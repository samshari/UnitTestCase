using Exelon.Application.IServices;
using Exelon.Domain.Abstractions;
using Exelon.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Exelon.Application.Service
{
    public class HutExPhaseOneService : IHutExPhaseOneService
    {
        private readonly IHutExPhaseOneRepository _hutExPhaseOneRepository;

        public HutExPhaseOneService(IHutExPhaseOneRepository hutExPhaseOneRepository)
        {
            _hutExPhaseOneRepository = hutExPhaseOneRepository;
        }

        public async Task<List<HutExPhaseOneModel>> GetHutExPOne(int id = 0)
        {
            return await _hutExPhaseOneRepository.GetHutExPOne(id);
        }

        public async Task<HutExPhaseOneModel> CreateHutExPOne(HutExPhaseOneModel exPhaseOneModel)
        {
            return await _hutExPhaseOneRepository.CreateHutExPOne(exPhaseOneModel);
        }

        public async Task<HutExPhaseOneModel> UpdateHutExPOne(HutExPhaseOneModel exPhaseOneModel)
        {
            return await _hutExPhaseOneRepository.UpdateHutExPOne(exPhaseOneModel);
        }

        public async Task<int> DeleteHutExPOne(int id)
        {
            return await _hutExPhaseOneRepository.DeleteHutExPOne(id);
        }




    }
}
