using FluentValidation;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.EmployeeDutyBranchDtos;

namespace HK.VocationalSchoolAutomason.Bussiness.ValidationRules.EmployeeDutyBranchValidation
{
    public class EmployeeDutyBranchUpdateValidation : AbstractValidator<EmployeeDutyBranchUpdateDto>
    {
        public EmployeeDutyBranchUpdateValidation()
        {
            RuleFor(dto => dto.Id)
                .NotEmpty().WithMessage("Çalışan görev branş ID boş olamaz.")
                .GreaterThan(0).WithMessage("Çalışan görev branş ID geçerli bir değer olmalıdır.");

            RuleFor(dto => dto.EmployeeDutyId)
                .NotEmpty().WithMessage("Çalışan görev ID boş olamaz.")
                .GreaterThan(0).WithMessage("Çalışan görev ID geçerli bir değer olmalıdır.");

            RuleFor(dto => dto.BranchId)
                .NotEmpty().WithMessage("Branş ID boş olamaz.")
                .GreaterThan(0).WithMessage("Branş ID geçerli bir değer olmalıdır.");
        }
    }
}
