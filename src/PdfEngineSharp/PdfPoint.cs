namespace PdfEngineSharp
{
    public class PdfPoint
    {
        public int X { get; }
        public int Y { get; }

        public PdfPoint(int x, int y)
        {
            if (x < 0)
                throw new ArgumentOutOfRangeException(nameof(x), "Value must be 0 or greater");
            if (y < 0)
                throw new ArgumentOutOfRangeException(nameof(y), "Value must be 0 or greater");

            X = x;
            Y = y;
        }

        public override string ToString() => $"{X} {Y}";
    }
}
