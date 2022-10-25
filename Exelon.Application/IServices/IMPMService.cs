using Exelon.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exelon.Application.IServices
{
    public interface IMPMService
    {
        public Task<List<MPMModel>> GetMPM(int id = 0);
        public Task<Dictionary<MPMModel,string>> CreateMPM(MPMModel mPMModel);
        public Task<Dictionary<MPMModel, string>> UpdateMPM(MPMModel mPMModel);
        public Task<int> DeleteMPM(int id);
    }
}
