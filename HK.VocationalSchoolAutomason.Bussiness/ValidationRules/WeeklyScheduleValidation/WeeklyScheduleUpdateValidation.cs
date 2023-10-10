using FluentValidation;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.WeeklyScheduleDtos;

namespace HK.VocationalSchoolAutomason.Bussiness.ValidationRules.WeeklyScheduleValidation
{
    public class WeeklyScheduleUpdateValidation : AbstractValidator<WeeklyScheduleUpdateDto>
    {
        public WeeklyScheduleUpdateValidation()
        {
            RuleFor(dto => dto.Id).NotEmpty().WithMessage("ID gereklidir.");
            RuleFor(dto => dto.ClassLessonsId).NotEmpty().WithMessage("Ders ID gereklidir.");
            RuleFor(dto => dto.ClassRoomId).NotEmpty().WithMessage("Sınıf ID gereklidir.");
            RuleFor(dto => dto.LessonDayandTimeInformationId).NotEmpty().WithMessage("Ders günü ve saat bilgisi ID gereklidir.");
            RuleFor(dto => dto.EmployeeId).NotEmpty().WithMessage("Personel ID gereklidir.");

        }
    }
}
