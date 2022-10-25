using System;
using System.Collections.Generic;
using System.Text;

namespace Exelon.Domain
{
    public class MCocBidComModel
    {
        public long COCBidCompleteID { get; set; }
        public long FK_LinkingID { get; set; }
        public int FK_StepID { get; set; }
        public Nullable<int> FK_COCBidCompMkReadyID { get; set; }
	    public Nullable<int> FK_COCBidCompFiberID { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public string UpdatedDate { get; set; }


    }
}
