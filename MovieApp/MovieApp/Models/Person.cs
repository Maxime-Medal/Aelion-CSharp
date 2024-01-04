using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieMain.Models
{
    public class Person(int? id, string name, DateOnly? birthDate) // new syntax C# 12
    {
        public Person() : this(null, "John Doe", null) 
        { }
        public int? Id { get; set; } = id;
        public string Name { get; set; } = name;
        public DateOnly? BirthDate { get; set; } = birthDate; // just AAAA MM DD

        #region public method
        public override string ToString() => $"Name = {Name} ({BirthDate})";
        #endregion


    }

}
