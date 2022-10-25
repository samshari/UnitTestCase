
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exelon.Domain.Abstractions
{
    public interface IGENERALRepository
    {
        public Task<COMMONREQModel> GetGENERAL(int id);
    }
}
