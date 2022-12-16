using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class ContactValidator:AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(x => x.Email).NotEmpty().EmailAddress().WithMessage("Lütfen E-posta adresinizi giriniz");
            RuleFor(x=>x.NameSurname).NotEmpty().WithMessage("Lütfen Ad-Soyad bilgilerinizi giriniz");
            RuleFor(x=>x.NameSurname).MinimumLength(2).WithMessage("En az 2 karakter girebilirsiniz");
            RuleFor(x=>x.NameSurname).MaximumLength(50).WithMessage("En fazla 50 karakter girebilirisiniz");
            RuleFor(X=>X.Message).NotEmpty().WithMessage("Lütfen Mesajınızı Giriniz");
            RuleFor(X=>X.Message).MinimumLength(10).WithMessage("Lütfen en az 10 karakter giriniz");
            RuleFor(X=>X.Message).MaximumLength(200).WithMessage("En fazla 200 karakter girebilirsiniz");
        }
    }
}
