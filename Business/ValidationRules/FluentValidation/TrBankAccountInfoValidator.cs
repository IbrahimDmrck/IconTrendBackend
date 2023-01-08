using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class TrBankAccountInfoValidator:AbstractValidator<TrBankAccountInfo>
    {
        public TrBankAccountInfoValidator()
        {
            RuleFor(x=>x.AccountName).NotEmpty().WithMessage("Hesap Adı Alanı Boş Bırakılamaz");
            RuleFor(x=>x.BankName).NotEmpty().WithMessage("Banka Adı Alanı Boş Bırakılamaz");
            RuleFor(x=>x.Description1).NotEmpty().WithMessage("Açıklama Alanı Boş Bırakılamaz");
            RuleFor(x=>x.Description2).NotEmpty().WithMessage("Açıklama Alanı Boş Bırakılamaz");
            RuleFor(x=>x.Iban).NotEmpty().WithMessage("IBAN Alanı Boş Bırakılamaz");
          
        }
    }
}
