
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exelon.Domain.Abstractions
{
    public interface IMREQUIREDRepository
    {
        public Task<List<MREQUIREDModel>> GetMREQ(int id = 0);
    }
}
