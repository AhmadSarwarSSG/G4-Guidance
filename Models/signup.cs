using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace G4_Guidance.Models
{
    public class signup
    {
        [Required(ErrorMessage = "Please enter your username")]
        [StringLength(50)]
        public string username { get; set; }
        [Required(ErrorMessage = "Please enter your email")]
        public string email { get; set; }
        [Required(ErrorMessage = "Please enter your password")]
        public string password { get; set; }
    }
}
