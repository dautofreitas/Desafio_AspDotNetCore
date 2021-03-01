using AutoMapper;
using Desafio.Entidade;
using Desafio.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Desafio.Infra.Maper
{
    public class ContaProfile : Profile
    {
        public ContaProfile() {
            CreateMap<Conta, PostContaModel>();
            CreateMap<PostContaModel, Conta>();
            CreateMap<Conta, GetContaModel>();
        }
    }
}
