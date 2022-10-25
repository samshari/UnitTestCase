using Exelon.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exelon.Domain.Abstractions
{
    public interface IHutExCivilPhaseThreeRepository
    {
        public Task<List<HutExCivilPhaseThreeModel>> GetHutCivilPhaseThree(int id = 0);
        public Task<HutExCivilPhaseThreeModel> CreateCivilPhaseThree(HutExCivilPhaseThreeModel hutExCivilPhaseThreeModel);
        public Task<HutExCivilPhaseThreeModel> UpdateCivilPhaseThree(HutExCivilPhaseThreeModel hutExCivilPhaseThreeModel);
        public Task<int> DeleteCivilPhaseThree(int id);
    }
}
