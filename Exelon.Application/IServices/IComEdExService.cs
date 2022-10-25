using Exelon.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exelon.Application.IServices
{
    public interface ICOMEDEXService
    {
        public Task<List<COMEDEXModel>> GetCOMED(int id = 0);
        public Task<Dictionary<COMEDEXModel, string>> CreateCOMED(COMEDEXModel cOMEDEXModel);
        public Task<COMEDEXModel> UpdateCOMED(COMEDEXModel cOMEDEXModel);
        public Task<int> DeleteCOMED(int id);

    }
}
