using Alura.LeilaoOnline.Core;
using Xunit;

namespace Alura.LeilaoOnline.Tests
{
    public class LeilaoTerminaPregao
    {
        [Fact]
        public void RetornaZeroDadoLeilaoSemLances()
        {
            //Arrange - cenário            
            var leilao = new Leilao("Van Gogh");
            
            //Act - método sob teste
            leilao.TerminaPregao();

            //Assert            
            var valorEsperado = 0;
            var valorObtido = leilao.Gannhador.Valor;
            Assert.Equal(valorEsperado, valorObtido);            
        }

        [Theory]
        [InlineData(1200, new double[] { 800, 900, 1000, 1200 })]
        [InlineData(1000, new double[] { 800, 900, 1000, 990 })]
        [InlineData(800, new double[] { 800 })]
        public void RetornaMaiorValorDadoLeilaoComPeloMenosUmLance(double valorEsperado, double[] ofertas)
        {
            //Arrange - cenário
            var leilao = new Leilao("Van Gogh");
            var fulano = new Interessada("Fulano", leilao);
            var maria = new Interessada("Maria", leilao);

            leilao.IniciaPregao();
            for (int i = 0; i < ofertas.Length; i++)
            {
                var valor = ofertas[i];
                if ((i % 2) == 0)
                {
                    leilao.RecebeLance(fulano, valor);
                }
                else
                {
                    leilao.RecebeLance(maria, valor);
                }
            }

            //Act - método sob teste
            leilao.TerminaPregao();

            //Assert            
            var valorObtido = leilao.Gannhador.Valor;
            Assert.Equal(valorEsperado, valorObtido);
        }
    }
}
