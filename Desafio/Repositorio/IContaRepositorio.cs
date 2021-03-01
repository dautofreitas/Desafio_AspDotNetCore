using Desafio.Entidade;
using System.Collections.Generic;

namespace Desafio.Repositorio
{
    public interface IContaRepositorio
    {
        IEnumerable<Conta> GetAll();
        void Isert(Conta conta);
    }
}