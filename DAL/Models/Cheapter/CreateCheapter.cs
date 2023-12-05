using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models.Cheapter
{
    public class CreateCheapter
    {
        [Required]
        public string Name { get; set; }
        public IFormFile Poster { get; set; }
        public IFormFile Note { get; set; }
        [Required]
        public int SubjectId { get; set; }
    }
}
