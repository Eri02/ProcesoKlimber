using DevelopmentChallenge.Data.Enum;
using System;

namespace DevelopmentChallenge.Data.Classes
{
    public class TrianguloEquilatero : FormaGeometrica
    {
        public override string NombreForma => Properties.Messages.triangulo;

        public decimal Lado { get; set; }

        public TrianguloEquilatero(Forma tipo, decimal a) : base(tipo, a)
        {
            Tipo = (int)tipo;
            Lado = a;
        }

        public override decimal CalcularArea()
        {
            return ((decimal)Math.Sqrt(3) / 4) * Lado * Lado;              
        }

        public override decimal CalcularPerimetro()
        {
            return Lado * 3;               
        }
    }
}
