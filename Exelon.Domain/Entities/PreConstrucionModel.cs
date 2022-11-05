using System;
using System.Collections.Generic;
using System.Text;

namespace Exelon.Domain
{
    public class PRECONSTRUCTIONModel
    {
		public long PreContructionID { get; set; }
		public long FK_LinkingID { get; set; }
		public Nullable<int> FK_EnvironmentalCOCID { get; set; }
		public Nullable<int> FK_VegRequired { get; set; }
		public Nullable<int> FK_StackingRequired { get; set; }
		public Nullable<int> FK_MattingRequired { get; set; }
		public string CreatedBy { get; set; }
		public string CreatedDate { get; set; }
		public string UpdatedBy { get; set; }
		public string UpdatedDate { get; set; }
		public bool IsActive { get; set; }
	}
}
