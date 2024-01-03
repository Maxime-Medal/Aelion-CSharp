using System.Collections.Generic;

void DisplayList(IList<string> list)
{
    Console.WriteLine(list.Count);
    Console.Write("#[");
    foreach (string el in list)
    {
        Console.Write(el + " ");
    }
    Console.WriteLine("]");
}

void DisplayCollection<T>(ICollection<T> collection, Int32 maxDisplay = 10)
{
    Console.WriteLine(collection.Count);
    Console.Write("#[");

    if (collection.Count <= maxDisplay)
    {
        foreach (var el in collection)
        {
            Console.Write(el + " ");
        }
    }
    else
    {

        // au dela de 10 éléments, afficher uniquement les 5 premiers et 5 derniers avec la methode getEnumerator poru gérer la boucle à la main
        var it = collection.GetEnumerator();
    Int32 spanSize = maxDisplay / 2;
    Int32 skipSize = collection.Count - 2 * spanSize;

    for (Int32 i = 0; i < spanSize; i++)
    {
        it.MoveNext();
    var elt = it.Current;
    Console.WriteLine(elt);
    }

    Console.WriteLine("... ");
    for (Int32 i = 0; i < skipSize; i++) it.MoveNext();

    for (Int32 i = 0; i < 5; i++)
    {
        it.MoveNext();
    var elt = it.Current;
    Console.WriteLine(elt);
    }


    }


    Console.WriteLine("]");
}

void PlayWithLists()
{
    // NB: string C# type vs String .NET type
    IList<string> cities = new List<string>();
    cities.Add("Toulouse");
    cities.Add("Paris");
    cities.Add("Pau");

    // a list is IEnumerable
    foreach (string city in cities)
    {
        Console.WriteLine(city);
    }

    DisplayList(cities);
    DisplayCollection(cities);

    //Random Accces
    Console.WriteLine(cities[1]);

    // Contains (ICollection) car tout est IEnumerable
    Console.WriteLine(cities.Contains("Toulouse"));
    Console.WriteLine(cities.Contains("Lyon"));

    Int32 index = cities.IndexOf("Pau"); // Index ou -1 si non présent
    Console.WriteLine(index);
    index = cities.IndexOf("Lyon"); // Index ou -1 si non présent
    Console.WriteLine(index);
}

void PlayWithLists2()
{
    Double[] temperaturesArray = { 11.6, 12.5, 13.1, 14.89, 15.86, -5.4, 16.4, 17.8 };

    // constructor from IEnumerable
    IList<Double> temperatures = new List<Double>(temperaturesArray);
    DisplayCollection(temperatures);
    DisplayCollection(temperaturesArray);

    Int32 capacity = 125_000_000;
    IList<Double> bigData = new List<Double>(capacity);
    Console.WriteLine($"Size big data : {bigData.Count}");

    // fill bigData with random numbers
    var rand = new Random();
    for (Int32 i = 0; i < capacity; i++)
    {
        bigData.Add(rand.NextDouble());
    }
    Console.WriteLine($"Size big data : {bigData.Count}");
    DisplayCollection(bigData);
    Console.WriteLine(bigData[0]);
    Console.WriteLine(bigData[^1]);
}

void PlayWithLists3()
{
    IList<string> cities = new List<string>() { "Pau", "Paris", "Toulouse" };
    IList<string> cities2 = ["Pau", "Paris", "Toulouse"]; // depuis C#12
    Console.WriteLine(cities.GetType());
    Console.WriteLine(cities2.GetType());
}


PlayWithLists();
Console.WriteLine("-------");
PlayWithLists2();
Console.WriteLine("-------");
PlayWithLists3();
Console.WriteLine("-------");