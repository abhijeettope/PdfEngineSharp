namespace PdfEngineSharp.Shapes
{
    public class PdfBezierCurve : PdfShape
    {
        private readonly PdfPoint Control1;
        private readonly PdfPoint Control2;
        private readonly PdfPoint End;

        public PdfBezierCurve(PdfPoint start, PdfPoint control1, PdfPoint control2, PdfPoint end)
            : base(start)
        {
            Control1 = control1;
            Control2 = control2;
            End = end;
        }

        public override string ToString()
        {
            return GetTopPart()
            + $"{Start} m\n"
            + $"{Control1} {Control2} {End} c\n"
            + $"{FillOrStroke}\n";
        }
    }
}

/*
 Cubic Bezier Curves
    2 End Points and 2 Control Points
P0 = Current Point, P3 = Final Point
P1 & P2 = Control Point

R(t) = [(1 - t)^3 ] * P0 + [ 3t(1-t)^2 ] * P1 + 3(t^2)(1-t) * P2 + (t^3) * P3

where 0 <= t <= 1

There are 3 Operators to draw Cubic Bezier Curve
c, v and y

x1 y1 x2 y2 x3 y3 c // here P0 is the current point P1 P2 and P3 are mentioned here
x2 y2 x3 y3 v // first control point is same as starting point
x1 y1 x3 y3 y // second control point is same as last point
 
 */