using DatabaseBroker;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Respository
{
  public  class ProizvodRespository
    {
        private List<Proizvod> proizvodi = new List<Proizvod>();

        private Broker broker = new Broker();

        public void Add(Proizvod proizvod)
        {
            proizvodi.Add(proizvod);
        }

        public List<Proizvod> VratiSveProizvode(){

            try
            {
                broker.OpenConnection();
                return broker.VratiSveProizvode();
            }
            finally
            {
                broker.CloseConnection();
            }
        }

        public void DodajSveProizvode(List<Proizvod> proizvods)
        {
            try
            {
                broker.OpenConnection();
                broker.BeginTransaction();

                foreach(Proizvod p in proizvods)
                {
                    p.ProizvodId = broker.IdProizvod();
                    broker.DodajProizvod(p);
                }

                broker.Commit();
                //cuvamo ili sve proizvode ili nijedan
                //transkacije

            }
            catch(Exception ex)
            {
                broker.Rollback();
                throw; 
            }
            finally
            {
                broker.CloseConnection();
            }

        }
    }
}
