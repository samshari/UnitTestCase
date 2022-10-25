
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exelon.Domain.Abstractions
{
    public interface IIFCFIBERRepository
    {
        public Task<List<IfcFiberModel>> GetIFCFIBER(int id = 0);
        public Task<Dictionary<IfcFiberModel,string>> CreateIFCFIBER(IfcFiberModel mIFCFIBERModel);
        public Task<IfcFiberModel> UpdateIFCFIBER(IfcFiberModel mIFCFIBERModel);
        public Task<int> DeleteIFCFIBER(int id);
    }
}
