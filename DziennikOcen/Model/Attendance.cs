using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DziennikOcen.Model
{
    [Table("Attendance")]
    public partial class Attendance
    {
        [Key]
        public int Id { get; set; }
        [Column("studentId")]
        public int StudentId { get; set; }
        [Column("date", TypeName = "datetime")]
        public DateTime Date { get; set; }
        [Column("classId")]
        public int ClassId { get; set; }
        [Column("attendance")]
        public bool Attendance1 { get; set; }

        [ForeignKey("ClassId")]
        [InverseProperty("Attendances")]
        public virtual Class Class { get; set; } = null!;
    }
}
