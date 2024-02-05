using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webase.TelegramBot.Constants
{
    public class MyApplicationDto
    {
        public long Id { get; set; }
        public string DocNumber { get; set; }
        public long ContractorId { get; set; }
        public long ApplicationClassificationId { get; set; }
        public string ApplicationClassification {  get; set; }
        public int? OrganizationId { get; set; }
        public string Organization { get; set;}
        public int StatusId { get; set; }
        public string Status { get; set; }
    }
}
