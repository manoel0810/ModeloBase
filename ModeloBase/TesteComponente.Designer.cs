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
            this.controle1 = new ModeloBase.Componente.Controle();
            this.SuspendLayout();
            // 
            // controle1
            // 
            this.controle1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("controle1.BackgroundImage")));
            this.controle1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.controle1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.controle1.Location = new System.Drawing.Point(12, 14);
            this.controle1.Name = "controle1";
            this.controle1.Size = new System.Drawing.Size(400, 400);
            this.controle1.TabIndex = 0;
            // 
            // TesteComponente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(427, 426);
            this.Controls.Add(this.controle1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TesteComponente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Teste de componente";
            this.ResumeLayout(false);

        }

        #endregion

        private Componente.Controle controle1;
    }
}