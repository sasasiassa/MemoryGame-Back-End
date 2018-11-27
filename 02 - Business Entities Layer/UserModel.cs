using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SonMogendorff
{
    public class UserModel
    {
        public int? userId;

        [Required(ErrorMessage = "Missing name")]
        [RegularExpression("^([A-Z]|[a-z])+$", ErrorMessage = "Name must contain letters only and full name.")] // Validation...
        public string fullName;

        [Required(ErrorMessage = "Missing username")]
        [MinLength(4, ErrorMessage = "Minimum length is 4 characters")]
        [MaxLength(15, ErrorMessage = "Maximum length is 15 characters")]
        [RegularExpression("^([0-9]|[a-z]|[A-Z])+$", ErrorMessage = "Must only contain letters and numbers.")] // Validation..
        public string userName;

        [Required(ErrorMessage = "Missing Password")]
        [MinLength(8, ErrorMessage = "Minimum length is 8 characters")]
        [MaxLength(20, ErrorMessage = "Maximum length is 20 characters")]
        [RegularExpression("^([0-9]|[a-z]|[A-Z])+$", ErrorMessage = "Must only contain letters and numbers.")] // Validation...
        public string password;

        public string email;

        public DateTime? bDay;
    }
}
