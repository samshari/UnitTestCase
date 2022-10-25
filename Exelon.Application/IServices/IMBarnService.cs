

using Exelon.Domain;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exelon.Application.IServices
{
    public interface IMBarnService
    {
        Task<List<MBARNModel>> GetBarn(int id = 0);
        Task<Dictionary<MBARNModel,string>> CreateBarn(MBARNModel mBARNModel);
        Task<Dictionary<MBARNModel, string>> UpdateBarn(MBARNModel mBARNModel);
        Task<int> DeleteBarn(int id);
    }
}
