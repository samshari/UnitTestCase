using Exelon.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exelon.Application.IServices
{
    public interface ICIVILService
    {
        public Task<List<CIVILModel>> GetCIVIL(int id = 0);
        public Task<Dictionary<CIVILModel, string>> CreateCIVIL(CIVILModel cIVILModel);
        public Task<CIVILModel> UpdateCIVIL(CIVILModel cIVILModel);
        public Task<int> DeleteCIVIL(int id);
    }
}
