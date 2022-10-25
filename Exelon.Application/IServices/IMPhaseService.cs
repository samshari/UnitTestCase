using Exelon.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exelon.Application.IServices
{
    public interface IMPhaseService
    {
        public Task<List<MPhaseModel>> GetMPhase(int id = 0);
    }
}
