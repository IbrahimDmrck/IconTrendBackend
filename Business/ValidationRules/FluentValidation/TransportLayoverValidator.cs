using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class TransportLayoverValidator : AbstractValidator<TransportLayover>
    {
        public TransportLayoverValidator()
        {
            RuleFor(x => x.Capacity).NotEmpty().WithMessage("Bu alanı boş geçemezsiniz");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Bu alanı boş geçemezsiniz");
            RuleFor(x => x.MinDemand).NotEmpty().WithMessage("Bu alanı boş geçemezsiniz");
            RuleFor(x => x.Price).NotEmpty().WithMessage("Bu alanı boş geçemezsiniz");
          
        }
    }
}
