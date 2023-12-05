using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Cheapter
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }    
        public string? Poster { get; set; }  
        public string? Note { get; set; }    
        public int? SubjectId { get; set; }
        [ForeignKey("SubjectId")]
        public Subject? Subject { get; set; }
        public ICollection<Video>? Videos { get; set; }  
        public ICollection<Question>? Question { get; set; } 
    }
}
