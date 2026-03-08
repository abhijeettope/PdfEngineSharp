using PdfEngineSharp.Shapes;

namespace PdfEngineSharp
{
    public class Pdf
    {
        private string _header;
        private string _body;
        private PdfPageTree _pageTree;
        private int objCount = 2;

        public Pdf()
        {
            _pageTree = new PdfPageTree();

            _header = "%PDF-1.4\n";
            _body = "1 0 obj\n";
            _body += "  << /Type /Catalog /Pages 2 0 R >>\n";
            _body += "endobj\n";

            AddPage();
        }

        public string Get()
        {
            string result = _header;
            result += _body;
            result += _pageTree.Get();

            // rough logic to build XREF
            // result += "xref\n";
            // result += "0 " + 12.ToString();
            // result += "0000000000 65535 f\n";
            // result += 12.ToString() + " 00000 n\n";

            result += "trailer\n";
            result += "<< /Size " + objCount.ToString() + "\n";
            result += "   /Root 1 0 R\n";
            result += ">>\n";
            result += "%%EOF";

            return result;
        }

        public void AddPage()
        {
            int obj1 = ++objCount;
            int obj2 = ++objCount;

            PdfPage p = new PdfPage(obj1, new PdfPageContent(obj2));
            p.SetParent(2);

            _pageTree.Add(p);
        }

        // Overloaded Add methods for different shapes
        public void Add(int pageNo, PdfText text)
        {
            if (_pageTree.NoOfPages() < pageNo)
                throw new Exception("Exception: Page number exceeding no of pages in pdf");
            _pageTree.Add(pageNo, text);
        }

        public void Add(int pageNo, PdfLine line)
        {
            if (_pageTree.NoOfPages() < pageNo)
                throw new Exception("Exception: Page number exceeding no of pages in pdf");
            _pageTree.Add(pageNo, line);
        }

        public void Add(int pageNo, PdfRectangle rectangle)
        {
            if (_pageTree.NoOfPages() < pageNo)
                throw new Exception("Exception: Page number exceeding no of pages in pdf");
            _pageTree.Add(pageNo, rectangle);
        }

        public void Add(int pageNo, PdfSquare square)
        {
            if (_pageTree.NoOfPages() < pageNo)
                throw new Exception("Exception: Page number exceeding no of pages in pdf");
            _pageTree.Add(pageNo, square);
        }

        public void Add(int pageNo, PdfCustomeShape shape)
        {
            if (_pageTree.NoOfPages() < pageNo)
                throw new Exception("Exception: Page number exceeding no of pages in pdf");
            _pageTree.Add(pageNo, shape);
        }

        public void Add(int pageNo, PdfCircle circle)
        {
            if (_pageTree.NoOfPages() < pageNo)
                throw new Exception("Exception: Page number exceeding no of pages in pdf");
            _pageTree.Add(pageNo, circle);
        }

        public void Add(int pageNo, PdfBezierCurve curve)
        {
            if (_pageTree.NoOfPages() < pageNo)
                throw new Exception("Exception: Page number exceeding no of pages in pdf");
            _pageTree.Add(pageNo, curve);
        }

    }
}

// IPdfDrawable will reduce code base size by a lot try using this
// User string builder instead of appending string
// todo : add resouces to the pdf file for page font and all other things