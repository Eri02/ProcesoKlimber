using DevelopmentChallenge.Data.Classes;
using DevelopmentChallenge.Data.Enum;
using NUnit.Framework;
using System.Collections.Generic;

namespace DevelopmentChallenge.Data.Tests
{
    [TestFixture]
    public class DataTests
    {
        [TestCase]
        public void TestResumenListaVacia()
        {
            Assert.AreEqual("<h1>Lista vacía de formas!</h1>",
                FormaGeometrica.Imprimir(new List<FormaGeometrica>(), (int)Idioma.Castellano));
        }

        [TestCase]
        public void TestResumenListaVaciaFormasEnIngles()
        {
            Assert.AreEqual("<h1>Empty list of shapes!</h1>",
                FormaGeometrica.Imprimir(new List<FormaGeometrica>(), (int)Idioma.Ingles));
        }

        [TestCase]
        public void TestResumenListaVaciaFormasEnItaliano()
        {
            Assert.AreEqual("<h1>Empty list of shapes!</h1>",
                FormaGeometrica.Imprimir(new List<FormaGeometrica>(), (int)Idioma.Italiano));
        }

        [TestCase]
        public void TestResumenListaConUnCuadrado()
        {
            var cuadrados = new List<FormaGeometrica> {new Cuadrado(Forma.cuadrado, 5)};

            var resumen = FormaGeometrica.Imprimir(cuadrados, (int)Idioma.Castellano);

            Assert.AreEqual("<h1>Reporte de Formas</h1>1 Cuadrado | Area 25 | Perimetro 20 <br/>TOTAL:<br/>1 formas Perimetro 20 Area 25", resumen);
        }

        [TestCase]
        public void TestResumenListaConUnTrapecio()
        {
            var trapecios = new List<FormaGeometrica> { new Trapecio(Forma.trapecio, 2,4,2,8,10) };

            var resumen = FormaGeometrica.Imprimir(trapecios, (int)Idioma.Castellano);

            Assert.AreEqual("<h1>Reporte de Formas</h1>1 Trapecio | Area 60 | Perimetro 16 <br/>TOTAL:<br/>1 formas Perimetro 16 Area 60", resumen);
        }

        [TestCase]
        public void TestResumenListaConUnRectanguloEnIngles()
        {
            var rectangulos = new List<FormaGeometrica> { new Rectangulo(Forma.rectangulo, 2, 4, 2, 4) };

            var resumen = FormaGeometrica.Imprimir(rectangulos, (int)Idioma.Ingles);

            Assert.AreEqual("<h1>Shapes report</h1>1 Rectangle | Area 8 | Perimeter 12 <br/>TOTAL:<br/>1 shapes Perimeter 12 Area 8", resumen);
        }

        [TestCase]
        public void TestResumenListaConMasCuadrados()
        {
            var cuadrados = new List<FormaGeometrica>
            {
                new Cuadrado(Forma.cuadrado, 5),
                new Cuadrado(Forma.cuadrado, 1),
                new Cuadrado(Forma.cuadrado,3)
            };

            var resumen = FormaGeometrica.Imprimir(cuadrados, (int)Idioma.Ingles);

            Assert.AreEqual("<h1>Shapes report</h1>3 Squares | Area 35 | Perimeter 36 <br/>TOTAL:<br/>3 shapes Perimeter 36 Area 35", resumen);
        }

        [TestCase]
        public void TestResumenListaConMasTipos()
        {
            var formas = new List<FormaGeometrica>
            {
                new Cuadrado(Forma.cuadrado,  5),
                new Circulo(Forma.circulo, 3),
                new TrianguloEquilatero(Forma.trianguloEquilatero, 4),
                new Cuadrado(Forma.cuadrado,  2),
                new TrianguloEquilatero(Forma.trianguloEquilatero, 9),
                new Circulo(Forma.circulo, 2.75m),
                new TrianguloEquilatero(Forma.trianguloEquilatero, 4.2m)
            };

            var resumen = FormaGeometrica.Imprimir(formas, (int)Idioma.Ingles);

            Assert.AreEqual(
                "<h1>Shapes report</h1>2 Squares | Area 29 | Perimeter 28 <br/>2 Circles | Area 13,01 | Perimeter 18,06 <br/>3 Triangles | Area 49,64 | Perimeter 51,6 <br/>TOTAL:<br/>7 shapes Perimeter 97,66 Area 91,65",
                resumen);
        }

        [TestCase]
        public void TestResumenListaConMasTiposEnCastellano()
        {
            var formas = new List<FormaGeometrica>
            {
                new Cuadrado(Forma.cuadrado,  5),
                new Circulo(Forma.circulo, 3),
                new TrianguloEquilatero(Forma.trianguloEquilatero, 4),
                new Cuadrado(Forma.cuadrado,  2),
                new TrianguloEquilatero(Forma.trianguloEquilatero, 9),
                new Circulo(Forma.circulo, 2.75m),
                new TrianguloEquilatero(Forma.trianguloEquilatero, 4.2m)
            };

            var resumen = FormaGeometrica.Imprimir(formas, (int)Idioma.Castellano);

            Assert.AreEqual(
                "<h1>Reporte de Formas</h1>2 Cuadrados | Area 29 | Perimetro 28 <br/>2 Círculos | Area 13,01 | Perimetro 18,06 <br/>3 Triángulos | Area 49,64 | Perimetro 51,6 <br/>TOTAL:<br/>7 formas Perimetro 97,66 Area 91,65",
                resumen);
        }

        [TestCase]
        public void TestResumenListaConMasTiposEnItaliano()
        {
            var formas = new List<FormaGeometrica>
            {
                new Cuadrado(Forma.cuadrado,  5),
                new Circulo(Forma.circulo, 3),
                new TrianguloEquilatero(Forma.trianguloEquilatero, 4),
                new Cuadrado(Forma.cuadrado,  2),
                new TrianguloEquilatero(Forma.trianguloEquilatero, 9),
                new Circulo(Forma.circulo, 2.75m),
                new TrianguloEquilatero(Forma.trianguloEquilatero, 4.2m)
            };

            var resumen = FormaGeometrica.Imprimir(formas, (int)Idioma.Italiano);

            Assert.AreEqual(
                "<h1>Rapporto delle forme</h1>2 Quadratos | Area 29 | Perimetro 28 <br/>2 Cerchios | Area 13,01 | Perimetro 18,06 <br/>3 Triangolos | Area 49,64 | Perimetro 51,6 <br/>TOTALE:<br/>7 forme Perimetro 97,66 Area 91,65",
                resumen);
        }
    }
}
