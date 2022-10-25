using Exelon.Application.IServices;
using Exelon.Domain;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Exelon.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HUTSController : ControllerBase
    {
        private readonly IUnitOfWorkService _unitOfWorkService;
        public HUTSController(IUnitOfWorkService unitOfWorkService)
        {
            _unitOfWorkService = unitOfWorkService;
        }


        public ActionResult NotFoundResult()
        {
            return NotFound(new { status = 404, message = "Not Exists!" });
        }



        #region Huts


        [HttpGet]
        public async Task<ActionResult> GetHUTS()
        {
            var result = await _unitOfWorkService.hUTService.GetHUTS();
            if (result.Count == 0)
                return NotFoundResult();
            else
                return Ok(result);

        }



        [HttpGet("{id}")]
        public async Task<ActionResult> GetHUTS(int id)
        {
            var result = await _unitOfWorkService.hUTService.GetHUTS(id);
            if (result.Count == 0)
                return NotFoundResult();
            else
                return Ok(result);
        }


        [HttpPost]
        public async Task<ActionResult> CreateHUTS([FromBody] HUTSModel hUTSModel)
        {
            hUTSModel.CreatedBy = "1";
            var result = await _unitOfWorkService.hUTService.CreateHUTS(hUTSModel);
            if (result.HutsID == 0)
                return BadRequest(new { status = 400, message = "Oops Something Went Wrong!" });
            else
                return Ok(new { ID = hUTSModel.HutsID });
        }


        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateHUTS(int id, [FromBody] HUTSModel hUTSModel)
        {
            hUTSModel.UpdatedBy = "1";
            hUTSModel.HutsID = id;
            var result = await _unitOfWorkService.hUTService.UpdateHUTS(hUTSModel);
            if (result.HutsID == 0)
                return BadRequest(new { status = 400, message = "Oops Something Went Wrong!" });
            else
                return Ok(new { status = 200 });
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteHUTS(int id)
        {
            
            var result = await _unitOfWorkService.hUTService.DeleteHUTS(id);
            if (result == 0)
                return BadRequest(new { status = 400, message = "Oops Something Went Wrong!" });
            else
                return Ok(new { status = 200 });
        }


        #endregion

    }
}
