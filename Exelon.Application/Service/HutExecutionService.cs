using Exelon.Application.IServices;
using Exelon.Domain.Abstractions;
using Exelon.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exelon.Application.Service
{
    public class HutExecutionService : IHutExecutionService
    {
        private readonly IHutExecutionRepository _hutExecutionRepository;

        public HutExecutionService(IHutExecutionRepository hutExecutionRepository)
        {
            _hutExecutionRepository = hutExecutionRepository;
        }

        public async Task<List<HutExecutionModel>> GetHutExecute(int id = 0)
        {
            return await _hutExecutionRepository.GetHutExecute(id);
        }

        public async  Task<HutExecutionModel> CreateHutExecute(HutExecutionModel hutExecutionModel)
        {
            return await _hutExecutionRepository.CreateHutExecute(hutExecutionModel);
        }

        public async Task<HutExecutionModel> UpdateHutExecute(HutExecutionModel hutExecutionModel)
        {
            return await _hutExecutionRepository.UpdateHutExecute(hutExecutionModel);
        }

        public async Task<int> DeleteHutExecute(int id)
        {
            return await _hutExecutionRepository.DeleteHutExecute(id);
        }
    }
}
