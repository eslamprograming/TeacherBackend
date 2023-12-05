using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models.SubjectModel
{
    public class CreateSubject
    {
        [Required(ErrorMessage ="Enter Your Subject Name")]
        public string Name { get; set; }
        [Required]
        public IFormFile Poster { get; set; }
        [Required]
        public IFormFile Book { get; set; }
    }
}
