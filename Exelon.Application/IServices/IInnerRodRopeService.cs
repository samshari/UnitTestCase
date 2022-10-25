using Exelon.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exelon.Application.IServices
{
    public interface IINNERRODROPEService
    {
        public Task<List<InnerRodRopeModel>> GetRODROPE(int id = 0);
        public Task<Dictionary<InnerRodRopeModel, string>> CreateRODROPE(InnerRodRopeModel iNNERODROPEModel);
        public Task<InnerRodRopeModel> UpdateRODROPE(InnerRodRopeModel iNNERODROPEModel);
        public Task<int> DeleteRODROPE(int id);
    }
}
