using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    [Serializable]
    public class Korisnik
    {
        private int korisnikId;
        private string ime;
        private string prezime;
        private string korisnickoIme;
        private int sifra;
        private Mesto mestoId;
        private string adresa;
      

        public int KorisnikId { get => korisnikId; set => korisnikId = value; }
        public string Ime { get => ime; set => ime = value; }
        public string Prezime { get => prezime; set => prezime = value; }
        public string KorisnickoIme { get => korisnickoIme; set => korisnickoIme = value; }
        public int Sifra { get => sifra; set => sifra = value; }
       
        public string Adresa { get => adresa; set => adresa = value; }
       
        public Mesto MestoId { get => mestoId; set => mestoId = value; }

        
    }
}
