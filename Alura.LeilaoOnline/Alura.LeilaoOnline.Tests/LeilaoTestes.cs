﻿using Alura.LeilaoOnline.Core;
using Xunit;

namespace Alura.LeilaoOnline.Tests
{
    public class LeilaoTestes
    {
        [Fact]
        public void LeilaoSemLances()
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
        public void LeilaoComVariosLances(double valorEsperado, double[] ofertas)
        {
            //Arrange - cenário
            var leilao = new Leilao("Van Gogh");
            var fulano = new Interessada("Fulano", leilao);
            
            foreach (var valor in ofertas)
            {
                leilao.RecebeLance(fulano, valor);
            }

            //Act - método sob teste
            leilao.TerminaPregao();

            //Assert            
            var valorObtido = leilao.Gannhador.Valor;
            Assert.Equal(valorEsperado, valorObtido);
        }
    }
}
