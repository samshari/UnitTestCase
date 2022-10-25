
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exelon.Domain.Abstractions
{
    public interface IMCOCBIDCOMRepository
    {
        public Task<List<MCocBidComModel>> GetMCOCBID(int id = 0);
        public Task<Dictionary<MCocBidComModel, string>> CreateMCOCBID(MCocBidComModel mCOCBIDCCOMModel);
        public Task<MCocBidComModel> UpdateMCOCBID(MCocBidComModel mCOCBIDCCOMModel);
        public Task<int> DeleteMCOCBID(int id);
    }
}
