using System.Drawing;

namespace AutoSchematic.Componente.Components
{
    public class Bobina
    {
        public int Raio = 180;
        public int Bobinas = 4;
        public ModeloBase.Componente.Controle.Type Funcao = ModeloBase.Componente.Controle.Type.Primaria;
        public Pen Color = new Pen(Brushes.DarkBlue, 1.5f);

        public Bobina() { /* empty */ }

        public Bobina(int Raio, int Bobinas, ModeloBase.Componente.Controle.Type Funcao = ModeloBase.Componente.Controle.Type.Primaria, Pen Color = null)
        {
            if (Raio == 0)
                throw new AutoSchematicArgumentException("The radius of the circle must be greater than zero", "Raio");
            else if (Bobinas == 0)
                throw new AutoSchematicArgumentException("the number of coils must be greater than zero", "Bobinas");

            this.Raio = Raio;
            this.Bobinas = Bobinas;
            this.Funcao = Funcao;
            this.Color = Color ?? this.Color;
        }
    }
}
