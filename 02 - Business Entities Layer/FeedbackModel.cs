using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SonMogendorff
{
    public class FeedbackModel
    {
        public int feedbackID;
        public int userID;
        public DateTime dateHour;
        [Required]
        public string feedbackText;
    }
}
