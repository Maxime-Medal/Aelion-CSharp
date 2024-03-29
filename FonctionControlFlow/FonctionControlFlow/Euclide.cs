﻿public static class Euclide // classe non instantiable, c'est généralement une boite à outils / class static = methode static
{
public static UInt64 Gcd(UInt64 a, UInt64 b)
{
        if (a == 0 || b == 0) throw new ArgumentException("Arg must be strictly positive");
    
        while (a != b)
    {
        if (a > b)
        {
            a -= b;
        }
        else
        {
            b -= a;
        }
    }
    return a;
}
}