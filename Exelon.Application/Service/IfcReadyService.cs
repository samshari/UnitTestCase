using Exelon.Application.IServices;
using Exelon.Domain;
using Exelon.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exelon.Application.Service
{
    public class IfcReadyService : IIfcReadyService
    {
        private readonly IIfcReadyRepository _iFCREADYRepository;

        public IfcReadyService(IIfcReadyRepository iFCREADYRepository)
        {
            _iFCREADYRepository = iFCREADYRepository;
        }
        public async Task<List<IfcReadyModel>> GetIFC(int id = 0)
        {
            return await _iFCREADYRepository.GetIFC(id);
        }

        public async Task<Dictionary<IfcReadyModel,string>> CreateIFC(IfcReadyModel iFCREADYModel)
        {
            return await _iFCREADYRepository.CreateIFC(iFCREADYModel);
        }

        public async Task<IfcReadyModel> UpdateIFC(IfcReadyModel iFCREADYModel)
        {
            return await _iFCREADYRepository.UpdateIFC(iFCREADYModel);
        }

        public async Task<int> DeleteIFC(int id = 0)
        {
            return await _iFCREADYRepository.DeleteIFC(id);
        }
    }
}
