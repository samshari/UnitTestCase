using Exelon.Application.IServices;
using Exelon.Domain;
using Exelon.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exelon.Application.Service
{
    public class OVHDMKService : IOVHDMKService
    {
        private readonly IOVHDMKRepository _oVHDMKRepository;

        public OVHDMKService(IOVHDMKRepository oVHDMKRepository)
        {
            _oVHDMKRepository = oVHDMKRepository;
        }

        public async Task<List<OVHDMKModel>> GetOVHD(int id = 0)
        {
            return await _oVHDMKRepository.GetOVHD(id);
        }
        public async  Task<Dictionary<OVHDMKModel, string>> CreateOVHD(OVHDMKModel oVHDMKModel)
        {
            return await _oVHDMKRepository.CreateOVHD(oVHDMKModel);
        }
        public async Task<OVHDMKModel> UpdateOVHD(OVHDMKModel oVHDMKModel)
        {
            return await _oVHDMKRepository.UpdateOVHD(oVHDMKModel);
        }
        public  async Task<int> DeleteOVHD(int id)
        {
            return await _oVHDMKRepository.DeleteOVHD(id);
        }
    }
}
