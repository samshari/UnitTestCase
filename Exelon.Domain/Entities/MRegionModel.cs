using System;
using System.Collections.Generic;
using System.Text;

namespace Exelon.Domain
{
    public class MREGIONModel
    {
        public int RegionID { get; set; }
        public string RegionName { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public string UpdatedDate { get; set; }
        public bool IsActive { get; set; }


    }
}
