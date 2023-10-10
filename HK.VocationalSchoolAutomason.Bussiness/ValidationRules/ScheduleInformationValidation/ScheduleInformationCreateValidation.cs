using FluentValidation;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.ScheduleInformationDtos;

namespace HK.VocationalSchoolAutomason.Bussiness.ValidationRules.ScheduleInformationValidation
{
    public class ScheduleInformationCreateValidation : AbstractValidator<ScheduleInformationCreateDto>
    {
        public ScheduleInformationCreateValidation()
        {
            RuleFor(dto => dto.SemesterWeeksId).NotEmpty().WithMessage("Dönem haftaları ID gereklidir.");
            RuleFor(dto => dto.WeeklyScheduleId).NotEmpty().WithMessage("Haftalık program ID gereklidir.");

            // Özel doğrulama kuralları ekleyebilirsiniz, örneğin, ID'lerin pozitif olması gerektiği gibi.
            RuleFor(dto => dto.SemesterWeeksId).GreaterThan(0).WithMessage("Dönem haftaları ID pozitif bir değer olmalıdır.");
            RuleFor(dto => dto.WeeklyScheduleId).GreaterThan(0).WithMessage("Haftalık program ID pozitif bir değer olmalıdır.");

            // IsCompleted özelliği için özel doğrulama kuralları ekleyebilirsiniz.
            // Örneğin, IsCompleted true ise AbsentStudentId boş olmamalıdır veya IsCompleted false ise AbsentStudentId boş olmalıdır.
            When(dto => dto.IsCompleted, () =>
            {
                RuleFor(dto => dto.AbsentStudentId).NotEmpty().WithMessage("Eksik öğrenci ID gereklidir.");
                RuleFor(dto => dto.AbsentStudentId).GreaterThan(0).WithMessage("Eksik öğrenci ID pozitif bir değer olmalıdır.");
            }).Otherwise(() =>
            {
                RuleFor(dto => dto.AbsentStudentId).Empty().WithMessage("Eksik öğrenci ID boş olmalıdır.");
            });
        }
    }
}
