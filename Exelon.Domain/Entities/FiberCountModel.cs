using System;
using System.Collections.Generic;
using System.Text;

namespace Exelon.Domain
{
    public class FiberCountModel
    {
        public int FiberCountID { get; set; }
        public int FiberCountValue { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public string UpdatedDate { get; set; }
    }
}
