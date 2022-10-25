
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exelon.Domain.Abstractions
{
    public interface IOVHDMKRepository
    {
        public Task<List<OVHDMKModel>> GetOVHD(int id = 0);
        public Task<Dictionary<OVHDMKModel, string>> CreateOVHD(OVHDMKModel oVHDMKModel);
        public Task<OVHDMKModel> UpdateOVHD(OVHDMKModel oVHDMKModel);
        public Task<int> DeleteOVHD(int id);
    }
}
