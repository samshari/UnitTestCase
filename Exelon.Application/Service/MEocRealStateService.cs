using Exelon.Application.IServices;
using Exelon.Domain;
using Exelon.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exelon.Application.Service
{
    public class MEOCREALSTATEService : IMEOCREALSTATEService
    {
        private readonly IMEOCREALSTATERepository _MEOCREALSTATERepository;
        public MEOCREALSTATEService(IMEOCREALSTATERepository MEOCREALSTATERepository)
        {
            _MEOCREALSTATERepository = MEOCREALSTATERepository;
        }

        public async Task<List<MEOCREALSTATEModel>> GetMEOCREALSTATE(int id = 0)
        {
            return await _MEOCREALSTATERepository.GetMEOCREALSTATE(id);
        }

        public async Task<Dictionary<MEOCREALSTATEModel,string>> CreateMEOCREALSTATE(MEOCREALSTATEModel mEOCREALSTATEModel)
        {
            return await _MEOCREALSTATERepository.CreateMEOCREALSTATE(mEOCREALSTATEModel);
        }

        public async Task<Dictionary<MEOCREALSTATEModel, string>> UpdateMEOCREALSTATE(MEOCREALSTATEModel mEOCREALSTATEModel)
        {
            return await _MEOCREALSTATERepository.UpdateMEOCREALSTATE(mEOCREALSTATEModel);
        }

        public async Task<int> DeleteMEOCREALSTATE(int id)
        {
            return await _MEOCREALSTATERepository.DeleteMEOCREALSTATE(id);
        }
    }
}
