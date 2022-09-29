using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
   public class CommunicationHelper
    {

        private Socket soket;
        private NetworkStream tok;
        private BinaryFormatter formater;

        public CommunicationHelper(Socket soket)
        {
            this.soket = soket;
            tok = new NetworkStream(soket);
            formater = new BinaryFormatter();
        }

        public void Send<T>(T obj) where T:class
        {
            //obradjujemo gresku koja moze da se desi u koliko se server ugasi prilikom, treba da se izvrsi serijalizacija
            
                formater.Serialize(tok, obj);
            
      
        }

        public T Receive<T>() where T : class
        {
            return (T)formater.Deserialize(tok);
        }
    }
}
