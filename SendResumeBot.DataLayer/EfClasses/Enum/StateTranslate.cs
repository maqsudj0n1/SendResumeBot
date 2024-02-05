using System.ComponentModel.DataAnnotations.Schema;
using System.Linq.Expressions;

namespace SendResumeBot.DataLayer.EfClasses;

[Table("enum_state_translate")]
public partial class StateTranslate : EnumTranslateEntity<StateTranslate, TranslateColumn>
{
    [ForeignKey(nameof(LanguageId))]
    public virtual Language Language { get; set; }
    [ForeignKey(nameof(OwnerId))]
    [InverseProperty(nameof(State.Translates))]
    public virtual State Owner { get; set; }

    public static Expression<Func<StateTranslate, bool>> GetExpr(TranslateColumn full_name, object id)
    {
        throw new NotImplementedException();
    }
}
