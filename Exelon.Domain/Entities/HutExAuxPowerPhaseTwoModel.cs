using System;
using System.Collections.Generic;
using System.Text;

namespace Exelon.Domain.Entities
{
    public class HutExAuxPowerPhaseTwoModel
    {
		public long AuxPowerPhase2ID { get; set; }
		public long HutExecutionID { get; set; }
		public string SecurityInfrastructure { get; set; }
		public string SecurityNotesNextSteps { get; set; }
		public Nullable<DateTime> DistElectricalIFAs { get; set; }
		public Nullable<DateTime> DistElectricalIFCs { get; set; }
		public Nullable<DateTime> AboveGradeElectricalIFAs { get; set; }
		public string StrDistElectricalIFAs { get; set; }
		public string StrDistElectricalIFCs { get; set; }
		public string StrAboveGradeElectricalIFAs { get; set; }
		public string PermitStatus { get; set; }
		public bool IsActive { get; set; }
		public string CreatedBy { get; set; }
		public string CreatedDate { get; set; }
		public string UpdatedBy { get; set; }
		public string UpdatedDate { get; set; }

	}
}
