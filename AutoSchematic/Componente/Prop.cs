using AutoSchematic.Componente.Components;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ModeloBase.Componente
{
    public partial class Prop : Form
    {
        public int ExitState { get; set; }
        public readonly BobinaProps PropsOutInstance = new BobinaProps();
        private Color SelectedColor = Color.Black;

        public Prop(BobinaProps Bobina)
        {
            InitializeComponent();
            PropsOutInstance = Bobina;
        }

        private void Btn_Aplicar_Click(object sender, EventArgs e)
        {
            ExitState = 1;
            Close();
        }

        private void Btn_Cancelar_Click(object sender, EventArgs e)
        {
            ExitState = 0;
            Close();
        }

        private void Prop_Load(object sender, EventArgs e)
        {
            ExitState = 0;
            SelectedColor = PropsOutInstance.Pens;
            Pb_color.BackColor = PropsOutInstance.Pens;
            NumericUpDown.Value = (decimal)PropsOutInstance.Espec;
            Tb_Letra.Text = PropsOutInstance.Latters.ToString();
            Tb_Nome.Text = PropsOutInstance.Name;
        }

        private void LK_Cor_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ColorDialog Dialog = new ColorDialog
            {
                SolidColorOnly = true
            };

            Dialog.ShowDialog(this);
            SelectedColor = Dialog.Color;
            Dialog.Dispose();

            Pb_color.BackColor = SelectedColor;
            PropsOutInstance.Pens = SelectedColor;
        }

        private void NumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            PropsOutInstance.Espec = (float)NumericUpDown.Value;
        }

        private void Tb_Nome_TextChanged(object sender, EventArgs e)
        {
            PropsOutInstance.Name = Tb_Nome.Text;
        }

        private void Tb_Letra_TextChanged(object sender, EventArgs e)
        {

            if (Tb_Letra.Text.Length > 0)
                PropsOutInstance.Latters = Tb_Letra.Text[0];
            else
                PropsOutInstance.Latters = '*';

        }
    }
}
