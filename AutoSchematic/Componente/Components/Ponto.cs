using System.Drawing;

namespace AutoSchematic.Componente.Components
{
    internal class Ponto
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
}
