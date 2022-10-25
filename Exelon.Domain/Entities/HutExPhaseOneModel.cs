using System;
using System.Collections.Generic;
using System.Text;

namespace Exelon.Domain.Entities
{
	public class HutExPhaseOneModel
	{
		public long HutExPhaseOneID { get; set; }
		public long FK_HutExecutionID { get; set; }
		public Nullable<int> FK_LandAcquisitionRequired { get; set; }
		public string LandAcquisitionOther {get;set;}
		public string LocationTwo { get; set; }
		public string PhaseOneFeasibility_T35 { get; set; }
		public Nullable<int> FK_IsLandAcquisitionRequired { get; set; }
		public string LandAcquisitionRequiredOth { get; set; }
		public Nullable<int> FK_SiteLayoutApprovalStatus { get; set; }
		public string CreatedBy { get; set; }
		public string CreatedDate { get; set; }
		public string UpdatedBy { get; set; }
		public string UpdatedDate { get; set; }
		public bool IsActive { get; set; }
	}
}
