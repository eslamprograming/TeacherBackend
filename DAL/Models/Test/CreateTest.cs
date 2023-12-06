using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models.Test
{
    public class CreateTest
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int FullMark { get; set; }
        [Required]

        public int Count { get; set; }
        [Required]
        public IFormFile Poster { get; set; }
        [Required]
        public int SubjectId { get; set; }

    }
}
