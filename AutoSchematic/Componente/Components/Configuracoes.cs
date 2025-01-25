using System.Drawing;
using static ModeloBase.Componente.Controle;

namespace AutoSchematic.Componente.Components
{
    public class Configuracoes
    {
        public double FREE_SPACE = 7d;
        public double LOW_GRADE_CORRECTION = 10d;
        public double HIGH_GRADE_CORRECTION = 0d;
        public double MAJOR_RADIUS_CORRECTION = 0.10d;
        public double SMALLER_RADIUS_CORRECTION = 0.08d;

        public int STAMP_WIDTH = 180;
        public int STAMP_HEIGHT = 90;
        public int DRECEMENT_CORRECTION_FACTOR = 4;
        public int LIMIT_FACTOR = 8;
        public int POINT_SIZE = 10;
        public int POINT_MARGIN = 1;
        public int RENDER_POINTS = 32;
        public int SMOOTH_ITERATIONS = 1;
        public int Y_LEGEND_START = 20;
        public int X_LEGEND_START = 20;
        public int Y_LEGEND_ITERATOR = 15;
        public int Y_LEGEND_SUB_ITERATOR = 5;
        public int LEGEND_LINE_SIZE = 80;
        public float LEGEND_LINE_HEIGHT = 8f;
        public float LINE_WIDTH = 2f;

        public bool USE_SMOOTH = true;
        public bool DRAW_LATTERS = true;
        public bool STAMP = true;
        public bool LEGEND_LINE = true;
        public bool TRIFASIC = true;

        public string INFO = "ESQUEMA MOTOR ELÉTRICO";
        public string MODEL = "MODELO";

        public Font STAMP_FONT = new Font("Consolas", 8f, FontStyle.Bold);
        public DateFormt DateFormat = DateFormt.Long;

        public Color BACKGROUND_COLOR_PLANE = Color.AliceBlue;
        public Color BACKGROUND_COLOR_CARIMBO = Color.Yellow;
        public Color X_AXIS_COLOR = Color.Blue;
        public Color Y_AXISCOLOR = Color.Red;
    }
}
