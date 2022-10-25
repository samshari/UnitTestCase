using System;
using System.Collections.Generic;
using System.Text;

namespace Exelon.Domain.Entities
{
    public class HutExRouterUpgradePhaseThreeModel
    {
        public long RouterUpgradesPhase3ID { get; set; } 
        public long HutExecutionID { get; set; }
        public Nullable<DateTime> RouterUpgradeStartDate { get; set; }
	    public Nullable<DateTime> RouterUpgradeEndDate { get; set; }
        public string StrRouterUpgradeStartDate { get; set; }
        public string StrRouterUpgradeEndDate { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public string UpdatedDate { get; set; }
    }
}
