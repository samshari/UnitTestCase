
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exelon.Domain.Abstractions
{
    public interface IVegPreConstructionRequiredRepository
    {
        public Task<COMMONREQModel> GetPreConstructionRequired(int id);
    }
}
