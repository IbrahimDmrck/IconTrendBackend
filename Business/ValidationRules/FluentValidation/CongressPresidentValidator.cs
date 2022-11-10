using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class CongressPresidentValidator : AbstractValidator<CongressPresident>
    {
        public CongressPresidentValidator()
        {
         
            RuleFor(x => x.CongressPresidentName).MinimumLength(2).WithMessage("Kongre Başkanı Adı En Az 2 Karakter Olabilir");
            RuleFor(x => x.CongressPresidentName).MaximumLength(50).WithMessage("Kongre Başkanı Adı En Fazla 50 Karakter Olabilir");
        }
    }
}
