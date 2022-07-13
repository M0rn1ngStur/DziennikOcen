using System;
using System.Collections.Generic;

namespace DziennikOcen.Model
{
    public partial class Attendance
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public DateTime Date { get; set; }
        public int ClassId { get; set; }
        public bool Attendance1 { get; set; }

        public virtual Class Class { get; set; } = null!;
    }
}
