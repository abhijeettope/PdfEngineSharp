using PdfEngineSharp.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PdfEngineSharp
{
    public class PdfPageTree
    {
        private const int _obj_no = 2;
        private int _generation_no = 0;

        private List<PdfPage> _pages = new List<PdfPage>();
        private string _result = string.Empty;

        public PdfPageTree() { }

        public PdfPageTree(List<PdfPage> pages)
        {
            _pages = pages;
        }

        private void Build()
        {
            string str_page_definations = "";
            string str_page_contents = "";
            string str_kids_og = "";

            foreach (PdfPage p in _pages)
            {
                str_page_definations += p.GetPageDefination();
                str_page_contents += p.GetPageContent();
                str_kids_og += p.GetOG() + " R ";
            }

            _result = GetOG() + " obj\n";
            _result += "  << /Type /Pages\n";
            _result += "     /Parent 1 0 R\n";
            _result += "     /Kids [" + str_kids_og + "]\n";
            _result += "     /Count " + _pages.Count.ToString() + "\n";
            _result += "     /MediaBox [0 0 612 792]\n";
            _result += "  >>\n";
            _result += "endobj\n";

            _result += str_page_definations + str_page_contents;
        }

        public void Add(PdfPage page)
        {
            _pages.Add(page);
        }

        public string GetOG()
        {
            return _obj_no.ToString() + " " + _generation_no.ToString();
        }

        public int NoOfPages()
        {
            return _pages.Count;
        }

        public string Get()
        {
            Build();
            return _result;
        }

        public void Add(int page_no, PdfText text)
        {
            if (_pages.Count < page_no)
                throw new Exception("Exception : Page number exceeding no of pages in pdf.");

            _pages[page_no - 1].Add(text);
        }

        public void Add(int page_no, PdfLine line)
        {
            if (_pages.Count < page_no)
                throw new Exception("Exception : Page number exceeding no of pages in pdf.");

            _pages[page_no - 1].Add(line);
        }

        public void Add(int page_no, PdfRectangle rectangle)
        {
            if (_pages.Count < page_no)
                throw new Exception("Exception : Page number exceeding no of pages in pdf.");

            _pages[page_no - 1].Add(rectangle);
        }

        public void Add(int page_no, PdfSquare square)
        {
            if (_pages.Count < page_no)
                throw new Exception("Exception : Page number exceeding no of pages in pdf.");

            _pages[page_no - 1].Add(square);
        }

        public void Add(int page_no, PdfCustomeShape shape)
        {
            if (_pages.Count < page_no)
                throw new Exception("Exception : Page number exceeding no of pages in pdf.");

            _pages[page_no - 1].Add(shape);
        }

        public void Add(int page_no, PdfCircle circle)
        {
            if (_pages.Count < page_no)
                throw new Exception("Exception : Page number exceeding no of pages in pdf.");

            _pages[page_no - 1].Add(circle);
        }

        public void Add(int page_no, PdfBezierCurve curve)
        {
            if (_pages.Count < page_no)
                throw new Exception("Exception : Page number exceeding no of pages in pdf.");

            _pages[page_no - 1].Add(curve);
        }
    }
}


/*
% --- Page tree ---
3 0 obj
  << /Type /Pages
     /Parent 1 0 R
     /Kids [4 0 R 5 0 R]
     /Count 2
     /MediaBox [0 0 300 200] // defines page size width × heigh
  >>
endobj

Note : we are not planing to add multiple page trees so we will keep parent for this one always 1.
along with that we will keep object number for this pdf as always 2.
*/
