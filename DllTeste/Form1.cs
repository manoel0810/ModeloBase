using AutoSchematic.Componente.Components;
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
            LoadFunction();
        }

        private void LoadFunction()
        {
            Ctrl.Reload(false);
            Ctrl.SetBobinas(new Bobina[]
            {
                new Bobina()
                {
                    Raio = 230,
                    Color = new Pen(Brushes.DarkBlue, 2f),
                    Bobinas = 6
                },

                new Bobina()
                {
                    Raio = 150,
                    Color = new Pen(Brushes.Red, 2f),
                    Funcao = ModeloBase.Componente.Controle.Type.Auxiliar,
                    Bobinas = 6
                },
            });

            MessageBox.Show("Objeto carregado com informações pré programadas em código compilado", "Objeto inicializado", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Teste_Load(object sender, EventArgs e)
        {
            LoadFunction();
        }
    }
}
