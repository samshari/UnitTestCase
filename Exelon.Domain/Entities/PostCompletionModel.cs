using System;
using System.Collections.Generic;
using System.Text;

namespace Exelon.Domain.Entities
{
    public class PostCompletionModel
    {
		public long PostCompletionID { get; set; }
		public long FK_LinkingID { get; set; }
		public string AsBuiltsReceived { get; set; }
		public string LocationsReadyToInspect { get; set; }
		public string LocationsInspected { get; set; }
		public string TEDUpdated { get; set; }
		public string PNIUpdatedIS { get; set; }
		public string CreatedBy { get; set; }
		public string CreatedDate { get; set; }
		public string UpdatedBy { get; set; }
		public string UpdatedDate { get; set; }
		public bool IsActive { get; set; }
	}
}
