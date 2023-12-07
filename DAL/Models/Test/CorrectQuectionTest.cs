using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models.Test
{
    public class CorrectQuectionTest
    {
        [Required]
        public string Quction { get; set; }
        [Required]
        public string Ansure { get; set; }
    }
}
