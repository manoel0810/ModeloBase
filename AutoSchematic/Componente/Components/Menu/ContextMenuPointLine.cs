using ModeloBase.Componente;
using System;
using System.Windows.Forms;

namespace AutoSchematic.Componente.Components.Menu
{
    internal class ContextMenuPointLine : IDisposable
    {
        public int ExitCode { get; set; }
        public int Index { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public ContextMenuStrip contextMenu = new ContextMenuStrip();

        public ContextMenuPointLine(int Index, int w, int h)
        {
            var apagarItem = new ToolStripMenuItem("Apagar");
            var propriedadesItem = new ToolStripMenuItem("Propriedades (Linha)");

            apagarItem.Click += ApagarItem_Click;
            propriedadesItem.Click += PropriedadesItem_Click;

            contextMenu.Items.Add(apagarItem);
            contextMenu.Items.Add(propriedadesItem);

            ExitCode = -1;
            Width = w;
            Height = h;

            this.Index = Index;
        }

        private void PropriedadesItem_Click(object sender, EventArgs e)
        {
            LineProps Propriedades = new LineProps(Width, Height, Index);
            Propriedades.ShowDialog();
            Propriedades.Dispose();
        }

        private void ApagarItem_Click(object sender, EventArgs e)
        {
            Controle.LinhasPonto.RemoveAt(Index);
            Controle.GraphicsPathLine.RemoveAt(Index);
            Controle.LastPointLineSelected = -1;
        }

        public void Dispose()
        {
            ((IDisposable)contextMenu).Dispose();
        }
    }
}
