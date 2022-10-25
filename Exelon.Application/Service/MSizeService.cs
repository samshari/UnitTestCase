using Exelon.Application.IServices;
using Exelon.Domain;
using Exelon.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exelon.Application.Service
{
    public class MSIZEService : IMSIZEService
    {
        private readonly IMSIZERepository _mSIZERepository;

        public MSIZEService(IMSIZERepository mSIZERepository)
        {
            _mSIZERepository = mSIZERepository;
        }

        public async Task<List<MSIZEModel>> GetMSIZE(int id = 0)
        {
            return await _mSIZERepository.GetMSIZE(id);
        }

        public async Task<Dictionary<MSIZEModel, string>> CreateMSIZE(MSIZEModel mSIZEModel)
        {
            return await _mSIZERepository.CreateMSIZE(mSIZEModel);
        }

        public async Task<Dictionary<MSIZEModel, string>> UpdateMSIZE(MSIZEModel mSIZEModel)
        {
            return await _mSIZERepository.UpdateMSIZE(mSIZEModel);
        }

        public async Task<int> DeleteMSIZE(int id)
        {
            return await _mSIZERepository.DeleteMSIZE(id);
        }
    }
}
