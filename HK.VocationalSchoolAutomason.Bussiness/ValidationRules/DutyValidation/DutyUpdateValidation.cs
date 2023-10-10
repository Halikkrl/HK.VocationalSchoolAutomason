using FluentValidation;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.DutiesDtos;

namespace HK.VocationalSchoolAutomason.Bussiness.ValidationRules.DutyValidation
{
    public class DutyUpdateValidation : AbstractValidator<DutyUpdateDto>
    {
        public DutyUpdateValidation()
        {
            RuleFor(d => d.Id)
                .NotEmpty().WithMessage("ID boş olamaz.")
                .GreaterThan(0).WithMessage("Geçerli bir ID giriniz.");

            RuleFor(d => d.Name)
                .NotEmpty().WithMessage("Görev adı boş olamaz.")
                .MaximumLength(100).WithMessage("Görev adı en fazla 100 karakter içerebilir.");
        }
    }
}
