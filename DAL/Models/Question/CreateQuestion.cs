using DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models.Question
{
    public class CreateQuestion
    {
        [Required]
        public string Quction { get; set; }
        [Required]
        public string Ansure { get; set; }
        [Required]
        public List<string> Choices { get; set; }
        [Required]
        public int CheapterId { get; set; }
    }
}
