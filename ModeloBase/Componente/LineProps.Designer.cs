namespace ModeloBase.Componente
{
    partial class LineProps
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LineProps));
            this.LK_Cor = new System.Windows.Forms.LinkLabel();
            this.Pb_color = new System.Windows.Forms.PictureBox();
            this.Espec = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Tb_Nome = new System.Windows.Forms.TextBox();
            this.Tb_Letra = new System.Windows.Forms.TextBox();
            this.X1 = new System.Windows.Forms.NumericUpDown();
            this.Y1 = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.X2 = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.Y2 = new System.Windows.Forms.NumericUpDown();
            this.Btn_Aplicar = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Pb_color)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Espec)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.X1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Y1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.X2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Y2)).BeginInit();
            this.SuspendLayout();
            // 
            // LK_Cor
            // 
            this.LK_Cor.AutoSize = true;
            this.LK_Cor.Location = new System.Drawing.Point(210, 95);
            this.LK_Cor.Name = "LK_Cor";
            this.LK_Cor.Size = new System.Drawing.Size(48, 13);
            this.LK_Cor.TabIndex = 3;
            this.LK_Cor.TabStop = true;
            this.LK_Cor.Text = "Escolher";
            this.LK_Cor.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LK_Cor_LinkClicked);
            // 
            // Pb_color
            // 
            this.Pb_color.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Pb_color.Location = new System.Drawing.Point(16, 68);
            this.Pb_color.Name = "Pb_color";
            this.Pb_color.Size = new System.Drawing.Size(242, 24);
            this.Pb_color.TabIndex = 13;
            this.Pb_color.TabStop = false;
            // 
            // Espec
            // 
            this.Espec.DecimalPlaces = 1;
            this.Espec.Increment = new decimal(new int[] {
            2,
            0,
            0,
            65536});
            this.Espec.Location = new System.Drawing.Point(192, 28);
            this.Espec.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.Espec.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.Espec.Name = "Espec";
            this.Espec.Size = new System.Drawing.Size(66, 20);
            this.Espec.TabIndex = 2;
            this.Espec.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Cor";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(189, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Espessura";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(83, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Nome";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Letra";
            // 
            // Tb_Nome
            // 
            this.Tb_Nome.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Tb_Nome.Location = new System.Drawing.Point(86, 27);
            this.Tb_Nome.MaxLength = 16;
            this.Tb_Nome.Name = "Tb_Nome";
            this.Tb_Nome.Size = new System.Drawing.Size(100, 20);
            this.Tb_Nome.TabIndex = 1;
            // 
            // Tb_Letra
            // 
            this.Tb_Letra.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Tb_Letra.Location = new System.Drawing.Point(16, 27);
            this.Tb_Letra.MaxLength = 3;
            this.Tb_Letra.Name = "Tb_Letra";
            this.Tb_Letra.Size = new System.Drawing.Size(64, 20);
            this.Tb_Letra.TabIndex = 0;
            // 
            // X1
            // 
            this.X1.DecimalPlaces = 3;
            this.X1.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.X1.Location = new System.Drawing.Point(13, 28);
            this.X1.Name = "X1";
            this.X1.Size = new System.Drawing.Size(95, 20);
            this.X1.TabIndex = 5;
            // 
            // Y1
            // 
            this.Y1.DecimalPlaces = 3;
            this.Y1.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.Y1.Location = new System.Drawing.Point(13, 54);
            this.Y1.Name = "Y1";
            this.Y1.Size = new System.Drawing.Size(95, 20);
            this.Y1.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(42, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "X/Y";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.X1);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.Y1);
            this.panel1.Enabled = false;
            this.panel1.Location = new System.Drawing.Point(16, 132);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(120, 86);
            this.panel1.TabIndex = 4;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.X2);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.Y2);
            this.panel2.Enabled = false;
            this.panel2.Location = new System.Drawing.Point(142, 132);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(120, 86);
            this.panel2.TabIndex = 7;
            // 
            // X2
            // 
            this.X2.DecimalPlaces = 3;
            this.X2.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.X2.Location = new System.Drawing.Point(13, 28);
            this.X2.Name = "X2";
            this.X2.Size = new System.Drawing.Size(95, 20);
            this.X2.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(46, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(26, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "X/Y";
            // 
            // Y2
            // 
            this.Y2.DecimalPlaces = 3;
            this.Y2.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.Y2.Location = new System.Drawing.Point(13, 54);
            this.Y2.Name = "Y2";
            this.Y2.Size = new System.Drawing.Size(95, 20);
            this.Y2.TabIndex = 9;
            // 
            // Btn_Aplicar
            // 
            this.Btn_Aplicar.Location = new System.Drawing.Point(188, 230);
            this.Btn_Aplicar.Name = "Btn_Aplicar";
            this.Btn_Aplicar.Size = new System.Drawing.Size(75, 23);
            this.Btn_Aplicar.TabIndex = 10;
            this.Btn_Aplicar.Text = "Aplicar";
            this.Btn_Aplicar.UseVisualStyleBackColor = true;
            this.Btn_Aplicar.Click += new System.EventHandler(this.Btn_Aplicar_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(21, 126);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(109, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "Coordenadas XY (P1)";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(148, 127);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(109, 13);
            this.label8.TabIndex = 18;
            this.label8.Text = "Coordenadas XY (P2)";
            // 
            // LineProps
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(281, 265);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.Btn_Aplicar);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.LK_Cor);
            this.Controls.Add(this.Pb_color);
            this.Controls.Add(this.Espec);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Tb_Nome);
            this.Controls.Add(this.Tb_Letra);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LineProps";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LineProps";
            ((System.ComponentModel.ISupportInitialize)(this.Pb_color)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Espec)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.X1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Y1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.X2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Y2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel LK_Cor;
        private System.Windows.Forms.PictureBox Pb_color;
        private System.Windows.Forms.NumericUpDown Espec;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Tb_Nome;
        private System.Windows.Forms.TextBox Tb_Letra;
        private System.Windows.Forms.NumericUpDown X1;
        private System.Windows.Forms.NumericUpDown Y1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.NumericUpDown X2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown Y2;
        private System.Windows.Forms.Button Btn_Aplicar;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
    }
}