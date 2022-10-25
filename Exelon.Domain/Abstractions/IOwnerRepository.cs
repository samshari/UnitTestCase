
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exelon.Domain.Abstractions
{
    public interface IOWNERRepository
    {
        public Task<List<OWNERSModel>> GetOWNER(int id = 0);
        public Task<Dictionary<OWNERSModel, string>> CreateOWNER(OWNERSModel oWNERSModel);
        public Task<Dictionary<OWNERSModel, string>> UpdateOWNER(OWNERSModel oWNERSModel);
        public Task<int> DeleteOWNER(int id);
    }
}
