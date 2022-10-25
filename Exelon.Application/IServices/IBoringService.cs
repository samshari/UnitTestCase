using Exelon.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exelon.Application.IServices
{
    public interface IBORINGService
    {
        public Task<List<BORINGModel>> GetBORE(int id = 0);
        public Task<Dictionary<BORINGModel, string>> CreateBORE(BORINGModel bORINGModel);
        public Task<BORINGModel> UpdateBORE(BORINGModel bORINGModel);
        public Task<int> DeleteBORE(int id);
    }
}
