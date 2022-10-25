
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exelon.Domain.Abstractions
{
    public interface IMREACTLRERepository
    {
        public Task<List<MREACTLREModel>> GetMREACT(int id = 0);
    }
}
