namespace PdfEngineSharp.Shapes
{
    public class PdfLine : PdfShape
    {
        public PdfPoint End { get; }

        public PdfLine(PdfPoint start, PdfPoint end)
            : base(start)
        {
            End = end ?? throw new ArgumentNullException(nameof(end));
        }

        public override string ToString()
        {
            return GetTopPart() +
                   $"{Start} m\n" +   // move to start point
                   $"{End} l\n" +    // draw line to end point
                   $"{FillOrStroke}\n";
        }
    }
}

/*
 Drawing Line in PDF
a b m // move to point (a, b)
x y l // draw line from current point to (x, y)
so this will draw line from (a, b) to (x, y)
*/