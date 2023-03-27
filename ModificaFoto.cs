using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using System.Data.SqlServerCe;
using System.IO;

namespace WindowsFormsApplication1
{
    public partial class ModificaFoto : Form
    {
        public static int foto;
        public static int codice;
        public static int numero;
        
        public ModificaFoto()
        {
            InitializeComponent();

            panel1.Location = new Point(
           this.ClientSize.Width / 2 - panel1.Size.Width / 2,
           this.ClientSize.Height / 2 - panel1.Size.Height / 2);
            panel1.Anchor = AnchorStyles.None;
            
           
        }

        private void btnOpenImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog filechosser = new OpenFileDialog();
            filechosser.Filter = "image file (*.jpg ) |*.jpg|All files (*.*)|*.*";
            filechosser.InitialDirectory = "C:\\Users\\Public\\Pictures";
            filechosser.Title = "Seleziona la tua immagine";
            
            if (filechosser.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.ImageLocation = filechosser.FileName;
                if (foto == 0)
                {
                    foto = 3;
                }
                else
                {
                    foto = 4;
                }
                label1.Text = "Immagine selezionata!";
            }
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                label1.Text = "Non Hai selezionato nessuna immagine";
            }
            else
            {
                
                string cartella = "\\img";
                string percorso = Application.StartupPath + cartella;
                if (foto == 1)
                {
                    label1.Text = "Questa è la stessa foto, scegli un altra!";
                }
                else
                {
                    if (foto == 3)
                    {
                        
                        try
                        {
                            var precius2 = new Bitmap(pictureBox1.Image);
                            precius2.Save(percorso + "\\myImage" + codice + "-" + numero + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                            
                        }
                        catch
                        {
                            MessageBox.Show("c'e un errore controllare...");
                        }
                        if (MessageBox.Show("L' immagine è stata salvata") == DialogResult.OK)
                        {
                            this.Close();

                        }
                    }
                    else
                    {
                        if (foto == 4)
                        { 
                           
                            try
                            {
                                File.Delete(percorso + "\\myImage" + codice + "-" + numero + ".jpg");
                                var precius = new Bitmap(pictureBox1.Image);
                                precius.Save(percorso + "\\myImage" + codice + "-" + numero + ".jpg", ImageFormat.Jpeg);
                            
                            }
                            catch (Exception ex)
                            {
                                label1.Text = ex.InnerException.ToString();
                                
                            }
                            
                            if (MessageBox.Show("L' immagine è stata salvata") == DialogResult.OK)
                            {
                                this.Close();
                                
                            }

                        }
                    }
                }
            }
            
        }
        public void Preview(int cod, int posizione, bool esiste)
        {
            if (esiste == true)
            {

                string cartella = "\\img";
                string percorso = Application.StartupPath + cartella;
                pictureBox1.ImageLocation = percorso+"\\myImage"+cod+"-"+posizione+".jpg";
                foto = 1;
                
            }
            else
            {
                btnElimina.Visible = false;
                foto = 0;
            }
            codice = cod;
            numero = posizione;
        }

        private void bnElimina_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                string percorso = Application.StartupPath + @"\img";
                //string cartella = "\\img";
                //string percorso = Environment.CurrentDirectory + cartella;
                
                try
                {

                    File.Delete(percorso + "\\myImage" + codice + "-" + numero + ".jpg");
                    if (MessageBox.Show("La Foto è stata cancellata") == DialogResult.OK)
                    {
                        this.Close();
                    }

                }
                catch (Exception ex)
                {
                    ex.InnerException.ToString();

                }
            }
            else 
            {
                label1.Text = "Non hai scelto nessuna foto";
            }
        }
    }
}
