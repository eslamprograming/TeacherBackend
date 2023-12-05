using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Test
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public int? FullMark { get; set; }   
        public int? Count { get; set; }
        public string? Poster { get; set; }
        public ICollection<QuctionTest>? quctionTests { get; set; }
        public ICollection<Degree>? Degrees { get; set; }
        public int SubjectId { get; set; }
        [ForeignKey("SubjectId")]
        public Subject Subject { get; set; }


    }
}
