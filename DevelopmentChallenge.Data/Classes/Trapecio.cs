using DevelopmentChallenge.Data.Enum;

namespace DevelopmentChallenge.Data.Classes
{
    public class Trapecio : FormaGeometrica
    {
        public override string NombreForma => Properties.Messages.trapecio;

        public decimal ladoA { get; set; }
        public decimal ladoB { get; set; }
        public decimal ladoC { get; set; }
        public decimal ladoD { get; set; }
        public decimal altura { get; set; }

        public Trapecio(Forma tipo, decimal a, decimal b, decimal c, decimal d, decimal h) : base(tipo, a) 
        { 
            Tipo = (int)tipo; 
            ladoA = a; 
            ladoB = b; 
            ladoC = c; 
            ladoD = d; 
            altura = h; 
        }

        public override decimal CalcularArea()
        {
            return ((ladoB+ladoD)/2) * altura;
        }

        public override decimal CalcularPerimetro()
        {            
            return ladoA + ladoB + ladoC + ladoD;
        }
    }
}
