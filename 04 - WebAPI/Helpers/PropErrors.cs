using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SonMogendorff
{
    public class PropErrors
    {
        public string property { get; set; }

        public List<string> errors { get; set; } = new List<string>();
    }
}