using Exelon.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exelon.Application.IServices
{
    public interface IHUTPERMITService
    {
        public Task<List<HUTPERMITTINGModel>> GetHUT(int id = 0);
        public Task<List<HUTPERMITTINGModel>> GetHutBySub(string id);
        public Task<Dictionary<HUTPERMITTINGModel, string>> CreateHUT(HUTPERMITTINGModel hUTPERMITTINGModel);
        public Task<Dictionary<HUTPERMITTINGModel, string>> UpdateHUT(HUTPERMITTINGModel hUTPERMITTINGModel);
        public Task<int> DeleteHUT(int id);
    }
}
