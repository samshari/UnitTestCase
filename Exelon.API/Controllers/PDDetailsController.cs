using Exelon.Application.IServices;
using Exelon.Domain;
using Exelon.Domain.Entities;
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
    public class PDDetailsController : ControllerBase
    {
        private readonly IUnitOfWorkService _unitOfWorkService;
        public PDDetailsController(IUnitOfWorkService unitOfWorkService)
        {
            _unitOfWorkService = unitOfWorkService;
        }
        [NonAction]
        public ActionResult NotFoundResult()
        {
            return NotFound(new { status = 404, message = "Not Exists!" });
        }

        #region [PD Information]

        #region [Save PD Infrmation]
        /// <summary>
        /// Save PD Information
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> SavePDInformation([FromBody] PDDetailsModel model)
        {
            model.CreatedBy = "1";
            var result = await _unitOfWorkService.pDDetailsService.SavePDInformation(model);
            if (result.PDInformationId > 0)
                return Ok(new { ID = result.PDInformationId });
            else if (result.PDInformationId == 0)
                return BadRequest(new { status = 400, message = "Oops Something Went Wrong!" });
            else
                return BadRequest(new { status = 400, message = "Oops Something Went Wrong!" });
        }
        #endregion

        #region [Update PD Information]
        /// <summary>
        /// Update PD Information
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdatePDInformation(int id, [FromBody] PDDetailsModel model)
        {
            model.UpdatedBy = "1";
            model.PDInformationId = id;
            var result = await _unitOfWorkService.pDDetailsService.SavePDInformation(model);
            if (result.PDInformationId == 0)
                return BadRequest(new { status = 400, message = "Oops Something Went Wrong!" });
            else
                return Ok(new { status = 200 });
        }
        #endregion

        #region [Get PD Information By Id]
        /// <summary>
        /// Get PD Information By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult> GetPDInformationById(int id)
        {
            var result = await _unitOfWorkService.pDDetailsService.GetPDInformationById(id);
            if (result == null)
                return NotFoundResult();
            else
                return Ok(result);
        }
        #endregion
        #endregion

        #region [PD COC]

        #region [Save PD COC]
        /// <summary>
        /// Save PD COC
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> SavePDCOC([FromBody] PDCOCModel model)
        {
            model.CreatedBy = "1";
            var result = await _unitOfWorkService.pDDetailsService.SaveUpdatePDCOC(model);
            if (result.PDCOCId > 0)
                return Ok(new { ID = result.PDInformationId });
            else if (result.PDInformationId == 0)
                return BadRequest(new { status = 400, message = "Oops Something Went Wrong!" });
            else
                return BadRequest(new { status = 400, message = "Oops Something Went Wrong!" });
        }
        #endregion

        #region [Update PD COC]
        /// <summary>
        /// Update PD COC
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdatePDCOC(int id, [FromBody] PDCOCModel model)
        {
            model.UpdatedBy = "1";
            model.PDCOCId = id;
            var result = await _unitOfWorkService.pDDetailsService.SaveUpdatePDCOC(model);
            if (result.PDInformationId == 0)
                return BadRequest(new { status = 400, message = "Oops Something Went Wrong!" });
            else
                return Ok(new { status = 200 });
        }
        #endregion

        #region [Get PD COC By Id]
        /// <summary>
        /// Get PD COC By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult> GetPDCOCById(int id)
        {
            var result = await _unitOfWorkService.pDDetailsService.GetPDCOCById(id);
            if (result == null)
                return NotFoundResult();
            else
                return Ok(result);
        }
        #endregion
        #endregion

        #region [PD EOC]

        #region [Save PD EOC]
        /// <summary>
        /// Save PD EOC
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> SavePDEOC([FromBody] PDEOCModel model)
        {
            model.CreatedBy = "1";
            var result = await _unitOfWorkService.pDDetailsService.SaveUpdatePDEOC(model);
            if (result.PDEOCId > 0)
                return Ok(new { ID = result.PDInformationId });
            else if (result.PDInformationId == 0)
                return BadRequest(new { status = 400, message = "Oops Something Went Wrong!" });
            else
                return BadRequest(new { status = 400, message = "Oops Something Went Wrong!" });
        }
        #endregion

        #region [Update PD EOC]
        /// <summary>
        /// Update PD EOC
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdatePDEOC(int id, [FromBody] PDEOCModel model)
        {
            model.UpdatedBy = "1";
            model.PDEOCId = id;
            var result = await _unitOfWorkService.pDDetailsService.SaveUpdatePDEOC(model);
            if (result.PDInformationId == 0)
                return BadRequest(new { status = 400, message = "Oops Something Went Wrong!" });
            else
                return Ok(new { status = 200 });
        }
        #endregion

        #region [Get PD EOC By Id]
        /// <summary>
        /// Get PD EOC By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult> GetPDEOCById(int id)
        {
            var result = await _unitOfWorkService.pDDetailsService.GetPDEOCById(id);
            if (result == null)
                return NotFoundResult();
            else
                return Ok(result);
        }
        #endregion
        #endregion

        #region [PD Fiber]

        #region [Save PD Fiber]
        /// <summary>
        /// Save PD Fiber
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> SavePDFiber([FromBody] PDFiberModel model)
        {
            model.CreatedBy = "1";
            var result = await _unitOfWorkService.pDDetailsService.SaveUpdatePDFiber(model);
            if (result.PDFiberId > 0)
                return Ok(new { ID = result.PDInformationId });
            else if (result.PDInformationId == 0)
                return BadRequest(new { status = 400, message = "Oops Something Went Wrong!" });
            else
                return BadRequest(new { status = 400, message = "Oops Something Went Wrong!" });
        }
        #endregion

        #region [Update PD Fiber]
        /// <summary>
        /// Update PD Fiber
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdatePDFiber(int id, [FromBody] PDFiberModel model)
        {
            model.UpdatedBy = "1";
            model.PDFiberId = id;
            var result = await _unitOfWorkService.pDDetailsService.SaveUpdatePDFiber(model);
            if (result.PDInformationId == 0)
                return BadRequest(new { status = 400, message = "Oops Something Went Wrong!" });
            else
                return Ok(new { status = 200 });
        }
        #endregion

        #region [Get PD Fiber By Id]
        /// <summary>
        /// Get PD Fiber By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult> GetPDFiberById(int id)
        {
            var result = await _unitOfWorkService.pDDetailsService.GetPDFiberById(id);
            if (result == null)
                return NotFoundResult();
            else
                return Ok(result);
        }
        #endregion
        #endregion
    }
}
