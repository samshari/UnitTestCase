using System;
using System.Collections.Generic;
using System.Text;

namespace Exelon.Domain.Entities
{
   public class PerformProgressModel
    {
        public Int64 PerformProgressId { get; set; }
        public int PDId { get; set; }
        public Int64 LinkingId { get; set; }
        public DateTime WeeklyDate { get; set; }
        public decimal Miles { get; set; }
        public string PDName { get; set; }
        public string WorkOrder { get; set; }
        public string ProjectID { get; set; }
        public string ProjectManager { get; set; }
        public decimal OHMiles { get; set; }
        public decimal UGMiles { get; set; }
    }
}
