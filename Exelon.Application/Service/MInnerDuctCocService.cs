using Exelon.Application.IServices;
using Exelon.Domain;
using Exelon.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exelon.Application.Service
{
    public class MINNERDUCTCOCService : IMINNERDUCTCOCService
    {
        private readonly IMINNERDUCTCOCRepository _mINNERDUCTCOCRepository;

        public MINNERDUCTCOCService(IMINNERDUCTCOCRepository mINNERDUCTCOCRepository)
        {
            _mINNERDUCTCOCRepository = mINNERDUCTCOCRepository;
        }

        public async Task<List<MINNERDUCTCOCModel>> GetINNERDUCT(int id = 0)
        {
            return await _mINNERDUCTCOCRepository.GetINNERDUCT(id);
        }
    }
}
