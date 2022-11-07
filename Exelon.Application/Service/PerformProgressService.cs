using Exelon.Application.IServices;
using Exelon.Domain.Abstractions;
using Exelon.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exelon.Application.Service
{
   public class PerformProgressService : IPerformProgressService
    {
        private readonly IPerformProgressRepository performProgressRepository;
        public PerformProgressService(IPerformProgressRepository repositories)
        {
            performProgressRepository = repositories;
        }

        public async Task<List<PerformProgressModel>> GetPerformProgress(long pdId, long linkingId)
        {
            return await performProgressRepository.GetPerformProgress(pdId, linkingId);
        }

        public async Task<PerformProgressModel> SaveUpdatePerformProgress(PerformProgressModel model)
        {
            return await performProgressRepository.SaveUpdatePerformProgress(model);
        }
    }
}
