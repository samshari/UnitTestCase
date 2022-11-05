using Exelon.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exelon.Application.IServices
{
    public interface IExLinkingInfoService
    {
        Task<List<ExLinkingInfoModel>> GetExLinkInfo(int id = 0);
        Task<Dictionary<ExLinkingInfoModel, string>> CreateExLinkInfo(ExLinkingInfoModel lINKINFOModel);
        Task<Dictionary<ExLinkingInfoModel, string>> UpdateExLinkInfo(ExLinkingInfoModel lINKINFOModel);
        Task<int> DeleteExLinkInfo(int id);
        Task<List<ExLinkingInfoModel>> GetProjectIDsByPDId(int id = 0);
        Task<Int64> GetLinkInfoIdByProjectId(string id);

    }
}
