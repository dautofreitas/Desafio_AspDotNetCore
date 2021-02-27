using AutoMapper;
using Desafio.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Desafio.Infra.Maper
{
    public class ContaProfile : Profile
    {
        public ContaProfile() {
            CreateMap<Conta, ContaModel>();
            CreateMap<ContaModel, Conta>();
        }
    }
}
