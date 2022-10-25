using Exelon.Application.IServices;
using Exelon.Domain;
using Exelon.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exelon.Application.Service
{
    public class HUTService : IHUTService
    {
        private readonly IHutRepository _hUTRepository;

        public HUTService(IHutRepository hUTRepository)
        {
            _hUTRepository = hUTRepository;
        }

        public async  Task<List<HUTSModel>> GetHUTS(int id = 0)
        {
            return await _hUTRepository.GetHUTS(id);
        }

        public async Task<HUTSModel> CreateHUTS(HUTSModel hUTSModel)
        {
            return await _hUTRepository.CreateHUTS(hUTSModel);
        }

        public async Task<HUTSModel> UpdateHUTS(HUTSModel hUTSModel)
        {
            return await _hUTRepository.UpdateHUTS(hUTSModel);
        }

        public async Task<int> DeleteHUTS(int id)
        {
            return await _hUTRepository.DeleteHUTS(id);
        }
    }
}
