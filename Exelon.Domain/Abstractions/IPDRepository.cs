
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exelon.Domain.Abstractions
{
    public interface IPDRepository
    {
        public Task<List<PdModel>> GetPD(int id = 0);
        public Task<PdModel> CreatePD(PdModel pDModel);
        public Task<PdModel> UpdatePD(PdModel pDModel);
        public Task<int> DeletePD(int id);
    }
}
