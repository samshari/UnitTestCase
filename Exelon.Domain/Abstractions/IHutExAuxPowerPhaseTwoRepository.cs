using Exelon.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exelon.Domain.Abstractions
{
    public interface IHutExAuxPowerPhaseTwoRepository
    {
        public Task<List<HutExAuxPowerPhaseTwoModel>> GetHutPhaseTwo(int id = 0);
        public Task<HutExAuxPowerPhaseTwoModel> CreateHutPhaseTwo(HutExAuxPowerPhaseTwoModel hutExAuxPowerPhaseTwoModel);
        public Task<HutExAuxPowerPhaseTwoModel> UpdateHutPhaseTwo(HutExAuxPowerPhaseTwoModel hutExAuxPowerPhaseTwoModel);
        public Task<int> DeleteHutPhaseTwo(int id);
    }
}
