using FluentValidation;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.EmployeeDtos;

namespace HK.VocationalSchoolAutomason.Bussiness.ValidationRules.EmployeeValidation
{
    public class EmployeeUpdateValidation : AbstractValidator<EmployeeUpdateDto>
    {
        public EmployeeUpdateValidation()
        {
            RuleFor(e => e.Id)
                .NotEmpty().WithMessage("ID boş olamaz.")
                .GreaterThan(0).WithMessage("Geçerli bir ID giriniz.");

            RuleFor(e => e.IdentificationNumber)
                .NotEmpty().WithMessage("Kimlik numarası boş olamaz.")
                .Length(11).WithMessage("Kimlik numarası 11 karakter olmalıdır.");

            RuleFor(e => e.FirstName)
                .NotEmpty().WithMessage("Ad alanı boş olamaz.")
                .MaximumLength(50).WithMessage("Ad alanı en fazla 50 karakter içerebilir.");

            RuleFor(e => e.LastName)
                .NotEmpty().WithMessage("Soyad alanı boş olamaz.")
                .MaximumLength(50).WithMessage("Soyad alanı en fazla 50 karakter içerebilir.");

            RuleFor(e => e.Gender)
                .NotEmpty().WithMessage("Cinsiyet alanı boş olamaz.");

            RuleFor(e => e.DateOfBirthDay)
                .NotEmpty().WithMessage("Doğum tarihi boş olamaz.")
                .Must(BeAValidDate).WithMessage("Geçerli bir tarih giriniz.");

            RuleFor(x => x.Photo)
                .Null().When(x => x.Photo == null).WithMessage("Fotoğraf alanı boş bırakılabilir.");

            RuleFor(e => e.DateOfIssue)
                .NotEmpty().WithMessage("Veriliş tarihi boş olamaz.")
                .Must(BeAValidDate).WithMessage("Geçerli bir tarih giriniz.");

        }

        private bool BeAValidDate(DateTime date)
        {
            return date != default(DateTime);
        }
    }
}
