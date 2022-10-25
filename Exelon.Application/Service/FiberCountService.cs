using Exelon.Application.IServices;
using Exelon.Domain;
using Exelon.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exelon.Application.Service
{
    public class FiberCountService : IFiberCountService
    {
        private readonly IFiberCountRepository _fIBERCOUNTRepository;

        public FiberCountService(IFiberCountRepository fIBERCOUNTRepository)
        {
            _fIBERCOUNTRepository = fIBERCOUNTRepository;
        }

        public async Task<List<FiberCountModel>> GetFIBER(int id = 0)
        {
            return await _fIBERCOUNTRepository.GetFIBER(id);
        }

        public async Task<Dictionary<FiberCountModel, string>> CreateFIBER(FiberCountModel fIBERCOUNTModel)
        {
            return await _fIBERCOUNTRepository.CreateFIBER(fIBERCOUNTModel);
        }

        public async Task<FiberCountModel> UpdateFIBER(FiberCountModel fIBERCOUNTModel)
        {
            return await _fIBERCOUNTRepository.UpdateFIBER(fIBERCOUNTModel);
        }
        
        public async Task<int> DeleteFIBER(int id)
        {
            return await _fIBERCOUNTRepository.DeleteFIBER(id);
        }
    }
}
