namespace PdfEngineSharp.Shapes
{
    public class PdfRectangle : PdfShape
    {
        public int Height { get; }
        public int Width { get; }

        public PdfRectangle(PdfPoint start, int height, int width)
            : base(start)
        {
            if (height <= 0)
                throw new ArgumentOutOfRangeException(nameof(height), "Height must be greater than zero");

            if (width <= 0)
                throw new ArgumentOutOfRangeException(nameof(width), "Width must be greater than zero");

            Height = height;
            Width = width;
        }

        public override string ToString()
        {
            return GetTopPart() +
                   $"{Start} {Width} {Height} re\n" +
                   $"{FillOrStroke}\n";
        }
    }

    public class PdfSquare : PdfRectangle
    {
        public PdfSquare(PdfPoint start, int side)
            : base(start, side, side)
        {
        }
    }
}
/*
0 0 1 RG        % stroke color blue
0.8 0.8 1 rg    % fill color light blue
2 w              % line width
100 100 200 100 re  % rectangle x y width height
B                % fill + stroke
-- code --
B = fill and stroke together (f + S).

100 100 200 100 re  % rectangle at (100,100), width=200, height=100
*/