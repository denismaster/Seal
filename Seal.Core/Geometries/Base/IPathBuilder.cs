using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seal.Geometries
{
    public interface IPathBuilder : IDisposable
    {
        /// <summary>
        /// Определяет начало фигуры
        /// </summary>
        /// <param name="startPoint"></param>
        /// <param name="isFilled"></param>
        void BeginFigure(Location startPoint, bool isFilled);
        /// <summary>
        /// Определяет конец фигуры
        /// </summary>
        /// <param name="isClosed"></param>
        void EndFigure(bool isClosed);
        /// <summary>
        /// Проводит линию из текущей точки в заданную
        /// </summary>
        /// <param name="p"></param>
        void LineTo(Location p);
        /// <summary>
        /// Рисует кривую Безье (4 степени) в заданную точку,используя дополнительные опорные точки
        /// </summary>
        /// <param name="end"></param>
        /// <param name="cp1"></param>
        /// <param name="cp2"></param>
        void BezierTo(Location end, Location cp1, Location cp2);
        /// <summary>
        /// Рисует дугу в заданную точку
        /// </summary>
        /// <param name="point"></param>
        /// <param name="size"></param>
        /// <param name="rotationAngle"></param>
        /// <param name="isLargeArc"></param>
        void ArcTo(Location point, Size size, double rotationAngle, bool isLargeArc);
    }
}
