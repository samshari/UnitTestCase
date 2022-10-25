using Exelon.Application.IServices;
using Exelon.Domain;
using Exelon.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exelon.Application.Service
{
    public class LNLService : ILNLService
    {
        private readonly ILNLRepository _lNLRepository;

        public LNLService(ILNLRepository lNLRepository)
        {
            _lNLRepository = lNLRepository;
        }

        public async Task<COMMONREQModel> GetLNL(int id)
        {
            return await _lNLRepository.GetLNL(id);
        }
    }
}
