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
        Task<ExLinkingInfoModel> CreateExLinkInfo(ExLinkingInfoModel lINKINFOModel);
        Task<ExLinkingInfoModel> UpdateExLinkInfo(ExLinkingInfoModel lINKINFOModel);
        Task<int> DeleteExLinkInfo(int id);
        Task<List<ExLinkingInfoModel>> GetProjectIDsByPDId(int id = 0);
        Task<Int64> GetLinkInfoIdByProjectId(string id);

    }
}
