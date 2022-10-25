
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exelon.Domain.Abstractions
{
    public interface IHUTSCOMPSTATUSRepository
    {
        public Task<COMMONREQModel> GetHUTSCOM(int id);
    }
}
