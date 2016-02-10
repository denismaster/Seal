using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;
namespace Seal.Geometries
{
    public class GeometryParser
    {
        private static readonly Dictionary<char, Command> Commands = new Dictionary<char, Command>
        {
            { 'F', Command.FillRule },
            { 'f', Command.FillRule },
            { 'M', Command.Move },
            { 'm', Command.MoveRelative },
            { 'L', Command.Line },
            { 'l', Command.LineRelative },
            { 'H', Command.HorizontalLine },
            { 'h', Command.HorizontalLineRelative },
            { 'V', Command.VerticalLine },
            { 'v', Command.VerticalLineRelative },
            { 'C', Command.CubicBezierCurve },
            { 'c', Command.CubicBezierCurve },
            { 'Z', Command.Close },
            { 'z', Command.Close },
        };

        private IPath _geometry;

        private readonly IPathBuilder _context;

        public GeometryParser(IPath geometry, IPathBuilder context)
        {
            _geometry = geometry;
            _context = context;
        }

        private enum Command
        {
            None,
            FillRule,
            Move,
            MoveRelative,
            Line,
            LineRelative,
            HorizontalLine,
            HorizontalLineRelative,
            VerticalLine,
            VerticalLineRelative,
            CubicBezierCurve,
            CubicBezierCurveRelative,
            Close,
            Eof,
        }
        public void Parse(string s)
        {
            bool openFigure = false;

            using (StringReader reader = new StringReader(s))
            {
                Command lastCommand = Command.None;
                Command command;
                Location point = new Location();

                while ((command = ReadCommand(reader, lastCommand)) != Command.Eof)
                {
                    switch (command)
                    {
                        case Command.FillRule:
                            // TODO: Implement.
                            reader.Read();
                            break;

                        case Command.Move:
                        case Command.MoveRelative:
                            if (openFigure)
                            {
                                _context.EndFigure(false);
                            }

                            if (command == Command.Move)
                            {
                                point = ReadLocation(reader);
                            }
                            else
                            {
                                point = ReadRelativeLocation(reader, point);
                            }

                            _context.BeginFigure(point, true);
                            openFigure = true;
                            break;

                        case Command.Line:
                            point = ReadLocation(reader);
                            _context.LineTo(point);
                            break;

                        case Command.LineRelative:
                            point = ReadRelativeLocation(reader, point);
                            _context.LineTo(point);
                            break;

                        case Command.HorizontalLine:
                            point = new Location(ReadDouble(reader), point.Y);
                            _context.LineTo(point);
                            break;

                        case Command.HorizontalLineRelative:
                            point = new Location(ReadDouble(reader), point.Y);
                            _context.LineTo(point);
                            break;

                        case Command.VerticalLine:
                            point = new Location(point.X, ReadDouble(reader));
                            _context.LineTo(point);
                            break;

                        case Command.VerticalLineRelative:
                            point = new Location(point.X, point.Y + ReadDouble(reader));
                            _context.LineTo(point);
                            break;

                        case Command.CubicBezierCurve:
                            {
                                Location point1 = ReadLocation(reader);
                                Location point2 = ReadLocation(reader);
                                point = ReadLocation(reader);
                                _context.BezierTo(point1, point2, point);
                                break;
                            }

                        case Command.Close:
                            _context.EndFigure(true);
                            openFigure = false;
                            break;

                        default:
                            throw new NotSupportedException("Unsupported command");
                    }

                    lastCommand = command;
                }

                if (openFigure)
                {
                    _context.EndFigure(false);
                }
            }
        }

        private static Command ReadCommand(StringReader reader, Command lastCommand)
        {
            ReadWhitespace(reader);

            int i = reader.Peek();

            if (i == -1)
            {
                return Command.Eof;
            }
            else
            {
                char c = (char)i;
                Command command = Command.None;

                if (!Commands.TryGetValue(c, out command))
                {
                    if ((char.IsDigit(c) || c == '.' || c == '+' || c == '-') &&
                        (lastCommand != Command.None))
                    {
                        return lastCommand;
                    }
                    else
                    {
                        throw new InvalidDataException("Unexpected path command '" + c + "'.");
                    }
                }

                reader.Read();
                return command;
            }
        }

        private static float ReadDouble(TextReader reader)
        {
            // TODO: Handle Infinity, NaN and scientific notation.
            StringBuilder b = new StringBuilder();
            bool readSign = false;
            bool readLocation = false;
            bool readExponent = false;
            int i;

            while ((i = reader.Peek()) != -1)
            {
                char c = char.ToUpperInvariant((char)i);

                if (((c == '+' || c == '-') && !readSign) ||
                    (c == '.' && !readLocation) ||
                    (c == 'E' && !readExponent) ||
                    char.IsDigit(c))
                {
                    b.Append(c);
                    reader.Read();
                    readSign = c == '+' || c == '-';
                    readLocation = c == '.';

                    if (c == 'E')
                    {
                        readSign = false;
                        readExponent = c == 'E';
                    }
                }
                else
                {
                    break;
                }
            }

            return float.Parse(b.ToString());
        }

        private static Location ReadLocation(StringReader reader)
        {
            ReadWhitespace(reader);
            float x = ReadDouble(reader);
            ReadSeparator(reader);
            float y = ReadDouble(reader);
            return new Location(x, y);
        }

        private static Location ReadRelativeLocation(StringReader reader, Location lastLocation)
        {
            ReadWhitespace(reader);
            float x = ReadDouble(reader);
            ReadSeparator(reader);
            float y = ReadDouble(reader);
            return new Location(lastLocation.X + x, lastLocation.Y + y);
        }

        private static void ReadSeparator(StringReader reader)
        {
            int i;
            bool readComma = false;

            while ((i = reader.Peek()) != -1)
            {
                char c = (char)i;

                if (char.IsWhiteSpace(c))
                {
                    reader.Read();
                }
                else if (c == ',')
                {
                    if (readComma)
                    {
                        throw new InvalidDataException("Unexpected ','.");
                    }

                    readComma = true;
                    reader.Read();
                }
                else
                {
                    break;
                }
            }
        }

        private static void ReadWhitespace(StringReader reader)
        {
            int i;

            while ((i = reader.Peek()) != -1)
            {
                char c = (char)i;

                if (char.IsWhiteSpace(c))
                {
                    reader.Read();
                }
                else
                {
                    break;
                }
            }
        }
    }
}
