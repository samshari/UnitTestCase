using Exelon.Application.IServices;
using Exelon.Domain;
using Exelon.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exelon.Application.Service
{
    public class PRECONSTRUCIONService : IPRECONSTRUCTIONService
    {
        private readonly IPRECONSTRUCTIONRepository _pRECONSTRUCTIONRepository;

        public PRECONSTRUCIONService(IPRECONSTRUCTIONRepository pRECONSTRUCTIONRepository)
        {
            _pRECONSTRUCTIONRepository = pRECONSTRUCTIONRepository;
        }

        public async Task<List<PRECONSTRUCTIONModel>> GetPreConstruction(int id = 0)
        {
            return await _pRECONSTRUCTIONRepository.GetPreConstruction(id);
        }

        public async Task<Dictionary<PRECONSTRUCTIONModel, string>> CreatePreConstruction(PRECONSTRUCTIONModel pRECONSTRUCTIONModel)
        {
            return await _pRECONSTRUCTIONRepository.CreatePreConstruction(pRECONSTRUCTIONModel);
        }

        public async Task<PRECONSTRUCTIONModel> UpdatePreConstruction(PRECONSTRUCTIONModel pRECONSTRUCTIONModel)
        {
            return await _pRECONSTRUCTIONRepository.UpdatePreConstruction(pRECONSTRUCTIONModel);
        }

        public async Task<int> DeletePreConstruction(int id)
        {
            return await _pRECONSTRUCTIONRepository.DeletePreConstruction(id);
        }
    }
}
