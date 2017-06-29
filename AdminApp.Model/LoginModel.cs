using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AdminApp.Model
{
    public class LoginModel
    {
        public int Userid { get; set; }
        public int UserTypeId { get; set; } 

        [Required(ErrorMessage = "Username required", AllowEmptyStrings = false)]
        public string Username { get; set; }
        [Required(ErrorMessage = "Password Required", AllowEmptyStrings = false)]
        [DataType(System.ComponentModel.DataAnnotations.DataType.Password)]
        public string Password { get; set; }
    }
}
