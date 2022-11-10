using Exelon.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exelon.Application.IServices
{
    public interface IFIBERService
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
        Task<Dictionary<ExecutionCompletedFiberMile, string>> SaveUpdateCompletedFiberMile(ExecutionCompletedFiberMile model);
        Task<ExecutionCompletedFiberMile> GetCompletedFiberMileByLinkId(int id);
        Task<ExecutionCompletedFiberMile> UpdateCompletedFiberMile(ExecutionCompletedFiberMile model);
    }
}
