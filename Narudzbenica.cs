using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    [Serializable]
    public class Narudzbenica
    {
        public Narudzbenica()
        {
            listaStavki = new List<StavkaNarudzbenice>();
        }

        private int narudzbenicaId;
        private int kolicina;
        private Korisnik korisnikId;
        private List<StavkaNarudzbenice> listaStavki;

        public int NarudzbenicaId { get => narudzbenicaId; set => narudzbenicaId = value; }
        public int Kolicina { get => kolicina; set => kolicina = value; }
        public Korisnik KorisnikId { get => korisnikId; set => korisnikId = value; }
        public List<StavkaNarudzbenice> ListaStavki { get => listaStavki; set => listaStavki = value; }
    }
}
