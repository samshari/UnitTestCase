using System;
using System.Collections.Generic;
using System.Text;

namespace Exelon.Domain
{
    public class DesignMilesModel
    {
        public long DesignMilesID { get; set; }
        public long FK_LinkingID { get; set; }
        public Nullable<decimal> UGMiles { get; set; }
        public Nullable<decimal> OHMiles { get; set; }
        public Nullable<decimal> TotalMiles {get;set;}
        public int FK_StepID { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public string UpdatedDate { get; set; }
        public bool IsActive { get; set; }
    }
}
