using Exelon.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Exelon.Application.IServices
{
    public interface IMCocService
    {
        Task<List<MCOCModel>> GetMCOC(int id = 0);
        Task<Dictionary<MCOCModel,string>> CreateMCOC(MCOCModel mCOCModel);
        Task<Dictionary<MCOCModel, string>> UpdateMCOC(MCOCModel mCOCModel);
        Task<int> DeleteMCOC(int id);
    }
}
