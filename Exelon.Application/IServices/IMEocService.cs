using Exelon.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exelon.Application.IServices
{
    public interface IMEOCService
    {
        Task<List<MEOCModel>> GetMEOC(int id = 0);
        Task<Dictionary<MEOCModel,string>> CreateMEOC(MEOCModel mEOCModel);
        Task<Dictionary<MEOCModel, string>> UpdateMEOC(MEOCModel mEOCModel);
        Task<int> DeleteMEOC(int id);
    }
}
