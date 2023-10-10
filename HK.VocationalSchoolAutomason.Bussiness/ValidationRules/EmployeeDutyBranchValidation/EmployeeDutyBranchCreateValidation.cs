using FluentValidation;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.EmployeeDutyBranchDtos;

namespace HK.VocationalSchoolAutomason.Bussiness.ValidationRules.EmployeeDutyBranchValidation
{
    public class EmployeeDutyBranchCreateValidation : AbstractValidator<EmployeeDutyBranchCreateDto>
    {
        public EmployeeDutyBranchCreateValidation()
        {
            RuleFor(dto => dto.EmployeeDutyId)
                .NotEmpty().WithMessage("Çalışan görev branş ID boş olamaz.")
                .GreaterThan(0).WithMessage("Çalışan görev branş ID geçerli bir değer olmalıdır.");

            RuleFor(dto => dto.BranchId)
                .NotEmpty().WithMessage("Branş ID boş olamaz.")
                .GreaterThan(0).WithMessage("Branş ID geçerli bir değer olmalıdır.");
        }
    }
}
