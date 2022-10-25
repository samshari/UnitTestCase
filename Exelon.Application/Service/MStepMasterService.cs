using Exelon.Application.IServices;
using Exelon.Domain;
using Exelon.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exelon.Application.Service
{
    public class MSTEPMASTERService : IMSTEPMASTERService
    {
        private readonly IMSTEPMASTERRepository _mSTEPMASTERRepository;

        public MSTEPMASTERService(IMSTEPMASTERRepository mSTEPMASTERRepository)
        {
            _mSTEPMASTERRepository = mSTEPMASTERRepository;
        }

        public async  Task<MSTEPMASTERModel> GetSTEPBYID(int id)
        {
            return await _mSTEPMASTERRepository.GetSTEPBYID(id);
        }
    }
}
