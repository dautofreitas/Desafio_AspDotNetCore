using Desafio.Entidade;
using Desafio.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Desafio.Negocio
{
    public class ContaNegocio : IContaNegocio
    {
        private readonly IContaRepositorio _contaRepository;
        public ContaNegocio(IContaRepositorio contaRepository)
        {

            _contaRepository = contaRepository;
        }
        public void CriarConta(Conta conta)
        {
            conta = CalculaAtrasoPagamento(conta);

            _contaRepository.Isert(conta);
        }

        public IEnumerable<Conta> RetornaTodasContas()
        {
            return _contaRepository.GetAll();
        }


        private Conta CalculaAtrasoPagamento(Conta conta)
        {
            conta.QuantidadeDiasAtraso = CalculaDiasAtraso(conta);
            conta = CalculaValorCorrigido(conta);

            return conta;
        }

        private static Conta CalculaValorCorrigido(Conta conta)
        {
            if (conta.QuantidadeDiasAtraso < 1)
                return conta;

            switch (conta.QuantidadeDiasAtraso)
            {
                case int dqDias when dqDias <= 3:
                    conta.PorcentagemMulta = 2;
                    conta.PorcentagemJurosDia = 0.1m;
                    break;

                case int dqDias when dqDias > 3 && dqDias < 6:
                    conta.PorcentagemMulta = 3;
                    conta.PorcentagemJurosDia = 0.2m;
                    break;

                case int dqDias when dqDias > 5:
                    conta.PorcentagemMulta = 5;
                    conta.PorcentagemJurosDia = 0.3m;
                    break;
            }

            conta.ValorCorrigido = conta.ValorOriginal;
            conta.ValorCorrigido += Convert.ToDecimal(conta.ValorOriginal * (conta.PorcentagemMulta/100));
            conta.ValorCorrigido += Convert.ToDecimal((conta.ValorOriginal * (conta.PorcentagemJurosDia/100))* conta.QuantidadeDiasAtraso);

            return conta;
        }

        private int CalculaDiasAtraso(Conta conta) {

            TimeSpan diferenca = conta.DataPagamento.Subtract(conta.DataVencimento);
            return diferenca.Days;
        }



    }
}
