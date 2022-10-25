using Exelon.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exelon.Application.IServices
{
    public interface IHutExRnPPhaseTwoService
    {
        public Task<List<HutExRnPPhaseTwoModel>> GetHutExRnPhaseTwo(int id = 0);
        public Task<HutExRnPPhaseTwoModel> CreateHutExRnPhaseTwo(HutExRnPPhaseTwoModel hutExRnPPhaseTwoModel);
        public Task<HutExRnPPhaseTwoModel> UpdateHutExRnPhaseTwo(HutExRnPPhaseTwoModel hutExRnPPhaseTwoModel);
        public Task<int> DeleteHutExRnPhaseTwo(int id);

    }
}
