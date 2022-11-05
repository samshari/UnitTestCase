using System;
using System.Collections.Generic;
using System.Text;

namespace Exelon.Domain.Entities
{
   public class PDDetailsModel
    {
        public Int64 PDInformationId { get; set; }
        public int FinancialYearId { get; set; }
        public string ProjectName { get; set; }
        public int ITN { get; set; }
        public int SR { get; set; }
        public int RegionId { get; set; }
        public int BarnId { get; set; }
        public string WorkOrder { get; set; }
        public string ProjectId { get; set; }
        public int ProjectStatusId { get; set; }
        public int PDId { get; set; }
        public int LinkNickName { get; set; }
        public string JobStatus { get; set; }
        public string OwnerName { get; set; }
        public string WorkOrderPriorityLevel { get; set; }
        public DateTime? WorkOrderDueDate { get; set; }
        public string PriorityLevel { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
    }

   public class PDCOCModel
    {
        public Int64 PDCOCId { get; set; }
        public Int64 PDInformationId { get; set; }
        public string OHFiberCOC { get; set; }
        public string UGFiberCOC { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
    }
    public class PDEOCModel
    {
        public Int64 PDEOCId { get; set; }
        public Int64 PDInformationId { get; set; }
        public int EOCId { get; set; }
        public DateTime EOCReleaseDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
    }
    public class PDFiberModel
    {
        public Int64 PDFiberId { get; set; }
        public Int64 PDInformationId { get; set; }
        public int FiberCount { get; set; }
        public DateTime PDIFA { get; set; }
        public DateTime PDIFC { get; set; }
        public decimal MilesOH { get; set; }
        public decimal MilesUG { get; set; }
        public string FiberOpticHutSize { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
    }
}
