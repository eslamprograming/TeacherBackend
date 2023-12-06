using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models.Video
{
    public class CreateVideo
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public IFormFile video { get; set; }
        [Required]
        public int CheapterId { get; set; }
    }
}
