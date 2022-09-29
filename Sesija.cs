using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KorisnickiInterfejs
{
 public  class Sesija
    {
        private static Sesija instanca;
        private static object lockObject = new object();
        private Sesija() { }
        public static Sesija Instanca
        {
            get
            {
                if (instanca == null)
                {
                    lock (lockObject)
                    {
                        if (instanca == null)
                            instanca = new Sesija();
                    }
                }
                return instanca;
            }
        }
       public Korisnik Korisnik { get; set; }
    }
}

