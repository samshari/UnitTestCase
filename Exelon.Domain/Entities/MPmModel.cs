using System;
using System.Collections.Generic;
using System.Text;

namespace Exelon.Domain
{
    public class MPMModel
    {
        public int PMID { get; set; }
        public string Name { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public string UpdatedDate { get; set; }
        public bool IsActive { get; set; }
    }
}
