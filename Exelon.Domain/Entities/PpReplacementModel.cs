using System;
using System.Collections.Generic;
using System.Text;

namespace Exelon.Domain
{
    public class PPREPLACEMENTModel
    {
		public long PolesRepacementID { get; set; }
		public long FK_LinkingID { get; set; }	
		public int TotalNoOfPolesInRoute { get; set; }
		public int ReplacedNoOfOsmos { get; set; }
		public int ReplacedLoading { get; set; }
		public int ReplacedClearance { get; set; }
		public int ReplacedReliability { get; set; }
		public int NewOrMidspanPoles { get; set; }
		public int TotalRelocatedPoles { get; set; }
		public int TotalPolesNeedingReplaced { get; set; }
		public int NewAnchor { get; set; }
		public int OtherWorkOnPole { get; set; }
		public decimal PoleReplacementPercentage { get; set; }
		public int StepID { get; set; }
		public string CreatedBy { get; set; }
		public string CreatedDate { get; set; }
		public string UpdatedBy { get; set; }
		public string UpdatedDate { get; set; }
		public bool IsActive { get; set; }

	}
}
