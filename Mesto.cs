using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    [Serializable]
    public class Mesto
    {
        private int mestoId;
        private string naziv;
        private int postanskiBroj;

        public int MestoId { get => mestoId; set => mestoId = value; }
        public string Naziv { get => naziv; set => naziv = value; }
        public int PostanskiBroj { get => postanskiBroj; set => postanskiBroj = value; }
    }
}
