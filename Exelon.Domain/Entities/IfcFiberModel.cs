using System;
using System.Collections.Generic;
using System.Text;

namespace Exelon.Domain
{
    public class IfcFiberModel
    {
		public long IFCFiberID { get; set; }
	    public long FK_LinkingID { get; set; }
		public Nullable<DateTime> OriginalScheduledDate { get; set; }
		public Nullable<DateTime> CurrentScheduledDate { get; set; }
		public Nullable<DateTime> MissedDates { get; set; }
		public string StrOriginalScheduledDate { get; set; }
		public string StrCurrentScheduledDate { get; set; }
		public string StrMissedDates { get; set; }
		public string MissedReason { get; set; }
		public Nullable<DateTime> InitialIssueDate { get; set; }
		public Nullable<DateTime> FinalIssueDate { get; set; }
		public string StrInitialIssueDate { get; set; }
		public string StrFinalIssueDate { get; set; }
		public int StepID { get; set; }
		public string CreatedBy { get; set; }
		public string CreatedDate { get; set; }
		public string UpdatedBy { get; set; }
		public string UpdatedDate { get; set; }
		public bool IsActive { get; set; }
	}
}
