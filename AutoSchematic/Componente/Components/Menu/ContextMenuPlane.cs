using ModeloBase.Componente;
using System;
using System.Windows.Forms;

namespace AutoSchematic.Componente.Components.Menu
{
    internal class ContextMenuPlane : IDisposable
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public ContextMenuStrip contextMenu = new ContextMenuStrip();

        public ContextMenuPlane(int w, int h)
        {
            var propriedadesItem = new ToolStripMenuItem("Propriedades (Plano)");
            propriedadesItem.Click += PropriedadesItem_Click;
            contextMenu.Items.Add(propriedadesItem);

            Width = w;
            Height = h;
        }

        private void PropriedadesItem_Click(object sender, EventArgs e)
        {
            PlaneProps Props = new PlaneProps(Controle.Parametros, new int[] { Height, Width });
            Props.ShowDialog();
            Props.Dispose();
        }

        public void Dispose()
        {
            ((IDisposable)contextMenu).Dispose();
        }
    }
}
