using Exelon.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exelon.Application.IServices
{
    public interface IMREACTLREService
    {
        public Task<List<MREACTLREModel>> GetMREACT(int id = 0);
    }
}
