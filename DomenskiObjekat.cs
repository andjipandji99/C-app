using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
   public interface DomenskiObjekat
    {
        string NazivTabele  { get; }
        string Vrednosti { get;  }

        DomenskiObjekat ReadObjectRow(SqlDataReader reader);
    }
}
