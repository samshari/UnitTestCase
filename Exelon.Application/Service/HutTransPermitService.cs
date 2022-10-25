using Exelon.Application.IServices;
using Exelon.Domain;
using Exelon.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exelon.Application.Service
{
    public class HUTTRANSPERMITService : IHUTSTRANSPERMITService
    {
        private readonly IHUTSTRANSPERMITRepository _hUTSTRANSPERMITRepository;

        public HUTTRANSPERMITService(IHUTSTRANSPERMITRepository hUTSTRANSPERMITRepository)
        {
            _hUTSTRANSPERMITRepository = hUTSTRANSPERMITRepository;
        }
        public async Task<COMMONREQModel> GetHUTSTRANS(int id)
        {
            return await _hUTSTRANSPERMITRepository.GetHUTSTRANS(id);
        }
    }
}
