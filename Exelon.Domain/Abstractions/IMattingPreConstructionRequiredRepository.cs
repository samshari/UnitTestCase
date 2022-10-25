
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exelon.Domain.Abstractions
{
    public interface IMattingPreConstructionRequiredRepository
    {
        public Task<COMMONREQModel> GetMattingPreConstructionRequired(int id);
    }
}
