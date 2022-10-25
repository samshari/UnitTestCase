using Exelon.Application.IServices;
using Exelon.Domain;
using Exelon.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exelon.Application.Service
{
    public class OWNERService : IOWNERService
    {
        private readonly IOWNERRepository _oWNERRepository;

        public OWNERService(IOWNERRepository oWNERRepository)
        {
            _oWNERRepository = oWNERRepository;
        }

        public async Task<List<OWNERSModel>> GetOWNER(int id = 0)
        {
            return await _oWNERRepository.GetOWNER(id);
        }

        public async Task<Dictionary<OWNERSModel, string>> CreateOWNER(OWNERSModel oWNERSModel)
        {
            return await _oWNERRepository.CreateOWNER(oWNERSModel);
        }

        public async Task<Dictionary<OWNERSModel, string>> UpdateOWNER(OWNERSModel oWNERSModel)
        {
            return await _oWNERRepository.UpdateOWNER(oWNERSModel);
        }

        public async Task<int> DeleteOWNER(int id)
        {
            return await _oWNERRepository.DeleteOWNER(id);
        }
    }
}
