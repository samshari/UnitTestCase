
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exelon.Domain.Abstractions
{
    public interface IDesignMilesRepository
    {
        public Task<List<DesignMilesModel>> GetDESIGN(int id = 0);
        public Task<Dictionary<DesignMilesModel, string>> CreateDESIGN(DesignMilesModel dESIGNMILESModel);
        public Task<DesignMilesModel> UpdateDESIGN(DesignMilesModel dESIGNMILESModel);
        public Task<int> DeleteDESIGN(int id);
    }
}
