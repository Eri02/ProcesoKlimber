using DevelopmentChallenge.Data.Enum;
using System;

namespace DevelopmentChallenge.Data.Classes
{
    public class Circulo : FormaGeometrica
    {
        public override string NombreForma => Properties.Messages.circulo;

        public decimal radio { get; set; }

        public Circulo(Forma tipo, decimal a) : base(tipo, a)
        {
            Tipo = (int)tipo;
            radio = a;
        }

        public override decimal CalcularArea()
        {
            return (decimal)Math.PI * (radio / 2) * (radio / 2);           
        }

        public override decimal CalcularPerimetro()
        {
            return (decimal)Math.PI * radio;             
        }
    }
}
