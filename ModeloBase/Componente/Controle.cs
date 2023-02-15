using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ModeloBase.Componente
{
    public partial class Controle : UserControl
    {
        public Configuracoes Parametros = new Configuracoes();
        public Bobina[] Bobinas = new Bobina[0x2];
        public SmoothBazier AlgoritmoBazier = new SmoothBazier();

        private readonly Argument[] Pontos = new Argument[0x2];
        private readonly List<Linha> Linhas = new List<Linha>();
        private static Bitmap IMG = new Bitmap(80, 80);
        private Graphics G = Graphics.FromImage(IMG);

        public Controle()
        {
            InitializeComponent();
            MouseClick += Controle_MouseClick;
            Rectangle rect = new Rectangle(0, 0, Width, Height);
            Region = new Region(rect);

            BorderStyle = BorderStyle.FixedSingle;
            BackgroundImageLayout = ImageLayout.Center;
        }

        private void Controle_MouseClick(object sender, MouseEventArgs e)
        {
            Initialize();
            Bobinas[0] = new Bobina()
            {
                Color = new Pen(Brushes.DarkBlue, 1.8f),
                Bobinas = 6
            };

            Bobinas[1] = new Bobina()
            {
                Raio = 120,
                Color = new Pen(Brushes.Red, 1.8f),
                Funcao = Type.Auxiliar,
                Bobinas = 6
            };

            DrawImage();
        }

        protected override void OnResize(EventArgs e)
        {
            Rectangle rect = new Rectangle(0, 0, Width, Height);
            Region = new Region(rect);
        }

        public partial class Linha
        {
            public Pen LineColor { get; set; }
            public float LineSize { get; set; }
            public LineType LineModel { get; set; }
        }

        public partial class Ponto
        {
            public Brush PointColor { get; set; }
            public float PointSize { get; set; }
            public double PointX { get; set; }
            public double PointY { get; set; }


            public Ponto(Brush pointColor, float pointSize, double pointX, double pointY)
            {
                PointColor = pointColor;
                PointSize = pointSize;
                PointX = pointX;
                PointY = pointY;
            }

            public Ponto(double PointX, double PointY)
            {
                this.PointX = PointX;
                this.PointY = PointY;
                PointSize = 5;
                PointColor = Brushes.Black;
            }

            public Ponto()
            {
                //empty
            }
        }

        public partial class Configuracoes
        {
            public double ESPACAMENTO_LIVRE = 7d;
            public double FATOR_CORRECAO_BAIXO = 10d;
            public double FATOR_CORRECAO_ALTO = 0d;
            public double FATOR_CORRECAO_RAIO_MAIOR = 0.10d;
            public double FATOR_CORRECAO_RAIO_MENOR = 0.08d;


            public int FATOR_CORRECAO_DECREMENTO = 4;
            public int FATOR_CORRECAO_LIMITACAO = 8;
            public int POINT_SIZE = 10;
            public int RENDER_POINTS = 32;
        }

        public partial class Bobina
        {
            public int Raio = 180;
            public int Bobinas = 4;
            public Type Funcao = Type.Primaria;
            public Pen Color = new Pen(Brushes.DarkBlue, 1.5f);

            public Bobina() { /* empty */ }

            public Bobina(int Raio, int Bobinas, Type Funcao = Type.Primaria, Pen Color = null)
            {
                this.Raio = Raio;
                this.Bobinas = Bobinas;
                this.Funcao = Funcao;
                this.Color = Color ?? this.Color;
            }
        }

        private void DoDraw(ref Graphics G, int Raio, int Pontos, double Angulo = 2 * Math.PI, Pen Pencil = null)
        {
            Pen Color = Pencil ?? Pens.DarkBlue;
            double Razao = Angulo / Pontos;
            double RazaoVariavel = 0;
            List<Ponto> PontosList = new List<Ponto>();
            for (double i = 0; i <= Pontos; i++)
            {
                var P = new Ponto((Width / 2) + (Raio * Math.Cos(RazaoVariavel)), (Height / 2) - (Raio * Math.Sin(RazaoVariavel)));
                PontosList.Add(P);
                RazaoVariavel += Razao;
            }

            Point[] Pnts = new Point[PontosList.Count];
            for (int i = 0; i < PontosList.Count; i++)
            {
                Pnts[i] = ConvertPoint(PontosList[i]);
                /*
                if (PontosList.Count == (i + 1))
                {
                    G.DrawLine(Color, ConvertPoint(PontosList[i - 1]), ConvertPoint(PontosList[i]));
                    G.DrawLine(Color, ConvertPoint(PontosList[i]), ConvertPoint(PontosList[0]));
                }
                else

                    G.DrawLine(Color, ConvertPoint(PontosList[i]), ConvertPoint(PontosList[i + 1]));
                */
            }

            G.DrawCurve(Color, Pnts);
            PontosList.Clear();
        }
        private void DoDraw(ref Graphics G, int Raio, int Pontos, double Begin, double End, Pen Color = null)
        {
            var Pen = Color ?? new Pen(Brushes.DarkBlue, 3f);
            double Angulo = End - Begin;

            double Razao = Angulo / Pontos;
            double RazaoVariavel = Begin;
            List<Ponto> PontosList = new List<Ponto>();
            for (double i = 0; i <= Pontos; i++)
            {
                var P = new Ponto((Width / 2) + (Raio * Math.Cos(RazaoVariavel)), (Height / 2) - (Raio * Math.Sin(RazaoVariavel)));
                PontosList.Add(P);
                RazaoVariavel += Razao;
            }

            PointF[] Pnts = new PointF[PontosList.Count];
            for (int i = 0; i < PontosList.Count; i++)
            {
                Pnts[i] = ConvertPointF(PontosList[i]);
                /*
                if (PontosList.Count == (i + 1))
                    G.DrawLine(Pen, ConvertPoint(PontosList[i - 1]), ConvertPoint(PontosList[i]));
                else
                    G.DrawLine(Pen, ConvertPoint(PontosList[i]), ConvertPoint(PontosList[i + 1]));
                */
            }

            var LIST = Pnts.ToList();
            var TEMP = AlgoritmoBazier.SmoothCurve(LIST).ToArray();
            G.DrawCurve(Pen, TEMP);
            //G.DrawCurve(Pen, Pnts);
            PontosList.Clear();
        }
        private void DrawWithSpace(int Number, ref Graphics G, int raio, int pontos, bool Pri = true, Pen Color = null)
        {
            double SpaceValue = ConvertToRadius(Parametros.ESPACAMENTO_LIVRE);
            double Livre = (2 * Math.PI) - (Number * SpaceValue * 2);
            double TamanhoPorParte = Livre / Number;
            double PositionAngle = Pri ? SpaceValue : 2 * SpaceValue + (TamanhoPorParte / 2);

            for (int i = 0; i < Number; i++)
            {
                if (i != 0)
                    PositionAngle += SpaceValue;

                DoDraw(ref G, raio, pontos, PositionAngle, PositionAngle + TamanhoPorParte, Color);
                DrawSegments(ref G, raio, PositionAngle, PositionAngle + TamanhoPorParte, Number, Pri, Color);
                PositionAngle += TamanhoPorParte + SpaceValue;
            }
        }
        private void DrawSegments(ref Graphics G, int Raio, double StartAngle, double EndAngle, int Number, bool Pri = true, Pen Color = null)
        {
            var Pen = Color ?? new Pen(Brushes.DarkBlue, 3f);
            double CorrectionFactor = Number >= 6 ? (ConvertToRadius(Parametros.FATOR_CORRECAO_BAIXO) * (1 / Number * Parametros.FATOR_CORRECAO_DECREMENTO)) : ConvertToRadius(Parametros.FATOR_CORRECAO_ALTO);
            List<Ponto> StartPoints = new List<Ponto>
            {
                GetPoint(StartAngle, Raio, (Width / 2), (Height / 2)),
                GetPoint(EndAngle, Raio, (Width / 2), (Height / 2))
            };

            List<Ponto> EndPoints = new List<Ponto>();
            double FractionAngle = ((EndAngle - StartAngle) / Parametros.FATOR_CORRECAO_LIMITACAO) + CorrectionFactor;
            double FractionRaio = Number >= 6 ? Raio * Parametros.FATOR_CORRECAO_RAIO_MAIOR : Raio * Parametros.FATOR_CORRECAO_RAIO_MENOR;
            //procedure BEGIN_LINE:
            EndPoints.Add(GetPoint(StartAngle + FractionAngle, Raio - FractionRaio, (Width / 2), (Height / 2)));
            //procedure END_LINE:
            EndPoints.Add(GetPoint(EndAngle - FractionAngle, Raio + FractionRaio, (Width / 2), (Height / 2)));

            //Draw Lines
            G.DrawLine(Pen, ConvertPoint(StartPoints[0]), ConvertPoint(EndPoints[0]));
            G.DrawLine(Pen, ConvertPoint(StartPoints[1]), ConvertPoint(EndPoints[1]));

            if (Pri)
            {
                if (Pontos[0].Pontos == null)
                {
                    Pontos[0].Pontos = new List<Ponto>();
                    Pontos[0].Funcao = Type.Primaria;
                }


                if (Pontos[0].Pontos.Count == (Bobinas[0].Bobinas * 2))
                {
                    Pontos[0] = new Argument()
                    {
                        Funcao = Type.Primaria,
                        Pontos = EndPoints
                    };
                }
                else
                {
                    Pontos[0].Pontos.Add(new Ponto(Pen.Brush, Parametros.POINT_SIZE, EndPoints[0].PointX, EndPoints[0].PointY));
                    Pontos[0].Pontos.Add(new Ponto(Pen.Brush, Parametros.POINT_SIZE, EndPoints[1].PointX, EndPoints[1].PointY));
                }
            }
            else
            {
                if (Pontos[1].Pontos == null)
                {
                    Pontos[1].Pontos = new List<Ponto>();
                    Pontos[1].Funcao = Type.Auxiliar;
                }

                if (Pontos[1].Pontos.Count == (Bobinas[1].Bobinas * 2))
                {
                    Pontos[1] = new Argument()
                    {
                        Funcao = Type.Auxiliar,
                        Pontos = EndPoints
                    };
                }
                else
                {
                    Pontos[1].Pontos.Add(new Ponto(Pen.Brush, Parametros.POINT_SIZE, EndPoints[0].PointX, EndPoints[0].PointY));
                    Pontos[1].Pontos.Add(new Ponto(Pen.Brush, Parametros.POINT_SIZE, EndPoints[1].PointX, EndPoints[1].PointY));
                }
            }
        }
        private double ConvertToRadius(double Degress)
        {
            return Degress * Math.PI / 180;
        }
        public Point ConvertPoint(Ponto P)
        {
            return new Point((int)P.PointX, (int)P.PointY);
        }
        public PointF ConvertPointF(Ponto P)
        {
            return new PointF((float)P.PointX, (float)P.PointY);
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
        public void Initialize(Configuracoes Parametros)
        {
            this.Parametros = Parametros;
            DrawPlane();
        }
        public void Initialize(Configuracoes Parametros, Bobina[] Bobina)
        {
            this.Parametros = Parametros;
            Bobinas = Bobina;
            DrawPlane();
        }
        public void Initialize(Bobina[] Bobina)
        {
            Bobinas = Bobina;
            DrawPlane();
        }
        public void Initialize()
        {
            DrawPlane();
        }
        public void DrawPlane()
        {
            IMG = new Bitmap(Width, Height);

            if (G != null)
            {
                G.Dispose();
                G = Graphics.FromImage(IMG);
            }

            G.PageUnit = GraphicsUnit.Pixel;
            G.FillRectangle(Brushes.AliceBlue, new Rectangle(0, 0, Width, Height));
            G.DrawLine(Pens.Black, new Point(0, Height / 2), new Point(Width, Height / 2));
            G.DrawLine(Pens.Black, new Point(Width / 2, 0), new Point(Width / 2, Height));
            G.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            BackgroundImage = IMG;
        }
        public void DrawPoints()
        {
            foreach (var T in Pontos)
                if (T.Pontos.Count > 0)
                {
                    foreach (var P in T.Pontos)
                    {
                        int x = (int)P.PointX;
                        int y = (int)P.PointY;
                        int tamanho = (int)P.PointSize;

                        G.FillEllipse(P.PointColor, x - tamanho / 2, y - tamanho / 2, tamanho, tamanho);
                    }
                }
        }
        public void DrawImage()
        {
            foreach (var B in Bobinas)
                if (B != null)
                    DrawWithSpace(B.Bobinas, ref G, B.Raio, Parametros.RENDER_POINTS, B.Funcao == Type.Primaria, B.Color);

            DrawPoints();
        }

        public struct Argument
        {
            public List<Ponto> Pontos;
            public Type Funcao;
        }

        [Flags]

        public enum LineType : int
        {
            Normal = 0,
            Point = 1,
            SpacingLine = 2
        }

        public enum Type : int
        {
            Primaria = 0,
            Auxiliar = 1
        }

        private enum Quadrante : int
        {
            NONE = 0,
            I = 1,
            II = 2,
            III = 3,
            IV = 4
        }
    }

    public partial class SmoothBazier
    {
        public List<PointF> SmoothCurve(List<PointF> points)
        {
            List<PointF> smoothedPoints = new List<PointF>();

            if (points.Count < 2)
            {
                smoothedPoints.AddRange(points);
            }
            else
            {
                smoothedPoints.Add(points[0]);

                for (int i = 0; i < points.Count - 1; i++)
                {
                    PointF pt1 = points[i];
                    PointF pt2 = points[i + 1];

                    float distance = (float)Math.Sqrt(Math.Pow(pt2.X - pt1.X, 2) + Math.Pow(pt2.Y - pt1.Y, 2));
                    PointF midPoint = new PointF((pt1.X + pt2.X) / 2, (pt1.Y + pt2.Y) / 2);
                    float step = distance / 4;

                    PointF diff1 = new PointF(midPoint.X - pt1.X, midPoint.Y - pt1.Y);
                    PointF tangent1 = new PointF(diff1.X / step, diff1.Y / step);

                    PointF diff2 = new PointF(pt2.X - midPoint.X, pt2.Y - midPoint.Y);
                    PointF tangent2 = new PointF(diff2.X / step, diff2.Y / step);

                    smoothedPoints.Add(pt1);

                    for (int j = 1; j <= 4; j++)
                    {
                        float t = (float)j / 4;
                        float t2 = t * t;
                        float t3 = t2 * t;
                        float c1 = 2 * t3 - 3 * t2 + 1;
                        float c2 = -2 * t3 + 3 * t2;
                        float c3 = t3 - 2 * t2 + t;
                        float c4 = t3 - t2;
                        float x = c1 * pt1.X + c2 * pt2.X + c3 * tangent1.X + c4 * tangent2.X;
                        float y = c1 * pt1.Y + c2 * pt2.Y + c3 * tangent1.Y + c4 * tangent2.Y;
                        smoothedPoints.Add(new PointF(x, y));
                    }
                }

                smoothedPoints.Add(points[points.Count - 1]);
            }

            return smoothedPoints;
        }
    }
}
