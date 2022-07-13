using System;
using System.Collections.Generic;

namespace DziennikOcen.Model
{
    public partial class Grade
    {
        public int Id { get; set; }
        public int Grade1 { get; set; }
        public int ClassId { get; set; }
        public int StudentId { get; set; }

        public virtual Class Class { get; set; } = null!;
        public virtual Student Student { get; set; } = null!;
    }
}
