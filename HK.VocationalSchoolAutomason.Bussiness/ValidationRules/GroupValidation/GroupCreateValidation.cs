using FluentValidation;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.GroupDtos;

namespace HK.VocationalSchoolAutomason.Bussiness.ValidationRules.GroupValidation
{
    public class GroupCreateValidation : AbstractValidator<GroupCreateDto>
    {
        public GroupCreateValidation()
        {
            RuleFor(dto => dto.Name)
                .NotEmpty().WithMessage("Grup adı boş olamaz.")
                .MaximumLength(50).WithMessage("Grup adı en fazla 50 karakter olabilir.");
        }
    }
}
