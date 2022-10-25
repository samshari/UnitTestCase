using Exelon.Application.IServices;
using Exelon.Domain;
using Exelon.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exelon.Application.Service
{
    public class HUTSCOMPSTATUSService : IHUTSCOMPSTATUSService
    {
        private readonly IHUTSCOMPSTATUSRepository _hUTSCOMPSTATUSRepository;

        public HUTSCOMPSTATUSService(IHUTSCOMPSTATUSRepository hUTSCOMPSTATUSService)
        {
            _hUTSCOMPSTATUSRepository = hUTSCOMPSTATUSService;
        }

        public async Task<COMMONREQModel> GetHUTSCOM(int id)
        {
            return await _hUTSCOMPSTATUSRepository.GetHUTSCOM(id);
        }


    }
}
