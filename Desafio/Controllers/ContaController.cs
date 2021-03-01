using AutoMapper;
using Desafio.Entidade;
using Desafio.Model;
using Desafio.Negocio;
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
        private IContaNegocio _contaNegocio;
        public ContaController(IContaNegocio contaNegocio, IMapper mapper)
        {
            _contaNegocio = contaNegocio;
            _mapper = mapper;
        }      

        [HttpGet]        
        public ActionResult<IEnumerable<GetContaModel>> GetAll()
        {
            var contas = _mapper.Map<IEnumerable<Conta>, IEnumerable<GetContaModel>>(_contaNegocio.RetornaTodasContas());

            if (contas.Count() == 0)
            {
                return NotFound();
            }

            return Ok(contas);

        }
        [HttpPost]
        public IActionResult Isert(PostContaModel contaModel)
        {
            
            Conta conta = _mapper.Map<Conta>(contaModel);
            _contaNegocio.CriarConta(conta);
            return Ok();

        }
    }
}
