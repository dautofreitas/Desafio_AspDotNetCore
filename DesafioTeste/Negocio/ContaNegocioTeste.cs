using Desafio.Entidade;
using Desafio.Negocio;
using Desafio.Repositorio;
using FluentAssertions;
using Moq;
using System;
using Xunit;

namespace DesafioTeste
{
    public class ContaNegocioTeste
    {
        ContaNegocio contaNegocio;
        Moq.Mock<IContaRepositorio> mock;
        public ContaNegocioTeste()
        {
            mock = new Moq.Mock<IContaRepositorio>();
            contaNegocio= new ContaNegocio(mock.Object);
        }
        [Theory]
        [InlineData("2020-02-26", "2020-02-28", 100,0.1,2,102.2)]
        [InlineData("2020-02-24", "2020-02-28", 100, 0.2, 3, 103.8)]
        [InlineData("2020-02-22", "2020-02-28", 100, 0.3, 5, 106.8)]        
        public void CriarContaComAtraso(string dataVencimento, string dataPagamento, decimal valorOriginal, decimal porcentagemJurosDia, decimal porcentagemMulta, decimal valorCorrigido)
        {
            Conta conta = new Conta
            {
                Nome = "Test",
                DataVencimento = DateTime.Parse(dataVencimento),
                DataPagamento = DateTime.Parse(dataPagamento),
                ValorOriginal = valorOriginal
            };

            contaNegocio.CriarConta(conta);

            conta.PorcentagemJurosDia.Should().Be(porcentagemJurosDia);
            conta.PorcentagemMulta.Should().Be(porcentagemMulta);
            conta.ValorCorrigido.Should().Be(valorCorrigido);

            mock.Verify(r => r.Isert(conta), Times.Exactly(1));


        }       


    }
}
