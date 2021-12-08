namespace Proyecto_De_Loteria
{
    partial class CPU
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
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.Btnlimpiar = new System.Windows.Forms.Button();
            this.Btncreartabla = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblcartasrestantes = new System.Windows.Forms.Label();
            this.BtnComenzar = new System.Windows.Forms.Button();
            this.BtnRegresar = new System.Windows.Forms.Button();
            this.BtnResumen = new System.Windows.Forms.Button();
            this.BtnLento = new System.Windows.Forms.Button();
            this.BtnRapido = new System.Windows.Forms.Button();
            this.Btniralmenu = new System.Windows.Forms.Button();
            this.BtnBuenas = new System.Windows.Forms.Button();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.GrupFormas = new System.Windows.Forms.GroupBox();
            this.RadioFomaTCh = new System.Windows.Forms.RadioButton();
            this.RadioFormaT = new System.Windows.Forms.RadioButton();
            this.RadioGanarL = new System.Windows.Forms.RadioButton();
            this.RadioCruz = new System.Windows.Forms.RadioButton();
            this.RadioPollaG = new System.Windows.Forms.RadioButton();
            this.RadioHorizontal = new System.Windows.Forms.RadioButton();
            this.Radiodiagonalinversa = new System.Windows.Forms.RadioButton();
            this.radiodosdiagonales = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.GrupFormas.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Btnlimpiar
            // 
            this.Btnlimpiar.Location = new System.Drawing.Point(12, 64);
            this.Btnlimpiar.Name = "Btnlimpiar";
            this.Btnlimpiar.Size = new System.Drawing.Size(75, 23);
            this.Btnlimpiar.TabIndex = 0;
            this.Btnlimpiar.Text = "Limpiar";
            this.Btnlimpiar.UseVisualStyleBackColor = true;
            this.Btnlimpiar.Click += new System.EventHandler(this.Btnlimpiar_Click);
            // 
            // Btncreartabla
            // 
            this.Btncreartabla.Location = new System.Drawing.Point(12, 35);
            this.Btncreartabla.Name = "Btncreartabla";
            this.Btncreartabla.Size = new System.Drawing.Size(75, 23);
            this.Btncreartabla.TabIndex = 1;
            this.Btncreartabla.Text = "Crear Tabla";
            this.Btncreartabla.UseVisualStyleBackColor = true;
            this.Btncreartabla.Click += new System.EventHandler(this.Btncreartabla_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(484, 223);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(105, 174);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // lblcartasrestantes
            // 
            this.lblcartasrestantes.AutoSize = true;
            this.lblcartasrestantes.Location = new System.Drawing.Point(521, 207);
            this.lblcartasrestantes.Name = "lblcartasrestantes";
            this.lblcartasrestantes.Size = new System.Drawing.Size(40, 13);
            this.lblcartasrestantes.TabIndex = 3;
            this.lblcartasrestantes.Text = "cuenta";
            // 
            // BtnComenzar
            // 
            this.BtnComenzar.Location = new System.Drawing.Point(458, 96);
            this.BtnComenzar.Name = "BtnComenzar";
            this.BtnComenzar.Size = new System.Drawing.Size(156, 23);
            this.BtnComenzar.TabIndex = 4;
            this.BtnComenzar.Text = "Comenzar";
            this.BtnComenzar.UseVisualStyleBackColor = true;
            this.BtnComenzar.Click += new System.EventHandler(this.BtnComenzar_Click);
            // 
            // BtnRegresar
            // 
            this.BtnRegresar.Location = new System.Drawing.Point(458, 125);
            this.BtnRegresar.Name = "BtnRegresar";
            this.BtnRegresar.Size = new System.Drawing.Size(156, 23);
            this.BtnRegresar.TabIndex = 5;
            this.BtnRegresar.Text = "Regresar";
            this.BtnRegresar.UseVisualStyleBackColor = true;
            this.BtnRegresar.Click += new System.EventHandler(this.BtnRegresar_Click);
            // 
            // BtnResumen
            // 
            this.BtnResumen.Location = new System.Drawing.Point(502, 181);
            this.BtnResumen.Name = "BtnResumen";
            this.BtnResumen.Size = new System.Drawing.Size(75, 23);
            this.BtnResumen.TabIndex = 7;
            this.BtnResumen.Text = "Resumen";
            this.BtnResumen.UseVisualStyleBackColor = true;
            this.BtnResumen.Click += new System.EventHandler(this.BtnResumen_Click);
            // 
            // BtnLento
            // 
            this.BtnLento.Location = new System.Drawing.Point(458, 154);
            this.BtnLento.Name = "BtnLento";
            this.BtnLento.Size = new System.Drawing.Size(75, 23);
            this.BtnLento.TabIndex = 8;
            this.BtnLento.Text = "Lento";
            this.BtnLento.UseVisualStyleBackColor = true;
            this.BtnLento.Click += new System.EventHandler(this.BtnLento_Click);
            // 
            // BtnRapido
            // 
            this.BtnRapido.Location = new System.Drawing.Point(539, 154);
            this.BtnRapido.Name = "BtnRapido";
            this.BtnRapido.Size = new System.Drawing.Size(75, 23);
            this.BtnRapido.TabIndex = 9;
            this.BtnRapido.Text = "Rapido";
            this.BtnRapido.UseVisualStyleBackColor = true;
            this.BtnRapido.Click += new System.EventHandler(this.BtnRapido_Click);
            // 
            // Btniralmenu
            // 
            this.Btniralmenu.Location = new System.Drawing.Point(12, 6);
            this.Btniralmenu.Name = "Btniralmenu";
            this.Btniralmenu.Size = new System.Drawing.Size(75, 23);
            this.Btniralmenu.TabIndex = 10;
            this.Btniralmenu.Text = "Ir al menu ";
            this.Btniralmenu.UseVisualStyleBackColor = true;
            this.Btniralmenu.Click += new System.EventHandler(this.Btniralmenu_Click);
            // 
            // BtnBuenas
            // 
            this.BtnBuenas.Location = new System.Drawing.Point(484, 420);
            this.BtnBuenas.Name = "BtnBuenas";
            this.BtnBuenas.Size = new System.Drawing.Size(105, 41);
            this.BtnBuenas.TabIndex = 11;
            this.BtnBuenas.Text = "Buenas";
            this.BtnBuenas.UseVisualStyleBackColor = true;
            this.BtnBuenas.Click += new System.EventHandler(this.BtnBuenas_Click);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(6, 19);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(67, 17);
            this.radioButton1.TabIndex = 13;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Diagonal";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // GrupFormas
            // 
            this.GrupFormas.Controls.Add(this.RadioFomaTCh);
            this.GrupFormas.Controls.Add(this.RadioFormaT);
            this.GrupFormas.Controls.Add(this.RadioGanarL);
            this.GrupFormas.Controls.Add(this.RadioCruz);
            this.GrupFormas.Controls.Add(this.RadioPollaG);
            this.GrupFormas.Controls.Add(this.RadioHorizontal);
            this.GrupFormas.Controls.Add(this.Radiodiagonalinversa);
            this.GrupFormas.Controls.Add(this.radiodosdiagonales);
            this.GrupFormas.Controls.Add(this.radioButton1);
            this.GrupFormas.Location = new System.Drawing.Point(630, 12);
            this.GrupFormas.Name = "GrupFormas";
            this.GrupFormas.Size = new System.Drawing.Size(505, 75);
            this.GrupFormas.TabIndex = 14;
            this.GrupFormas.TabStop = false;
            this.GrupFormas.Text = "Formas de ganar";
            // 
            // RadioFomaTCh
            // 
            this.RadioFomaTCh.AutoSize = true;
            this.RadioFomaTCh.Location = new System.Drawing.Point(390, 19);
            this.RadioFomaTCh.Name = "RadioFomaTCh";
            this.RadioFomaTCh.Size = new System.Drawing.Size(97, 17);
            this.RadioFomaTCh.TabIndex = 21;
            this.RadioFomaTCh.TabStop = true;
            this.RadioFomaTCh.Text = "Forma T Chica ";
            this.RadioFomaTCh.UseVisualStyleBackColor = true;
            this.RadioFomaTCh.CheckedChanged += new System.EventHandler(this.RadioFomaTCh_CheckedChanged);
            // 
            // RadioFormaT
            // 
            this.RadioFormaT.AutoSize = true;
            this.RadioFormaT.Location = new System.Drawing.Point(316, 42);
            this.RadioFormaT.Name = "RadioFormaT";
            this.RadioFormaT.Size = new System.Drawing.Size(64, 17);
            this.RadioFormaT.TabIndex = 20;
            this.RadioFormaT.TabStop = true;
            this.RadioFormaT.Text = "Forma T";
            this.RadioFormaT.UseVisualStyleBackColor = true;
            this.RadioFormaT.CheckedChanged += new System.EventHandler(this.RadioFormaT_CheckedChanged);
            // 
            // RadioGanarL
            // 
            this.RadioGanarL.AutoSize = true;
            this.RadioGanarL.Location = new System.Drawing.Point(316, 19);
            this.RadioGanarL.Name = "RadioGanarL";
            this.RadioGanarL.Size = new System.Drawing.Size(63, 17);
            this.RadioGanarL.TabIndex = 19;
            this.RadioGanarL.TabStop = true;
            this.RadioGanarL.Text = "Forma L";
            this.RadioGanarL.UseVisualStyleBackColor = true;
            this.RadioGanarL.CheckedChanged += new System.EventHandler(this.RadioGanarL_CheckedChanged);
            // 
            // RadioCruz
            // 
            this.RadioCruz.AutoSize = true;
            this.RadioCruz.Location = new System.Drawing.Point(224, 42);
            this.RadioCruz.Name = "RadioCruz";
            this.RadioCruz.Size = new System.Drawing.Size(46, 17);
            this.RadioCruz.TabIndex = 18;
            this.RadioCruz.TabStop = true;
            this.RadioCruz.Text = "Cruz";
            this.RadioCruz.UseVisualStyleBackColor = true;
            this.RadioCruz.CheckedChanged += new System.EventHandler(this.RadioCruz_CheckedChanged);
            // 
            // RadioPollaG
            // 
            this.RadioPollaG.AutoSize = true;
            this.RadioPollaG.Location = new System.Drawing.Point(224, 19);
            this.RadioPollaG.Name = "RadioPollaG";
            this.RadioPollaG.Size = new System.Drawing.Size(86, 17);
            this.RadioPollaG.TabIndex = 17;
            this.RadioPollaG.TabStop = true;
            this.RadioPollaG.Text = "Polla Grande";
            this.RadioPollaG.UseVisualStyleBackColor = true;
            this.RadioPollaG.CheckedChanged += new System.EventHandler(this.RadioPollaG_CheckedChanged);
            // 
            // RadioHorizontal
            // 
            this.RadioHorizontal.AutoSize = true;
            this.RadioHorizontal.Location = new System.Drawing.Point(108, 42);
            this.RadioHorizontal.Name = "RadioHorizontal";
            this.RadioHorizontal.Size = new System.Drawing.Size(72, 17);
            this.RadioHorizontal.TabIndex = 16;
            this.RadioHorizontal.TabStop = true;
            this.RadioHorizontal.Text = "Horizontal";
            this.RadioHorizontal.UseVisualStyleBackColor = true;
            this.RadioHorizontal.CheckedChanged += new System.EventHandler(this.RadioHorizontal_CheckedChanged);
            // 
            // Radiodiagonalinversa
            // 
            this.Radiodiagonalinversa.AutoSize = true;
            this.Radiodiagonalinversa.Location = new System.Drawing.Point(108, 19);
            this.Radiodiagonalinversa.Name = "Radiodiagonalinversa";
            this.Radiodiagonalinversa.Size = new System.Drawing.Size(110, 17);
            this.Radiodiagonalinversa.TabIndex = 15;
            this.Radiodiagonalinversa.TabStop = true;
            this.Radiodiagonalinversa.Text = "Diagonale inversa";
            this.Radiodiagonalinversa.UseVisualStyleBackColor = true;
            this.Radiodiagonalinversa.CheckedChanged += new System.EventHandler(this.Radiodiagonalinversa_CheckedChanged);
            // 
            // radiodosdiagonales
            // 
            this.radiodosdiagonales.AutoSize = true;
            this.radiodosdiagonales.Location = new System.Drawing.Point(6, 42);
            this.radiodosdiagonales.Name = "radiodosdiagonales";
            this.radiodosdiagonales.Size = new System.Drawing.Size(100, 17);
            this.radiodosdiagonales.TabIndex = 14;
            this.radiodosdiagonales.TabStop = true;
            this.radiodosdiagonales.Text = "Dos Diagonales";
            this.radiodosdiagonales.UseVisualStyleBackColor = true;
            this.radiodosdiagonales.CheckedChanged += new System.EventHandler(this.radiodosdiagonales_CheckedChanged);
            // 
            // CPU
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Red;
            this.ClientSize = new System.Drawing.Size(1157, 608);
            this.Controls.Add(this.GrupFormas);
            this.Controls.Add(this.BtnBuenas);
            this.Controls.Add(this.Btniralmenu);
            this.Controls.Add(this.BtnRapido);
            this.Controls.Add(this.BtnLento);
            this.Controls.Add(this.BtnResumen);
            this.Controls.Add(this.BtnRegresar);
            this.Controls.Add(this.BtnComenzar);
            this.Controls.Add(this.lblcartasrestantes);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.Btncreartabla);
            this.Controls.Add(this.Btnlimpiar);
            this.Name = "CPU";
            this.Text = "CPU";
            this.Load += new System.EventHandler(this.CPU_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.GrupFormas.ResumeLayout(false);
            this.GrupFormas.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button Btnlimpiar;
        private System.Windows.Forms.Button Btncreartabla;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblcartasrestantes;
        private System.Windows.Forms.Button BtnComenzar;
        private System.Windows.Forms.Button BtnRegresar;
        private System.Windows.Forms.Button BtnResumen;
        private System.Windows.Forms.Button BtnLento;
        private System.Windows.Forms.Button BtnRapido;
        private System.Windows.Forms.Button Btniralmenu;
        private System.Windows.Forms.Button BtnBuenas;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.GroupBox GrupFormas;
        private System.Windows.Forms.RadioButton radiodosdiagonales;
        private System.Windows.Forms.RadioButton Radiodiagonalinversa;
        private System.Windows.Forms.RadioButton RadioHorizontal;
        private System.Windows.Forms.RadioButton RadioPollaG;
        private System.Windows.Forms.RadioButton RadioCruz;
        private System.Windows.Forms.RadioButton RadioGanarL;
        private System.Windows.Forms.RadioButton RadioFormaT;
        private System.Windows.Forms.RadioButton RadioFomaTCh;
    }
}