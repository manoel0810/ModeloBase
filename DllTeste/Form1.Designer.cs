namespace DllTeste
{
    partial class Teste
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Teste));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.Exec = new System.Windows.Forms.ToolStripMenuItem();
            this.Ctrl = new ModeloBase.Componente.Controle();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Exec});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(621, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // Exec
            // 
            this.Exec.Name = "Exec";
            this.Exec.Size = new System.Drawing.Size(60, 20);
            this.Exec.Text = "Execute";
            this.Exec.Click += new System.EventHandler(this.Exec_Click);
            // 
            // Ctrl
            // 
            this.Ctrl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Ctrl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Ctrl.Location = new System.Drawing.Point(12, 39);
            this.Ctrl.Name = "Ctrl";
            this.Ctrl.Size = new System.Drawing.Size(600, 600);
            this.Ctrl.TabIndex = 1;
            // 
            // Teste
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(621, 649);
            this.Controls.Add(this.Ctrl);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Teste";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Área de teste";
            this.Load += new System.EventHandler(this.Teste_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem Exec;
        private ModeloBase.Componente.Controle Ctrl;
    }
}

