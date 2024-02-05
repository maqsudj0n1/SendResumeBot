using IHMA_INSON_bot.DataLayer.EfClasses;
using Microsoft.EntityFrameworkCore;
using SendResumeBot.DataLayer.EfClasses;
using WEBASE.EF;

namespace SendResumeBot.Models;

public partial class EfCoreContext : BaseDbContext
{
    public EfCoreContext()
    {
    }

    public EfCoreContext(DbContextOptions options)
        : base(options)
    {
        Config.AutoSetProperties.DateOfCreated.PropertyName = nameof(User.CreatedAt);
        Config.AutoSetProperties.DateOfModified.PropertyName = nameof(User.ModifiedAt);
    }

    public virtual DbSet<Language> Languages { get; set; }

    public virtual DbSet<State> States { get; set; }

    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<StateTranslate> StateTranslates { get; set; }
    public virtual DbSet<Button> Buttons { get; set; }
    public virtual DbSet<Caption> Captions { get; set; }
    public virtual DbSet<ButtonTranslate> ButtonTranslates { get; set; }
    public virtual DbSet<CaptionTranslate> CaptionsTranslates { get; set;}
    public virtual DbSet<CaseFile> CaseFiles { get; set; }

}
