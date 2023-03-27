using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Messaggio_Ok : Form
    {
        private string messaggio;

        public string Messaggio
        {
            get { return messaggio; }
            set { messaggio = value; }
        }
        private string messaggio2;

        public string Messaggio2
        {
            get { return messaggio2; }
            set { messaggio2 = value; }
        }
        
        public Messaggio_Ok()
        {
            InitializeComponent();
            
                panel1.Location = new Point(
               this.ClientSize.Width / 2 - panel1.Size.Width / 2,
               this.ClientSize.Height / 2 - panel1.Size.Height / 2);
                panel1.Anchor = AnchorStyles.None;

                System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();

                timer.Interval = 10000;
                timer.Start();
                timer.Tick += new EventHandler(Chiude_form);
            
        }
        private void Chiude_form(Object sender, System.EventArgs e)
        {
            System.Windows.Forms.Timer timer = (System.Windows.Forms.Timer)sender;
            timer.Stop();
            this.Close();

        }
        private void button1_Click(object sender, EventArgs e)
        {
            
            this.Close();
        }
        public void Mess_diverso()
        {
            label1.Text = this.messaggio;
           
            
        }
        
    }
}
