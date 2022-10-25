using System;
using System.Collections.Generic;
using System.Text;

namespace Exelon.Domain.Entities
{
    public class HutExFiberPhaseThreeModel
    {
		public long FiberPhase3ID { get; set; }
		public long HutExecutionID { get; set; }
		public  Nullable<DateTime> FiberInstallationDate { get; set; }
		public Nullable<DateTime> FiberRingCompleted { get; set; }
		public string StrFiberInstallationDate { get; set; }
		public string StrFiberRingCompleted { get; set; }
		public bool IsActive { get; set; }
		public string CreatedBy { get; set; }
		public string CreatedDate { get; set; }
		public string UpdatedBy { get; set; }
		public string UpdatedDate { get; set; }

	}
}
