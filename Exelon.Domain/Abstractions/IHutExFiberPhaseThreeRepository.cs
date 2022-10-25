using Exelon.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exelon.Domain.Abstractions
{
    public interface IHutExFiberPhaseThreeRepository
    {
        public Task<List<HutExFiberPhaseThreeModel>> GetHutFiber(int id = 0);
        public Task<HutExFiberPhaseThreeModel> CreateHutFiber(HutExFiberPhaseThreeModel hutExFiberPhaseThreeModel);
        public Task<HutExFiberPhaseThreeModel> UpdateHutFiber(HutExFiberPhaseThreeModel hutExFiberPhaseThreeModel);
        public Task<int> DeleteHutFiber(int id);
    }
}
