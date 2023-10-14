using FluentValidation;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.StudentRegistrationDtos;

namespace HK.VocationalSchoolAutomason.Bussiness.ValidationRules.StudentRegistrationValidation
{
    public class StudentregistrationUpdateValidation : AbstractValidator<StudentregistrationUpdateDto>
    {
        public StudentregistrationUpdateValidation()
        {
            RuleFor(dto => dto.StudentIdentificationNumber)
                .NotEmpty()
                .WithMessage("Öğrenci kimlik numarası gereklidir.");

            RuleFor(dto => dto.StudentFirstName)
                .NotEmpty()
                .WithMessage("Öğrenci adı gereklidir.");

            RuleFor(dto => dto.StudentLastName)
                .NotEmpty()
                .WithMessage("Öğrenci soyadı gereklidir.");

            RuleFor(dto => dto.StudentNumber)
                .GreaterThan(0)
                .WithMessage("Geçerli bir öğrenci numarası gereklidir.");

            RuleFor(dto => dto.StudentGender)
                .NotEmpty()
                .WithMessage("Cinsiyet gereklidir.");

            RuleFor(dto => dto.DateOfBirthDay)
                .NotNull()
                .WithMessage("Doğum tarihi gereklidir.");

            RuleFor(dto => dto.City)
                .NotEmpty()
                .WithMessage("Şehir bilgisi gereklidir.");

            RuleFor(dto => dto.District)
                .NotEmpty()
                .WithMessage("İlçe bilgisi gereklidir.");

            RuleFor(dto => dto.Neighbourhood)
                .NotEmpty()
                .WithMessage("Mahalle bilgisi gereklidir.");

            RuleFor(dto => dto.Address)
                .NotEmpty()
                .WithMessage("Adres gereklidir.");

            RuleFor(dto => dto.ContactPhoneNumber)
                .NotEmpty()
                .WithMessage("İletişim telefon numarası gereklidir.");

            RuleFor(dto => dto.MajorLevelGroupId)
                .GreaterThan(0)
                .WithMessage("Geçerli bir sınıf bilgisi gereklidir.");

            RuleFor(dto => dto.SemesterId)
                .GreaterThan(0)
                .WithMessage("Geçerli bir dönem bilgisi gereklidir.");
        }
    }
}
