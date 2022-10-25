using System;
using System.Collections.Generic;
using System.Text;

namespace Exelon.Domain.Entities
{
    public class HutExCVSubgradePhaseTwoModel
    {
		public long HutExCVSubgradePhase2_ID { get; set; }
		public long HutsExecutionID { get; set; }
		public Nullable<DateTime> CiviIFAs_T15 { get; set; }
		public Nullable<DateTime> CivilIFCs_T12 { get; set; }
		public Nullable<DateTime> PermitReadyDate { get; set; }
		public string StrCiviIFAs_T15 { get; set; }
		public string StrCivilIFCs_T12 { get; set; }
		public string StrPermitReadyDate { get; set; }
		public string CreateMR { get; set; }
		public Nullable<DateTime> RFPSubmittedOn { get; set; }
		public string StrRFPSubmittedOn { get; set; }
		public string HRESubmitte { get; set;}
		public string PermitsOutstanding_T8 { get; set; }
		public Nullable<DateTime> PreConstructionWalkdown { get; set; }
		public string StrPreConstructionWalkdown { get; set; }
		public Nullable<int> FK_HASPRequired { get; set; }
		public string HASPReqdOther { get; set; }
		public bool IsActive { get; set; }
		public string CreatedBy { get; set; }
		public string CreatedDate { get; set; }
		public string UpdatedBy { get; set; }
		public string UpdatedDate { get; set; }

	}
}
