using AplikacionaLogika;
using Domain;
using KorisnickiInterfejs.Exceptions;
using KorisnickiInterfejs.GUIController;
using KorisnickiInterfejs.ServerCommunication;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KorisnickiInterfejs
{
    public partial class FrmLogin : Form
    {
        private LoginKontroler loginKontroler;
        public FrmLogin()
        {
            InitializeComponent();
            loginKontroler = new LoginKontroler();
            btnLogin.Click += btnLogin_Click;

        }


        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            loginKontroler.Login(this);

          

            
        }

        private void FrmLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
         

        }
    }

           
         



}
