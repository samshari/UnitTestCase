
using Exelon.Application.IServices;
using Exelon.Domain;
using Exelon.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exelon.Application.Service
{
    public class CIVILService : ICIVILService
    {

        private readonly ICIVILRepository _cIVILRepository;

        public CIVILService(ICIVILRepository cIVILRepository)
        {
            _cIVILRepository = cIVILRepository;
        }

        public async  Task<List<CIVILModel>> GetCIVIL(int id = 0)
        {
            return await _cIVILRepository.GetCIVIL(id);
        }
        public async Task<Dictionary<CIVILModel, string>> CreateCIVIL(CIVILModel cIVILModel)
        {
            return await _cIVILRepository.CreateCIVIL(cIVILModel);
        }
        public async Task<CIVILModel> UpdateCIVIL(CIVILModel cIVILModel)
        {
            return await _cIVILRepository.UpdateCIVIL(cIVILModel);
        }
        public async Task<int> DeleteCIVIL(int id)
        {
            return await _cIVILRepository.DeleteCIVIL(id);
        }
    }
}
