
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exelon.Domain.Abstractions
{
    public interface ICIVILRepository
    {
        public Task<List<CIVILModel>> GetCIVIL(int id = 0);
        public Task<Dictionary<CIVILModel, string>> CreateCIVIL(CIVILModel cIVILModel);
        public Task<CIVILModel> UpdateCIVIL(CIVILModel cIVILModel);
        public Task<int> DeleteCIVIL(int id);
    }
}
