using Exelon.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exelon.Application.IServices
{
    public interface IMREGIONService
    {
        Task<List<MREGIONModel>> GetMREGION(int id = 0);
        Task<Dictionary<MREGIONModel,string>> CreateMREGION(MREGIONModel mREGIONModel);
        Task<Dictionary<MREGIONModel, string>> UpdateMREGION(MREGIONModel mREGIONModel);
        Task<int> DeleteMREGION(int id);
    }
}
