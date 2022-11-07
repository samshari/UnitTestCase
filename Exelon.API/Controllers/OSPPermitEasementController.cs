using Exelon.Application.IServices;
using Exelon.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Exelon.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OSPPermitEasementController : ControllerBase
    {
        private readonly IUnitOfWorkService _unitOfWorkService;

        public OSPPermitEasementController(IUnitOfWorkService unitOfWorkService)
        {
            _unitOfWorkService = unitOfWorkService;
        }
        public ActionResult NotFoundResult()
        {
            return NotFound(new { status = 404, message = "Not Exists!" });
        }

        #region [Get OSP Permit Easement]
        /// <summary>
        /// Get OSP Permit Easement
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult> GetOSPPermitEasement(int id=0)
        {
            var result = await _unitOfWorkService.oSPPermitEasementService.GetOSPPermitEasement(id);
            if (result.Count == 0)
                return NotFoundResult();
            else
                return Ok(result);
        }
        #endregion

        #region [Save OSP Permit Easement]
        /// <summary>
        /// Save OSP Permit Easement
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> SaveOSPPermitEasement([FromBody] OSPPermitEasementModel model)
        {
            model.CreatedBy = "1";
            model.UpdatedBy = "1";
            var result = await _unitOfWorkService.oSPPermitEasementService.SaveUpdatedOSPPermitEasement(model);
            if (result.PermitId > 0)
                return Ok(new { ID = result.PermitId });
            else if (result.PermitId == 0)
                return BadRequest(new { status = (int)HttpStatusCode.BadRequest, message = "Oops Something Went Wrong!" });
            else
                return BadRequest(new { status = (int)HttpStatusCode.BadRequest, message = result.PermitId });
        }
        #endregion

        #region [Update OSP Permit Easement]
        /// <summary>
        /// Update OSP Permit Easement
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateOSPPermitEasement([FromBody] OSPPermitEasementModel model)
        {
            model.CreatedBy = "1";
            model.UpdatedBy = "1";
            var result = await _unitOfWorkService.oSPPermitEasementService.SaveUpdatedOSPPermitEasement(model);
            if (result.PermitId == 0)
                return BadRequest(new { status = 400, message = "Oops Something Went Wrong!" });
            else
                return Ok(new { status = 200 });
        }
        #endregion 
    }
}
