using System;
using System.Collections.Generic;
using System.Text;

namespace Exelon.Domain
{
    public class DeviceModel
    {
        public long DeviceId { get; set; }
        public long LinkingId { get; set; }
        public int StepId { get; set; }
        public int TotalDevices { get; set; }
        public string DeviceType { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public string UpdatedDate { get; set; }
        public bool IsActive { get; set; }
    }
}
