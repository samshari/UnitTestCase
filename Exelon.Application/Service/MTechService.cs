using Exelon.Application.IServices;
using Exelon.Domain;
using Exelon.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exelon.Application.Service
{
    public class MTECHService : IMTECHService
    {
        private readonly IMTECHRepository _MTECHRepository;

        public MTECHService(IMTECHRepository MTECHRepository)
        {
            _MTECHRepository = MTECHRepository;
        }

        public async Task<List<MTECHModel>> GetMTECH(int id = 0)
        {
            return await _MTECHRepository.GetMTECH(id);
        }

    }
}
