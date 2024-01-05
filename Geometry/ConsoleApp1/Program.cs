// See https://aka.ms/new-console-template for more information
using Geometry.Extensions;
using Geometry.Model;
using System.Linq;

Console.WriteLine("Hello, World!");


// IMesurable1D m = null;
// Form f = null;
IList<Point> points = new List<Point>() {
    new() { Name = "O", X = 0.0, Y = 0.0 },
    new() { Name = "A", X = 3.0, Y = 0.0 },
    new() { Name = "B", X = 0.0, Y = 4.0 },
    new() { Name = "D", X = 5.25, Y = 3.5 },
    new() { Name = "E", X = -5.25, Y = 3.5 },
};

IList<Form> forms = new List<Form>(points);

foreach (Point p in points)
{
    Console.WriteLine(p);
    Console.WriteLine($"{p.Name}, {p.X}, {p.Y}");
    Console.WriteLine();
}

points[^1].Y = 12.75;
Console.WriteLine(points[^1]);

Circle circleC1 = new()
{
    Name = "C1",
    Center = points[0],
    Radius = 10.0,
};
forms.Add(circleC1);

Console.WriteLine();
foreach (var form in forms)
{
    Console.WriteLine(form);
}

Point po1 = new Point() { X = 3, Y = 4 };
Point po2 = new Point() { X = 5, Y = 6 };

Console.WriteLine(po1.Distance(po2)); ;

Polygon p1 = new("p1", [points[0], points[1], points[2]]);
forms.Add(p1);
Console.WriteLine(p1);

try
{
    Polygon p2 = new("?", [points[0]]);
}
catch (ArgumentException ex)
{
    Console.WriteLine("!! Not possible ;) !!");
}

// Surface Totale de toutes les formes IMesurable2D
foreach (var form in forms)
{
    if (form is IMesurable2D m) // down casting, on attribu la variable avec le type voulu 
    {
        double area = m.Area;
        Console.WriteLine($"This {form} is IMesurable2D, has area {area}");
    }
}

// faire cela en Linq
// Where : Form IMesurable2D
// Select: Form => Area 
// Final : SUM

double totalArea = forms.Where(f => f is not null and IMesurable2D) // patern and or not 
   .Select(f => (f as IMesurable2D))
   .Sum(m => m!.Area);

Console.WriteLine(totalArea);

// pattern  matching (swith or is)
// https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/functional/pattern-matching
foreach (var point in points)
{
    switch (point)
    {
        case { Name: "O" }:
            Console.WriteLine($"Point O: {point}");
            break;
        case
        {
            Name: var name,
            X: < 0.0
        }:
            Console.WriteLine($"Point negative X: {name}");
            break;
        case
        {
            X: var x,
            Y: >= 1.0 and <= 5.0
        }:
            Console.WriteLine($"Point with Y in [1..5] and X={x}: {point}");
            break;
        case
        {
            X: var x,
            Y: var y
        } when x > Math.Pow(y, 2):
            Console.WriteLine($"Point with X linkedto Y {point}");
            break;
    }
}

Console.WriteLine("*******************");

Comparison<Point> cpm = (p1, p2) => (int)(p1.X - p2.X);
Func<Point, Point, int> cpm2 = (p1, p2) => (int)(p1.X - p2.X);

var pointSample = p1.Where(p => p.X > 0.0)
    .ToList();
foreach (var point in pointSample)
{
    Console.WriteLine($"{point}");
}

p1.Translate(1.0, -1.0);
var names = String.Join('_',
    p1.Where(p => p.X > 0.0)
    .Select(p1 => p1.Name));
Console.WriteLine(names);

var pointA = points[1];
pointA += 2;
var pointA2 = pointA + 3;
Console.WriteLine($"{pointA}, {pointA2}");