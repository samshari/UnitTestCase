using Exelon.Application.IServices;
using Exelon.Domain.Abstractions;
using Exelon.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Exelon.Application.Service
{
    public class HutExPowPhaseThreeService : IHutExPowPhaseThreeService
    {
        private readonly IHutExPowPhaseThreeRepository _hutExPowPhaseThreeRepository;

        public HutExPowPhaseThreeService(IHutExPowPhaseThreeRepository hutExPowPhaseThreeRepository)
        {
            _hutExPowPhaseThreeRepository = hutExPowPhaseThreeRepository;
        }

        public async  Task<List<HutExPowPhaseThreeModel>> GetHutExPowPhaseThree(int id = 0)
        {
            return await _hutExPowPhaseThreeRepository.GetHutExPowPhaseThree(id);
        }

        public async Task<HutExPowPhaseThreeModel> CreateHutExPowPhaseThree(HutExPowPhaseThreeModel hutExPowPhaseThreeModel)
        {
            return await _hutExPowPhaseThreeRepository.CreateHutExPowPhaseThree(hutExPowPhaseThreeModel);
        }

        public async Task<HutExPowPhaseThreeModel> UpdateHutExPowPhaseThree(HutExPowPhaseThreeModel hutExPowPhaseThreeModel)
        {
            return await _hutExPowPhaseThreeRepository.UpdateHutExPowPhaseThree(hutExPowPhaseThreeModel);
        }

        public async Task<int> DeleteHutExPowPhaseThree(int id)
        {
            return await _hutExPowPhaseThreeRepository.DeleteHutExPowPhaseThree(id);
        }
    }
}
