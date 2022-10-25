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
        private readonly ICOMEDEXRepository _cOMEDEXRepository;


        public COMEDEXService(ICOMEDEXRepository cOMEDEXRepository)
        {
            _cOMEDEXRepository = cOMEDEXRepository;
        }


        public async Task<List<COMEDEXModel>> GetCOMED(int id = 0)
        {
            return await _cOMEDEXRepository.GetCOMED(id);
        }

        public async Task<Dictionary<COMEDEXModel, string>> CreateCOMED(COMEDEXModel cOMEDEXModel)
        {
            return await _cOMEDEXRepository.CreateCOMED(cOMEDEXModel);
        }

        public async Task<COMEDEXModel> UpdateCOMED(COMEDEXModel cOMEDEXModel)
        {
            return await _cOMEDEXRepository.UpdateCOMED(cOMEDEXModel);
        }

        public async Task<int> DeleteCOMED(int id)
        {
            return await _cOMEDEXRepository.DeleteCOMED(id);
        }
    }
}
