using System;
using System.Collections.Generic;
using System.Text;

namespace Exelon.Domain.Entities
{
    public class HutExCivilPhaseThreeModel
    {
		public long HutExCivilPhase3ID { get; set; }
		public long HutExecutionID { get; set; }
		public string CivilAward { get; set; }
		public string EnvRFP { get; set; }
		public string Survey { get; set; }
		public Nullable<DateTime> IFC_T7 { get; set; }
		public Nullable<DateTime> FoundationPoured_T5 { get; set; }
		public Nullable<DateTime> GroundingConduitInstallPedBoxes_T4 { get; set; }
		public string StrIFC_T7 { get; set; }
		public string StrFoundationPoured_T5 { get; set; }
		public string StrGroundingConduitInstallPedBoxes_T4 { get; set; }
		public string ComEdContractingLNL { get; set; }
		public Nullable<DateTime> FoundationReadyforHutOffload_T1 { get; set; }
		public Nullable<DateTime> HutOffload { get; set; }
		public Nullable<DateTime> CivilComplete_T0 { get; set; }
		public Nullable<DateTime> Fenceinstall { get; set; }
		public string StrFoundationReadyforHutOffload_T1 { get; set; }
		public string StrHutOffload { get; set; }
		public string StrCivilComplete_T0 { get; set; }
		public string StrFenceinstall { get; set; }
		public string Construction_Notes { get; set; }
		public string GroundingTestingCompleted { get; set; }
		public string OutageRequiredforDelivery { get; set; }
		public bool IsActive { get; set; }
		public string CreatedBy { get; set; }
		public string CreatedDate { get; set; }
		public string UpdatedBy { get; set; }
		public string UpdatedDate { get; set; }

	}
}
