using Exelon.Application.IServices;
using Exelon.Domain;
using Exelon.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exelon.Application.Service
{
    public class IfaReadyService : IIfaReadyService
    {
        private readonly IIfaReadyRepository _iFAREADYRepository;

        public IfaReadyService(IIfaReadyRepository iFAREADYRepository)
        {
            _iFAREADYRepository = iFAREADYRepository;
        }
        public async Task<List<IfaReadyModel>> GetIFA(int id = 0)
        {
            return await _iFAREADYRepository.GetIFA(id);
        }

        public async Task<Dictionary<IfaReadyModel,string>> CreateIFA(IfaReadyModel iFAREADYModel)
        {
            return await _iFAREADYRepository.CreateIFA(iFAREADYModel);
        }

        public async Task<IfaReadyModel> UpdateIFA(IfaReadyModel iFAREADYModel)
        {
            return await _iFAREADYRepository.UpdateIFA(iFAREADYModel);
        }

        public async Task<int> DeleteIFA(int id = 0)
        {
            return await _iFAREADYRepository.DeleteIFA(id);
        }
    }
}
