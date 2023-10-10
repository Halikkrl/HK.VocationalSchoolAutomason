using FluentValidation;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.WeeksDtos;

namespace HK.VocationalSchoolAutomason.Bussiness.ValidationRules.WeekValidation
{
    public class WeekUpdateValidation : AbstractValidator<WeekUpdateDto>
    {
        public WeekUpdateValidation()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Hafta ID boş olamaz.")
                .GreaterThan(0).WithMessage("Hafta ID geçerli bir değer olmalıdır.");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Hafta adı boş olamaz.")
                .MaximumLength(255).WithMessage("Hafta adı en fazla 255 karakter olabilir.");
        }
    }
}
