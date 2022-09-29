using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server
{
    public partial class FrmServer : Form
    {
        private Server server; 
        public FrmServer()
        {
            InitializeComponent();
            btnStart.Enabled = true;
            btnStop.Enabled = false; //sprecavamo korisnika da u startu klikne stop

            this.FormClosed += FrmServer_FormClosed;
        }

        private void FrmServer_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            server = new Server();
            if (server.Start()){
                
                btnStart.Enabled = false; //sprecavamo korisnika da ponovo pokrene srever
                btnStop.Enabled = true;
                MessageBox.Show("Server je pokrenut!");
                Thread nit=new Thread(server.Listen);
                nit.IsBackground = true;
                nit.Start();
                
            }
            else
            {
                MessageBox.Show("Server nije pokrenut!");
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            server?.Stop();//ako je server null, ne pozivaj ovu metodu(u slucaju da korisnik odmah klikne stop)
            server = null;
            btnStart.Enabled = true;
            btnStop.Enabled = false;
            
            MessageBox.Show("Server je zaustavljen");
        }

       
    }
}
