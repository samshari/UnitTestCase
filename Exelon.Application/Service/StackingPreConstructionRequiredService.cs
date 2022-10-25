using Exelon.Application.IServices;
using Exelon.Domain;
using Exelon.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exelon.Application.Service
{
    public class STACKINGPreConstructionRequiredService : ISTACKINGPreConstructionRequiredService
    {
        private readonly ISTACKINGPreConstructionRequiredRepository _sTAKINGPreConstructionRequired;

        public STACKINGPreConstructionRequiredService(ISTACKINGPreConstructionRequiredRepository sTAKINGPreConstructionRequired)
        {
            sTAKINGPreConstructionRequired = _sTAKINGPreConstructionRequired;
        }
        public async Task<COMMONREQModel> GetStakingConstructionRequired(int id)
        {
            return await _sTAKINGPreConstructionRequired.GetStakingConstructionRequired(id);
        }
    }
}
