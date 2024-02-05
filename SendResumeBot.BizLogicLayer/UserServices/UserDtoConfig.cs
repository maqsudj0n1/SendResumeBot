using GenericServices.Configuration;
using AutoMapper;
using System.Linq.Dynamic.Core;
using SendResumeBot.DataLayer.EfClasses;
using SendResumeBot.DataLayer;
using SendResumeBot.BizLogicLayer.Services;

namespace SendResumeBot.Services
{
    public class UserDtoConfig : PerDtoConfig<UserDto, User>
    {
        public override Action<IMappingExpression<User, UserDto>> AlterReadMapping =>
            cfg => cfg
                .ForMember(x => x.State, x => x.MapFrom(ent => ent.State.Translates.AsQueryable()
                    .FirstOrDefault(StateTranslate.GetExpr(TranslateColumn.full_name, ServiceProvider.CultureHelper.CurrentCulture.Id)).TranslateText ?? ent.State.FullName))
            ;
    }
}
