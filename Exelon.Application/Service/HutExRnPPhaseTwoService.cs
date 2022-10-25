using Exelon.Application.IServices;
using Exelon.Domain.Abstractions;
using Exelon.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exelon.Application.Service
{
    public class HutExRnPPhaseTwoService : IHutExRnPPhaseTwoService
    {
        private readonly IHutExRnPPhaseTwoRepository _hutExRnPPhaseTwoRepository;

        public HutExRnPPhaseTwoService(IHutExRnPPhaseTwoRepository hutExRnPPhaseTwoRepository)
        {
            _hutExRnPPhaseTwoRepository = hutExRnPPhaseTwoRepository;
        }


        public async Task<List<HutExRnPPhaseTwoModel>> GetHutExRnPhaseTwo(int id = 0)
        {
            return await _hutExRnPPhaseTwoRepository.GetHutExRnPhaseTwo(id);
        }
        public async Task<HutExRnPPhaseTwoModel> CreateHutExRnPhaseTwo(HutExRnPPhaseTwoModel hutExRnPPhaseTwoModel)
        {
            return await _hutExRnPPhaseTwoRepository.CreateHutExRnPhaseTwo(hutExRnPPhaseTwoModel);
        }

        public async  Task<HutExRnPPhaseTwoModel> UpdateHutExRnPhaseTwo(HutExRnPPhaseTwoModel hutExRnPPhaseTwoModel)
        {
            return await _hutExRnPPhaseTwoRepository.UpdateHutExRnPhaseTwo(hutExRnPPhaseTwoModel);
        }

        public async  Task<int> DeleteHutExRnPhaseTwo(int id)
        {
            return await _hutExRnPPhaseTwoRepository.DeleteHutExRnPhaseTwo(id);
        }
    }
}
