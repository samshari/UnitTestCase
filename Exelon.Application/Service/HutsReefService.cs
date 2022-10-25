using Exelon.Application.IServices;
using Exelon.Domain;
using Exelon.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exelon.Application.Service
{
    public class HUTSREEFService : IHUTREEFService
    {
        private readonly IHUTSREEFRepository _hUTSREEFRepository;

        public HUTSREEFService(IHUTSREEFRepository hUTSREEFRepository)
        {
            _hUTSREEFRepository = hUTSREEFRepository;
        }

        public async  Task<COMMONREQModel> GetHUTS(int id)
        {
            return await _hUTSREEFRepository.GetHUTS(id);
        }
    }
}
