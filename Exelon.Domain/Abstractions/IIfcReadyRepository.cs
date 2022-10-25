
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exelon.Domain.Abstractions
{
    public interface IIfcReadyRepository
    {
        public Task<List<IfcReadyModel>> GetIFC(int id = 0);
        public Task<Dictionary<IfcReadyModel, string>> CreateIFC(IfcReadyModel iFCREADYModel);
        public Task<IfcReadyModel> UpdateIFC(IfcReadyModel iFCREADYModel);
        public Task<int> DeleteIFC(int id = 0);
    }
}
