using Exelon.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exelon.Application.IServices
{
    public interface IMCOCMKREADYService
    {
        public Task<List<MCOCMKREADYModel>> GetMCOCMK(int id = 0);
    }
}
