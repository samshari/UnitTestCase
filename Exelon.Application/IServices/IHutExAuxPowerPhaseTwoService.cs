using Exelon.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Exelon.Application.IServices
{
    public interface IHutExAuxPowerPhaseTwoService
    {
        public Task<List<HutExAuxPowerPhaseTwoModel>> GetHutPhaseTwo(int id = 0);
        public Task<HutExAuxPowerPhaseTwoModel> CreateHutPhaseTwo(HutExAuxPowerPhaseTwoModel hutExAuxPowerPhaseTwoModel);
        public Task<HutExAuxPowerPhaseTwoModel> UpdateHutPhaseTwo(HutExAuxPowerPhaseTwoModel hutExAuxPowerPhaseTwoModel);
        public Task<int> DeleteHutPhaseTwo(int id);
    }
}
