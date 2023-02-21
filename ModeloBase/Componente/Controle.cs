﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace ModeloBase.Componente
{
    public partial class Controle : UserControl
    {
        public SmoothBazier AlgoritmoBazier = new SmoothBazier();
        public static Configuracoes Parametros = new Configuracoes();
        public static Bobina[] Bobinas = new Bobina[0x2];
        private ContextMenu Context = null;

        public static readonly List<BobinaProps> Props = new List<BobinaProps>();
        public static readonly List<GraphicsPath> GP = new List<GraphicsPath>();
        public static readonly List<GraphicsPath> PGP = new List<GraphicsPath>();
        public static readonly Argument[] Pontos = new Argument[0x2];
        public static readonly List<Linha> Linhas = new List<Linha>();
        public static readonly List<Linha> LinhasPonto = new List<Linha>();
        public static readonly PointF[] PontosSegmento = new PointF[] { new PointF(-1, -1), new PointF(-1, -1) };

        private static Bitmap IMG = new Bitmap(80, 80);
        private static Graphics G = Graphics.FromImage(IMG);

        private int SelectedIndex = -1;
        private int LastSelectedIndex = -1;
        private int CharNumber = 65;
        private int CountFase = 1;
        private bool INITIALIZED = false;

        public static Color LastColorState = Color.Violet;

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
            VerifyClick(e);
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
            public PointF[] FistLine { get; set; }
            public PointF[] SecundLine { get; set; }

            //Segment Properties (used to point-point line)
            public PointF FistPoint { get; set; }
            public PointF LastPoint { get; set; }
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
            public int POINT_MARGIN = 1;
            public int RENDER_POINTS = 16;
            public int SMOOTH_ITERATIONS = 1;
            public float LINE_WIDTH = 2f;

            public bool USE_SMOOTH = true;
            public bool DRAW_LATTERS = true;
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
        private void PrepearDraw(int Raio, int Pontos, double Begin, double End, Pen Color = null)
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
                Pnts[i] = ConvertPointF(PontosList[i]);

            if (Parametros.USE_SMOOTH)
            {
                var LIST = Pnts.ToList();
                for (int i = 0; i < Parametros.SMOOTH_ITERATIONS; i++)
                    LIST = AlgoritmoBazier.SmoothCurve(LIST);

                var OBJ = new GraphicsPath();
                OBJ.AddCurve(LIST.ToArray());
                GP.Add(OBJ);

                var obj = new BobinaProps()
                {
                    Espec = 2f,
                    Latters = (char)CharNumber,
                    Name = $"B{CountFase}",
                    Pens = Pen.Color,
                    Points = LIST.ToArray()
                };

                Props.Add(obj);
            }
            else
            {
                var OBJ = new GraphicsPath();
                OBJ.AddCurve(Pnts);

                var obj = new BobinaProps()
                {
                    Espec = 2f,
                    Latters = (char)CharNumber,
                    Name = $"B{CountFase}",
                    Pens = Pen.Color,
                    Points = Pnts
                };

                Props.Add(obj);
            }

            CountFase++;
            CharNumber++;
            PontosList.Clear();
        }
        private void CreateDrawerObject(int Number, int raio, int pontos, bool Pri = true, Pen Color = null, int ClickIndex = -1)
        {
            double SpaceValue = ConvertToRadius(Parametros.ESPACAMENTO_LIVRE);
            double Livre = (2 * Math.PI) - (Number * SpaceValue * 2);
            double TamanhoPorParte = Livre / Number;
            double PositionAngle = Pri ? SpaceValue : 2 * SpaceValue + (TamanhoPorParte / 2);

            for (int i = 0; i < Number; i++)
            {
                if (i != 0)
                    PositionAngle += SpaceValue;

                if (ClickIndex != -1)
                {
                    if (SelectedIndex == -1)
                        SelectedIndex = 0;

                    if (SelectedIndex == ClickIndex)
                    {
                        PrepearDraw(raio, pontos, PositionAngle, PositionAngle + TamanhoPorParte, new Pen(Brushes.DarkGoldenrod, 3f));
                        PrepearSegmentes(raio, PositionAngle, PositionAngle + TamanhoPorParte, Number, Pri, new Pen(Brushes.DarkGoldenrod, 3f));
                        SelectedIndex = -2;
                        LastSelectedIndex = ClickIndex;
                    }
                    else
                    {
                        PrepearDraw(raio, pontos, PositionAngle, PositionAngle + TamanhoPorParte, Color);
                        PrepearSegmentes(raio, PositionAngle, PositionAngle + TamanhoPorParte, Number, Pri, Color);
                        if (SelectedIndex != -2)
                            SelectedIndex++;
                    }
                }
                else
                {
                    PrepearDraw(raio, pontos, PositionAngle, PositionAngle + TamanhoPorParte, Color);
                    PrepearSegmentes(raio, PositionAngle, PositionAngle + TamanhoPorParte, Number, Pri, Color);
                }

                PositionAngle += TamanhoPorParte + SpaceValue;
            }
        }
        private void PrepearSegmentes(int Raio, double StartAngle, double EndAngle, int Number, bool Pri = true, Pen Color = null)
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
            Linhas.Add(new Linha()
            {
                LineColor = Pen,
                FistLine = new PointF[] { ConvertPoint(StartPoints[0]), ConvertPoint(EndPoints[0]) },
                SecundLine = new PointF[] { ConvertPoint(StartPoints[1]), ConvertPoint(EndPoints[1]) },
                LineModel = LineType.Normal,
                LineSize = Pen.Width
            });

            if (Pri)
            {
                if (Pontos[0].Pontos == null)
                {
                    Pontos[0].Pontos = new List<Ponto>();
                    Pontos[0].Funcao = Type.Primaria;
                }

                if (Pontos[0].Pontos.Count == (Bobinas[0].Bobinas * 2))
                {
                    EndPoints[0].PointColor = Pen.Brush;
                    EndPoints[0].PointSize = Parametros.POINT_SIZE;
                    EndPoints[1].PointColor = Pen.Brush;
                    EndPoints[1].PointSize = Parametros.POINT_SIZE;

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
                    EndPoints[0].PointColor = Pen.Brush;
                    EndPoints[0].PointSize = Parametros.POINT_SIZE;
                    EndPoints[1].PointColor = Pen.Brush;
                    EndPoints[1].PointSize = Parametros.POINT_SIZE;

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
        private Ponto GetPoint(double Angle, double Raio, double XCorrectionFactor = 0, double YCorrectionFactor = 0)
        {
            return new Ponto(XCorrectionFactor + Raio * Math.Cos(Angle), YCorrectionFactor - Raio * Math.Sin(Angle));
        }
        public void Initialize(Configuracoes ParametrosVar)
        {
            Parametros = ParametrosVar;
            DrawPlane();
        }
        public void Initialize(Configuracoes ParametrosVar, Bobina[] Bobina)
        {
            Parametros = ParametrosVar;
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
            G.CompositingQuality = CompositingQuality.HighQuality;
            BackgroundImage = IMG;
        }
        public static void DrawPoints()
        {
            int Passo = 0;
            int Count = 1;
            foreach (var T in Pontos)
                if (T.Pontos.Count > 0)
                {
                    foreach (var P in T.Pontos)
                    {
                        int x = (int)P.PointX;
                        int y = (int)P.PointY;
                        int tamanho = (int)P.PointSize;

                        G.FillEllipse(P.PointColor, x - tamanho / 2, y - tamanho / 2, tamanho, tamanho);
                        string TXT = Passo == 0 ? $"C{Count}" : $"F{Count}";
                        if (Passo == 0)
                            Passo = 1;
                        else if (Passo == 1)
                        {
                            Passo = 0;
                            Count++;
                        }

                        if (Parametros.DRAW_LATTERS)
                            G.DrawString(TXT, new Font("Consolas", 10f, FontStyle.Bold), Brushes.Black, x + tamanho / 2, y - tamanho);
                    }
                }
        }
        public static void DrawObject()
        {
            for (int i = 0; i < Props.Count; i++)
            {
                G.DrawCurve(new Pen(Props[i].Pens, Props[i].Espec), Props[i].Points);
                G.DrawLine(Linhas[i].LineColor, Linhas[i].FistLine[0], Linhas[i].FistLine[1]);
                G.DrawLine(Linhas[i].LineColor, Linhas[i].SecundLine[0], Linhas[i].SecundLine[1]);
            }

            for (int i = 0; i < LinhasPonto.Count; i++)
                G.DrawLine(new Pen(LinhasPonto[i].LineColor.Brush, Parametros.LINE_WIDTH), LinhasPonto[i].FistPoint, LinhasPonto[i].LastPoint);

            DrawPoints();
        }
        public void DrawImage(int ClickIndex = -1)
        {
            if (INITIALIZED == false)
            {
                SelectedIndex = -1;
                if (GP.Count > 0)
                    for (int i = GP.Count - 1; i > -1; i--)
                        GP.RemoveAt(i);

                if (Linhas.Count > 0)
                    for (int i = Linhas.Count - 1; i > -1; i--)
                        Linhas.RemoveAt(i);

                if (Props.Count > 0)
                    for (int i = Props.Count - 1; i > -1; i--)
                        Props.RemoveAt(i);

                foreach (var B in Bobinas)
                    if (B != null)
                        CreateDrawerObject(B.Bobinas, B.Raio, Parametros.RENDER_POINTS, B.Funcao == Type.Primaria, B.Color, ClickIndex);

                foreach (var T in Pontos)
                    if (T.Pontos.Count > 0)
                    {
                        foreach (var P in T.Pontos)
                        {
                            int x = (int)P.PointX;
                            int y = (int)P.PointY;
                            int tamanho = (int)P.PointSize;
                            GraphicsPath VAR = new GraphicsPath();
                            VAR.AddEllipse(x - tamanho / 2, y - tamanho / 2, tamanho, tamanho);
                            PGP.Add(VAR);
                        }
                    }

                DrawObject();
                INITIALIZED = true;
            }
            else
            {
                DrawPlane();
                if (ClickIndex == -1 && LastSelectedIndex == -1)
                    DrawObject();
                else if (ClickIndex == -1 && LastSelectedIndex != ClickIndex)
                {
                    GoBackState(LastSelectedIndex);
                    DrawObject();
                    LastSelectedIndex = -1;
                }
                else if (ClickIndex != -1 && LastSelectedIndex == -1)
                {
                    UpdateObjectList(ClickIndex, Color.Black);
                    DrawObject();
                    LastSelectedIndex = ClickIndex;
                }
                else if (ClickIndex == LastSelectedIndex)
                    DrawObject();
                else if (ClickIndex != -1 && LastSelectedIndex != -1)
                {
                    GoBackState(LastSelectedIndex);
                    UpdateObjectList(ClickIndex, Color.Black);
                    DrawObject();
                    LastSelectedIndex = ClickIndex;
                }
            }
        }
        public void VerifyClick(MouseEventArgs e)
        {
            Initialize();
            Bobinas[0] = new Bobina()
            {
                Raio = 230,
                Color = new Pen(Brushes.DarkBlue, 2f),
                Bobinas = 12
            };

            Bobinas[1] = new Bobina()
            {
                Raio = 150,
                Color = new Pen(Brushes.Red, 2f),
                Funcao = Type.Auxiliar,
                Bobinas = 12
            };

            PointF P = new PointF(e.X, e.Y);
            int index = -1;

            if (INITIALIZED)
            {
                for (int i = 0; i < PGP.Count; i++)
                {
                    if (PGP[i].PointCount > 0 && PGP[i].IsVisible(new PointF(e.X, e.Y)))
                    {
                        index = i;
                        break;
                    }
                }

                if (index != -1)
                {
                    if (PontosSegmento[0].X == -1 && PontosSegmento[1].X == -1)
                        PontosSegmento[0] = new PointF(e.X, e.Y);
                    else if (PontosSegmento[0].X != -1 && PontosSegmento[1].X == -1)
                    {
                        if (Math.Abs(PontosSegmento[0].X - e.X) > Parametros.POINT_MARGIN && Math.Abs(PontosSegmento[0].Y - e.Y) > Parametros.POINT_MARGIN)
                            PontosSegmento[1] = new PointF(e.X, e.Y);

                        if (PontosSegmento[1].X != -1)
                            LinhasPonto.Add(new Linha()
                            {
                                FistPoint = PontosSegmento[0],
                                LastPoint = PontosSegmento[1],
                                LineColor = new Pen(Brushes.Black, Parametros.POINT_SIZE / 2)
                            });

                        PontosSegmento[0] = new PointF(-1, -1);
                        PontosSegmento[1] = new PointF(-1, -1);
                    }
                }

                index = -1;
            }

            for (int i = 0; i < GP.Count; i++)
                if (GP[i].IsOutlineVisible(P, new Pen(Brushes.Red, 15f)))
                {
                    index = i;
                    break;
                }



            DrawImage(index);
            if (e.Button == MouseButtons.Right && index != -1)
                ShowContext(e, index);
        }
        public static void UpdateObjectList(int Index, Color Cor)
        {
            LastColorState = Props[Index].Pens;
            Props[Index].Pens = Cor;
            Linhas[Index].LineColor = new Pen(Props[Index].Pens, Props[Index].Espec);
            Linhas[Index].LineSize = Props[Index].Espec;

            int[] Positions = GetBobinaIndexAndPoint(Index);
            for (int i = 0; i < 2; i++)
                Pontos[Positions[0]].Pontos[Positions[1] + i].PointColor = Linhas[Index].LineColor.Brush;

        }
        public void GoBackState(int LastIndex)
        {
            Props[LastIndex].Pens = LastColorState;
            Linhas[LastIndex].LineColor = new Pen(Props[LastIndex].Pens, Linhas[LastIndex].LineColor.Width);

            int[] Positions = GetBobinaIndexAndPoint(LastIndex);
            for (int i = 0; i < 2; i++)
                Pontos[Positions[0]].Pontos[Positions[1] + i].PointColor = Linhas[LastIndex].LineColor.Brush;
        }
        private static int[] GetBobinaIndexAndPoint(int Index)
        {
            int[] Info = new int[] { -1, -1 };
            if (Index >= 0 && Index <= (Bobinas[0].Bobinas - 1))
            {
                Info[0] = (int)Type.Primaria;
                Info[1] = Index * 2;
            }
            else
            {
                Info[0] = (int)Type.Auxiliar;
                Info[1] = (Index - (Bobinas[0].Bobinas)) * 2;
            }

            return Info;
        }
        private void ShowContext(MouseEventArgs e, int Index)
        {
            var OBJ = Props[Index];
            OBJ.Pens = LastColorState;
            Context?.Dispose();

            Context = new ContextMenu(OBJ, Index);
            Context.contextMenu.Show(this, e.Location);
        }
        public class BobinaProps
        {
            public char Latters { get; set; }
            public string Name { get; set; }
            public PointF[] Points { get; set; }
            public Color Pens { get; set; }
            public float Espec { get; set; }
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

    partial class ContextMenu : IDisposable
    {
        public int ExitCode { get; set; }
        public int Index { get; set; }
        public Controle.BobinaProps _Props = new Controle.BobinaProps();
        public ContextMenuStrip contextMenu = new ContextMenuStrip();

        public ContextMenu(Controle.BobinaProps Props2, int Index)
        {
            var editarItem = new ToolStripMenuItem("Editar");
            var apagarItem = new ToolStripMenuItem("Apagar");
            var propriedadesItem = new ToolStripMenuItem("Propriedades");

            editarItem.Click += EditarItem_Click;
            apagarItem.Click += ApagarItem_Click;
            propriedadesItem.Click += PropriedadesItem_Click;

            contextMenu.Items.Add(editarItem);
            contextMenu.Items.Add(apagarItem);
            contextMenu.Items.Add(propriedadesItem);
            _Props = Props2;
            ExitCode = -1;
            this.Index = Index;
        }

        private void PropriedadesItem_Click(object sender, EventArgs e)
        {
            Prop P = new Prop(_Props);
            P.ShowDialog();
            ExitCode = P.ExitState;
            _Props = P.PropsOutInstance;
            P.Dispose();

            Controle.LastColorState = _Props.Pens;
            Controle.Props[Index] = _Props;
            Controle.UpdateObjectList(Index, _Props.Pens);
            Controle.DrawObject();
        }

        private void ApagarItem_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void EditarItem_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            ((IDisposable)contextMenu).Dispose();
        }
    }
}
