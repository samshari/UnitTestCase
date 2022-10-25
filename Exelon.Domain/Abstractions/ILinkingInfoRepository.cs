
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exelon.Domain.Abstractions
{
    public interface ILinkingInfoRepository
    {
        Task<List<LinkingInfoModel>> GetLinkInfo(int id = 0);
        Task<LinkingInfoModel> CreateLinkInfo(LinkingInfoModel lINKINFOModel);
        Task<LinkingInfoModel> UpdateLinkInfo(LinkingInfoModel lINKINFOModel);
        Task<int> DeleteLinkInfo(int id);
        Task<List<LinkingInfoModel>> GetPrimayKeysByPDId(int id = 0);
        Task<long> GetLinkInfoIdByPrimayKey(string id);
    }
}
