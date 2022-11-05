using Exelon.Application.IServices;
using Exelon.Domain;
using Exelon.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exelon.Application.Service
{
    public class COMEDEXService : ICOMEDEXService
    {
        private readonly ICOMEDEXRepository _comEdRepository;

        public COMEDEXService(ICOMEDEXRepository repository)
        {
            _comEdRepository = repository;
        }

        public async Task<List<COMEDEXModel>> GetComEd(int id = 0)
        {
            return await _comEdRepository.GetComEd(id);
        }
        public async Task<Dictionary<COMEDEXModel, string>> CreateComEd(COMEDEXModel model)
        {
            return await _comEdRepository.CreateComEd(model);
        }
        public async Task<COMEDEXModel> UpdateComEd(COMEDEXModel model)
        {
            return await _comEdRepository.UpdateComEd(model);
        }
        public async Task<int> DeleteComEd(int id)
        {
            return await _comEdRepository.DeleteComEd(id);
        }
        public async Task<List<COMEDEXModel>> GetLnL()
        {
            return await _comEdRepository.GetLnL();
        }
       public async Task<int> GetComEdIdByLinkingId(long linkingId)
        {
            return await _comEdRepository.GetComEdIdByLinkingId(linkingId);
        }
    }
}
