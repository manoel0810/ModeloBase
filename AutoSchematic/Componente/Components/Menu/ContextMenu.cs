using ModeloBase.Componente;
using System;
using System.Windows.Forms;

namespace AutoSchematic.Componente.Components.Menu
{
    internal class ContextMenu : IDisposable
    {
        public int ExitCode { get; set; }
        public int Index { get; set; }
        public BobinaProps _Props = new BobinaProps();
        public ContextMenuStrip contextMenu = new ContextMenuStrip();

        public ContextMenu(BobinaProps Props2, int Index)
        {
            var editarItem = new ToolStripMenuItem("Editar");
            var apagarItem = new ToolStripMenuItem("Apagar");
            var propriedadesItem = new ToolStripMenuItem("Propriedades (Bobina)");

            editarItem.Enabled = false;
            apagarItem.Enabled = false;
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
