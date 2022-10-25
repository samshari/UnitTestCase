using Exelon.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exelon.Application.IServices
{
    public interface IFiberCountService
    {
        public Task<List<FiberCountModel>> GetFIBER(int id = 0);
        public Task<Dictionary<FiberCountModel,string>> CreateFIBER(FiberCountModel fIBERCOUNTModel);
        public Task<FiberCountModel> UpdateFIBER(FiberCountModel fIBERCOUNTModel);
        public Task<int> DeleteFIBER(int id );

    }
}
