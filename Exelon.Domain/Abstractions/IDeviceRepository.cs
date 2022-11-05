using System.Collections.Generic;
using System.Threading.Tasks;

namespace Exelon.Domain.Abstractions
{
    public interface IDeviceRepository
    {
        public Task<List<DeviceModel>> GetDevice(int id = 0);
        public Task<Dictionary<DeviceModel, string>> CreateDevice(DeviceModel model);
        public Task<DeviceModel> UpdateDevice(DeviceModel model);
        public Task<int> DeleteDevice(int id);
        public Task<ExecutionDeviceModel> GetExecutionDevice(int id);
        public Task<ExecutionDeviceModel> SaveUpdateExecutionDevice(ExecutionDeviceModel model);
    }
}
