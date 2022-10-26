﻿using Exelon.Application.IServices;
using Exelon.Domain;
using Exelon.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Exelon.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EXECUTIONLINKSController : ControllerBase
    {

        
        private readonly IUnitOfWorkService _unitOfWorkService;

        public EXECUTIONLINKSController(IUnitOfWorkService unitOfWorkService)
        {
            _unitOfWorkService = unitOfWorkService;
        }

        public ActionResult NotFoundResult()
        {
            return NotFound(new { status = 404, message = "Not Exists!" });
        }


        #region Engineering Invest
        [HttpGet]
        public async Task<ActionResult> GetENGINVEST()
        {
            var result = await _unitOfWorkService.eNGINVESTService.GetENGINVEST();
            if (result.Count == 0)
                return NotFoundResult();
            else
                return Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult> GetENGINVEST(int id)
        {
            var result = await _unitOfWorkService.eNGINVESTService.GetENGINVEST(id);
            if (result.Count == 0)
                return NotFoundResult();
            else
                return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> CreateENGINVEST([FromBody] ENGINVESTModel eNGINVESTModel)
        {
            eNGINVESTModel.CreatedBy = "1";
            var result = await _unitOfWorkService.eNGINVESTService.CreateENGINVEST(eNGINVESTModel);
            KeyValuePair<ENGINVESTModel, string> i = result.First();
            if (i.Value == "ok")
                return Ok(new { ID = i.Key.EnggInvestigationID });
            else if (i.Value == "")
                return BadRequest(new { status = 400, message = "Oops Something Went Wrong!" });
            else
                return BadRequest(new { status = 400, message = i.Value });
        }


        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateENGINVEST(int id, [FromBody] ENGINVESTModel eNGINVESTModel)
        {
            eNGINVESTModel.UpdatedBy = "1";
            eNGINVESTModel.EnggInvestigationID = id;
            var result = await _unitOfWorkService.eNGINVESTService.UpdateENGINVEST(eNGINVESTModel);
            if (result.EnggInvestigationID == 0)
                return BadRequest(new { status = 400, message = "Oops Something Went Wrong!" });
            else
                return Ok(new { status = 200 });
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteENGINVEST(int id)
        {
            var result = await _unitOfWorkService.eNGINVESTService.DeleteENGINVEST(id);
            if (result == 0)
                return BadRequest(new { status = 400, message = "Oops Something Went Wrong!" });
            else
                return Ok(new { status = 200 });
        }

        #endregion


        #region Inner Rod Rope

        [HttpGet]
        public async Task<ActionResult> GetRODROPE()
        {
            var result = await _unitOfWorkService.iNNERRODROPEService.GetRODROPE();
            if (result.Count == 0)
                return NotFoundResult();
            else
                return Ok(result);
        }




        [HttpGet("{id}")]
        public async Task<ActionResult> GetRODROPE(int id)
        {
            var result = await _unitOfWorkService.iNNERRODROPEService.GetRODROPE(id);
            if (result.Count == 0)
                return NotFoundResult();
            else
                return Ok(result);
        }


        [HttpPost]
        public async Task<ActionResult> CreateRODROPE([FromBody] InnerRodRopeModel iNNERODROPEModel)
        {
            iNNERODROPEModel.CreatedBy = "1";
            var result = await _unitOfWorkService.iNNERRODROPEService.CreateRODROPE(iNNERODROPEModel);
            KeyValuePair<InnerRodRopeModel, string> i = result.First();
            if (i.Value == "ok")
                return Ok(new { ID = i.Key.RodAndRopeID });
            else if (i.Value == "")
                return BadRequest(new { status = 400, message = "Oops Something Went Wrong!" });
            else
                return BadRequest(new { status = 400, message = i.Value });
        }


        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateRODROPE(int id, [FromBody] InnerRodRopeModel iNNERODROPEModel)
        {
            iNNERODROPEModel.UpdatedBy = "1";
            iNNERODROPEModel.RodAndRopeID = id;
            var result = await _unitOfWorkService.iNNERRODROPEService.UpdateRODROPE(iNNERODROPEModel);
            if (result.RodAndRopeID == 0)
                return BadRequest(new { status = 400, message = "Oops Something Went Wrong!" });
            else
                return Ok(new { status = 200 });
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteRODROPE(int id)
        {
            var result = await _unitOfWorkService.iNNERRODROPEService.DeleteRODROPE(id);
            if (result == 0)
                return BadRequest(new { status = 400, message = "Oops Something Went Wrong!" });
            else
                return Ok(new { status = 200 });
        }

        #endregion

        #region IFC Dates
        [HttpGet]
        public async Task<ActionResult> GetIFCDATES()
        {
            var result = await _unitOfWorkService.iFCDATESService.GetIFCDATES();
            if (result.Count == 0)
                return NotFoundResult();
            else
                return Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult> GetIFCDATES(int id)
        {
            var result = await _unitOfWorkService.iFCDATESService.GetIFCDATES(id);
            if (result.Count == 0)
                return NotFoundResult();
            else
                return Ok(result);
        }


        [HttpPost]
        public async Task<ActionResult> CreateIFCDATES([FromBody] IFCDATESModel iFCDATESModel)
        {
            iFCDATESModel.CreatedBy = "1";
            var result = await _unitOfWorkService.iFCDATESService.CreateIFCDATES(iFCDATESModel);
            KeyValuePair<IFCDATESModel, string> i = result.First();
            if (i.Value == "ok")
                return Ok(new { ID = i.Key.IFCDateID });
            else if (i.Value == "")
                return BadRequest(new { status = 400, message = "Oops Something Went Wrong!" });
            else
                return BadRequest(new { status = 400, message = i.Value });
        }


        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateIFCDATES(int id, [FromBody] IFCDATESModel iFCDATESModel)
        {
            iFCDATESModel.UpdatedBy = "1";
            iFCDATESModel.IFCDateID = id;
            var result = await _unitOfWorkService.iFCDATESService.UpdateIFCDATES(iFCDATESModel);
            if (result.IFCDateID == 0)
                return BadRequest(new { status = 400, message = "Oops Something Went Wrong!" });
            else
                return Ok(new { status = 200 });
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteIFCDATES(int id)
        {
            var result = await _unitOfWorkService.iFCDATESService.DeleteIFCDATES(id);
            if (result == 0)
                return BadRequest(new { status = 400, message = "Oops Something Went Wrong!" });
            else
                return Ok(new { status = 200 });
        }

        #endregion


        #region PreConsturction
        [HttpGet]
        public async Task<ActionResult> GetPreConstruction()
        {
            var result = await _unitOfWorkService.pRECONSTRUCTIONService.GetPreConstruction();
            if (result.Count == 0)
                return NotFoundResult();
            else
                return Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult> GetPreConstruction(int id)
        {
            var result = await _unitOfWorkService.pRECONSTRUCTIONService.GetPreConstruction(id);
            if (result.Count == 0)
                return NotFoundResult();
            else
                return Ok(result);
        }


        [HttpPost]
        public async Task<ActionResult> CreatePreConstruction([FromBody] PRECONSTRUCTIONModel pRECONSTRUCTIONModel)
        {
            pRECONSTRUCTIONModel.CreatedBy = "1";
            var result = await _unitOfWorkService.pRECONSTRUCTIONService.CreatePreConstruction(pRECONSTRUCTIONModel);
            KeyValuePair<PRECONSTRUCTIONModel, string> i = result.First();
            if (i.Value == "ok")
                return Ok(new { ID = i.Key.PreContructionID });
            else if (i.Value == "")
                return BadRequest(new { status = 400, message = "Oops Something Went Wrong!" });
            else
                return BadRequest(new { status = 400, message = i.Value });
        }


        
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdatePreConstruction(int id, [FromBody] PRECONSTRUCTIONModel pRECONSTRUCTIONModel)
        {
            pRECONSTRUCTIONModel.UpdatedBy = "1";
            pRECONSTRUCTIONModel.PreContructionID = id;
            var result = await _unitOfWorkService.pRECONSTRUCTIONService.UpdatePreConstruction(pRECONSTRUCTIONModel);
            if (result.PreContructionID == 0)
                return BadRequest(new { status = 400, message = "Oops Something Went Wrong!" });
            else
                return Ok(new { status = 200 });
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePreConstruction(int id)
        {
            var result = await _unitOfWorkService.pRECONSTRUCTIONService.DeletePreConstruction(id);
            if (result == 0)
                return BadRequest(new { status = 400, message = "Oops Something Went Wrong!" });
            else
                return Ok(new { status = 200 });
        }

        #endregion

        #region Complete Ed External

        [HttpGet]
        public async Task<ActionResult> GetCOMED()
        {
            var result = await _unitOfWorkService.cOMEDEXService.GetCOMED();
            if (result.Count == 0)
                return NotFoundResult();
            else
                return Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult> GetCOMED(int id)
        {
            var result = await _unitOfWorkService.cOMEDEXService.GetCOMED(id);
            if (result.Count == 0)
                return NotFoundResult();
            else
                return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> CreateCOMED([FromBody] COMEDEXModel cOMEDEXModel)
        {
            cOMEDEXModel.CreatedBy = "1";
            var result = await _unitOfWorkService.cOMEDEXService.CreateCOMED(cOMEDEXModel);
            KeyValuePair<COMEDEXModel, string> i = result.First();
            if (i.Value == "ok")
                return Ok(new { ID = i.Key.ComEdID });
            else if (i.Value == "")
                return BadRequest(new { status = 400, message = "Oops Something Went Wrong!" });
            else
                return BadRequest(new { status = 400, message = i.Value });
        }


        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCOMED(int id, [FromBody] COMEDEXModel cOMEDEXModel)
        {
            cOMEDEXModel.UpdatedBy = "1";
            cOMEDEXModel.ComEdID = id;
            var result = await _unitOfWorkService.cOMEDEXService.UpdateCOMED(cOMEDEXModel);
            if (result.ComEdID == 0)
                return BadRequest(new { status = 400, message = "Oops Something Went Wrong!" });
            else
                return Ok(new { status = 200 });
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCOMED(int id)
        {
            var result = await _unitOfWorkService.cOMEDEXService.DeleteCOMED(id);
            if (result == 0)
                return BadRequest(new { status = 400, message = "Oops Something Went Wrong!" });
            else
                return Ok(new { status = 200 });
        }

        #endregion

        #region Boring

        [HttpGet]
        public async Task<ActionResult> GetBORE()
        {
            var result = await _unitOfWorkService.bORINGService.GetBORE();
            if (result.Count == 0)
                return NotFoundResult();
            else
                return Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult> GetBORE(int id)
        {
            var result = await _unitOfWorkService.bORINGService.GetBORE(id);
            if (result.Count == 0)
                return NotFoundResult();
            else
                return Ok(result);
        }


        [HttpPost]
        public async Task<ActionResult> CreateBORE([FromBody] BORINGModel bORINGModel)
        {
            bORINGModel.CreatedBy = "1";
            var result = await _unitOfWorkService.bORINGService.CreateBORE(bORINGModel);
            KeyValuePair<BORINGModel, string> i = result.First();
            if (i.Value == "ok")
                return Ok(new { ID = i.Key.BoringID });
            else if (i.Value == "")
                return BadRequest(new { status = 400, message = "Oops Something Went Wrong!" });
            else
                return BadRequest(new { status = 400, message = i.Value });
        }


        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateBORE(int id, [FromBody] BORINGModel bORINGModel)
        {
            bORINGModel.UpdatedBy = "1";
            bORINGModel.BoringID = id;
            var result = await _unitOfWorkService.bORINGService.UpdateBORE(bORINGModel);
            if (result.BoringID == 0)
                return BadRequest(new { status = 400, message = "Oops Something Went Wrong!" });
            else
                return Ok(new { status = 200 });
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBORE(int id)
        {
            var result = await _unitOfWorkService.bORINGService.DeleteBORE(id);
            if (result == 0)
                return BadRequest(new { status = 400, message = "Oops Something Went Wrong!" });
            else
                return Ok(new { status = 200 });
        }

        #endregion

        #region CIVIL

        [HttpGet]
        public async Task<ActionResult> GetCIVIL()
        {
            var result = await _unitOfWorkService.cIVILService.GetCIVIL();
            if (result.Count == 0)
                return NotFoundResult();
            else
                return Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult> GetCIVIL(int id)
        {
            var result = await _unitOfWorkService.cIVILService.GetCIVIL(id);
            if (result.Count == 0)
                return NotFoundResult();
            else
                return Ok(result);
        }


        [HttpPost]
        public async Task<ActionResult> CreateCIVIL([FromBody] CIVILModel cIVILModel)
        {
            cIVILModel.CreatedBy = "1";
            var result = await _unitOfWorkService.cIVILService.CreateCIVIL(cIVILModel);
            KeyValuePair<CIVILModel, string> i = result.First();
            if (i.Value == "ok")
                return Ok(new { ID = i.Key.CivilID });
            else if (i.Value == "")
                return BadRequest(new { status = 400, message = "Oops Something Went Wrong!" });
            else
                return BadRequest(new { status = 400, message = i.Value });
        }


        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCIVIL(int id, [FromBody] CIVILModel cIVILModel)
        {
            cIVILModel.UpdatedBy = "1";
            cIVILModel.CivilID = id;
            var result = await _unitOfWorkService.cIVILService.UpdateCIVIL(cIVILModel);
            if (result.CivilID == 0)
                return BadRequest(new { status = 400, message = "Oops Something Went Wrong!" });
            else
                return Ok(new { status = 200 });
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCIVIL(int id)
        {
            var result = await _unitOfWorkService.cIVILService.DeleteCIVIL(id);
            if (result == 0)
                return BadRequest(new { status = 400, message = "Oops Something Went Wrong!" });
            else
                return Ok(new { status = 200 });
        }

        #endregion

        #region Fiber

        [HttpGet]
        public async Task<ActionResult> GetFIBER()
        {
            var result = await _unitOfWorkService.fIBERService.GetFIBER();
            if (result.Count == 0)
                return NotFoundResult();
            else
                return Ok(result);
        }



        [HttpGet("{id}")]
        public async Task<ActionResult> GetFIBER(int id)
        {
            var result = await _unitOfWorkService.fIBERService.GetFIBER(id);
            if (result.Count == 0)
                return NotFoundResult();
            else
                return Ok(result);
        }


        [HttpPost]
        public async Task<ActionResult> CreateFIBER([FromBody] FIBERModel fIBERModel)
        {
            fIBERModel.CreatedBy = "1";
            var result = await _unitOfWorkService.fIBERService.CreateFIBER(fIBERModel);
            KeyValuePair<FIBERModel, string> i = result.First();
            if (i.Value == "ok")
                return Ok(new { ID = i.Key.FiberID });
            else if (i.Value == "")
                return BadRequest(new { status = 400, message = "Oops Something Went Wrong!" });
            else
                return BadRequest(new { status = 400, message = i.Value });
        }


        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateFIBER(int id, [FromBody] FIBERModel fIBERModel)
        {
            fIBERModel.UpdatedBy = "1";
            fIBERModel.FiberID = id;
            var result = await _unitOfWorkService.fIBERService.UpdateFIBER(fIBERModel);
            if (result.FiberID == 0)
                return BadRequest(new { status = 400, message = "Oops Something Went Wrong!" });
            else
                return Ok(new { status = 200 });
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteFIBER(int id)
        {
            var result = await _unitOfWorkService.fIBERService.DeleteFIBER(id);
            if (result == 0)
                return BadRequest(new { status = 400, message = "Oops Something Went Wrong!" });
            else
                return Ok(new { status = 200 });
        }

        #endregion

        #region OVHD Make Ready

        [HttpGet]
        public async Task<ActionResult> GetOVHD()
        {
            var result = await _unitOfWorkService.oVHDMKService.GetOVHD();
            if (result.Count == 0)
                return NotFoundResult();
            else
                return Ok(result);
        }



        [HttpGet("{id}")]
        public async Task<ActionResult> GetOVHD(int id)
        {
            var result = await _unitOfWorkService.oVHDMKService.GetOVHD(id);
            if (result.Count == 0)
                return NotFoundResult();
            else
                return Ok(result);
        }


        [HttpPost]
        public async Task<ActionResult> CreateOVHD([FromBody] OVHDMKModel oVHDMKModel)
        {
            oVHDMKModel.CreatedBy = "1";
            var result = await _unitOfWorkService.oVHDMKService.CreateOVHD(oVHDMKModel);
            KeyValuePair<OVHDMKModel, string> i = result.First();
            if (i.Value == "ok")
                return Ok(new { ID = i.Key.OVHDMakeReadyID });
            else if (i.Value == "")
                return BadRequest(new { status = 400, message = "Oops Something Went Wrong!" });
            else
                return BadRequest(new { status = 400, message = i.Value });
        }


        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateOVHD(int id, [FromBody] OVHDMKModel oVHDMKModel)
        {
            oVHDMKModel.UpdatedBy = "1";
            oVHDMKModel.OVHDMakeReadyID = id;
            var result = await _unitOfWorkService.oVHDMKService.UpdateOVHD(oVHDMKModel);
            if (result.OVHDMakeReadyID == 0)
                return  BadRequest(new { status = 400, message = "Oops Something Went Wrong!" });
            else
                return Ok(new { status = 200 });
        }



        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteOVHD(int id)
        {
            var result = await _unitOfWorkService.oVHDMKService.DeleteOVHD(id);
            if (result == 0)
                return BadRequest(new { status = 400, message = "Oops Something Went Wrong!" });
            else
                return Ok(new { status = 200 });
        }

        #endregion

        #region PostCompletion

        [HttpGet]
        public async Task<ActionResult> GetPostCompletion()
        {
            var result = await _unitOfWorkService.postCompletionService.GetPostCompletion();
            if (result.Count == 0)
                return NotFoundResult();
            else
                return Ok(result);
        }



        [HttpGet("{id}")]
        public async Task<ActionResult> GetPostCompletion(int id)
        {
            var result = await _unitOfWorkService.postCompletionService.GetPostCompletion(id);
            if (result.Count == 0)
                return NotFoundResult();
            else
                return Ok(result);
        }


        [HttpPost]
        public async Task<ActionResult> CreatePostCompletion([FromBody] PostCompletionModel postCompletionModel)
        {
            postCompletionModel.CreatedBy = "1";
            var result = await _unitOfWorkService.postCompletionService.CreatePostCompletion(postCompletionModel);
            KeyValuePair<PostCompletionModel, string> i = result.First();
            if (i.Value == "ok")
                return Ok(new { ID = i.Key.PostCompletionID });
            else if (i.Value == "")
                return BadRequest(new { status = 400, message = "Oops Something Went Wrong!" });
            else
                return BadRequest(new { status = 400, message = i.Value });
        }


        [HttpPut("{id}")]
        public async Task<ActionResult> UpdatePostCompletion(int id, [FromBody] PostCompletionModel postCompletionModel)
        {
            postCompletionModel.UpdatedBy = "1";
            postCompletionModel.PostCompletionID = id;
            var result = await _unitOfWorkService.postCompletionService.UpdatePostCompletion(postCompletionModel);
            if (result.PostCompletionID == 0)
                return BadRequest(new { status = 400, message = "Oops Something Went Wrong!" });
            else
                return Ok(new { status = 200 });
        }



        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePostCompletion(int id)
        {
            var result = await _unitOfWorkService.postCompletionService.DeletePostCompletion(id);
            if (result == 0)
                return BadRequest(new { status = 400, message = "Oops Something Went Wrong!" });
            else
                return Ok(new { status = 200 });
        }


        #endregion


    }
}