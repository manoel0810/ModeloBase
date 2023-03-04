using System;
using System.Windows.Forms;
using static ModeloBase.Componente.Controle;

namespace ModeloBase.Componente
{
    public partial class PlaneProps : Form
    {
        private readonly Configuracoes Conf;
        private readonly int[] MedidasPlano;

        public PlaneProps(Configuracoes Config, int[] Medidas)
        {
            InitializeComponent();
            Conf = Config;
            MedidasPlano = Medidas;
        }

        private void Cb_Carimbo_CheckedChanged(object sender, EventArgs e)
        {
            if (Cb_Carimbo.Checked)
            {
                PainelCarimbo.Enabled = true;
                Parametros.CARIMBO = true;
            }
            else
            {
                PainelCarimbo.Enabled = false;
                Parametros.CARIMBO = false;
            }

            if (Cb_Carimbo.Checked)
            {
                Tb_Titulo.Text = Conf.INFO;
                Tb_Modelo.Text = Conf.MODEL;
                NunHeight.Value = Conf.CARIMBO_HEIGHT;
                NunWidth.Value = Conf.CARIMBO_WIDTH;
                PainelCorFundoCarimbo.BackColor = Conf.BACKGROUND_COLOR_CARIMBO;
                Tb_FonteTest.Font = Conf.CARIMBO_FONT;
                Tb_FonteTest.Refresh();
                Cb_Trifasico.Checked = Parametros.TRIFASIC;
            }
        }

        private void PlaneProps_Load(object sender, EventArgs e)
        {
            NunHeight.Maximum = MedidasPlano[0];
            NunWidth.Maximum = MedidasPlano[1];
            Cb_Carimbo.Checked = Conf.CARIMBO;

            if (Conf.CARIMBO)
            {
                Tb_Titulo.Text = Conf.INFO;
                Tb_Modelo.Text = Conf.MODEL;
                NunHeight.Value = Conf.CARIMBO_HEIGHT;
                NunWidth.Value = Conf.CARIMBO_WIDTH;
                PainelCorFundoCarimbo.BackColor = Conf.BACKGROUND_COLOR_CARIMBO;
                Tb_FonteTest.Font = Conf.CARIMBO_FONT;
                Tb_FonteTest.Refresh();
                Cb_Trifasico.Checked = Parametros.TRIFASIC;
            }

            PainelCorX.BackColor = Conf.EIXO_X_COLOR;
            PainelCorY.BackColor = Conf.EIXO_Y_COLOR;
            PainelCorFundo.BackColor = Conf.BACKGROUND_COLOR_PLANE;
        }

        private void Tb_Titulo_TextChanged(object sender, EventArgs e)
        {
            Parametros.INFO = Tb_Titulo.Text;
        }

        private void Tb_Modelo_TextChanged(object sender, EventArgs e)
        {
            Parametros.MODEL = Tb_Modelo.Text;
        }

        private void Cb_Trifasico_CheckedChanged(object sender, EventArgs e)
        {
            Parametros.TRIFASIC = Cb_Trifasico.Checked;
        }

        private void NunHeight_ValueChanged(object sender, EventArgs e)
        {
            Parametros.CARIMBO_HEIGHT = (int)NunHeight.Value;
        }

        private void NunWidth_ValueChanged(object sender, EventArgs e)
        {
            Parametros.CARIMBO_WIDTH = (int)NunWidth.Value;
        }

        private void Lk_AlterarFundoCarimbo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ColorPic.ShowDialog(this);
            PainelCorFundoCarimbo.BackColor = ColorPic.Color;
            Parametros.BACKGROUND_COLOR_CARIMBO = ColorPic.Color;
        }

        private void Lk_AlterarFonte_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FontPic.ShowDialog(this);
            Tb_FonteTest.Font = FontPic.Font;
            Parametros.CARIMBO_FONT = FontPic.Font;
        }

        private void Lk_AlterarY_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ColorPic.ShowDialog(this);
            PainelCorY.BackColor = ColorPic.Color;
            Parametros.EIXO_Y_COLOR = ColorPic.Color;
        }

        private void Lk_AlterarX_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ColorPic.ShowDialog(this);
            PainelCorX.BackColor = ColorPic.Color;
            Parametros.EIXO_X_COLOR = ColorPic.Color;
        }

        private void Lk_AlterarFundo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ColorPic.ShowDialog(this);
            PainelCorFundo.BackColor = ColorPic.Color;
            Parametros.BACKGROUND_COLOR_PLANE = ColorPic.Color;
        }
    }
}
