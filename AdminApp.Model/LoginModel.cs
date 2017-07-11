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
        public int userId { get; set; }
        public int userTypeId { get; set; } 

        [Required(ErrorMessage = "Username required", AllowEmptyStrings = false)]
        public string userName { get; set; }
        [Required(ErrorMessage = "Password Required", AllowEmptyStrings = false)]
        [DataType(System.ComponentModel.DataAnnotations.DataType.Password)]
        public string password { get; set; }
    }
}
