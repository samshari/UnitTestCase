
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exelon.Domain.Abstractions
{
    public interface IHUTPERMITRepository
    {
        public Task<List<HUTPERMITTINGModel>> GetHUT(int id = 0);
        public Task<List<HUTPERMITTINGModel>> GetHutBySub(string id);
        public Task<Dictionary<HUTPERMITTINGModel, string>> CreateHUT(HUTPERMITTINGModel hUTPERMITTINGModel);
        public Task<Dictionary<HUTPERMITTINGModel, string>> UpdateHUT(HUTPERMITTINGModel hUTPERMITTINGModel);
        public Task<int> DeleteHUT(int id);
    }
}
