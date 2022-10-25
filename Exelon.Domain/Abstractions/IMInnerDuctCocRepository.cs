
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exelon.Domain.Abstractions
{
    public interface IMINNERDUCTCOCRepository
    {
        public Task<List<MINNERDUCTCOCModel>> GetINNERDUCT(int id = 0);
    }
}
