using Exelon.Application.IServices;
using Exelon.Domain;
using Exelon.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exelon.Application.Service
{
    public class PPREPLACEMENTService : IPPREPLACEMENTService
    {
        private readonly IPPReplacementRepository _pPREPLACERepository;

        public PPREPLACEMENTService(IPPReplacementRepository pPREPLACERepository)
        {
            _pPREPLACERepository = pPREPLACERepository;
        }

        public async Task<List<PPREPLACEMENTModel>> GetPPREPLACE(int id = 0)
        {
            return await _pPREPLACERepository.GetPPREPLACE(id);
        }

        public async Task<Dictionary<PPREPLACEMENTModel, string>> CreatePPREPLACE(PPREPLACEMENTModel pPREPLACEMENTModel)
        {
            return await _pPREPLACERepository.CreatePPREPLACE(pPREPLACEMENTModel);
        }

        public async Task<PPREPLACEMENTModel> UpdatePPREPLACE(PPREPLACEMENTModel pPREPLACEMENTModel)
        {
            return await _pPREPLACERepository.UpdatePPREPLACE(pPREPLACEMENTModel);
        }

        public async Task<int> DeletePPREPLACE(int id)
        {
            return await _pPREPLACERepository.DeletePPREPLACE(id);
        }
    }
}
