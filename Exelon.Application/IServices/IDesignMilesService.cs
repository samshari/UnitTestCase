using Exelon.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exelon.Application.IServices
{
    public interface IDesignMilesService
    {
        public Task<List<DesignMilesModel>> GetDESIGN(int id = 0);
        public Task<Dictionary<DesignMilesModel, string>> CreateDESIGN(DesignMilesModel dESIGNMILESModel);
        public Task<DesignMilesModel> UpdateDESIGN(DesignMilesModel dESIGNMILESModel);
        public Task<int> DeleteDESIGN(int id);
    }
}
