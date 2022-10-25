using System;
using System.Collections.Generic;
using System.Text;

namespace Exelon.Domain
{
    public class ENGINVESTModel
    {
        public long EnggInvestigationID { get; set; }
		public long FK_LinkingID { get; set; }
		public int FK_StepID { get; set; }
		public Nullable<int> FK_InnerductCOC { get; set; }
		public string Comments { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public string UpdatedDate { get; set; }
        public bool IsActive { get; set; }
    }
}
