
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exelon.Domain.Abstractions
{
    public interface IPPReplacementRepository
    {
        public Task<List<PPREPLACEMENTModel>> GetPPREPLACE(int id = 0);
        public Task<Dictionary<PPREPLACEMENTModel, string>> CreatePPREPLACE(PPREPLACEMENTModel pPREPLACEMENTModel);
        public Task<PPREPLACEMENTModel> UpdatePPREPLACE(PPREPLACEMENTModel pPREPLACEMENTModel);
        public Task<int> DeletePPREPLACE(int id);
    }
}
