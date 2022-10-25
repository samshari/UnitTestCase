using System;
using System.Collections.Generic;
using System.Text;

namespace Exelon.Domain
{
    public class IFCDATESModel
    {
		public int IFCDateID { get; set; }
		public long FK_LinkingID { get; set; }
		public int FK_StepID { get; set; }
		public Nullable<DateTime> IFCMkReadyScheduledIssueDate { get; set; }
		public Nullable<DateTime> IFCFiberCurrentScheduledIssueDt { get; set; }
        public string StrIFCMkReadyScheduledIssueDate { get; set; }
        public string StrIFCFiberCurrentScheduledIssueDt { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public string UpdatedDate { get; set; }
        public bool IsActive { get; set; }
    }
}
