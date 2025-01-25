using System.Drawing;

namespace AutoSchematic.Componente.Components.Math
{
    internal static class Helper
    {
        public static double ConvertToRadius(double Degress)
        {
            return Degress * System.Math.PI / 180;
        }

        public static Point ConvertPoint(Ponto P)
        {
            if (P == null)
                throw new AutoSchematicArgumentNullException("P");

            return new Point((int)P.PointX, (int)P.PointY);
        }

        public static PointF ConvertPointF(Ponto P)
        {
            if (P == null)
                throw new AutoSchematicArgumentNullException("P");

            return new PointF((float)P.PointX, (float)P.PointY);
        }

        public static Ponto GetPoint(double Angle, double Raio, double XCorrectionFactor = 0, double YCorrectionFactor = 0)
        {
            return new Ponto(XCorrectionFactor + Raio * System.Math.Cos(Angle), YCorrectionFactor - Raio * System.Math.Sin(Angle));
        }
    }
}
