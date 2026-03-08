using PdfEngineSharp.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PdfEngineSharp
{
    public class PdfPage
    {
        private int _obj_no;
        private int _parent_obj_no;
        private int _generation_no = 0;

        private PdfPageContent _page_content;
        private string _result = string.Empty;

        public PdfPage(int obj_no, PdfPageContent page_content)
        {
            _obj_no = obj_no;
            _page_content = page_content;
        }

        private void Build()
        {
            _result = _obj_no.ToString() + " " + _generation_no.ToString() + " obj\n";
            _result += "  << /Type /Page\n";
            _result += "     /Parent " + _parent_obj_no.ToString() + " 0 R\n";
            _result += "     /Contents " + _page_content.GetOG() + " R\n";
            _result += "  >>\n";
            _result += "endobj\n";
        }

        public void SetParent(int x)
        {
            _parent_obj_no = x;
        }

        public string GetOG()
        {
            return _obj_no.ToString() + " " + _generation_no.ToString();
        }

        public string GetPageDefination()
        {
            Build();
            return _result;
        }

        public string GetPageContent()
        {
            return _page_content.Get();
        }

        public void Add(PdfText text)
        {
            _page_content.Add(text);
        }

        public void Add(PdfLine line)
        {
            _page_content.Add(line);
        }

        public void Add(PdfRectangle rectangle)
        {
            _page_content.Add(rectangle);
        }

        public void Add(PdfSquare square)
        {
            _page_content.Add(square);
        }

        public void Add(PdfCustomeShape shape)
        {
            _page_content.Add(shape);
        }

        public void Add(PdfCircle circle)
        {
            _page_content.Add(circle);
        }

        public void Add(PdfBezierCurve curve)
        {
            _page_content.Add(curve);
        }

    }
}

/*
% --- Page 1 ---
4 0 obj
  << /Type /Page
     /Parent 3 0 R
     /Contents 8 0 R
  >>
endobj
*/