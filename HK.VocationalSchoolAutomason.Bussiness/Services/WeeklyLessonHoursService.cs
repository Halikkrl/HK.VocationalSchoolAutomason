using AutoMapper;
using FluentValidation;
using HK.VocationalSchoolAutomason.Bussiness.Extensions;
using HK.VocationalSchoolAutomason.Bussiness.Interfaces;
using HK.VocationalSchoolAutomason.Common.ResponsObjects;
using HK.VocationalSchoolAutomason.DataAccess.UnitOfWork;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.GroupDtos;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.LevelDtos;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.WeeklyLessonHoursDtos;
using HK.VocationalSchoolAutomason.Entities.Domains;

namespace HK.VocationalSchoolAutomason.Bussiness.Services
{
    public class WeeklyLessonHoursService : IWeeklyLessonHours
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;
        private readonly IValidator<WeeklyLessonHoursCreateDto> _createValidator;
        private readonly IValidator<WeeklyLessonHoursUpdateDto> _updateValidator;

        public WeeklyLessonHoursService(IUow uow, IMapper mapper, IValidator<WeeklyLessonHoursCreateDto> createValidator, IValidator<WeeklyLessonHoursUpdateDto> updateValidator)
        {
            _uow = uow;
            _mapper = mapper;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }

        public async Task<IResponse<WeeklyLessonHoursCreateDto>> Create(WeeklyLessonHoursCreateDto dto)
        {
            var validationResult = _createValidator.Validate(dto);
            if (validationResult.IsValid)
            {
                await _uow.GetRepository<WeeklyLessonHours>().Create(_mapper.Map<WeeklyLessonHours>(dto));
                await _uow.SaveChanges();

                return new Response<WeeklyLessonHoursCreateDto>(ResponseType.Success, dto);
            }
            else
            {
                return new Response<WeeklyLessonHoursCreateDto>(ResponseType.ValidationError, dto, validationResult.CovertToCustomValidationError());
            }
        }

        public async Task<IResponse<List<WeeklyLessonHoursListDto>>> GetAllStudents()
        {
            var data = _mapper.Map<List<WeeklyLessonHoursListDto>>(await _uow.GetRepository<WeeklyLessonHours>().GetAll());

            return new Response<List<WeeklyLessonHoursListDto>>(ResponseType.Success, data);
        }

        public async Task<IResponse<IDto>> GetById<IDto>(int id)
        {
            var data = _mapper.Map<IDto>(await _uow.GetRepository<WeeklyLessonHours>().GetByFilter(x => x.Id == id));
            if (data == null)
            {
                return new Response<IDto>(ResponseType.NotFound, $"{id} ait data bulunamadı");
            }
            return new Response<IDto>(ResponseType.Success, data);
        }

        public async  Task<IResponse> Remove(int id)
        {
            var deletedEntity = await _uow.GetRepository<Day>().GetByFilter(x => x.Id == id);
            if (deletedEntity != null)
            {
                _uow.GetRepository<Day>().Remove(deletedEntity);
                await _uow.SaveChanges();
                return new Response(ResponseType.Success);
            }
            else
            {
                return new Response(ResponseType.NotFound, $"{id} ye ait data bulunamadı");
            }
        }

        public async Task<IResponse<WeeklyLessonHoursUpdateDto>> Update(WeeklyLessonHoursUpdateDto dto)
        {
            var result = _updateValidator.Validate(dto);
            if (result.IsValid)
            {
                var updatedEntity = await _uow.GetRepository<WeeklyLessonHours>().Find(dto.Id);
                if (updatedEntity != null)
                {
                    _uow.GetRepository<WeeklyLessonHours>().Update(_mapper.Map<WeeklyLessonHours>(dto), updatedEntity);
                    _uow.SaveChanges();

                    return new Response<WeeklyLessonHoursUpdateDto>(ResponseType.Success, dto);
                }
                return new Response<WeeklyLessonHoursUpdateDto>(ResponseType.NotFound, $"{dto.Id} ait data bulunamadı");

            }
            else
            {
                return new Response<WeeklyLessonHoursUpdateDto>(ResponseType.ValidationError, dto, result.CovertToCustomValidationError());
            }
        }
    }
}
