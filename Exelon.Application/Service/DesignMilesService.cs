
using Exelon.Application.IServices;
using Exelon.Domain;
using Exelon.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exelon.Application.Service
{
    public class DesignMilesService : IDesignMilesService
    {
        private readonly IDesignMilesRepository _dESIGNMILESRepository;

        public DesignMilesService(IDesignMilesRepository dESIGNMILESRepository)
        {
            _dESIGNMILESRepository = dESIGNMILESRepository;
        }

        public async Task<List<DesignMilesModel>> GetDESIGN(int id = 0)
        {
            return await _dESIGNMILESRepository.GetDESIGN(id);
        }

        public async Task<Dictionary<DesignMilesModel, string>> CreateDESIGN(DesignMilesModel dESIGNMILESModel)
        {
            return await _dESIGNMILESRepository.CreateDESIGN(dESIGNMILESModel);
        }

        public async Task<DesignMilesModel> UpdateDESIGN(DesignMilesModel dESIGNMILESModel)
        {
            return await _dESIGNMILESRepository.UpdateDESIGN(dESIGNMILESModel);
        }

        public async Task<int> DeleteDESIGN(int id)
        {
            return await _dESIGNMILESRepository.DeleteDESIGN(id);
        }
    }
}
