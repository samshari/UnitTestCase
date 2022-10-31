using System;
using System.Collections.Generic;
using System.Text;

namespace Exelon.Domain
{
    public class InnerRodRopeModel
    {
        public long RodAndRopeID { get; set; }
        public long FK_LinkingID { get; set; }
        public int FK_StepID { get; set; }
        public Nullable<DateTime> InnerductStartDate { get; set; }
        public Nullable<DateTime> InnerductEndDate { get; set; }
        public string StrInnerductStartDate { get; set; }
        public string StrInnerductEndDate { get; set; }
        public string Comments { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public string UpdatedDate { get; set; }
    }
}
