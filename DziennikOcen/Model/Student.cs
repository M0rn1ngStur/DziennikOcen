using System;
using System.Collections.Generic;

namespace DziennikOcen.Model
{
    public partial class Student
    {
        public Student()
        {
            Grades = new HashSet<Grade>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string GroupSymbol { get; set; } = null!;

        public virtual ICollection<Grade> Grades { get; set; }
    }
}
