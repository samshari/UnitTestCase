
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exelon.Domain.Abstractions
{
    public interface IMBARNRepository
    {
        Task<List<MBARNModel>> GetBarn(int id = 0);
        Task<Dictionary<MBARNModel,string>> CreateBarn(MBARNModel mREGIONModel);
        Task<Dictionary<MBARNModel, string>> UpdateBarn(MBARNModel mREGIONModel);
        Task<int> DeleteBarn(int id);
    }
}
