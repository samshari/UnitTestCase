using Exelon.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exelon.Domain.Abstractions
{
   public interface IOSPPermitEasementRepository
    {
        Task<OSPPermitEasementModel> SaveUpdatedOSPPermitEasement(OSPPermitEasementModel model);
        Task<List<OSPPermitEasementModel>> GetOSPPermitEasement(int id=0);
    }
}
