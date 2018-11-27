using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SonMogendorff
{
    public class GameResultModel
    {
        public int id;
        public int userId;
        public DateTime gameTime;
        public TimeSpan gameSpan;
        public int steps;
    }
}
