using Exelon.Application.IServices;
using Exelon.Domain.Abstractions;
using Exelon.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exelon.Application.Service
{
    public class HutExAuxPowerPhaseTwoService : IHutExAuxPowerPhaseTwoService
    {
        private readonly IHutExAuxPowerPhaseTwoRepository _hutExAuxPowerPhaseTwoRepository;

        public HutExAuxPowerPhaseTwoService(IHutExAuxPowerPhaseTwoRepository hutExAuxPowerPhaseTwoRepository)
        {
            _hutExAuxPowerPhaseTwoRepository = hutExAuxPowerPhaseTwoRepository;
        }

        public async Task<List<HutExAuxPowerPhaseTwoModel>> GetHutPhaseTwo(int id = 0)
        {
            return await _hutExAuxPowerPhaseTwoRepository.GetHutPhaseTwo(id);
        }

        public async Task<HutExAuxPowerPhaseTwoModel> CreateHutPhaseTwo(HutExAuxPowerPhaseTwoModel hutExAuxPowerPhaseTwoModel)
        {
            return await _hutExAuxPowerPhaseTwoRepository.CreateHutPhaseTwo(hutExAuxPowerPhaseTwoModel);
        }

        public async Task<HutExAuxPowerPhaseTwoModel> UpdateHutPhaseTwo(HutExAuxPowerPhaseTwoModel hutExAuxPowerPhaseTwoModel)
        {
            return await _hutExAuxPowerPhaseTwoRepository.UpdateHutPhaseTwo(hutExAuxPowerPhaseTwoModel);
        }

        public async Task<int> DeleteHutPhaseTwo(int id)
        {
            return await _hutExAuxPowerPhaseTwoRepository.DeleteHutPhaseTwo(id);
        }
    }
}
