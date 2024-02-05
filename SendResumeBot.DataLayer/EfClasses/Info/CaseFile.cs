using System.ComponentModel.DataAnnotations.Schema;

namespace IHMA_INSON_bot.DataLayer.EfClasses;

[Table("info_case_file")]
public partial class CaseFile : FileEntity<long>
{

}
