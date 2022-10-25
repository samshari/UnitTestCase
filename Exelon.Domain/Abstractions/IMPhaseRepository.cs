using Exelon.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exelon.Domain.Abstractions
{
    public interface IMPhaseRepository
    {
        public Task<List<MPhaseModel>> GetMPhase(int id = 0);
    }
}
