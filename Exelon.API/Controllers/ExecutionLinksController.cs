using Exelon.Application.IServices;
using Exelon.Domain;
using Exelon.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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


        #region Linking Information

        [HttpGet]
        public async Task<ActionResult> GetAllExLinkInfo()
        {
            var result = await _unitOfWorkService.exLinkingInfoService.GetExLinkInfo();
            if (result.Count == 0)
                return NotFoundResult();
            else
                return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetExLinkInfo(int id)
        {
            var result = await _unitOfWorkService.exLinkingInfoService.GetExLinkInfo(id);
            if (result.Count == 0)
                return NotFoundResult();
            else
                return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> CreateExLinkInfo([FromBody] ExLinkingInfoModel linkingInfoModel)
        {
            linkingInfoModel.CreatedBy = "1";
            var result = await _unitOfWorkService.exLinkingInfoService.CreateExLinkInfo(linkingInfoModel);
            KeyValuePair<ExLinkingInfoModel, string> i = result.First();
            if (i.Value == "ok")
                return Ok(new { ID = linkingInfoModel.ExecutionLinkingID });
            else if (i.Value == "")
                return BadRequest(new { status = 400, message = "Oops Something Went Wrong!" });
            else
                return BadRequest(new { status = 400, message = i.Value });
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateExLinkInfo(int id, [FromBody] ExLinkingInfoModel linkingInfoModel)
        {
            linkingInfoModel.ExecutionLinkingID = id;
            linkingInfoModel.UpdatedBy = "1";
            var result = await _unitOfWorkService.exLinkingInfoService.UpdateExLinkInfo(linkingInfoModel);
            KeyValuePair<ExLinkingInfoModel, string> i = result.First();
            if (i.Value == "ok")
                return Ok(new { status = 200 });
            else if (i.Value == "")
                return BadRequest(new { status = 400, message = "Oops Something Went Wrong!" });
            else
                return BadRequest(new { status = 400, message = i.Value });
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteExLinkInfo(int id)
        {
            var result = await _unitOfWorkService.exLinkingInfoService.DeleteExLinkInfo(id);
            if (result == 1)
                return Ok(new { status = 200 });
            else
                return BadRequest(new { status = 400, message = "Oops Something Went Wrong!" });
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetProjectIdsByPDId(int id)
        {
            var result = await _unitOfWorkService.exLinkingInfoService.GetProjectIDsByPDId(id);
            if (result.Count == 0)
                return NotFoundResult();
            else
                return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetLinkInfoIdByProjectId(string id)
        {
            long linkInfoId = await _unitOfWorkService.exLinkingInfoService.GetLinkInfoIdByProjectId(id);
            if (linkInfoId == 0)
                return NotFoundResult();

            var result = await _unitOfWorkService.exLinkingInfoService.GetExLinkInfo((int)linkInfoId);
            return Ok(result);
        }
        #endregion

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

        #region ComEd/External

        [HttpGet]
        public async Task<ActionResult> GetComEd()
        {
            var result = await _unitOfWorkService.cOMEDEXService.GetComEd();
            if (result.Count == 0)
                return NotFoundResult();
            else
                return Ok(result);
        }

        [HttpGet("{comEdId}")]
        public async Task<ActionResult> GetComEd(int comEdId)
        {
            var result = await _unitOfWorkService.cOMEDEXService.GetComEd(comEdId);
            if (result.Count == 0)
                return NotFoundResult();
            else
                return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> CreateComEd([FromBody] COMEDEXModel model)
        {
            model.CreatedBy = "1";
            var result = await _unitOfWorkService.cOMEDEXService.CreateComEd(model);
            KeyValuePair<COMEDEXModel, string> i = result.First();
            if (i.Value == "ok")
                return Ok(new { ID = i.Key.ComEdId });
            else if (i.Value == "")
                return BadRequest(new { status = 400, message = "Oops Something Went Wrong!" });
            else
                return BadRequest(new { status = 400, message = i.Value });
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateComEd(int id, [FromBody] COMEDEXModel model)
        {
            model.UpdatedBy = "1";
            model.ComEdId = id;
            var result = await _unitOfWorkService.cOMEDEXService.UpdateComEd(model);
            if (result.ComEdId == 0)
                return BadRequest(new { status = 400, message = "Oops Something Went Wrong!" });
            else
                return Ok(new { status = 200 });
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteComEd(int id)
        {
            var result = await _unitOfWorkService.cOMEDEXService.DeleteComEd(id);
            if (result == 0)
                return BadRequest(new { status = 400, message = "Oops Something Went Wrong!" });
            else
                return Ok(new { status = 200 });
        }

        [HttpGet]
        public async Task<ActionResult> GetLnLForDropdown()
        {
            var result = await _unitOfWorkService.cOMEDEXService.GetLnL();
            if (result.Count == 0)
                return NotFoundResult();
            else
                return Ok(result);
        }
        [HttpGet("{linkingId}")]
        public async Task<ActionResult> GetComEdIdByLinkingId(int linkingId)
        {
            var comEdId = await _unitOfWorkService.cOMEDEXService.GetComEdIdByLinkingId(linkingId);
            if (comEdId == 0)
                return NotFoundResult();
            else
                return Ok(comEdId);
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

        #region [Execution Devices]
        #region [Get Execution Device]
        /// <summary>
        /// Get Execution Device
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult> GetExecutionDevice(int id)
        {
            var result = await _unitOfWorkService.deviceServices.GetExecutionDevice(id);
            if (result.ExecutionDeviceId == 0)
                return NotFoundResult();
            else
                return Ok(result);
        }
        #endregion

        #region [Save Execution Device]
        /// <summary>
        /// Save Execution Device
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> SaveExecutionDevice([FromBody] ExecutionDeviceModel model)
        {
            model.CreatedBy = "1";
            model.UpdatedBy = "1";
            var result = await _unitOfWorkService.deviceServices.SaveUpdateExecutionDevice(model);
            if (result.ExecutionDeviceId > 0)
                return Ok(new { ID = result.ExecutionDeviceId });
            else if (result.ExecutionDeviceId == 0)
                return BadRequest(new { status = (int)HttpStatusCode.BadRequest, message = "Oops Something Went Wrong!" });
            else
                return BadRequest(new { status = (int)HttpStatusCode.BadRequest, message = result.ExecutionDeviceId });
        }
        #endregion

        #region [Update Execution Device]
        /// <summary>
        /// Update Execution Device
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateExecutionDevice([FromBody] ExecutionDeviceModel model)
        {
            model.UpdatedBy = "1";
            var result = await _unitOfWorkService.deviceServices.SaveUpdateExecutionDevice(model);
            if (result.ExecutionDeviceId == 0)
                return BadRequest(new { status = 400, message = "Oops Something Went Wrong!" });
            else
                return Ok(new { status = 200 });
        }
        #endregion 
        #endregion

        #region [Completed Fiber Mile]

        #region [Get Completed Fiber Mile]
        /// <summary>
        /// Get Completed Fiber Mile
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult> GetCompletedFiberMile(int id)
        {
            var result = await _unitOfWorkService.fIBERService.GetCompletedFiberMileById(id);
            if (result.CompletedFiberMileId == 0)
                return NotFoundResult();
            else
                return Ok(result);
        }
        #endregion

        #region [Save Completed Fiber Mile]
        /// <summary>
        /// Save Completed Fiber Mile
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> SaveCompletedFiberMile([FromBody] ExecutionCompletedFiberMile model)
        {
            model.CreatedBy = "1";
            model.UpdatedBy = "1";
            var result = await _unitOfWorkService.fIBERService.SaveUpdateCompletedFiberMile(model);
            if (result.CompletedFiberMileId > 0)
                return Ok(new { ID = result.CompletedFiberMileId });
            else if (result.CompletedFiberMileId == 0)
                return BadRequest(new { status = (int)HttpStatusCode.BadRequest, message = "Oops Something Went Wrong!" });
            else
                return BadRequest(new { status = (int)HttpStatusCode.BadRequest, message = result.CompletedFiberMileId });
        }
        #endregion

        #region [Update Completed Fiber Mile]
        /// <summary>
        /// Update Completed Fiber Mile
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCompletedFiberMile([FromBody] ExecutionCompletedFiberMile model)
        {
            model.CreatedBy = "1";
            model.UpdatedBy = "1";
            var result = await _unitOfWorkService.fIBERService.SaveUpdateCompletedFiberMile(model);
            if (result.CompletedFiberMileId == 0)
                return BadRequest(new { status = 400, message = "Oops Something Went Wrong!" });
            else
                return Ok(new { status = 200 });
        }
        #endregion 
        #endregion

        #region [Completed Pole Mile]

        #region [Get Completed Pole Mile]
        /// <summary>
        /// Get Completed Pole Mile
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult> GetCompletedPoleMile(int id)
        {
            var result = await _unitOfWorkService.completedPoleMileService.GetCompletedPoleMileById(id);
            if (result.CompletedPoleMileId == 0)
                return NotFoundResult();
            else
                return Ok(result);
        }
        #endregion

        #region [Save Completed Pole Mile]
        /// <summary>
        /// Save Completed Pole Mile
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> SaveCompletedPoleMile([FromBody] CompletedPoleAndMile model)
        {
            model.CreatedBy = "1";
            model.UpdatedBy = "1";
            var result = await _unitOfWorkService.completedPoleMileService.SaveUpdateCompletedPoleMile(model);
            if (result.CompletedPoleMileId > 0)
                return Ok(new { ID = result.CompletedPoleMileId });
            else if (result.CompletedPoleMileId == 0)
                return BadRequest(new { status = (int)HttpStatusCode.BadRequest, message = "Oops Something Went Wrong!" });
            else
                return BadRequest(new { status = (int)HttpStatusCode.BadRequest, message = result.CompletedPoleMileId });
        }
        #endregion

        #region [Update Completed Fiber Mile]
        /// <summary>
        /// Update Completed Fiber Mile
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCompletedPoleMile([FromBody] CompletedPoleAndMile model)
        {
            model.CreatedBy = "1";
            model.UpdatedBy = "1";
            var result = await _unitOfWorkService.completedPoleMileService.SaveUpdateCompletedPoleMile(model);
            if (result.CompletedPoleMileId == 0)
                return BadRequest(new { status = 400, message = "Oops Something Went Wrong!" });
            else
                return Ok(new { status = 200 });
        }
        #endregion 
        #endregion
    }
}
