namespace PdfEngineSharp.Shapes
{
    public class PdfShape
    {
        protected PdfColor StrokeColor;
        protected PdfColor FillColor;
        protected int LineWidth;
        protected string FillOrStroke;
        protected PdfPoint Start;

        public PdfShape(PdfPoint start)
        {
            Start = start ?? throw new ArgumentNullException(nameof(start));
            StrokeColor = new PdfColor(0, 0, 1); // default stroke = blue
            FillColor = new PdfColor(1, 0, 0);   // default fill = red
            LineWidth = 2;
            FillOrStroke = "S";                 // default: stroke only
        }

        protected string GetTopPart()
        {
            // RG = stroke color, rg = fill color, w = line width
            return $"{StrokeColor.ToString()} RG\n" +
                   $"{FillColor.ToString()} rg\n" +
                   $"{LineWidth} w\n";
        }

        public void SetStrokeColor(PdfColor color)
        {
            StrokeColor = color ?? throw new ArgumentNullException(nameof(color));
        }

        public void SetFillColor(PdfColor color)
        {
            FillColor = color ?? throw new ArgumentNullException(nameof(color));
        }

        public void SetWidth(int width)
        {
            if (width <= 0)
                throw new ArgumentOutOfRangeException(nameof(width), "Line width must be positive");

            LineWidth = width;
        }

        public void Fill()
        {
            FillOrStroke = "f";
        }

        public void Stroke()
        {
            FillOrStroke = "S";
        }

        public void FillAndStroke()
        {
            FillOrStroke = "B";
        }
    }

}

/*

*/  