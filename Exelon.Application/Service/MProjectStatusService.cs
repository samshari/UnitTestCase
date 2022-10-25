using Exelon.Application.IServices;
using Exelon.Domain;
using Exelon.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exelon.Application.Service
{
    public class MPROJECTSTATUSService : IMProjectStatusService
    {
        private readonly IMPROJECTSTATUSRepository _MPROJECTSTATUSRepository;

        public MPROJECTSTATUSService(IMPROJECTSTATUSRepository MPROJECTSTATUSRepository)
        {
            _MPROJECTSTATUSRepository = MPROJECTSTATUSRepository;
        }

        public async Task<List<MPROJECTSTATUSModel>> GETMPROJECTSTATUS(int id = 0)
        {
            return await _MPROJECTSTATUSRepository.GETMPROJECTSTATUS(id);
        }
    }
}
