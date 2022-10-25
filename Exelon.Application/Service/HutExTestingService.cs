using Exelon.Application.IServices;
using Exelon.Domain.Abstractions;
using Exelon.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exelon.Application.Service
{
    public class HutExTestingService : IHutExTestingService
    {
        private readonly IHutExTestingRepository _hutExTestingRepository;

        public HutExTestingService(IHutExTestingRepository hutExTestingRepository)
        {
            _hutExTestingRepository = hutExTestingRepository;
        }

        public async Task<List<HutExTestingModel>> GetHutTest(int id = 0)
        {
            return await _hutExTestingRepository.GetHutTest(id);
        }

        public async Task<HutExTestingModel> CreateHutTest(HutExTestingModel hutExTestingModel)
        {
            return await _hutExTestingRepository.CreateHutTest(hutExTestingModel);
        }

        public async Task<HutExTestingModel> UpdateHutTest(HutExTestingModel hutExTestingModel)
        {
            return await _hutExTestingRepository.UpdateHutTest(hutExTestingModel);
        }

        public async Task<int> DeleteHutTest(int id)
        {
            return await _hutExTestingRepository.DeleteHutTest(id);
        }
    }
}
