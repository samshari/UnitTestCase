using Exelon.Application.IServices;
using Exelon.Domain;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exelon.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CommonController : ControllerBase
    {

        private readonly IUnitOfWorkService _unitOfWorkService;


        public CommonController(IUnitOfWorkService unitOfWorkService)
        {
            _unitOfWorkService = unitOfWorkService;

        }



        //NotFound Method
        public ActionResult NotFoundResult()
        {
            return NotFound(new { status = 404, message = "Not Exists!" });
        }


        #region SIZE

        [HttpGet]
        public async Task<ActionResult> GetMSIZE()
        {
            var result = await _unitOfWorkService.mSIZEService.GetMSIZE();
            if (result.Count == 0)
                return NotFoundResult();
            else
                return Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult> GetMSIZE(int id)
        {
            var result = await _unitOfWorkService.mSIZEService.GetMSIZE(id);
            if (result.Count == 0)
                return NotFoundResult();
            else
                return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> CreateMSIZE([FromBody] MSIZEModel mSIZEModel)
        {
            mSIZEModel.CreatedBy = "1";
            var result = await _unitOfWorkService.mSIZEService.CreateMSIZE(mSIZEModel);
            KeyValuePair<MSIZEModel, string> i = result.First();
            if (i.Value == "ok")
                return Ok(new { status = 200 });
            else if (i.Value == "")
                return BadRequest(new { status = 400, message = "Oops Something Went Wrong!" });
            else
                return BadRequest(new { status = 400, message = i.Value });

        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateMSIZE(int id, [FromBody] MSIZEModel mSIZEModel)
        {
            mSIZEModel.ID = id;
            mSIZEModel.UpdatedBy = "1";
            var result = await _unitOfWorkService.mSIZEService.UpdateMSIZE(mSIZEModel);
            KeyValuePair<MSIZEModel, string> i = result.First();
            if (i.Value == "ok")
                return Ok(new { ID = i.Key.ID });
            else if (i.Value == "")
                return BadRequest(new { status = 400, message = "Oops Something Went Wrong!" });
            else
                return BadRequest(new { status = 400, message = i.Value });
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteMSIZE(int id)
        {
            var result = await _unitOfWorkService.mSIZEService.DeleteMSIZE(id);
            if (result == 0)
                return BadRequest(new { status = 400, message = "Oops Something Went Wrong!" });
            else
                return Ok(new { status = 200 });
        }


        #endregion 

        #region BARN

        [HttpGet]
        public async Task<ActionResult> GetAllBarn()
        {
            var result = await _unitOfWorkService.mBarnService.GetBarn();
            if (result.Count == 0)
                return NotFoundResult();
            else
                return Ok(result);

        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetBarnById(int id)
        {
            var result = await _unitOfWorkService.mBarnService.GetBarn(id);
            if (result.Count == 0)
                return NotFoundResult();
            else
                return Ok(result);

        }

        [HttpPost]
        public async Task<ActionResult> CreateMBARN([FromBody] MBARNModel mBARNModel)
        {
            mBARNModel.CreatedBy = "1";
            var result = await _unitOfWorkService.mBarnService.CreateBarn(mBARNModel);
            KeyValuePair<MBARNModel, string> i = result.First();
            if (i.Value == "ok")
                return Ok(new { ID = i.Key.BarnID });
            else if (i.Value == "")
                return BadRequest(new { status = 400, message = "Oops Something Went Wrong!" });
            else
                return BadRequest(new { status = 400, message = i.Value });
        }


        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateMBARN(int id, [FromBody] MBARNModel mBARNModel)
        {
            mBARNModel.BarnID = id;
            mBARNModel.UpdatedBy = "1";
            var result = await _unitOfWorkService.mBarnService.UpdateBarn(mBARNModel);
            KeyValuePair<MBARNModel, string> i = result.First();
            if (i.Value == "ok")
                return Ok(new { status = 200 });
            else if (i.Value == "")
                return BadRequest(new { status = 400, message = "Oops Something Went Wrong!" });
            else
                return BadRequest(new { status = 400, message = i.Value });
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteMBARN(int id)
        {
            var result = await _unitOfWorkService.mBarnService.DeleteBarn(id);
            if (result == 1)
                return Ok(new { status = 200 });
            else
                return BadRequest(new { status = 400, message = "Oops Something Went Wrong!" });
        }

        #endregion

        #region REGION

        [HttpGet]
        public async Task<ActionResult> GetMREGION()
        {
            var result = await _unitOfWorkService.mREGIONService.GetMREGION();
            if (result.Count == 0)
                return NotFoundResult();
            else
                return Ok(result);
        }



        [HttpGet("{id}")]
        public async Task<ActionResult> GetMREGION(int id)
        {
            var result = await _unitOfWorkService.mREGIONService.GetMREGION(id);
            if (result.Count == 0)
                return NotFoundResult();
            else
                return Ok(result);
        }


        [HttpPost]
        public async Task<ActionResult> CreateMREGION([FromBody] MREGIONModel mREGIONModel)
        {

            mREGIONModel.CreatedBy = "1";
            var result = await _unitOfWorkService.mREGIONService.CreateMREGION(mREGIONModel);

            KeyValuePair<MREGIONModel, string> i = result.First();
            if (i.Value == "ok")
                return Ok(new { ID = i.Key.RegionID });
            else if (i.Value == "")
                return BadRequest(new { status = 400, message = "Oops Something Went Wrong!" });
            else
                return NotFound(new { status = 404, message = i.Value });
        }



        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateMREGION(int id, [FromBody] MREGIONModel mREGIONModel)
        {
            mREGIONModel.RegionID = id;
            mREGIONModel.UpdatedBy = "1";
            var result = await _unitOfWorkService.mREGIONService.UpdateMREGION(mREGIONModel);
            KeyValuePair<MREGIONModel, string> i = result.First();
            if (i.Value == "ok")
                return Ok(new { status = 200 });
            else if (i.Value == "")
                return BadRequest(new { status = 400, message = "Oops Something Went Wrong!" });
            else
                return BadRequest(new { status = 400, message = i.Value });
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteMREGION(int id)
        {

            var result = await _unitOfWorkService.mREGIONService.DeleteMREGION(id);
            if (result == 0)
                return BadRequest(new { status = 400, message = "Oops Something Went Wrong!" });
            else
                return Ok(new { status = 200 });
        }



        #endregion

        #region COC

        [HttpGet]
        public async Task<ActionResult> GetMCOC()
        {
            var result = await _unitOfWorkService.mCOSService.GetMCOC();
            if (result.Count == 0)
                return NotFoundResult();
            else
                return Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult> GetMCOC(int id)
        {
            var result = await _unitOfWorkService.mCOSService.GetMCOC(id);
            if (result.Count == 0)
                return NotFoundResult();
            else
                return Ok(result);
        }


        [HttpPost]
        public async Task<ActionResult> CreateMCOC([FromBody] MCOCModel mCOCModel)
        {

            mCOCModel.CreatedBy = "1";
            var result = await _unitOfWorkService.mCOSService.CreateMCOC(mCOCModel);
            KeyValuePair<MCOCModel, string> i = result.First();
            if (i.Value == "ok")
                return Ok(new { ID = i.Key.ID });
            else if (i.Value == "")
                return BadRequest(new { status = 400, message = "Oops Something Went Wrong!" });
            else
                return BadRequest(new { status = 400, message = i.Value });
        }




        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateMCOC(int id, [FromBody] MCOCModel mCOCModel)
        {
            mCOCModel.ID = id;
            mCOCModel.UpdatedBy = "1";
            var result = await _unitOfWorkService.mCOSService.UpdateMCOC(mCOCModel);
            KeyValuePair<MCOCModel, string> i = result.First();
            if (i.Value == "ok")
                return Ok(new { status = 200 });
            else if (i.Value == "")
                return BadRequest(new { status = 400, message = "Oops Something Went Wrong!" });
            else
                return BadRequest(new { status = 400, message = i.Value });

        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteMCOC(int id)
        {

            var result = await _unitOfWorkService.mCOSService.DeleteMCOC(id);

            if (result == 0)
                return BadRequest(new { status = 400, message = "Oops Something Went Wrong!" });
            else
                return Ok(new { status = 200 });
        }

        #endregion

        #region EOC 


        [HttpGet]
        public async Task<ActionResult> GetEOC()
        {

            var result = await _unitOfWorkService.mEOCService.GetMEOC();
            if (result.Count == 0)
                return NotFoundResult();
            else
                return Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult> GetMEOC(int id)
        {
            var result = await _unitOfWorkService.mEOCService.GetMEOC(id);
            if (result.Count == 0)
                return NotFoundResult();
            else
                return Ok(result);
        }



        [HttpPost]
        public async Task<ActionResult> CreateMEOC([FromBody] MEOCModel meocModel)
        {

            meocModel.CreatedBy = "1";
            var result = await _unitOfWorkService.mEOCService.CreateMEOC(meocModel);
            KeyValuePair<MEOCModel, string> i = result.First();
            if (i.Value == "ok")
                return Ok(new { ID = i.Key.ID });
            else if (i.Value == "")
                return BadRequest(new { status = 400, message = "Oops Something Went Wrong!" });
            else
                return BadRequest(new { status = 400, message = i.Value });
        }


        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateMEOC(int id, [FromBody] MEOCModel meocModel)
        {
            meocModel.ID = id;
            meocModel.UpdatedBy = "1";
            var result = await _unitOfWorkService.mEOCService.UpdateMEOC(meocModel);
            KeyValuePair<MEOCModel, string> i = result.First();
            if (i.Value == "ok")
                return Ok(new { status = 200 });
            else if (i.Value == "")
                return BadRequest(new { status = 400, message = "Oops Something Went Wrong!" });
            else
                return BadRequest(new { status = 400, message = i.Value });
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteMEOC(int id)
        {

            var result = await _unitOfWorkService.mEOCService.DeleteMEOC(id);
            if (result == 0)
                return BadRequest(new { status = 400, message = "Oops Something Went Wrong!" });
            else
                return Ok(new { status = 200 });
        }

        #endregion

        #region Project Status

        [HttpGet]
        public async Task<ActionResult> GETMPROJECTSTATUS()
        {
            var result = await _unitOfWorkService.mProjectStatusService.GETMPROJECTSTATUS();
            if (result.Count == 0)
                return NotFoundResult();
            else
                return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GETMPROJECTSTATUS(int id)
        {
            var result = await _unitOfWorkService.mProjectStatusService.GETMPROJECTSTATUS(id);
            if (result.Count == 0)
                return NotFoundResult();
            else
                return Ok(result);
        }

        #endregion

        #region TECHNOLOGY

        [HttpGet]
        public async Task<ActionResult> GetMTECH()
        {
            var result = await _unitOfWorkService.mTECHService.GetMTECH();
            if (result.Count == 0)
                return NotFoundResult();
            else
                return Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult> GetMTECH(int id)
        {
            var result = await _unitOfWorkService.mTECHService.GetMTECH(id);
            if (result.Count == 0)
                return NotFoundResult();
            else
                return Ok(result);
        }

        #endregion

        #region Real Estate Support EOC

        [HttpGet]
        public async Task<ActionResult> GetMEOCREALSTATE()
        {
            var result = await _unitOfWorkService.mEOCREALSTATEService.GetMEOCREALSTATE();


            if (result.Count == 0)
                return NotFoundResult();
            else
                return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetMEOCREALSTATE(int id)
        {
            var result = await _unitOfWorkService.mEOCREALSTATEService.GetMEOCREALSTATE(id);
            if (result.Count == 0)
                return NotFoundResult();
            else
                return Ok(result);

        }


        [HttpPost]
        public async Task<ActionResult> CreateMEOCREALSTATE([FromBody] MEOCREALSTATEModel mEOCREALSTATEModel)
        {

            mEOCREALSTATEModel.CreatedBy = "1";
            var result = await _unitOfWorkService.mEOCREALSTATEService.CreateMEOCREALSTATE(mEOCREALSTATEModel);
            KeyValuePair<MEOCREALSTATEModel, string> i = result.First();
            if (i.Value == "ok")
                return Ok(new { ID = i.Key.EOCRealEstateID });
            else if (i.Value == "")
                return BadRequest(new { status = 400, message = "Oops Something Went Wrong!" });
            else
                return BadRequest(new { status = 400, message = i.Value });
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateMEOCREALSTATE(int id, [FromBody] MEOCREALSTATEModel mEOCREALSTATEModel)
        {
            mEOCREALSTATEModel.EOCRealEstateID = id;
            mEOCREALSTATEModel.UpdatedBy = "1";
            var result = await _unitOfWorkService.mEOCREALSTATEService.UpdateMEOCREALSTATE(mEOCREALSTATEModel);
            KeyValuePair<MEOCREALSTATEModel, string> i = result.First();
            if (i.Value == "ok")
                return Ok(new { status = 200 });
            else if (i.Value == "")
                return BadRequest(new { status = 400, message = "Oops Something Went Wrong!" });
            else
                return BadRequest(new { status = 400, message = i.Value });
           
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteMEOCREALSTATE(int id)
        {

            var result = await _unitOfWorkService.mEOCREALSTATEService.DeleteMEOCREALSTATE(id);
            if (result == 1)
                return BadRequest(new { status = 400, message = "Oops Something Went Wrong!" });
            else
                return Ok(new { status = 404 });
        }


        #endregion

        #region Project Manager

        [HttpGet]
        public async Task<ActionResult> GetMPM()
        {
            var result = await _unitOfWorkService.mPMService.GetMPM();
            if (result.Count == 0)
                return NotFoundResult();
            else
                return Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult> GetMPM(int id)
        {
            var result = await _unitOfWorkService.mPMService.GetMPM(id);
            if (result.Count == 0)
                return NotFoundResult();
            else
                return Ok(result);

        }


        [HttpPost]
        public async Task<ActionResult> CreateMPM([FromBody] MPMModel mpmModel)
        {

            mpmModel.CreatedBy = "1";
            var result = await _unitOfWorkService.mPMService.CreateMPM(mpmModel);
            KeyValuePair<MPMModel, string> i = result.First();
            if (i.Value == "ok")
                return Ok(new { ID = i.Key.PMID });
            else if (i.Value == "")
                return BadRequest(new { status = 400, message = "Oops Something Went Wrong!" });
            else
                return BadRequest(new { status = 400, message = i.Value });
            
        }



        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateMPM(int id, [FromBody] MPMModel mpmModel)
        {
            mpmModel.PMID = id;
            mpmModel.UpdatedBy = "1";
            var result = await _unitOfWorkService.mPMService.UpdateMPM(mpmModel);
            KeyValuePair<MPMModel, string> i = result.First();
            if (i.Value == "ok")
                return Ok(new { status = 200 });
            else if (i.Value == "")
                return BadRequest(new { status = 400, message = "Oops Something Went Wrong!" });
            else
                return BadRequest(new { status = 400, message = i.Value });
        }



        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteMPM(int id)
        {

            var result = await _unitOfWorkService.mPMService.DeleteMPM(id);
            if (result == 0)
                return BadRequest(new { status = 400, message = "Oops Something Went Wrong!" });
            else
                return Ok(new { status = 200 });

        }

        #endregion

        #region COC BID FIBER

        [HttpGet]
        public async Task<ActionResult> GetMCOCBIDFIBER()
        {
            var result = await _unitOfWorkService.mCOCBIDFIBERService.GetMCOCBID();
            if (result.Count == 0)
                return NotFoundResult();
            else
                return Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult> GetMCOCBIDFIBER(int id)
        {
            var result = await _unitOfWorkService.mCOCBIDFIBERService.GetMCOCBID(id);
            if (result.Count == 0)
                return NotFoundResult();
            else
                return Ok(result);
        }

        #endregion

        #region React LRE


        [HttpGet]
        public async Task<ActionResult> GetMREACT()
        {
            var result = await _unitOfWorkService.mREACTLREService.GetMREACT();
            if (result.Count == 0)
                return NotFoundResult();
            else
                return Ok(result);

        }


        [HttpGet("{id}")]
        public async Task<ActionResult> GetMREACT(int id)
        {
            var result = await _unitOfWorkService.mREACTLREService.GetMREACT(id);
            if (result.Count == 0)
                return NotFoundResult();
            else
                return Ok(result);
        }

        #endregion

        #region UcomSPoc

        [HttpGet]
        public async Task<ActionResult> GetMUCO()
        {
            var result = await _unitOfWorkService.mUCOSPOCService.GetMUCO();
            if (result.Count == 0)
                return NotFoundResult();
            else
                return Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult> GetMUCO(int id)
        {
            var result = await _unitOfWorkService.mUCOSPOCService.GetMUCO(id);
            if (result.Count == 0)
                return NotFoundResult();
            else
                return Ok(result);
        }

        #endregion

        #region INNERDUCTCOC


        [HttpGet]

        public async Task<ActionResult> GetINNERDUCT()
        {
            var result = await _unitOfWorkService.mINNERDUCTCOCService.GetINNERDUCT();
            if (result.Count == 0)
                return NotFoundResult();
            else
                return Ok(result);
        }

        [HttpGet("{id}")]

        public async Task<ActionResult> GetINNERDUCT(int id)
        {
            var result = await _unitOfWorkService.mINNERDUCTCOCService.GetINNERDUCT(id);
            if (result.Count == 0)
                return NotFoundResult();
            else
                return Ok(result);
        }

        #endregion

        #region StepMaster

        [HttpGet("{id}")]

        public async Task<ActionResult> GetSTEPBYID(int id)
        {
            var result = await _unitOfWorkService.mSTEPMASTERService.GetSTEPBYID(id);
            if (result.result == null)
                return NotFoundResult();
            else
                return Ok(result);
        }

        #endregion

        #region  EnvironmentalCOC

        [HttpGet]
        public async Task<ActionResult> GetMENVCOC()
        {
            var result = await _unitOfWorkService.mENVCOCService.GetMENVCOC();
            if (result.Count == 0)
                return NotFoundResult();
            else
                return Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult> GetMENVCOC(int id)
        {
            var result = await _unitOfWorkService.mENVCOCService.GetMENVCOC(id);
            if (result.Count == 0)
                return NotFoundResult();
            else
                return Ok(result);
        }

        #endregion

        #region RealSupportEoc
        [HttpGet]
        public async Task<ActionResult> GetMREALEOC()
        {
            var result = await _unitOfWorkService.mREALSUPEOCService.GetMREALEOC();
            if (result.Count == 0)
                return NotFoundResult();
            else
                return Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult> GetMREALEOC(int id)
        {
            var result = await _unitOfWorkService.mREALSUPEOCService.GetMREALEOC(id);
            if (result.Count == 0)
                return NotFoundResult();
            else
                return Ok(result);
        }

        #endregion

        #region COC Make Ready


        [HttpGet]
        public async Task<ActionResult> GetMCOCMK()
        {
            var result = await _unitOfWorkService.mCOCMKREADYService.GetMCOCMK();
            if (result.Count == 0)
                return NotFoundResult();
            else
                return Ok(result);
        }

        [HttpGet("{id}")]

        public async Task<ActionResult> GetMCOCMK(int id)
        {
            var result = await _unitOfWorkService.mCOCMKREADYService.GetMCOCMK(id);
            if (result.Count == 0)
                return NotFoundResult();
            else
                return Ok(result);
        }

        #endregion    

        #region MattingPreConstructionRequired

        [HttpGet("{id}")]
        public async Task<ActionResult> GetMattingPreConstructionRequired(int id)
        {
            var result = await _unitOfWorkService.mattingPreConstructionRequiredService.GetMattingPreConstructionRequired(id);
            if (result.Result == null)
                return NotFoundResult();
            else
                return Ok(result);
        }

        #endregion

        #region LNL

        [HttpGet("{id}")]

        public async Task<ActionResult> GetLNL(int id)
        {
            var result = await _unitOfWorkService.lNLService.GetLNL(id);
            if (result.Result == null)
                return NotFoundResult();
            else
                return Ok(result);
        }

        #endregion

        #region PreConstructionRequired

        [HttpGet("{id}")]

        public async Task<ActionResult> GetPreConstructionRequired(int id)
        {
            var result = await _unitOfWorkService.vEGPreConstructionRequiredService.GetPreConstructionRequired(id);
            if (result.Result == null)
                return NotFoundResult();
            else
                return Ok(result);
        }

        #endregion

        #region StakingConstructionRequired

        [HttpGet("{id}")]

        public async Task<ActionResult> GetStakingConstructionRequired(int id)
        {
            var result = await _unitOfWorkService.sTAKINGPreConstructionRequiredService.GetStakingConstructionRequired(id);
            if (result.Result == null)
                return NotFoundResult();
            else
                return Ok(result);
        }
        #endregion

        #region General

        [HttpGet("{id}")]
        public async Task<ActionResult> GetGENERAL(int id)
        {
            var result = await _unitOfWorkService.gENERALService.GetGENERAL(id);
            if (result.Result == null)
                return NotFoundResult();
            else
                return Ok(result);
        }

        #endregion

        #region Huts

        [HttpGet("{id}")]
        public async Task<ActionResult> GetHUTS(int id)
        {
            var result = await _unitOfWorkService.hUTREEFService.GetHUTS(id);
            if (result.Result == null)
                return NotFoundResult();
            else
                return Ok(result);
        }

        #endregion

        #region Huts Owner


        [HttpGet("{id}")]
        public async Task<ActionResult> GetHUTSOWNER(int id)
        {
            var result = await _unitOfWorkService.hUTSOWNERService.GetHUTSOWNER(id);
            if (result.Result == null)
                return NotFoundResult();
            else
                return Ok(result);
        }

        #endregion

        #region HutsComplete

        [HttpGet("{id}")]
        public async Task<ActionResult> GetHUTSCOM(int id)
        {
            var result = await _unitOfWorkService.hUTSCOMPSTATUSService.GetHUTSCOM(id);
            if (result.Result == null)
                return NotFoundResult();
            else
                return Ok(result);
        }

        #endregion

        #region Huts Enviornment

        [HttpGet("{id}")]
        public async Task<ActionResult> GetHUTSENV(int id)
        {
            var result = await _unitOfWorkService.hUTSENVDUEService.GetHUTSENV(id);
            if (result.Result == null)
                return NotFoundResult();
            else
                return Ok(result);
        }

        #endregion

        #region Huts Transmit

        [HttpGet("{id}")]

        public async Task<ActionResult> GetHUTSTRANS(int id)
        {
            var result = await _unitOfWorkService.hUTSTRANSPERMITService.GetHUTSTRANS(id);
            if (result.Result == null)
                return NotFoundResult();
            else
                return Ok(result);
        }

        #endregion

        #region COCMaster
        [HttpGet]
        public async Task<ActionResult> GetCOCMaster()
        {
            var result = await _unitOfWorkService.mCOCMASTERService.GetCOC();
            if (result.Count == 0)
                return NotFoundResult();
            else
                return Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult> GetCOCMaster(int id)
        {
            var result = await _unitOfWorkService.mCOCMASTERService.GetCOC(id);
            if (result.Count == 0)
                return NotFoundResult();
            else
                return Ok(result);
        }


        [HttpPost]
        public async Task<ActionResult> CreateCOCMaster([FromBody] MCOCMASTERModel mCOCMASTERModel)
        {
            mCOCMASTERModel.CreatedBy = "1";
            var result = await _unitOfWorkService.mCOCMASTERService.CreateCOC(mCOCMASTERModel);
            KeyValuePair<MCOCMASTERModel, string> i = result.First();
            if (i.Value == "ok")
                return Ok(new { ID = i.Key.COCID });
            else if (i.Value == "")
                return BadRequest(new { status = 400, message = "Oops Something Went Wrong!" });
            else
                return BadRequest(new { status = 400, message = i.Value });
            

        }


        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCOCMaster(int id, [FromBody] MCOCMASTERModel mCOCMASTERModel)
        {
            mCOCMASTERModel.COCID = id;
            mCOCMASTERModel.UpdatedBy = "1";
            var result = await _unitOfWorkService.mCOCMASTERService.UpdateCOC(mCOCMASTERModel);
            if (result.COCID == 0)
                return BadRequest(new { status = 400, message = "Oops Something Went Wrong!" });
            else
                return Ok(new { status = 200 });
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCOCMaster(int id)
        {
            var result = await _unitOfWorkService.mCOCMASTERService.DeleteCOC(id);
            if (result == 0)
                return BadRequest(new { status = 400, message = "Oops Something Went Wrong!" });
            else
                return Ok(new { status = 200 });
        }


        #endregion

        #region CoCTypeMaster


        [HttpGet]
        public async Task<ActionResult> GetMCOCTYPE()
        {
            var result = await _unitOfWorkService.mCOCTYPEMASTERService.GetMCOCTYPE();
            if (result.Count == 0)
                return NotFoundResult();
            else
                return Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult> GetMCOCTYPE(int id)
        {
            var result = await _unitOfWorkService.mCOCTYPEMASTERService.GetMCOCTYPE(id);
            if (result.Count == 0)
                return NotFoundResult();
            else
                return Ok(result);
        }

        #endregion

        #region Phase
        [HttpGet]
        public async Task<ActionResult> GetMPhase()
        {
            var result = await _unitOfWorkService.mPhaseService.GetMPhase();
            if (result.Count == 0)
                return NotFoundResult();
            else
                return Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult> GetMPhase(int id)
        {
            var result = await _unitOfWorkService.mPhaseService.GetMPhase(id);
            if (result.Count == 0)
                return NotFoundResult();
            else
                return Ok(result);
        }
        #endregion

        #region FiberCount

        [HttpGet]
        public async Task<ActionResult> GetFIBER()
        {
            var result = await _unitOfWorkService.fIBERCOUNTService.GetFIBER();
            if (result.Count == 0)
                return NotFoundResult();
            else
                return Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult> GetFIBER(int id)
        {
            var result = await _unitOfWorkService.fIBERCOUNTService.GetFIBER(id);
            if (result.Count == 0)
                return NotFoundResult();
            else
                return Ok(result);
        }


        [HttpPost]
        public async Task<ActionResult> CreateFIBER([FromBody] FiberCountModel fIBERCOUNTModel)
        {
            fIBERCOUNTModel.CreatedBy = "1";
            var result = await _unitOfWorkService.fIBERCOUNTService.CreateFIBER(fIBERCOUNTModel);
            KeyValuePair<FiberCountModel, string> i = result.First();
            if (i.Value == "ok")
                return Ok(new { ID = i.Key.FiberCountID });
            else if (i.Value == "")
                return BadRequest(new { status = 400, message = "Oops Something Went Wrong!" });
            else
                return BadRequest(new { status = 400, message = i.Value });
        }


        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateFIBER(int id, [FromBody] FiberCountModel fIBERCOUNTModel)
        {
            fIBERCOUNTModel.FiberCountID = id;
            fIBERCOUNTModel.UpdatedBy = "1";
            var result = await _unitOfWorkService.fIBERCOUNTService.UpdateFIBER(fIBERCOUNTModel);
            if (result.FiberCountID == 0)
                return BadRequest(new { status = 400, message = "Oops Something Went Wrong!" });
            else
                return Ok(new { status = 200 });
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteFIBER(int id)
        {
            var result = await _unitOfWorkService.fIBERCOUNTService.DeleteFIBER(id);
            if (result == 0)
                return BadRequest(new { status = 400, message = "Oops Something Went Wrong!" });
            else
                return Ok(new { status = 200 });
        }


        #endregion
    }
}
