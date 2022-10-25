using Exelon.Application.IServices;
using Exelon.Domain;
using Exelon.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exelon.Application.Service
{
    public class IFCDATESService : IIFCDATESService
    {
        private readonly IIFCDATESRepository _iFCDATESRepository;

        public IFCDATESService(IIFCDATESRepository iFCDATESRepository)
        {
            _iFCDATESRepository = iFCDATESRepository;
        }

        public async Task<List<IFCDATESModel>> GetIFCDATES(int id = 0)
        {
            return await _iFCDATESRepository.GetIFCDATES(id);
        }

        public async Task<Dictionary<IFCDATESModel, string>> CreateIFCDATES(IFCDATESModel iFCDATESModel)
        {
            return await _iFCDATESRepository.CreateIFCDATES(iFCDATESModel);
        }

        public async Task<IFCDATESModel> UpdateIFCDATES(IFCDATESModel iFCDATESModel)
        {
            return await _iFCDATESRepository.UpdateIFCDATES(iFCDATESModel);
        }

        public async Task<int> DeleteIFCDATES(int id)
        {
            return await _iFCDATESRepository.DeleteIFCDATES(id);
        }
    }
}
