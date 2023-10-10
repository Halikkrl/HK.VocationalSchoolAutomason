using FluentValidation;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.ClassRoomsDtos;

namespace HK.VocationalSchoolAutomason.Bussiness.ValidationRules.ClassRoomValidation
{
    public class ClassRoomUpdateValidation : AbstractValidator<ClassRoomUpdateDto>
    {
        public ClassRoomUpdateValidation()
        {
            RuleFor(dto => dto.Id)
                .NotEmpty().WithMessage("Sınıf ID boş olamaz.")
                .GreaterThan(0).WithMessage("Geçerli bir sınıf ID girilmelidir.");

            RuleFor(dto => dto.Name)
                .NotEmpty().WithMessage("Sınıf adı boş olamaz.")
                .MaximumLength(255).WithMessage("Sınıf adı en fazla 255 karakter olmalıdır.");
        }
    }
}
