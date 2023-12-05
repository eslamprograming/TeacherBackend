using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Degree
    {
        [Key]
        public int Id { get; set; }
        public int? degree { get; set; }

        public int? TestId { get; set; }
        public int? SubjectId { get; set; }
        public int? StudentId { get; set; }

        [ForeignKey("TestId")]
        public Test? Test { get; set; }
        [ForeignKey("SubjectId")]

        public Subject? Subject { get; set; }
        [ForeignKey("StudentId")]

        public Student? Student { get; set; }    
    }
}
