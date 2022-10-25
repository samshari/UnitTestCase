
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exelon.Domain.Abstractions
{
    public interface IENGINVESTRepository
    {
        public Task<List<ENGINVESTModel>> GetENGINVEST(int id = 0);
        public Task<Dictionary<ENGINVESTModel, string>> CreateENGINVEST(ENGINVESTModel eNGINVESTModel);
        public Task<ENGINVESTModel> UpdateENGINVEST(ENGINVESTModel eNGINVESTModel);
        public Task<int> DeleteENGINVEST(int id);
    }
}
