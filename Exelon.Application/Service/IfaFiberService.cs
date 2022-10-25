using Exelon.Application.IServices;
using Exelon.Domain;
using Exelon.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exelon.Application.Service
{
    public class IfaFiberService : IIfaFiberService
    {
        private readonly IIfaFiberRepository _iIFAFIBERRepository;

        public IfaFiberService(IIfaFiberRepository iIFAFIBERRepository)
        {
            _iIFAFIBERRepository = iIFAFIBERRepository;
        }

        public async Task<List<IfaFiberModel>> GetIFAFIBER(int id = 0)
        {
            return await _iIFAFIBERRepository.GetIFAFIBER(id);
        }

        public async Task<Dictionary<IfaFiberModel,string>> CreateIFAFIBER(IfaFiberModel ifaFiberModel)
        {
            return await _iIFAFIBERRepository.CreateIFAFIBER(ifaFiberModel);
        }

        public async Task<IfaFiberModel> UpdateIFAFIBER(IfaFiberModel ifaFiberModel)
        {
            return await _iIFAFIBERRepository.UpdateIFAFIBER(ifaFiberModel);
        }

        public async Task<int> DeleteIFAFIBER(int id)
        {
            return await _iIFAFIBERRepository.DeleteIFAFIBER(id);
        }
    }
}
