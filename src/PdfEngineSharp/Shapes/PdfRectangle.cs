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
x y height width re // will draw rectangle from point (x, y) of height and width specified
*/