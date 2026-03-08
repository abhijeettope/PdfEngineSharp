using PdfEngineSharp.Utils;

namespace PdfEngineSharp
{
    public class PdfText
    {
        public PdfPoint Start { get; }
        public int FontSize { get; }
        public PdfColor FontColor { get; }
        public string Content { get; }
        public double AngleRadians { get; }

        public PdfText(PdfPoint start, string content)
            : this(start, 24, new PdfColor(0, 0, 0), content, 0)
        {
        }

        public PdfText(PdfPoint start, int fontSize, string content)
            : this(start, fontSize, new PdfColor(0, 0, 0), content, 0)
        {
        }

        public PdfText(PdfPoint start, int fontSize, PdfColor fontColor, string content, double angleDegrees)
        {
            if (fontSize <= 0)
                throw new ArgumentOutOfRangeException(nameof(fontSize), "Font size must be positive");

            if (string.IsNullOrWhiteSpace(content))
                throw new ArgumentException("Content cannot be empty", nameof(content));

            Start = start ?? throw new ArgumentNullException(nameof(start));
            FontSize = fontSize;
            FontColor = fontColor ?? throw new ArgumentNullException(nameof(fontColor));
            Content = content;
            AngleRadians = angleDegrees * (Math.PI / 180);
        }

        public override string ToString()
        {
            double a = Math.Cos(AngleRadians);
            double b = Math.Sin(AngleRadians);
            double c = -Math.Sin(AngleRadians);
            double d = Math.Cos(AngleRadians);

            return $"BT\n" +
                   $" /F1 {FontSize} Tf\n" +
                   $" {FontColor.ToString()} rg\n" +
                   $" {PdfEngineHelper.Fmt(a)} {PdfEngineHelper.Fmt(b)} {PdfEngineHelper.Fmt(c)} {PdfEngineHelper.Fmt(d)} {Start.ToString()} Tm\n" +
                   $" ({Content}) Tj\n" +
                   $"ET\n";
        }
    }
}


/*
BT
  /F1 24 Tf
  0.7071 -0.7071 0.7071 0.7071 100 100 Tm
  (Hello, PDF!) Tj
ET
-- code --
BT
  /F1 _font_size Tf
  cos(_angle_of_rotation) sin(_angle_of_rotation) -sin(_angle_of_rotation) cos(_angle_of_rotation) _start.x() _start.y() Tm
  (_content) Tj
ET
Note : _angle_of_rotation should be in radian
*/
