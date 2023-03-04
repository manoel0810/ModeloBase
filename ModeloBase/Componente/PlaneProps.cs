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
                PainelCarimbo.Enabled = true;
            else
                PainelCarimbo.Enabled = false;
        }

        private void PlaneProps_Load(object sender, EventArgs e)
        {
            NunHeight.Maximum = MedidasPlano[0];
            NunWidth.Maximum = MedidasPlano[1];

            if (Conf.CARIMBO)
            {
                Tb_Titulo.Text = Conf.INFO;
                NunHeight.Value = Conf.CARIMBO_HEIGHT;
                NunWidth.Value = Conf.CARIMBO_WIDTH;
                PainelCorFundoCarimbo.BackColor = Conf.BACKGROUND_COLOR_CARIMBO;
                Tb_FonteTest.Font = Conf.CARIMBO_FONT;
                Tb_FonteTest.Refresh();
            }

            PainelCorX.BackColor = Conf.EIXO_X_COLOR;
            PainelCorY.BackColor = Conf.EIXO_Y_COLOR;
            PainelCorFundo.BackColor = Conf.BACKGROUND_COLOR_PLANE;
        }
    }
}
