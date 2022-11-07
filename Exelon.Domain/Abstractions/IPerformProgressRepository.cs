using Exelon.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exelon.Domain.Abstractions
{
   public interface IPerformProgressRepository
    {
        Task<PerformProgressModel> SaveUpdatePerformProgress(PerformProgressModel model);
        Task<List<PerformProgressModel>> GetPerformProgress(Int64 pdId, Int64 linkingId);
    }
}
