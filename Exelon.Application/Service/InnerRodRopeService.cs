using Exelon.Application.IServices;
using Exelon.Domain;
using Exelon.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exelon.Application.Service
{
    public class INNERRODROPEService : IINNERRODROPEService
    {
        private readonly IINNERRODROPERepository _nNERRODROPERepository;

        public INNERRODROPEService(IINNERRODROPERepository nNERRODROPERepository)
        {
            _nNERRODROPERepository = nNERRODROPERepository;
        }

        public async Task<List<InnerRodRopeModel>> GetRODROPE(int id = 0)
        {
            return await _nNERRODROPERepository.GetRODROPE(id);
        }

        public async Task<Dictionary<InnerRodRopeModel, string>> CreateRODROPE(InnerRodRopeModel iNNERODROPEModel)
        {
            return await _nNERRODROPERepository.CreateRODROPE(iNNERODROPEModel);
        }

        public async Task<InnerRodRopeModel> UpdateRODROPE(InnerRodRopeModel iNNERODROPEModel)
        {
            return await _nNERRODROPERepository.UpdateRODROPE(iNNERODROPEModel);
        }

        public async Task<int> DeleteRODROPE(int id)
        {
            return await _nNERRODROPERepository.DeleteRODROPE(id);
        }
    }
}
