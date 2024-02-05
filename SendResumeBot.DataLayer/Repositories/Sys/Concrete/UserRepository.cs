using GenericServices;
using SendResumeBot.DataLayer.EfClasses;
using WEBASE.EF;

namespace SendResumeBot.DataLayer.Repositories
{
    public class UserRepository : BaseEntityRepository<long, User, CreateUserDlDto, UpdateUserDlDto>, IUserRepository
    {
        public UserRepository(ICrudServices crudServices)
            : base(crudServices)
        {
        }

        //public User Create(CreateUserByEmployeeDlDto dto)
        //{
        //    var employee = CrudServices.Context.Set<Employee>()
        //                                   .Include(a => a.Person)
        //                                   .FirstOrDefault(a => a.Id == dto.EmployeeId);
        //    if (employee == null)
        //    {
        //        AddError("Сотрудник не найден");
        //        return null;
        //    }
        //    var query = DbSet.AsQueryable();
        //    if (query.Any(a => a.UserName == dto.UserName))
        //    {
        //        AddError("Это имя пользователя занято", dto.UserName);
        //        return null;
        //    }
        //    var entity = dto.CreateEntity();
        //    entity.PersonId = employee.PersonId;
        //    entity.Employee = employee;
        //    DbSet.Add(entity);
        //    Context.Entry(entity).State = EntityState.Added;
        //    return entity;
        //}

        protected override IQueryable<User> ByIdQuery()
        {
            return base.ByIdQuery();
        }

        public User ByUserName(string userName)
        {
            var user = ByIdQuery().FirstOrDefault(a => a.UserName == userName);
            if (user == null)
            {
                AddEntityNotFoundError();
            }
            return user;
        }

        protected override void CreateValidate(CreateUserDlDto dto)
        {
            var query = DbSet.AsQueryable();
            if (query.Any(a => a.UserName == dto.UserName))
            {
                AddError("Это имя пользователя занято", dto.UserName);
            }
            Validate(null, dto);
        }

        protected override void UpdateValidate(User entity, UpdateUserDlDto dto)
        {
            var query = DbSet.AsQueryable();
            if (query.Any(a => a.Id != dto.Id && a.UserName == dto.UserName))
            {
                AddError("Это имя пользователя занято", dto.UserName);
            }
            Validate(entity, dto);
        }

        private void Validate<TDto>(User entity, UserDlDto<TDto> dto)
            where TDto : UserDlDto<TDto>
        {
            var query = DbSet.AsQueryable();

            if (entity != null)
                query = query.Where(a => a.Id != entity.Id);

            //if (dto.Pinfl.NullOrEmpty() && query.ByPinfl(dto.Pinfl, isIncludePassive: true).Any())
            //    AddError($"Страна с этим ИНПС ({dto.Pinfl}) уже существует.", nameof(dto.Pinfl));
        }

        public void ClearErrors()
        {
            _errors?.Clear();
        }
    }
}
