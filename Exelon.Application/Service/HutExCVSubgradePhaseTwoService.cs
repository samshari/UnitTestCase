using Exelon.Application.IServices;
using Exelon.Domain.Abstractions;
using Exelon.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exelon.Application.Service
{
    public class HutExCVSubgradePhaseTwoService : IHutExCVSubgradePhaseTwoService
    {
        private readonly IHutExCVSubgradePhaseTwoRepository _hutExCVSubgradePhaseTwoRepository;

        public HutExCVSubgradePhaseTwoService(IHutExCVSubgradePhaseTwoRepository hutExCVSubgradePhaseTwoRepository)
        {
            _hutExCVSubgradePhaseTwoRepository = hutExCVSubgradePhaseTwoRepository;
        }

        public async  Task<List<HutExCVSubgradePhaseTwoModel>> GetHutExCV(int id = 0)
        {
            return await _hutExCVSubgradePhaseTwoRepository.GetHutExCV(id);
        }

        public async Task<HutExCVSubgradePhaseTwoModel> CreateHutExCV(HutExCVSubgradePhaseTwoModel hutExCVSubgradePhaseTwoModel)
        {
            return await _hutExCVSubgradePhaseTwoRepository.CreateHutExCV(hutExCVSubgradePhaseTwoModel);
        }

        public async Task<HutExCVSubgradePhaseTwoModel> UpdateHutExCV(HutExCVSubgradePhaseTwoModel hutExCVSubgradePhaseTwoModel)
        {
            return await _hutExCVSubgradePhaseTwoRepository.UpdateHutExCV(hutExCVSubgradePhaseTwoModel);
        }

        public async Task<int> DeleteHutExCV(int id)
        {
            return await _hutExCVSubgradePhaseTwoRepository.DeleteHutExCV(id);
        }

    }
}
