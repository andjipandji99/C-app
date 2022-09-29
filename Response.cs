using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    [Serializable]
    public class Response
    {
        public string Poruka { get; set; }
        public bool Uspesno { get; set; } = true;
        public object Rezultat { get; set; }
    }
}
