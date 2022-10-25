using Exelon.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exelon.Application.IServices
{
    public interface IHutExRnPPhaseThreeService
    {
        public Task<List<HutExRnPPhaseThreeModel>> GetHutRnPPhaseThree(int id = 0);
        public Task<HutExRnPPhaseThreeModel> CreateHutRnPPhaseThree(HutExRnPPhaseThreeModel hutExRnPPhaseThreeModel);
        public Task<HutExRnPPhaseThreeModel> UpdateHutRnPPhaseThree(HutExRnPPhaseThreeModel hutExRnPPhaseThreeModel);
        public Task<int> DeleteHutRnPPhaseThree(int id);
    }
}
