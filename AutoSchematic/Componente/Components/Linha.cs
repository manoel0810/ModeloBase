using System.Drawing;
using static ModeloBase.Componente.Controle;

namespace AutoSchematic.Componente.Components
{
    internal class Linha
    {
        public Linha()
        {
            Legend = false;
        }

        public string Name { get; set; }
        public string ID { get; set; }
        public Pen LineColor { get; set; }
        public float LineSize { get; set; }
        public LineType LineModel { get; set; }
        public PointF[] FistLine { get; set; }
        public PointF[] SecundLine { get; set; }
        public bool Legend { get; set; }

        //Segment Properties (used to point-point line)
        public PointF FistPoint { get; set; }
        public PointF LastPoint { get; set; }
    }
}
