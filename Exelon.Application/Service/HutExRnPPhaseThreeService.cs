using Exelon.Application.IServices;
using Exelon.Domain.Abstractions;
using Exelon.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exelon.Application.Service
{
    public class HutExRnPPhaseThreeService : IHutExRnPPhaseThreeService
    {
        private readonly IHutExRnPPhaseThreeRepository _hutExRnPPhaseThreeRepository;

        public HutExRnPPhaseThreeService(IHutExRnPPhaseThreeRepository hutExRnPPhaseThreeRepository)
        {
            _hutExRnPPhaseThreeRepository = hutExRnPPhaseThreeRepository;
        }

        public async Task<List<HutExRnPPhaseThreeModel>> GetHutRnPPhaseThree(int id = 0)
        {
            return await _hutExRnPPhaseThreeRepository.GetHutRnPPhaseThree(id);
        }

        public async Task<HutExRnPPhaseThreeModel> CreateHutRnPPhaseThree(HutExRnPPhaseThreeModel hutExRnPPhaseThreeModel)
        {
            return await _hutExRnPPhaseThreeRepository.CreateHutRnPPhaseThree(hutExRnPPhaseThreeModel);
        }

        public async Task<HutExRnPPhaseThreeModel> UpdateHutRnPPhaseThree(HutExRnPPhaseThreeModel hutExRnPPhaseThreeModel)
        {
            return await _hutExRnPPhaseThreeRepository.UpdateHutRnPPhaseThree(hutExRnPPhaseThreeModel);
        }

        public async Task<int> DeleteHutRnPPhaseThree(int id)
        {
            return await _hutExRnPPhaseThreeRepository.DeleteHutRnPPhaseThree(id);
        }
    }
}
