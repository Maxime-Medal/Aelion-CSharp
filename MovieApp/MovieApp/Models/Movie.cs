using System.Xml.Linq;

namespace MovieMain.Models
{
    public class Movie : IComparable<Movie>, IEquatable<Movie>
    {
        public Movie() : this(null, "?", 0, null)
        { }
        public Movie(string title, int year) : this(null, title, year, null)
        { }

        public Movie(int? id, string title, int year, int? duration)
        {
            Id = id;
            Title = title;
            Year = year;
            Duration = duration;
        }


        // property with auto : private attribute + getter, setter methods
        public int? Id { get; set; }
        public string Title { get; set; } // metttre ? à la place de string.empty
        public int Year { get; set; }
        public int? Duration { get; set; }

        public int CompareTo(Movie? other)
        {
            if(other == null) return 1;
            return (Year, Title).CompareTo((other.Year, other.Title));
        }

        /// <summary>
        /// implement IEquatable<Movie>.Equals
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(Movie? other) // avoir les même critère entre CompaeTo et Equals
        {
            if (other == null) return false;
            return (Year, Title).Equals((other.Year, other.Title));
        }

        /// <summary>
        /// Override Object.Equals
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public override bool Equals(Object? other)
        {
            if (!(other is Movie)) return false;
            return Equals((Movie)other);
        }

        /// Override Object.GetHashCode
        public override int GetHashCode()
        {
            return (Title, Year).GetHashCode();
        }
        #region public method
        public override string ToString() =>  $"{Title} ({Year}) #{(Id == null ? Id : '?'.ToString())}";
        #endregion

    }
}
