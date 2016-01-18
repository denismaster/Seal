using System;
using Seal;
using CairoVars=global::Cairo;
namespace Seal.Platform.Cairo
{
	public static class ExtensionMethods
	{
		public static CairoVars.Point ToCairo(this Point p)
		{
			return new CairoVars.Point(p.X, p.Y);
		}
		public static CairoVars.PointD ToCairo(this Location p)
		{
			return new CairoVars.PointD(p.X, p.Y);
		}
		public static CairoVars.Color ToCairo(this Color color)
		{
			return new CairoVars.Color(
				(double)(color.R / 255.0),
				(double)(color.G / 255.0),
				(double)(color.B / 255.0),
				(double)(color.A / 255.0));
		}
	}
}

