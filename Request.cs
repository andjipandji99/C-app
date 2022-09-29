using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    [Serializable]
    public class Request
    {
        public Operation Operacija { get; set; }
        //object pokriva cak i listu
        public object RequestObject { get; set; }
     
    }
}
