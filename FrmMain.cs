using AplikacionaLogika;
using KorisnickiInterfejs.ServerCommunication;
using KorisnickiInterfejs.UserControls;
using KorisnickiInterfejs.UserControls.Invoice;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KorisnickiInterfejs
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
            
            this.Text = $"Dobrodošli, {Kontroler.Instanca.TrenutniKorisnik.Ime} {Kontroler.Instanca.TrenutniKorisnik.Prezime}!";


        }

        private void dodajProizvodToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PromeniPanel(new UCProizvod());
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {

        }

        private void prikaziProizvodeToolStripMenuItem_Click(object sender, EventArgs e)
        {

            PromeniPanel(new UCSviProizvodi());
        
        }

        private void dodajProizvodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PromeniPanel(new UCDodajProizvode());

        }

        private void dodajNovuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PromeniPanel(new UCInvoice());
        }

        //da ne bismo stalno ponavljali isti kod, lakse nam je da napravimo funkciju 
        //menjamo panel i dodajemo u kontrole, stvar koja se menja je user controla
        //mozemo da stavimo object kao opsti tip, ali posto nam je tip isti uvek biramo UserControl
        private void PromeniPanel(UserControl uCKontrola)
        {
            pnlMain.Controls.Clear();

            uCKontrola.Dock = DockStyle.Fill;
            pnlMain.Controls.Add(uCKontrola);
            
        }

        private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                Komunikacija.Instanca.Close();
            }
            catch (IOException ex)
            {

                Debug.WriteLine(">>>>>FrmClosed event", ex.Message);
            }
        }
    }
}
