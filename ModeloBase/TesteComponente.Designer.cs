namespace ModeloBase
{
    partial class TesteComponente
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TesteComponente));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.RS = new System.Windows.Forms.ToolStripMenuItem();
            this.controle1 = new ModeloBase.Componente.Controle();
            this.DEF = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RS,
            this.DEF});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(621, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // RS
            // 
            this.RS.Name = "RS";
            this.RS.Size = new System.Drawing.Size(47, 20);
            this.RS.Text = "Reset";
            this.RS.Click += new System.EventHandler(this.RS_Click);
            // 
            // controle1
            // 
            this.controle1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("controle1.BackgroundImage")));
            this.controle1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.controle1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.controle1.Location = new System.Drawing.Point(12, 39);
            this.controle1.Name = "controle1";
            this.controle1.Size = new System.Drawing.Size(600, 600);
            this.controle1.TabIndex = 0;
            // 
            // DEF
            // 
            this.DEF.Name = "DEF";
            this.DEF.Size = new System.Drawing.Size(53, 20);
            this.DEF.Text = "Define";
            this.DEF.Click += new System.EventHandler(this.DEF_Click);
            // 
            // TesteComponente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(621, 649);
            this.Controls.Add(this.controle1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TesteComponente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Teste de componente";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Componente.Controle controle1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem RS;
        private System.Windows.Forms.ToolStripMenuItem DEF;
    }
}