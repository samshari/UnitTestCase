
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exelon.Domain.Abstractions
{
    public interface ILinkingInfoRepository
    {
        Task<List<LinkingInfoModel>> GetLinkInfo(int id = 0);
        Task<Dictionary<LinkingInfoModel, string>> CreateLinkInfo(LinkingInfoModel lINKINFOModel);
        Task<Dictionary<LinkingInfoModel, string>> UpdateLinkInfo(LinkingInfoModel lINKINFOModel);
        Task<int> DeleteLinkInfo(int id);
        Task<List<LinkingInfoModel>> GetPrimayKeysByPDId(int id = 0);
        Task<long> GetLinkInfoIdByPrimayKey(string id);
    }
}
