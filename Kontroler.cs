using Domain;
using Respository;
using Respository.DatabaseRespository;
using SistemskeOperacije;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AplikacionaLogika
{
    public class Kontroler
    {
        //SINGLETON PATTERN
        #region singleton
        private static Kontroler instanca;

        public static Kontroler Instanca {
            get
            {
                if (instanca == null)
                {
                    instanca = new Kontroler();

                }
                return instanca;
            }
        }

        

        public List<String> VratiSveDuzine()
        {
            return null;
        }

        private Kontroler()
        {

        }
        #endregion 


        private UserRespository userRespository = new UserRespository();

        private ProizvodRespository proizvodRespository = new ProizvodRespository();

        private IRepository<Narudzbenica> InvoiceRepository = new InvoiceDatabaseRepository();
        public Korisnik TrenutniKorisnik { get; set; }//prijavljeni korisnik

        public List<Proizvod> VratiSveProizvode()
        {

            OpstaSO so = new VratiSveProizvodeSO();
            try
            {
                so.ExecuteTemplate();
            }
            catch (Exception ex)
            {
                throw;
            }
            return ((VratiSveProizvodeSO)so).Result;
        }
        public Korisnik Login(Korisnik k)
        {
            List<Korisnik> korisnici = userRespository.GetUsers();

            foreach(Korisnik korisnik in korisnici)
            {
                if(korisnik.KorisnickoIme==k.KorisnickoIme && korisnik.Sifra == k.Sifra)
                {
                    TrenutniKorisnik = korisnik;
                    return korisnik;
                }
            }
            return null;
        }

        

        public void DodajProizvod(Proizvod noviProizvod)
        {
            //proizvodRespository.Add(noviProizvod);

            OpstaSO so = new DodajProizvodSO(noviProizvod);
            so.ExecuteTemplate();

        }

        public void SacuvajNarudzbenicu(Narudzbenica n)
        {
            InvoiceRepository.Sacuvaj(n);
        }

        public void DodajSveProizvode(List<Proizvod> proizvods)
        {
            //respository
            proizvodRespository.DodajSveProizvode(proizvods);
        }
    }
}
