using Exelon.Application.IServices;
using Exelon.Domain;
using Exelon.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exelon.Application.Service
{
    public  class MCOCBIDCOMService : IMCOCBIDCOMService
    {
        private readonly IMCOCBIDCOMRepository _mCOCBIDCOMRepository;

        public MCOCBIDCOMService(IMCOCBIDCOMRepository mCOCBIDCOMRepository)
        {
            _mCOCBIDCOMRepository = mCOCBIDCOMRepository;
        }

        public async Task<List<MCocBidComModel>> GetMCOCBID(int id = 0)
        {
            return await _mCOCBIDCOMRepository.GetMCOCBID(id);
        }

        public async Task<Dictionary<MCocBidComModel, string>> CreateMCOCBID(MCocBidComModel mCOCBIDCCOMModel)
        {
            return await _mCOCBIDCOMRepository.CreateMCOCBID(mCOCBIDCCOMModel);
        }

        public async Task<MCocBidComModel> UpdateMCOCBID(MCocBidComModel mCOCBIDCCOMModel)
        {
            return await _mCOCBIDCOMRepository.UpdateMCOCBID(mCOCBIDCCOMModel);
        }

        public async Task<int> DeleteMCOCBID(int id)
        {
            return await _mCOCBIDCOMRepository.DeleteMCOCBID(id);
        }
    }
}
