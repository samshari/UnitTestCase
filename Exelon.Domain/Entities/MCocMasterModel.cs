using System;
using System.Collections.Generic;
using System.Text;

namespace Exelon.Domain
{
    public class MCOCMASTERModel
    {
		public int COCID { get; set; }
		public int FK_COCTypeID { get; set; }
		public string COCName { get; set; }
		public string CreatedBy { get; set; }
		public string CreatedDate { get; set; }
		public string UpdatedBy { get; set; }
		public string UpdatedDate { get; set; }
		public bool IsActive { get; set; }
	}
}
