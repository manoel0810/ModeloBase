using System;
using System.Drawing;
using System.Windows.Forms;

namespace DllTeste
{
    public partial class Teste : Form
    {
        public Teste()
        {
            InitializeComponent();
        }

        private void Exec_Click(object sender, EventArgs e)
        {
            Ctrl.Reload(false);
            Ctrl.SetBobinas(new ModeloBase.Componente.Controle.Bobina[]
            {
                new ModeloBase.Componente.Controle.Bobina()
                {
                    Raio = 230,
                    Color = new Pen(Brushes.DarkBlue, 2f),
                    Bobinas = 6
                },

                new ModeloBase.Componente.Controle.Bobina()
                {
                    Raio = 150,
                    Color = new Pen(Brushes.Red, 2f),
                    Funcao = ModeloBase.Componente.Controle.Type.Auxiliar,
                    Bobinas = 6
                },
            });

            MessageBox.Show("Objeto carregado com informações pré programadas em código compilado", "Objeto inicializado", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
