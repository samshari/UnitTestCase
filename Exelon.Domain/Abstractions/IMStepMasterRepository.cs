
using Exelon.Domain;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exelon.Domain.Abstractions
{
    public interface IMSTEPMASTERRepository
    {
        public Task<MSTEPMASTERModel> GetSTEPBYID(int id);
    }
}
