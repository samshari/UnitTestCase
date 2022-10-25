using System;
using System.Collections.Generic;
using System.Text;

namespace Exelon.Domain.Entities
{
    public class HutExRnPPhaseTwoModel
    {
		public long HutExRnPPhase2ID { get; set; }
		public long HutExecutionID { get; set; }
		public Nullable<DateTime> RnPIFA { get; set; }
		public Nullable<DateTime> RnPIFC { get; set; }
		public string StrRnPIFA { get; set; }
		public string StrRnPIFC { get; set; }
		public bool IsActive { get; set; }
		public string CreatedBy { get; set; }
		public string CreatedDate { get; set; }
		public string UpdatedBy { get; set; }
		public string UpdatedDate { get; set; }
	}
}
