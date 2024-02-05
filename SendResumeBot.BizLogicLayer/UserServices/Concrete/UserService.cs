
using Microsoft.EntityFrameworkCore;
using SendResumeBot.BizLogicLayer.Models;
using SendResumeBot.BizLogicLayer.Services;
using SendResumeBot.DataLayer;
using SendResumeBot.DataLayer.Repositories;
using StatusGeneric;
using WEBASE;
using WEBASE.Models;

namespace SendResumeBot.Services
{
    public class UserService : StatusGenericHandler, IUserService
    {
        private readonly IUserRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        //   private IStorageService _storageService;
        //   private readonly ICultureHelper _cultureHelper;

        public UserService(IUnitOfWork unitOfWork)
        //IStorageService storageService,
        //ICultureHelper cultureHelper)
        {
            _repository = unitOfWork.UserRepository;
            _unitOfWork = unitOfWork;
            //    _storageService = storageService;
            // _cultureHelper = cultureHelper;
        }

        public PagedResult<UserListDto> GetList(TableSortFilterPageOptions dto)
        {
            return _repository.ReadAsNoTracked<UserListDto>()
                .SortFilter(dto).AsPagedResult(dto);
                //.ToTableData(dto);
        }

        public UserDto Get()
        {
            return new UserDto
            {

            };
        }

        public UserDto Get(int id)
        {
            var dto = _repository.ReadAsNoTracked<UserDto>().FirstOrDefault(a => a.Id == id);
            if (dto == null)
                AddError("По вашему запросу запись не найдено");
            return dto;
        }

        public HaveId<long> Create(CreateUserDto dto)
        {
            var entity = _repository.Create(dto);
            CombineStatuses(_repository);
            if (IsValid)
            {
                _unitOfWork.Save();
                return HaveId.Create(entity.Id);
            }

            return null;
        }

        public void Update(UpdateUserDlDto dto)
        {
            _repository.Update(dto);
            CombineStatuses(_repository);
            if (IsValid)
                _unitOfWork.Save();
        }

        public void Delete(int id)
        {
            var entity = _repository.ById(id);
            try
            {
                _repository.Delete(id);
                CombineStatuses(_repository);
                if (IsValid)
                    _unitOfWork.Save();
            }
            catch (DbUpdateException)
            {
                AddError("Пользователь не может быть удален");
            }
        }
    }
}
