using FluentValidation;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.LevelDtos;

namespace HK.VocationalSchoolAutomason.Bussiness.ValidationRules.LevelValidation
{
    public class LevelUpdateValidation : AbstractValidator<LevelUpdateDto>
    {
        public LevelUpdateValidation()
        {
            RuleFor(dto => dto.Id)
                .GreaterThan(0).WithMessage("Geçerli bir seviye kimliği sağlanmalıdır.");

            RuleFor(dto => dto.Name)
                .NotEmpty().WithMessage("Seviye adı boş olamaz.")
                .MaximumLength(50).WithMessage("Seviye adı en fazla 50 karakter olabilir.");
        }
    }
}
