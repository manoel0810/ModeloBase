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
            Cb_Legenda.Checked = Conf.LEGEND_LINE;

            //LegendProps

            NunXInicialLegenda.Maximum = MedidasPlano[1];
            NunYInicialLegenda.Maximum = MedidasPlano[0];
            NunXInicialLegenda.Value = Conf.X_LEGEND_START;
            NunYInicialLegenda.Value = Conf.Y_LEGEND_START;
            NunEspacoLinhaCorLegenda.Value = Conf.Y_LEGEND_ITERATOR;
            NunQuebraLinhaLegenda.Value = Conf.Y_LEGEND_SUB_ITERATOR;
            NunTamanhoLinhaLegenda.Value = Conf.LEGEND_LINE_SIZE;
            NunEspessuraLinhaLegenda.Value = (decimal)Conf.LEGEND_LINE_HEIGHT;

            //-------------------------------- TABPAGE 2 ----------------------------//

            NumEspacoLivre.Value = (decimal)Conf.ESPACAMENTO_LIVRE;
            NunBaixa.Value = (decimal)Conf.FATOR_CORRECAO_BAIXO;
            NunAlta.Value = (decimal)Conf.FATOR_CORRECAO_ALTO;
            NunCorrecaoRaioMaior.Value = (decimal)Conf.FATOR_CORRECAO_RAIO_MAIOR;
            NunCorrecaoRaioMenor.Value = (decimal)Conf.FATOR_CORRECAO_RAIO_MENOR;
            NunDecrement.Value = Conf.FATOR_CORRECAO_DECREMENTO;
            NunLimitacao.Value = Conf.FATOR_CORRECAO_LIMITACAO;

            NunPointSize.Value = Conf.POINT_SIZE;
            NunPointMargin.Value = Conf.POINT_MARGIN;
            NunRenderPoints.Value = Conf.RENDER_POINTS;
            NunBazierIterations.Value = Conf.SMOOTH_ITERATIONS;

            Cb_UsarBazier.Checked = Conf.USE_SMOOTH;
            Cb_DescreverPonto.Checked = Conf.DRAW_LATTERS;
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

        private void Cb_Legenda_CheckedChanged(object sender, EventArgs e)
        {
            Parametros.LEGEND_LINE = Cb_Legenda.Checked;
            PainelLegend.Enabled = Cb_Legenda.Checked;
        }

        private void NunXInicialLegenda_ValueChanged(object sender, EventArgs e)
        {
            Parametros.X_LEGEND_START = (int)NunXInicialLegenda.Value;
        }

        private void NunYInicialLegenda_ValueChanged(object sender, EventArgs e)
        {
            Parametros.Y_LEGEND_START = (int)NunYInicialLegenda.Value;
        }

        private void NunEspacoLinhaCorLegenda_ValueChanged(object sender, EventArgs e)
        {
            Parametros.Y_LEGEND_ITERATOR = (int)NunEspacoLinhaCorLegenda.Value;
        }

        private void NunQuebraLinhaLegenda_ValueChanged(object sender, EventArgs e)
        {
            Parametros.Y_LEGEND_SUB_ITERATOR = (int)NunQuebraLinhaLegenda.Value;
        }

        private void NunTamanhoLinhaLegenda_ValueChanged(object sender, EventArgs e)
        {
            Parametros.LEGEND_LINE_SIZE = (int)NunTamanhoLinhaLegenda.Value;
        }

        private void NunEspessuraLinhaLegenda_ValueChanged(object sender, EventArgs e)
        {
            Parametros.LEGEND_LINE_HEIGHT = (float)NunEspessuraLinhaLegenda.Value;
        }

        private void NumEspacoLivre_ValueChanged(object sender, EventArgs e)
        {
            Parametros.ESPACAMENTO_LIVRE = (double)NumEspacoLivre.Value;
        }

        private void NunBaixa_ValueChanged(object sender, EventArgs e)
        {
            Parametros.FATOR_CORRECAO_BAIXO = (double)NunBaixa.Value;
        }

        private void NunAlta_ValueChanged(object sender, EventArgs e)
        {
            Parametros.FATOR_CORRECAO_ALTO = (double)NunAlta.Value;
        }

        private void NunCorrecaoRaioMaior_ValueChanged(object sender, EventArgs e)
        {
            Parametros.FATOR_CORRECAO_RAIO_MAIOR = (double)NunCorrecaoRaioMaior.Value;
        }

        private void NunCorrecaoRaioMenor_ValueChanged(object sender, EventArgs e)
        {
            Parametros.FATOR_CORRECAO_RAIO_MENOR = (double)NunCorrecaoRaioMenor.Value;
        }

        private void NunDecrement_ValueChanged(object sender, EventArgs e)
        {
            Parametros.FATOR_CORRECAO_DECREMENTO = (int)NunDecrement.Value;
        }

        private void NunLimitacao_ValueChanged(object sender, EventArgs e)
        {
            Parametros.FATOR_CORRECAO_LIMITACAO = (int)NunLimitacao.Value;
        }

        private void NunPointSize_ValueChanged(object sender, EventArgs e)
        {
            Parametros.POINT_SIZE = (int)NunPointSize.Value;
        }

        private void NunPointMargin_ValueChanged(object sender, EventArgs e)
        {
            Parametros.POINT_MARGIN = (int)NunPointMargin.Value;
        }

        private void NunRenderPoints_ValueChanged(object sender, EventArgs e)
        {
            Parametros.RENDER_POINTS = (int)NunRenderPoints.Value;
        }

        private void NunBazierIterations_ValueChanged(object sender, EventArgs e)
        {
            Parametros.SMOOTH_ITERATIONS = (int)NunBazierIterations.Value;
        }

        private void Cb_DescreverPonto_CheckedChanged(object sender, EventArgs e)
        {
            Parametros.DRAW_LATTERS = Cb_DescreverPonto.Checked;
        }

        private void Cb_UsarBazier_CheckedChanged(object sender, EventArgs e)
        {
            Parametros.USE_SMOOTH = Cb_UsarBazier.Checked;
        }
    }
}
