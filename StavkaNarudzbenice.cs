using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    [Serializable]
   public class StavkaNarudzbenice
    {
        private int narudzbenicaId;
        private int stavkaId;
        private int brojKomada;
        private Proizvod proizvodId;

        public int StavkaId { get => stavkaId; set => stavkaId = value; }
        public int BrojKomada { get => brojKomada; set => brojKomada = value; }
        public Proizvod ProizvodId { get => proizvodId; set => proizvodId = value; }
        public int NarudzbenicaId { get => narudzbenicaId; set => narudzbenicaId = value; }
    }
}
