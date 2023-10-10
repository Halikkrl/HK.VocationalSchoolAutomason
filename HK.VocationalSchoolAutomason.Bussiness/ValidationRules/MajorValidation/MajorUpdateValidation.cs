using FluentValidation;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.MajorDtos;

namespace HK.VocationalSchoolAutomason.Bussiness.ValidationRules.MajorValidation
{
    public class MajorUpdateValidation : AbstractValidator<MajorUpdateDto>
    {
        public MajorUpdateValidation()
        {
            RuleFor(dto => dto.Id)
                .GreaterThan(0).WithMessage("Geçerli bir anahtar kimliği sağlanmalıdır.");

            RuleFor(dto => dto.MajorName)
                .NotEmpty().WithMessage("Anahtar alan boş olamaz.")
                .MaximumLength(50).WithMessage("Anahtar alanı en fazla 50 karakter olabilir.");
        }
    }
}
