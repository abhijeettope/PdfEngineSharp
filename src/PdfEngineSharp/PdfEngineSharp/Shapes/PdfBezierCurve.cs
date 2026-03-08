namespace PdfEngineSharp.Shapes
{
    public class PdfBezierCurve : PdfShape
    {
        private readonly PdfPoint Control1;
        private readonly PdfPoint Control2;
        private readonly PdfPoint End;

        public PdfBezierCurve(PdfPoint start, PdfPoint control1, PdfPoint control2, PdfPoint end)
            : base(start)
        {
            Control1 = control1;
            Control2 = control2;
            End = end;
        }

        public override string ToString()
        {
            return GetTopPart()
            + $"{Start} m\n"
            + $"{Control1} {Control2} {End} c\n"
            + $"{FillOrStroke}\n";
        }
    }
}
