
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exelon.Domain.Abstractions
{
    public interface IMREALSUPEOCRepository
    {
        Task<List<MREALSUPEOCModel>> GetMREALEOC(int id = 0);
    }
}
