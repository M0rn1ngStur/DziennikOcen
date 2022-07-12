using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DziennikOcen.Model
{
    public partial class Student
    {
        public Student()
        {
            Grades = new HashSet<Grade>();
        }

        [Key]
        public int Id { get; set; }
        [Column("name")]
        [StringLength(50)]
        [Unicode(false)]
        public string Name { get; set; } = null!;
        [Column("groupSymbol")]
        [StringLength(3)]
        [Unicode(false)]
        public string GroupSymbol { get; set; } = null!;

        [InverseProperty("Student")]
        public virtual ICollection<Grade> Grades { get; set; }
    }
}
