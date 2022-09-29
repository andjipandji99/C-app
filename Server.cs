using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Server
{
    public class Server
    {
        //osluskujuci soket

        private Socket soket;
        private List<ClientHandler> klijenti = new List<ClientHandler>();

        public Server()
        {
            soket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        public bool Start()
        {
            try
            {

                IPEndPoint endpoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9999);
                soket.Bind(endpoint); //mozemo da pokrenemo server samo 1 jer on zauzme ip adresu na datom serveru
                soket.Listen(5);
                return true;
            }
            catch (Exception ex)
            {

                Debug.WriteLine(">>>>" + ex.Message); //zasto je doslo do greske
                return false;
            }

        }

        public void Listen()
        {
            try
            {
                while (true)
                {
                    //kreira nove sokete za klijente i obradjuje zahteve

                    Socket klijentskiSocket = soket.Accept();

                    //obrada klijentskih zahteva

                    ClientHandler klijent = new ClientHandler(klijentskiSocket);

                    klijenti.Add(klijent);
                    klijent.OdjavljeniKlijent += Handler_OdjavljenKlijent;
                    Thread nitKlijenta = new Thread(klijent.HandleRequests);
                    nitKlijenta.IsBackground = false;
                    nitKlijenta.Start();
                    

                }

            }
            catch (SocketException ex)
            {
                Debug.WriteLine(">>>>" + ex.Message);
                
            }



        }

        public void Handler_OdjavljenKlijent(object sender,EventArgs args)
        {
            klijenti.Remove((ClientHandler)sender);
        }

         public void Stop()
        {

            soket.Close(); // ovim zatvaramo SAMO osluskujuci soket !!!, ostali su i dalje aktivni

            foreach(ClientHandler k in klijenti.ToList())
            {
                k.ZatvoriSoket();
            }

            //klijenti.Clear();

        }
    }
}