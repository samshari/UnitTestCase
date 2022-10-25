using System;
using System.Collections.Generic;
using System.Text;

namespace Exelon.Domain
{
    public class LinkingInfoModel
    {
        public long LinkingId { get; set; }
        public string PrimaryKey { get; set; }
        public string Description { get; set; }
        public string Nickname { get; set; }
        public int PDId { get; set; }
        public string EngineeringYear { get; set; }
        public string ExecutionYear { get; set; }
        public Nullable<int> TechnologyId { get; set; }
        public Nullable<int> RegionId { get; set; }
        public Nullable<int> BarnId { get; set; }
        public string WorkOrder { get; set; }
        public string ProjectId { get; set; }
        public Nullable<int> FiberCount { get; set; }
        public string Comments { get; set; }
        public string ScopeComments { get; set; }
        public string ITN { get; set; }
        public Nullable<int> ProjectStatusId { get; set; }
        public int StepId { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public string UpdatedDate { get; set; }
        public bool IsActive { get; set; }

    }
}
