
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exelon.Domain.Abstractions
{
    public interface IHUTSTRANSPERMITRepository
    {
        public Task<COMMONREQModel> GetHUTSTRANS(int id);
    }
}
