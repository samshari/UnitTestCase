using Exelon.Application.IServices;
using Exelon.Domain;
using Exelon.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exelon.Application.Service
{
    public class VegPreConstructionRequiredService : IVEGPreConstructionRequiredService
    {
        private readonly IVegPreConstructionRequiredRepository _iVEGPreConstructionRequiredRepository;
        public VegPreConstructionRequiredService(IVegPreConstructionRequiredRepository iVEGPreConstructionRequiredRepository)
        {
            _iVEGPreConstructionRequiredRepository = iVEGPreConstructionRequiredRepository;
        }

        public async Task<COMMONREQModel> GetPreConstructionRequired(int id)
        {
            return await _iVEGPreConstructionRequiredRepository.GetPreConstructionRequired(id);
        }
    }
}
