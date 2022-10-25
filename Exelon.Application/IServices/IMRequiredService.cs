using Exelon.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exelon.Application.IServices
{
    public interface IMREQUIREDService
    {
        public Task<List<MREQUIREDModel>> GetMREQ(int id = 0);
    }
}
