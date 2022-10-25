
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exelon.Domain.Abstractions
{
    public interface IMCOCBIDFIBERRepository
    {
        public Task<List<MCOCBIDFIBERModel>> GetMCOCBID(int id = 0);
    }
}
