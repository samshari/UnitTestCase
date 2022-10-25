using Exelon.Application.IServices;
using Exelon.Domain;
using Exelon.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exelon.Application.Service
{
    public class GENERALService : IGENERALService
    {
        private readonly IGENERALRepository _gENERALRepository;
        public GENERALService(IGENERALRepository gENERALRepository)
        {
            _gENERALRepository = gENERALRepository;
        }

        public async Task<COMMONREQModel> GetGENERAL(int id)
        {
            return await _gENERALRepository.GetGENERAL(id);
        }
    }
}
