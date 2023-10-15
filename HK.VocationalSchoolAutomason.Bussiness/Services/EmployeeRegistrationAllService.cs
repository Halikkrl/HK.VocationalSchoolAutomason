using AutoMapper;
using FluentValidation;
using HK.VocationalSchoolAutomason.Bussiness.Extensions;
using HK.VocationalSchoolAutomason.Bussiness.Interfaces;
using HK.VocationalSchoolAutomason.Common.ResponsObjects;
using HK.VocationalSchoolAutomason.DataAccess.Contexts;
using HK.VocationalSchoolAutomason.DataAccess.UnitOfWork;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.EmployeeRegistrationDto;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.StudentRegistrationDtos;
using HK.VocationalSchoolAutomason.Entities.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HK.VocationalSchoolAutomason.Bussiness.Services
{
    public class EmployeeRegistrationAllService : IEmployeeInformationAll
    {
        private readonly SchoolContext _context;
        private readonly IMapper _mapper;
        private readonly IUow _uow;
        private readonly IValidator<EmployeeRegistrationCreateDto> _createValidator;

        public EmployeeRegistrationAllService(SchoolContext context, IMapper mapper, IUow uow, IValidator<EmployeeRegistrationCreateDto> createValidator)
        {
            _context = context;
            _mapper = mapper;
            _uow = uow;
            _createValidator = createValidator;
        }

        public async Task<IResponse<EmployeeRegistrationCreateDto>> Create(EmployeeRegistrationCreateDto dto)
        {
            var ValidationResult = _createValidator.Validate(dto);
            if (ValidationResult.IsValid)
            {
                #region Employee Add
                var NewEmployee = _mapper.Map<Employee>(dto);
                await _uow.GetRepository<Employee>().Create(NewEmployee);
                await _uow.SaveChanges();
                int EmployeeID = NewEmployee.Id;
                #endregion


                #region Contact Add
                var Contact = _mapper.Map<EmployeeContact>(dto);
                Contact.EmployeeId = EmployeeID;
                await _uow.GetRepository<EmployeeContact>().Create(Contact);

                #endregion

                #region Information Add

                var InformationEmployee = _mapper.Map<EmployeeInformation>(dto);
                InformationEmployee.EmployeeId = EmployeeID;
                await _uow.GetRepository<EmployeeInformation>().Create(InformationEmployee);


                #endregion

                #region EmployeeDuty Add

                var DutyEmployee = _mapper.Map<EmployeeDuty>(dto);
                DutyEmployee.EmployeeId = EmployeeID;
                await _uow.GetRepository<EmployeeDuty>().Create(DutyEmployee);
                await _uow.SaveChanges();


                #endregion


                #region DutyBranch Add

                var DutyBranch = _mapper.Map<EmployeeDutyBranch>(dto);
                DutyBranch.EmployeeDutyId = DutyEmployee.Id;
                await _uow.GetRepository<EmployeeDutyBranch>().Create(DutyBranch);
                await _uow.SaveChanges();


                #endregion

                return new Response<EmployeeRegistrationCreateDto>(ResponseType.Success, dto);

            }
            else
            {
                return new Response<EmployeeRegistrationCreateDto>(ResponseType.ValidationError, dto, ValidationResult.CovertToCustomValidationError());
            }
        }

        public IQueryable<EmployeeRegistrationListDto> GetAllEmployee()
        {
            var joins = (from generalEmployeDB in _context.EmployeeDutyBranches 

                         join _employeDuty in _context.EmployeeDuties
                         on generalEmployeDB.EmployeeDutyId equals _employeDuty.Id 

                         join _duty in _context.Duties
                         on _employeDuty.DutyId equals _duty.Id

                         join _branch in _context.Branches
                         on generalEmployeDB.BranchId equals _branch.Id

                         join _employee in _context.Employees
                         on  _employeDuty.EmployeeId equals _employee.Id 

                         join _contact in _context.EmployeeContacts
                         on _employee.Id equals _contact.EmployeeId

                         join _information in _context.EmployeeInformations
                         on _employee.Id equals _information.EmployeeId into listEmployee





                         from list in listEmployee.DefaultIfEmpty()

                         select new EmployeeRegistrationListDto
                         {
                             Id = generalEmployeDB.Id,
                             BranchName = _branch.Name,
                             DutyName = _duty.Name,

                             IdentificationNumber = _employee.IdentificationNumber,
                             FirstName = _employee.FirstName,
                             LastName = _employee.LastName,

                             City = _contact.City,
                             District = _contact.District,
                             Neighbourhood = _contact.Neighbourhood,
                             Address = _contact.Address,
                             PhoneNumber = _contact.PhoneNumber,


                             Graduation = list.Graduation,
                             GraduationYear = list.GraduationYear,
                             GraduatedSchool = list.GraduatedSchool



                         });

            return joins.AsQueryable();
        }

        public async Task<IResponse> Remove(int id)
        {
            var deletedEntity = await _uow.GetRepository<EmployeeDutyBranch>().GetByFilter(x => x.Id == id);

            if (deletedEntity != null)
            {
                _uow.GetRepository<EmployeeDutyBranch>().Remove(deletedEntity);
                
                var EmployeeDuty = await _uow.GetRepository<EmployeeDuty>().GetByFilter(x => x.Id == deletedEntity.EmployeeDutyId);
                _uow.GetRepository<EmployeeDuty>().Remove(EmployeeDuty);

                var EmployeeID = await _uow.GetRepository<Employee>().GetByFilter(x => x.Id == EmployeeDuty.EmployeeId);
                _uow.GetRepository<Employee>().Remove(EmployeeID);
                _uow.SaveChanges();
                return new Response(ResponseType.Success);
            }
            else
            {
                return new Response(ResponseType.NotFound, $"{id} ye ait data bulunamadı");
            }
        }
    }
}
