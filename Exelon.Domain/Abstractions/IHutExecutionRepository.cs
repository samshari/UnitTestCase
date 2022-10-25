using Exelon.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exelon.Domain.Abstractions
{
    public interface IHutExecutionRepository
    {
        public Task<List<HutExecutionModel>> GetHutExecute(int id = 0);
        public Task<HutExecutionModel> CreateHutExecute(HutExecutionModel hutExecutionModel);
        public Task<HutExecutionModel> UpdateHutExecute(HutExecutionModel hutExecutionModel);
        public Task<int> DeleteHutExecute(int id);
    }
}
