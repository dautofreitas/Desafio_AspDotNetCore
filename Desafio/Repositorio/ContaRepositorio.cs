using Desafio.Dados;
using Desafio.Entidade;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Desafio.Repositorio
{
    public class ContaRepositorio : IContaRepositorio
    {
       
        private readonly DbSet<Conta> _entity;
        private readonly ApplicationContext _context;

        public ContaRepositorio(ApplicationContext applicationContext)
        {
            _context = applicationContext;
            _entity = applicationContext.Set<Conta>();
        }

        public IEnumerable<Conta> GetAll()
        {
            return _entity.AsEnumerable();

        }
        public void Isert(Conta conta)
        {
            _entity.Add(conta);
            _context.SaveChanges();
        }
    }
}
