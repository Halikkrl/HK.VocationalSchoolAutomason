using FluentValidation;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.Parent_Information;

namespace HK.VocationalSchoolAutomason.Bussiness.ValidationRules.Parent_InformationValidation
{
    public class Parent_InformationUpdateValidation : AbstractValidator<Parent_InformationUpdate>
    {
        public Parent_InformationUpdateValidation()
        {
            RuleFor(p => p.Id)
                .NotEmpty().WithMessage("Id alanı boş olamaz.")
                .GreaterThan(0).WithMessage("Id alanı 0'dan büyük bir değer olmalıdır.");

            RuleFor(p => p.Proximity)
                .NotEmpty().WithMessage("Proximity alanı boş olamaz.")
                .MaximumLength(50).WithMessage("Proximity alanı en fazla 50 karakter olabilir.");

            RuleFor(p => p.FirstName)
                .NotEmpty().WithMessage("FirstName alanı boş olamaz.")
                .MaximumLength(50).WithMessage("FirstName alanı en fazla 50 karakter olabilir.");

            RuleFor(p => p.LastName)
                .NotEmpty().WithMessage("LastName alanı boş olamaz.")
                .MaximumLength(50).WithMessage("LastName alanı en fazla 50 karakter olabilir.");

            RuleFor(p => p.PhoneNumber)
                .NotEmpty().WithMessage("PhoneNumber alanı boş olamaz.")
                .Matches(@"^\d{10}$").WithMessage("PhoneNumber alanı 10 haneli olmalıdır.");

            RuleFor(p => p.IdentificationNumber)
                .NotEmpty().WithMessage("IdentificationNumber alanı boş olamaz.")
                .Length(11).WithMessage("IdentificationNumber alanı 11 karakter olmalıdır.")
                .Matches(@"^\d{11}$").WithMessage("IdentificationNumber alanı sadece rakamlardan oluşmalıdır.");

        }
    }
}
