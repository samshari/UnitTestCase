using Exelon.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exelon.Domain.Abstractions
{
    public interface IHutExTestingRepository
    {
        public Task<List<HutExTestingModel>> GetHutTest(int id = 0);
        public Task<HutExTestingModel> CreateHutTest(HutExTestingModel hutExTestingModel);
        public Task<HutExTestingModel> UpdateHutTest(HutExTestingModel hutExTestingModel);
        public Task<int> DeleteHutTest(int id);
    }
}
