
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exelon.Domain.Abstractions
{
    public interface IMENVCOCRepository
    {
        public Task<List<MENVCOCModel>> GetMENVCOC(int id = 0);
    }
}
