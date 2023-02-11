using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ModeloBase
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void RodarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*
            Informe IF = new Informe();
            IF.ShowDialog();

            var Data = IF.Informacoes;
            IF.Dispose();
            */

            Bitmap IMG = new Bitmap(P_Desenho.Width, P_Desenho.Height);
            Graphics G = Graphics.FromImage(IMG);

            G.FillRectangle(Brushes.AliceBlue, new Rectangle(0, 0, P_Desenho.Width, P_Desenho.Height));
            G.DrawLine(Pens.Black, new Point(0, P_Desenho.Height / 2), new Point(P_Desenho.Width, P_Desenho.Height / 2));
            G.DrawLine(Pens.Black, new Point(P_Desenho.Width / 2, 0), new Point(P_Desenho.Width / 2, P_Desenho.Height));
            G.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;

            DrawWithSpace(6, ref G, 180, 128, true, new Pen(Brushes.Blue, 1f));
            DrawWithSpace(6, ref G, 135, 64, false, new Pen(Brushes.Red, 1f));

            //DoDraw(ref G, 190, 256, ConvertToRadius(0),   ConvertToRadius(90));
            //DoDraw(ref G, 190, 256, ConvertToRadius(180), ConvertToRadius(270));
            //DoDraw(ref G, 190, 256, ConvertToRadius(90),  ConvertToRadius(180));
            //DoDraw(ref G, 190, 256, ConvertToRadius(270), ConvertToRadius(360));

            P_Desenho.BackgroundImage = IMG;
        }

        private void DoDraw(ref Graphics G, int raio, int pontos, double angulo = 2 * Math.PI)
        {
            int Raio = raio, Pontos = pontos;
            double Angulo = angulo;

            double Razao = Angulo / Pontos;
            double RazaoVariavel = 0;
            List<Ponto> PontosList = new List<Ponto>();
            for (double i = 0; i <= Pontos; i++)
            {
                var P = new Ponto((P_Desenho.Width / 2) + (Raio * Math.Cos(RazaoVariavel)), (P_Desenho.Height / 2) - (Raio * Math.Sin(RazaoVariavel)));
                PontosList.Add(P);
                RazaoVariavel += Razao;
            }

            for (int i = 0; i < PontosList.Count; i++)
            {

                if (PontosList.Count == (i + 1))
                {
                    G.DrawLine(Pens.DarkBlue, ConvertPoint(PontosList[i - 1]), ConvertPoint(PontosList[i]));
                    G.DrawLine(Pens.DarkBlue, ConvertPoint(PontosList[i]), ConvertPoint(PontosList[0]));
                }
                else

                    G.DrawLine(Pens.DarkBlue, ConvertPoint(PontosList[i]), ConvertPoint(PontosList[i + 1]));
            }

            PontosList.Clear();
        }

        private void DoDraw(ref Graphics G, int raio, int pontos, double Begin, double End, Pen Color = null)
        {
            var Pen = Color ?? new Pen(Brushes.DarkBlue, 3f);
            int Raio = raio, Pontos = pontos;
            double Angulo = End - Begin;

            double Razao = Angulo / Pontos;
            double RazaoVariavel = Begin;
            List<Ponto> PontosList = new List<Ponto>();
            for (double i = 0; i <= Pontos; i++)
            {
                var P = new Ponto((P_Desenho.Width / 2) + (Raio * Math.Cos(RazaoVariavel)), (P_Desenho.Height / 2) - (Raio * Math.Sin(RazaoVariavel)));
                PontosList.Add(P);
                RazaoVariavel += Razao;
            }

            for (int i = 0; i < PontosList.Count; i++)
            {
                if (PontosList.Count == (i + 1))
                    G.DrawLine(Pen, ConvertPoint(PontosList[i - 1]), ConvertPoint(PontosList[i]));
                else
                    G.DrawLine(Pen, ConvertPoint(PontosList[i]), ConvertPoint(PontosList[i + 1]));
            }

            PontosList.Clear();
        }

        private void DrawWithSpace(int Number, ref Graphics G, int raio, int pontos, bool Pri = true, Pen Color = null)
        {
            double SpaceValue = ConvertToRadius(7d);

            double Livre = (2 * Math.PI) - (Number * SpaceValue * 2);
            double TamanhoPorParte = Livre / Number;
            double PositionAngle = Pri ? SpaceValue : 2 * SpaceValue + (TamanhoPorParte / 2);

            for (int i = 0; i < Number; i++)
            {
                if (i != 0)
                    PositionAngle += SpaceValue;

                DoDraw(ref G, raio, pontos, PositionAngle, PositionAngle + TamanhoPorParte, Color);
                DrawSegments(ref G, raio, PositionAngle, PositionAngle + TamanhoPorParte, Number, Color);
                PositionAngle += TamanhoPorParte + SpaceValue;
            }
        }

        private void DrawSegments(ref Graphics G, int Raio, double StartAngle, double EndAngle, int Number, Pen Color = null)
        {
            var Pen = Color ?? new Pen(Brushes.DarkBlue, 3f);
            double CorrectionFactor = Number >= 6 ? (ConvertToRadius(10) * (1 / Number * 4)) : ConvertToRadius(0);
            List<Ponto> StartPoints = new List<Ponto>
            {
                GetPoint(StartAngle, Raio, (P_Desenho.Width / 2), (P_Desenho.Height / 2)),
                GetPoint(EndAngle, Raio, (P_Desenho.Width / 2), (P_Desenho.Height / 2))
            };

            List<Ponto> EndPoints = new List<Ponto>();
            double FractionAngle = ((EndAngle - StartAngle) / 8) + CorrectionFactor;
            double FractionRaio = Number >= 6 ? Raio * 0.10d : Raio * 0.08d;
            //procedure BEGIN_LINE:
            EndPoints.Add(GetPoint(StartAngle + FractionAngle, Raio - FractionRaio, (P_Desenho.Width / 2), (P_Desenho.Height / 2)));
            //procedure END_LINE:
            EndPoints.Add(GetPoint(EndAngle - FractionAngle, Raio + FractionRaio, (P_Desenho.Width / 2), (P_Desenho.Height / 2)));

            //Draw Lines
            G.DrawLine(Pen, ConvertPoint(StartPoints[0]), ConvertPoint(EndPoints[0]));
            G.DrawLine(Pen, ConvertPoint(StartPoints[1]), ConvertPoint(EndPoints[1]));
        }

        private double ConvertToRadius(double Degress)
        {
            return Degress * Math.PI / 180;
        }

        public Point ConvertPoint(Ponto P)
        {
            return new Point((int)P.XValue, (int)P.YValue);
        }

        private Quadrante GetLocation(double Angle)
        {
            if (Angle >= 0 && Angle < ConvertToRadius(90))
                return Quadrante.I;
            else if (Angle >= ConvertToRadius(90) && Angle < ConvertToRadius(180))
                return Quadrante.II;
            else if (Angle >= ConvertToRadius(180) && Angle < ConvertToRadius(270))
                return Quadrante.III;
            else if (Angle >= ConvertToRadius(270) && Angle < ConvertToRadius(360))
                return Quadrante.IV;
            else
                return Quadrante.NONE;
        }

        private Ponto GetPoint(double Angle, double Raio, double XCorrectionFactor = 0, double YCorrectionFactor = 0)
        {
            return new Ponto(XCorrectionFactor + Raio * Math.Cos(Angle), YCorrectionFactor - Raio * Math.Sin(Angle));
        }

        public class Ponto
        {
            public double XValue { get; set; }
            public double YValue { get; set; }

            public Ponto(double xValue, double yValue)
            {
                XValue = xValue;
                YValue = yValue;
            }
        }

        [Flags]

        private enum Quadrante : int
        {
            NONE = 0,
            I = 1,
            II = 2,
            III = 3,
            IV = 4
        }
    }
}
