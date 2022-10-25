using Exelon.Application.IServices;
using Exelon.Domain;
using Exelon.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exelon.Application.Service
{
    public class IfcFiberService : IIfcFiberService
    {
        private readonly IIFCFIBERRepository _iIFCFIBERRepository;

        public IfcFiberService(IIFCFIBERRepository iIFCFIBERRepository)
        {
            _iIFCFIBERRepository = iIFCFIBERRepository;
        }

        public async Task<List<IfcFiberModel>> GetIFCFIBER(int id = 0)
        {
            return await _iIFCFIBERRepository.GetIFCFIBER(id);
        }

        public async Task<Dictionary<IfcFiberModel,string>> CreateIFCFIBER(IfcFiberModel mIFCFIBERModel)
        {
            return await _iIFCFIBERRepository.CreateIFCFIBER(mIFCFIBERModel);
        }

        public async Task<IfcFiberModel> UpdateIFCFIBER(IfcFiberModel mIFCFIBERModel)
        {
            return await _iIFCFIBERRepository.UpdateIFCFIBER(mIFCFIBERModel);
        }

        public async Task<int> DeleteIFCFIBER(int id)
        {
            return await _iIFCFIBERRepository.DeleteIFCFIBER(id);
        }
    }
}
