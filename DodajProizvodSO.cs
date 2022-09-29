using Domain;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemskeOperacije
{
   public class DodajProizvodSO : OpstaSO
    {
        private readonly Proizvod p;
        public DodajProizvodSO(Proizvod p)
        {
            this.p = p;
        }
        protected override void Execute()
        {
           
           
                //p.ProizvodId = repository.IdProizvod();
            repository.Sacuvaj(p);
            
        }
    }
}
