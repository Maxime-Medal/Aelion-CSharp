using System.Collections.Generic;
using System.Runtime.InteropServices;

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

void PlayWithSortedSet()
{
    IList<string> cityList = ["Pau", "Paris", "Toulouse", "Bordeaux", "Olorons", "Marseille", "Lyon", "Orléans", "Clermont-Ferrand"];
    ISet<string> citySet = new SortedSet<string>(cityList); // Attention! si même longueur, l'élément disparait
    DisplayCollection(cityList);
    DisplayCollection(citySet);

    IComparer<string> comparer = new StringLengthComparer(); // old methode
    ISet<string> citySet2 = new SortedSet<string>(citySet, comparer);
    Console.WriteLine(" ");
    DisplayCollection(citySet2);

    // easier comparer method
    IComparer<string> comparerLengthDesc = Comparer<string>.Create(
        (s1, s2) => s2.Length - s1.Length
        );
    ISet<string> citySet3 = new SortedSet<string>(citySet, comparerLengthDesc);


    // TODO update comparer
    IComparer<string> comparerLengthDesc2 = Comparer<string>.Create(
        (s1, s2) =>
        {
            return s2.Length - s1.Length;
        }
            );
    ISet<string> citySet4 = new SortedSet<string>(citySet, comparerLengthDesc2);

}


void PlayWithDictionary()
{
    IDictionary<string, UInt32> cityPopulation = new Dictionary<string, UInt32>()
    {
        {"Pau", 77_000},
        {"Toulouse", 470_000},
        {"Paris", 2_161_000 }
    };
    cityPopulation.Add("Orléans", 114_000);
    DisplayCollection(cityPopulation);
    cityPopulation["Orléans"] = 114_611;
    DisplayCollection(cityPopulation);
    cityPopulation["Marseille"] = 860_000; // Si en place écrase sinon l'ajoute
    DisplayCollection(cityPopulation);

    Console.WriteLine(cityPopulation["Marseille"]); // en JS cityPopulation.Marseille

    IList<string> cities = ["Marseille", "Bordeaux"];

    // try methods : TryGetValue, ContainsKey
    foreach (string city in cities)
    {
        Console.WriteLine("***** 1st");
        cityPopulation.TryGetValue(city, out UInt32 population);
        if (population > 0)
        {
            Console.WriteLine($"Population of {city} is {population} people");
        }
        else
        {
            Console.WriteLine($"Population of {city} is unknown");
        }

        Console.WriteLine("***** 2nde");
        if (cityPopulation.TryGetValue(city, out UInt32 pop))
        {
            Console.WriteLine($"Population of {city} is {pop} people");
        }
        else
        {
            Console.WriteLine($"Population of {city} is unknown");
        }
    }

    // Iterate over Dictionary
    foreach (KeyValuePair<string, UInt32> cityPop in cityPopulation)
    {
        Console.WriteLine($"{cityPop} : {cityPop.Key} => {cityPop.Value}");
    }

    Console.WriteLine("**********");
    // iterate using deconstructor of type KeyValuePair
    foreach ((var city, var pop) in cityPopulation)
    {
        Console.WriteLine($"{city} => {pop}");
    }

    // use just key
    foreach (string city in cityPopulation.Keys)
    {
        Console.WriteLine(city);
    }

    foreach (UInt32 pop in cityPopulation.Values)
    {
        Console.WriteLine(pop);
    }

    foreach (var pop in cityPopulation)
    {
        Console.WriteLine(pop);
    }
}

(string, int) GenerateCity()
{
    return ("Toulouse", 477_000);
}

// tuple nommé
(string City, int Population) GenerateCityN()
{
    //return ("Toulouse", 477_000); // still OK
    return (City: "Toulouse", Population: 477_000);
}

void PlayWithTuple()
{
    // tuple (struct): (string, int) or ValueTuple<string, int>
    var cityPop = ("Pau", 77_000);
    Console.WriteLine(cityPop.Item1);
    Console.WriteLine(cityPop.Item2);

    // tuple (class) : Tuple<string, int>
    var citypop2 = cityPop.ToTuple();
    Console.WriteLine(citypop2);

    var cityPop3 = GenerateCity();
    Console.WriteLine(cityPop3);

    var (city, pop) = GenerateCity();
    Console.WriteLine($"{city} has population {pop}");

    var cityPop4 = GenerateCityN();
    Console.WriteLine($"{cityPop4.City} has population {cityPop4.Population}");

    Console.WriteLine(cityPop4 == ("Toulouse", 477_000));
    Console.WriteLine(cityPop4 == (City: "Toulouse", Population: 477_000));
}

//PlayWithLists();
//Console.WriteLine("-------");
//PlayWithLists2();
//Console.WriteLine("-------");
//PlayWithLists3();
//Console.WriteLine("-------");
//PlayWithSortedSet();
//PlayWithDictionary();
PlayWithTuple();