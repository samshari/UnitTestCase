using System;
using System.Collections.Generic;
using System.Text;

namespace Exelon.Domain.Entities
{
    public class HutExRnPPhaseThreeModel
    {
        public long RnPPhase3ID { get; set; }
        public long HutExecutionID { get; set; }
        public Nullable<DateTime> RelayExecutionStartDate { get; set; }
        public string StrRelayExecutionStartDate { get; set; }
        public string Outage { get; set; }
	    public Nullable<DateTime> CompletionDate { get; set; }
        public string StrCompletionDate { get; set; }
        public Boolean IsActive { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public string UpdatedDate { get; set; }
    }
}
