using Exelon.Application.IServices;
using Exelon.Domain.Abstractions;
using Exelon.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Exelon.Application.Service
{
    public class MPhaseService : IMPhaseService
    {
        private readonly IMPhaseRepository _mPhaseRepository;
        public MPhaseService(IMPhaseRepository mPhaseRepository)
        {
            _mPhaseRepository = mPhaseRepository;
        }

        public async  Task<List<MPhaseModel>> GetMPhase(int id = 0)
        {
            return await _mPhaseRepository.GetMPhase(id);
        }
    }
}
