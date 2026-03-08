namespace PdfEngineSharp.Shapes
{
    public class PdfCustomeShape : PdfShape
    {
        private readonly List<PdfPoint> _points = new List<PdfPoint>();

        public PdfCustomeShape(PdfPoint start)
            : base(start)
        {
        }

        public PdfCustomeShape(PdfPoint start, List<PdfPoint> points)
            : base(start)
        {
            _points = points;
        }

        public void AddPdfPoint(PdfPoint point)
        {
            _points.Add(point);
        }

        public override string ToString()
        {
            string result = GetTopPart() +
                   $"{Start} m\n";
            foreach (PdfPoint p in _points)
            {
                result += $"{p} l\n";
            }
            result += "h\n"; // Close path to first PDF Point
            result += $"{FillOrStroke}\n";
            return result;
        }

    }
}
