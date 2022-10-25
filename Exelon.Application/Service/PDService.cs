using Exelon.Application.IServices;
using Exelon.Domain;
using Exelon.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exelon.Application.Service
{
    public class PDService : IPDService
    {
        private readonly IPDRepository _pDRepository;

        public PDService(IPDRepository MPDRepository)
        {
            _pDRepository = MPDRepository;
        }

        public async Task<List<PdModel>> GetPD(int id = 0)
        {
            return await _pDRepository.GetPD(id);
        }

        public async Task<PdModel> CreatePD(PdModel pDModel)
        {
            return await _pDRepository.CreatePD(pDModel);
        }

        public async Task<PdModel> UpdatePD(PdModel mPDModel)
        {
            return await _pDRepository.UpdatePD(mPDModel);
        }

        public async Task<int> DeletePD(int id)
        {
            return await _pDRepository.DeletePD(id);
        }
    }
}
