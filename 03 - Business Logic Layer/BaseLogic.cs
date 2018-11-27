using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SonMogendorff
{
    public class BaseLogic: IDisposable
    {
        protected MemoryGameEntities DB = new MemoryGameEntities();
        
         public void Dispose()
        {
            DB.Dispose();
        }
    }
}
