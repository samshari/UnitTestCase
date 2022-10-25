using Exelon.Application.IServices;
using Exelon.Domain;
using Exelon.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exelon.Application.Service
{
    public class MPMService : IMPMService
    {
        private readonly IMPMRepository _MPMRepository;

        public MPMService(IMPMRepository MPMRepository)
        {
            _MPMRepository = MPMRepository;
        }

        public async Task<List<MPMModel>> GetMPM(int id = 0)
        {
            return await _MPMRepository.GetMPM(id);
        }

        public async Task<Dictionary<MPMModel,string>> CreateMPM(MPMModel mPMModel)
        {
            return await _MPMRepository.CreateMPM(mPMModel);
        }

        public async Task<Dictionary<MPMModel, string>> UpdateMPM(MPMModel mPMModel)
        {
            return await _MPMRepository.UpdateMPM(mPMModel);
        }

        public async Task<int> DeleteMPM(int id)
        {
            return await _MPMRepository.DeleteMPM(id);
        }
    }
}
