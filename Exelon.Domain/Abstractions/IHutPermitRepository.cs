
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exelon.Domain.Abstractions
{
    public interface IHUTPERMITRepository
    {
        public Task<List<HUTPERMITTINGModel>> GetHUT(int id = 0);
        public Task<HUTPERMITTINGModel> CreateHUT(HUTPERMITTINGModel hUTPERMITTINGModel);
        public Task<HUTPERMITTINGModel> UpdateHUT(HUTPERMITTINGModel hUTPERMITTINGModel);
        public Task<int> DeleteHUT(int id);
    }
}
