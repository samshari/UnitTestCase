using Exelon.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exelon.Application.IServices
{
    public interface ILinkingInfoService
    {
        Task<List<LinkingInfoModel>> GetLinkInfo(int id= 0);
        Task<LinkingInfoModel> CreateLinkInfo(LinkingInfoModel lINKINFOModel);
        Task<LinkingInfoModel> UpdateLinkInfo(LinkingInfoModel lINKINFOModel);
        Task<int> DeleteLinkInfo(int id);
        Task<List<LinkingInfoModel>> GetPrimayKeysByPDId(int id = 0);
        Task<Int64> GetLinkInfoIdByPrimayKey(string id);
    }
}
