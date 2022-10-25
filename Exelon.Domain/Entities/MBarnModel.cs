using System;
using System.Collections.Generic;
using System.Text;

namespace Exelon.Domain
{
    public class MBARNModel
    {
        public int BarnID { get; set; }
        public string BarnName { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public string UpdatedDate { get; set; }
    }
}
