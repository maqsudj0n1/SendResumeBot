using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WEBASE.Models;

namespace SendResumeBot.DataLayer.EfClasses;

[Table("enum_language")]
public partial class Language : IHaveIdProp<int>
{

    [Key]
    [Column("id")]
    public int Id { get; set; }
    [Required]
    [Column("code")]
    [StringLength(10)]
    public string Code { get; set; }
    [Required]
    [Column("short_name")]
    [StringLength(50)]
    public string ShortName { get; set; }
    [Required]
    [Column("full_name")]
    [StringLength(100)]
    public string FullName { get; set; }
    [Column("created_at")]
    public DateTime CreatedAt { get; set; }
}
