using PdfEngineSharp.Shapes;

namespace PdfEngineSharp
{
    public class PdfPageContent
    {
        private int _obj_no;
        private int _generation_no = 0;

        private List<PdfLine> _lines = new List<PdfLine>();
        private List<PdfText> _texts = new List<PdfText>();
        private List<PdfRectangle> _rectangles = new List<PdfRectangle>();
        private List<PdfSquare> _squares = new List<PdfSquare>();
        private List<PdfCustomeShape> _custome_shapes = new List<PdfCustomeShape>();
        private List<PdfCircle> _circles = new List<PdfCircle>();
        private List<PdfBezierCurve> _bezier_curves = new List<PdfBezierCurve>();

        private string _result = string.Empty;

        public PdfPageContent(int obj_no)
        {
            _obj_no = obj_no;
        }

        private void Build()
        {
            string page_stream = "";

            foreach (PdfLine line in _lines)
                page_stream += line;

            foreach (PdfText text in _texts)
                page_stream += text;

            foreach (PdfRectangle rec in _rectangles)
                page_stream += rec;

            foreach (PdfSquare sqr in _squares)
                page_stream += sqr;

            foreach (PdfCustomeShape cus_shape in _custome_shapes)
                page_stream += cus_shape;

            foreach (PdfCircle circle in _circles)
                page_stream += circle;

            foreach (PdfBezierCurve b_curve in _bezier_curves)
                page_stream += b_curve;

            _result = _obj_no.ToString() + " " + _generation_no.ToString() + " obj\n";
            _result += "  << /Length " + page_stream.Length.ToString() + " >>\n";
            _result += "stream\n";
            _result += page_stream;
            _result += "endstream\n";
            _result += "endobj\n";
        }

        public void Add(PdfLine line)
        {
            _lines.Add(line);
        }

        public void Add(PdfText text)
        {
            _texts.Add(text);
        }

        public void Add(PdfRectangle rectangle)
        {
            _rectangles.Add(rectangle);
        }

        public void Add(PdfSquare square)
        {
            _squares.Add(square);
        }

        public void Add(PdfCustomeShape shape)
        {
            _custome_shapes.Add(shape);
        }

        public void Add(PdfCircle circle)
        {
            _circles.Add(circle);
        }

        public void Add(PdfBezierCurve curve)
        {
            _bezier_curves.Add(curve);
        }

        public string GetOG()
        {
            return _obj_no.ToString() + " " + _generation_no.ToString();
        }

        public string Get()
        {
            Build();
            return _result;
        }

    }
}

/*
% --- Page 1 Content ---
8 0 obj
  << /Length 44 >>
stream
BT
  /F1 24 Tf
  50 100 Td
  (Page 1: Hello!) Tj
ET
endstream
endobj
*/

