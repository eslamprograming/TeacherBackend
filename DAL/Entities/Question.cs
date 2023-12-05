using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Question
    {
        [Key]
        public int Id { get; set; }
        public string? Quction { get; set; }
        public string? Ansure { get; set; }
        public ICollection<QuestionChoice>? Choices { get; set; }
        public int? CheapterId { get; set; }
        [ForeignKey("CheapterId")]
        public Cheapter? Cheapter { get; set; }
    }
}
