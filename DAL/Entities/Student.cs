using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        public int? SubjectID { get; set; }
        [ForeignKey("SubjectID")]
        public Subject? Subject { get; set; }    
        public ICollection<Degree>? Degrees { get; set; }
        public string? ApplicationUserId { get; set; }
        [ForeignKey("ApplicationUserId")]
        public ApplicationUser? User { get; set; }

    }
}
