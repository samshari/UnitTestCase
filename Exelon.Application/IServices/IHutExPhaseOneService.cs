using Exelon.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exelon.Application.IServices
{
    public interface IHutExPhaseOneService
    {
        public Task<List<HutExPhaseOneModel>> GetHutExPOne(int id = 0);
        public Task<HutExPhaseOneModel> CreateHutExPOne(HutExPhaseOneModel exPhaseOneModel );
        public Task<HutExPhaseOneModel> UpdateHutExPOne(HutExPhaseOneModel exPhaseOneModel);
        public Task<int> DeleteHutExPOne(int id);
    }
}
