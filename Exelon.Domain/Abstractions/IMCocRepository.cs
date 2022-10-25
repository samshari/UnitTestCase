
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Exelon.Domain.Abstractions
{
    public interface IMCocRepository
    {
        Task<List<MCOCModel>> GetMCOC(int id);
        Task<Dictionary<MCOCModel,string>> CreateMCOC(MCOCModel mCOCModel);
        Task<Dictionary<MCOCModel,string>> UpdateMCOC(MCOCModel mCOCModel);
        Task<int> DeleteMCOC(int id);
    }
}
