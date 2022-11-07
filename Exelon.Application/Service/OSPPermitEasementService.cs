using Exelon.Application.IServices;
using Exelon.Domain.Abstractions;
using Exelon.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exelon.Application.Service
{
   public class OSPPermitEasementService: IOSPPermitEasementService
    {
        private readonly IOSPPermitEasementRepository oSPPermitEasementRepository;
        public OSPPermitEasementService(IOSPPermitEasementRepository repositories)
        {
            oSPPermitEasementRepository = repositories;
        }

        public async Task<List<OSPPermitEasementModel>> GetOSPPermitEasement(int id = 0)
        {
           return await oSPPermitEasementRepository.GetOSPPermitEasement(id);
        }

        public async Task<OSPPermitEasementModel> SaveUpdatedOSPPermitEasement(OSPPermitEasementModel model)
        {
            return await oSPPermitEasementRepository.SaveUpdatedOSPPermitEasement(model);
        }
    }
}
