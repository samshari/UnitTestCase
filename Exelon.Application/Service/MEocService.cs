
using Exelon.Application.IServices;
using Exelon.Domain;
using Exelon.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exelon.Application.Service
{
    public class MEOCService : IMEOCService
    {
        private readonly IMEOCRepository _MEOCRepository;
        
        public MEOCService(IMEOCRepository MEOCRepository)
        {
            _MEOCRepository = MEOCRepository;
        }

        public async Task<List<MEOCModel>> GetMEOC(int id = 0)
        {
            return await _MEOCRepository.GetMEOC(id);
        }

        public async Task<Dictionary<MEOCModel,string>> CreateMEOC(MEOCModel mEOCModel)
        {
            return await _MEOCRepository.CreateMEOC(mEOCModel);
        }

        public async Task<Dictionary<MEOCModel, string>> UpdateMEOC(MEOCModel mEOCModel)
        {
            return await _MEOCRepository.UpdateMEOC(mEOCModel);
        }

        public async Task<int> DeleteMEOC(int id)
        {
            return await _MEOCRepository.DeleteMEOC(id);
        }
    }
}
