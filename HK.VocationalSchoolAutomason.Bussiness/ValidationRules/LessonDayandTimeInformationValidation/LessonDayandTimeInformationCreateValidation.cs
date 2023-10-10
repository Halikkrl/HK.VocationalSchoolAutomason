using FluentValidation;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.LessonDayandTimeInformationDtos;

namespace HK.VocationalSchoolAutomason.Bussiness.ValidationRules.LessonDayandTimeInformationValidation
{
    public class LessonDayandTimeInformationCreateValidation : AbstractValidator<LessonDayandTimeInformationCreateDto>
    {
        public LessonDayandTimeInformationCreateValidation()
        {
            RuleFor(dto => dto.DayId)
                .NotEmpty().WithMessage("Gün ID boş olamaz.")
                .GreaterThan(0).WithMessage("Geçerli bir gün ID girilmelidir.");

            RuleFor(dto => dto.WeekLessonHoursId)
                .NotEmpty().WithMessage("Haftalık ders saat ID boş olamaz.")
                .GreaterThan(0).WithMessage("Geçerli bir haftalık ders saat ID girilmelidir.");
        }
    }
}
