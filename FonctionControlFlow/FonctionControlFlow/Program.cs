﻿

void NewYearCounter(UInt32 cpt)
{
    while (cpt > 0)
    {
        Console.WriteLine(cpt);
        --cpt;
    }
    Console.WriteLine("Happy new year !!");
}

NewYearCounter(10);


UInt64 a = 12;
UInt64 b = 27;
UInt64 g = Euclide.Gcd(12, 27);
Console.WriteLine($"Gcd({a}, {b}) = {g}");
Console.WriteLine("---------");

Console.WriteLine(Weather.Kind(5));
Console.WriteLine(Weather.Kind2(19));
Console.WriteLine(Weather.Kind3(30));