using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace WindowsFormsApplication1
{
    
    class Annunci
    {
        private int id;
        private string titolo;
        private string telefono;
        private string testo;
        private string web_address;
        private string emailscelta;
        public string Emailscelta
        {
            get { return emailscelta; }
            set { emailscelta = value; }
        }

        public string Web_address
        {
            get { return web_address; }
            set { web_address = value; }
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Titolo
        {
            get { return titolo; }
            set { titolo = value; }
        }


        public string Testo
        {
            get { return testo; }
            set { testo = value; }
        }
        private string eta;

        public string Eta
        {
            get { return eta; }
            set { eta = value; }
        }
        private string citta;

        public string Citta
        {
            get { return citta; }
            set { citta = value; }
        }


        public string Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }
        private string categoria;

        public string Categoria
        {
            get { return categoria; }
            set { categoria = value; }
        }
        private string indirizzo;

        public string Indirizzo
        {
            get { return indirizzo; }
            set { indirizzo = value; }
        }
        private string email;

        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        private string cmbEmail;

        public string CmbEmail
        {
            get { return cmbEmail; }
            set { cmbEmail = value; }
        }
        private string password;

        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        private string zona;

        public string Zona
        {
            get { return zona; }
            set { zona = value; }
        }
        private string cap;

        public string Cap
        {
            get { return cap; }
            set { cap = value; }
        }
        private int temp;

        public int Temp
        {
            get { return temp; }
            set { temp = value; }
        }
        private int contatore = 1;

        public int Contatore
        {
            get { return contatore; }
            set { contatore = value; }
        }

        public void Righa()
        {
            string righa = "select * from annunci where id=" + this.id;
            DataTable DT = new DataTable();
            Connessione c = new Connessione();
            DT = c.Browse(righa);
            
            try
            {
                this.titolo = DT.Rows[0]["titolo"].ToString();
                this.testo = DT.Rows[0]["testo"].ToString();
                this.telefono = DT.Rows[0]["telefono"].ToString();
                this.citta = DT.Rows[0]["citta"].ToString();
                this.email = DT.Rows[0]["email"].ToString();
                string [] words=email.Split('@');
                this.email=words[0];
                this.cmbEmail = "@"+words[1];

                this.password = DT.Rows[0]["password"].ToString();
                this.categoria = DT.Rows[0]["categoria"].ToString();
                this.indirizzo = DT.Rows[0]["indirizzo"].ToString();                
                this.cap = DT.Rows[0]["cap"].ToString();
                this.zona = DT.Rows[0]["zona"].ToString();
                this.eta = DT.Rows[0]["eta"].ToString();
                this.web_address = DT.Rows[0]["webaddress"].ToString();

            }
            catch 
            {
                this.titolo = "";
                this.testo = "";
                this.telefono = "";
                this.citta = "";
                this.email = "";
                this.categoria = "";
                this.indirizzo = "";
                this.eta = "";
                this.zona = "";
                
            }
            
        }
        public void Doppioni()
        {
            this.titolo=this.titolo.Replace("'", "''");
            this.testo = this.testo.Replace("'", "''");
            this.citta = this.citta.Replace("'","''");
            this.indirizzo = this.indirizzo.Replace("'","''");
            this.Zona = this.Zona.Replace("'","''");
            this.email = this.email.Replace("'", "''");
        }
        public void Aggiorna()
        {
            Doppioni();
            string str = "update annunci set titolo='" + this.titolo + "', testo='" + this.testo + "', telefono='" + this.telefono;
            str += "', citta='" + this.citta + "', email='" + this.email +"', categoria='" + this.categoria + "', cap='" + this.cap;
            str += "', indirizzo='" + this.indirizzo + "', eta='" + this.eta + "', zona='" + this.zona+"', password='"+this.password;
            str += "' where id="+this.id;

            Connessione conn = new Connessione();
            conn.EseguiSql(str);
        }
        public void refreshStatus()
        {
            string str = "update pubblicati set creato='1' where id_annuncio='"+this.id+"'";
            Connessione conn = new Connessione();
            conn.EseguiSql(str);
        }
        public string queryCreazione()
        {
            string query = "select creato from pubblicati where id_annuncio='"+this.id+"'";
            Connessione conn = new Connessione();
            DataTable DT=conn.Browse(query);
            string creazione=DT.Rows[0].ToString();
            return creazione;
        }
        public int ResetAll()
        {
            string query = "select creato from pubblicati";
            Connessione conn = new Connessione();
            DataTable DT = conn.Browse(query);
            
            int i=0;
            DataRow DR;
            try
            {
                for (i = 0; i <= DT.Rows.Count - 1; i++)
                {


                    DR = DT.Rows[i];
                    if (DR.ToString() == "0")
                    {
                        return i;
                    }
                    

                }
                return 4;
            }
            catch
            {
                return 0;
            }
   
        }

        public void saveurl()
        {
            Connessione conn = new Connessione();
            string crt = "update annunci set webaddress='" + this.web_address + "' where id=" + this.id;
            conn.EseguiSql(crt);
        }
    }
}
