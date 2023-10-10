using FluentValidation;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.LevelDtos;

namespace HK.VocationalSchoolAutomason.Bussiness.ValidationRules.LevelValidation
{
    public class LevelCreateValidation : AbstractValidator<LevelCreateDto>
    {
        public LevelCreateValidation()
        {
            RuleFor(dto => dto.Name)
                .NotEmpty().WithMessage("Seviye adı boş olamaz.")
                .MaximumLength(50).WithMessage("Seviye adı en fazla 50 karakter olabilir.");
        }
    }
}
