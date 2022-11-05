using Exelon.Domain;
using Exelon.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exelon.Application.IServices
{
    public class ExLinkingInfoService: IExLinkingInfoService
    {
        private readonly IExLinkingInfoRepository _linkingInfoRepository;

        public ExLinkingInfoService(IExLinkingInfoRepository linkingInfoRepository)
        {
            _linkingInfoRepository = linkingInfoRepository;
        }

        public async Task<List<ExLinkingInfoModel>> GetExLinkInfo(int id = 0)
        {
            return await _linkingInfoRepository.GetExLinkInfo(id);
        }

        public async Task<Dictionary<ExLinkingInfoModel, string>> CreateExLinkInfo(ExLinkingInfoModel lINKINFOModel)
        {
            return await _linkingInfoRepository.CreateExLinkInfo(lINKINFOModel);
        }

        public async Task<Dictionary<ExLinkingInfoModel, string>> UpdateExLinkInfo(ExLinkingInfoModel lINKINFOModel)
        {
            return await _linkingInfoRepository.UpdateExLinkInfo(lINKINFOModel);
        }

        public async Task<int> DeleteExLinkInfo(int id)
        {
            return await _linkingInfoRepository.DeleteExLinkInfo(id);
        }

        public async Task<List<ExLinkingInfoModel>> GetProjectIDsByPDId(int id = 0)
        {
            return await _linkingInfoRepository.GetProjectIDsByPDId(id);
        }

        public async Task<Int64> GetLinkInfoIdByProjectId(string id)
        {
            return await _linkingInfoRepository.GetLinkInfoIdByProjectId(id);
        }
    }
}
