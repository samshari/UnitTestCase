
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exelon.Domain.Abstractions
{
    public interface IFIBERRepository
    {
        public Task<List<FIBERModel>> GetFIBER(int id = 0);
        public Task<Dictionary<FIBERModel, string>> CreateFIBER(FIBERModel fIBERModel);
        public Task<FIBERModel> UpdateFIBER(FIBERModel fIBERModel);
        public Task<int> DeleteFIBER(int id);

        /// <summary>
        /// Completed Fiber Miles
        /// </summary>
        /// <returns></returns>
        Task<ExecutionCompletedFiberMile> GetCompletedFiberMileById(int id);
        Task<ExecutionCompletedFiberMile> SaveUpdateCompletedFiberMile(ExecutionCompletedFiberMile model);
    }
}
