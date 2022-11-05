
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exelon.Domain.Abstractions
{
    public interface ICOMEDEXRepository
    {
        Task<List<COMEDEXModel>> GetComEd(int id = 0);
        Task<Dictionary<COMEDEXModel, string>> CreateComEd(COMEDEXModel model);
        Task<COMEDEXModel> UpdateComEd(COMEDEXModel model);
        Task<int> DeleteComEd(int id);
        Task<List<COMEDEXModel>> GetLnL();
        Task<int> GetComEdIdByLinkingId(long linkingId);
    }
}
