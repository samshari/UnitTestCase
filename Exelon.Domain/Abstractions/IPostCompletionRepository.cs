using Exelon.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exelon.Domain.Abstractions
{
    public interface IPostCompletionRepository
    {
        public Task<List<PostCompletionModel>> GetPostCompletion(int id = 0);
        public Task<Dictionary<PostCompletionModel, string>> CreatePostCompletion(PostCompletionModel postCompletionModel);
        public Task<PostCompletionModel> UpdatePostCompletion(PostCompletionModel postCompletionModel);
        public Task<int> DeletePostCompletion(int id);
    }
}
