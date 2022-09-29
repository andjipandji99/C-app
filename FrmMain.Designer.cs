
namespace KorisnickiInterfejs
{
    partial class FrmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.proizvodToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dodajProizvodToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.prikaziProizvodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dodajProizvodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.narudzbenicaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dodajNovuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.proizvodToolStripMenuItem,
            this.narudzbenicaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(872, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuMain";
            // 
            // proizvodToolStripMenuItem
            // 
            this.proizvodToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dodajProizvodToolStripMenuItem,
            this.prikaziProizvodeToolStripMenuItem,
            this.dodajProizvodeToolStripMenuItem});
            this.proizvodToolStripMenuItem.Name = "proizvodToolStripMenuItem";
            this.proizvodToolStripMenuItem.Size = new System.Drawing.Size(81, 24);
            this.proizvodToolStripMenuItem.Text = "Proizvod";
            // 
            // dodajProizvodToolStripMenuItem
            // 
            this.dodajProizvodToolStripMenuItem.Name = "dodajProizvodToolStripMenuItem";
            this.dodajProizvodToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.dodajProizvodToolStripMenuItem.Text = "Dodaj proizvod";
            this.dodajProizvodToolStripMenuItem.Click += new System.EventHandler(this.dodajProizvodToolStripMenuItem_Click);
            // 
            // prikaziProizvodeToolStripMenuItem
            // 
            this.prikaziProizvodeToolStripMenuItem.Name = "prikaziProizvodeToolStripMenuItem";
            this.prikaziProizvodeToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.prikaziProizvodeToolStripMenuItem.Text = "Prikazi proizvode";
            this.prikaziProizvodeToolStripMenuItem.Click += new System.EventHandler(this.prikaziProizvodeToolStripMenuItem_Click);
            // 
            // dodajProizvodeToolStripMenuItem
            // 
            this.dodajProizvodeToolStripMenuItem.Name = "dodajProizvodeToolStripMenuItem";
            this.dodajProizvodeToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.dodajProizvodeToolStripMenuItem.Text = "Dodaj proizvode";
            this.dodajProizvodeToolStripMenuItem.Click += new System.EventHandler(this.dodajProizvodeToolStripMenuItem_Click);
            // 
            // pnlMain
            // 
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 28);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(872, 622);
            this.pnlMain.TabIndex = 1;
            // 
            // narudzbenicaToolStripMenuItem
            // 
            this.narudzbenicaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dodajNovuToolStripMenuItem});
            this.narudzbenicaToolStripMenuItem.Name = "narudzbenicaToolStripMenuItem";
            this.narudzbenicaToolStripMenuItem.Size = new System.Drawing.Size(115, 24);
            this.narudzbenicaToolStripMenuItem.Text = "Narudzbenica";
            // 
            // dodajNovuToolStripMenuItem
            // 
            this.dodajNovuToolStripMenuItem.Name = "dodajNovuToolStripMenuItem";
            this.dodajNovuToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.dodajNovuToolStripMenuItem.Text = "Dodaj novu";
            this.dodajNovuToolStripMenuItem.Click += new System.EventHandler(this.dodajNovuToolStripMenuItem_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(872, 650);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmMain";
            this.Text = "FrmMain";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmMain_FormClosed);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem proizvodToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dodajProizvodToolStripMenuItem;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.ToolStripMenuItem prikaziProizvodeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dodajProizvodeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem narudzbenicaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dodajNovuToolStripMenuItem;
    }
}