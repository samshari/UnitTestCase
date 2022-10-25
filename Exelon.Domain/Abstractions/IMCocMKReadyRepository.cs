
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exelon.Domain.Abstractions
{
    public interface IMCOCMKREADYRepository
    {
        public Task<List<MCOCMKREADYModel>> GetMCOCMK(int id = 0);
    }
}
