﻿using MovieMain.Models;
using System;

void PlayWithMovies()
{

// a class type is a reference type
Movie mNull = null;
Movie movieEmplty = new();
Console.WriteLine(movieEmplty);

Movie movie = new Movie()
{
    Id = 1,
    Title = "Oppenheimer"
};
Console.WriteLine(movie);
Movie movie2 = new Movie("Barbie", 2023);
Movie movie3 = new Movie(3, "Rebel Moon", 2023, 120);

Person person1 = new();
Person person2 = new(2, "Zack Snyder", new DateOnly(1966, 3, 1));
Person person3 = new()
{
    Name = "Sofia Boutella",
    BirthDate = new DateOnly(1982, 4, 3),
};

IEnumerable<Movie> movies = [movieEmplty, movie, movie2, movie3];
IEnumerable<Person> persons = [person1, person2, person3];

foreach (var m in movies)
{
    Console.WriteLine(m);
}

IEnumerable<Object> basket = [movie2, person3, "Toulouse"];
foreach (var o in basket)
{
    Console.WriteLine(String.Format("ToString: {0}; getType: {1}; hashCode: {2}",
        o.ToString(),
        o.GetType(),
        o.GetHashCode())
        );
}

ISet<Movie> movieSet = new HashSet<Movie>() { movie, movie2, movie3 };
Console.WriteLine(movieSet.Contains(movie));

var movieSearch = new Movie()
{
    Id = 1,
    Title = "Oppenheimer"
};

Console.WriteLine(movieSet.Contains(movieSearch));

Console.WriteLine(movieSet.Any(m => m.Id == 1));
Console.WriteLine(movieSet.Any(m => m.Title == "Barbie" && (m.Year == 2023)));

ISet<Movie> movieSortedSet = new SortedSet<Movie>(
    Comparer<Movie>.Create((m1, m2) => m1.Title.CompareTo(m2.Title))
    )
{ movie, movie2, movie3 };

foreach (var m in movieSortedSet)
{
    Console.WriteLine($"\t#{m}");
}

ISet<Movie> movieSortedSet2 = new SortedSet<Movie>(){ movie, movie2, movie3 };

foreach (var m in movieSortedSet2)
{
    Console.WriteLine($"\t~{m}");
}

var res1 = movies.Where(m => m.Equals(movieSearch)).ToList();
var res2 = movies.Where(m => m == movieSearch).ToList();
var res3 = movies.Where(m => m == movie).ToList();

Console.WriteLine($" {res1.Count} vs {res2.Count} vs {res3.Count}") ;
}

// lister les fichers créer pendant la formation
void ExploreDirectory(string directory)
{
    Console.WriteLine(Directory.Exists(directory));

    Console.WriteLine("--File exist");
    Console.WriteLine(File.Exists(@"C:\Projects\Aelion\MovieApp\MovieApp\Models\Person.cs"));

    var dirs = Directory.EnumerateFiles(directory, "*.cs", SearchOption.AllDirectories);

    foreach (var dir in dirs)
    {
    Console.WriteLine(dir);
        var fileInfo = new FileInfo(dir);
        Console.WriteLine($"{fileInfo.Name}: {fileInfo.LastWriteTime}, {fileInfo.Length}");
    }
}

void SaveMovies(string file, IEnumerable<Movie> movies)
{
    //File.WriteAllText(file, String.Join('\n', movies.Select(m => m.ToString())));
    File.WriteAllText(file, String.Join(Environment.NewLine, movies.Select(m => m.ToString())));
}

//PlayWithMovies();
ExploreDirectory(@"C:\Projects\Aelion");

IList<Movie> movies = [
    new Movie("Oppenheimer", 2023),
    new Movie("Dune part 2", 2024),
    new Movie("Donjon et dragon", 2023),
    new Movie("La passion de Dodin Bouffan", 2023),
];

SaveMovies(@"C:\Temp\movies.txt", movies);

IList<Movie> LoadMovies(string file)
{
    var movieList = new List<Movie>();
    var stream = File.OpenText(file);


    string line;
    while ((line = stream.ReadLine()) != null)
    {
        var movie = new Movie(line, 2023);  // TODO: parse Movie object
        movieList.Add(movie);
    };
    return movieList;
}
