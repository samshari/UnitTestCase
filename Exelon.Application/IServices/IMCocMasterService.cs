using Exelon.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exelon.Application.IServices
{
    public interface IMCOCMASTERService
    {
        public Task<List<MCOCMASTERModel>> GetCOC(int id = 0);
        public Task<Dictionary<MCOCMASTERModel, string>> CreateCOC(MCOCMASTERModel mCOCMASTERModel);
        public Task<MCOCMASTERModel> UpdateCOC(MCOCMASTERModel mCOCMASTERModel);
        public Task<int> DeleteCOC(int id);
    }
}
