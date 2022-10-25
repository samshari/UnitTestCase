using System;
using System.Collections.Generic;
using System.Text;

namespace Exelon.Domain.Entities
{
    public class HutExecutionModel
    {
		public long HutExecutionID { get; set; }
		public string HutDeliveryYear { get; set; }
		public string Location { get; set; }
		public int FK_PDID { get; set; }
		public string WorkOrder { get; set; }
		public string PID { get; set; }
		public Nullable<int> FK_RegionID { get; set; }
		public Nullable<int> FK_BarnID { get; set; }
		public string EOC { get; set; }
		public  Nullable<int> FK_HutSize { get; set; }
		public string ProductOrder { get; set; }
		public string Cat_ID { get; set; }
		public string Delivery_Address_On_PO { get; set; }
		public string CreatedBy { get; set; }
		public string CreatedDate { get; set; }
		public string UpdatedBy { get; set; }
		public string UpdatedDate { get; set; }
		public bool IsActive { get; set; }
	}
}
