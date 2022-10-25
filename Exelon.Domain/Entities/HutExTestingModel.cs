using System;
using System.Collections.Generic;
using System.Text;

namespace Exelon.Domain.Entities
{
    public class HutExTestingModel
    {
		public long HutTestingLNLID { get; set; }
		public long HutExecutionID { get; set; }
		public Nullable<DateTime> FiberRingCompleted { get; set; }
		public Nullable<DateTime> HutInService { get; set; }
		public string StrFiberRingCompleted { get; set; }
		public string StrHutInService { get; set; }
		public string SecurityEquipmentInstalleCard { get; set; }
		public bool IsActive { get; set; }
		public string CreatedBy { get; set; }
		public string CreatedDate { get; set; }
		public string UpdatedBy { get; set; }
		public string UpdatedDate { get; set; }

	}
}
