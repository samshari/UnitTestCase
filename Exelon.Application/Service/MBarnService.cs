using Exelon.Application.IServices;
using Exelon.Domain;
using Exelon.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exelon.Application.Service
{
    public class MBARNService : IMBarnService
    {
        private readonly IMBARNRepository _MBARNRepository;

        public MBARNService(IMBARNRepository MBARNRepository)
        {
            _MBARNRepository = MBARNRepository;
        }

        public async Task<List<MBARNModel>> GetBarn(int id = 0)
        {
            return await _MBARNRepository.GetBarn(id);
        }

        public async Task<Dictionary<MBARNModel,string>> CreateBarn(MBARNModel mBARNModel)
        {
            return await _MBARNRepository.CreateBarn(mBARNModel);
        }

        public async Task<Dictionary<MBARNModel, string>> UpdateBarn(MBARNModel mBARNModel)
        {
            return await _MBARNRepository.UpdateBarn(mBARNModel);
        }

        public async Task<int> DeleteBarn(int id)
        {
            return await _MBARNRepository.DeleteBarn(id);
        }

    }
}
