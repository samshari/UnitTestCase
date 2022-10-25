
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exelon.Domain.Abstractions
{
    public interface ILNLRepository
    {
        public Task<COMMONREQModel> GetLNL(int id);
    }
}
