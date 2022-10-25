
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exelon.Domain.Abstractions
{
    public interface ISTACKINGPreConstructionRequiredRepository
    {
        public Task<COMMONREQModel> GetStakingConstructionRequired(int id);
    }
}
