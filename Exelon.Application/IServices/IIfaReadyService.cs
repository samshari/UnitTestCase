using Exelon.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exelon.Application.IServices
{
    public interface IIfaReadyService
    {
        public Task<List<IfaReadyModel>> GetIFA(int id = 0);
        public Task<Dictionary<IfaReadyModel,string>> CreateIFA(IfaReadyModel iFAREADYModel);
        public Task<IfaReadyModel> UpdateIFA(IfaReadyModel iFAREADYModel);
        public Task<int> DeleteIFA(int id = 0);
    }
}
