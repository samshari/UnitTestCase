using System;
using System.Collections.Generic;
using System.Text;

namespace Exelon.Domain.Entities
{
    public class HutExPowPhaseThreeModel
    {
		public long HutExAuxPowerPhase3ID { get; set; }
		public long HutExecutionID { get; set; }
	    public Nullable<DateTime> AuxPowerCivilStart { get; set; }
		public Nullable<DateTime> AuxPowerCivilComplete { get; set; }
		public Nullable<DateTime> AuxPowerElectricalStart { get; set; }
		public Nullable<DateTime> AuxPowerElectricalComplete { get; set; }
		public string StrAuxPowerCivilStart { get; set; }
		public string StrAuxPowerCivilComplete { get; set; }
		public string StrAuxPowerElectricalStart { get; set; }
		public string StrAuxPowerElectricalComplete { get; set; }
		public string AuxPowerTestedByTG { get; set; }
		public Nullable<DateTime> OutageCutoverDate { get; set; }
		public string StrOutageCutoverDate { get; set; }
		public string DistOpsNotifiedOfWork { get; set; }
		public string LNLSubmitted { get; set; }
		public string ComEdContracting { get; set; }
		public Nullable<DateTime> FiberHutToControlBuildingStart { get; set; }
		public Nullable<DateTime> FiberHutToControlBuildingFinish { get; set; }
		public string StrFiberHutToControlBuildingStart { get; set; }
		public string StrFiberHutToControlBuildingFinish { get; set; }
		public bool IsActive { get; set; }
		public string CreatedBy { get; set; }
		public string CreatedDate { get; set; }
		public string UpdatedBy { get; set; }
		public string UpdatedDate { get; set; }
	}
}
