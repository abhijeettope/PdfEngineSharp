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
            string p1 = PdfEngineHelper.Fmt(Start.X + _radius * k);
            string p2 = PdfEngineHelper.Fmt(Start.X - _radius * k);
            string result = GetTopPart();
            result += $"{Start} m\n";
            result += $"{Start} {p1} {Start.Y} {p1} {p1} c\n";
            result += $"{p1} {Start.X} {Start.X} {p2} {Start.X} {p2} c\n";
            result += $"{Start.X} {PdfEngineHelper.Fmt(Start.X - _radius)} {p2} {p2} {p2} {Start.Y} c\n";
            result += $"{p2} {p1} {Start} {Start} c\n";
            result += $"{FillOrStroke}\n";
            return result;
        }
    }
}

/*

*/