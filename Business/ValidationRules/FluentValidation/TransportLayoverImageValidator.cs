using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class TransportLayoverImageValidator:AbstractValidator<TransportLayoverImage>
    {
        public TransportLayoverImageValidator()
        {
            RuleFor(x => x.TransportLayoverId).NotEmpty();
            RuleFor(x => x.TransportLayoverId).GreaterThan(0);
        }
    }
}
