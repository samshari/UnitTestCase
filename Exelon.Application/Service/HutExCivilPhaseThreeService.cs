using Exelon.Application.IServices;
using Exelon.Domain.Abstractions;
using Exelon.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Exelon.Application.Service
{
    public class HutExCivilPhaseThreeService : IHutExCivilPhaseThreeService
    {
        private readonly IHutExCivilPhaseThreeRepository _hutExCivilPhaseThreeRepository;

        public HutExCivilPhaseThreeService(IHutExCivilPhaseThreeRepository hutExCivilPhaseThreeRepository)
        {
            _hutExCivilPhaseThreeRepository = hutExCivilPhaseThreeRepository;
        }

        public async Task<List<HutExCivilPhaseThreeModel>> GetHutCivilPhaseThree(int id = 0)
        {
            return await _hutExCivilPhaseThreeRepository.GetHutCivilPhaseThree(id);
        }

        public async Task<HutExCivilPhaseThreeModel> CreateCivilPhaseThree(HutExCivilPhaseThreeModel hutExCivilPhaseThreeModel)
        {
            return await _hutExCivilPhaseThreeRepository.CreateCivilPhaseThree(hutExCivilPhaseThreeModel);
        }

        public async Task<HutExCivilPhaseThreeModel> UpdateCivilPhaseThree(HutExCivilPhaseThreeModel hutExCivilPhaseThreeModel)
        {
            return await _hutExCivilPhaseThreeRepository.UpdateCivilPhaseThree(hutExCivilPhaseThreeModel);
        }

        public async Task<int> DeleteCivilPhaseThree(int id)
        {
            return await _hutExCivilPhaseThreeRepository.DeleteCivilPhaseThree(id);
        }
    }
}
