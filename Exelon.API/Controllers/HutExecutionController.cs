using Exelon.Application.IServices;
using Exelon.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Exelon.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HutExecutionController : ControllerBase
    {
        private readonly IUnitOfWorkService _unitOfWorkService;

        public HutExecutionController(IUnitOfWorkService unitOfWorkService)
        {
            _unitOfWorkService = unitOfWorkService;
        }


        public ActionResult NotFoundResult()
        {
            return NotFound(new { status = 404, message = "Not Exists!" });
        }

        #region Hut Execution

        [HttpGet]
        public async Task<ActionResult> GetHutExecute()
        {
            var result = await _unitOfWorkService.hutExecutionService.GetHutExecute();
            if (result.Count == 0)
                return NotFoundResult();
            else
                return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetHutExecute(int id)
        {
            var result = await _unitOfWorkService.hutExecutionService.GetHutExecute(id);
            if (result.Count == 0)
                return NotFoundResult();
            else
                return Ok(result);
            
        }

        [HttpPost]
        public async Task<ActionResult> CreateHutExecute([FromBody] HutExecutionModel hutExecutionModel)
        {
            hutExecutionModel.CreatedBy = "1";
            var result = await _unitOfWorkService.hutExecutionService.CreateHutExecute(hutExecutionModel);
            if (result.HutExecutionID == 0)
                return BadRequest(new { status = 400, message = "Oops Something went wrong!" });
            else
                return Ok(new { ID = hutExecutionModel.HutExecutionID});
        }


        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateHutExecute(int id, [FromBody] HutExecutionModel hutExecutionModel)
        {
            hutExecutionModel.UpdatedBy = "1";
            hutExecutionModel.HutExecutionID = id;
            var result = await _unitOfWorkService.hutExecutionService.UpdateHutExecute(hutExecutionModel);
            if (result.HutExecutionID == 0)
                return BadRequest(new { status = 400, message = "Oops Something went wrong!" });
            else
                return Ok(new { status = 200 });

        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteHutExecute(int id)
        {
            var result = await _unitOfWorkService.hutExecutionService.DeleteHutExecute(id);
            if(result == 0)
                return BadRequest(new { status = 400, message = "Oops Something went wrong!" });
            else
                return Ok(new { status = 200 });
        }

        #endregion


        #region Hut Execution Phase-1

        [HttpGet]
        public async Task<ActionResult> GetHutExPOne()
        {
            var result = await _unitOfWorkService.hutExPhaseOneService.GetHutExPOne();
            if (result.Count == 0)
                return NotFoundResult();
            else
                return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetHutExPOne(int id)
        {
            var result = await _unitOfWorkService.hutExPhaseOneService.GetHutExPOne(id);
            if (result.Count == 0)
                return NotFoundResult();
            else
                return Ok(result);

        }

        [HttpPost]
        public async Task<ActionResult> CreateHutExPOne([FromBody] HutExPhaseOneModel hutExPhaseOneModel)
        {
            hutExPhaseOneModel.CreatedBy = "1";
            var result = await _unitOfWorkService.hutExPhaseOneService.CreateHutExPOne(hutExPhaseOneModel);
            if (result.HutExPhaseOneID == 0)
                return BadRequest(new { status = 400, message = "Oops Something went wrong!" });
            else
                return Ok(new { ID = hutExPhaseOneModel.HutExPhaseOneID });
        }


        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateHutExPOne(int id, [FromBody] HutExPhaseOneModel hutExPhaseOneModel)
        {
            hutExPhaseOneModel.UpdatedBy = "1";
            hutExPhaseOneModel.HutExPhaseOneID = id;
            var result = await _unitOfWorkService.hutExPhaseOneService.UpdateHutExPOne(hutExPhaseOneModel);
            if (result.HutExPhaseOneID == 0)
                return BadRequest(new { status = 400, message = "Oops Something went wrong!" });
            else
                return Ok(new { status = 200 });

        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteHutExPOne(int id)
        {
            var result = await _unitOfWorkService.hutExPhaseOneService.DeleteHutExPOne(id);
            if (result == 0)
                return BadRequest(new { status = 400, message = "Oops Something went wrong!" });
            else
                return Ok(new { status = 200 });
        }


        #endregion


        #region Hut Exexution AuxPower Phase-3 

        [HttpGet]
        public async Task<ActionResult> GetHutExPowPhaseThree()
        {
            var result = await _unitOfWorkService.hutExPowPhaseThreeService.GetHutExPowPhaseThree();
            if (result.Count == 0)
                return NotFoundResult();
            else
                return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetHutExPowPhaseThree(int id)
        {
            var result = await _unitOfWorkService.hutExPowPhaseThreeService.GetHutExPowPhaseThree(id);
            if (result.Count == 0)
                return NotFoundResult();
            else
                return Ok(result);

        }

        [HttpPost]
        public async Task<ActionResult> CreateHutExPowPhaseThree([FromBody] HutExPowPhaseThreeModel hutExPowPhaseThreeModel)
        {
            hutExPowPhaseThreeModel.CreatedBy = "1";
            var result = await _unitOfWorkService.hutExPowPhaseThreeService.CreateHutExPowPhaseThree(hutExPowPhaseThreeModel);
            if (result.HutExAuxPowerPhase3ID == 0)
                return BadRequest(new { status = 400, message = "Oops Something went wrong!" });
            else
                return Ok(new { ID = hutExPowPhaseThreeModel.HutExAuxPowerPhase3ID });
        }


        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateHutExPowPhaseThree(int id, [FromBody] HutExPowPhaseThreeModel hutExPowPhaseThreeModel)
        {
            hutExPowPhaseThreeModel.UpdatedBy = "1";
            hutExPowPhaseThreeModel.HutExAuxPowerPhase3ID = id;
            var result = await _unitOfWorkService.hutExPowPhaseThreeService.UpdateHutExPowPhaseThree(hutExPowPhaseThreeModel);
            if (result.HutExAuxPowerPhase3ID == 0)
                return BadRequest(new { status = 400, message = "Oops Something went wrong!" });
            else
                return Ok(new { status = 200 });

        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteHutExPowPhaseThree(int id)
        {
            var result = await _unitOfWorkService.hutExPowPhaseThreeService.DeleteHutExPowPhaseThree(id);
            if (result == 0)
                return BadRequest(new { status = 400, message = "Oops Something went wrong!" });
            else
                return Ok(new { status = 200 });
        }

        #endregion

        #region Hut Exexution AuxPower Phase-2
        [HttpGet]
        public async Task<ActionResult> GetHutPhaseTwo()
        {
            var result = await _unitOfWorkService.hutExAuxPowerPhaseTwoService.GetHutPhaseTwo();
            if (result.Count == 0)
                return NotFoundResult();
            else
                return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetHutPhaseTwo(int id)
        {
            var result = await _unitOfWorkService.hutExAuxPowerPhaseTwoService.GetHutPhaseTwo(id);
            if (result.Count == 0)
                return NotFoundResult();
            else
                return Ok(result);

        }

        [HttpPost]
        public async Task<ActionResult> CreateHutPhaseTwo([FromBody] HutExAuxPowerPhaseTwoModel hutExAuxPowerPhaseTwoModel)
        {
            hutExAuxPowerPhaseTwoModel.CreatedBy = "1";
            var result = await _unitOfWorkService.hutExAuxPowerPhaseTwoService.CreateHutPhaseTwo(hutExAuxPowerPhaseTwoModel);
            if (result.AuxPowerPhase2ID == 0)
                return BadRequest(new { status = 400, message = "Oops Something went wrong!" });
            else
                return Ok(new { ID = hutExAuxPowerPhaseTwoModel.AuxPowerPhase2ID });
        }


        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateHutPhaseTwo(int id, [FromBody] HutExAuxPowerPhaseTwoModel hutExAuxPowerPhaseTwoModel)
        {
            hutExAuxPowerPhaseTwoModel.UpdatedBy = "1";
            hutExAuxPowerPhaseTwoModel.AuxPowerPhase2ID = id;
            var result = await _unitOfWorkService.hutExAuxPowerPhaseTwoService.UpdateHutPhaseTwo(hutExAuxPowerPhaseTwoModel);
            if (result.AuxPowerPhase2ID == 0)
                return BadRequest(new { status = 400, message = "Oops Something went wrong!" });
            else
                return Ok(new { status = 200 });

        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteHutPhaseTwo(int id)
        {
            var result = await _unitOfWorkService.hutExAuxPowerPhaseTwoService.DeleteHutPhaseTwo(id);
            if (result == 0)
                return BadRequest(new { status = 400, message = "Oops Something went wrong!" });
            else
                return Ok(new { status = 200 });
        }

        #endregion

        #region Hut Execution Civil Phase-3

        [HttpGet]
        public async Task<ActionResult> GetCivilPhaseThree()
        {
            var result = await _unitOfWorkService.hutExCivilPhaseThreeService.GetHutCivilPhaseThree();
            if (result.Count == 0)
                return NotFoundResult();
            else
                return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetCivilPhaseThree(int id)
        {
            var result = await _unitOfWorkService.hutExCivilPhaseThreeService.GetHutCivilPhaseThree(id);
            if (result.Count == 0)
                return NotFoundResult();
            else
                return Ok(result);

        }

        [HttpPost]
        public async Task<ActionResult> CreateCivilPhaseThree([FromBody] HutExCivilPhaseThreeModel hutExCivilPhaseThreeModel)
        {
            hutExCivilPhaseThreeModel.CreatedBy = "1";
            var result = await _unitOfWorkService.hutExCivilPhaseThreeService.CreateCivilPhaseThree(hutExCivilPhaseThreeModel);
            if (result.HutExCivilPhase3ID == 0)
                return BadRequest(new { status = 400, message = "Oops Something went wrong!" });
            else
                return Ok(new { ID = hutExCivilPhaseThreeModel.HutExCivilPhase3ID });
        }


        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCivilPhaseThree(int id, [FromBody] HutExCivilPhaseThreeModel hutExCivilPhaseThreeModel)
        {
            hutExCivilPhaseThreeModel.UpdatedBy = "1";
            hutExCivilPhaseThreeModel.HutExCivilPhase3ID = id;
            var result = await _unitOfWorkService.hutExCivilPhaseThreeService.UpdateCivilPhaseThree(hutExCivilPhaseThreeModel);
            if (result.HutExCivilPhase3ID == 0)
                return BadRequest(new { status = 400, message = "Oops Something went wrong!" });
            else
                return Ok(new { status = 200 });

        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCivilPhaseThree(int id)
        {
            var result = await _unitOfWorkService.hutExCivilPhaseThreeService.DeleteCivilPhaseThree(id);
            if (result == 0)
                return BadRequest(new { status = 400, message = "Oops Something went wrong!" });
            else
                return Ok(new { status = 200 });
        }
        #endregion

        #region Hut Exexution Civil Subgrade Phase-2
        [HttpGet]
        public async Task<ActionResult> GetHutExCV()
        {
            var result = await _unitOfWorkService.hutExCVSubgradePhaseTwoService.GetHutExCV();
            if (result.Count == 0)
                return NotFoundResult();
            else
                return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetHutExCV(int id)
        {
            var result = await _unitOfWorkService.hutExCVSubgradePhaseTwoService.GetHutExCV(id);
            if (result.Count == 0)
                return NotFoundResult();
            else
                return Ok(result);

        }

        [HttpPost]
        public async Task<ActionResult> CreateHutExCV([FromBody] HutExCVSubgradePhaseTwoModel hutExCVSubgradePhaseTwoModel)
        {
            hutExCVSubgradePhaseTwoModel.CreatedBy = "1";
            var result = await _unitOfWorkService.hutExCVSubgradePhaseTwoService.CreateHutExCV(hutExCVSubgradePhaseTwoModel);
            if (result.HutExCVSubgradePhase2_ID == 0)
                return BadRequest(new { status = 400, message = "Oops Something went wrong!" });
            else
                return Ok(new { ID = hutExCVSubgradePhaseTwoModel.HutExCVSubgradePhase2_ID });
        }


        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateHutExCV(int id, [FromBody] HutExCVSubgradePhaseTwoModel hutExCVSubgradePhaseTwoModel)
        {
            hutExCVSubgradePhaseTwoModel.UpdatedBy = "1";
            hutExCVSubgradePhaseTwoModel.HutExCVSubgradePhase2_ID = id;
            var result = await _unitOfWorkService.hutExCVSubgradePhaseTwoService.UpdateHutExCV(hutExCVSubgradePhaseTwoModel);
            if (result.HutExCVSubgradePhase2_ID == 0)
                return BadRequest(new { status = 400, message = "Oops Something went wrong!" });
            else
                return Ok(new { status = 200 });

        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteHutExCV(int id)
        {
            var result = await _unitOfWorkService.hutExCVSubgradePhaseTwoService.DeleteHutExCV(id);
            if (result == 0)
                return BadRequest(new { status = 400, message = "Oops Something went wrong!" });
            else
                return Ok(new { status = 200 });
        }
        #endregion

        #region Hut Execution R&n Phase-2
        [HttpGet]
        public async Task<ActionResult> GetHutExRnPhaseTwo()
        {
            var result = await _unitOfWorkService.hutExRnPPhaseTwoService.GetHutExRnPhaseTwo();
            if (result.Count == 0)
                return NotFoundResult();
            else
                return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetHutExRnPhaseTwo(int id)
        {
            var result = await _unitOfWorkService.hutExRnPPhaseTwoService.GetHutExRnPhaseTwo(id);
            if (result.Count == 0)
                return NotFoundResult();
            else
                return Ok(result);

        }

        [HttpPost]
        public async Task<ActionResult> CreateHutExRnPhaseTwo([FromBody] HutExRnPPhaseTwoModel hutExRnPPhaseTwoModel)
        {
            hutExRnPPhaseTwoModel.CreatedBy = "1";
            var result = await _unitOfWorkService.hutExRnPPhaseTwoService.CreateHutExRnPhaseTwo(hutExRnPPhaseTwoModel);
            if (result.HutExRnPPhase2ID == 0)
                return BadRequest(new { status = 400, message = "Oops Something went wrong!" });
            else
                return Ok(new { ID = hutExRnPPhaseTwoModel.HutExRnPPhase2ID });
        }


        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateHutExRnPhaseTwo(int id, [FromBody] HutExRnPPhaseTwoModel hutExRnPPhaseTwoModel)
        {
            hutExRnPPhaseTwoModel.UpdatedBy = "1";
            hutExRnPPhaseTwoModel.HutExRnPPhase2ID = id;
            var result = await _unitOfWorkService.hutExRnPPhaseTwoService.UpdateHutExRnPhaseTwo(hutExRnPPhaseTwoModel);
            if (result.HutExRnPPhase2ID == 0)
                return BadRequest(new { status = 400, message = "Oops Something went wrong!" });
            else
                return Ok(new { status = 200 });

        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteHutExRnPhaseTwo(int id)
        {
            var result = await _unitOfWorkService.hutExRnPPhaseTwoService.DeleteHutExRnPhaseTwo(id);
            if (result == 0)
                return BadRequest(new { status = 400, message = "Oops Something went wrong!" });
            else
                return Ok(new { status = 200 });
        }
        #endregion

        #region Hut Execution LNL Testing
        [HttpGet]
        public async Task<ActionResult> GetHutTest()
        {
            var result = await _unitOfWorkService.hutExTestingService.GetHutTest();
            if (result.Count == 0)
                return NotFoundResult();
            else
                return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetHutTest(int id)
        {
            var result = await _unitOfWorkService.hutExTestingService.GetHutTest(id);
            if (result.Count == 0)
                return NotFoundResult();
            else
                return Ok(result);

        }

        [HttpPost]
        public async Task<ActionResult> CreateHutTest([FromBody] HutExTestingModel hutExTestingModel )
        {
            hutExTestingModel.CreatedBy = "1";
            var result = await _unitOfWorkService.hutExTestingService.CreateHutTest(hutExTestingModel);
            if (result.HutTestingLNLID == 0)
                return BadRequest(new { status = 400, message = "Oops Something went wrong!" });
            else
                return Ok(new { ID = hutExTestingModel.HutTestingLNLID });
        }


        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateHutTest(int id, [FromBody] HutExTestingModel hutExTestingModel)
        {
            hutExTestingModel.UpdatedBy = "1";
            hutExTestingModel.HutTestingLNLID = id;
            var result = await _unitOfWorkService.hutExTestingService.UpdateHutTest(hutExTestingModel);
            if (result.HutTestingLNLID == 0)
                return BadRequest(new { status = 400, message = "Oops Something went wrong!" });
            else
                return Ok(new { status = 200 });

        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteHutTest(int id)
        {
            var result = await _unitOfWorkService.hutExTestingService.DeleteHutTest(id);
            if (result == 0)
                return BadRequest(new { status = 400, message = "Oops Something went wrong!" });
            else
                return Ok(new { status = 200 });
        }
        #endregion


        #region Hut Exexution Fiber Phase-3
        [HttpGet]
        public async Task<ActionResult> GetHutFiber()
        {
            var result = await _unitOfWorkService.hutExFiberPhaseThreeService.GetHutFiber();
            if (result.Count == 0)
                return NotFoundResult();
            else
                return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetHutFiber(int id)
        {
            var result = await _unitOfWorkService.hutExFiberPhaseThreeService.GetHutFiber(id);
            if (result.Count == 0)
                return NotFoundResult();
            else
                return Ok(result);

        }

        [HttpPost]
        public async Task<ActionResult> CreateHutFiber([FromBody] HutExFiberPhaseThreeModel hutExFiberPhaseThreeModel )
        {
            hutExFiberPhaseThreeModel.CreatedBy = "1";
            var result = await _unitOfWorkService.hutExFiberPhaseThreeService.CreateHutFiber(hutExFiberPhaseThreeModel);
            if (result.FiberPhase3ID == 0)
                return BadRequest(new { status = 400, message = "Oops Something went wrong!" });
            else
                return Ok(new { ID = hutExFiberPhaseThreeModel.FiberPhase3ID });
        }


        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateHutFiber(int id, [FromBody] HutExFiberPhaseThreeModel hutExFiberPhaseThreeModel)
        {
            hutExFiberPhaseThreeModel.UpdatedBy = "1";
            hutExFiberPhaseThreeModel.FiberPhase3ID = id;
            var result = await _unitOfWorkService.hutExFiberPhaseThreeService.UpdateHutFiber(hutExFiberPhaseThreeModel);
            if (result.FiberPhase3ID == 0)
                return BadRequest(new { status = 400, message = "Oops Something went wrong!" });
            else
                return Ok(new { status = 200 });

        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteHutFiber(int id)
        {
            var result = await _unitOfWorkService.hutExFiberPhaseThreeService.DeleteHutFiber(id);
            if (result == 0)
                return BadRequest(new { status = 400, message = "Oops Something went wrong!" });
            else
                return Ok(new { status = 200 });
        }
        #endregion

        #region Hut Execution RnP Phase-3
        [HttpGet]
        public async Task<ActionResult> GetHutRnPPhaseThree()
        {
            var result = await _unitOfWorkService.hutExRnPPhaseThreeService.GetHutRnPPhaseThree();
            if (result.Count == 0)
                return NotFoundResult();
            else
                return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetHutRnPPhaseThree(int id)
        {
            var result = await _unitOfWorkService.hutExRnPPhaseThreeService.GetHutRnPPhaseThree(id);
            if (result.Count == 0)
                return NotFoundResult();
            else
                return Ok(result);

        }

        [HttpPost]
        public async Task<ActionResult> CreateHutRnPPhaseThree([FromBody] HutExRnPPhaseThreeModel hutExRnPPhaseThreeModel)
        {
            hutExRnPPhaseThreeModel.CreatedBy = "1";
            var result = await _unitOfWorkService.hutExRnPPhaseThreeService.CreateHutRnPPhaseThree(hutExRnPPhaseThreeModel);
            if (result.RnPPhase3ID == 0)
                return BadRequest(new { status = 400, message = "Oops Something went wrong!" });
            else
                return Ok(new { ID = hutExRnPPhaseThreeModel.RnPPhase3ID });
        }


        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateHutRnPPhaseThree(int id, [FromBody] HutExRnPPhaseThreeModel hutExRnPPhaseThreeModel)
        {
            hutExRnPPhaseThreeModel.UpdatedBy = "1";
            hutExRnPPhaseThreeModel.RnPPhase3ID = id;
            var result = await _unitOfWorkService.hutExRnPPhaseThreeService.UpdateHutRnPPhaseThree(hutExRnPPhaseThreeModel);
            if (result.RnPPhase3ID == 0)
                return BadRequest(new { status = 400, message = "Oops Something went wrong!" });
            else
                return Ok(new { status = 200 });

        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteHutRnPPhaseThree(int id)
        {
            var result = await _unitOfWorkService.hutExRnPPhaseThreeService.DeleteHutRnPPhaseThree(id);
            if (result == 0)
                return BadRequest(new { status = 400, message = "Oops Something went wrong!" });
            else
                return Ok(new { status = 200 });
        }
        #endregion

        #region Hut Execution Router Upgrade Phase-3
        [HttpGet]
        public async Task<ActionResult> GetHutRouterP3()
        {
            var result = await _unitOfWorkService.hutExRouterUpgradePhaseThreeService.GetHutRouterP3();
            if (result.Count == 0)
                return NotFoundResult();
            else
                return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetHutRouterP3(int id)
        {
            var result = await _unitOfWorkService.hutExRouterUpgradePhaseThreeService.GetHutRouterP3(id);
            if (result.Count == 0)
                return NotFoundResult();
            else
                return Ok(result);

        }

        [HttpPost]
        public async Task<ActionResult> CreateHutRouterP3([FromBody] HutExRouterUpgradePhaseThreeModel hutExRouterUpgradePhaseThreeModel)
        {
            hutExRouterUpgradePhaseThreeModel.CreatedBy = "1";
            var result = await _unitOfWorkService.hutExRouterUpgradePhaseThreeService.CreateHutRouterP3(hutExRouterUpgradePhaseThreeModel);
            if (result.RouterUpgradesPhase3ID == 0)
                return BadRequest(new { status = 400, message = "Oops Something went wrong!" });
            else
                return Ok(new { ID = hutExRouterUpgradePhaseThreeModel.RouterUpgradesPhase3ID });
        }


        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateHutRouterP3(int id, [FromBody] HutExRouterUpgradePhaseThreeModel hutExRouterUpgradePhaseThreeModel)
        {
            hutExRouterUpgradePhaseThreeModel.UpdatedBy = "1";
            hutExRouterUpgradePhaseThreeModel.RouterUpgradesPhase3ID = id;
            var result = await _unitOfWorkService.hutExRouterUpgradePhaseThreeService.UpdateHutRouterP3(hutExRouterUpgradePhaseThreeModel);
            if (result.RouterUpgradesPhase3ID == 0)
                return BadRequest(new { status = 400, message = "Oops Something went wrong!" });
            else
                return Ok(new { status = 200 });

        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteHutRouterP3(int id)
        {
            var result = await _unitOfWorkService.hutExRouterUpgradePhaseThreeService.DeleteHutRouterP3(id);
            if (result == 0)
                return BadRequest(new { status = 400, message = "Oops Something went wrong!" });
            else
                return Ok(new { status = 200 });
        }
        #endregion
    }
}
