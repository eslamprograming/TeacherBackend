using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models.User
{
    public class Register
    {
        [Required(ErrorMessage ="Enter First Name")]
        [StringLength(20)]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Enter Last Name")]
        [StringLength(20)]

        public string LastName { get; set; }
        [Required(ErrorMessage = "Enter User Name")]

        public string UserName { get; set; }
        [Required(ErrorMessage = "Phone")]

        public string Phone { get; set; }

        [Required(ErrorMessage = "Enter Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Enter Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        public int SubjectId { get; set; }
    }
}
