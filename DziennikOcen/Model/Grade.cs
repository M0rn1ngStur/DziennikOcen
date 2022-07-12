using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DziennikOcen.Model
{
    public partial class Grade
    {
        [Key]
        public int Id { get; set; }
        [Column("grade")]
        public int Grade1 { get; set; }
        [Column("classId")]
        public int ClassId { get; set; }
        [Column("studentId")]
        public int StudentId { get; set; }

        [ForeignKey("ClassId")]
        [InverseProperty("Grades")]
        public virtual Class Class { get; set; } = null!;
        [ForeignKey("StudentId")]
        [InverseProperty("Grades")]
        public virtual Student Student { get; set; } = null!;
    }
}
