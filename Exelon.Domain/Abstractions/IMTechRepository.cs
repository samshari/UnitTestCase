
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exelon.Domain.Abstractions
{
    public interface IMTECHRepository
    {
        Task<List<MTECHModel>> GetMTECH(int id = 0);
    }
}
