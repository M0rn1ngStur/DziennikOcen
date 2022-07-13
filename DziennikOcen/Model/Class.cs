using System;
using System.Collections.Generic;

namespace DziennikOcen.Model
{
    public partial class Class
    {
        public Class()
        {
            Attendances = new HashSet<Attendance>();
            Grades = new HashSet<Grade>();
        }

        public int Id { get; set; }
        public string ClassName { get; set; } = null!;

        public virtual ICollection<Attendance> Attendances { get; set; }
        public virtual ICollection<Grade> Grades { get; set; }
    }
}
