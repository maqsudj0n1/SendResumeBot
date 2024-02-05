using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WEBASE.Models;

namespace SendResumeBot.BizLogicLayer.Models
{
    public class TableSortFilterPageOptions : SortFilterPageOptions
    {
        public Dictionary<string, FilterMeta> Filters { get; set; }
    }

    public class FilterMeta
    {
        public object Value { get; set; }
        public string MatchMode { get; set; }
    }
}
