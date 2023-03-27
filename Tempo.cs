using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;

namespace WindowsFormsApplication1
{
    class Tempo
    {
        private string pick1;

        public string Pick1
        {
            get { return pick1; }
            set { pick1 = value; }
        }
        private string pick2;

        public string Pick2
        {
            get { return pick2; }
            set { pick2 = value; }
        }
        private string pick3;

        public string Pick3
        {
            get { return pick3; }
            set { pick3 = value; }
        }
        private string pick4;

        public string Pick4
        {
            get { return pick4; }
            set { pick4 = value; }
        }
        private string pick5;

        public string Pick5
        {
            get { return pick5; }
            set { pick5 = value; }
        }
        private int combo;

        public int Combo
        {
            get { return combo; }
            set { combo = value; }
        }
        private TimeSpan ts;

        public TimeSpan Ts
        {
            get { return ts; }
            set { ts = value; }
        }
        private string ripeti;

        public string Ripeti
        {
            get { return ripeti; }
            set { ripeti = value; }
        }
        
        
        public bool riga_creato(int a)
        {
            string query = "select creato from pubblicati where id_annuncio="+a;
            Connessione conn = new Connessione();
            DataTable DT=conn.Browse(query);
            bool bcreate=false;
            if (DT.Rows[0]["creato"].ToString() == "1")
            {
                bcreate = true;
            }
            return bcreate;
         
        }
        public bool riga_pubblicato(int a)
        {
            string query = "select pubblicato from pubblicati where id_annuncio=" + a;
            Connessione conn = new Connessione();
            DataTable DT = conn.Browse(query);
            bool bpublish = false;
            if (DT.Rows[0]["pubblicato"].ToString() == "1")
            {
                bpublish = true;
            }
            return bpublish;

        }
        public void valoriPrec()
        {
           
            Connessione conn = new Connessione();
            string qry = "select * from Tempo where id=1";
            DataTable DT =conn.Browse(qry);
            DataRow DR= DT.Rows[0];
            try
            {
                this.combo = Convert.ToInt32(DR["combo"]);
                this.pick1 =DR["picker1"].ToString();
                this.pick2 =DR["picker2"].ToString();
                this.pick3 =DR["picker3"].ToString();
                this.pick4 =DR["picker4"].ToString();
                this.pick5 = DR["picker5"].ToString();
            }
            catch
            {
                this.combo = 0;
                this.pick1 = "";
                this.pick2 = "";
                this.pick3 = "";
                this.pick4 = "";
                this.pick5 = "";
            }
            
        }
        public void UpdateTempo()
        {

            if (this.Combo == 1)
            {
                this.pick2 = "00:00";
                this.pick3 = "00:00";
                this.pick4 = "00:00";
                this.pick5 = "00:00";
            }
            if (this.combo == 2)
            {
                this.pick3 = "00:00";
                this.pick4 = "00:00";
                this.pick5 = "00:00";
            }
            if (this.combo == 3)
            {
                this.pick4 = "00:00";
                this.pick5 = "00:00";
            }
            if (this.combo == 4)
            {
                this.pick5 = "00:00";
            }
            string isrt = "Update tempo set combo=" + this.Combo + ", picker1='" + this.pick1 + "', picker2='";
            isrt += this.pick2 + "', picker3='" + this.pick3 + "', picker4='" + this.pick4 + "', picker5='" + this.pick5;
            isrt +="' where id=1";

            Connessione conn = new Connessione();
            conn.EseguiSql(isrt);
        }
        public void create_all()
        { 
          string str="Update tempo set create_all='yes' where id=1";
          Connessione conn = new Connessione();
          conn.EseguiSql(str);
        }
        public string control_create_all()
        {
            string qry = "select create_all from tempo where id=1";
            Connessione conn = new Connessione();
            DataTable DT=conn.Browse(qry);
            string result;
            result=DT.Rows[0]["create_all"].ToString();
            return result;
        }
        public void updatePublish(int val)
        {
            string str = "update pubblicati set pubblicato=1 where id_annuncio=" + val;
            Connessione conn = new Connessione();
            conn.EseguiSql(str);
        }
        public void updatePublishBann(int val)
        {
            string str = "update pubblicati set pubblicato=1, bannato=1 where id_annuncio=" + val;
            Connessione conn = new Connessione();
            conn.EseguiSql(str);
        }
        public string ControlBann(int val)
        {
            string qry = "select bannato from pubblicati where id_annuncio=" + val ;
            Connessione conn = new Connessione();
            DataTable DT=conn.Browse(qry);
            string ba=DT.Rows[0]["bannato"].ToString();
            return ba;
        }
        public void ControlClearAll()
        {
            string str = "update pubblicati set pubblicato=0";
            string str2 = "update pubblicati set creato=0";
            string str3 = "update pubblicati set bannato=0";
            string str4 = "update tempo set create_all='no' where id=1";
            Connessione conn = new Connessione();
            conn.EseguiSql(str);
            conn.EseguiSql(str2);
            conn.EseguiSql(str3);
            conn.EseguiSql(str4);

        }
        public int visuale()
        {
            Connessione conn = new Connessione();
            string qry="select creato from pubblicati where id_annuncio=1";
            DataTable DT=conn.Browse(qry);
            int val = Convert.ToInt32(DT.Rows[0]["creato"]);
            return val;
        }

        public int control7()
        {
            string qry = "select last from tempo where id=1";
            Connessione conn = new Connessione();
            DataTable DT = conn.Browse(qry);
            int val = Convert.ToInt32(DT.Rows[0]["last"]);
            return val;
        }
        public void Updcontrol7(int val)
        {
            
            string str = "Update tempo set last="+val;                           
            str+=" where id=1";
            Connessione conn = new Connessione();
            conn.EseguiSql(str);
   
        }
        public void Change()
        {
            string str = "update tempo set ora='0' where id=1";
            Connessione conn = new Connessione();
            conn.EseguiSql(str);
        }
        public void dim()
        {
            string str = "update tempo set serial='000000' where id=1";
            Connessione conn = new Connessione();
            conn.EseguiSql(str);
        }
        public string getdata()
        {
            string qry = "select * from azione";
            Connessione co = new Connessione();
            string td="";
            
                DataTable DT = co.Browse(qry);
                td = DT.Rows[0]["tempo"].ToString();
                return td;
            
            
            
        }
        public void savedata()
        {
            
            string str = "Update azione set tempo=getdate() where id_a=1";
            Connessione conn = new Connessione();
            conn.EseguiSql(str);
        }
    }
    
}
