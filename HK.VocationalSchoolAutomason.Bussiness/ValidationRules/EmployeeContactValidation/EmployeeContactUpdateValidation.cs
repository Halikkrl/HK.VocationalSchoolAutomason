using FluentValidation;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.EmployeeContact;

namespace HK.VocationalSchoolAutomason.Bussiness.ValidationRules.EmployeeContactValidation
{
    public class EmployeeContactUpdateValidation : AbstractValidator<EmployeeContactUpdateDto>
    {
        public EmployeeContactUpdateValidation()
        {
            RuleFor(e => e.Id)
                .NotEmpty().WithMessage("ID boş olamaz.")
                .GreaterThan(0).WithMessage("Geçerli bir ID giriniz.");

            RuleFor(e => e.EmployeeId)
                .NotEmpty().WithMessage("Çalışan ID'si boş olamaz.")
                .GreaterThan(0).WithMessage("Geçerli bir çalışan ID'si giriniz.");

            RuleFor(e => e.City)
                .NotEmpty().WithMessage("Şehir boş olamaz.")
                .MaximumLength(50).WithMessage("Şehir en fazla 50 karakter içerebilir.");

            RuleFor(e => e.District)
                .NotEmpty().WithMessage("İlçe boş olamaz.")
                .MaximumLength(50).WithMessage("İlçe en fazla 50 karakter içerebilir.");

            RuleFor(e => e.Neighbourhood)
                .NotEmpty().WithMessage("Mahalle boş olamaz.")
                .MaximumLength(50).WithMessage("Mahalle en fazla 50 karakter içerebilir.");

            RuleFor(e => e.Address)
                .NotEmpty().WithMessage("Adres boş olamaz.")
                .MaximumLength(200).WithMessage("Adres en fazla 200 karakter içerebilir.");

            RuleFor(e => e.PhoneNumber)
                .NotEmpty().WithMessage("Telefon numarası boş olamaz.")
                .Matches(@"^\d{10}$").WithMessage("Geçerli bir telefon numarası giriniz (örn. 1234567890).");

        }

        private bool BeAValidDate(DateTime date)
        {
            return date != default(DateTime);
        }
    }
}
