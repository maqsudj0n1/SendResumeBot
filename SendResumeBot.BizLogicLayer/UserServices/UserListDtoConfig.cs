using GenericServices.Configuration;
using AutoMapper;
using SendResumeBot.DataLayer.EfClasses;
using SendResumeBot.DataLayer;

namespace SendResumeBot.BizLogicLayer.Services
{
    public class UserListDtoConfig : PerDtoConfig<UserListDto, User>
    {
        public override Action<IMappingExpression<User, UserListDto>> AlterReadMapping =>
            cfg => cfg
                .ForMember(x => x.State, x => x.MapFrom(ent => ent.State.Translates.AsQueryable()
                    .FirstOrDefault(StateTranslate.GetExpr(TranslateColumn.full_name, ServiceProvider.CultureHelper.CurrentCulture.Id)).TranslateText ?? ent.State.FullName))
                ;
    }
}
