using Exelon.Application.IServices;
using Exelon.Domain;
using Exelon.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exelon.Application.Service
{
    public class MUCOSPOCService : IMUCOSPOCService
    {
        private readonly IMUCOSPOCRepository _mUCOSPOCRepository;

        public MUCOSPOCService(IMUCOSPOCRepository mUCOSPOCRepository)
        {
            _mUCOSPOCRepository = mUCOSPOCRepository;
        }

        public async Task<List<MUCOMSPOCModel>> GetMUCO(int id = 0)
        {
            return await _mUCOSPOCRepository.GetMUCO(id);
        }
    }
}
