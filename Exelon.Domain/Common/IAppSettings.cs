using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Exelon.Domain.Common
{
    public interface IAppSettings
    {
        string GetConnectionString();
        
    }

}
