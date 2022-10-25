using Exelon.Application.IServices;
using Exelon.Domain;
using Exelon.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exelon.Application.Service
{
    public class MREGIONService : IMREGIONService
    {
        private readonly IMREGIONRepository _MREGIONRepository;

        public MREGIONService(IMREGIONRepository MREGIONRepository)
        {
            _MREGIONRepository = MREGIONRepository;
        }

        public async Task<List<MREGIONModel>> GetMREGION(int id = 0)
        {
            return await _MREGIONRepository.GetMREGION(id);
        }

        public async Task<Dictionary<MREGIONModel,string>> CreateMREGION(MREGIONModel mREGIONModel)
        {
            return await _MREGIONRepository.CreateMREGION(mREGIONModel);
        }

        public async Task<Dictionary<MREGIONModel, string>> UpdateMREGION(MREGIONModel mREGIONModel)
        {
            return await _MREGIONRepository.UpdateMREGION(mREGIONModel);
        }

        public async Task<int> DeleteMREGION(int id)
        {
            return await _MREGIONRepository.DeleteMREGION(id);
        }
    }
}
