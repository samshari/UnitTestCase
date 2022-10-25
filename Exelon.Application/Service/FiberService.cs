using Exelon.Application.IServices;
using Exelon.Domain;
using Exelon.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exelon.Application.Service
{
    public class FIBERService : IFIBERService
    {
        private readonly IFIBERRepository _fIBERRepository;


        public FIBERService(IFIBERRepository fIBERRepository)
        {
            _fIBERRepository = fIBERRepository;
        }

        public async Task<List<FIBERModel>> GetFIBER(int id = 0)
        {
            return await _fIBERRepository.GetFIBER(id);
        }
        public async Task<Dictionary<FIBERModel, string>> CreateFIBER(FIBERModel fIBERModel)
        {
            return await _fIBERRepository.CreateFIBER(fIBERModel);
        }
        public async  Task<FIBERModel> UpdateFIBER(FIBERModel fIBERModel)
        {
            return await _fIBERRepository.UpdateFIBER(fIBERModel);
        }
        public async Task<int> DeleteFIBER(int id)
        {
            return await _fIBERRepository.DeleteFIBER(id);
        }
    }
}
