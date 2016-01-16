﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Reflection;
namespace Seal
{
    public struct Color
    {
        /// <summary>
        /// Gets or sets the Alpha component of the color.
        /// </summary>
        public byte A { get; set; }

        /// <summary>
        /// Gets or sets the Red component of the color.
        /// </summary>
        public byte R { get; set; }

        /// <summary>
        /// Gets or sets the Green component of the color.
        /// </summary>
        public byte G { get; set; }

        /// <summary>
        /// Gets or sets the Blue component of the color.
        /// </summary>
        public byte B { get; set; }

        /// <summary>
        /// Creates a <see cref="Color"/> from alpha, red, green and blue components.
        /// </summary>
        /// <param name="a">The alpha component.</param>
        /// <param name="r">The red component.</param>
        /// <param name="g">The green component.</param>
        /// <param name="b">The blue component.</param>
        /// <returns>The color.</returns>
        public static Color FromArgb(byte a, byte r, byte g, byte b)
        {
            return new Color
            {
                A = a,
                R = r,
                G = g,
                B = b,
            };
        }

        /// <summary>
        /// Creates a <see cref="Color"/> from red, green and blue components.
        /// </summary>
        /// <param name="r">The red component.</param>
        /// <param name="g">The green component.</param>
        /// <param name="b">The blue component.</param>
        /// <returns>The color.</returns>
        public static Color FromRgb(byte r, byte g, byte b)
        {
            return new Color
            {
                A = 0xff,
                R = r,
                G = g,
                B = b,
            };
        }

        /// <summary>
        /// Creates a <see cref="Color"/> from an integer.
        /// </summary>
        /// <param name="value">The integer value.</param>
        /// <returns>The color.</returns>
        public static Color FromUInt32(uint value)
        {
            return new Color
            {
                A = (byte)((value >> 24) & 0xff),
                R = (byte)((value >> 16) & 0xff),
                G = (byte)((value >> 8) & 0xff),
                B = (byte)(value & 0xff),
            };
        }

        /// <summary>
        /// Parses a color string.
        /// </summary>
        /// <param name="s">The color string.</param>
        /// <returns>The <see cref="Color"/>.</returns>
        public static Color Parse(string s)
        {
            if (s[0] == '#')
            {
                var or = 0u;

                if (s.Length == 7)
                {
                    or = 0xff000000;
                }
                else if (s.Length != 9)
                {
                    throw new FormatException(String.Format("Invalid color string: '{0}'.",s));
                }

                return FromUInt32(uint.Parse(s.Substring(1), NumberStyles.HexNumber, CultureInfo.InvariantCulture) | or);
            }
            else
            {
                var upper = s.ToUpperInvariant();
                var member = typeof(Colors).GetTypeInfo().DeclaredProperties
                    .FirstOrDefault(x => x.Name.ToUpperInvariant() == upper);

                if (member != null)
                {
                    return (Color)member.GetValue(null);
                }
                else
                {
                    throw new FormatException(String.Format("Invalid color string: '{0}'.",s));
                }
            }
        }

        /// <summary>
        /// Returns the string representation of the color.
        /// </summary>
        /// <returns>
        /// The string representation of the color.
        /// </returns>
        public override string ToString()
        {
            uint rgb = ((uint)A << 24) | ((uint)R << 16) | ((uint)G << 8) | (uint)B;
            return string.Format("#{0:x8}", rgb);
        }

        /// <summary>
        /// Returns the integer representation of the color.
        /// </summary>
        /// <returns>
        /// The integer representation of the color.
        /// </returns>
        public uint ToUint32()
        {
            return ((uint)A << 24) | ((uint)R << 16) | ((uint)G << 8) | (uint)B;
        }
    }
}
