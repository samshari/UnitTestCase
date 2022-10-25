using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exelon.Domain.Abstractions
{
    public interface IHUTSOWNERRepository
    {
        public Task<COMMONREQModel> GetHUTSOWNER(int id);
    }
}
