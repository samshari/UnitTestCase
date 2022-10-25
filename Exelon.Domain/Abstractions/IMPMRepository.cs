
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exelon.Domain.Abstractions
{
    public interface IMPMRepository
    {
        public Task<List<MPMModel>> GetMPM(int id = 0);
        public Task<Dictionary<MPMModel,string>> CreateMPM(MPMModel mPMModel);
        public Task<Dictionary<MPMModel, string>> UpdateMPM(MPMModel mPMModel);
        public Task<int> DeleteMPM(int id);
    }
}
