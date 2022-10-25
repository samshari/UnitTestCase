
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exelon.Domain.Abstractions
{
    public interface IIfaFiberRepository
    {
        public Task<List<IfaFiberModel>> GetIFAFIBER(int id = 0);
        public Task<Dictionary<IfaFiberModel,string>> CreateIFAFIBER(IfaFiberModel ifaFiberModel);
        public Task<IfaFiberModel> UpdateIFAFIBER(IfaFiberModel ifaFiberModel);
        public Task<int> DeleteIFAFIBER(int id);
    }
}
