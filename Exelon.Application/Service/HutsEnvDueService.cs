using Exelon.Application.IServices;
using Exelon.Domain;
using Exelon.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exelon.Application.Service
{
    public class HUTSENVDUEService : IHUTSENVDUEService
    {
        private readonly IHUTSENVDUERepository _hUTSENVDUERepository;

        public HUTSENVDUEService(IHUTSENVDUERepository hUTSENVDUERepository)
        {
            _hUTSENVDUERepository = hUTSENVDUERepository;
        }

        public async Task<COMMONREQModel> GetHUTSENV(int id)
        {
            return await _hUTSENVDUERepository.GetHUTSENV(id);
        }
    }
}
