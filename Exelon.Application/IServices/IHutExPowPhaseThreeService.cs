using Exelon.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exelon.Application.IServices
{
    public interface IHutExPowPhaseThreeService
    {
        public Task<List<HutExPowPhaseThreeModel>> GetHutExPowPhaseThree(int id = 0);
        public Task<HutExPowPhaseThreeModel> CreateHutExPowPhaseThree(HutExPowPhaseThreeModel hutExPowPhaseThreeModel);
        public Task<HutExPowPhaseThreeModel> UpdateHutExPowPhaseThree(HutExPowPhaseThreeModel hutExPowPhaseThreeModel);
        public Task<int> DeleteHutExPowPhaseThree(int id);
    }
}
