using Exelon.Application.IServices;
using Exelon.Domain.Abstractions;
using Exelon.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exelon.Application.Service
{
    public class PostCompletionService : IPostCompletionService
    {
        private readonly IPostCompletionRepository _postCompletionRepository;

        public PostCompletionService(IPostCompletionRepository postCompletionRepository)
        {
            _postCompletionRepository = postCompletionRepository;
        }

        public async  Task<List<PostCompletionModel>> GetPostCompletion(int id = 0)
        {
            return await _postCompletionRepository.GetPostCompletion(id);
        }
        public async Task<Dictionary<PostCompletionModel, string>> CreatePostCompletion(PostCompletionModel postCompletionModel)
        {
            return await _postCompletionRepository.CreatePostCompletion(postCompletionModel);
        }
        public async Task<PostCompletionModel> UpdatePostCompletion(PostCompletionModel postCompletionModel)
        {
            return await _postCompletionRepository.UpdatePostCompletion(postCompletionModel);
        }
        public async Task<int> DeletePostCompletion(int id)
        {
            return await _postCompletionRepository.DeletePostCompletion(id);
        }
    }
}
