using Exelon.Application.IServices;
using Exelon.Domain;
using Exelon.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exelon.Application.Service
{
    public class MENVCOCService : IMENVCOCService
    {
        private readonly IMENVCOCRepository _mENVCOCRepository;

        public MENVCOCService(IMENVCOCRepository mENVCOCRepository)
        {
            _mENVCOCRepository = mENVCOCRepository;
        }

        public async Task<List<MENVCOCModel>> GetMENVCOC(int id = 0)
        {
            return await _mENVCOCRepository.GetMENVCOC(id);
        }
    }
}
