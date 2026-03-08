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
use move to and line for creating lines
0 0 1 RG       % stroke color blue
2 w            % line width
100 100 m      % move to first vertex
200 100 l      % line to second vertex
S              % stroke
*/