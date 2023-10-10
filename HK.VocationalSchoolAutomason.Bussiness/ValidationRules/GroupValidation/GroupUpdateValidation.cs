using FluentValidation;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.GroupDtos;

namespace HK.VocationalSchoolAutomason.Bussiness.ValidationRules.GroupValidation
{
    public class GroupUpdateValidation : AbstractValidator<GroupUpdateDto>
    {
        public GroupUpdateValidation()
        {
            RuleFor(dto => dto.Id)
                .GreaterThan(0).WithMessage("Geçerli bir grup kimliği sağlanmalıdır.");

            RuleFor(dto => dto.Name)
                .NotEmpty().WithMessage("Grup adı boş olamaz.")
                .MaximumLength(50).WithMessage("Grup adı en fazla 50 karakter olabilir.");
        }
    }
}
