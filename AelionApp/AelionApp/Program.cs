// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

String city = "Toulouse";
Console.WriteLine(city);
Console.WriteLine(city.ToLower());
Console.WriteLine(city[0]);
Console.WriteLine(city.Length);
Console.WriteLine("------");

//Console.WriteLine(city[8]); // Exception car hors du tableau
//city[0] = "j"; // non mutable

foreach (char c in city)
{
    Console.WriteLine(c);
}

for (int i = 0; i < city.Length; i++)
{
    Console.WriteLine(city[i].ToString().ToUpper());
}

Double[] temperatures = { 12.4, 13.2, 14.7 , 16.8, 17.4, 18.9, 19.1};
temperatures[0] = 22.4;

Console.WriteLine(temperatures[0]);
Console.WriteLine(temperatures[^1]);

Console.WriteLine();
foreach (Double t in temperatures)
{
    Console.WriteLine(t);
}


// slice operator
Console.WriteLine();
foreach (Double t in temperatures[2..5])
{
    Console.WriteLine(t);
}

Console.WriteLine();
foreach (Double t in temperatures[..4])
{
    Console.WriteLine(t);
}

Console.WriteLine();
foreach (Double t in temperatures[^2..])
{
    Console.WriteLine(t);
}