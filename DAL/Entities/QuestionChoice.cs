using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class QuestionChoice
    {
        [Key]
        public int Id { get; set; }
        public string? choice { get; set; }
        public int? QuestionId { get; set; }
        [ForeignKey("QuestionId")]
        [JsonIgnore]
        public Question? question { get; set; }
    }
}
