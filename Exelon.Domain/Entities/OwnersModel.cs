using System;
using System.Collections.Generic;
using System.Text;

namespace Exelon.Domain
{
    public class OWNERSModel
    {
		public long OwnerID { get; set; }
		public long FK_LinkingID { get; set; }
		public Nullable<int> FK_ReactsLRE_ID { get; set; }
		public Nullable<int> FK_UCOMMSPOC_ID { get; set; }
		public int FK_ProjectManagerID { get; set; }
		public int StepID { get; set; }
		public string CreatedBy { get; set; }
		public string CreatedDate { get; set; }
		public string UpdatedBy { get; set; }
		public string UpdatedDate { get; set; }
		public bool IsActive { get; set; }
	}
}
