using Exelon.Application.IServices;
using Exelon.Domain;
using Exelon.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exelon.Application.Service
{
    public class HUTSOWNERService : IHUTSOWNERService
    {
        private readonly IHUTSOWNERRepository _hUTSOWNERRepository;

        public HUTSOWNERService(IHUTSOWNERRepository hUTSOWNERRepository)
        {
            _hUTSOWNERRepository = hUTSOWNERRepository;
        }

        public async Task<COMMONREQModel> GetHUTSOWNER(int id)
        {
            return await _hUTSOWNERRepository.GetHUTSOWNER(id);
        }
    }
}
