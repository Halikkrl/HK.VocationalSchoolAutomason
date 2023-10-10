using FluentValidation;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.BranchDtos;

namespace HK.VocationalSchoolAutomason.Bussiness.ValidationRules.BranchValidation
{
    public class BranchUpdateValidation : AbstractValidator<BranchUpdatedto>
    {
        public BranchUpdateValidation()
        {
            RuleFor(dto => dto.Id)
                .NotEmpty().WithMessage("Branş ID boş olamaz.")
                .GreaterThan(0).WithMessage("Branş ID geçerli bir değer olmalıdır.");

            RuleFor(dto => dto.Name)
                .NotEmpty().WithMessage("Branş adı boş olamaz.")
                .MaximumLength(255).WithMessage("Branş adı 255 karakteri geçemez.");
        }
    }
}
