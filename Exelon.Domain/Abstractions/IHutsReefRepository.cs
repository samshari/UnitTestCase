
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exelon.Domain.Abstractions
{
    public interface IHUTSREEFRepository
    {
        public Task<COMMONREQModel> GetHUTS(int id);
    }
}
