using Exelon.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exelon.Application.IServices
{
    public interface IMSIZEService
    {
        public Task<List<MSIZEModel>> GetMSIZE(int id = 0);
        public Task<Dictionary<MSIZEModel, string>> CreateMSIZE(MSIZEModel mSIZEModel);
        public Task<Dictionary<MSIZEModel, string>> UpdateMSIZE(MSIZEModel mSIZEModel);
        public Task<int> DeleteMSIZE(int id);
    }
}
