using System;
using System.Drawing;
using System.Windows.Forms;
using static ModeloBase.Componente.Controle;

namespace ModeloBase
{
    public partial class TesteComponente : Form
    {
        public TesteComponente()
        {
            InitializeComponent();
        }

        private void RS_Click(object sender, EventArgs e)
        {
            if (controle1.IsInitialized())
            {
                controle1.Reload(false);
                MessageBox.Show("Controle recarregado");
            }
            else
                MessageBox.Show("Controle não carregado");
        }

        private void DEF_Click(object sender, EventArgs e)
        {
            try
            {
                controle1.SetBobinas(new Bobina[]
                {
                    Bobinas[0] = new Bobina()
                    {
                        Raio = 230,
                        Color = new Pen(Brushes.DarkBlue, 2f),
                        Bobinas = 6
                    },

                    Bobinas[1] = new Bobina()
                    {
                         Raio = 150,
                         Color = new Pen(Brushes.Red, 2f),
                         Funcao = Componente.Controle.Type.Auxiliar,
                         Bobinas = 6
                    },

                });

                MessageBox.Show("Controle carregado");

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao instanciar objetos [bobina].\nERRO: {ex.Message}");
            }

        }
    }
}
