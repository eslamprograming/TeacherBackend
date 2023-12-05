using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class QuctionTest
    {
        [Key]
        public int Id { get; set; }
        public string? Quction { get; set; }   
        public string? Ansure { get; set; }
        public ICollection<TestQuestionChoice>? Choices { get; set; }
        public int? TestId { get; set; }
        [ForeignKey("TestId")]
        public Test? Test { get; set; }
    }
}
