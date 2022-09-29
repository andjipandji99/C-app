using AplikacionaLogika;
using Common;
using Domain;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class ClientHandler
    {
        private  Socket soket;

        private CommunicationHelper helper;

        public EventHandler OdjavljeniKlijent;

        private bool kraj;

        //sluzi za obradjivanje zahteva klijenta, 1 klijentski soket
        public ClientHandler(Socket soket)
        {
            this.soket = soket;
            helper = new CommunicationHelper(soket);
        }

       
        public void HandleRequests()
        { //samo logika obradjivanja zahteva
           
            try
            {
                Request zahtev;
                while ((zahtev = helper.Receive<Request>()).Operacija != Operation.Kraj)
                {
                    
                    Response odgovor = KreirajOdgovor(zahtev);
                    helper.Send(odgovor);


                   
                }
            }
            catch (IOException ex)
            {

                Debug.WriteLine(">>>>" + ex.Message);
            }
            finally
            {
                // soket.Shutdown(SocketShutdown.Both);
                // soket.Close();
                ZatvoriSoket();

                // treba izbaciti korisnika iz liste (klijent henlder iz liste klijenata)
                
            }
        } 

        public Response KreirajOdgovor(Request zahtev)
        {
            //samo kreiranje odgovora
            Response odgovor = new Response();

            try
            {
                switch (zahtev.Operacija)
                {
                    case Operation.Login:
                        odgovor.Rezultat = Kontroler.Instanca.Login((Korisnik)zahtev.RequestObject);
                        Console.WriteLine(odgovor.Rezultat);
                        
                        if (odgovor.Rezultat == null)
                        {
                            odgovor.Uspesno = false;
                            odgovor.Poruka = "Korisnik ne postoji!";
                        }
                  
                        

                        break;
                    case Operation.VratiSveProizvode:
                        odgovor.Rezultat = Kontroler.Instanca.VratiSveProizvode();
                       
                        

                        break;

                   


                    default:
                        break;

                }
            }
            catch (Exception ex)
            {
                //u slucaju da je greska sa klijentske strane, npr. pad baze

                Debug.WriteLine(ex.Message);
                odgovor.Uspesno = false;
                odgovor.Poruka = ex.Message;
                
            }
            return odgovor;
        }

        private object lockobject = new object();
        internal void ZatvoriSoket()
        {
            lock (lockobject) //thread save
            {
                //zatvaranje klijentskog soketa 

                if (soket != null)
                {
                    kraj = true;
                    soket.Shutdown(SocketShutdown.Both);
                    soket.Close();

                    soket = null;

                    OdjavljeniKlijent?.Invoke(this, EventArgs.Empty);

                }

            }
        }
    }
}
