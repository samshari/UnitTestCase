using Exelon.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exelon.Domain.Abstractions
{
    public interface IHutExCVSubgradePhaseTwoRepository
    {
        public Task<List<HutExCVSubgradePhaseTwoModel>> GetHutExCV(int id = 0);
        public Task<HutExCVSubgradePhaseTwoModel> CreateHutExCV(HutExCVSubgradePhaseTwoModel hutExCVSubgradePhaseTwoModel);
        public Task<HutExCVSubgradePhaseTwoModel> UpdateHutExCV(HutExCVSubgradePhaseTwoModel hutExCVSubgradePhaseTwoModel);
        public Task<int> DeleteHutExCV(int id);
    }
}
