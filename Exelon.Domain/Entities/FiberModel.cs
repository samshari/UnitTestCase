using System;
using System.Collections.Generic;
using System.Text;

namespace Exelon.Domain
{
    public class FIBERModel
    {
		public long	FiberID { get; set; }
		public long FK_LinkingID { get; set; }
		public Nullable<int> FK_FiberCOCID { get; set; }
		public string IssuesOrComments { get; set; }
		public Nullable<DateTime> StartDate { get; set; }
		public Nullable<DateTime> EndDate { get; set; }
		public string StrStartDate { get; set; }
		public string StrEndDate { get; set; }
		public string WeeklyFTECount { get; set; }
		public Nullable<DateTime> OTDRCompletionDate { get; set; }
		public string StrOTDRCompletionDate { get; set; }
		public bool IsActive { get; set; }
		public string CreatedBy { get; set; }
		public string CreatedDate { get; set; }
		public string UpdatedBy { get; set; }
		public string UpdatedDate { get; set; }
	}
}
