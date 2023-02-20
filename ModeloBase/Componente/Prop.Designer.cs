namespace ModeloBase.Componente
{
    partial class Prop
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Prop));
            this.Tb_Letra = new System.Windows.Forms.TextBox();
            this.Tb_Nome = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.NumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.Pb_color = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.LK_Cor = new System.Windows.Forms.LinkLabel();
            this.Btn_Aplicar = new System.Windows.Forms.Button();
            this.Btn_Cancelar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pb_color)).BeginInit();
            this.SuspendLayout();
            // 
            // Tb_Letra
            // 
            this.Tb_Letra.Location = new System.Drawing.Point(12, 21);
            this.Tb_Letra.MaxLength = 1;
            this.Tb_Letra.Name = "Tb_Letra";
            this.Tb_Letra.Size = new System.Drawing.Size(64, 20);
            this.Tb_Letra.TabIndex = 0;
            this.Tb_Letra.TextChanged += new System.EventHandler(this.Tb_Letra_TextChanged);
            // 
            // Tb_Nome
            // 
            this.Tb_Nome.Location = new System.Drawing.Point(82, 21);
            this.Tb_Nome.MaxLength = 16;
            this.Tb_Nome.Name = "Tb_Nome";
            this.Tb_Nome.Size = new System.Drawing.Size(100, 20);
            this.Tb_Nome.TabIndex = 1;
            this.Tb_Nome.TextChanged += new System.EventHandler(this.Tb_Nome_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Letra";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(79, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nome";
            // 
            // NumericUpDown
            // 
            this.NumericUpDown.DecimalPlaces = 1;
            this.NumericUpDown.Increment = new decimal(new int[] {
            2,
            0,
            0,
            65536});
            this.NumericUpDown.Location = new System.Drawing.Point(188, 22);
            this.NumericUpDown.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.NumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumericUpDown.Name = "NumericUpDown";
            this.NumericUpDown.Size = new System.Drawing.Size(66, 20);
            this.NumericUpDown.TabIndex = 2;
            this.NumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumericUpDown.ValueChanged += new System.EventHandler(this.NumericUpDown_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(185, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Espessura";
            // 
            // Pb_color
            // 
            this.Pb_color.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Pb_color.Location = new System.Drawing.Point(12, 62);
            this.Pb_color.Name = "Pb_color";
            this.Pb_color.Size = new System.Drawing.Size(242, 24);
            this.Pb_color.TabIndex = 4;
            this.Pb_color.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Cor";
            // 
            // LK_Cor
            // 
            this.LK_Cor.AutoSize = true;
            this.LK_Cor.Location = new System.Drawing.Point(206, 89);
            this.LK_Cor.Name = "LK_Cor";
            this.LK_Cor.Size = new System.Drawing.Size(48, 13);
            this.LK_Cor.TabIndex = 3;
            this.LK_Cor.TabStop = true;
            this.LK_Cor.Text = "Escolher";
            this.LK_Cor.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LK_Cor_LinkClicked);
            // 
            // Btn_Aplicar
            // 
            this.Btn_Aplicar.Location = new System.Drawing.Point(179, 126);
            this.Btn_Aplicar.Name = "Btn_Aplicar";
            this.Btn_Aplicar.Size = new System.Drawing.Size(75, 23);
            this.Btn_Aplicar.TabIndex = 4;
            this.Btn_Aplicar.Text = "Aplicar";
            this.Btn_Aplicar.UseVisualStyleBackColor = true;
            this.Btn_Aplicar.Click += new System.EventHandler(this.Btn_Aplicar_Click);
            // 
            // Btn_Cancelar
            // 
            this.Btn_Cancelar.Location = new System.Drawing.Point(98, 126);
            this.Btn_Cancelar.Name = "Btn_Cancelar";
            this.Btn_Cancelar.Size = new System.Drawing.Size(75, 23);
            this.Btn_Cancelar.TabIndex = 5;
            this.Btn_Cancelar.Text = "Cancelar";
            this.Btn_Cancelar.UseVisualStyleBackColor = true;
            this.Btn_Cancelar.Click += new System.EventHandler(this.Btn_Cancelar_Click);
            // 
            // Prop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(267, 161);
            this.Controls.Add(this.Btn_Cancelar);
            this.Controls.Add(this.Btn_Aplicar);
            this.Controls.Add(this.LK_Cor);
            this.Controls.Add(this.Pb_color);
            this.Controls.Add(this.NumericUpDown);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Tb_Nome);
            this.Controls.Add(this.Tb_Letra);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Prop";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Propriedades";
            this.Load += new System.EventHandler(this.Prop_Load);
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pb_color)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Tb_Letra;
        private System.Windows.Forms.TextBox Tb_Nome;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown NumericUpDown;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox Pb_color;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.LinkLabel LK_Cor;
        private System.Windows.Forms.Button Btn_Aplicar;
        private System.Windows.Forms.Button Btn_Cancelar;
    }
}