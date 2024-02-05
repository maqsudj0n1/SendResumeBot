using GenericServices;
using SendResumeBot.DataLayer.EfClasses;
using SendResumeBot.DataLayer.Repositories;

namespace SendResumeBot.BizLogicLayer.Services
{
    public class UserDto : UpdateUserDlDto, ILinkToEntity<User>
    {
        public string Organization { get; set; }
        public string Region { get; set; }
        public bool IsOmbudsman { get; set; }
        public string State { get; set; }
       // public int PersonId { get; set; }
       // public PersonDto Person { get; set; } = new();
    }
}
