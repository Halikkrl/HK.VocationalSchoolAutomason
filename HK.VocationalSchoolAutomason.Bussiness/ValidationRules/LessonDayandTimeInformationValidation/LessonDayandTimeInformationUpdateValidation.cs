using FluentValidation;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.LessonDayandTimeInformationDtos;

namespace HK.VocationalSchoolAutomason.Bussiness.ValidationRules.LessonDayandTimeInformationValidation
{
    public class LessonDayandTimeInformationUpdateValidation : AbstractValidator<LessonDayandTimeInformationUpdateDto>
    {
        public LessonDayandTimeInformationUpdateValidation()
        {
            RuleFor(dto => dto.Id)
                .NotEmpty().WithMessage("ID boş olamaz.")
                .GreaterThan(0).WithMessage("Geçerli bir ID girilmelidir.");

            RuleFor(dto => dto.DayId)
                .NotEmpty().WithMessage("Gün ID boş olamaz.")
                .GreaterThan(0).WithMessage("Geçerli bir gün ID girilmelidir.");

            RuleFor(dto => dto.WeeklyLessonHoursId)
                .NotEmpty().WithMessage("Haftalık ders saat ID boş olamaz.")
                .GreaterThan(0).WithMessage("Geçerli bir haftalık ders saat ID girilmelidir.");
        }
    }
}
