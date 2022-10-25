using Exelon.Application.IServices;
using Exelon.Domain;
using Exelon.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exelon.Application.Service
{
    public class MREACTLREService : IMREACTLREService
    {
        private readonly IMREACTLRERepository _mREACTLRERepository;

        public MREACTLREService(IMREACTLRERepository mREACTLRERepository)
        {
            _mREACTLRERepository = mREACTLRERepository;
        }

        public async Task<List<MREACTLREModel>> GetMREACT(int id = 0)
        {
            return await _mREACTLRERepository.GetMREACT(id);
        }
    }
}
