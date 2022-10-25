using Exelon.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exelon.Application.IServices
{
    public interface IMCOCBIDCOMService
    {
        public Task<List<MCocBidComModel>> GetMCOCBID(int id = 0);
        public Task<Dictionary<MCocBidComModel, string>> CreateMCOCBID(MCocBidComModel mCOCBIDCCOMModel);
        public Task<MCocBidComModel> UpdateMCOCBID(MCocBidComModel mCOCBIDCCOMModel);
        public Task<int> DeleteMCOCBID(int id);
    }
}
