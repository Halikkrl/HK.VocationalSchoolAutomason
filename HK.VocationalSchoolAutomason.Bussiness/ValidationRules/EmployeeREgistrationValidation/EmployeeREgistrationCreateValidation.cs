using FluentValidation;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.EmployeeRegistrationDto;

namespace HK.VocationalSchoolAutomason.Bussiness.ValidationRules.EmployeeREgistrationValidation
{
    public class EmployeeREgistrationCreateValidation : AbstractValidator<EmployeeRegistrationCreateDto>
    {
        public EmployeeREgistrationCreateValidation()
        {
            RuleFor(dto => dto.IdentificationNumber)
                .NotEmpty().WithMessage("Kimlik numarası boş olamaz.")
                .MaximumLength(20).WithMessage("Kimlik numarası en fazla 20 karakter olmalıdır.");

            RuleFor(dto => dto.FirstName)
                .NotEmpty().WithMessage("Ad boş olamaz.")
                .MaximumLength(50).WithMessage("Ad en fazla 50 karakter olmalıdır.");

            RuleFor(dto => dto.LastName)
                .NotEmpty().WithMessage("Soyad boş olamaz.")
                .MaximumLength(50).WithMessage("Soyad en fazla 50 karakter olmalıdır.");


            RuleFor(dto => dto.City)
                .NotEmpty().WithMessage("Şehir boş olamaz.")
                .MaximumLength(50).WithMessage("Şehir en fazla 50 karakter olmalıdır.");

            RuleFor(dto => dto.District)
                .NotEmpty().WithMessage("İlçe boş olamaz.")
                .MaximumLength(50).WithMessage("İlçe en fazla 50 karakter olmalıdır.");

            RuleFor(dto => dto.Neighbourhood)
                .NotEmpty().WithMessage("Mahalle boş olamaz.")
                .MaximumLength(50).WithMessage("Mahalle en fazla 50 karakter olmalıdır.");

            RuleFor(dto => dto.Address)
                .NotEmpty().WithMessage("Adres boş olamaz.")
                .MaximumLength(100).WithMessage("Adres en fazla 100 karakter olmalıdır.");

            RuleFor(dto => dto.PhoneNumber)
                .NotEmpty().WithMessage("Telefon numarası boş olamaz.")
                .Matches(@"^\d{10}$").WithMessage("Geçerli bir telefon numarası girin.");

            RuleFor(dto => dto.Graduation)
                .NotEmpty().WithMessage("Mezuniyet durumu boş olamaz.")
                .MaximumLength(50).WithMessage("Mezuniyet durumu en fazla 50 karakter olmalıdır.");

            RuleFor(dto => dto.GraduationYear)
                .NotEmpty().WithMessage("Mezuniyet yılı boş olamaz.")
                .Matches(@"^\d{4}$").WithMessage("Geçerli bir yıl girin.");

            RuleFor(dto => dto.GraduatedSchool)
                .NotEmpty().WithMessage("Mezun olduğunuz okul boş olamaz.")
                .MaximumLength(100).WithMessage("Okul adı en fazla 100 karakter olmalıdır.");

            RuleFor(dto => dto.DutyId)
                .NotEmpty().WithMessage("Görev ID boş olamaz.");

            RuleFor(dto => dto.BranchId)
                .NotEmpty().WithMessage("Branş ID boş olamaz.");

        }
    }
}
