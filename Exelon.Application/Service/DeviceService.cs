#region [Namespaces]
using Exelon.Application.IServices;
using Exelon.Domain;
using Exelon.Domain.Abstractions;
using System.Collections.Generic;
using System.Threading.Tasks; 
#endregion

namespace Exelon.Application.Service
{
    public class DeviceService : IMDEVICEService
    {
        private readonly IDeviceRepository _deviceRepository;

        public DeviceService(IDeviceRepository deviceRepository)
        {
            _deviceRepository = deviceRepository;
        }
        public async  Task<List<DeviceModel>> GetDevice(int id = 0)
        {
            return await _deviceRepository.GetDevice(id);
        }
        public  async Task<Dictionary<DeviceModel, string>> CreateDevice(DeviceModel deviceModel)
        {
            return await _deviceRepository.CreateDevice(deviceModel);
        }
        public async Task<DeviceModel> UpdateDevice(DeviceModel mDEVICEModel)
        {
            return await _deviceRepository.UpdateDevice(mDEVICEModel);
        }
        public async Task<int> DeleteDevice(int id)
        {
            return await _deviceRepository.DeleteDevice(id);
        }
        public async Task<ExecutionDeviceModel> GetExecutionDevice(int id)
        {
            return await _deviceRepository.GetExecutionDevice(id);
        }
        public async Task<ExecutionDeviceModel> GetExecutionDeviceBYLinkId(int id)
        {
            return await _deviceRepository.GetExecutionDeviceBYLinkId(id);
        }
        public async Task<Dictionary<ExecutionDeviceModel,string>> SaveUpdateExecutionDevice(ExecutionDeviceModel model)
        {
            return await _deviceRepository.SaveUpdateExecutionDevice(model);
        }
        public async Task<ExecutionDeviceModel> UpdateExecutionDevice(ExecutionDeviceModel model)
        {
            return await _deviceRepository.UpdateExecutionDevice(model);
        }
    }
}
