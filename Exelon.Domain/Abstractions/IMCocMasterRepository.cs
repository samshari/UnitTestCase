
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exelon.Domain.Abstractions
{
    public interface IMCOCMASTERRepository
    {
        public Task<List<MCOCMASTERModel>> GetCOC(int id = 0);
        public Task<Dictionary<MCOCMASTERModel, string>> CreateCOC(MCOCMASTERModel mCOCMASTERModel);
        public Task<MCOCMASTERModel> UpdateCOC(MCOCMASTERModel mCOCMASTERModel);
        public Task<int> DeleteCOC(int id);
    }
}
