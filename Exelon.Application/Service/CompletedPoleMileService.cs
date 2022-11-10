using Exelon.Application.IServices;
using Exelon.Domain.Abstractions;
using Exelon.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Exelon.Application.Service
{
   public class CompletedPoleMileService : ICompletedPoleMileService
    {
        private readonly ICompletedPoleAndMile completedPoleAndMile;

        public CompletedPoleMileService(ICompletedPoleAndMile repositories)
        {
            completedPoleAndMile = repositories;
        }

        public async Task<Dictionary<CompletedPoleAndMile, string>> SaveUpdateCompletedPoleMile(CompletedPoleAndMile model)
        {
            return await completedPoleAndMile.SaveUpdateCompletedPoleMile(model);
        }
        public async Task<CompletedPoleAndMile> GetCompletedPoleMileById(int id)
        {
            return await completedPoleAndMile.GetCompletedPoleMileById(id);
        }
        public async Task<CompletedPoleAndMile> UpdateCompletedPoleMile(CompletedPoleAndMile model)
        {
            return await completedPoleAndMile.UpdateCompletedPoleMile(model);
        }
        public async Task<CompletedPoleAndMile> GetCompletedPoleMileByLinkId(int id)
        {
            return await completedPoleAndMile.GetCompletedPoleMileByLinkId(id);
        }
    }
}
