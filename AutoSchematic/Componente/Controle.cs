using AutoSchematic.Componente;
using AutoSchematic.Componente.Components;
using AutoSchematic.Componente.Components.Math;
using AutoSchematic.Componente.Components.Menu;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;
using ContextMenu = AutoSchematic.Componente.Components.Menu.ContextMenu;

namespace ModeloBase.Componente
{
    public partial class Controle : UserControl
    {
        internal SmoothBazier AlgoritmoBazier = new SmoothBazier();
        internal static Configuracoes Parametros = new Configuracoes();
        internal static Bobina[] Bobinas = new Bobina[0x2];
        internal static ContextMenu Contexto = null;
        internal static ContextMenuPointLine ContextoLine = null;
        internal static ContextMenuPlane ContextoPlane = null;

        internal static readonly List<BobinaProps> Props = new List<BobinaProps>();
        internal static readonly List<GraphicsPath> GraphicsPathMap = new List<GraphicsPath>();
        internal static readonly List<GraphicsPath> GraphicsPathPoint = new List<GraphicsPath>();
        internal static readonly List<GraphicsPath> GraphicsPathLine = new List<GraphicsPath>();
        internal static readonly List<Linha> Linhas = new List<Linha>();
        internal static readonly List<Linha> LinhasPonto = new List<Linha>();
        private static Argument[] Pontos = new Argument[0x2];
        internal static PointF[] PontosSegmento = new PointF[] { new PointF(-1, -1), new PointF(-1, -1) };

        private static MouseEventArgs MouseArgs = null;
        private static Bitmap IMG = new Bitmap(80, 80);
        private static Graphics G = Graphics.FromImage(IMG);

        internal static int LastPointLineSelected = -1;
        internal static int SelectedIndex = -1;

        private static int LastSelectedIndex = -1;
        private static int CharNumber = 65; // (char)CharNumber => 'A' | ASCII
        private static int CountFase = 1;
        private static int CountLine = 1;
        private static bool INITIALIZED = false;
        private static bool CTRL = false;
        private static bool DRAW_GUIDE_LINE = false;
        private static bool DRAW_GUIDE_POINT = false;

        internal static Color LastColorState = Color.Violet;
        internal static Color LastPointLineColorState = Color.Black;

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
                Pnts[i] = Helper.ConvertPointF(PontosList[i]);

            if (Parametros.USE_SMOOTH)
            {
                var LIST = Pnts.ToList();
                for (int i = 0; i < Parametros.SMOOTH_ITERATIONS; i++)
                    LIST = AlgoritmoBazier.SmoothCurve(LIST);

                var OBJ = new GraphicsPath();
                OBJ.AddCurve(LIST.ToArray());
                GraphicsPathMap.Add(OBJ);

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
            double SpaceValue = Helper.ConvertToRadius(Parametros.FREE_SPACE);
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
            double CorrectionFactor = Number >= 6 ? (Helper.ConvertToRadius(Parametros.LOW_GRADE_CORRECTION) * (1 / Number * Parametros.DRECEMENT_CORRECTION_FACTOR)) : Helper.ConvertToRadius(Parametros.HIGH_GRADE_CORRECTION);
            List<Ponto> StartPoints = new List<Ponto>
            {
                Helper.GetPoint(StartAngle, Raio, (Width / 2), (Height / 2)),
                Helper.GetPoint(EndAngle, Raio, (Width / 2), (Height / 2))
            };

            List<Ponto> EndPoints = new List<Ponto>();
            double FractionAngle = ((EndAngle - StartAngle) / Parametros.LIMIT_FACTOR) + CorrectionFactor;
            double FractionRaio = Number >= 6 ? Raio * Parametros.MAJOR_RADIUS_CORRECTION : Raio * Parametros.SMALLER_RADIUS_CORRECTION;
            //procedure BEGIN_LINE:
            EndPoints.Add(Helper.GetPoint(StartAngle + FractionAngle, Raio - FractionRaio, (Width / 2), (Height / 2)));
            //procedure END_LINE:
            EndPoints.Add(Helper.GetPoint(EndAngle - FractionAngle, Raio + FractionRaio, (Width / 2), (Height / 2)));

            //Draw Lines
            Linhas.Add(new Linha()
            {
                LineColor = Pen,
                FistLine = new PointF[] { Helper.ConvertPoint(StartPoints[0]), Helper.ConvertPoint(EndPoints[0]) },
                SecundLine = new PointF[] { Helper.ConvertPoint(StartPoints[1]), Helper.ConvertPoint(EndPoints[1]) },
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

        #region Initializations

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


        #endregion

        public void DrawPlane()
        {
            IMG = new Bitmap(Width, Height);

            if (G != null)
            {
                G.Dispose();
                G = Graphics.FromImage(IMG);
            }

            G.PageUnit = GraphicsUnit.Pixel;
            G.FillRectangle(new SolidBrush(Parametros.BACKGROUND_COLOR_PLANE), new Rectangle(0, 0, Width, Height));
            G.DrawLine(new Pen(new SolidBrush(Parametros.X_AXIS_COLOR)), new Point(0, Height / 2), new Point(Width, Height / 2));
            G.DrawLine(new Pen(new SolidBrush(Parametros.Y_AXISCOLOR)), new Point(Width / 2, 0), new Point(Width / 2, Height));
            G.CompositingQuality = CompositingQuality.HighQuality;
            BackgroundImage = IMG;
        }

        public static void DrawPoints()
        {
            int Passo = 0;
            int Count = 1;
            foreach (var T in Pontos)
                try
                {
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
                catch
                {
                    //none
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
                G.DrawLine(new Pen(LinhasPonto[i].LineColor.Brush, (Parametros.LINE_WIDTH != LinhasPonto[i].LineColor.Width ? LinhasPonto[i].LineColor.Width : Parametros.LINE_WIDTH)), LinhasPonto[i].FistPoint, LinhasPonto[i].LastPoint);

            DrawPoints();
            if (DRAW_GUIDE_LINE)
            {
                var Tamanho = Parametros.POINT_SIZE + (Parametros.POINT_SIZE / 6);
                G.FillEllipse(Brushes.Green, MouseArgs.X - Tamanho / 2, MouseArgs.Y - Tamanho / 2, Tamanho, Tamanho);
                G.DrawLine(Pens.Green, new Point(MouseArgs.X - 200, MouseArgs.Y), new Point(MouseArgs.X + 200, MouseArgs.Y));
                G.DrawLine(Pens.Green, new Point(MouseArgs.X, MouseArgs.Y - 200), new Point(MouseArgs.X, MouseArgs.Y + 200));
                DRAW_GUIDE_LINE = false;
            }

            if (DRAW_GUIDE_POINT)
            {
                var Tamanho = Parametros.POINT_SIZE + (Parametros.POINT_SIZE / 6);
                G.FillEllipse(Brushes.Green, MouseArgs.X - Tamanho / 2, MouseArgs.Y - Tamanho / 2, Tamanho, Tamanho);
                DRAW_GUIDE_POINT = false;
            }
        }

        public void DrawImage(int ClickIndex = -1)
        {
            if (INITIALIZED == false)
            {
                Parametros.X_LEGEND_START = Width - 100; //initial value for load_function
                SelectedIndex = -1;
                if (GraphicsPathMap.Count > 0)
                    for (int i = GraphicsPathMap.Count - 1; i > -1; i--)
                        GraphicsPathMap.RemoveAt(i);

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
                    try
                    {
                        if (T.Pontos.Count > 0)
                        {
                            foreach (var P in T.Pontos)
                            {
                                int x = (int)P.PointX;
                                int y = (int)P.PointY;
                                int tamanho = (int)P.PointSize;
                                GraphicsPath VAR = new GraphicsPath();
                                VAR.AddEllipse(x - tamanho / 2, y - tamanho / 2, tamanho, tamanho);
                                GraphicsPathPoint.Add(VAR);
                            }
                        }
                    }
                    catch
                    {
                        //none
                    }


                DrawObject();
                INITIALIZED = true;

                if (Parametros.STAMP)
                    DrawCarimbo();

                if (Parametros.LEGEND_LINE)
                    DrawLineLegend();
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

                if (Parametros.STAMP)
                    DrawCarimbo();

                if (Parametros.LEGEND_LINE)
                    DrawLineLegend();
            }
        }

        public void DrawCarimbo()
        {
            Point InitPoint = new Point(Width - Parametros.STAMP_WIDTH, Height - Parametros.STAMP_HEIGHT);
            Point FinalPoint = new Point(Width, Height);
            var REC = new Rectangle(InitPoint.X, InitPoint.Y, FinalPoint.X, FinalPoint.Y);

            G.FillRectangle(new SolidBrush(Parametros.BACKGROUND_COLOR_CARIMBO), REC);
            G.DrawRectangle(new Pen(Brushes.Black, 1f), REC);
            float Incremento = Parametros.STAMP_HEIGHT / 4;
            float Position = 0f;

            G.DrawLine(new Pen(Brushes.Black, 1f), new PointF(InitPoint.X, InitPoint.Y + Incremento + Position), new PointF(Width, InitPoint.Y + Incremento + Position));
            G.DrawString(Parametros.INFO, Parametros.STAMP_FONT, Brushes.Black, InitPoint.X + 3, InitPoint.Y + Incremento / 4);
            Position = Incremento;
            G.DrawLine(new Pen(Brushes.Black, 1f), new PointF(InitPoint.X, InitPoint.Y + Incremento + Position), new PointF(Width, InitPoint.Y + Incremento + Position));
            Position = Incremento;
            G.DrawLine(new Pen(Brushes.Black, 1f), new PointF(InitPoint.X + (Width - InitPoint.X) / 2, InitPoint.Y + Position), new PointF(InitPoint.X + (Width - InitPoint.X) / 2, InitPoint.Y + Position + Incremento));
            Position = Incremento;

            G.DrawString(Parametros.MODEL, Parametros.STAMP_FONT, Brushes.Black, InitPoint.X + 3, InitPoint.Y + Incremento + Position / 4);
            G.DrawString(Parametros.TRIFASIC ? "TRIFÁSICO" : "MONOFÁSICO", Parametros.STAMP_FONT, Brushes.Black, InitPoint.X + 3 + (Width - InitPoint.X) / 2, InitPoint.Y + Incremento + Position / 4);
            Position = Incremento;

            G.DrawLine(new Pen(Brushes.Black, 1f), new PointF(InitPoint.X, InitPoint.Y + 2 * Incremento + Position), new PointF(Width, InitPoint.Y + 2 * Incremento + Position));
            Position = Incremento;
            G.DrawLine(new Pen(Brushes.Black, 1f), new PointF(InitPoint.X + (Width - InitPoint.X) / 2, InitPoint.Y + 2 * Position), new PointF(InitPoint.X + (Width - InitPoint.X) / 2, InitPoint.Y + 2 * Position + Incremento));
            Position = Incremento;

            try
            {
                G.DrawString($"PRI. {Bobinas[0].Bobinas}", Parametros.STAMP_FONT, Brushes.Black, InitPoint.X + 3, InitPoint.Y + Incremento + Position + (Position / 4));
            }
            catch (Exception)
            {
                throw new AutoSchematicArgumentNullException("Bobinas[0]", "Array of type 'Coils' not loaded for current instance");
            }

            try
            {
                G.DrawString($"AUX. {Bobinas[1].Bobinas}", Parametros.STAMP_FONT, Brushes.Black, InitPoint.X + 3 + (Width - InitPoint.X) / 2, InitPoint.Y + Incremento + Position + (Position / 4));
            }
            catch
            {
                G.DrawString($"AUX. ---", Parametros.STAMP_FONT, Brushes.Black, InitPoint.X + 3 + (Width - InitPoint.X) / 2, InitPoint.Y + Incremento + Position + (Position / 4));
            }

            Position = Incremento;
            string Date = Parametros.DateFormat == DateFormt.Long ? DateTime.Now.ToLongDateString() : DateTime.Now.ToShortDateString();
            G.DrawString(Date, Parametros.STAMP_FONT, Brushes.Black, InitPoint.X + 3, InitPoint.Y + Incremento + 2 * Position + (Incremento / 4));

        }

        public void DrawLineLegend()
        {
            int YPosition = Parametros.Y_LEGEND_START;
            int YIterator = Parametros.Y_LEGEND_ITERATOR;
            int YIteratorSubSegment = Parametros.Y_LEGEND_SUB_ITERATOR;
            int XPosition = Parametros.X_LEGEND_START;

            foreach (var item in LinhasPonto)
            {
                if (item.Legend)
                {
                    G.DrawString($"{item.ID} - {item.Name}", Parametros.STAMP_FONT, Brushes.Black, new Point(XPosition, YPosition));
                    YPosition += YIterator;
                    G.DrawLine(new Pen(item.LineColor.Brush, Parametros.LEGEND_LINE_HEIGHT), new Point(XPosition, YPosition), new Point(XPosition + Parametros.LEGEND_LINE_SIZE, YPosition));
                    YPosition += YIteratorSubSegment;
                }
            }
        }

        private void VerifyClick(MouseEventArgs e)
        {
            Initialize();
            PointF P = new PointF(e.X, e.Y);
            int index = -1, index2 = -1;
            int ACC1 = -1, ACC2 = -1;

            try
            {
                ACC1 = Bobinas[0].Bobinas;
                ACC2 = Bobinas[1].Bobinas;
            }
            catch
            {
                if (ACC1 == 0 && ACC2 == 0)
                    throw new AutoSchematicArgumentException("Object 'Coil' to render was not passed or is invalid. At least one argument was expected", "ACC1/ACC2");
            }


            if (INITIALIZED)
            {
                if (LastPointLineSelected != -1)
                {
                    LinhasPonto[LastPointLineSelected].LineColor = new Pen(LastPointLineColorState, LinhasPonto[LastPointLineSelected].LineColor.Width);
                    LastPointLineSelected = -1;
                }

                for (int i = 0; i < GraphicsPathLine.Count; i++)
                {
                    if (GraphicsPathLine[i].IsOutlineVisible(new PointF(e.X, e.Y), new Pen(Brushes.Black, 5f)))
                    {
                        index2 = i;
                        break;
                    }
                }

                if (index2 != -1 && (LinhasPonto.Count - 1) >= index2)
                {
                    LastPointLineSelected = index2;
                    LastPointLineColorState = LinhasPonto[index2].LineColor.Color;
                    LinhasPonto[index2].LineColor = new Pen(Brushes.DarkGreen, LinhasPonto[index2].LineColor.Width);
                }

                for (int i = 0; i < GraphicsPathPoint.Count; i++)
                {
                    if (GraphicsPathPoint[i].PointCount > 0 && GraphicsPathPoint[i].IsVisible(new PointF(e.X, e.Y)))
                    {
                        index = i;
                        break;
                    }

                    if (PontosSegmento[0].X != -1 && CTRL)
                        index = 0;
                }

                if (index != -1)
                {
                    if (PontosSegmento[0].X == -1 && PontosSegmento[1].X == -1 && CTRL == false)
                    {
                        PontosSegmento[0] = new PointF(e.X, e.Y);
                        Cursor = Cursors.Cross;

                        MouseArgs = e;
                        DRAW_GUIDE_POINT = true;
                    }
                    else if (PontosSegmento[0].X == -1 && PontosSegmento[1].X == -1 && CTRL == true)
                    {
                        PontosSegmento[0] = new PointF(e.X, e.Y);
                        Cursor = Cursors.Cross;

                        MouseArgs = e;
                        DRAW_GUIDE_LINE = true;
                    }
                    else if (PontosSegmento[0].X != -1 && PontosSegmento[1].X == -1)
                    {
                        if (Math.Abs(e.X + (Parametros.POINT_MARGIN / 2)) > Parametros.POINT_MARGIN && Math.Abs(e.Y + (Parametros.POINT_MARGIN / 2)) > Parametros.POINT_MARGIN)
                        {
                            if (CTRL)
                            {
                                var Dx = Math.Abs(PontosSegmento[0].X - e.X);
                                var Dy = Math.Abs(PontosSegmento[0].Y - e.Y);

                                if (Math.Abs(Dx - Dy) <= 20)
                                    PontosSegmento[1] = new PointF(e.X, e.Y);
                                else if (Dx > Dy)
                                    PontosSegmento[1] = new PointF(e.X, PontosSegmento[0].Y);
                                else if (Dx < Dy)
                                    PontosSegmento[1] = new PointF(PontosSegmento[0].X, e.Y);
                            }
                            else
                                PontosSegmento[1] = new PointF(e.X, e.Y);
                        }
                        else
                        {
                            Cursor = Cursors.Default;
                            PontosSegmento[0] = new PointF(-1, -1);
                        }

                        if (PontosSegmento[1].X != -1)
                        {
                            var Line = new Linha()
                            {
                                FistPoint = PontosSegmento[0],
                                LastPoint = PontosSegmento[1],
                                LineColor = new Pen(Brushes.Black, Parametros.LINE_WIDTH),
                                Name = "LINE",
                                ID = $"L{CountLine}"
                            };

                            LinhasPonto.Add(Line);
                            var PLine = new GraphicsPath();
                            PLine.AddLine(Line.FistPoint, Line.LastPoint);
                            GraphicsPathLine.Add(PLine);


                            CountLine++;
                            Cursor = Cursors.Default;
                        }


                        PontosSegmento[0] = new PointF(-1, -1);
                        PontosSegmento[1] = new PointF(-1, -1);
                    }
                }

                index = -1;
            }


            for (int i = 0; i < GraphicsPathMap.Count; i++)
                if (GraphicsPathMap[i].IsOutlineVisible(P, new Pen(Brushes.Red, 15f)))
                {
                    index = i;
                    break;
                }

            DrawImage(index);
            if (e.Button == MouseButtons.Right && index != -1)
                ShowContext(e, index, 0);
            else if (e.Button == MouseButtons.Right && index2 != -1)
                ShowContext(e, index2, 1);
            else if (e.Button == MouseButtons.Right && index == -1)
                ShowContext(e, index, 2);

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

        private void ShowContext(MouseEventArgs e, int Index, int Model)
        {
            if (Model == 0)
            {
                var OBJ = Props[Index];
                OBJ.Pens = LastColorState;
                Contexto?.Dispose();

                Contexto = new ContextMenu(OBJ, Index);
                Contexto.contextMenu.Show(this, e.Location);
            }
            else if (Model == 1)
            {
                ContextoLine = new ContextMenuPointLine(Index, Width, Height);
                ContextoLine.contextMenu.Show(this, e.Location);
            }
            else if (Model == 2)
            {
                ContextoPlane = new ContextMenuPlane(Width, Height);
                ContextoPlane.contextMenu.Show(this, e.Location);
            }
        }

        public void Reload(bool ReloadProps = true)
        {
            if (ReloadProps)
                Parametros = new Configuracoes();

            Bobinas = new Bobina[0x2];
            Contexto = null;
            ContextoLine = null;
            ContextoPlane = null;

            if (GraphicsPathMap.Count > 0)
                for (int i = GraphicsPathMap.Count - 1; i > -1; i--)
                    GraphicsPathMap.RemoveAt(i);

            if (GraphicsPathLine.Count > 0)
                for (int i = GraphicsPathLine.Count - 1; i > -1; i--)
                    GraphicsPathLine.RemoveAt(i);

            if (GraphicsPathPoint.Count > 0)
                for (int i = GraphicsPathPoint.Count - 1; i > -1; i--)
                    GraphicsPathPoint.RemoveAt(i);

            if (Linhas.Count > 0)
                for (int i = Linhas.Count - 1; i > -1; i--)
                    Linhas.RemoveAt(i);

            if (Props.Count > 0)
                for (int i = Props.Count - 1; i > -1; i--)
                    Props.RemoveAt(i);

            if (LinhasPonto.Count > 0)
                for (int i = LinhasPonto.Count - 1; i > -1; i--)
                    LinhasPonto.RemoveAt(i);

            Pontos = new Argument[0x2];
            PontosSegmento = new PointF[] { new PointF(-1, -1), new PointF(-1, -1) };

            LastPointLineSelected = -1;
            SelectedIndex = -1;
            LastSelectedIndex = -1;
            CharNumber = 65;
            CountFase = 1;
            CountLine = 1;
            INITIALIZED = false;
        }

        private void Controle_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 17)
            {
                Cursor = Cursors.Cross;
                CTRL = true;
            }
        }

        private void Controle_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 17)
            {
                Cursor = Cursors.Default;
                CTRL = false;
            }
        }

        public Image GetImage()
        {
            return IMG;
        }

        #region FlagsStruct

        private struct Argument
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

        public enum DateFormt : int
        {
            Long,
            Short
        }

        #endregion

        #region Acessos
        public void SetBobinas(Bobina[] Bobina)
        { Bobinas = Bobina; }
        public bool IsInitialized() { return INITIALIZED; }

        #endregion       
    }
}
