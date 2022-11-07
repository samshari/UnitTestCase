using System;
using System.Collections.Generic;
using System.Text;

namespace Exelon.Domain.Entities
{
   public class OSPPermitEasementModel
    {
        public Int64 PermitId { get; set; }
        public int PDId { get; set; }
        public string PId { get; set; }
        public string Link { get; set; }
        public decimal Miles { get; set; }
        public string CurrentIFADate { get; set; }
        public string ExecutionQuarterStart { get; set; }
        public int ExecutionQuarterFinish { get; set; }
        public string ExecutionYear { get; set; }
        public int EasementsRes { get; set; }
        public int EasementsReq { get; set; }
        public int PermitStatusIDOTPermitsRes { get; set; }
        public int PermitStatusIDOTPermitsReq { get; set; }
        public int PermitStatusEnvironmentalPermitReq { get; set; }
        public int PermitStatusEnvironmentalPermitRes { get; set; }
        public int PermitStatusRRMetraPermitReq { get; set; }
        public int PermitStatusRRMetraPermitRes { get; set; }
        public int PermitStatusCityCountryPermitReq { get; set; }
        public int PermitStatusCityCountryPermitRes { get; set; }
        public int PermitStatusTROWPermitReq { get; set; }
        public int PermitStatusTROWPermitRes { get; set; }
        public int PotentialIssuesConcerns { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
    }
}
