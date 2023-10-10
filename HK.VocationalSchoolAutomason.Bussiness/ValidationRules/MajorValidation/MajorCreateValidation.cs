using FluentValidation;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.MajorDtos;

namespace HK.VocationalSchoolAutomason.Bussiness.ValidationRules.MajorValidation
{
    public class MajorCreateValidation : AbstractValidator<MajorCreateDto>
    {
        public MajorCreateValidation()
        {
            RuleFor(dto => dto.MajorName)
                .NotEmpty().WithMessage("Anahtar alan boş olamaz.")
                .MaximumLength(50).WithMessage("Anahtar alanı en fazla 50 karakter olabilir.");
        }
    }
}
