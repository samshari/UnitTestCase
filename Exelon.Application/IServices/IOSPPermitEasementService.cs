using Exelon.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exelon.Application.IServices
{
    public interface IOSPPermitEasementService
    {
        Task<OSPPermitEasementModel> SaveUpdatedOSPPermitEasement(OSPPermitEasementModel model);
        Task<List<OSPPermitEasementModel>> GetOSPPermitEasement(int id = 0);
    }
}
