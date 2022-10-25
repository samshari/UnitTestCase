using Exelon.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exelon.Application.IServices
{
    public interface IHUTService
    {
        public Task<List<HUTSModel>> GetHUTS(int id = 0);
        public Task<HUTSModel> CreateHUTS(HUTSModel hUTSModel);
        public Task<HUTSModel> UpdateHUTS(HUTSModel hUTSModel);
        public Task<int> DeleteHUTS(int id);
    }
}
