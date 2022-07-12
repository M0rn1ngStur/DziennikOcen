using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DziennikOcen.Model
{
    public partial class Class
    {
        public Class()
        {
            Attendances = new HashSet<Attendance>();
            Grades = new HashSet<Grade>();
        }

        [Key]
        public int Id { get; set; }
        [Column("className")]
        [StringLength(50)]
        [Unicode(false)]
        public string ClassName { get; set; } = null!;

        [InverseProperty("Class")]
        public virtual ICollection<Attendance> Attendances { get; set; }
        [InverseProperty("Class")]
        public virtual ICollection<Grade> Grades { get; set; }
    }
}
