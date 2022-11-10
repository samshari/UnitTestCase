using System;
using System.Collections.Generic;
using System.Text;

namespace Exelon.Domain
{
    public class HUTPERMITTINGModel
    {
		public long HutPermittingID { get; set; }
		public string InstallYear { get; set; }
		public string Substation { get; set; }
		public Nullable<int> FK_EOCID { get; set; }
		public string EOCName { get; set; }
		public string SizeName { get; set; }
		public Nullable<int> FK_SizeID { get; set; }
		public string Location_Municipality { get; set; }
		public string Location_County { get; set; }
		public Nullable<int> FK_RequiredCountyStormwater { get; set; }
		public string OH_RequiredCountyStormwater { get; set; }
		public  Nullable<int> FK_ArmyCorpsPermitRequired { get; set; }
		public string OH_ArmyCorpsPermitRequired { get; set; }
		public Nullable<int> FK_TROWPermitRequired { get; set; }
		public string OH_TROWPermitRequired { get; set; }
		public Nullable<int> FK_SiteDevelopmentPermitRequired { get; set; }
		public string OH_SiteDevelopmentPermitRequired { get; set; }
		public Nullable<int> FK_HwyOrIDOTPermit { get; set; }
		public string OH_HwyOrIDOTPermit { get; set; }
		public Nullable<int> FK_BuildingOrOtherPermitRequired { get; set; }
		public string OH_BuildingOrOtherPermitRequired { get; set; }
		public Nullable<DateTime> CivilIFADate { get; set; }
		public Nullable<DateTime> CivilIFCDate { get; set; }
		public string StrCivilIFADate { get; set; }
		public string StrCivilIFCDate { get; set; }
		public string Status { get; set; }
		public Nullable<DateTime> PermitSubmissionDate { get; set; }
		public string StrPermitSubmissionDate { get; set; }
		public string Comments { get; set; }
		public Nullable<DateTime> PermitReadyDate { get; set; }
		public string StrPermitReadyDate { get; set; }
		public string PermitExpiration { get; set; }
		public string Notes { get; set; }
		public string CreatedBy { get; set; }
		public string CreatedDate { get; set; }
		public string UpdatedBy { get; set; }
		public string UpdatedDate { get; set; }
		public bool IsActive { get; set; }
	}
}
