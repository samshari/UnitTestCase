using Exelon.Application.IServices;
using Exelon.Domain.Abstractions;
using Exelon.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exelon.Application.Service
{
    public class HutExFiberPhaseThreeService : IHutExFiberPhaseThreeService
    {
        private readonly IHutExFiberPhaseThreeRepository _hutExFiberPhaseThreeRepository;
        public HutExFiberPhaseThreeService(IHutExFiberPhaseThreeRepository hutExFiberPhaseThreeRepository)
        {
            _hutExFiberPhaseThreeRepository = hutExFiberPhaseThreeRepository;
        }

        public async Task<List<HutExFiberPhaseThreeModel>> GetHutFiber(int id = 0)
        {
            return await _hutExFiberPhaseThreeRepository.GetHutFiber(id);
        }

        public async Task<HutExFiberPhaseThreeModel> CreateHutFiber(HutExFiberPhaseThreeModel hutExFiberPhaseThreeModel)
        {
            return await _hutExFiberPhaseThreeRepository.CreateHutFiber(hutExFiberPhaseThreeModel);
        }

        public async Task<HutExFiberPhaseThreeModel> UpdateHutFiber(HutExFiberPhaseThreeModel hutExFiberPhaseThreeModel)
        {
            return await _hutExFiberPhaseThreeRepository.UpdateHutFiber(hutExFiberPhaseThreeModel);
        }

        public async Task<int> DeleteHutFiber(int id)
        {
            return await _hutExFiberPhaseThreeRepository.DeleteHutFiber(id);
        }
    }
}
