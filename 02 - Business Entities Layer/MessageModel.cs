using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SonMogendorff
{
    public class MessageModel
    {
        public int msgID;
        public DateTime DateHour;
        public string phoneNumber;
        public string email;

        [Required(ErrorMessage = "Missing Message")]
        [MinLength(10, ErrorMessage = "Minimum length is 10 characters")] // Validation..
        public string msg;
    }
}
