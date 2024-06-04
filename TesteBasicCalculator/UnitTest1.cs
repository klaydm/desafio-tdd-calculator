using System;
using Xunit;
using BasicCalculator;

namespace TesteBasicCalculator
{
    public class UnitTest1
    {
        public Calculadora construirClasse()
        {
            string data = "07/11/2023";
            Calculadora calc = new Calculadora(data);
            return calc;
        }

        [Theory]
        [InlineData(2, 3, 5)]
        [InlineData(5, 6, 11)]
        public void TesteSomar(int num1, int num2, int resultado)
        {
            Calculadora calc = construirClasse();

            int resultadoCalculadora = calc.Somar(num1, num2);

            Assert.Equal(resultado, resultadoCalculadora);
        }

        [Theory]
        [InlineData(5, 2, 3)]
        [InlineData(11, 6, 5)]
        public void TesteSubtrair(int num1, int num2, int resultado)
        {
            Calculadora calc = construirClasse();

            int resultadoCalculadora = calc.Subtrair(num1, num2);

            Assert.Equal(resultado, resultadoCalculadora);
        }

        [Theory]
        [InlineData(2, 3, 6)]
        [InlineData(5, 6, 30)]
        public void TesteMultiplicar(int num1, int num2, int resultado)
        {
            Calculadora calc = construirClasse();

            int resultadoCalculadora = calc.Multiplicar(num1, num2);

            Assert.Equal(resultado, resultadoCalculadora);
        }

        [Theory]
        [InlineData(6, 3, 2)]
        [InlineData(30, 5, 6)]
        public void TesteDividir(int num1, int num2, int resultado)
        {
            Calculadora calc = construirClasse();

            int resultadoCalculadora = calc.Dividir(num1, num2);

            Assert.Equal(resultado, resultadoCalculadora);
        }

        [Fact]
        public void TestarDivisaoPorZero()
        {
            Calculadora calc = construirClasse();

            Assert.Throws<DivideByZeroException>(
                () => calc.Dividir(3, 0)
            );
        }

        [Fact]
        public void TestarHistorico()
        {
            Calculadora calc = construirClasse();

            calc.Somar(2, 3);
            calc.Somar(4, 5);
            calc.Somar(1, 6);
            calc.Somar(7, 8);

            var lista = calc.Historico();

            Assert.NotEmpty(lista);
            Assert.Equal(3, lista.Count);
        }
    }
}
