using DevelopmentChallenge.Data.Enum;

namespace DevelopmentChallenge.Data.Classes
{
    public class Cuadrado : FormaGeometrica
    {
        public override string NombreForma => Properties.Messages.cuadrado;

        public decimal ladoA { get; set; }

        public Cuadrado(Forma tipo, decimal a) : base(tipo, a)
        {
            Tipo = (int)tipo;
            ladoA = a;
        }

        public override decimal CalcularArea()
        {
            return ladoA * ladoA;
        }

        public override decimal CalcularPerimetro()
        {
            return ladoA * 4;
        }
    }
}
