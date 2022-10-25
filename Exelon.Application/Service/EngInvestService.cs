using Exelon.Application.IServices;
using Exelon.Domain;
using Exelon.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exelon.Application.Service
{
    public class ENGINVESTService : IENGINVESTService
    {

        private readonly IENGINVESTRepository _eNGINVESTRepository;

        public ENGINVESTService(IENGINVESTRepository eNGINVESTRepository)
        {
            _eNGINVESTRepository = eNGINVESTRepository;
        }

        public async Task<List<ENGINVESTModel>> GetENGINVEST(int id = 0)
        {
            return await _eNGINVESTRepository.GetENGINVEST(id);
        }

        public async Task<Dictionary<ENGINVESTModel, string>> CreateENGINVEST(ENGINVESTModel eNGINVESTModel)
        {
            return await _eNGINVESTRepository.CreateENGINVEST(eNGINVESTModel);
        }

        public async Task<ENGINVESTModel> UpdateENGINVEST(ENGINVESTModel eNGINVESTModel)
        {
            return await _eNGINVESTRepository.UpdateENGINVEST(eNGINVESTModel);
        }

        public async Task<int> DeleteENGINVEST(int id)
        {
            return await _eNGINVESTRepository.DeleteENGINVEST(id);
        }
    }
}
