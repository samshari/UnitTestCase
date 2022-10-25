
using Exelon.Application.IServices;
using Exelon.Domain;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ExelonPOC.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ENGINEERINGController : ControllerBase
    {
        private readonly IUnitOfWorkService _unitOfWorkService;

        public ENGINEERINGController(IUnitOfWorkService unitOfWorkService)
        {
            _unitOfWorkService = unitOfWorkService;

        }


        public ActionResult NotFoundResult()
        {
            return NotFound(new { status = 404, message = "Not Exists!" });
        }



        #region Linking Information

        [HttpGet]
        public async Task<ActionResult> GetLinkInfo()
        {
            var result = await _unitOfWorkService.linkInfoService.GetLinkInfo();
            if (result.Count == 0)
                return NotFoundResult();
            else
                return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetLinkInfo(int id)
        {
            var result = await _unitOfWorkService.linkInfoService.GetLinkInfo(id);
            if (result.Count == 0)
                return NotFoundResult();
            else
                return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> CreateLinkInfo([FromBody] LinkingInfoModel linkingInfoModel)
        {
            linkingInfoModel.CreatedBy = "1";
            var result = await _unitOfWorkService.linkInfoService.CreateLinkInfo(linkingInfoModel);
            if (result.LinkingId == 0)
                return BadRequest(new { status = 400, message = "Oops Something Went Wrong!" });
            else
                return Ok(new { ID = result.LinkingId });
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateLinkInfo(int id, [FromBody] LinkingInfoModel linkingInfoModel)
        {
            linkingInfoModel.LinkingId = id;
            linkingInfoModel.UpdatedBy = "1";
            var result = await _unitOfWorkService.linkInfoService.UpdateLinkInfo(linkingInfoModel);
            if (result.LinkingId == 0)
                return BadRequest(new { status = 400, message = "Oops Something Went Wrong!" });
            else
                return Ok(new { status = 200 });
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteLinkInfo(int id)
        {
            var result = await _unitOfWorkService.linkInfoService.DeleteLinkInfo(id);
            if (result == 1)
                return Ok(new { status = 200 });
            else
                return BadRequest(new { status = 400, message = "Oops Something Went Wrong!" });
        }
        #endregion

        #region DesignMiles

        [HttpGet]
        public async Task<ActionResult> GetDESIGN()
        {
            var result = await _unitOfWorkService.dESIGNMILESService.GetDESIGN();
            if (result.Count == 0)
                return NotFoundResult();
            else
                return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetDESIGN(int id)
        {
            var result = await _unitOfWorkService.dESIGNMILESService.GetDESIGN(id);
            if (result.Count == 0)
                return NotFoundResult();
            else
                return Ok(result);
        }



        [HttpPost]
        public async Task<ActionResult> CreateDESIGN([FromBody] DesignMilesModel dESIGNMILESModel)
        {
            dESIGNMILESModel.CreatedBy = "1";
            var result = await _unitOfWorkService.dESIGNMILESService.CreateDESIGN(dESIGNMILESModel);
            KeyValuePair<DesignMilesModel, string> i = result.First();
            if (i.Value == "ok")
                return Ok(new { ID = dESIGNMILESModel.DesignMilesID });
            else if (i.Value == "")
                return BadRequest(new { status = 400, message = "Oops Something Went Wrong!" });
            else
                return BadRequest(new { status = 400, message = i.Value });
        }



        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateDESIGN(int id, [FromBody] DesignMilesModel dESIGNMILESModel)
        {
            dESIGNMILESModel.DesignMilesID = id;
            dESIGNMILESModel.UpdatedBy = "1";
            var result = await _unitOfWorkService.dESIGNMILESService.UpdateDESIGN(dESIGNMILESModel);
            if (result.DesignMilesID == 0)
                return BadRequest(new { status = 400, message = "Oops Something Went Wrong!" });
            else
                return Ok(new { status = 200 });
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteDESIGN(int id)
        {
            var result = await _unitOfWorkService.dESIGNMILESService.DeleteDESIGN(id);
            if (result == 0)
                return BadRequest(new { status = 400, message = "Oops Something Went Wrong!" });
            else
                return Ok(new { status = 200 });
        }

        #endregion

        #region Owner

        [HttpGet]
        public async Task<ActionResult> GetOWNER()
        {
            var result = await _unitOfWorkService.oWNERService.GetOWNER();
            if (result.Count == 0)
                return NotFoundResult();
            else
                return Ok(result);
        }



        [HttpGet("{id}")]
        public async Task<ActionResult> GetOWNER(int id)
        {
            var result = await _unitOfWorkService.oWNERService.GetOWNER(id);
            if (result.Count == 0)
                return NotFoundResult();
            else
                return Ok(result);
        }


        [HttpPost]
        public async Task<ActionResult> CreateOWNER([FromBody] OWNERSModel oWNERModel)
        {
            oWNERModel.CreatedBy = "1";
            var result = await _unitOfWorkService.oWNERService.CreateOWNER(oWNERModel);
            KeyValuePair<OWNERSModel, string> i = result.First();
            if (i.Value == "ok")
                return Ok(new { ID = i.Key.OwnerID });
            else if (i.Value == "")
                return BadRequest(new { status = 400, message = "Oops Something Went Wrong!" });
            else
                return BadRequest(new { status = 400, message = i.Value });

        }


        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateOWNER(int id, [FromBody] OWNERSModel oWNERModel)
        {
            oWNERModel.OwnerID = id;
            oWNERModel.UpdatedBy = "1";
            var result = await _unitOfWorkService.oWNERService.UpdateOWNER(oWNERModel);
            KeyValuePair<OWNERSModel, string> i = result.First();
            if (i.Value == "ok")
                return Ok(new { status = 200 });
            else if (i.Value == "")
                return BadRequest(new { status = 400, message = "Oops Something Went Wrong!" });
            else
                return BadRequest(new { status = 400, message = i.Value });
        }



        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteOWNER(int id)
        {
            var result = await _unitOfWorkService.oWNERService.DeleteOWNER(id);
            if (result == 0)
            {
                return BadRequest(new { status = 400, message = "Oops Something Went Wrong!" });
            }
            else
                return Ok(new { status = 200 });

        }


        #endregion

        #region Planned Pole Replacement

        [HttpGet]
        public async Task<ActionResult> GetPPREPLACE()
        {
            var result = await _unitOfWorkService.pPREPLACEMENTService.GetPPREPLACE();
            if (result.Count == 0)
                return NotFoundResult();
            else
                return Ok(result);

        }


        [HttpGet("{id}")]
        public async Task<ActionResult> GetPPREPLACE(int id)
        {
            var result = await _unitOfWorkService.pPREPLACEMENTService.GetPPREPLACE(id);
            if (result.Count == 0)
                return NotFoundResult();
            else
                return Ok(result);
        }


        [HttpPost]
        public async Task<ActionResult> CreatePPREPLACE([FromBody] PPREPLACEMENTModel pPREPLACEMENTModel)
        {
            pPREPLACEMENTModel.CreatedBy = "1";

            var result = await _unitOfWorkService.pPREPLACEMENTService.CreatePPREPLACE(pPREPLACEMENTModel);
            KeyValuePair<PPREPLACEMENTModel, string> i = result.First();
            if (i.Value == "ok")
                return Ok(new { ID = i.Key.PolesRepacementID });
            else if (i.Value == "")
                return BadRequest(new { status = 400, message = "Oops Something Went Wrong!" });
            else
                return BadRequest(new { status = 400, message = i.Value });
        }


        [HttpPut("{id}")]
        public async Task<ActionResult> UpdatePPREPLACE(int id, [FromBody] PPREPLACEMENTModel pPREPLACEMENTModel)
        {
            pPREPLACEMENTModel.PolesRepacementID = id;
            pPREPLACEMENTModel.UpdatedBy = "1";
            var result = await _unitOfWorkService.pPREPLACEMENTService.UpdatePPREPLACE(pPREPLACEMENTModel);
            if (result.PolesRepacementID == 0)
                return BadRequest(new { status = 400, message = "Oops Something Went Wrong!" });
            else
                return Ok(new { status = 200 });

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePPREPLACE(int id)
        {
            var result = await _unitOfWorkService.pPREPLACEMENTService.DeletePPREPLACE(id);
            if (result == 0)
                return BadRequest(new { status = 400, message = "Oops Something Went Wrong!" });
            else
                return Ok(new { status = 200 });
        }

        #endregion

        #region IfaReady 

        [HttpGet]
        public async Task<ActionResult> GetIFA()
        {
            var result = await _unitOfWorkService.iFAREADYService.GetIFA();
            if (result.Count == 0)
                return NotFoundResult();
            else
                return Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult> GetIFA(int id)
        {
            var result = await _unitOfWorkService.iFAREADYService.GetIFA(id);
            if (result.Count == 0)
                return NotFoundResult();
            else
                return Ok(result);
        }


        [HttpPost]
        public async Task<ActionResult> CreateIFA([FromBody] IfaReadyModel iFAREADYModel)
        {
            iFAREADYModel.CreatedBy = "1";
            var result = await _unitOfWorkService.iFAREADYService.CreateIFA(iFAREADYModel);
            KeyValuePair<IfaReadyModel, string> i = result.First();
            if (i.Value == "ok")
                return Ok(new { ID = i.Key.IFAMakeReadyID });
            else if (i.Value == "")
                return BadRequest(new { status = 400, message = "Oops Something Went Wrong!" });
            else
                return BadRequest(new { status = 400, message = i.Value });
        }


        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateIFA(int id, [FromBody] IfaReadyModel iFAREADYModel)
        {
            iFAREADYModel.IFAMakeReadyID = id;
            iFAREADYModel.UpdatedBy = "1";
            var result = await _unitOfWorkService.iFAREADYService.UpdateIFA(iFAREADYModel);
            if (result.IFAMakeReadyID == 0)
                return BadRequest(new { status = 400, message = "Oops Something Went Wrong!" });
            else
                return Ok(new { status = 200 });

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteIFA(int id)
        {
            var result = await _unitOfWorkService.iFAREADYService.DeleteIFA(id);
            if (result == 0)
                return BadRequest(new { status = 400, message = "Oops Something Went Wrong!" });
            else
                return Ok(new { status = 200 });
        }

        #endregion

        #region IFC Make Ready 

        [HttpGet]
        public async Task<ActionResult> GetIFC()
        {
            var result = await _unitOfWorkService.iFCREADYService.GetIFC();
            if (result.Count == 0)
                return NotFoundResult();
            else
                return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetIFC(int id)
        {
            var result = await _unitOfWorkService.iFCREADYService.GetIFC(id);
            if (result.Count == 0)
                return NotFoundResult();
            else
                return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> CreateIFC([FromBody] IfcReadyModel iFCREADYModel)
        {
            iFCREADYModel.CreatedBy = "1";
            var result = await _unitOfWorkService.iFCREADYService.CreateIFC(iFCREADYModel);
            KeyValuePair<IfcReadyModel, string> i = result.First();
            if (i.Value == "ok")
                return Ok(new { ID = i.Key.IFCMakeReadyID });
            else if (i.Value == "")
                return BadRequest(new { status = 400, message = "Oops Something Went Wrong!" });
            else
                return BadRequest(new { status = 400, message = i.Value });
        }


        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateIFC(int id, [FromBody] IfcReadyModel iFCREADYModel)
        {
            iFCREADYModel.IFCMakeReadyID = id;
            iFCREADYModel.UpdatedBy = "1";
            var result = await _unitOfWorkService.iFCREADYService.UpdateIFC(iFCREADYModel);
            if (result.IFCMakeReadyID == 0)
                return BadRequest(new { status = 400, message = "Oops Something Went Wrong!" });
            else
                return Ok(new { status = 200 });
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteIFC(int id)
        {
            var result = await _unitOfWorkService.iFCREADYService.DeleteIFC(id);
            if (result == 0)
                return BadRequest(new { status = 400, message = "Oops Something Went Wrong!" });
            else
                return Ok(new { status = 200 });
        }

        #endregion

        #region Device
        /// <summary>
        /// Devices APIs
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> GetDevice()
        {
            var result = await _unitOfWorkService.deviceServices.GetDevice();
            if (result.Count == 0)
                return NotFoundResult();
            else
                return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetDevice(int id)
        {
            var result = await _unitOfWorkService.deviceServices.GetDevice(id);
            if (result.Count == 0)
                return NotFoundResult();
            else
                return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> CreateDevice([FromBody] DeviceModel model)
        {
            model.CreatedBy = "1";
            var result = await _unitOfWorkService.deviceServices.CreateDevice(model);
            KeyValuePair<DeviceModel, string> i = result.First();
            if (i.Value == "ok")
                return Ok(new { ID = model.DeviceId });
            else if (i.Value == "")
                return BadRequest(new { status = (int)HttpStatusCode.BadRequest, message = "Oops Something Went Wrong!" });
            else
                return BadRequest(new { status = (int)HttpStatusCode.BadRequest, message = i.Value });
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateDevice(int id, [FromBody] DeviceModel deviceModel)
        {
            deviceModel.DeviceId = id;
            deviceModel.UpdatedBy = "1";
            var result = await _unitOfWorkService.deviceServices.UpdateDevice(deviceModel);
            if (result.DeviceId == 0)
                return BadRequest(new { status = (int)HttpStatusCode.BadRequest, message = "Oops Something Went Wrong!" });
            else
                return Ok(new { status = (int)HttpStatusCode.OK });
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteDevice(int id)
        {
            var result = await _unitOfWorkService.deviceServices.DeleteDevice(id);
            if (result == 0)
                return BadRequest(new { status = (int)HttpStatusCode.BadRequest, message = "Oops Something Went Wrong!" });
            else
                return Ok(new { status = (int)HttpStatusCode.OK });
        }
        #endregion

        #region PD
        /// <summary>
        /// Project Development APIs
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> GetPD()
        {
            var result = await _unitOfWorkService.pDService.GetPD();
            if (result.Count == 0)
                return NotFoundResult();
            else
                return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetPD(int id)
        {
            var result = await _unitOfWorkService.pDService.GetPD(id);
            if (result.Count == 0)
                return NotFoundResult();
            else
                return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> CreatePD([FromBody] PdModel pDModel)
        {
            pDModel.CreatedBy = "1";
            var result = await _unitOfWorkService.pDService.CreatePD(pDModel);
            if (result.PDID == 0)
                return BadRequest(new { status = 400, message = "Oops Something Went Wrong!" });
            else
                return Ok(new { ID = pDModel.PDID });
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdatePD(int id, [FromBody] PdModel pDModel)
        {
            pDModel.PDID = id;
            pDModel.UpdatedBy = "1";
            var result = await _unitOfWorkService.pDService.UpdatePD(pDModel);
            if (result.PDID == 0)
                return BadRequest(new { status = 400, message = "Oops Something Went Wrong!" });
            else
                return Ok(new { status = 200 });
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePD(int id)
        {
            var result = await _unitOfWorkService.pDService.DeletePD(id);
            if (result == 0)
                return BadRequest(new { status = 400, message = "Oops Something Went Wrong!" });
            else
                return Ok(new { status = 200 });
        }


        #endregion

        #region IFA Fiber
        /// <summary>
        /// IFA Fiber APIs
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> GetIFAFIBER()
        {
            var result = await _unitOfWorkService.ifaFiberService.GetIFAFIBER();
            if (result.Count == 0)
                return NotFoundResult();
            else
                return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetIFAFiber(int id)
        {
            var result = await _unitOfWorkService.ifaFiberService.GetIFAFIBER(id);
            if (result.Count == 0)
                return NotFoundResult();
            else
                return NotFound(result);
        }
        [HttpPost]
        public async Task<ActionResult> CreateIFAFiber([FromBody] IfaFiberModel ifaFiberModel)
        {
            ifaFiberModel.CreatedBy = "1";
            var result = await _unitOfWorkService.ifaFiberService.CreateIFAFIBER(ifaFiberModel);
            KeyValuePair<IfaFiberModel, string> i = result.First();
            if (i.Value == "ok")
                return Ok(new { ID = i.Key.IFAFiberID });
            else if (i.Value == "")
                return BadRequest(new { status = 400, message = "Oops Something Went Wrong!" });
            else
                return BadRequest(new { status = 400, message = i.Value });
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateIFAFiber(int id, [FromBody] IfaFiberModel ifaFiberModel)
        {
            ifaFiberModel.IFAFiberID = id;
            ifaFiberModel.UpdatedBy = "1";
            var result = await _unitOfWorkService.ifaFiberService.UpdateIFAFIBER(ifaFiberModel);
            if (result.IFAFiberID == 0)
                return BadRequest(new { status = 400, message = "Oops Something Went Wrong!" });
            else
                return Ok(new { status = 200 });
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteIFAFiber(int id)
        {
            var result = await _unitOfWorkService.ifaFiberService.DeleteIFAFIBER(id);
            if (result == 0)
                return BadRequest(new { status = 400, message = "Oops Something Went Wrong!" });
            else
                return Ok(new { status = 200 });
        }
        #endregion

        #region IFC Fiber
        /// <summary>
        /// IFC Fiber APIs
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> GetIFCFiber()
        {
            var result = await _unitOfWorkService.ifcFiberService.GetIFCFIBER();
            if (result.Count == 0)
                return NotFoundResult();
            else
                return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetIFCFiber(int id)
        {
            var result = await _unitOfWorkService.ifcFiberService.GetIFCFIBER(id);
            if (result.Count == 0)
                return NotFoundResult();
            else
                return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> CreateIFCFiber([FromBody] IfcFiberModel ifcFiberModel)
        {
            ifcFiberModel.CreatedBy = "1";
            var result = await _unitOfWorkService.ifcFiberService.CreateIFCFIBER(ifcFiberModel);
            KeyValuePair<IfcFiberModel, string> i = result.First();
            if (i.Value == "ok")
                return Ok(new { ID = i.Key.IFCFiberID });
            else if (i.Value == "")
                return BadRequest(new { status = 400, message = "Oops Something Went Wrong!" });
            else
                return BadRequest(new { status = 400, message = i.Value });
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateIFCFiber(int id, [FromBody] IfcFiberModel ifcFiberModel)
        {
            ifcFiberModel.IFCFiberID = id;
            ifcFiberModel.UpdatedBy = "1";
            var result = await _unitOfWorkService.ifcFiberService.UpdateIFCFIBER(ifcFiberModel);
            if (result.IFCFiberID == 0)
                return BadRequest(new { status = 400, message = "Oops Something Went Wrong!" });
            else
                return Ok(new { status = 200 });
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteIFCFiber(int id)
        {
            var result = await _unitOfWorkService.ifcFiberService.DeleteIFCFIBER(id);
            if (result == 0)
                return BadRequest(new { status = 400, message = "Oops Something Went Wrong!" });
            else
                return Ok(new { status = 200 });
        }
        #endregion

        [HttpGet("{id}")]
        public async Task<ActionResult> GetPrimaryKeysByPDId(int id)
        {
            var result = await _unitOfWorkService.linkInfoService.GetPrimayKeysByPDId(id);
            if (result.Count == 0)
                return NotFoundResult();
            else
                return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetDetailsByLinkId(string id)
        {
            long linkInfoId = await _unitOfWorkService.linkInfoService.GetLinkInfoIdByPrimayKey(id);
            if (linkInfoId == 0)
                return NotFoundResult();

            var result = await _unitOfWorkService.linkInfoService.GetLinkInfo((int)linkInfoId);
            return Ok(result);
        }
    }
}
