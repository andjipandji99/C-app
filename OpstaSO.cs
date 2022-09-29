using DatabaseBroker;
using Domain;
using Respository.DatabaseRespository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

 namespace SistemskeOperacije
{
    public abstract class OpstaSO
    {
        protected IRepository<DomenskiObjekat> repository = new GenerickiDBRepository();
        public void ExecuteTemplate()
        {
            //template metod patern
            try
            {

                repository.OpenConnection();
                repository.BeginTransaction();

                Execute();

                repository.Commit();
                //cuvamo ili sve proizvode ili nijedan
                //transkacije

            }
            catch (Exception ex)
            {
                repository.Rollback();
                throw;
            }
            finally
            {
                repository.CloseConnection();
            }

        }

        protected abstract void Execute();
    }
}
