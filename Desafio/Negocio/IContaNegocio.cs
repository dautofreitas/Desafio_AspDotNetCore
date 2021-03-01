using Desafio.Entidade;
using System.Collections.Generic;

namespace Desafio.Negocio
{
    public interface IContaNegocio
    {
        void CriarConta(Conta conta);
        IEnumerable<Conta> RetornaTodasContas();
    }
}