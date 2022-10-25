using Exelon.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exelon.Application.IServices
{
    public interface IHutExCivilPhaseThreeService
    {
        public Task<List<HutExCivilPhaseThreeModel>> GetHutCivilPhaseThree(int id = 0);
        public Task<HutExCivilPhaseThreeModel> CreateCivilPhaseThree(HutExCivilPhaseThreeModel hutExCivilPhaseThreeModel);
        public Task<HutExCivilPhaseThreeModel> UpdateCivilPhaseThree(HutExCivilPhaseThreeModel hutExCivilPhaseThreeModel);
        public Task<int> DeleteCivilPhaseThree(int id);
    }
}
