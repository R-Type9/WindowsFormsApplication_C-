using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Windows.Forms.ComponentModel;
using System.IO;
//using System.Web.UI.WebControls;
using System.Web;





namespace WindowsFormsApplication1
{
    public partial class ModificaA : Form
    {
       Annunci anu = new Annunci();
        
        public ModificaA()
        {
            
            InitializeComponent();
            
            panel3.Location = new Point(
            this.ClientSize.Width / 2 - panel3.Size.Width / 2,
            this.ClientSize.Height / 2 - panel3.Size.Height / 2);
            panel3.Anchor = AnchorStyles.None;
            

            anu.Id = 1;
            anu.Righa();
            caricaTutto();
            btnAnt.Visible = false;

            
            NumeroFoto(1);
            link();

        }
        public void NumeroFoto(int val)
        {
            
            try
            {
                
                string percorso = Application.StartupPath + @"\img";
                bool foto1 = false;
                bool foto2 = false;
                bool foto3 = false;
                string[] filePaths = Directory.GetFiles(percorso, "myImage" + val + "-" + "*.jpg", SearchOption.TopDirectoryOnly);
                foreach (string f in filePaths)
                {
                    string filenameWithoutPath = Path.GetFileName(f);
                    int aperString = 9;
                    int chiuString = filenameWithoutPath.IndexOf(".jpg", aperString);
                    string numeroFoto = filenameWithoutPath.Substring(aperString, chiuString - aperString).Trim();
                    if (numeroFoto == "1")
                    {
                        pictureBox1.ImageLocation = percorso + "\\myImage" + val + "-1.jpg";
                        foto1 = true;
                    }
                    if (numeroFoto == "2")
                    {
                        pictureBox2.ImageLocation = percorso + "\\myImage" + val + "-2.jpg";
                        foto2 = true;
                    }
                    if (numeroFoto == "3")
                    {
                        pictureBox3.ImageLocation = percorso + "\\myImage" + val + "-3.jpg";
                        foto3 = true;
                    }


                }
                if (foto1 == false)
                {
                    pictureBox1.ImageLocation = null;
                }
                if (foto2 == false)
                {
                    pictureBox2.ImageLocation = null;
                }
                if (foto3 == false)
                {
                    pictureBox3.ImageLocation = null;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("C'e un problema nella cartella \"img\" ");

                return;
                
            }
        }
        
   
        public void link()
        {
            if (pictureBox1.ImageLocation == null)
            {
                linkLabel1.Text = "Inserisce Foto";
            }
            else
            {
                linkLabel1.Text = "Modifica Foto";
            }
            if (pictureBox2.ImageLocation == null)
            {
                linkLabel2.Text = "Inserisce Foto";
            }
            else
            {
                linkLabel2.Text = "Modifica Foto";
            }
            if (pictureBox3.ImageLocation == null)
            {
                linkLabel3.Text = "Inserisce Foto";
            }
            else
            {
                linkLabel3.Text = "Modifica Foto";
            }
        }
        private void ModificaA_SizeChanged(object sender, EventArgs e)
        {
            CenterControlInParent(panel3);
        }
        private void CenterControlInParent(Control ctrlToCenter)
        {
            ctrlToCenter.Left = (ctrlToCenter.Parent.Width - ctrlToCenter.Width) / 2;
            ctrlToCenter.Top = (ctrlToCenter.Parent.Height - ctrlToCenter.Height) / 2;
        }
        private void btnPro_Click(object sender, EventArgs e)
        {
            anu.Id = anu.Id + 1;
            switch (anu.Id)
            {
                case 2:
                    NumAnun.Text = "2. Secondo Annuncio";
                    break;
                case 3:
                    NumAnun.Text = "3. Terzo Annuncio";
                    break;
                case 4:
                    NumAnun.Text = "4. Quarto Annuncio";
                    break;
                case 5:
                    NumAnun.Text = "5. Quinto Annuncio";
                    break;
            }
            anu.Righa();
            caricaTutto();

            NumeroFoto(anu.Id);

            
            link();
            btnAnt.Visible = true;
            if (anu.Id > 4) 
            {
                btnPro.Visible = false;
            }
            
        }

        private void btnAnt_Click(object sender, EventArgs e)
        {
            anu.Id = anu.Id - 1;
            switch (anu.Id)
            {
                case 2:
                    NumAnun.Text = "2. Secondo Annuncio";
                    break;
                case 3:
                    NumAnun.Text = "3. Terzo Annuncio";
                    break;
                case 4:
                    NumAnun.Text = "4. Quarto Annuncio";
                    break;
                case 1:
                    NumAnun.Text = "1. Primo Annuncio";
                    break;
            }
            anu.Righa();
            caricaTutto();

            NumeroFoto(anu.Id);

            
            link();

            btnPro.Visible = true;
            if (anu.Id < 2)
            {
                btnAnt.Visible = false;
            }
        }
        private void caricaTutto()
        {
            txtTesto.Text = anu.Testo;
            txtTitolo.Text = anu.Titolo;
            txtEmail.Text = anu.Email;
            cmbMail.Text = anu.CmbEmail;
            txtPass.Text = anu.Password;
            txtTel.Text = anu.Telefono;
            txtInd.Text = anu.Indirizzo;
            txtZon.Text = anu.Zona;
            txtEta.Text = anu.Eta;
            comboBox2.Text = anu.Citta;
            txtCap.Text = anu.Cap;
            comboBox1.Text = anu.Categoria;
           
        }

        private void btnSalva_Click(object sender, EventArgs e)
        {

            if (txtTesto.Text.Trim() != "" && txtTitolo.Text.Trim() != "" && txtPass.Text.Trim() != "" &&
                txtEmail.Text.Trim() != "")
            {
                anu.Titolo = txtTitolo.Text.Trim();
                anu.Testo = txtTesto.Text.Trim();
                int count = Regex.Matches(txtEmail.Text, "@").Count;
                if (count > 0)
                {
                    MessageBox.Show("Errore nel inserimento della Email");
                    return;
                }
                else
                {
                    anu.Email = txtEmail.Text.Trim() + cmbMail.Text;                    
                }

                

                anu.Password = txtPass.Text.Trim();
                anu.Indirizzo = txtInd.Text.Trim();
                anu.Eta = txtEta.Text.Trim();
                anu.Citta = comboBox2.Text.Trim();
                anu.Cap = txtCap.Text.Trim();
                anu.Categoria = comboBox1.Text.Trim();
                anu.Telefono = txtTel.Text;
                anu.Zona = txtZon.Text.Trim();

                anu.Aggiorna();
                MessageBox.Show("Salvataggio Avvenuto");
            }
            else
            {
                MessageBox.Show("Errore, devi compilare i campi Titolo, Testo, Password e Email");
            }
        }

        

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtEta_TextChanged(object sender, EventArgs e)
        {

        }

        

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            pictureBox1.Show();
        }

        

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ModificaFoto mf = new ModificaFoto();
            bool immagine = true;
            if (pictureBox1.ImageLocation == null)
            {
                immagine = false;
            }

            int valore = anu.Id;
            mf.Preview(valore, 1, immagine);

            mf.FormClosing += new FormClosingEventHandler(ChildFormClosing);
            anu.Temp = 1;
            mf.ShowDialog();

            
        }
        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var mf = new ModificaFoto();
            bool immagine = true;
            if (pictureBox2.ImageLocation == null)
            {
               immagine = false;
            }
            int valore=anu.Id;
            mf.Preview(valore,2,immagine);

            mf.FormClosing += new FormClosingEventHandler(ChildFormClosing);
            anu.Temp = 2;
            mf.ShowDialog();
        }
        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var mf = new ModificaFoto();
            bool immagine = true;
            if (pictureBox3.ImageLocation == null)
            {
                immagine = false;
            }
            int valore = anu.Id;
            mf.Preview(valore, 3, immagine);

            mf.FormClosing += new FormClosingEventHandler(ChildFormClosing);
            anu.Temp = 3;
            mf.ShowDialog();
        }
            
        private void ChildFormClosing(object sender, FormClosingEventArgs e)
        {
            string percorso = Application.StartupPath + @"\img";
            
            
            if (anu.Temp == 1)
            {
                pictureBox1.ImageLocation = percorso + "\\myImage" + anu.Id + "-"+anu.Temp+".jpg";
            }
            if (anu.Temp == 2)
            {
                pictureBox2.ImageLocation = percorso + "\\myImage" + anu.Id + "-" + anu.Temp + ".jpg";
            }
            if (anu.Temp == 3)
            {
                pictureBox3.ImageLocation = percorso + "\\myImage" + anu.Id + "-" + anu.Temp + ".jpg";
            }
        }
        public void Newpath()
        {
            string percorso = Path.GetFullPath("img");
            Foto fo = new Foto();
            fo.Percorso = percorso;
            fo.FinalPath();
        }
    }
}
