using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class BankAccountInfoValidator:AbstractValidator<BankAccountInfo>
    {
        public BankAccountInfoValidator()
        {
            RuleFor(x=>x.AccountNumber).NotEmpty().WithMessage("Hesap Numarası Alanı Boş Bırakılamaz");
            RuleFor(x=>x.Address).NotEmpty().WithMessage("Adres Alanı Boş Bırakılamaz");
            RuleFor(x=>x.BankCode).NotEmpty().WithMessage("Banka Swift Kodu Alanı Boş Bırakılamaz");
            RuleFor(x=>x.Branch).NotEmpty().WithMessage("Şube Alanı Boş Bırakılamaz");
            RuleFor(x=>x.Country).NotEmpty().WithMessage("Ülke Alanı Boş Bırakılamaz");
            RuleFor(x=>x.Description).NotEmpty().WithMessage("Açıklama Alanı Boş Bırakılamaz");
        
        }
    }
}
