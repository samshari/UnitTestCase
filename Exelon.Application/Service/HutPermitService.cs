using Exelon.Application.IServices;
using Exelon.Domain;
using Exelon.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exelon.Application.Service
{
    public class HUTPERMITService : IHUTPERMITService
    {
        private readonly IHUTPERMITRepository _hUTPERMITRepository;

        public HUTPERMITService(IHUTPERMITRepository hUTPERMITRepository)
        {
            _hUTPERMITRepository = hUTPERMITRepository;
        }

        public async Task<List<HUTPERMITTINGModel>> GetHUT(int id = 0)
        {
            return await _hUTPERMITRepository.GetHUT(id);
        }

        public async Task<Dictionary<HUTPERMITTINGModel, string>> CreateHUT(HUTPERMITTINGModel hUTPERMITTINGModel)
        {
            return await _hUTPERMITRepository.CreateHUT(hUTPERMITTINGModel);
        }

        public async Task<Dictionary<HUTPERMITTINGModel, string>> UpdateHUT(HUTPERMITTINGModel hUTPERMITTINGModel)
        {
            return await _hUTPERMITRepository.UpdateHUT(hUTPERMITTINGModel);
        }

        public async Task<int> DeleteHUT(int id)
        {
            return await _hUTPERMITRepository.DeleteHUT(id);
        }
        public async Task<List<HUTPERMITTINGModel>> GetHutBySub(string id)
        {
            return await _hUTPERMITRepository.GetHutBySub(id);
        }
    }
}
