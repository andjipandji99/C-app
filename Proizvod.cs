using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    [Serializable]
  public  class Proizvod :DomenskiObjekat
    {
        private int proizvodId;
        private string naziv;
        private string pol;
        private string boja;
        private string materijal;
        private string duzina;
        private int cena;
        private string proizvodjac;
        private int velicina;
        private int kolicina;

        public int ProizvodId { get => proizvodId; set => proizvodId = value; }
        public string Naziv { get => naziv; set => naziv = value; }
        public string Pol { get => pol; set => pol = value; }
        public string Boja { get => boja; set => boja = value; }
        public string Materijal { get => materijal; set => materijal = value; }
        public string Duzina { get => duzina; set => duzina = value; }
        public string Proizvodjac { get => proizvodjac; set => proizvodjac = value; }
        
        public int Velicina { get => velicina; set => velicina = value; }
        public int Kolicina { get => kolicina; set => kolicina = value; }
        public int Cena { get => cena; set => cena = value; }

        public string NazivTabele => "Proizvod";

        public string Vrednosti => $"'{naziv}','{pol}','{boja}','{materijal}','{duzina}','{proizvodjac}',{cena},{velicina},{kolicina}";

        public override string ToString()
        {
            return $"{Naziv}";
        }

        public string PrikaziCenu()
        {
            return $"{Cena}";
        }

        public DomenskiObjekat ReadObjectRow(SqlDataReader citac)
        {
            Proizvod p = new Proizvod();
            p.ProizvodId = citac.GetInt32(0);
            p.Naziv = citac.GetString(1);
            p.Pol = citac.GetString(2);
            p.Boja = citac.GetString(3);
            p.Materijal = citac.GetString(4);
            p.Duzina = citac.GetString(5);
            p.Proizvodjac = citac.GetString(6);
            p.Cena = (int)citac.GetDecimal(7);
            p.Velicina = citac.GetInt32(8);
            p.Kolicina = citac.GetInt32(9);

            return p;
        }
    }
}
