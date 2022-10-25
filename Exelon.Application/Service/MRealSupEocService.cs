using Exelon.Application.IServices;
using Exelon.Domain;
using Exelon.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exelon.Application.Service
{
    public class MREALSUPEOCService : IMREALSUPEOCService
    {
        private readonly IMREALSUPEOCRepository _MREALSUPEOCRepository;

        public MREALSUPEOCService(IMREALSUPEOCRepository MREALSUPEOCRepository)
        {
            _MREALSUPEOCRepository = MREALSUPEOCRepository;
        }

        public async Task<List<MREALSUPEOCModel>> GetMREALEOC(int id = 0)
        {
            return await _MREALSUPEOCRepository.GetMREALEOC(id);
        }
    }
}
