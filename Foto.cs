using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    class Foto
    {
        private int cod;

        public int Cod
        {
            get { return cod; }
            set { cod = value; }
        }
        private int posizione;

        public int Posizione
        {
            get { return posizione; }
            set { posizione = value; }
        }
        private bool esiste;
        private string percorso;

        public string Percorso
        {
            get { return percorso; }
            set { percorso = value; }
        }
 
        public bool Esiste
        {
            get { return esiste; }
            set { esiste = value; }
        }
        public string[] NumeroFoto(int val)
        {
            string percorso = Application.StartupPath + @"\img";
           
            
            
            string[] filePaths = Directory.GetFiles(percorso, "myImage" + val + "-" + "*.jpg", SearchOption.TopDirectoryOnly);
            
            string[] NomeFoto=new string [filePaths.Count()];

            foreach (string f in filePaths)
            {
                string filenameWithoutPath = Path.GetFileName(f);
                int aperString = 9;
                int chiuString = filenameWithoutPath.IndexOf(".jpg", aperString);
                string numeroFoto = filenameWithoutPath.Substring(aperString, chiuString - aperString).Trim();
                if (numeroFoto == "1")
                {
                    if (NomeFoto[0] == null)
                    {
                        NomeFoto[0] = "myImage" + val + "-1.jpg";
                    }
                   
                    
                }
                if (numeroFoto == "2")
                {
                    if (NomeFoto[0] == null)
                    {
                        NomeFoto[0] = "myImage" + val + "-2.jpg";
                    }
                    else 
                    {
                        
                        NomeFoto[1] = "myImage" + val + "-2.jpg";
                        
                    }
                    
                }
                if (numeroFoto == "3")
                {
                    if (NomeFoto[0] == null)
                    {
                        NomeFoto[0] = "myImage" + val + "-3.jpg";
                    }
                    else
                    {
                        if (NomeFoto[1] == null)
                        {
                            NomeFoto[1] = "myImage" + val + "-3.jpg";
                        }
                        else
                        {
                            NomeFoto[2] = "myImage" + val + "-3.jpg";
                        }
                    }
                    
                    
                }


            }

            return NomeFoto;
        }
        public void FinalPath()
        {
            string str="update immagini set Percorso='"+this.Percorso+"' where id=7";
            Connessione conn = new Connessione();
            conn.EseguiSql(str);
        }
    }
    
    
}
