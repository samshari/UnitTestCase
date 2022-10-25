using System;
using System.Collections.Generic;
using System.Text;

namespace Exelon.Domain
{
    public class MEOCREALSTATEModel
    {
        public long EOCRealEstateID { get; set; }
        public long FK_LinkingID { get; set; }
        public Nullable<int> FK_EOCID { get; set; }
        public Nullable<DateTime> EOCReleaseDate { get; set; }
        public Nullable<DateTime> EOCPoleForemanComplete { get; set; }
        public string StrEOCReleaseDate { get; set; }
        public string StrEOCPoleForemanComplete { get; set; }
        public string REEFSubmittal { get; set; }
        public string REEF { get; set; }
        public Nullable<int> FK_COCID { get; set; }
        public Nullable<int> FK_RealEstateSupportCOCID { get; set; }
        public string UGCnCInvestigation { get; set; }
        public string MHDefects { get; set; }
        public string InvestigationComments { get; set; }
        public string MRs { get; set; }
        public int FK_StepID { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public string UpdatedDate { get; set; }
        public bool IsActive { get; set; }
    }
}
