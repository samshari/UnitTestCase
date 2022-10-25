using Exelon.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exelon.Application.IServices
{
    public interface IOVHDMKService
    {
        public Task<List<OVHDMKModel>> GetOVHD(int id = 0);
        public Task<Dictionary<OVHDMKModel, string>> CreateOVHD(OVHDMKModel oVHDMKModel);
        public Task<OVHDMKModel> UpdateOVHD(OVHDMKModel oVHDMKModel);
        public Task<int> DeleteOVHD(int id);
    }
}
