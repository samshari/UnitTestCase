
using Exelon.Application.IServices;
using Exelon.Domain;
using Exelon.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exelon.Application.Service
{
    public class MCOCTYPEMASTERService : IMCOCTYPEMASTERService
    {
        private readonly IMCOCTYPEMASTERRepository _mCOCTYPEMASTERRepository;


        public MCOCTYPEMASTERService(IMCOCTYPEMASTERRepository mCOCTYPEMASTERRepository)
        {
            _mCOCTYPEMASTERRepository = mCOCTYPEMASTERRepository;
        }

        public async Task<List<MCOCTYPEMASTERModel>> GetMCOCTYPE(int id = 0)
        {
            return await _mCOCTYPEMASTERRepository.GetMCOCTYPE(id);
        }
    }
}
