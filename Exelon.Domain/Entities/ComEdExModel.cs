using System;
using System.Collections.Generic;
using System.Text;

namespace Exelon.Domain
{
    public class COMEDEXModel
    {
		public long ComEdId { get; set; }
		public long LinkingId { get; set; }
		public int FK_StepID { get; set; }
		public Nullable<int> LNLId{ get; set; }
        public string CreatedBy { get; set; }
        public string CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public string UpdatedDate { get; set; }
        public bool IsActive { get; set; }
        public string Name { get; set; }
        public int Id { get; set; }
    }
}
