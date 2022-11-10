using Exelon.Application.IServices;
using Exelon.Domain;
using Exelon.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exelon.Application.Service

{
    public class LinkingInfoService : ILinkingInfoService
    {
        private readonly ILinkingInfoRepository _linkingInfoRepository;

        public LinkingInfoService(ILinkingInfoRepository linkingInfoRepository)
        {
            _linkingInfoRepository = linkingInfoRepository;
        }

        public async Task<List<LinkingInfoModel>> GetLinkInfo(int id = 0)
        {
            return await _linkingInfoRepository.GetLinkInfo(id);
        }

        public async Task<Dictionary<LinkingInfoModel, string>> CreateLinkInfo(LinkingInfoModel lINKINFOModel)
        {
            return await _linkingInfoRepository.CreateLinkInfo(lINKINFOModel);
        }

        public async Task<Dictionary<LinkingInfoModel, string>> UpdateLinkInfo(LinkingInfoModel lINKINFOModel)
        {
            return await _linkingInfoRepository.UpdateLinkInfo(lINKINFOModel);
        }

        public async Task<int> DeleteLinkInfo(int id)
        {
            return await _linkingInfoRepository.DeleteLinkInfo(id);
        }
        public async Task<List<LinkingInfoModel>> GetPrimayKeysByPDId(int id = 0)
        {
            return await _linkingInfoRepository.GetPrimayKeysByPDId(id);
        }

        public async Task<Int64> GetLinkInfoIdByPrimayKey(string id)
        {
            return await _linkingInfoRepository.GetLinkInfoIdByPrimayKey(id);
        }
    }
}
