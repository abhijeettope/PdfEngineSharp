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

*/