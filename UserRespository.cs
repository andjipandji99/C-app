using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Respository
{
    public class UserRespository
    {
        private List<Korisnik> korisnici = new List<Korisnik>();

        public UserRespository()
        {
            korisnici.Add(new Korisnik { KorisnikId = 1, Ime = "Pera", Prezime = "Peric", KorisnickoIme = "pera", Sifra = 1111, Adresa = "nesto"});
        }
        public List<Korisnik> GetUsers()
        {
            return korisnici;
        }




    }
}
