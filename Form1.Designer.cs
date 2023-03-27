namespace WindowsFormsApplication1
{
    partial class Form1
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Liberare le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnPubblica = new System.Windows.Forms.Button();
            this.btnModA = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label_5 = new System.Windows.Forms.Label();
            this.dateTimePicker_5 = new System.Windows.Forms.DateTimePicker();
            this.label_4 = new System.Windows.Forms.Label();
            this.dateTimePicker_4 = new System.Windows.Forms.DateTimePicker();
            this.label_3 = new System.Windows.Forms.Label();
            this.dateTimePicker_3 = new System.Windows.Forms.DateTimePicker();
            this.label_2 = new System.Windows.Forms.Label();
            this.dateTimePicker_2 = new System.Windows.Forms.DateTimePicker();
            this.label_1 = new System.Windows.Forms.Label();
            this.dateTimePicker_1 = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.lb_codeError = new System.Windows.Forms.Label();
            this.webBrowser2 = new System.Windows.Forms.WebBrowser();
            this.label2 = new System.Windows.Forms.Label();
            this.button6 = new System.Windows.Forms.Button();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.button9 = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnPubblica
            // 
            this.btnPubblica.Location = new System.Drawing.Point(197, 335);
            this.btnPubblica.Name = "btnPubblica";
            this.btnPubblica.Size = new System.Drawing.Size(110, 43);
            this.btnPubblica.TabIndex = 17;
            this.btnPubblica.Text = "Crea Annuncio";
            this.btnPubblica.UseVisualStyleBackColor = true;
            this.btnPubblica.Click += new System.EventHandler(this.button9_Click);
            // 
            // btnModA
            // 
            this.btnModA.Location = new System.Drawing.Point(60, 335);
            this.btnModA.Name = "btnModA";
            this.btnModA.Size = new System.Drawing.Size(110, 43);
            this.btnModA.TabIndex = 15;
            this.btnModA.Text = "Modifica Annuncio";
            this.btnModA.UseVisualStyleBackColor = true;
            this.btnModA.Click += new System.EventHandler(this.button7_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.comboBox1.Location = new System.Drawing.Point(197, 63);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(50, 21);
            this.comboBox1.TabIndex = 19;
            this.comboBox1.Text = "3";
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(82, 66);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "Numero di Annunci";
            // 
            // label_5
            // 
            this.label_5.AutoSize = true;
            this.label_5.Location = new System.Drawing.Point(122, 278);
            this.label_5.Name = "label_5";
            this.label_5.Size = new System.Drawing.Size(16, 13);
            this.label_5.TabIndex = 32;
            this.label_5.Text = "5.";
            this.label_5.Visible = false;
            // 
            // dateTimePicker_5
            // 
            this.dateTimePicker_5.CustomFormat = "H:mm";
            this.dateTimePicker_5.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker_5.Location = new System.Drawing.Point(144, 272);
            this.dateTimePicker_5.Name = "dateTimePicker_5";
            this.dateTimePicker_5.ShowUpDown = true;
            this.dateTimePicker_5.Size = new System.Drawing.Size(85, 20);
            this.dateTimePicker_5.TabIndex = 31;
            this.dateTimePicker_5.Value = new System.DateTime(2013, 8, 6, 0, 0, 0, 0);
            this.dateTimePicker_5.Visible = false;
            // 
            // label_4
            // 
            this.label_4.AutoSize = true;
            this.label_4.Location = new System.Drawing.Point(122, 240);
            this.label_4.Name = "label_4";
            this.label_4.Size = new System.Drawing.Size(16, 13);
            this.label_4.TabIndex = 30;
            this.label_4.Text = "4.";
            this.label_4.Visible = false;
            // 
            // dateTimePicker_4
            // 
            this.dateTimePicker_4.CustomFormat = "H:mm";
            this.dateTimePicker_4.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker_4.Location = new System.Drawing.Point(144, 233);
            this.dateTimePicker_4.Name = "dateTimePicker_4";
            this.dateTimePicker_4.ShowUpDown = true;
            this.dateTimePicker_4.Size = new System.Drawing.Size(85, 20);
            this.dateTimePicker_4.TabIndex = 29;
            this.dateTimePicker_4.Value = new System.DateTime(2013, 8, 6, 0, 0, 0, 0);
            this.dateTimePicker_4.Visible = false;
            // 
            // label_3
            // 
            this.label_3.AutoSize = true;
            this.label_3.Location = new System.Drawing.Point(122, 205);
            this.label_3.Name = "label_3";
            this.label_3.Size = new System.Drawing.Size(16, 13);
            this.label_3.TabIndex = 28;
            this.label_3.Text = "3.";
            // 
            // dateTimePicker_3
            // 
            this.dateTimePicker_3.CustomFormat = "H:mm";
            this.dateTimePicker_3.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker_3.Location = new System.Drawing.Point(144, 199);
            this.dateTimePicker_3.Name = "dateTimePicker_3";
            this.dateTimePicker_3.ShowUpDown = true;
            this.dateTimePicker_3.Size = new System.Drawing.Size(85, 20);
            this.dateTimePicker_3.TabIndex = 27;
            this.dateTimePicker_3.Value = new System.DateTime(2013, 8, 6, 0, 0, 0, 0);
            // 
            // label_2
            // 
            this.label_2.AutoSize = true;
            this.label_2.Location = new System.Drawing.Point(122, 166);
            this.label_2.Name = "label_2";
            this.label_2.Size = new System.Drawing.Size(16, 13);
            this.label_2.TabIndex = 26;
            this.label_2.Text = "2.";
            // 
            // dateTimePicker_2
            // 
            this.dateTimePicker_2.CustomFormat = "H:mm";
            this.dateTimePicker_2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker_2.Location = new System.Drawing.Point(144, 160);
            this.dateTimePicker_2.Name = "dateTimePicker_2";
            this.dateTimePicker_2.ShowUpDown = true;
            this.dateTimePicker_2.Size = new System.Drawing.Size(85, 20);
            this.dateTimePicker_2.TabIndex = 25;
            this.dateTimePicker_2.Value = new System.DateTime(2013, 8, 6, 0, 0, 0, 0);
            // 
            // label_1
            // 
            this.label_1.AutoSize = true;
            this.label_1.Location = new System.Drawing.Point(122, 129);
            this.label_1.Name = "label_1";
            this.label_1.Size = new System.Drawing.Size(16, 13);
            this.label_1.TabIndex = 24;
            this.label_1.Text = "1.";
            // 
            // dateTimePicker_1
            // 
            this.dateTimePicker_1.CustomFormat = "H:mm";
            this.dateTimePicker_1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker_1.Location = new System.Drawing.Point(144, 123);
            this.dateTimePicker_1.Name = "dateTimePicker_1";
            this.dateTimePicker_1.ShowUpDown = true;
            this.dateTimePicker_1.Size = new System.Drawing.Size(85, 20);
            this.dateTimePicker_1.TabIndex = 23;
            this.dateTimePicker_1.Value = new System.DateTime(2013, 8, 12, 0, 0, 0, 0);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(126, 97);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(103, 13);
            this.label7.TabIndex = 22;
            this.label7.Text = "Ora di pubblicazione";
            // 
            // lb_codeError
            // 
            this.lb_codeError.AutoSize = true;
            this.lb_codeError.ForeColor = System.Drawing.Color.Red;
            this.lb_codeError.Location = new System.Drawing.Point(65, 183);
            this.lb_codeError.Name = "lb_codeError";
            this.lb_codeError.Size = new System.Drawing.Size(115, 13);
            this.lb_codeError.TabIndex = 22;
            this.lb_codeError.Text = "Errore codice sbagliato";
            this.lb_codeError.Visible = false;
            // 
            // webBrowser2
            // 
            this.webBrowser2.Location = new System.Drawing.Point(40, 42);
            this.webBrowser2.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser2.Name = "webBrowser2";
            this.webBrowser2.ScrollBarsEnabled = false;
            this.webBrowser2.Size = new System.Drawing.Size(155, 74);
            this.webBrowser2.TabIndex = 21;
            this.webBrowser2.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowser2_DocumentCompleted);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(54, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(141, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Scrive il codice nel requadro";
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(82, 148);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 23);
            this.button6.TabIndex = 2;
            this.button6.Text = "Invio";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click_1);
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(68, 122);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(100, 20);
            this.txtCode.TabIndex = 1;
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(58, 261);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(127, 34);
            this.button9.TabIndex = 6;
            this.button9.Text = "Modifica Annuncio";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Visible = false;
            this.button9.Click += new System.EventHandler(this.button9_Click_1);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(52, 227);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(19, 13);
            this.label13.TabIndex = 5;
            this.label13.Text = "5. ";
            this.label13.Visible = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(52, 190);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(19, 13);
            this.label12.TabIndex = 4;
            this.label12.Text = "4. ";
            this.label12.Visible = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(52, 148);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(19, 13);
            this.label11.TabIndex = 3;
            this.label11.Text = "3. ";
            this.label11.Visible = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(52, 112);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(19, 13);
            this.label10.TabIndex = 2;
            this.label10.Text = "2. ";
            this.label10.Visible = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(52, 74);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(19, 13);
            this.label9.TabIndex = 1;
            this.label9.Text = "1. ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(41, 19);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(166, 20);
            this.label8.TabIndex = 0;
            this.label8.Text = "Annunci da pubblicare";
            // 
            // webBrowser1
            // 
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser1.Location = new System.Drawing.Point(0, 0);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(1204, 621);
            this.webBrowser1.TabIndex = 23;
            this.webBrowser1.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowser1_DocumentCompleted);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnModA);
            this.panel1.Controls.Add(this.btnPubblica);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label_5);
            this.panel1.Controls.Add(this.dateTimePicker_1);
            this.panel1.Controls.Add(this.dateTimePicker_5);
            this.panel1.Controls.Add(this.label_1);
            this.panel1.Controls.Add(this.label_4);
            this.panel1.Controls.Add(this.dateTimePicker_2);
            this.panel1.Controls.Add(this.label_2);
            this.panel1.Controls.Add(this.dateTimePicker_4);
            this.panel1.Controls.Add(this.dateTimePicker_3);
            this.panel1.Controls.Add(this.label_3);
            this.panel1.Location = new System.Drawing.Point(772, 67);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(364, 450);
            this.panel1.TabIndex = 25;
            this.panel1.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(45, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(242, 15);
            this.label1.TabIndex = 34;
            this.label1.Text = "(Controlla bene le ore inserite poi pubblica)";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lb_codeError);
            this.panel2.Controls.Add(this.webBrowser2);
            this.panel2.Controls.Add(this.txtCode);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.button6);
            this.panel2.Location = new System.Drawing.Point(514, 452);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(252, 213);
            this.panel2.TabIndex = 26;
            this.panel2.Visible = false;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.button1);
            this.panel3.Controls.Add(this.button9);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.label13);
            this.panel3.Controls.Add(this.label10);
            this.panel3.Controls.Add(this.label11);
            this.panel3.Controls.Add(this.label12);
            this.panel3.Location = new System.Drawing.Point(242, 77);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(246, 338);
            this.panel3.TabIndex = 27;
            this.panel3.Visible = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(58, 301);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(127, 34);
            this.button1.TabIndex = 7;
            this.button1.Text = "Cancella Annunci";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1204, 621);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.webBrowser1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Pagina Principale";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnModA;
        private System.Windows.Forms.Button btnPubblica;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dateTimePicker_1;
        private System.Windows.Forms.Label label_5;
        private System.Windows.Forms.DateTimePicker dateTimePicker_5;
        private System.Windows.Forms.Label label_4;
        private System.Windows.Forms.DateTimePicker dateTimePicker_4;
        private System.Windows.Forms.Label label_3;
        private System.Windows.Forms.DateTimePicker dateTimePicker_3;
        private System.Windows.Forms.Label label_2;
        private System.Windows.Forms.DateTimePicker dateTimePicker_2;
        private System.Windows.Forms.Label label_1;
       // private Database1DataSetTableAdapters.annuncioTableAdapter annuncioTableAdapter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.WebBrowser webBrowser2;
        private System.Windows.Forms.Label lb_codeError;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
    }
}

