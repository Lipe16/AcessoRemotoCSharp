namespace Remoto
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtIp = new System.Windows.Forms.TextBox();
            this.txtPorta = new System.Windows.Forms.TextBox();
            this.btnConectar = new System.Windows.Forms.Button();
            this.btnCompartilhar = new System.Windows.Forms.Button();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.numericUpDownEscala = new System.Windows.Forms.NumericUpDown();
            this.checkSacala = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.numericUpDownVelocidadeThread = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.numericUpDownQualidade = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownEscala)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownVelocidadeThread)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownQualidade)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(71, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "IP";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(71, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "PORTA";
            // 
            // txtIp
            // 
            this.txtIp.Location = new System.Drawing.Point(177, 33);
            this.txtIp.Name = "txtIp";
            this.txtIp.Size = new System.Drawing.Size(100, 22);
            this.txtIp.TabIndex = 2;
            // 
            // txtPorta
            // 
            this.txtPorta.Location = new System.Drawing.Point(177, 100);
            this.txtPorta.Name = "txtPorta";
            this.txtPorta.Size = new System.Drawing.Size(100, 22);
            this.txtPorta.TabIndex = 3;
            // 
            // btnConectar
            // 
            this.btnConectar.Location = new System.Drawing.Point(74, 151);
            this.btnConectar.Name = "btnConectar";
            this.btnConectar.Size = new System.Drawing.Size(75, 23);
            this.btnConectar.TabIndex = 4;
            this.btnConectar.Text = "conectar";
            this.btnConectar.UseVisualStyleBackColor = true;
            this.btnConectar.Click += new System.EventHandler(this.btnConectar_Click);
            // 
            // btnCompartilhar
            // 
            this.btnCompartilhar.Location = new System.Drawing.Point(177, 151);
            this.btnCompartilhar.Name = "btnCompartilhar";
            this.btnCompartilhar.Size = new System.Drawing.Size(115, 23);
            this.btnCompartilhar.TabIndex = 5;
            this.btnCompartilhar.Text = "Compartilhar";
            this.btnCompartilhar.UseVisualStyleBackColor = true;
            this.btnCompartilhar.Click += new System.EventHandler(this.btnCompartilhar_Click);
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // numericUpDownEscala
            // 
            this.numericUpDownEscala.BackColor = System.Drawing.SystemColors.Control;
            this.numericUpDownEscala.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.numericUpDownEscala.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDownEscala.Location = new System.Drawing.Point(177, 218);
            this.numericUpDownEscala.Maximum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.numericUpDownEscala.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDownEscala.Name = "numericUpDownEscala";
            this.numericUpDownEscala.ReadOnly = true;
            this.numericUpDownEscala.Size = new System.Drawing.Size(120, 22);
            this.numericUpDownEscala.TabIndex = 7;
            this.numericUpDownEscala.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // checkSacala
            // 
            this.checkSacala.AutoSize = true;
            this.checkSacala.Location = new System.Drawing.Point(38, 219);
            this.checkSacala.Name = "checkSacala";
            this.checkSacala.Size = new System.Drawing.Size(111, 21);
            this.checkSacala.TabIndex = 8;
            this.checkSacala.Text = "usar escala?";
            this.checkSacala.UseVisualStyleBackColor = true;
            this.checkSacala.CheckedChanged += new System.EventHandler(this.checkSacala_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(35, 258);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 17);
            this.label3.TabIndex = 9;
            this.label3.Text = "velocidade(miliseg)";
            // 
            // numericUpDownVelocidadeThread
            // 
            this.numericUpDownVelocidadeThread.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericUpDownVelocidadeThread.Location = new System.Drawing.Point(177, 253);
            this.numericUpDownVelocidadeThread.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.numericUpDownVelocidadeThread.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericUpDownVelocidadeThread.Name = "numericUpDownVelocidadeThread";
            this.numericUpDownVelocidadeThread.ReadOnly = true;
            this.numericUpDownVelocidadeThread.Size = new System.Drawing.Size(120, 22);
            this.numericUpDownVelocidadeThread.TabIndex = 10;
            this.numericUpDownVelocidadeThread.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numericUpDownVelocidadeThread.ValueChanged += new System.EventHandler(this.numericUpDownVelocidadeThread_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(35, 299);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 17);
            this.label4.TabIndex = 11;
            this.label4.Text = "Qualidade";
            // 
            // numericUpDownQualidade
            // 
            this.numericUpDownQualidade.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownQualidade.Location = new System.Drawing.Point(177, 294);
            this.numericUpDownQualidade.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownQualidade.Name = "numericUpDownQualidade";
            this.numericUpDownQualidade.ReadOnly = true;
            this.numericUpDownQualidade.Size = new System.Drawing.Size(120, 22);
            this.numericUpDownQualidade.TabIndex = 12;
            this.numericUpDownQualidade.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numericUpDownQualidade.ValueChanged += new System.EventHandler(this.numericUpDownQualidade_ValueChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(456, 507);
            this.Controls.Add(this.numericUpDownQualidade);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.numericUpDownVelocidadeThread);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.checkSacala);
            this.Controls.Add(this.numericUpDownEscala);
            this.Controls.Add(this.btnCompartilhar);
            this.Controls.Add(this.btnConectar);
            this.Controls.Add(this.txtPorta);
            this.Controls.Add(this.txtIp);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Configuração";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownEscala)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownVelocidadeThread)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownQualidade)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtIp;
        private System.Windows.Forms.TextBox txtPorta;
        private System.Windows.Forms.Button btnConectar;
        private System.Windows.Forms.Button btnCompartilhar;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.NumericUpDown numericUpDownEscala;
        private System.Windows.Forms.CheckBox checkSacala;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericUpDownVelocidadeThread;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numericUpDownQualidade;
    }
}

