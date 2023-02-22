using System;
using System.Drawing;
using System.Windows.Forms;

namespace ModeloBase.Componente
{
    public partial class LineProps : Form
    {
        private readonly int LineIndex = -1;

        public LineProps(int Width, int Height, int Index)
        {
            InitializeComponent();
            X1.Maximum = Width;
            X2.Maximum = Width;

            Y1.Maximum = Height;
            Y2.Maximum = Height;
            var Linha = Controle.LinhasPonto[Index];
            var p1 = Linha.FistPoint;
            var p2 = Linha.LastPoint;

            Pb_color.BackColor = Controle.LastPointLineColorState;
            Espec.Value = (decimal)Linha.LineColor.Width;

            X1.Value = (decimal)p1.X;
            Y1.Value = (decimal)p1.Y;

            X2.Value = (decimal)p2.X;
            Y2.Value = (decimal)p2.Y;

            Tb_Nome.Text = Linha.Name;
            Tb_Letra.Text = Linha.ID;
            LineIndex = Index;
        }

        private void LK_Cor_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ColorDialog Dialog = new ColorDialog
            {
                SolidColorOnly = true
            };

            Dialog.ShowDialog(this);
            var Cor = Dialog.Color;
            Dialog.Dispose();

            Pb_color.BackColor = Cor;
        }

        private void Btn_Aplicar_Click(object sender, EventArgs e)
        {
            Controle.LinhasPonto[LineIndex].Name = Tb_Nome.Text;
            Controle.LinhasPonto[LineIndex].ID = Tb_Letra.Text;
            Controle.LinhasPonto[LineIndex].LineColor = new Pen(Pb_color.BackColor, (float)Espec.Value);
            Controle.LinhasPonto[LineIndex].FistPoint = new PointF((float)X1.Value, (float)Y1.Value);
            Controle.LinhasPonto[LineIndex].LastPoint = new PointF((float)X2.Value, (float)Y2.Value);
            Controle.LastPointLineSelected = -1;
            Close();
        }
    }
}
