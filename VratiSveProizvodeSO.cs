using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemskeOperacije
{
    public class VratiSveProizvodeSO : OpstaSO
    {
        public List<Proizvod> Result { get; private set; } 
        protected override void Execute()
        {
            Result= repository.VratiSve(new Proizvod()).OfType<Proizvod>().ToList();

        }
    }
}
