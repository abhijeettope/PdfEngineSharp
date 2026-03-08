using System.Globalization;

namespace PdfEngineSharp.Utils
{
    internal class PdfEngineHelper
    {
        public static string Fmt(double value)
        {
            return value.ToString("F4", CultureInfo.InvariantCulture);
        }
    }
}
