﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Exelon.Domain
{
    public class CIVILModel
    {
		public long	CivilID { get; set; }
		public long FK_LinkingID { get; set; }
		public int FK_stepID { get; set; }
		public Nullable<int> FK_CivilCOCID { get; set; }
		public string IssuesOrComments { get; set; }
		public Nullable<DateTime> StartDate { get; set; }
		public Nullable<DateTime> EndDate { get; set; }
		public string StrStartDate { get; set; }
		public string StrEndDate { get; set; }
		public string WeeklyFTECount { get; set; }
		public string CreatedBy { get; set; }
		public string CreatedDate { get; set; }
		public string UpdatedBy { get; set; }
		public string UpdatedDate { get; set; }
		public bool IsActive { get; set; }
	}
}
