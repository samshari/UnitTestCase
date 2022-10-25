
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exelon.Domain.Abstractions
{
    public interface IMUCOSPOCRepository
    {
        public Task<List<MUCOMSPOCModel>> GetMUCO(int id = 0);
    }
}
