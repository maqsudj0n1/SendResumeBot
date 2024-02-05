using System.ComponentModel.DataAnnotations.Schema;

namespace SendResumeBot.DataLayer.EfClasses;

[Table("enum_button_translate")]
public class ButtonTranslate : EnumTranslateEntity<ButtonTranslate, TranslateColumn>
{
    [ForeignKey(nameof(LanguageId))]
    public virtual Language Language { get; set; }
    [ForeignKey(nameof(OwnerId))]
    [InverseProperty(nameof(Button.Translates))]
    public virtual Button Owner { get; set; }
}
