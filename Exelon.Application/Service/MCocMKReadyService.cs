using Exelon.Application.IServices;
using Exelon.Domain;
using Exelon.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exelon.Application.Service
{
    public class MCOCMKREADYService : IMCOCMKREADYService
    {
        private readonly IMCOCMKREADYRepository _mCOCMKREADYRepository;

        public MCOCMKREADYService(IMCOCMKREADYRepository mCOCMKREADYRepository)
        {
            _mCOCMKREADYRepository = mCOCMKREADYRepository;
        }
        public async Task<List<MCOCMKREADYModel>> GetMCOCMK(int id = 0)
        {
            return await _mCOCMKREADYRepository.GetMCOCMK(id);
        }
    }
}
