
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exelon.Domain.Abstractions
{
    public interface IMPROJECTSTATUSRepository
    {
        public Task<List<MPROJECTSTATUSModel>> GETMPROJECTSTATUS(int id = 0);
    }
}
