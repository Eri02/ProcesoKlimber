using DevelopmentChallenge.Data.Enum;

namespace DevelopmentChallenge.Data.Classes
{
    public class Rectangulo : FormaGeometrica
    {
        public override string NombreForma => Properties.Messages.rectangulo;
        public decimal ladoA { get; set; }
        public decimal ladoB { get; set; }
        public decimal ladoC { get; set; }
        public decimal ladoD { get; set; }

        public Rectangulo(Forma tipo, decimal a, decimal b, decimal c, decimal d) : base(tipo, a)
        {
            Tipo = (int)tipo;
            ladoA = a;
            ladoB = b;
            ladoC = c;
            ladoD = d;
        }

        public override decimal CalcularArea()
        {
            return ladoA * ladoB;         
        }

        public override decimal CalcularPerimetro()
        {
            return ladoA + ladoB + ladoC + ladoD;
        }
    }
}
