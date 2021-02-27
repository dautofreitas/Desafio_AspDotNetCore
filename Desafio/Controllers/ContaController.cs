using AutoMapper;
using Desafio.Entidade;
using Desafio.Repositorio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Desafio.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContaController : ControllerBase
    {
        private readonly IMapper _mapper;
        private ContaRepository _contaRepository;
        public ContaController(ContaRepository contaRepository, IMapper mapper)
        {
            _contaRepository = contaRepository;
            _mapper = mapper;
        }      

        [HttpGet]        
        public IActionResult GetAll()
        {
            var contas = _mapper.Map<IEnumerable<Conta>, IEnumerable<ContaModel>>(_contaRepository.GetAll());

            if (contas.Count() == 0)
            {
                return NotFound();
            }

            return Ok(contas);

        }
        [HttpPost]
        public IActionResult Isert(ContaModel contaModel)
        {
            
            Conta conta = _mapper.Map<Conta>(contaModel);
            _contaRepository.Isert(conta);
            return Ok();

        }
    }
}
