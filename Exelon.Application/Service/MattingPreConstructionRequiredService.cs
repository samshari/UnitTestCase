using Exelon.Application.IServices;
using Exelon.Domain;
using Exelon.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exelon.Application.Service
{
    public class MattingPreConstructionRequiredService : IMattingPreConstructionRequiredService
    {
        private readonly IMattingPreConstructionRequiredRepository _mattingPreConstructionRequiredRepository;

        public MattingPreConstructionRequiredService(IMattingPreConstructionRequiredRepository mattingPreConstructionRequiredRepository)
        {
            _mattingPreConstructionRequiredRepository = mattingPreConstructionRequiredRepository;
        }

        public async Task<COMMONREQModel> GetMattingPreConstructionRequired(int id)
        {
            return await _mattingPreConstructionRequiredRepository.GetMattingPreConstructionRequired(id);
        }
    }
}
