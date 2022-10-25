
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exelon.Domain.Abstractions
{
    public interface IPRECONSTRUCTIONRepository
    {
        public Task<List<PRECONSTRUCTIONModel>> GetPreConstruction(int id = 0);
        public Task<Dictionary<PRECONSTRUCTIONModel,string>> CreatePreConstruction(PRECONSTRUCTIONModel pRECONSTRUCTIONModel);
        public Task<PRECONSTRUCTIONModel> UpdatePreConstruction(PRECONSTRUCTIONModel pRECONSTRUCTIONModel);
        public Task<int> DeletePreConstruction(int id);
    }
}
