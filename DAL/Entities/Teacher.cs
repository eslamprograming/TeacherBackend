using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Teacher
    {
        [Key]
        public int Id { get; set; }
        public string? Photo { get; set; }
        public int? GreaduateOfYear { get; set; }
        public ICollection<Subject>? Subjects { get; set; }
        public string? ApplicationUserId { get; set; }
        [ForeignKey("ApplicationUserId")]
        public ApplicationUser? User { get; set; }

    }
}
