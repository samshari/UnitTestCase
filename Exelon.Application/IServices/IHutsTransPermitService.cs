using Exelon.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exelon.Application.IServices
{
    public interface IHUTSTRANSPERMITService
    {
        public Task<COMMONREQModel> GetHUTSTRANS(int id);
    }

}
