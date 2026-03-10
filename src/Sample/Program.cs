using PdfEngineSharp;
using PdfEngineSharp.Shapes;

Console.WriteLine("Hello from sample for PDF Engine Sharp...");

Pdf myPdf = new Pdf();

myPdf.Add(1, new PdfLine(
    new PdfPoint(10, 10),
    new PdfPoint(100, 100)
    ));

string output = myPdf.Get();

Console.WriteLine("Output string of PDF.");
Console.WriteLine(output);