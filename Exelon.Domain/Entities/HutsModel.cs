using System;
using System.Collections.Generic;
using System.Text;

namespace Exelon.Domain
{
    public class HUTSModel
    {
	public long HutsID { get; set; }
	public string Substation { get; set; }
	public int FK_PDID { get; set; }
	public string Address { get; set; }
	public Nullable<int> FK_RegionID { get; set; }
	public Nullable<int> FK_SizeID { get; set; }
	public string Vendor { get; set; }
	public string WorkOrder { get; set; }
	public string ProjectID { get; set; }
	public string ProjectManager { get; set; }
	public Nullable<int> FK_EOCID { get; set; }
	public Nullable<int> FK_PhaseID { get; set; }
	public string SR { get; set; }
	public string Year { get; set; }
	public Nullable<int> FK_LandAcquisition { get; set; }
	public Nullable<int> FK_EnvironmentalDueDiligence { get; set; }
	public string REEFResults { get; set; }
	public Nullable<int> FK_ComEdOwnership { get; set; }
	public string Survey { get; set; }
	public string SitePlanSubmitted { get; set; }
	public string LocationProperty { get; set; }
	public Nullable<int> FK_TransmissionROWPermitStatus { get; set; }
	public string GEOTech { get; set; } 
	public Nullable<DateTime> CivilIFA { get; set; }
	public string StrCivilIFA { get; set; }
	public string LandscapingPlan { get; set; }
	public string Stormwater { get; set; }
	public Nullable<DateTime> CivilIFC { get; set; }
	public Nullable<DateTime> ElectricalIFA { get; set; }
	public Nullable<DateTime> ElectricalIFC { get; set; }
	public Nullable<int> FK_CompletionStatus { get; set; }
	public string StrCivilIFC { get; set; }
	public string StrElectricalIFA { get; set; }
	public string StrElectricalIFC { get; set; }
	public string StrFK_CompletionStatus { get; set; }
	public string SubstationElectrical { get; set; } 
	public string SubstationCivil { get; set; }
	public string SubstationSupportDesigner { get; set; }
	public string SCADA { get; set; }
	public string Relay { get; set; }
	public string COMM { get; set; }
	public string UCommFiberEng { get; set; }
	public string UCommNetworkEng { get; set; }
	public string REACTsEng { get; set; }
	public  Nullable<DateTime> HutPlannedDeliveryDate { get; set; }
	public  string StrHutPlannedDeliveryDate { get; set; }
	public string EnclosureLeadtime { get; set; }
	public string Remarks { get; set; }
	public string CreatedBy { get; set; }
	public string CreatedDate { get; set; }
	public string UpdatedBy { get; set; }
	public string UpdatedDate { get; set; }
	public bool IsActive { get; set; }
	}
}
