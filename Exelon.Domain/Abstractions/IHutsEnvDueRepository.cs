
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exelon.Domain.Abstractions
{
    public interface IHUTSENVDUERepository
    {
        public Task<COMMONREQModel> GetHUTSENV(int id);
    }
}
