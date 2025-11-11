/******************************************************************************************************************/
/******* ¿Qué pasa si debemos soportar un nuevo idioma para los reportes, o agregar más formas geométricas? *******/
/******************************************************************************************************************/

/*
 * TODO: 
 * Refactorizar la clase para respetar principios de la programación orientada a objetos.
 * Implementar la forma Trapecio/Rectangulo. 
 * Agregar el idioma Italiano (o el deseado) al reporte.
 * Se agradece la inclusión de nuevos tests unitarios para validar el comportamiento de la nueva funcionalidad agregada 
 * (los tests deben pasar correctamente al entregar la solución, incluso los actuales.)
 * Una vez finalizado, hay que subir el código a un repo GIT y ofrecernos la URL para que podamos utilizar la nueva versión :).
 */

using DevelopmentChallenge.Data.Enum;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;

namespace DevelopmentChallenge.Data.Classes
{
    public abstract class FormaGeometrica
    {
        private readonly decimal _lado;
        public abstract string NombreForma { get; }
        public int Tipo { get; set; }

        public abstract decimal CalcularArea();
        public abstract decimal CalcularPerimetro();


        public FormaGeometrica(decimal ladoA, decimal ladoB, decimal ladoC, decimal ladoD, decimal ladoE)
        {

        }

        public FormaGeometrica(Forma tipo, decimal ancho)
        {
            Tipo = (int)tipo;
            _lado = ancho;
        }

        public static void CambiarIdioma(int idioma)
        {
            CultureInfo culture;

            switch (idioma)
            {
                case (int)Idioma.Castellano:
                    culture = new CultureInfo("es");
                    break;

                case (int)Idioma.Ingles:
                    culture = new CultureInfo("en");
                    break;

                case (int)Idioma.Italiano:
                    culture = new CultureInfo("it");
                    break;

                default:
                    culture = new CultureInfo("es");
                    break;
            }

            Thread.CurrentThread.CurrentUICulture = culture;
        }

        public static string Imprimir(IEnumerable<FormaGeometrica> formas, int idioma)
        {
            CambiarIdioma(idioma);

            var lista = formas.ToList();
            if (!lista.Any())
                return Properties.Messages.ListaVacia;

            var sb = new StringBuilder();
            sb.Append(Properties.Messages.Reporte);

            var grupos = lista
                .GroupBy(f => f.Tipo)
                .Select(g => new
                {
                    Tipo = g.Key,
                    Cantidad = g.Count(),
                    Area = g.Sum(x => x.CalcularArea()),
                    Perimetro = g.Sum(x => x.CalcularPerimetro())
                });

            foreach (var g in grupos)
            {
                var nombre = TraducirForma(g.Tipo, g.Cantidad, idioma);
                sb.Append(ObtenerLinea(g.Cantidad, g.Area, g.Perimetro, g.Tipo, idioma));
            }

            // FOOTER
            var totalFormas = lista.Count();
            var totalArea = lista.Sum(f => f.CalcularArea());
            var totalPerimetro = lista.Sum(f => f.CalcularPerimetro());

            sb.Append($"{Properties.Messages.total}");
            sb.Append($"{totalFormas} {Properties.Messages.formas} ");
            sb.Append($"{Properties.Messages.Perimetro} {totalPerimetro:#.##} ");
            sb.Append($"{Properties.Messages.Area} {totalArea:#.##}");

            return sb.ToString();
        }

        private static string ObtenerLinea(int cantidad, decimal area, decimal perimetro, int tipo, int idioma)
        {
            if (cantidad > 0)
            {
                return $"{cantidad} " +
                    $"{TraducirForma(tipo, cantidad, idioma)} | " +
                    $"{ Properties.Messages.Area} {area:#.##} | " +
                    $"{ Properties.Messages.Perimetro} {perimetro:#.##} <br/>";
            }

            return string.Empty;
        }

        private static string TraducirForma(int tipo, int cantidad, int idioma)
        {
            CambiarIdioma(idioma);

            switch (tipo)
            {
                case (int)Forma.cuadrado:
                    return cantidad == 1 ? Properties.Messages.cuadrado : Properties.Messages.cuadrados;
                case (int)Forma.rectangulo:
                   return cantidad == 1 ? Properties.Messages.rectangulo : Properties.Messages.rectangulos;                  
                case (int)Forma.circulo:
                    return cantidad == 1 ? Properties.Messages.circulo : Properties.Messages.circulos;
                case (int)Forma.trianguloEquilatero:                   
                    return cantidad == 1 ? Properties.Messages.triangulo : Properties.Messages.triangulos;
                case (int)Forma.trapecio:
                    return cantidad == 1 ? Properties.Messages.trapecio : Properties.Messages.trapecios;
                default:
                    return string.Empty;
            }            
        }
    }
}
