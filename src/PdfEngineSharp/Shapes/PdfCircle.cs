using PdfEngineSharp.Utils;

namespace PdfEngineSharp.Shapes
{
    public class PdfCircle : PdfShape
    {
        private const double k = 0.55228; // constant for perfect circle approximation
        private readonly double _radius;

        public PdfCircle(PdfPoint start, double radius) : base(start)
        {
            this._radius = radius;
        }

        public override string ToString()
        {
            PdfPoint P0 = new PdfPoint(this.Start.X, this.Start.Y + (int)this._radius);
            PdfPoint P1 = new PdfPoint(this.Start.X + (int)(_radius * 0.55), this.Start.Y + (int)(_radius * 0.99));
            PdfPoint P2 = new PdfPoint(this.Start.X + (int)(_radius * 0.99), this.Start.Y + (int)(_radius * 0.55));
            PdfPoint P3 = new PdfPoint(this.Start.X + (int)this._radius, this.Start.Y);
                        
            string result = GetTopPart();
            result += $"{Start.X} {Start.Y + _radius} m\n";
            result += $"{PdfEngineHelper.Fmt(Start.X + _radius * 0.55)} {PdfEngineHelper.Fmt(Start.Y + _radius * 0.99)} {PdfEngineHelper.Fmt(Start.X + _radius * 0.99)} {PdfEngineHelper.Fmt(Start.Y + _radius * 0.55)} {Start.X + _radius} {Start.Y} c\n";
            result += $"{PdfEngineHelper.Fmt(Start.X + _radius * 0.99)} {PdfEngineHelper.Fmt(Start.Y - _radius * 0.55)} {PdfEngineHelper.Fmt(Start.X + _radius * 0.55)} {PdfEngineHelper.Fmt(Start.Y - _radius * 0.99)} {Start.X} {Start.Y - _radius} c\n";
            result += $"{PdfEngineHelper.Fmt(Start.X - _radius * 0.55)} {PdfEngineHelper.Fmt(Start.Y - _radius * 0.99)} {PdfEngineHelper.Fmt(Start.X - _radius * 0.99)} {PdfEngineHelper.Fmt(Start.Y - _radius * 0.55)} {Start.X - _radius} {Start.Y} c\n";
            result += $"{PdfEngineHelper.Fmt(Start.X - _radius * 0.99)} {PdfEngineHelper.Fmt(Start.Y + _radius * 0.55)} {PdfEngineHelper.Fmt(Start.X - _radius * 0.55)} {PdfEngineHelper.Fmt(Start.Y + _radius * 0.99)} {Start.X} {Start.Y + _radius} c\n";
            //result += $"{p1} {Start.X} {Start.X} {p2} {Start.X} {p2} c\n";
            //result += $"{Start.X} {PdfEngineHelper.Fmt(Start.X - _radius)} {p2} {p2} {p2} {Start.Y} c\n";
            //result += $"{p2} {p1} {Start} {Start} c\n";
            result += $"{FillOrStroke}\n";
            return result;
        }
    }
}

/*
Cubic Bezier Curves
    2 End Points and 2 Control Points
P0 = Current Point, P3 = Final Point
P1 & P2 = Control Point

There are 3 Operators to draw Cubic Bezier Curve
c, v and y

x1 y1 x2 y2 x3 y3 c // here P0 is the current point P1 P2 and P3 are mentioned here

===================================================================================

There is no operator by which we can draw circle so we will try to approximate cirlce with Cubic Bezier Curve
Following is the article for referance
https://spencermortensen.com/articles/bezier-circle/
following is my understand from above aritcle
If center is (x, y) and radius is r
then following will be the points for bezier curve for right top arc of circle
P0 => [ x, y + r]
P1 => [ x + ( r * 0.55 ), y + ( r * 0.99 ) ]
P2 => [ x + ( r * 0.99 ), y + ( r * 0.55 ) ]
P3 => [ x + r, y ]

need to check how we can get points for others arcs of circle
*/