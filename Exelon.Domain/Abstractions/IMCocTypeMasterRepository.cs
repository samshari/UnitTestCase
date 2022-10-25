using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exelon.Domain.Abstractions
{
    public interface IMCOCTYPEMASTERRepository
    {
        public Task<List<MCOCTYPEMASTERModel>> GetMCOCTYPE(int id = 0);
    }
}
