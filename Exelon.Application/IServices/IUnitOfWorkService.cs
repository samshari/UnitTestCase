using System;
using System.Collections.Generic;
using System.Text;

namespace Exelon.Application.IServices
{
    public interface IUnitOfWorkService
    {


        #region CommonController
        public IMBarnService mBarnService { get; }
        public IMSIZEService mSIZEService { get; }
        public IMREGIONService mREGIONService { get; }
        public IMCocService mCOSService { get; }
        public IMEOCService mEOCService { get; }
        public IMProjectStatusService mProjectStatusService { get; }
        public IMTECHService mTECHService { get; }
        public IMEOCREALSTATEService mEOCREALSTATEService { get; }
        public IMPMService mPMService { get; }
        
        public IMCOCBIDFIBERService mCOCBIDFIBERService { get; }
        public IMREACTLREService mREACTLREService { get; }
        public IMUCOSPOCService mUCOSPOCService { get; }
        public IMINNERDUCTCOCService mINNERDUCTCOCService { get; }
        public IMSTEPMASTERService mSTEPMASTERService { get; }
        public IMENVCOCService mENVCOCService { get; }
        public IMREALSUPEOCService mREALSUPEOCService { get; }
        public IMCOCMKREADYService mCOCMKREADYService { get; }
        public IGENERALService gENERALService { get; }
        public IHUTREEFService hUTREEFService { get; }
        public IHUTSOWNERService hUTSOWNERService { get; }
        public IHUTSCOMPSTATUSService hUTSCOMPSTATUSService { get; }
        public IHUTSTRANSPERMITService hUTSTRANSPERMITService { get; }
        public IHUTSENVDUEService hUTSENVDUEService { get; }
        public IMattingPreConstructionRequiredService mattingPreConstructionRequiredService { get; }
        public ILNLService lNLService { get; }
        public ISTACKINGPreConstructionRequiredService sTAKINGPreConstructionRequiredService { get; }
        public IVEGPreConstructionRequiredService vEGPreConstructionRequiredService { get; }
        public IMCOCMASTERService mCOCMASTERService { get; }
        public IMCOCTYPEMASTERService mCOCTYPEMASTERService { get; }
        public IMPhaseService mPhaseService { get; }
        #endregion

        #region ExecutionLinks Controller 
        public IENGINVESTService eNGINVESTService { get; }
        public IINNERRODROPEService iNNERRODROPEService { get; }
        public IIFCDATESService iFCDATESService { get; }
        public IPRECONSTRUCTIONService pRECONSTRUCTIONService { get; }
        public ICOMEDEXService cOMEDEXService { get; }
        public ICIVILService cIVILService { get; }
        public IBORINGService bORINGService { get; }
        public IFIBERService fIBERService { get; }
        public IOVHDMKService oVHDMKService { get; }
        public IPostCompletionService postCompletionService { get; }
        public IExLinkingInfoService exLinkingInfoService { get; }

        public ICompletedPoleMileService completedPoleMileService { get; }
        #endregion

        #region Engineering 

        public ILinkingInfoService linkInfoService { get; }
        public IDesignMilesService dESIGNMILESService { get; }
        public IOWNERService oWNERService { get; }
        public IPPREPLACEMENTService pPREPLACEMENTService { get; }
        public IIfaReadyService iFAREADYService { get; }
        public IIfcReadyService iFCREADYService { get; }
        public IMDEVICEService deviceServices { get; }
        public IPDService pDService { get; }
        public IFiberCountService fIBERCOUNTService { get; }
        public IIfaFiberService ifaFiberService { get; }
        public IIfcFiberService ifcFiberService { get; }
        public IMCOCBIDCOMService mCOCBIDCOMService { get; }

        #endregion

        #region HutExectuion 
        public IHutExecutionService hutExecutionService { get; }
        public IHutExPhaseOneService hutExPhaseOneService { get; }
        public IHutExPowPhaseThreeService hutExPowPhaseThreeService { get; }
        public IHutExAuxPowerPhaseTwoService hutExAuxPowerPhaseTwoService { get; }
        public IHutExCivilPhaseThreeService hutExCivilPhaseThreeService { get; }
        public IHutExCVSubgradePhaseTwoService hutExCVSubgradePhaseTwoService { get; }
        public IHutExRnPPhaseTwoService hutExRnPPhaseTwoService { get; }
        public IHutExTestingService hutExTestingService { get; }
        public IHutExFiberPhaseThreeService hutExFiberPhaseThreeService { get; }
        public IHutExRnPPhaseThreeService hutExRnPPhaseThreeService { get; }
        public IHutExRouterUpgradePhaseThreeService hutExRouterUpgradePhaseThreeService { get; }
        #endregion

        #region HutPermit 
        public IHUTPERMITService hUTPERMITService { get; }
        #endregion

        #region Hut 
        public IHUTService hUTService { get; }
        #endregion

        #region PD Details Controller 
        public IPDDetailsService pDDetailsService { get; }
        #endregion
    }
}
