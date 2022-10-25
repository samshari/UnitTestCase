using Exelon.Application.IServices;
using Exelon.Domain;
using Exelon.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exelon.Application.Service
{
    public class MCOCBIDFIBERService : IMCOCBIDFIBERService
    {
        private readonly IMCOCBIDFIBERRepository _mCOCBIDFIBERRepository;

        public MCOCBIDFIBERService(IMCOCBIDFIBERRepository mCOCBIDFIBERRepository)
        {
            _mCOCBIDFIBERRepository = mCOCBIDFIBERRepository;
        }
        public async Task<List<MCOCBIDFIBERModel>> GetMCOCBID(int id = 0)
        {
            return await _mCOCBIDFIBERRepository.GetMCOCBID(id);
        }
    }
}
