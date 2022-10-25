using Exelon.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exelon.Application.IServices
{
    public interface IENGINVESTService
    {
        public Task<List<ENGINVESTModel>> GetENGINVEST(int id = 0);
        public Task<Dictionary<ENGINVESTModel, string>> CreateENGINVEST(ENGINVESTModel eNGINVESTModel);
        public Task<ENGINVESTModel> UpdateENGINVEST(ENGINVESTModel eNGINVESTModel);
        public Task<int> DeleteENGINVEST(int id);
    }
}
