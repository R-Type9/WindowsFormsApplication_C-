using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Web;
using System.Net;
using System.Collections;
using System.Collections.Specialized;
using System.IO;

using System.Text.RegularExpressions;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            Connessione conns = new Connessione();
            
            if (conns.Annuncix() == 0)
            {
                MessageBox.Show("ERRORE!!!!1");
                this.Close();
                return;
            }
            InitializeComponent();
            

            panel1.Location = new Point(
           this.ClientSize.Width / 2 - panel1.Size.Width / 2,
           this.ClientSize.Height / 2 - panel1.Size.Height / 2);
            panel1.Anchor = AnchorStyles.None;
            
            
            panel3.Location = new Point(
           this.ClientSize.Width / 2 - panel3.Size.Width / 2,
           this.ClientSize.Height / 2 - panel3.Size.Height / 2);
            panel3.Anchor = AnchorStyles.None;
            
            panel2.Location = new Point(
           this.ClientSize.Width / 2 - panel2.Size.Width / 2,
           this.ClientSize.Height / 2 - panel2.Size.Height / 2);
            panel2.Anchor = AnchorStyles.None;
            
           
            Tempo te = new Tempo();
            try
            {
                te.valoriPrec();
            }
            catch
            {
                MessageBox.Show("ERRORE!!!!2");
                this.Close();
            }
            if (te.riga_creato(1) == true)
            {
                for (int j = 2; j <= te.Combo; j++)
                {
                    if (te.riga_creato(j) == false)
                    {
                        if (j == 2)
                        {
                            creaDalSito(te.Pick2, j);
                        }
                        if (j == 3)
                        {
                            creaDalSito(te.Pick3, j);
                        }
                        if (j == 4)
                        {
                            creaDalSito(te.Pick4, j);
                        }
                        if (j == 5)
                        {
                            creaDalSito(te.Pick5, j);
                        }
                        break;
                    }

                }

            }
            int c7 = te.control7();
            if (c7 == 0)
            {
                webBrowser2.Visible = false;
                variabile = "ver_valor";
                Thread.Sleep(1000);
                webBrowser2.Navigate("http://sitophp2013.altervista.org/verifica.php");
            }
            else
            {
                c7--;
                te.Updcontrol7(c7);
                
                initialprocess();
                
            }
            

            
            string sb=conns.zoe();
            if (sb == "0")
            {
                this.FormClosed += Form1_FormClosed;
                te.dim();

            }
        }
        public static int i = 0;
        public static int y = 0;
        public static bool bannata = false;
        public static string variabile="primo";
        [DllImport("kernel32.dll")]
        static extern EXECUTION_STATE SetThreadExecutionState(EXECUTION_STATE esFlags);

        [FlagsAttribute]
        enum EXECUTION_STATE : uint
        {
            ES_AWAYMODE_REQUIRED = 0x00000040,
            ES_CONTINUOUS = 0x80000000,
            ES_DISPLAY_REQUIRED = 0x00000002,
            ES_SYSTEM_REQUIRED = 0x00000001
        }
        Tempo te = new Tempo();
        
        Annunci an = new Annunci();
        


        public static void Disable()
        {

            SetThreadExecutionState(EXECUTION_STATE.ES_DISPLAY_REQUIRED | EXECUTION_STATE.ES_CONTINUOUS | EXECUTION_STATE.ES_SYSTEM_REQUIRED);
                        
        }
        private void initialprocess()
        {
            //ControlloData/o mese
            //cod_h();
            te.valoriPrec();
            //per sapere se il primo panello divena invisible per che è sao prmuo il pulsane pubblica
            

            if (te.control_create_all() == "yes")
            {
                panel1.Visible = false;
                var mess = new Messaggio_Ok();

                mess.FormClosing += new FormClosingEventHandler(ChiusuraFormFiglio);
                mess.ShowDialog();

            }
            else
            {

                comboBox1.Text = te.Combo.ToString();
                if (te.Combo == 1)
                {
                    dateTimePicker_1.Text = te.Pick1;
                }
                else
                {
                    if (te.Combo == 2)
                    {
                        dateTimePicker_1.Text = te.Pick1;
                        dateTimePicker_2.Text = te.Pick2;
                    }
                    else
                    {
                        if (te.Combo == 3)
                        {
                            dateTimePicker_1.Text = te.Pick1;
                            dateTimePicker_2.Text = te.Pick2;
                            dateTimePicker_3.Text = te.Pick3;
                        }
                        else
                        {
                            if (te.Combo == 4)
                            {
                                dateTimePicker_1.Text = te.Pick1;
                                dateTimePicker_2.Text = te.Pick2;
                                dateTimePicker_3.Text = te.Pick3;
                                dateTimePicker_4.Text = te.Pick4;

                            }
                            else
                            {
                                if (te.Combo == 5)
                                {
                                    dateTimePicker_1.Text = te.Pick1;
                                    dateTimePicker_2.Text = te.Pick2;
                                    dateTimePicker_3.Text = te.Pick3;
                                    dateTimePicker_4.Text = te.Pick4;
                                    dateTimePicker_5.Text = te.Pick5;

                                }
                            }
                        }
                    }
                }
                panel1.Visible = true;
                if (te.visuale() == 1)
                {
                    panel1.Visible = false;
                }
            }
            
        }
        private void cod_h()
        {
            
            if (te.getdata() == "")
            {
                
                te.savedata();
            }
            else
            {
                DateTime Dtime = DateTime.Parse(te.getdata());


                if (Dtime < DateTime.Now.AddDays(-3))
                {
                   this.Close();
                }
            }
            
        }
        private void LanciaProcesso(Object sender, System.EventArgs e)
        {
            Foto fo = new Foto();

            string[] FotoNome = fo.NumeroFoto(y);
            if (i < FotoNome.Length)
            {
                System.Windows.Forms.Timer timer = (System.Windows.Forms.Timer)sender;
                timer.Stop();
               
                string percorso = Application.StartupPath + @"\img";
                
               
                Thread.Sleep(500);
                SendKeys.Send(FotoNome[i]);
                Thread.Sleep(500);

                SendKeys.SendWait("{tab}{tab}{tab}{tab}");
                Thread.Sleep(500);

                SendKeys.SendWait("{ENTER}");

                SendKeys.SendWait(percorso);
                Thread.Sleep(1000);
                SendKeys.SendWait("{ENTER}");

                SendKeys.SendWait("{tab}");

                SendKeys.SendWait("{tab}");

                SendKeys.SendWait("{tab}");

                SendKeys.SendWait("{tab}");

                SendKeys.SendWait("{tab}");

                SendKeys.SendWait("{tab}");

                SendKeys.SendWait("{tab}");

                SendKeys.SendWait("{ENTER}");

                
               
                System.Windows.Forms.Timer timecarica = new System.Windows.Forms.Timer();

               
                timecarica.Start();
                timecarica.Tick += new EventHandler(clickcarica);

                
                i++;
                
          
            }
            else
            {
                
                MessageBox.Show("ERRORE... Chiudere tutto");
                this.Close();
            }
            
        }
        private void clickcarica(Object sender, System.EventArgs e)
        {
            System.Windows.Forms.Timer timercarica = (System.Windows.Forms.Timer)sender;
            timercarica.Stop();
            try
            {
                HtmlElementCollection elc2 = this.webBrowser1.Document.GetElementsByTagName("input");

                foreach (HtmlElement el2 in elc2)
                {
                    if (el2.GetAttribute("type").Equals("button") && el2.GetAttribute("value").Equals("CARICA"))
                    {
                        Foto fo = new Foto();

                        string[] FotoNome = fo.NumeroFoto(y);
                        if (i >= FotoNome.Length)
                        {
                            variabile = "terzo";
                        }
                        el2.InvokeMember("Click");
                        break;

                    }
                }
               
            }
            catch (Exception)
            {
                MessageBox.Show("Devi lasciar caricare la pagina", "troppo lento :(");
            } 

        }
        
       
        private void ElencoMail_hot(object sender, EventArgs e)
        {
            webBrowser1.Navigate("https://dub116.mail.live.com/default.aspx");
            System.Windows.Forms.Timer posta = (System.Windows.Forms.Timer)sender;
            posta.Stop();
        }
        private void ElencoMail(object sender, EventArgs e)
        {
            

            

            
            string html = string.Empty;
            Uri url = new Uri("http://easymail.libero.it/posta-arrivata");
            webBrowser1.Navigate(url);

            string source = webBrowser1.DocumentText;
            
            string data=DateTime.Now.ToString("dd/MM/yyyy");

           
            int count=Regex.Matches(source, data).Count;





            int totale = source.Length;
           
            int start = source.IndexOf(data)-420;
            
            int stop = source.LastIndexOf(data);
            int temp = totale - start;
            temp = temp - stop;
            string dati = source.Substring(start, stop - start).Trim();

            //modifica github
            int countBakeca = Regex.Matches(dati, "support@bakeca.com").Count;
            if (countBakeca == 0)
            {

            }
            else 
            {
                int stopBakeca = dati.LastIndexOf("support@bakeca.com");
                string linkbakeca=dati.Substring(stopBakeca-66,122);

                int visitato = Regex.Matches(linkbakeca, "<b>").Count;
                if (visitato == 0)
                {

                }
                else
                {
                    int aperBakeca = linkbakeca.IndexOf("<a href=")+10;
                    int chiuBakeca = linkbakeca.IndexOf(">", aperBakeca)-1;
                    string link = linkbakeca.Substring(aperBakeca, chiuBakeca - aperBakeca).Trim();
                    string urlpage = "http://easymail.libero.it/" + link;
                    webBrowser1.Navigate(urlpage);
                    HtmlElementCollection elems = this.webBrowser1.Document.GetElementsByTagName("a");
                    foreach (HtmlElement he in elems)
                    { 
                        if(he.GetAttribute("class").Equals("btn"))
                        {
                            he.InvokeMember("click");
                        }
   

                    }
                }

            }
           

            
         
            System.Windows.Forms.Timer posta = (System.Windows.Forms.Timer)sender;
            posta.Stop();

        }
        
        private void btnTempo_click(object sender, EventArgs e)
        {
            
            panel1.Visible = false;
            int nPublic = Convert.ToInt32(comboBox1.SelectedItem.ToString());

            te.Combo = nPublic;

            int h1, h2, h3, h4, h5;
            int m1, m2, m3, m4, m5;
            h1=dateTimePicker_1.Value.Hour;
            m1 = dateTimePicker_1.Value.Minute;
            List<TimeSpan> _orari = new List<TimeSpan>();
            _orari.Add(new TimeSpan(h1, m1, 1));

            switch (nPublic)
            {
                case 2:
                    
                    h2=dateTimePicker_2.Value.Hour;
                    m2 = dateTimePicker_2.Value.Minute;
                    _orari.Add(new TimeSpan(h2, m2, 2));

                    break;

                case 3:
                    h2=dateTimePicker_2.Value.Hour;
                    m2 = dateTimePicker_2.Value.Minute;
                    h3=dateTimePicker_3.Value.Hour;
                    m3 = dateTimePicker_3.Value.Minute;
                    _orari.Add(new TimeSpan(h2, m2, 2));
                    _orari.Add(new TimeSpan(h3, m3, 3));

                    
                    break;
                case 4:
                    h2=dateTimePicker_2.Value.Hour;
                    m2 = dateTimePicker_2.Value.Minute;
                    h3=dateTimePicker_3.Value.Hour;
                    m3 = dateTimePicker_3.Value.Minute;
                    h4=dateTimePicker_4.Value.Hour;
                    m4 = dateTimePicker_4.Value.Minute;
                    _orari.Add(new TimeSpan(h2, m2, 2));
                    _orari.Add(new TimeSpan(h3, m3, 3));
                    _orari.Add(new TimeSpan(h4, m4, 4));

                    break;

                case 5:
                    h2=dateTimePicker_2.Value.Hour;
                    m2 = dateTimePicker_2.Value.Minute;
                    h3=dateTimePicker_3.Value.Hour;
                    m3 = dateTimePicker_3.Value.Minute;
                    h4=dateTimePicker_4.Value.Hour;
                    m4 = dateTimePicker_4.Value.Minute;
                    h5=dateTimePicker_5.Value.Hour;
                    m5 = dateTimePicker_5.Value.Minute;
                    _orari.Add(new TimeSpan(h2, m2, 2));
                    _orari.Add(new TimeSpan(h3, m3, 3));
                    _orari.Add(new TimeSpan(h4, m4, 4));
                    _orari.Add(new TimeSpan(h5, m5, 5));

                    break;
                
            }
            _orari.Sort();
            int f=1;
            foreach (TimeSpan _orario in _orari)
            {
                if (f == 1)
                { te.Pick1 = _orario.ToString(); }
                if (f == 2)
                { te.Pick2 = _orario.ToString(); }
                if (f == 3)
                { te.Pick3 = _orario.ToString(); }
                if (f == 4)
                { te.Pick4 = _orario.ToString(); }
                if (f == 5)
                { te.Pick5 = _orario.ToString(); }
                
                f++;
            
            }
            if (te.Ripeti == "true")
            {
                
            }
            te.UpdateTempo();
            

            creaDalSito(te.Pick1,an.Contatore);

            
        }
        
        private void creaDalSito(string st, int rep)
        {
            te.valoriPrec();
            if (st != "00:00"  && rep<=te.Combo)
            {
                variabile = "primo";
                TimeSpan ts = TimeSpan.Parse(st);
                y = ts.Seconds;
                an.Id = rep;
                an.Righa();

                //modifica github
                string address = "https://www.bakeca.it//inserisci//annuncio//sel_categoria//arredamento-casa-ufficio";
                Uri uri = new Uri(address);
                webBrowser1.Navigate(uri);
            }
            else
            {
                
                if (st == "00:00" && te.Combo>=rep)
                {
                    MessageBox.Show("ERRORE VALORE \"00:00\" NON CORRETTO");
                    this.Close();
                }
                
                    
                    te.create_all();
                    var mess_allCreate = new Messaggio_Ok();
                    mess_allCreate.FormClosing += new FormClosingEventHandler(ChiusuraFormFiglio);

                    mess_allCreate.ShowDialog();
                

               
               
            }
            
            
        }
        private void panelloRisultati()
        {
            panel3.Visible = true;

                
                
                    for (int x = 1; x <= te.Combo; x++)
                    {
                        if (x == 1)
                        {
                            label9.Visible = true;
                            int primo=te.Pick1.LastIndexOf(":");
                            string dat = te.Pick1.Substring(0, primo);
                            label9.Text = dat;
                        }
                        if (x == 2)
                        {
                            label10.Visible = true;
                            int primo = te.Pick2.LastIndexOf(":");
                            string dat = te.Pick2.Substring(0, primo);
                            label10.Text = dat;
                        }
                        if (x == 3)
                        {
                            label11.Visible = true;
                            int primo = te.Pick3.LastIndexOf(":");
                            string dat = te.Pick3.Substring(0, primo);
                            label11.Text = dat;
                        }
                        if (x == 4)
                        {
                            label12.Visible = true;
                            int primo = te.Pick4.LastIndexOf(":");
                            string dat = te.Pick4.Substring(0, primo);
                            label12.Text = dat;
                        }
                        if (x == 5)
                        {
                            label13.Visible = true;
                            int primo = te.Pick5.LastIndexOf(":");
                            string dat = te.Pick5.Substring(0, primo);
                            label13.Text = dat;
                        }
                        if (te.riga_pubblicato(x) == true)
                        {
                            if (te.ControlBann(x) == "1")
                            {
                                if (x == 1)
                                {
                                    label9.Text += "  Non Pubblicato/Bannato";
                                }
                                if (x == 2)
                                {
                                    label10.Text += "  Non Pubblicato/Bannato";                                
                                }
                                if (x == 3)
                                {
                                    label11.Text += "  Non Pubblicato/Bannato";
                                }
                                if (x == 4)
                                {
                                    label12.Text += "  Non Pubblicato/Bannato";
                                }
                                if (x == 5)
                                {
                                    label13.Text += "  Non Pubblicato/Bannato";
                                }
                            }
                            else
                            {
                                if (x == 1)
                                {
                                    label9.Text += "  Pubblicato";
                                }
                                if (x == 2)
                                {
                                    label10.Text += "  Pubblicato";
                                }
                                if (x == 3)
                                {
                                    label11.Text += "  Pubblicato";
                                }
                                if (x == 4)
                                {
                                    label12.Text += "  Pubblicato";
                                }
                                if (x == 5)
                                {
                                    label13.Text += "  Pubblicato";
                                }
                            }
                            
                        }
            }
            if (i == 2)
            {
                if (te.riga_pubblicato(2) == true)
                {

                    if (bannata == true)
                    {
                        
                        label10.Text += " Bannato";
                        bannata = false;
                    }
                    else
                    {
                        label10.Text += " Pubblicato";
                    }
                }
            }
            if (i == 3)
            {
                if (te.riga_pubblicato(3) == true)
                {

                    if (bannata == true)
                    {

                        label11.Text += " Banato";
                        bannata = false;

                    }
                    else
                    {
                        label11.Text += " Pubblicato";
                    }
                }
            }
            if (i == 4)
            {
                if (te.riga_pubblicato(4) == true)
                {

                    if (bannata == true)
                    {

                        label12.Text += " Bannato";
                        bannata = false;

                    }
                    else
                    {
                        label12.Text += " Pubblicato";
                    }
                }
            }
            if (i == 5)
            {
                if (te.riga_pubblicato(5) == true)
                {

                    if (bannata == true)
                    {

                        label13.Text += " Bannato";
                        bannata = false;

                    }
                    else
                    {
                        label13.Text += " Pubblicato";
                    }
                }
            }

        }
        private void ChiusuraFormFiglio(object sender, FormClosingEventArgs e)
        {
            
            
            if (te.control_create_all() == "yes")
            {
                te.valoriPrec();
                
                panel3.Visible = true;
                panelloRisultati();
                if (te.riga_pubblicato(1) == true)
                {
                    for (int j = 2; j <= te.Combo; j++)
                    {
                        if (te.riga_pubblicato(j) == false)
                        {
                            if (j == 2) { i = 2; ParteTimer(); }
                            if (j == 3) { i = 3; ParteTimer(); }
                            if (j == 4) { i = 4; ParteTimer(); }
                            if (j == 5) { i = 5; ParteTimer(); }

                            break;
                        }
                        else
                        {
                            if (j == te.Combo)
                            {
                                
                                te.ControlClearAll();
                                Lastanun();
                                return;
                            }
                        }
                    }
                    
                    if (te.Combo == 1 && i==2)
                    {
                        te.ControlClearAll();
                        Lastanun();
                        return;
                    }
                }
                else
                {
                    i = 1;
                    ParteTimer();
                }
            }

        }
        private void ParteTimer()
        {
            switch (i)
            {
                case 1:
                {
                    TimeSpan tempo1 = TimeSpan.Parse(te.Pick1);
                    int second1 = tempo1.Seconds;
                    an.Id = second1;
                    break;
                }
                case 2:
                {
                    TimeSpan tempo1 = TimeSpan.Parse(te.Pick2);
                    int second1 = tempo1.Seconds;
                    an.Id = second1;
                    break;
                }
                case 3:
                {
                    TimeSpan tempo1 = TimeSpan.Parse(te.Pick3);
                    int second1 = tempo1.Seconds;
                    an.Id = second1;
                    break;
                }
                case 4:
                {
                    TimeSpan tempo1 = TimeSpan.Parse(te.Pick4);
                    int second1 = tempo1.Seconds;
                    an.Id = second1;
                    break;
                }
                case 5:
                {
                    TimeSpan tempo1 = TimeSpan.Parse(te.Pick5);
                    int second1 = tempo1.Seconds;
                    an.Id = second1;
                    break;
                }
            }
            

           

            System.Windows.Forms.Timer Controlx = new System.Windows.Forms.Timer();
            Controlx.Interval = 2 * 60 * 1000;
            Controlx.Start();
            Controlx.Tick += new EventHandler(Intervallo_tempo);
        }
        private void Intervallo_tempo(Object sender, System.EventArgs e)
        {
            TimeSpan tempo1=new TimeSpan(0,0,0);
            if (i == 1)
            {
                tempo1 = TimeSpan.Parse(te.Pick1);
            }
            else
            {
                if (i == 2)
                {
                    tempo1 = TimeSpan.Parse(te.Pick2);
                }
                else
                {
                    if (i == 3)
                    {
                        tempo1 = TimeSpan.Parse(te.Pick3);
                    }
                    else
                    {
                        if (i == 4)
                        {
                            tempo1 = TimeSpan.Parse(te.Pick4);
                        }
                        else
                        {
                            if (i == 5)
                            {
                                tempo1 = TimeSpan.Parse(te.Pick5);
                            }
                            else
                            {
                               
                                    MessageBox.Show("c'e un errore nel programma conttatare l'amnistratore");
                                    this.Close();
                            }
                        }
                    }
                }
            }
            string tempo_temp = System.DateTime.Now.ToString("HH:mm:ss");
            tempo_temp=tempo_temp.Replace('.', ':');
            TimeSpan tempo_ora = TimeSpan.Parse(tempo_temp);
            if(tempo1.TotalMinutes < (tempo_ora.TotalMinutes)+10)
            {
            //if (tempo_ora.CompareTo(tempo1) >= 0)
            //{
               
                System.Windows.Forms.Timer controlx = (System.Windows.Forms.Timer)sender;
                controlx.Stop();
                Mail_publish(i);


            }
               
        }
        private void Mail_publish(int c)
        {
            
            an.Id = c;
            an.Righa();
            

            string mail = an.Email+an.CmbEmail;
            string[] words = mail.Split('@');

            switch(words[1])
            {
                case "libero.it":
                    variabile = "publish1";
                    an.Temp = 0;
                    Uri uri = new Uri("http://easymail.libero.it/logout");
                    webBrowser1.Navigate(uri);
                break;
                    
                case "gmail.com":
                variabile = "gmailx";
                an.Temp = 0;
                webBrowser1.Navigate("https://mail.google.com/mail/u/0/?logout&amp;hl=it");
           
                break;

                case "hotmail.it":
                
                    webBrowser1.Navigate("https://login.live.com");
                    variabile = "hotmail";
                    
                    break;

                case "yahoo.it":
                    variabile = "yahoo";
                    webBrowser1.Navigate("https://login.yahoo.com/config/login_verify2?.intl=it&.src=ym");
                


                
                    break;

                default:
                    MessageBox.Show("la Email del annuncio "+i+" non è valida.\n Modifica e poi riavvia");
                    button9.Visible = true;
                    return;
                    
            }
        }
        private void error_catcha()
        {
            panel2.Visible = true;
            HtmlElementCollection elce = this.webBrowser1.Document.GetElementsByTagName("input");
            foreach (HtmlElement el2 in elce)
            {

                if (el2.GetAttribute("name").Equals("accettopub"))
                {
                    el2.InvokeMember("Click");
                }
            }            
            
            HtmlElementCollection elems = webBrowser1.Document.GetElementsByTagName("input");

            foreach (HtmlElement elem in elems)
            {
                string name = elem.GetAttribute("type");
                
                string name2 = elem.GetAttribute("name");

                if (name.Equals("hidden") && name2.Equals("kchallenge"))
                {
                    
                    string code = elem.GetAttribute("value");
                    //modifica github
                    Uri uri2 = new Uri("http://"+an.Citta.ToLower()+".bakeca.com/be/main.php?page=challenge_img&k=" + code);
                    webBrowser2.Navigate(uri2);
                }

            }
            
        }
        
        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            switch (variabile)
            { 
                
                case "primo":
                {
                    if (webBrowser1.ReadyState != WebBrowserReadyState.Complete)
                        return;
                    try
                    {


                        //an.Id = y;
                        an.Righa();
                        webBrowser1.Document.GetElementById("tit").SetAttribute("value", an.Titolo);
                        webBrowser1.Document.GetElementById("testoann").SetAttribute("value", an.Testo);
                        webBrowser1.Document.GetElementById("indirizzopub").SetAttribute("value", an.Indirizzo);
                        webBrowser1.Document.GetElementById("localitapub").SetAttribute("value", an.Zona);

                        
                        string cat = an.Categoria.ToLower().Replace(" ","");
                        //modifica github
                        if (cat == "casa")
                        {
                            cat= "31";
                        }
                        if (cat == "arredo")
                        {
                            cat = "30";
                        }
                        if (cat == "auto")
                        {
                            cat = "32";
                        }
                        if (cat == "lavoro")
                        {
                            cat = "29";
                        }
                        webBrowser1.Document.GetElementById("categoriapub").SetAttribute("value", cat);
                        
                        

                        HtmlElementCollection elems = webBrowser1.Document.GetElementsByTagName("input");

                        foreach (HtmlElement elem in elems)
                        {
                            string name = elem.GetAttribute("name");
                            
                            if (name.Equals("eta"))
                            {
                                elem.SetAttribute("value", an.Eta);
                            }
                            if (name.Equals("contatto"))
                            {
                                elem.SetAttribute("value", an.Telefono);
                            }
                            if (name != null && name.Length != 0 && name.Equals("email"))
                            {
                                
                                elem.SetAttribute("value", an.Email+an.CmbEmail);

                            }
                        }

                        

                        variabile = "secondo";
                        AllegaFoto();

                        
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Devi lasciar caricare la pagina", "troppo lento :(");
                    }


                    
                    break;
                }
                case "secondo":
                {
                    if (webBrowser1.ReadyState != WebBrowserReadyState.Complete)
                        return;
                    
                    AllegaFoto();
                    break;
                }
         
                case "terzo":
                {
                    if (webBrowser1.ReadyState != WebBrowserReadyState.Complete)
                        return;
                    try
                    {
                        panel2.Visible = true;
                        HtmlElementCollection elce = this.webBrowser1.Document.GetElementsByTagName("input");
                        foreach (HtmlElement el2 in elce)
                        {

                            if (el2.GetAttribute("name").Equals("accettopub"))
                            {
                                el2.InvokeMember("Click");
                                break;
                            }
                        }

                        HtmlElementCollection elems = webBrowser1.Document.GetElementsByTagName("input");

                        foreach (HtmlElement elem in elems)
                        {
                            string name = elem.GetAttribute("type");
                           
                            string name2 = elem.GetAttribute("name");

                            if (name.Equals("hidden") && name2.Equals("kchallenge"))
                            {
                                

                                string code = elem.GetAttribute("value");
                                //modifica github
                                string address = "http://"+an.Citta.ToLower()+".bakeca.com/be/main.php?page=challenge_img&k=" + code;
                                Uri uri2 = new Uri(address);
                                webBrowser2.Navigate(uri2);
                                break;
                            }

                        }
                        variabile = "quarto";
                        
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Devi lasciar caricare la pagina", "troppo lento :(");
                        
                    }
                    break;
                }
                case "quinto":
                {
                    try
                    {
                        string url = "";
                        if (webBrowser1.Url != null)
                        {
                            url = webBrowser1.Url.AbsoluteUri;
                            if (te.Ripeti == url)
                            {
                                lb_codeError.Text += "\n oppure corregge i campi in rosso";
                                lb_codeError.Visible = true;
                                error_catcha();
                            }
                            else
                            {
                                panel2.Visible = false;
                                webBrowser1.Navigate(url);
                                variabile = "sesto";

                            }
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Devi lasciar caricare la pagina", "troppo lento :(");
                    }
                    break;
                }
                
                case "sesto":
                {

                    if (webBrowser1.ReadyState != WebBrowserReadyState.Complete)
                        return;


                    if (webBrowser1.Url != null)
                    {
                        string urlx = webBrowser1.Url.AbsoluteUri;
                        an.Web_address = urlx;

                    }
                    else
                    {
                        MessageBox.Show("ERRORE CARICAMENTO");
                        this.Close();

                    }
                    an.saveurl();
                    an.refreshStatus();
                    variabile = "settimo";
                    webBrowser1.Navigate(an.Web_address);
                    
                    break;
                }
                case "settimo":
                {
                    an.Contatore++;
                    i = 0;
                    if (an.Id == 1)
                    {
                        creaDalSito(te.Pick2, 2);
                        break;
                    }
                    if (an.Id == 2)
                    {
                        creaDalSito(te.Pick3, 3);
                        break;
                    }
                    if (an.Id == 3)
                    {
                        creaDalSito(te.Pick4, 4);
                        break;
                    }
                    if (an.Id == 4)
                    {
                        creaDalSito(te.Pick5, 5);
                        break;
                    }
                    if (an.Id == 5)
                    {
                        creaDalSito("00:00", 6);
                        break;
                    }
                    
                    variabile = "primo";
                    break;
                }
                    case"publish1":
                    if (webBrowser1.ReadyState != WebBrowserReadyState.Complete)
                        return;
                    webBrowser1.Navigate("http://easy.libero.it/pre_mail.php");
                    variabile = "publish2";

                    break;
                

                case"publish2":
                {
                    if (webBrowser1.ReadyState != WebBrowserReadyState.Complete)
                        return;
                    
                    string Login = an.Email+an.CmbEmail;
                    string Pass = an.Password;
                    var element = webBrowser1.Document.GetElementById("query");
                    if (element != null)
                        element.InnerText = Login;

                    var pas_elem = webBrowser1.Document.GetElementById("mailpassword");

                    if (pas_elem != null)
                        pas_elem.InnerText = Pass;


                    HtmlElementCollection elems = this.webBrowser1.Document.GetElementsByTagName("input");
                    foreach (HtmlElement he in elems)
                    {
                        if (he.GetAttribute("type").Equals("submit"))
                        {
                            he.InvokeMember("click");
                            break;
                        }
                    }
                    variabile = "publish_libero";
                    break;
                }
                case "publish_libero":
                {
                    if (webBrowser1.ReadyState != WebBrowserReadyState.Complete)
                        return;
                    bool accesso = false;
                    HtmlElementCollection vemailLibero = webBrowser1.Document.GetElementsByTagName("input");
                    foreach (HtmlElement he in vemailLibero)
                    {
                        if (he.GetAttribute("type").Equals("submit") && he.GetAttribute("value").Equals("OK"))
                        {
                            accesso = true;
                            break;
                        }
                    }

                    if (accesso == true)
                    {
                        if (MessageBox.Show("La tua Password o Email sono sbagliate, modificali e poi riavvia") == DialogResult.OK)
                        {
                            button9.Visible = true;
                            variabile = "";
                        }
                        return;
                    }
                    else
                    {

                        Uri url = new Uri("http://easymail.libero.it/posta-arrivata");
                        webBrowser1.Navigate(url);
                        variabile = "del_lastemails";
                        break;
                    }
                }
                case "del_lastemails":
                if (webBrowser1.ReadyState != WebBrowserReadyState.Complete)
                    return;

                string sourced = webBrowser1.DocumentText;
                string datad=string.Empty;
                if (an.Temp == 1 || an.Temp==10)
                {
                    datad = DateTime.Now.ToString("dd/MM/yyyy");
                }
                else
                {
                    datad = DateTime.Now.AddDays(-1).ToString("dd/MM/yyyy");
                }                    
                int countd = Regex.Matches(sourced, datad).Count;

                //int totaled = sourced.Length;

                //int startd = sourced.IndexOf(datad) - 420;
                if (countd == 0 && an.Temp==1)
                {
                    //a pposto nessuna mail di bakeca inconttri
                    //o controllo un giorno precedente oppure creoil anuncio
                    webBrowser1.Navigate(an.Web_address);
                    //attende();
                    variabile = "click_link";
                }
                else
                {
                    //questa condizione è riservata al ultimo annuncio
                    if(countd==0 && an.Temp==10)
                    {
                        MessageBox.Show("L'email del ultimo annuncio non ricevuta o eliminata");
                        return;
                    }
                    int stop = sourced.LastIndexOf(datad);
                    if (stop < 0)
                    {
                        an.Temp = 1;
                        Uri url = new Uri("http://easymail.libero.it/posta-arrivata");
                        webBrowser1.Navigate(url);
                        break;
                    }
                    int start = sourced.IndexOf(datad) - 425;
                    int totale = sourced.Length;

                    int temp = totale - start;
                    temp = temp - stop;

                    string dati = sourced.Substring(start, stop - start).Trim();

                        //modifica github
                    int countBakeca = Regex.Matches(dati, "@bakeca.com").Count;
                    if (countBakeca == 0 && an.Temp==1)
                    {
                        
                        var Mo = new Messaggio_Ok();
                        Mo.Messaggio = "Probabilmente l'annuncio l'hai gia pubblicato oppure la tua email è stata bannata!";
                        Mo.Mess_diverso();
                        te.updatePublish(i);
                        i++;
                        bannata = true;
                        Mo.ShowDialog();

                    }
                    else
                    {
                        
                        if (countBakeca == 0 && an.Temp == 0)
                        {
                            an.Temp = 1;
                            Uri url = new Uri("http://easymail.libero.it/posta-arrivata");
                            webBrowser1.Navigate(url);
                            break;
                        }
                        try
                        {
                            string dati_without_space = dati.Replace("\t", string.Empty).Replace("\r", string.Empty).Replace("\n", string.Empty);
                            //dati_without_space = dati_without_space.Replace(" ", string.Empty);
                            int stopBakeca = dati_without_space.LastIndexOf("@bakeca.com");

                            string linkBakeca = dati_without_space.Substring(0, stopBakeca);
                            int aperBakeca = linkBakeca.IndexOf("<a href=") + 10;
                            int chiuBakeca = linkBakeca.LastIndexOf("\">");

                            string link = linkBakeca.Substring(aperBakeca, chiuBakeca - aperBakeca).Trim();

                            string urlpage = "http://easymail.libero.it/" + link;
                            variabile = "eliminato";
                            webBrowser1.Navigate(urlpage);
                        }
                        catch
                        {
                            te.updatePublish(i);
                            te.updatePublishBann(i);
                            i++;
                            Thread.Sleep(2000);
                            var me = new Messaggio_Ok();
                            me.Messaggio = "Il tuo1 annuncio " + (i - 1) + " è stato cancellato dal sito.";
                            me.Mess_diverso();
                            bannata = true;
                            variabile = "";

                            me.FormClosing += new FormClosingEventHandler(ChiusuraFormFiglio);
                            me.ShowDialog();
                        }
                    }
                }

                break;
                case "eliminato":
                if (webBrowser1.ReadyState != WebBrowserReadyState.Complete)
                    return;

                Thread.Sleep(1000);


                an.Emailscelta = webBrowser1.Url.AbsoluteUri;
                string emailTextl = webBrowser1.DocumentText;
                int totalcharacter = 0;
                totalcharacter = Convert.ToInt32(emailTextl.Length);
                //emailTextl = emailTextl.Replace("\r", string.Empty).Replace("\n", string.Empty).Replace("&amp;","&");
                emailTextl = emailTextl.Replace("&amp;", "&");
                //int totalcharacter = emailTextl.Length;
                int startxl = emailTextl.IndexOf(".bakeca.com/be/main.php?page=manage_post&idp=");
                int begin = emailTextl.LastIndexOf("<a href=", startxl);

                int finishxl = emailTextl.IndexOf("\" target", begin);
                string link_l = emailTextl.Substring(begin+9, finishxl-begin-9);
                variabile = "del_annuncio";
                webBrowser1.Navigate(link_l);
                //webBrowser1.Refresh();

                break;
                case "del_annuncio":

                if (webBrowser1.ReadyState != WebBrowserReadyState.Complete)
                    return;
                Thread.Sleep(1000);
                  
                bool page = false;
                string nuovourl=webBrowser1.Url.AbsoluteUri;
                int metalink=nuovourl.IndexOf("/be");
                nuovourl = nuovourl.Substring(0, metalink);
                HtmlElementCollection elems_del = this.webBrowser1.Document.GetElementsByTagName("input");
                foreach (HtmlElement he_del in elems_del)
                {
                    if (he_del.GetAttribute("type").Equals("button") && he_del.GetAttribute("name").Equals("delpost"))
                    {
                        page = true;

                        variabile = "email_posta_letta";
                        //inkerclick non serve per che appare subito dopo un messagebox da confermare la scelta
                        
                        
                        int iStartPos = he_del.OuterHtml.IndexOf("onclick=\"confirmAndGo('") + ("onClick=\"confirmAndGo('").Length;
                        int iEndPos = he_del.OuterHtml.IndexOf("')",iStartPos);
                        //he_del.InvokeMember("Click");
                        string secondameta=he_del.OuterHtml.Substring(iStartPos,iEndPos-iStartPos);
                        string totallink = nuovourl + secondameta;
                        totallink = totallink.Replace("&amp;", "&");
                        
                        webBrowser1.Navigate(totallink);
                        break;
                   
                        
                    }
                }
                if (page == false)
                {
                    
                    
                    Messaggio_Ok cancell = new Messaggio_Ok();
                    cancell.Messaggio="Il tuo2 annuncio è stato cancellato";
                    cancell.Mess_diverso();
                    cancell.ShowDialog();
                    variabile = "cancel_email";
                    //webBrowser1.Refresh();

                    webBrowser1.GoBack();
                }
                break;

                case "email_posta_letta":
                if (webBrowser1.ReadyState != WebBrowserReadyState.Complete)
                    return;
                Thread.Sleep(1000);
                   
                variabile = "cancel_email";
                webBrowser1.Navigate(an.Emailscelta);

                break;

                case "cancel_email":
                if (webBrowser1.ReadyState != WebBrowserReadyState.Complete)
                    return;
                Thread.Sleep(1000);

                string urlxd = webBrowser1.Url.AbsoluteUri;
                if (urlxd.Contains("libero.it"))
                {

                    HtmlElementCollection elems_c = this.webBrowser1.Document.GetElementsByTagName("input");
                    foreach (HtmlElement he_l in elems_c)
                    {
                        if (he_l.GetAttribute("type").Equals("submit") && he_l.GetAttribute("value").Equals("Cancella"))
                        {
                            variabile = "posta_arrivata";
                            he_l.InvokeMember("click");
                            break;
                        }
                    }
                }
                if (urlxd.Contains("mail.google"))
                {

                    string scritto=webBrowser1.DocumentText;
                    
                    
                    
                    variabile = "cancelemail2";
                    if (an.Temp == 10)
                    {
                        variabile = "messaggioFinale";

                    }
                    int finald = scritto.LastIndexOf("\">Elimina</a>");
                    int initiald = scritto.LastIndexOf("href=\"", finald) + "href=\"".Length;
                    string linkgy = scritto.Substring(initiald, finald - initiald);
                    webBrowser1.Navigate("https://mail.google.com/mail/u/0/h/4z1p6b35uhcr/"+linkgy);
                }
                break;
                case "messaggioFinale":
                MessageBox.Show("L'ultima email del annuncio è stato cancellato");
                return;
                case "posta_arrivata":
                if (webBrowser1.ReadyState != WebBrowserReadyState.Complete)
                    return;
                if (an.Temp == 10)
                {
                    MessageBox.Show("L'ultimo annuncio è stato eliminato :)");
                    return;
                }
                Uri urln = new Uri("http://easymail.libero.it/posta-arrivata");
                webBrowser1.Navigate(urln);
                variabile = "del_lastemails";
                       
                break;
                case "click_link":
                if (webBrowser1.ReadyState != WebBrowserReadyState.Complete)
                    return;

                HtmlElementCollection elems_l = this.webBrowser1.Document.GetElementsByTagName("input");
                foreach (HtmlElement he_l in elems_l)
                {
                    if (he_l.GetAttribute("type").Equals("button") && he_l.GetAttribute("name").Equals("sendpost"))
                    {
                        variabile = "clikato";
                        he_l.InvokeMember("click");
                        break;
                    }
                }
                if (variabile != "clikato")
                {
                    variabile = "clikato";
                    if (an.CmbEmail == "@gmail.com")
                    {
                        webBrowser1.Navigate("https://mail.google.com/mail/u/0/h/u/0/?hl=it#inbox");
                    }
                    if (an.CmbEmail == "@libero.it")
                    {
                        webBrowser1.Navigate("http://easymail.libero.it/posta-arrivata");

                    }
                        break;
                }
                break;

                case "clikato":
                if (webBrowser1.ReadyState != WebBrowserReadyState.Complete)
                    return;

                if (an.Temp == 10)
                {
                    variabile = "";
                    MessageBox.Show("Tutti gli annunci d'oggi sono stati pubblicati e poi cancellati");
                    break;
                }
                variabile = "";
                attende();

                break;
                case "publish_libero1":
                {


                    if (webBrowser1.ReadyState != WebBrowserReadyState.Complete)
                        return;

                    string source = webBrowser1.DocumentText;

                    string data = DateTime.Now.ToString("dd/MM/yyyy");


                    int count = Regex.Matches(source, data).Count;

                    int totale = source.Length;

                    int start = source.IndexOf(data) - 420;
                    if (start < 0)
                    {

                        Messaggio_Ok me = new Messaggio_Ok();
                        me.Messaggio = "Non hai ricevuto l'email per l'annuncio " + i + ".";
                        me.Mess_diverso();
                        bannata = true;
                        variabile = "";
                        te.updatePublishBann(i);
                        i++;
                        me.FormClosing += new FormClosingEventHandler(ChiusuraFormFiglio);
                        me.ShowDialog();

                        break;
                    }
                    else
                    {

                        int stop = source.LastIndexOf(data);

                        int temp = totale - start;
                        temp = temp - stop;

                        string dati = source.Substring(start, stop - start).Trim();


                        int countBakeca = Regex.Matches(dati, "support@bakeca.com").Count;
                        if (countBakeca == 0)
                        {
                            var Mo = new Messaggio_Ok();
                            Mo.Messaggio = "Probabilmente l'annuncio l'hai gia pubblicato oppure la tua email è stata bannata!";
                            Mo.Mess_diverso();
                            te.updatePublish(i);
                            i++;
                            bannata = true;
                            Mo.ShowDialog();

                        }
                        else
                        {
                            try
                            {
                                string dati_without_space = dati.Replace("\t", string.Empty).Replace("\r", string.Empty).Replace("\n", string.Empty);
                                dati_without_space = dati_without_space.Replace(" ", string.Empty);
                                int stopBakeca = dati_without_space.LastIndexOf("<b>support@bakeca.com");

                                string linkBakeca = dati_without_space.Substring(stopBakeca - 43, 43);
                                int aperBakeca = linkBakeca.IndexOf("<a href=") + 24;
                                int chiuBakeca = linkBakeca.LastIndexOf(">") - 1;

                                string link = linkBakeca.Substring(aperBakeca, chiuBakeca - aperBakeca).Trim();

                                string urlpage = "http://easymail.libero.it/" + link;
                                variabile = "finito";
                                webBrowser1.Navigate(urlpage);
                            }
                            catch
                            {
                                te.updatePublish(i);
                                te.updatePublishBann(i);
                                i++;
                                Thread.Sleep(2000);
                                var me = new Messaggio_Ok();
                                me.Messaggio = "Il tuo3 annuncio " + (i - 1) + " è stato cancellato dal sito.";
                                me.Mess_diverso();
                                bannata = true;
                                variabile = "";

                                me.FormClosing += new FormClosingEventHandler(ChiusuraFormFiglio);
                                me.ShowDialog();
                            }


                        }
                    }
                    break;

                }


                case "finito":
                {
                    if (webBrowser1.ReadyState != WebBrowserReadyState.Complete)
                        return;
                    
                    string bb = webBrowser1.DocumentText;
                    HtmlElementCollection elems = this.webBrowser1.Document.GetElementsByTagName("a");
                    int x = 0;
                   
                    foreach (HtmlElement he in elems)
                    {
                        if (he.InnerText=="PUBBLICA ANNUNCIO")
                        {
                            he.InvokeMember("click");
                            x=1;
                            te.updatePublish(i);
                            variabile = "";
                            i++;
                            Thread.Sleep(2000);

                            var messf = new Messaggio_Ok();
                            messf.Messaggio = "Annuncio " + (i-1) + " pubblicato!!";
                            messf.Mess_diverso();
                            messf.FormClosing += new FormClosingEventHandler(ChiusuraFormFiglio);
                            messf.ShowDialog();

                            
                            break;
                        }
                    }
                    if (x == 0)
                    {
                        Messaggio_Ok me = new Messaggio_Ok();
                        me.Messaggio = "Il tuo4 annuncio " + i + " è stato cancellato dal sito.";
                        me.Mess_diverso();
                        bannata = true;
                        variabile = "";
                        te.updatePublishBann(i);
                        i++;
                        me.FormClosing += new FormClosingEventHandler(ChiusuraFormFiglio);
                        me.ShowDialog();
                    }
                    break;
                }
                case "hotmail":
                {
                    variabile = "hotmailx";
                    break;
                }
                case "hotmailx":
                {
                    
                    try
                    {
                        string Login2 = an.Email+an.CmbEmail;
                        string Pass2 = an.Password;
                        var element2 = webBrowser1.Document.GetElementById("i0116");
                        if (element2 != null)
                            element2.InnerText = Login2;

                        var pas_elem2 = webBrowser1.Document.GetElementById("i0118");

                        if (pas_elem2 != null)
                            pas_elem2.InnerText = Pass2;


                        //webBrowser1.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(webBrowser1_DocumentCompleted);
                        HtmlElement but_elem = webBrowser1.Document.GetElementById("idSIButton9");
                        but_elem.Focus();
                        but_elem.InvokeMember("click");
                        variabile = "hotmail2";
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Devi lasciar caricare la pagina", "troppo lento :(");
                    }
                    break;
                }

                case "hotmail2":
                {
                    variabile = "hotmail3";
                    break;
                }
                case "hotmail3":
                    {

                   
                    try
                    {
                        
                        webBrowser1.Navigate("https://dub116.mail.live.com/default.aspx");
                        webBrowser1.DocumentCompleted -=webBrowser1_DocumentCompleted;

                        webBrowser1.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(webBrowser1_DocumentCompleted);

                        variabile = "hotmail4";
                        break;
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Devi lasciar caricare la pagina", "troppo lento :(");
                    }

                    break;

                }
                case "hotmail4":
                    string url2 = "";
                    if (webBrowser1.Url != null)
                    {
                        url2 = webBrowser1.Url.AbsoluteUri;
                    }
                    webBrowser1.Navigate(url2);
                    webBrowser1.DocumentCompleted -= webBrowser1_DocumentCompleted;

                    webBrowser1.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(webBrowser1_DocumentCompleted);

                    variabile = "hotmail5";
                    
                    break;
                case "hotmail5":
                    string sourceh = webBrowser1.DocumentText;

                    string datah = DateTime.Now.ToString("yyyy-MM-dd");
                    int lastDatah = sourceh.LastIndexOf(datah)+500; //la prima mail del giorno di oggi
                    int datanowh = sourceh.IndexOf("mdt=\"" + datah);
                    string datih = sourceh.Substring(datanowh, lastDatah - datanowh).Trim();
                    break;

                case "yahoo":
                    string Login_y = an.Email+an.CmbEmail;
                    string Pass_y = an.Password;
                    var element_y = webBrowser1.Document.GetElementById("username");
                    if (element_y != null)
                        element_y.InnerText = Login_y;

                    var pas_elem_y = webBrowser1.Document.GetElementById("passwd");

                    if (pas_elem_y != null)
                        pas_elem_y.InnerText = Pass_y;
                    webBrowser1.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(webBrowser1_DocumentCompleted);

                    HtmlElement btn_elem_y = webBrowser1.Document.GetElementById(".save");
                    btn_elem_y.InvokeMember("click");

                    variabile = "yahoo2";
                    
                   
                    break;

                case"yahoo2":
                    string source_y = webBrowser1.DocumentText;
                    try
                    {
                        string data_y = DateTime.Now.ToString("yyyyMMdd");
                        int stop_y = source_y.LastIndexOf(data_y);
                        string mailday = source_y.Substring(10, stop_y);
                        int stop2_y = mailday.LastIndexOf("PUBBLICA ANNUNCIO");
                        string codice = mailday.Substring(stop2_y - 142, 142);
                        //cerco di capire se la email non è stata visualizata
                        string visitato = source_y.Substring(stop2_y,1000);

                        int start2 = codice.IndexOf("idp=") + 4;
                        int stop2 = codice.LastIndexOf("\" class") - 1;
                        string codicefinale = codice.Substring(start2, stop2 - start2);
                        webBrowser1.Navigate("http://torino.bakeca.com/be/main.php?page=publishnow&idp=" + codicefinale);
                    }
                    catch (Exception)
                    {
                        var mes=new Messaggio_Ok();
                        mes.Messaggio = "Non hai ricevuto l'email per l'annuncio " + i + ".";
                       
                    }
                    break;
                
                case "gmailx":
                    if (webBrowser1.ReadyState != WebBrowserReadyState.Complete)
                        return;
                    Uri url_gx = new Uri("http://mail.google.com/mail/u ");
                    webBrowser1.Navigate(url_gx);
                    variabile = "gmail";
                    break;
                    
                case "gmail":


                    if (webBrowser1.ReadyState != WebBrowserReadyState.Complete)
                        return;
                    

                    string Login_g = an.Email+an.CmbEmail;
                    string Pass_g = an.Password;
                    var element_g = webBrowser1.Document.GetElementById("Email");
                    if (element_g != null)
                        element_g.InnerText = Login_g;

                    var pas_elem_g = webBrowser1.Document.GetElementById("Passwd");

                    if (pas_elem_g != null)
                        pas_elem_g.InnerText = Pass_g;
                   

                    HtmlElementCollection elems_g = this.webBrowser1.Document.GetElementsByTagName("input");
                    foreach (HtmlElement he_g in elems_g)
                    {
                        if (he_g.GetAttribute("type").Equals("submit")&& he_g.GetAttribute("id").Equals("signIn"))
                        {
                            he_g.InvokeMember("click");
                            break;
                        }
                    }

                    variabile = "gmail2";
                    break;
               
                case "gmail2":
                    {
                        if (webBrowser1.ReadyState != WebBrowserReadyState.Complete)
                        {return;}
                        var vemail=webBrowser1.Document.GetElementById("Email");
                        if (vemail != null)
                        {
                            if (MessageBox.Show("La tua Password o Email sono sbagliate, modificali e poi riavvia") == DialogResult.OK)
                            {
                                button9.Visible = true;
                            }
                            return;
                        }
                        else
                        {
                            //Uri url_g = new Uri("https://mail.google.com/mail/u/0/?ui=2&shva=1#inbox");
                            Uri url_g = new Uri("https://mail.google.com/mail/u/0/h/1bedkdkmvw6qg/?f=1");
                            webBrowser1.Navigate(url_g);
                            variabile = "controldel";
                            //variabile = "gmail3";
                        }
                        break;
                    }
                case "controldel":
                    if (webBrowser1.ReadyState != WebBrowserReadyState.Complete)
                        return;

                    string emailText2x = webBrowser1.DocumentText;

                    string source_g = webBrowser1.DocumentText;
                    source_g = source_g.Replace("&nbsp;", " ").Replace("&amp;", "&").Replace("&quot;","\"");
                    string data_day;
                    string data_month;
                    string data_year;

                    if (an.Temp == 1 || an.Temp==10)
                    {
                        data_day = DateTime.Now.ToString("dd");
                        data_month = DateTime.Now.ToString("MM");
                        

                        Regex rgx2 = new Regex(@"\d{2}:\d{2}");
                        int conta2 = 0;
                        int primoTime=0;
                        int lastTime=0;
                        string lastValTime="";
                        int count_g2xr = rgx2.Matches(source_g).Count;
                        if(count_g2xr<=0)
                        {
                            variabile = "click_link";

                            webBrowser1.Navigate(an.Web_address);
                            break;
                        }

                        foreach (Match match in rgx2.Matches(source_g))
                        {
                            if (conta2 == 0)
                            {
                                primoTime = match.Index;
                            }
                            lastTime = match.Index;
                            lastValTime=match.Value.ToString();
                            conta2++;
                        }
                        if (conta2 > 0)
                        {
                            string tempSource = source_g;
                            int primog = tempSource.LastIndexOf("<tr", primoTime);
                            primoTime = primog;
                            tempSource = source_g.Substring(primoTime, lastTime - primoTime);
                            int count_bakeca2 = Regex.Matches(tempSource, "Bakeca.com ").Count;
                            if (count_bakeca2 > 0)
                            {

                                int valore3=tempSource.LastIndexOf("Bakeca.com ");
                                int valore1 = tempSource.LastIndexOf("<a href=\"", valore3)+9;
                                int valore2 = tempSource.IndexOf("\">", valore1);
                                string Linkcon = tempSource.Substring(valore1, valore2 - valore1);
                                variabile = "cancelemail2";
                                webBrowser1.Navigate("https://mail.google.com/mail/u/0/h/58vzcroeppea/" + Linkcon);
                                break;
                            }
                            else
                            {
                                if (an.Temp == 10)
                                {
                                    MessageBox.Show("L'email del ultimo annuncio è stato cancellata");
                                    return;
                                }
                                webBrowser1.Navigate(an.Web_address);
                                variabile = "click_link";
                                break;
                            }


                        }
                        else
                        {
                            webBrowser1.Navigate(an.Web_address);                          
                            variabile = "click_link";
                            break;
                        }
                    }
                    else
                    {
                        data_day = DateTime.Now.AddDays(-1).ToString("dd");
                        data_month = DateTime.Now.AddDays(-1).ToString("MM");
                        data_year = DateTime.Now.AddDays(-1).ToString("yyyy");
                    }
                    //cambio il mese per la abreviazione per il mese 
                    //string mese = cercamese(data_month);

                    data_month=abrev_mese(data_month);
                    data_day=abrev_giorno(data_day);

                    //string data_g = data_day + " " + mese + " " + data_year;
                    string data_g = data_day + " " + data_month;
                    int beginy;
                    int beginx;
                    try
                    {
                        beginy = source_g.IndexOf(data_g);
                        beginx = source_g.LastIndexOf("<tr", beginy);
                        beginy = beginx;
                    }
                    catch
                    {
                        an.Temp = 1;
                        //Uri url_g = new Uri("https://mail.google.com/mail/u/0/?ui=2&shva=1#inbox");
                        Uri url_g = new Uri("https://mail.google.com/mail/u/0/h/1bedkdkmvw6qg/?f=1");
                        webBrowser1.Navigate(url_g);
                        break;
                    }
                        int lasty = source_g.LastIndexOf(data_g);
                        string dat = source_g.Substring(beginy, lasty - beginy);
                        
                        string emailbak;
                        int count_bakeca = Regex.Matches(dat, "Bakeca.com ").Count;
                        if (count_bakeca <= 0)
                        {
                            an.Temp = 1;
                            //Uri url_g = new Uri("https://mail.google.com/mail/u/0/?ui=2&shva=1#inbox");
                            Uri url_g = new Uri("https://mail.google.com/mail/u/0/h/1bedkdkmvw6qg/?f=1");

                            webBrowser1.Navigate(url_g);
                            break;

                        }
                        else
                        {
                            int uno = dat.LastIndexOf("Bakeca.com ");
                            int primario = dat.LastIndexOf("<a href=\"", uno) + 9;
                            int termine = dat.IndexOf("\">", primario);
                            emailbak = dat.Substring(primario, termine - primario);
                            

                        }

                    
                    
                    
                    
                    Uri url_gc = new Uri("https://mail.google.com/mail/u/0/h/58vzcroeppea/" + emailbak);
                            variabile = "cancelemail2";
                            webBrowser1.Navigate(url_gc);
                            break;
                   
                case "cancelemail2":
                    if (webBrowser1.ReadyState != WebBrowserReadyState.Complete)
                        return;
                    Thread.Sleep(1000);
                    string emailTextgma = webBrowser1.DocumentText;

                    emailTextgma=emailTextgma.Replace("<WBR>",string.Empty).Replace("&amp;","&");
                    emailTextgma = emailTextgma.Replace("\r", string.Empty).Replace("\n",string.Empty);
                    
                    int startxd=emailTextgma.LastIndexOf(".bakeca.com/be/main.php?page=manage_post&idp=");

                    an.Emailscelta = webBrowser1.Url.AbsoluteUri.ToString();
                    int count_g2b = Regex.Matches(emailTextgma, ".bakeca.com/be/main.php?page=manage_post&idp=").Count;                        

                    if (startxd <= 0)
                    {
                        
                            variabile="controldel";
                            //webBrowser1.Navigate("https://mail.google.com/mail/u/0/?ui=2&shva=1#inbox");
                            webBrowser1.Navigate("https://mail.google.com/mail/u/0/h/1qmh474bcoae8/?f=1");
                            break;
                        
                    }

                    int iniz = emailTextgma.LastIndexOf(">", startxd)+">".Length;
                    int fini = emailTextgma.IndexOf("<", startxd);
                    string linka = emailTextgma.Substring(iniz,fini-iniz);
                    variabile = "del_annuncio";
                    webBrowser1.Navigate(linka);

                    //elimina email bakeca poi guarda se ci sono altre nella stessa email

                    break;
                    
                case "gmail3":
                    if (webBrowser1.ReadyState != WebBrowserReadyState.Complete)
                        return;


                        data_day = DateTime.Now.ToString("dd");
                        data_month = DateTime.Now.ToString("MM");
                        data_month=abrev_mese(data_month);
                        data_day=abrev_giorno(data_day);

                        Regex data_g2ex = new Regex(@"\d{2}:\d{2}");

                    string emailText2x2 = webBrowser1.DocumentText;

                    string source_g2 = webBrowser1.DocumentText;
                    source_g2 = source_g2.Replace("&nbsp;", " ").Replace("&amp;", "&").Replace("&quot;","\"");
                   
                    int count_g2 = data_g2ex.Matches(source_g2).Count;
                    if (count_g2 <= 0)
                    {
                        variabile = "";
                        messError();

                        break;
                    }
                    else
                    {
                        int conta2 = 0;
                        int primoTime;
                        int lastTime = 0;
                        string lastValTime = string.Empty;

                        foreach (Match match in data_g2ex.Matches(source_g2))
                        {
                            if (conta2 == 0)
                            {
                                primoTime = match.Index;
                            }
                            lastTime = match.Index;
                            lastValTime = match.Value.ToString();
                            conta2++;
                        }
                        string data_g2 = lastValTime;

                        int stop = source_g2.LastIndexOf(data_g2);
                        string totbak = source_g2.Substring(0, stop);

                        int indexlink = totbak.LastIndexOf("<a href=\"", lastTime)+9;
                        int indexfinelink = totbak.IndexOf("\">", indexlink);

                        string linkintegro = totbak.Substring(indexlink, indexfinelink - indexlink);

                        variabile = "gmail4";
                        Uri urlx = new Uri("https://mail.google.com/mail/u/0/h/58vzcroeppea/" + linkintegro);
                        an.Emailscelta = "";
                        webBrowser1.Navigate(urlx);
                        break;
                    } 
             
                    case "gmail4":

                    if (webBrowser1.ReadyState != WebBrowserReadyState.Complete)
                        return;
                    
                        
                    


                    string emailText=webBrowser1.DocumentText;
                    emailText=emailText.Replace("<WBR>",string.Empty).Replace("&amp;","&");
                    emailText = emailText.Replace("\r", string.Empty).Replace("\n",string.Empty);


                    variabile = "gmail6";
                    //rifatto
                    int startx = emailText.IndexOf(".bakeca.com/be/main.php?page=manage_post&idp=");



                   int iniziohx = emailText.LastIndexOf("target=\"_blank\">", startx) + "target=\"_blank\">".Length;
                   int finishx = emailText.IndexOf("</a>", startx);
                   string annuncio = emailText.Substring(iniziohx, finishx - iniziohx);
                   webBrowser1.Navigate(annuncio);
                   
                    break;

                case "gmail6":


                    string totsource = webBrowser1.DocumentText;
                    HtmlElementCollection elemsg = this.webBrowser1.Document.GetElementsByTagName("input");
                    int xg = 0;
                    
                    foreach (HtmlElement he in elemsg)
                    {

                        if (he.GetAttribute("name").Equals("unpublish") && he.GetAttribute("type").Equals("button"))
                        {
                            he.InvokeMember("click");
                            xg=1;
                            te.updatePublish(i);
                            variabile = "";
                            i++;
                            Thread.Sleep(2000);

                            var messf = new Messaggio_Ok();
                            messf.Messaggio = "Annuncio " + (i-1) + " pubblicato!!";
                            messf.Mess_diverso();
                            messf.FormClosing += new FormClosingEventHandler(ChiusuraFormFiglio);
                            messf.ShowDialog();

                            
                            break;
                        }
                    }
                    if (xg == 0)
                    {
                        Messaggio_Ok me = new Messaggio_Ok();
                        me.Messaggio = "Il tuo5 annuncio " + i + " è stato cancellato dal sito.";
                        me.Mess_diverso();
                        bannata = true;
                        variabile = "";
                        te.updatePublishBann(i);
                        i++;
                        me.FormClosing += new FormClosingEventHandler(ChiusuraFormFiglio);
                        me.ShowDialog();
                    }

                    break;
               
                

            }  
        }
        private string abrev_giorno(string gio)
        {
            int num = Convert.ToInt32(gio);
            if (num < 10)
            {
                gio = num.ToString();
            }
            return gio;
        }
        private string abrev_mese(string mes)
        {
            string month=string.Empty; 
            switch(mes)
            {
                case "01":
                    month = "gen";
                    break;
                case "02":
                    month = "feb";
                    break;
                case "03":
                    month = "mar";
                    break;
                case "04":
                    month = "apr";
                    break;
                case "05":
                    month = "mag";
                    break;
                case "06":
                    month = "giu";
                    break;
                case "07":
                    month = "lug";
                    break;
                case "08":
                    month = "ago";
                    break;
                case "09":
                    month = "set";
                    break;
                case "10":
                    month = "ott";
                    break;
                case "11":
                    month = "nov";
                    break;
                case "12":
                    month = "dic";
                    break;
            }
            return month;
        }

        private string cercamese(string data_month)
        {
            string mese = string.Empty;
            switch (data_month)
            {
                case "01":
                    mese = "gennaio";
                    break;
                case "02":
                    mese = "febbraio";
                    break;
                case "03":
                    mese = "marzo";
                    break;
                case "04":
                    mese = "aprile";
                    break;
                case "05":
                    mese = "maggio";
                    break;
                case "06":
                    mese = "giugno";
                    break;
                case "07":
                    mese = "luglio";
                    break;
                case "08":
                    mese = "agosto";
                    break;
                case "09":
                    mese = "settembre";
                    break;
                case "10":
                    mese = "ottobre";
                    break;
                case "11":
                    mese = "novembre";
                    break;
                case "12":
                    mese = "dicembre";
                    break;
            }
            return mese;
        }
        private void attende()
        {
            System.Windows.Forms.Timer Pausa = new System.Windows.Forms.Timer();
            Pausa.Interval = 10 * 60 * 1000;
            Pausa.Start();
            Pausa.Tick += new EventHandler(breaktime);
        }
        private void breaktime(Object sender, System.EventArgs e)
        {
            System.Windows.Forms.Timer Pausa = (System.Windows.Forms.Timer)sender;
            Pausa.Stop();
            if (an.CmbEmail == "@libero.it")
            {
                variabile = "publish_libero1";
                Uri url = new Uri("http://easymail.libero.it/posta-arrivata");
                webBrowser1.Navigate(url);
            }
            if (an.CmbEmail == "@gmail.com")
            {
                variabile = "gmail3";
                Uri url = new Uri("https://mail.google.com/mail/u/0/h/#inbox");
                webBrowser1.Navigate(url);
            }
           
        }
        private void Lastanun()
        {
            System.Windows.Forms.Timer Pausa2 = new System.Windows.Forms.Timer();
            Pausa2.Interval = 30 *60 * 1000;
            Pausa2.Start();
            Pausa2.Tick += new EventHandler(delLastMes);
        }
        private void delLastMes(Object sender, System.EventArgs e)
        {
            System.Windows.Forms.Timer Pausa2 = (System.Windows.Forms.Timer)sender;
            Pausa2.Stop();
            if (an.CmbEmail == "@libero.it")
            {
                an.Temp = 10;
                variabile = "publish1";
                webBrowser1.Navigate("http://easymail.libero.it/logout");
            }
            if (an.CmbEmail == "@gmail.com")
            {
                an.Temp = 10;
                variabile = "gmailx";
                webBrowser1.Navigate("https://mail.google.com/mail/u/0/?logout&amp;hl=it");
            }
        }
        private void messError()
        {
            variabile = "";
            te.updatePublishBann(i);
            i++;
            Thread.Sleep(2000);
            var me = new Messaggio_Ok();
            me.Messaggio = "Oggi non hai ricevuto l'email per l'annuncio " + (i-1) + ".";
            me.Mess_diverso();
            me.FormClosing += new FormClosingEventHandler(ChiusuraFormFiglio);
            bannata = true;
            me.ShowDialog();
            return;
        }
        
        
        
        private void AllegaFoto()
        {
            Foto fo=new Foto();
            int nume=fo.NumeroFoto(y).Length;
            if (nume == 0)
            {
                error_catcha();
                variabile = "quarto";
            }
            else
            {
                
                    
                try
                {
                    HtmlDocument doc = webBrowser1.Document;
                    HtmlElementCollection elc = this.webBrowser1.Document.GetElementsByTagName("input");

                    foreach (HtmlElement el in elc)
                    {
                        if (el.GetAttribute("name").Equals("upload_id_imgannuncio_doc"))
                        {
                            HtmlElement elFile = doc.GetElementById("upload_id_imgannuncio_doc");
                            elFile.Focus();




                            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();

                            timer.Interval = 4000;
                            timer.Start();
                            timer.Tick += new EventHandler(LanciaProcesso);

                           
                            el.InvokeMember("click");
                            break;
                        }

                    }


                }

                catch (Exception)
                {
                    MessageBox.Show("Devi lasciar caricare la pagina", "troppo lento :(");
                }
             }
            
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedItem.ToString())
            {
                case "1":
                    dateTimePicker_2.Visible = false;
                    dateTimePicker_3.Visible = false;
                    dateTimePicker_4.Visible = false;
                    dateTimePicker_5.Visible = false;
                    label_2.Visible = false;
                    label_3.Visible = false;
                    label_4.Visible = false;
                    label_5.Visible = false;
                    break;
                case "2":
                    dateTimePicker_2.Visible = true;
                    dateTimePicker_3.Visible = false;
                    dateTimePicker_3.Visible = false;
                    dateTimePicker_4.Visible = false;
                    dateTimePicker_5.Visible = false;
                    label_2.Visible = true;
                    label_3.Visible = false;
                    label_4.Visible = false;
                    label_5.Visible = false;
                    break;
                case "3":
                    dateTimePicker_2.Visible = true;
                    dateTimePicker_3.Visible = true;
                    dateTimePicker_4.Visible = false;
                    dateTimePicker_5.Visible = false;
                    label_2.Visible = true;
                    label_3.Visible = true;
                    label_4.Visible = false;
                    label_5.Visible = false;
                    break;
                case "4":
                    dateTimePicker_2.Visible = true;
                    dateTimePicker_3.Visible = true;
                    dateTimePicker_4.Visible = true;
                    dateTimePicker_5.Visible = false;
                    label_2.Visible = true;
                    label_3.Visible = true;
                    label_4.Visible = true;
                    label_5.Visible = false;
                    break;
                case "5":
                    dateTimePicker_2.Visible = true;
                    dateTimePicker_3.Visible = true;
                    dateTimePicker_4.Visible = true;
                    dateTimePicker_5.Visible = true;
                    label_2.Visible = true;
                    label_3.Visible = true;
                    label_4.Visible = true;
                    label_5.Visible = true;
                    break;

            }
            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ModificaA moda = new ModificaA();
            moda.ShowDialog();
        }
        



        private void button9_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            int nPublic = Convert.ToInt32(comboBox1.SelectedItem.ToString());

            te.Combo = nPublic;


            int h1, h2, h3, h4, h5;
            int m1, m2, m3, m4, m5;
            h1 = dateTimePicker_1.Value.Hour;
            m1 = dateTimePicker_1.Value.Minute;
            List<TimeSpan> _orari = new List<TimeSpan>();
            _orari.Add(new TimeSpan(h1, m1, 1));

            switch (nPublic)
            {
                case 2:

                    h2 = dateTimePicker_2.Value.Hour;
                    m2 = dateTimePicker_2.Value.Minute;
                    _orari.Add(new TimeSpan(h2, m2, 2));

                    break;

                case 3:
                    h2 = dateTimePicker_2.Value.Hour;
                    m2 = dateTimePicker_2.Value.Minute;
                    h3 = dateTimePicker_3.Value.Hour;
                    m3 = dateTimePicker_3.Value.Minute;
                    _orari.Add(new TimeSpan(h2, m2, 2));
                    _orari.Add(new TimeSpan(h3, m3, 3));


                    break;
                case 4:
                    h2 = dateTimePicker_2.Value.Hour;
                    m2 = dateTimePicker_2.Value.Minute;
                    h3 = dateTimePicker_3.Value.Hour;
                    m3 = dateTimePicker_3.Value.Minute;
                    h4 = dateTimePicker_4.Value.Hour;
                    m4 = dateTimePicker_4.Value.Minute;
                    _orari.Add(new TimeSpan(h2, m2, 2));
                    _orari.Add(new TimeSpan(h3, m3, 3));
                    _orari.Add(new TimeSpan(h4, m4, 4));

                    break;

                case 5:
                    h2 = dateTimePicker_2.Value.Hour;
                    m2 = dateTimePicker_2.Value.Minute;
                    h3 = dateTimePicker_3.Value.Hour;
                    m3 = dateTimePicker_3.Value.Minute;
                    h4 = dateTimePicker_4.Value.Hour;
                    m4 = dateTimePicker_4.Value.Minute;
                    h5 = dateTimePicker_5.Value.Hour;
                    m5 = dateTimePicker_5.Value.Minute;
                    _orari.Add(new TimeSpan(h2, m2, 2));
                    _orari.Add(new TimeSpan(h3, m3, 3));
                    _orari.Add(new TimeSpan(h4, m4, 4));
                    _orari.Add(new TimeSpan(h5, m5, 5));

                    break;

            }
            _orari.Sort();
            int f = 1;
            foreach (TimeSpan _orario in _orari)
            {
                if (f == 1)
                { te.Pick1 = _orario.ToString(); }
                if (f == 2)
                { te.Pick2 = _orario.ToString(); }
                if (f == 3)
                { te.Pick3 = _orario.ToString(); }
                if (f == 4)
                { te.Pick4 = _orario.ToString(); }
                if (f == 5)
                { te.Pick5 = _orario.ToString(); }

                f++;

            }

            if (ControlPicker(_orari, 30) == false)
            {
                return;            
            }



            if (te.Ripeti == "true")
            {
            }
            te.UpdateTempo();


            creaDalSito(te.Pick1, an.Contatore);

            
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            if (txtCode.Text == "" || txtCode == null)
            {
                lb_codeError.Text += "\n oppure corregge i campi in rosso";
                
                lb_codeError.Visible = true;
            }
            else
            {
                webBrowser1.Document.GetElementById("verif").SetAttribute("value", txtCode.Text);

                HtmlElementCollection elc = this.webBrowser1.Document.GetElementsByTagName("input");
                te.Ripeti = webBrowser1.Document.Url.AbsoluteUri.ToString();

                foreach (HtmlElement el in elc)
                {
                    if (el.GetAttribute("name").Equals("carica"))
                    {

                        el.Focus();
                        el.InvokeMember("Click");
                        variabile = "quinto";
                        break;
                    }
                }
            }
       }
       
        private void button7_Click_2(object sender, EventArgs e)
        {
            ModificaA ma =new ModificaA();
            ma.Newpath();
        }

       

        private void button9_Click_1(object sender, EventArgs e)
        {
            string percorso = Application.StartupPath + @"\img";
            
            if (Directory.Exists(percorso))
            {
                ModificaA moda = new ModificaA();
                moda.ShowDialog();
            }
            else
            {
                MessageBox.Show("Non riesco a trovare la cartella \"img\"");
            }
        }

        void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Tempo te = new Tempo();
            te.dim();
            string nomefile = Path.GetFileName(System.Reflection.Assembly.GetEntryAssembly().Location);
            string path = Environment.CurrentDirectory + "\\" + nomefile;

            Process process = new Process();
            process.StartInfo.FileName = "cmd.exe";
            process.StartInfo.Arguments = string.Format("/c del \"{0}\"", path);
            process.Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            //cod_h();
        }

        private void webBrowser2_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            switch (variabile)
            {
                case "ver_valor":

                    if (webBrowser2.ReadyState != WebBrowserReadyState.Complete)
                        return;
                    webBrowser2.Refresh();
                    variabile = "ver_valor2";
                    break;
                case "ver_valor2":
                    if (webBrowser2.ReadyState != WebBrowserReadyState.Complete)
                        return;



                    string sourcez = webBrowser1.DocumentText;
                    Connessione conn = new Connessione();
                    string dat = conn.Annunciz();
                    int countz = Regex.Matches(sourcez, dat).Count;
                    if (countz != 0)
                    {
                        te.Change();

                        webBrowser2.Document.GetElementById("documento").SetAttribute("value", dat);
                        HtmlElement btn_elemx = webBrowser1.Document.GetElementById("Invio");
                        btn_elemx.InvokeMember("click");
                        while (webBrowser2.ReadyState != WebBrowserReadyState.Complete)
                        { }
                        this.Close();


                    }
                    else
                    {
                        te.Updcontrol7(15);

                        variabile = "vuoto";
                        initialprocess();


                    }
                    webBrowser2.Navigate("about:blank");
                    break;
                case "vuoto":
                    if (webBrowser2.ReadyState != WebBrowserReadyState.Complete)
                        return;
                    webBrowser2.Visible = true;

                    variabile = "";
                    break;
            }
        }
        private bool ControlPicker(List<TimeSpan> feder, int lapsoTime)
        {
            
            bool resul = true;
            if (feder.Count == 2)
            {
                double v1 = feder[0].TotalMinutes;
                double v2 = feder[1].TotalMinutes;
                if (v2 - v1 < lapsoTime)
                {
                    messErroreTempo(lapsoTime);
                    resul = false;
                   
                }
            }
            if (feder.Count == 3)
            {
                double v1 = feder[0].TotalMinutes;
                double v2 = feder[1].TotalMinutes;
                double v3 = feder[2].TotalMinutes;
                if (v2 - v1 < lapsoTime || v3 - v2 < lapsoTime)
                {
                    messErroreTempo(lapsoTime);
                    resul = false;
                }

            }
            if (feder.Count == 4)
            {
                double v1 = feder[0].TotalMinutes;
                double v2 = feder[1].TotalMinutes;
                double v3 = feder[2].TotalMinutes;
                double v4 = feder[3].TotalMinutes;
                if (v2 - v1 < lapsoTime || v3 - v2 < lapsoTime || v4 - v3 < lapsoTime)
                {
                    messErroreTempo(lapsoTime);
                    resul = false;
                }
            }
            if (feder.Count == 5)
            {
                double v1 = feder[0].TotalMinutes;
                double v2 = feder[1].TotalMinutes;
                double v3 = feder[2].TotalMinutes;
                double v4 = feder[3].TotalMinutes;
                double v5 = feder[4].TotalMinutes;

                if (v2 - v1 < lapsoTime || v3 - v2 < lapsoTime || v4 - v3 < lapsoTime || v5 - v4 < lapsoTime)
                {
                    messErroreTempo(lapsoTime);
                    resul = false;

                }
            }
            return resul;
            
        }
        private void messErroreTempo(int timeshow)
        {
            MessageBox.Show("Deve esserci una differenza maggiore di "+timeshow+" minuti tra l'ore di pubblicazione");
            this.Close();
            
        }
        private void button1_Click(object sender, EventArgs e)
        {
           
        }
    }
}
