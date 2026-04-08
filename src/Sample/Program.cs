using PdfEngineSharp;
using PdfEngineSharp.Shapes;

Console.WriteLine("Hello from sample for PDF Engine Sharp ...");

Pdf pdf = new Pdf();

// To draw line from point x to point y
//pdf.Add(1, new PdfLine(new PdfPoint(10, 10), new PdfPoint(100, 100)));

// to draw rectangle
//pdf.Add(1, new PdfRectangle(new PdfPoint(200, 100), 200, 100));

// to add text box
//pdf.Add(1, new PdfText(new PdfPoint(100, 500), "Hello World!"));

// to add custome shape
//pdf.Add(1, new PdfCustomeShape(new PdfPoint(200, 200), new List<PdfPoint>() { new PdfPoint(300, 200), new PdfPoint(400, 100)}));

//  to add circle
pdf.Add(1, new PdfCircle(new PdfPoint(200, 500), 20));
pdf.Add(1, new PdfCircle(new PdfPoint(200, 500), 30));
pdf.Add(1, new PdfCircle(new PdfPoint(300, 500), 20));
pdf.Add(1, new PdfCircle(new PdfPoint(300, 500), 30));

pdf.Add(1, new PdfCircle(new PdfPoint(250, 450), 110));

// to draw cubic bezier curve
//pdf.Add(1, new PdfBezierCurve(new PdfPoint(100, 200), new PdfPoint(155, 199), new PdfPoint(199, 155), new PdfPoint(200, 100)));

pdf.Save("D:\\temp\\test.pdf");


