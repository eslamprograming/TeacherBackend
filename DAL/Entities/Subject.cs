using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Subject
    {
        [Key]
        public int Id { get; set; } 
        public string? Name { get; set; }    
        public string? Poster { get; set; }
        public string? Book { get; set; }
        public int? TeacherID { get; set; }
        [ForeignKey("TeacherID")]
        public Teacher? Teacher { get; set; }
        public ICollection<Student>? Students { get; set; }
        public ICollection<Cheapter>? Cheapters { get; set; }
        public ICollection<Test> Tests { get; set; }
        public ICollection<Degree>? Degrees { get; set; }



    }
}
