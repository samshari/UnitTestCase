using Exelon.Application.IServices;
using Exelon.Domain;
using Exelon.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exelon.Application.Service
{
    public class BORINGService : IBORINGService
    {
        private readonly IBORINGRepository _bORINGRepository;


        public BORINGService(IBORINGRepository bORINGRepository)
        {
            _bORINGRepository = bORINGRepository;
        }


        public async Task<List<BORINGModel>> GetBORE(int id = 0)
        {
            return await _bORINGRepository.GetBORE(id);
        }

        public async Task<Dictionary<BORINGModel, string>> CreateBORE(BORINGModel bORINGModel)
        {
            return await _bORINGRepository.CreateBORE(bORINGModel);
        }

        public async Task<BORINGModel> UpdateBORE(BORINGModel bORINGModel)
        {
            return await _bORINGRepository.UpdateBORE(bORINGModel);
        }

        public async Task<int> DeleteBORE(int id)
        {
            return await _bORINGRepository.DeleteBORE(id);
        }
    }
}
