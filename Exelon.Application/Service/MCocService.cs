
using Exelon.Application.IServices;
using Exelon.Domain;
using Exelon.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Exelon.Application.Service
{
    public class MCocService : IMCocService
    {

        private readonly IMCocRepository _MCOSRepository;

        public MCocService(IMCocRepository mcosRepository)
        {
            _MCOSRepository = mcosRepository;
        }
        public async Task<Dictionary<MCOCModel,string>> CreateMCOC(MCOCModel mCOCModel)
        {
            return await _MCOSRepository.CreateMCOC(mCOCModel);
        }

        public async Task<Dictionary<MCOCModel, string>> UpdateMCOC(MCOCModel mCOCModel)
        {
            return await _MCOSRepository.UpdateMCOC(mCOCModel);
        }

        public async Task<int> DeleteMCOC(int id)
        {
            return await _MCOSRepository.DeleteMCOC(id);
        }

        public async Task<List<MCOCModel>> GetMCOC(int id = 0)
        {
            return await _MCOSRepository.GetMCOC(id);
        }
    }
}
