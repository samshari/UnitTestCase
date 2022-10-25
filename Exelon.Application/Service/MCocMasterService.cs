
using Exelon.Application.IServices;
using Exelon.Domain;
using Exelon.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exelon.Application.Service
{
    public class MCOCMASTERService : IMCOCMASTERService
    {
        private readonly IMCOCMASTERRepository _mCOCMASTERRepository;

        public MCOCMASTERService(IMCOCMASTERRepository mCOCMASTERRepository)
        {
            _mCOCMASTERRepository = mCOCMASTERRepository;
        }

        public async Task<List<MCOCMASTERModel>> GetCOC(int id = 0)
        {
            return await _mCOCMASTERRepository.GetCOC(id);
        }

        public async Task<Dictionary<MCOCMASTERModel, string>> CreateCOC(MCOCMASTERModel mCOCMASTERModel)
        {
            return await _mCOCMASTERRepository.CreateCOC(mCOCMASTERModel);
        }

        public async Task<MCOCMASTERModel> UpdateCOC(MCOCMASTERModel mCOCMASTERModel)
        {
            return await _mCOCMASTERRepository.UpdateCOC(mCOCMASTERModel);
        }

        public async Task<int> DeleteCOC(int id)
        {
            return await _mCOCMASTERRepository.DeleteCOC(id);
        }
    }
}
