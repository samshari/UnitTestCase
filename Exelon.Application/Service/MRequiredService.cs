using Exelon.Application.IServices;
using Exelon.Domain;
using Exelon.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exelon.Application.Service
{
    public class MREQUIREDService : IMREQUIREDService
    {
        private readonly IMREQUIREDRepository _mREQUIREDRepository;

        public MREQUIREDService(IMREQUIREDRepository mREQUIREDRepository)
        {
            _mREQUIREDRepository = mREQUIREDRepository;
        }

        public async Task<List<MREQUIREDModel>> GetMREQ(int id = 0)
        {
            return await _mREQUIREDRepository.GetMREQ(id);
        }
    }
}
