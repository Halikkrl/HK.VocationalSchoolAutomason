using FluentValidation;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.ClassRoomsDtos;

namespace HK.VocationalSchoolAutomason.Bussiness.ValidationRules.ClassRoomValidation
{
    public class ClassRoomCreateValidation : AbstractValidator<ClassRoomCreateDto>
    {
        public ClassRoomCreateValidation()
        {
            RuleFor(dto => dto.Name)
                .NotEmpty().WithMessage("Sınıf adı boş olamaz.")
                .MaximumLength(255).WithMessage("Sınıf adı en fazla 255 karakter olmalıdır.");
        }
    }
}
