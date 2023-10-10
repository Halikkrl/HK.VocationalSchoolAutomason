using FluentValidation;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.BranchDtos;

namespace HK.VocationalSchoolAutomason.Bussiness.ValidationRules.BranchValidation
{
    public class BranchCreateValidation : AbstractValidator<BranchCreateDto>
    {
        public BranchCreateValidation()
        {
            RuleFor(dto => dto.Name)
                .NotEmpty().WithMessage("Branş adı boş olamaz.")
                .MaximumLength(255).WithMessage("Branş adı 255 karakteri geçemez.");
        }
    }
}
