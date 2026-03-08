namespace PdfEngineSharp
{
    public class PdfColor
    {
        public float Red { get; }
        public float Green { get; }
        public float Blue { get; }

        public PdfColor(float red, float green, float blue)
        {
            if (red < 0 || red > 1)
                throw new ArgumentOutOfRangeException(nameof(red), "Value must be between 0 and 1");
            if (green < 0 || green > 1)
                throw new ArgumentOutOfRangeException(nameof(green), "Value must be between 0 and 1");
            if (blue < 0 || blue > 1)
                throw new ArgumentOutOfRangeException(nameof(blue), "Value must be between 0 and 1");

            Red = red;
            Green = green;
            Blue = blue;
        }
        public override string ToString() => $"{Red:F4} {Green:F4} {Blue:F4}";
    }
}
