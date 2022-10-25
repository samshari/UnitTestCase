
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exelon.Domain.Abstractions
{
    public interface IMEOCRepository
    {
        Task<List<MEOCModel>> GetMEOC(int id);
        Task<Dictionary<MEOCModel,string>> CreateMEOC(MEOCModel mEOCModel);
        Task<Dictionary<MEOCModel, string>> UpdateMEOC(MEOCModel mEOCModel);
        Task<int> DeleteMEOC(int id);
    }
}
