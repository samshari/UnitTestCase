using Exelon.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exelon.Application.IServices
{
    public interface IGENERALService
    {
        public Task<COMMONREQModel> GetGENERAL(int id);
    }
}
