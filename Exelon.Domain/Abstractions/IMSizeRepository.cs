
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exelon.Domain.Abstractions
{
    public interface IMSIZERepository
    {
        public Task<List<MSIZEModel>> GetMSIZE(int id = 0);
        public Task<Dictionary<MSIZEModel, string>> CreateMSIZE(MSIZEModel mSIZEModel);
        public Task<Dictionary<MSIZEModel, string>> UpdateMSIZE(MSIZEModel mSIZEModel);
        public Task<int> DeleteMSIZE(int id);
    }
}
