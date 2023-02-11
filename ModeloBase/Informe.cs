using System;
using System.Windows.Forms;

namespace ModeloBase
{
    public partial class Informe : Form
    {

        public Dados Informacoes { get; set; }
        public Informe()
        {
            InitializeComponent();
        }

        private void Btn_Salvar_Click(object sender, EventArgs e)
        {
            Informacoes = new Dados
            {
                Pontos = int.Parse(textBox1.Text)
            };

            Close();
        }
    }
}
