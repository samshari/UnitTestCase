using Exelon.Application.IServices;
using Exelon.Domain.Abstractions;
using Exelon.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exelon.Application.Service
{
    public class HutExRouterUpgradePhaseThreeService : IHutExRouterUpgradePhaseThreeService
    {
        private readonly IHutExRouterUpgradePhaseThreeRepository _hutExRouterUpgradePhaseThreeRepository;
        public HutExRouterUpgradePhaseThreeService(IHutExRouterUpgradePhaseThreeRepository hutExRouterUpgradePhaseThreeRepository)
        {
            _hutExRouterUpgradePhaseThreeRepository = hutExRouterUpgradePhaseThreeRepository;
        }

        public async Task<List<HutExRouterUpgradePhaseThreeModel>> GetHutRouterP3(int id = 0)
        {
            return await _hutExRouterUpgradePhaseThreeRepository.GetHutRouterP3(id);
        }

        public async Task<HutExRouterUpgradePhaseThreeModel> CreateHutRouterP3(HutExRouterUpgradePhaseThreeModel hutExRouterUpgradePhaseThreeModel)
        {
            return await _hutExRouterUpgradePhaseThreeRepository.CreateHutRouterP3(hutExRouterUpgradePhaseThreeModel);
        }

        public async Task<HutExRouterUpgradePhaseThreeModel> UpdateHutRouterP3(HutExRouterUpgradePhaseThreeModel hutExRouterUpgradePhaseThreeModel)
        {
            return await _hutExRouterUpgradePhaseThreeRepository.UpdateHutRouterP3(hutExRouterUpgradePhaseThreeModel);
        }

        public async Task<int> DeleteHutRouterP3(int id)
        {
            return await _hutExRouterUpgradePhaseThreeRepository.DeleteHutRouterP3(id);
        }
    }
}
