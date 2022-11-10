using Exelon.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Exelon.Application.IServices
{
    public interface IMDEVICEService
    {
        public Task<List<DeviceModel>> GetDevice(int id = 0);
        public Task<Dictionary<DeviceModel, string>> CreateDevice(DeviceModel dEVICEModel);
        public Task<DeviceModel> UpdateDevice(DeviceModel dEVICEModel);
        public Task<int> DeleteDevice(int id);
        public Task<ExecutionDeviceModel> GetExecutionDevice(int id);
        public Task<ExecutionDeviceModel> GetExecutionDeviceBYLinkId(int id);
        public Task<Dictionary<ExecutionDeviceModel,string>> SaveUpdateExecutionDevice(ExecutionDeviceModel model);
        public Task<ExecutionDeviceModel> UpdateExecutionDevice(ExecutionDeviceModel model);

    }
}
