using Exelon.Application.IServices;
using Exelon.Domain;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Exelon.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HUTPERMITController : ControllerBase
    {
        private readonly IUnitOfWorkService _unitOfWorkService;

        public HUTPERMITController(IUnitOfWorkService unitOfWorkService)
        {
            _unitOfWorkService = unitOfWorkService;
        }

        [NonAction]
        public ActionResult NotFoundResult()
        {
            return NotFound(new { status = 404, message = "Not Exists!" });
        }




        #region Hut Permitting
        [HttpGet]
        public async Task<ActionResult> GetHUT()
        {
            var result = await _unitOfWorkService.hUTPERMITService.GetHUT();
            if (result.Count == 0)
                return NotFoundResult();
            else
                return Ok(result);

        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetHUTBySub(string id)
        {
            var result = await _unitOfWorkService.hUTPERMITService.GetHutBySub(id);
            if (result.Count == 0)
                return NotFoundResult();
            else
                return Ok(result);

        }


        [HttpGet("{id}")]
        public async Task<ActionResult> GetHUT(int id)
        {
            var result = await _unitOfWorkService.hUTPERMITService.GetHUT(id);
            if (result.Count == 0)
                return NotFoundResult();
            else
                return Ok(result);

        }

        [HttpPost]
        public async Task<ActionResult> CreateHUT([FromBody] HUTPERMITTINGModel hUTPERMITTINGModel)
        {
            hUTPERMITTINGModel.CreatedBy = "1";
            var result = await _unitOfWorkService.hUTPERMITService.CreateHUT(hUTPERMITTINGModel);
            KeyValuePair<HUTPERMITTINGModel, string> i = result.First();
            if (i.Value == "ok")
                return Ok(new { ID = i.Key.HutPermittingID });
            else if (i.Value == "")
                return BadRequest(new { status = 400, message = "Oops Something Went Wrong!" });
            else
                return BadRequest(new { status = 400, message = i.Value });
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateHUT(int id, [FromBody] HUTPERMITTINGModel hUTPERMITTINGModel)
        {
            hUTPERMITTINGModel.UpdatedBy = "1";
            hUTPERMITTINGModel.HutPermittingID = id;
            var result = await _unitOfWorkService.hUTPERMITService.UpdateHUT(hUTPERMITTINGModel);
            KeyValuePair<HUTPERMITTINGModel, string> i = result.First();
            if (i.Value == "ok")
                return Ok(new { status = 200 });
            else if (i.Value == "")
                return BadRequest(new { status = 400, message = "Oops Something Went Wrong!" });
            else
                return BadRequest(new { status = 400, message = i.Value });
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteHUT(int id)
        {
            var result = await _unitOfWorkService.hUTPERMITService.DeleteHUT(id);
            if (result == 0)
                return BadRequest(new { status = 400, message = "Oops Something Went Wrong!" });
            else
                return Ok(new { status = 200});
        }

        #endregion
    }
}
