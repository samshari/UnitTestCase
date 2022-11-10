using Exelon.Application.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exelon.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PerformProgressController : ControllerBase
    {
        private readonly IUnitOfWorkService _unitOfWorkService;

        public PerformProgressController(IUnitOfWorkService unitOfWorkService)
        {
            _unitOfWorkService = unitOfWorkService;
        }

        [NonAction]
        public ActionResult NotFoundResult()
        {
            return NotFound(new { status = 404, message = "Not Exists!" });
        }
    }
}
