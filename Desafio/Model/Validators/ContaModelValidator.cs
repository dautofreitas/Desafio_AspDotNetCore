using Desafio.Entidade;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Desafio.Model.Validators
{
    public class ContaModelValidator:AbstractValidator<ContaModel>
    {
        public ContaModelValidator()
        {
            string messageFieldEmpty = "Não pode ser fazio";
            this.
            RuleFor(m => m.Nome).NotEmpty().WithMessage(messageFieldEmpty);
            RuleFor(m => m.DataPagamento).NotEmpty().WithMessage(messageFieldEmpty);
            RuleFor(m => m.DataVencimento).NotEmpty().WithMessage(messageFieldEmpty);
            RuleFor(m => m.QuantidadeDiasAtraso).NotNull().WithMessage(messageFieldEmpty);
            RuleFor(m => m.ValorOriginal).NotNull().WithMessage(messageFieldEmpty);


        }
    }
}
