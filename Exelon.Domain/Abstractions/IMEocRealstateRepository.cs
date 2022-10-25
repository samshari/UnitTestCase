
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exelon.Domain.Abstractions
{
    public interface IMEOCREALSTATERepository
    {
        Task<List<MEOCREALSTATEModel>> GetMEOCREALSTATE(int id = 0);
        Task< Dictionary<MEOCREALSTATEModel, string>> CreateMEOCREALSTATE(MEOCREALSTATEModel mEOCREALSTATEModel);
        Task<Dictionary<MEOCREALSTATEModel, string>> UpdateMEOCREALSTATE(MEOCREALSTATEModel mEOCREALSTATEModel);
        Task<int> DeleteMEOCREALSTATE(int id);
    }
}
