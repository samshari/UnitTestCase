using Exelon.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exelon.Application.IServices
{
    public interface IHutExRouterUpgradePhaseThreeService
    {
        public Task<List<HutExRouterUpgradePhaseThreeModel>> GetHutRouterP3(int id = 0);
        public Task<HutExRouterUpgradePhaseThreeModel> CreateHutRouterP3(HutExRouterUpgradePhaseThreeModel hutExRouterUpgradePhaseThreeModel);
        public Task<HutExRouterUpgradePhaseThreeModel> UpdateHutRouterP3(HutExRouterUpgradePhaseThreeModel hutExRouterUpgradePhaseThreeModel);
        public Task<int> DeleteHutRouterP3(int id);

    }
}
