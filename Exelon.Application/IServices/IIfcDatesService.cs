using Exelon.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exelon.Application.IServices
{
    public interface IIFCDATESService
    {
        public Task<List<IFCDATESModel>> GetIFCDATES(int id = 0);
        public Task<Dictionary<IFCDATESModel, string>> CreateIFCDATES(IFCDATESModel iFCDATESModel);
        public Task<IFCDATESModel> UpdateIFCDATES(IFCDATESModel iFCDATESModel);
        public Task<int> DeleteIFCDATES(int id);

    }
}
