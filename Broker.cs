using Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseBroker
{
    public class Broker
    {

        private SqlConnection konekcija;
        private SqlTransaction transkacija;

        public Broker()
        {
            konekcija = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MojaBaza;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Encrypt=False;TrustServerCertificate=False");

        }

        public void OpenConnection()
        {
            konekcija.Open();
           

           

        }

        public void CloseConnection()
        {
            if (konekcija!=null && konekcija.State != ConnectionState.Closed)
            {
                konekcija.Close();
            }


        }

        public SqlCommand CreateCommand()
        {
            return new SqlCommand("", konekcija, transkacija);
        }


        public int SacuvajNarudzbenicu(Narudzbenica obj)
        {
            SqlCommand komanda = new SqlCommand("",konekcija,transkacija);

            komanda.CommandText = "Insert into Narudzbenica output inserted.ID values(@KorisnikId,@Kolicina)";

            komanda.Parameters.AddWithValue("@KorisnikId", obj.KorisnikId.KorisnikId);
            komanda.Parameters.AddWithValue("@Kolicina", obj.Kolicina);

            SqlDataReader reader = komanda.ExecuteReader();
            reader.Read();
            return reader.GetInt32(0);


        }

      
        public void SacuvajStavkuNarudzbenice(StavkaNarudzbenice s)
        {
            SqlCommand komanda = new SqlCommand("", konekcija, transkacija);

            komanda.CommandText = "Insert into StavkaNarudzbenice values(@NarudzbenicaId,@ProizvodId,@BrojKomada)";

            komanda.Parameters.AddWithValue("@NarudzbenicaId", s.NarudzbenicaId);
            komanda.Parameters.AddWithValue("@ProizvodId", s.ProizvodId);
            komanda.Parameters.AddWithValue("@KBrojKomada", s.BrojKomada);

            komanda.ExecuteNonQuery();
        }

        public void BeginTransaction()
        {
            transkacija = konekcija.BeginTransaction();
        }

        public void Commit()
        {
            transkacija.Commit();
        }

        public void Rollback()
        {
            transkacija.Rollback();
        }

        public void Dodaj(DomenskiObjekat obj)
        {
            SqlCommand komanda = new SqlCommand();

            komanda.Connection = konekcija;
            komanda.Transaction = transkacija;
            komanda.CommandText = $"Insert into {obj.NazivTabele} values({obj.Vrednosti}) ";


            //ovoj metodi mozemo proslediti sve objekte cije klase implementiraju DomenskiObjekat interfejs
            komanda.ExecuteNonQuery();


        }

        public List<DomenskiObjekat> Vrati(DomenskiObjekat obj)
        {
            List<DomenskiObjekat> rezultat = new List<DomenskiObjekat>();

            SqlCommand komanda = new SqlCommand("", konekcija);
            komanda.CommandText =$"SELECT * FROM {obj.NazivTabele}";

            using (SqlDataReader citac = komanda.ExecuteReader())
            {
                while (citac.Read())
                {
                    DomenskiObjekat rowObject = obj.ReadObjectRow(citac);

                
                    rezultat.Add(rowObject);

                }
            }

            return rezultat;
        }

        public void DodajProizvod(Proizvod proizvod)
        {
            SqlCommand komanda = new SqlCommand("", konekcija,transkacija);

            komanda.CommandText = "Insert into Proizvod values (@id,@naziv,@pol,@boja,@materijal,@duzina,@proizvodjac,@cena,@velicina,@kolicina) ";

            
            komanda.Parameters.AddWithValue("@id", proizvod.ProizvodId);
            komanda.Parameters.AddWithValue("@naziv", proizvod.Naziv);
            komanda.Parameters.AddWithValue("@pol", proizvod.Pol);
            komanda.Parameters.AddWithValue("@boja", proizvod.Boja);
            komanda.Parameters.AddWithValue("@materijal",proizvod.Materijal);
            komanda.Parameters.AddWithValue("@duzina", proizvod.Duzina);
            komanda.Parameters.AddWithValue("@proizvodjac", proizvod.Proizvodjac);
            komanda.Parameters.AddWithValue("@cena", proizvod.Cena);
            komanda.Parameters.AddWithValue("@velicina", proizvod.Velicina);
            komanda.Parameters.AddWithValue("@kolicina", proizvod.Kolicina);

            komanda.ExecuteNonQuery();
        }



        public int IdProizvod()
        {
            SqlCommand komanda = new SqlCommand();
            komanda.Connection = konekcija;
            komanda.Transaction = transkacija;
            komanda.CommandText = $"Select max(id) from Proizvod";

            object result = komanda.ExecuteScalar();
            if(result is DBNull)
            {
                return 1;
            }
            else
            {
                int najveciId = (int)result;
                int noviId = najveciId + 1;
                return noviId;
            }
           

        }

     
     
        public void DodajKorisnika(Korisnik korisnik)
        {
            SqlCommand komanda = new SqlCommand();

            komanda.Connection = konekcija;
            komanda.Transaction = transkacija;
            komanda.CommandText = "Insert into Korisnik values (@ime,@prezime,@korisnickoIme,@sifra,@adresa,@mestoId) ";

           //id nemamo jer smo u bazi podesili na identity specification,odnosno da se automatski azurira
            komanda.Parameters.AddWithValue("@ime", korisnik.Ime);
            komanda.Parameters.AddWithValue("@prezime", korisnik.Prezime);
            komanda.Parameters.AddWithValue("@korisnickoIme", korisnik.KorisnickoIme);
            komanda.Parameters.AddWithValue("@sifra", korisnik.Sifra);
            komanda.Parameters.AddWithValue("@adresa", korisnik.Adresa);
            komanda.Parameters.AddWithValue("@mestoId", korisnik.MestoId);

            komanda.ExecuteNonQuery();


        }

        public int vratiIdNarudzbenice()
        {
            SqlCommand komanda = new SqlCommand();
            komanda.Connection = konekcija;
            komanda.CommandText = $"Select max(id) from Narudzbenica";

            object result = komanda.ExecuteScalar();
            if (result is DBNull)
            {
                return 1;
            }
            else
            {
                int najveciId = (int)result;
                int noviId = najveciId + 1;
                return noviId;
            }
            //kada id nije autoincrement
        }

        public int vratiIdKorisnika()
        {
            SqlCommand komanda = new SqlCommand();
            komanda.Connection = konekcija;
            komanda.CommandText = $"Select max(id) from Proizvod";

            int maxId = (int)komanda.ExecuteScalar();
            return maxId;

            //ne proveravamo da li je DBNull jer smo u bazi podesili da se automatski podesava


        }

        public List<Proizvod> VratiSveProizvode()
        {
            List<Proizvod> proizvodi = new List<Proizvod>();

            SqlCommand komanda = new SqlCommand("", konekcija);
            komanda.CommandText = "SELECT * from Proizvod";

            using(SqlDataReader citac = komanda.ExecuteReader())
            {
                while (citac.Read())
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



                    

                    proizvodi.Add(p);

                }
            }

            return proizvodi;
        }

       

    }
}
