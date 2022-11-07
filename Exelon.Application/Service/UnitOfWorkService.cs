using Exelon.Application.IServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exelon.Application.Service
{
    public class UnitOfWorkService : IUnitOfWorkService
    {

        #region CommonController Services Declaration 

        private readonly IMSIZEService _mSIZEService;
        private readonly IMBarnService _mBarnService;
        private readonly IMREGIONService _mREGIONService;
        private readonly IMCocService _mCOSService;
        private readonly IMEOCService _mEOCService;
        private readonly IMProjectStatusService _mProjectStatusService;
        private readonly IMTECHService _mTECHService;
        private readonly IMEOCREALSTATEService _mEOCREALSTATEService;
        private readonly IMPMService _mPMService;
        private readonly IMCOCBIDCOMService _mCOCBIDCOMService;
        private readonly IMCOCBIDFIBERService _mCOCBIDFIBERService;
        private readonly IMREACTLREService _mREACTLREService;
        private readonly IMUCOSPOCService _mUCOSPOCService;
        private readonly IMINNERDUCTCOCService _mINNERDUCTCOCService;
        private readonly IMSTEPMASTERService _mSTEPMASTERService;
        private readonly IMENVCOCService _mENVCOCService;
        private readonly IMREALSUPEOCService _mREALSUPEOCService;
        private readonly IMCOCMKREADYService _mCOCMKREADYService;
        private readonly IGENERALService _gENERALService;
        private readonly IHUTREEFService _hUTREEFService;
        private readonly IHUTSOWNERService _hUTSOWNERService;
        private readonly IHUTSCOMPSTATUSService _hUTSCOMPSTATUSService;
        private readonly IHUTSTRANSPERMITService _hUTSTRANSPERMITService;
        private readonly IHUTSENVDUEService _hUTSENVDUEService;
        private readonly IMattingPreConstructionRequiredService _mattingPreConstructionRequiredService;
        private readonly ILNLService _lNLService;
        private readonly ISTACKINGPreConstructionRequiredService _sTAKINGPreConstructionRequiredService;
        private readonly IVEGPreConstructionRequiredService _vEGPreConstructionRequiredService;
        private readonly IMCOCMASTERService _mCOCMASTERService;
        private readonly IMCOCTYPEMASTERService _mCOCTYPEMASTERService;
        private readonly IMPhaseService _mPhaseService;
        #endregion


        #region ExecutionLinks Decalration 
        private readonly IENGINVESTService _eNGINVESTService;
        private readonly IINNERRODROPEService _iNNERRODROPEService;
        private readonly IIFCDATESService _iFCDATESService;
        private readonly IPRECONSTRUCTIONService _pRECONSTRUCTIONService;
        private readonly ICOMEDEXService _cOMEDEXService;
        private readonly ICIVILService _cIVILService;
        private readonly IBORINGService _bORINGService;
        private readonly IFIBERService _fIBERService;
        private readonly IOVHDMKService _oVHDMKService;
        private readonly IPostCompletionService _postCompletionService;
        private readonly IPDDetailsService pDDetails;
        private readonly ICompletedPoleMileService poleMileService;
        private readonly IOSPPermitEasementService oSPPermitService;
        private readonly IPerformProgressService progressService;
        #endregion

        #region Engineering Declaration 

        private readonly ILinkingInfoService _linkingInfoService;
        private readonly IDesignMilesService _dESIGNMILESService;
        private readonly IOWNERService _oWNERService;
        private readonly IPPREPLACEMENTService _pPREPLACEMENTService;
        private readonly IIfaReadyService _iFAREADYService;
        private readonly IIfcReadyService _iFCREADYService;
        private readonly IMDEVICEService _dEVICEService;
        private readonly IPDService _pDService;
        private readonly IFiberCountService _fIBERCOUNTService;
        private readonly IIfaFiberService _ifaFiberService;
        private readonly IIfcFiberService _ifcFiberService;

        #endregion


        #region HutExecution Decalaration 
        private readonly IHutExecutionService _hutExecutionService;
        private readonly IHutExPhaseOneService _hutExPhaseOneService;
        private readonly IHutExPowPhaseThreeService _hutExPowPhaseThreeService;
        private readonly IHutExAuxPowerPhaseTwoService _hutExAuxPowerPhaseTwoService;
        private readonly IHutExCivilPhaseThreeService _hutExCivilPhaseThreeService;
        private readonly IHutExCVSubgradePhaseTwoService _hutExCVSubgradePhaseTwoService;
        private readonly IHutExRnPPhaseTwoService _hutExRnPPhaseTwoService;
        private readonly IHutExTestingService _hutExTestingService;
        private readonly IHutExFiberPhaseThreeService _hutExFiberPhaseThreeService;
        private readonly IHutExRnPPhaseThreeService _hutExRnPPhaseThreeService;
        private readonly IHutExRouterUpgradePhaseThreeService _hutExRouterUpgradePhaseThreeService;
        #endregion

        #region HutPermit Declaration 
        private readonly IHUTPERMITService _hUTPERMITService;
        #endregion

        #region Hut Declaration
        private readonly IHUTService _hUTService;
        #endregion
        public UnitOfWorkService(
            //Common 
            IMSIZEService mSIZEService, IMBarnService mBarnService, IMREGIONService mREGIONService, IMCocService mCOSService, IMEOCService mEOCService,
            IMProjectStatusService mProjectStatusService, IMTECHService mTECHService, IMPMService mPMService, IMCOCBIDCOMService mCOCBIDCOMService,
            IMCOCBIDFIBERService mCOCBIDFIBERService, IMREACTLREService mREACTLREService, IMUCOSPOCService mUCOSPOCService, IMINNERDUCTCOCService mINNERDUCTCOCService,
            IMSTEPMASTERService mSTEPMASTERService, IMENVCOCService mENVCOCService, IMREALSUPEOCService mREALSUPEOCService, IMCOCMKREADYService mCOCMKREADYService,
            IMattingPreConstructionRequiredService mattingPreConstructionRequiredService, ILNLService lNLService,
            IVEGPreConstructionRequiredService vEGPreConstructionRequiredService, ISTACKINGPreConstructionRequiredService sTAKINGPreConstructionRequired,
            IGENERALService gENERALService, IHUTREEFService hUTREEFService, IHUTSOWNERService hUTSOWNERService,
            IHUTSCOMPSTATUSService hUTSCOMPSTATUSService, IHUTSTRANSPERMITService hUTSTRANSPERMITService, IHUTSENVDUEService hUTSENVDUEService,
            IMCOCTYPEMASTERService mCOCTYPEMASTERService, IMCOCMASTERService mCOCMASTERService,
            IMPhaseService mPhaseService,

            //ExecutionLinks 
            IENGINVESTService eNGINVESTService, IINNERRODROPEService iNNERRODROPEService,
            IIFCDATESService iFCDATESService, IPRECONSTRUCTIONService pRECONSTRUCTIONService,
            ICOMEDEXService cOMEDEXService, ICIVILService cIVILService, IBORINGService bORINGService,
            IFIBERService fIBERService, IOVHDMKService oVHDMKService, IPostCompletionService postCompletionService,

            //Engineering 
            ILinkingInfoService linkingInfoService,
            IDesignMilesService dESIGNMILESService, IOWNERService oWNERService,
            IPPREPLACEMENTService pPREPLACEMENTService, IIfaReadyService iFAREADYService,
            IIfcReadyService iFCREADYService,
            IMDEVICEService dEVICEService, IPDService pDService,
            IFiberCountService fIBERCOUNTService, IIfaFiberService ifaFiberService,
            IIfcFiberService ifcFiberService
            , IMEOCREALSTATEService mEOCREALSTATEService,

            //HutExecution 
            IHutExecutionService hutExecutionService, IHutExPhaseOneService hutExPhaseOneService,
            IHutExPowPhaseThreeService hutExPowPhaseThreeService, IHutExAuxPowerPhaseTwoService hutExAuxPowerPhaseTwoService,
            IHutExCivilPhaseThreeService hutExCivilPhaseThreeService,
            IHutExCVSubgradePhaseTwoService hutExCVSubgradePhaseTwoService,
            IHutExRnPPhaseTwoService hutExRnPPhaseTwoService,
            IHutExTestingService hutExTestingService,
            IHutExFiberPhaseThreeService hutExFiberPhaseThreeService,
            IHutExRnPPhaseThreeService hutExRnPPhaseThreeService,
            IHutExRouterUpgradePhaseThreeService hutExRouterUpgradePhaseThreeService,

            //HutPermit
            IHUTPERMITService hUTPERMITService,

            //Hut
            IHUTService hUTService,
            // PD Details
            IPDDetailsService pdDetailsService

            )
        {

            #region  CommonController Services initialization
            _mSIZEService = mSIZEService;
            _mBarnService = mBarnService;
            _mREGIONService = mREGIONService;
            _mCOSService = mCOSService;
            _mEOCService = mEOCService;
            _mProjectStatusService = mProjectStatusService;
            _mTECHService = mTECHService;
            _mPMService = mPMService;
            _mCOCBIDCOMService = mCOCBIDCOMService;
            _mCOCBIDFIBERService = mCOCBIDFIBERService;
            _mREACTLREService = mREACTLREService;
            _mUCOSPOCService = mUCOSPOCService;
            _mINNERDUCTCOCService = mINNERDUCTCOCService;
            _mSTEPMASTERService = mSTEPMASTERService;
            _mENVCOCService = mENVCOCService;
            _mREALSUPEOCService = mREALSUPEOCService;
            _mCOCMKREADYService = mCOCMKREADYService;
            _gENERALService = gENERALService;
            _hUTREEFService = hUTREEFService;
            _hUTSOWNERService = hUTSOWNERService;
            _hUTSCOMPSTATUSService = hUTSCOMPSTATUSService;
            _hUTSTRANSPERMITService = hUTSTRANSPERMITService;
            _hUTSENVDUEService = hUTSENVDUEService;
            _mattingPreConstructionRequiredService = mattingPreConstructionRequiredService;
            _lNLService = lNLService;
            _vEGPreConstructionRequiredService = vEGPreConstructionRequiredService;
            _sTAKINGPreConstructionRequiredService = sTAKINGPreConstructionRequired;
            _mCOCMASTERService = mCOCMASTERService;
            _mCOCTYPEMASTERService = mCOCTYPEMASTERService;
            _mPhaseService = mPhaseService;

            #endregion


            #region ExecutiuonLinks Initialization 
            _eNGINVESTService = eNGINVESTService;
            _iNNERRODROPEService = iNNERRODROPEService;
            _iFCDATESService = iFCDATESService;
            _pRECONSTRUCTIONService = pRECONSTRUCTIONService;
            _cOMEDEXService = cOMEDEXService;
            _cIVILService = cIVILService;
            _bORINGService = bORINGService;
            _fIBERService = fIBERService;
            _oVHDMKService = oVHDMKService;
            _postCompletionService = postCompletionService;
            #endregion

            #region Engineering Initialization 
            _linkingInfoService = linkingInfoService;
            _dESIGNMILESService = dESIGNMILESService;
            _oWNERService = oWNERService;
            _pPREPLACEMENTService = pPREPLACEMENTService;
            _iFAREADYService = iFAREADYService;
            _iFCREADYService = iFCREADYService;
            _dEVICEService = dEVICEService;
            _pDService = pDService;
            _fIBERCOUNTService = fIBERCOUNTService;
            _ifaFiberService = ifaFiberService;
            _ifcFiberService = ifcFiberService;
            _mEOCREALSTATEService = mEOCREALSTATEService;
            #endregion

            #region HutExecution Initialization
            _hutExecutionService = hutExecutionService;
            _hutExPhaseOneService = hutExPhaseOneService;
            _hutExPowPhaseThreeService = hutExPowPhaseThreeService;
            _hutExAuxPowerPhaseTwoService = hutExAuxPowerPhaseTwoService;
            _hutExCivilPhaseThreeService = hutExCivilPhaseThreeService;
            _hutExCVSubgradePhaseTwoService = hutExCVSubgradePhaseTwoService;
            _hutExRnPPhaseTwoService = hutExRnPPhaseTwoService;
            _hutExTestingService = hutExTestingService;
            _hutExFiberPhaseThreeService = hutExFiberPhaseThreeService;
            _hutExRnPPhaseThreeService = hutExRnPPhaseThreeService;
            _hutExRouterUpgradePhaseThreeService = hutExRouterUpgradePhaseThreeService;
            #endregion

            #region HutPermit Initialization
            _hUTPERMITService = hUTPERMITService;
            #endregion

            #region Hut Initialization
            _hUTService = hUTService;
            #endregion

            #region PD Details Initialization 
            pDDetails = pdDetailsService ;
            #endregion
        }


        #region CommonController Services

        public IMBarnService mBarnService
        {
            get
            {
                return _mBarnService; 
            }
            
        }
        
        public IMSIZEService mSIZEService
        {
            get
            {
                return _mSIZEService;
            }
        }


        public IMREGIONService mREGIONService
        {
            get
            {
                return _mREGIONService;
            }
            
        }


        public IMCocService mCOSService
        {
            get
            {
                return _mCOSService;
            }
        }

        public IMEOCService mEOCService
        {
            get
            {
                return _mEOCService;
            }
        }


        public IMProjectStatusService mProjectStatusService
        {
            get
            {
                return _mProjectStatusService;
            }
        }


        public IMTECHService mTECHService
        {
            get
            {
                return _mTECHService;
            }
        }


        public IMEOCREALSTATEService mEOCREALSTATEService
        {
            get
            {
                return _mEOCREALSTATEService;
            }
        }

        public IMPMService mPMService
        {
            get
            {
                return _mPMService;
            }
        }

        public IMCOCBIDCOMService mCOCBIDCOMService
        {
            get
            {
                return _mCOCBIDCOMService;
            }
        }


        public IMCOCBIDFIBERService mCOCBIDFIBERService
        {
            get
            {
                return _mCOCBIDFIBERService;
            }
        }

        public IMREACTLREService mREACTLREService
        {
            get
            {
                return _mREACTLREService;
            }
        }


        public IMUCOSPOCService mUCOSPOCService
        {
            get
            {
                return _mUCOSPOCService;
            }
        }


        public IMINNERDUCTCOCService mINNERDUCTCOCService
        {
            get
            {
                return _mINNERDUCTCOCService;
            }
        }

        public IMSTEPMASTERService mSTEPMASTERService
        {
            get
            {
                return _mSTEPMASTERService;
            }
        }

        public IMENVCOCService mENVCOCService
        {
            get
            {
                return _mENVCOCService;
            }
        }

        public IMREALSUPEOCService mREALSUPEOCService
        {
            get
            {
                return _mREALSUPEOCService;
            }
        }

        public IMCOCMKREADYService mCOCMKREADYService
        {
            get
            {
                return _mCOCMKREADYService;
            }
        }

        public IGENERALService gENERALService
        {
            get
            {
                return _gENERALService;
            }
        }

        public IHUTREEFService hUTREEFService
        {
            get
            {
                return _hUTREEFService;
            }
        }


        public IHUTSOWNERService hUTSOWNERService
        {
            get
            {
                return _hUTSOWNERService;
            }
        }

        public IHUTSCOMPSTATUSService hUTSCOMPSTATUSService
        {
            get
            {
                return _hUTSCOMPSTATUSService;
            }
        }

        public IHUTSTRANSPERMITService hUTSTRANSPERMITService
        {
            get
            {
                return _hUTSTRANSPERMITService;
            }
        }

        public IHUTSENVDUEService hUTSENVDUEService
        {
            get
            {
                return _hUTSENVDUEService;
            }
        }

        public IMattingPreConstructionRequiredService mattingPreConstructionRequiredService
        {
            get
            {
                return _mattingPreConstructionRequiredService;
            }
        }

        public ILNLService lNLService
        {
            get
            {
                return _lNLService;
            }
        }

        public ISTACKINGPreConstructionRequiredService sTAKINGPreConstructionRequiredService
        {
            get
            {
                return _sTAKINGPreConstructionRequiredService;
            }
        }

        public IVEGPreConstructionRequiredService vEGPreConstructionRequiredService
        {
            get
            {
                return _vEGPreConstructionRequiredService;
            }
        }

        public IMCOCMASTERService mCOCMASTERService
        {
            get
            {
                return _mCOCMASTERService;
            }
        }

        public IMCOCTYPEMASTERService mCOCTYPEMASTERService
        {
            get
            {
                return _mCOCTYPEMASTERService;
            }
        }

        public IMPhaseService mPhaseService
        {
            get
            {
                return _mPhaseService;
            }
        }
        #endregion

        #region ExecutionLinks 
        
        public IENGINVESTService eNGINVESTService
        {
            get
            {
                return _eNGINVESTService;
            }
        }

        public IINNERRODROPEService iNNERRODROPEService
        {
            get
            {
                return _iNNERRODROPEService;
            }
        }

        public IIFCDATESService iFCDATESService
        {
            get
            {
                return _iFCDATESService;
            }
        }

        public IPRECONSTRUCTIONService pRECONSTRUCTIONService
        {
            get
            {
                return _pRECONSTRUCTIONService;
            }
        }

        public ICOMEDEXService cOMEDEXService
        {
            get
            {
                return _cOMEDEXService;
            }
        }

        public ICIVILService cIVILService
        {
            get
            {
                return _cIVILService;
            }
        }

        public IBORINGService bORINGService
        {
            get
            {
                return _bORINGService;
            }
        }

        public IFIBERService fIBERService
        {
            get
            {
                return _fIBERService;
            }
        }

        public IOVHDMKService oVHDMKService
        {
            get
            {
                return _oVHDMKService;
            }
        }

        public IPostCompletionService postCompletionService
        {
            get
            {
                return _postCompletionService;
            }
        }
        public ICompletedPoleMileService completedPoleMileService
        {
            get { return poleMileService; }
        }
        #endregion


        #region Engineering Controller 

        public ILinkingInfoService linkInfoService
        {
            get{return _linkingInfoService;}
        }

        public IDesignMilesService dESIGNMILESService
        {
            get{return _dESIGNMILESService;}
        }

        public IOWNERService oWNERService
        {
            get
            {
                return _oWNERService;
            }
        }

        public IPPREPLACEMENTService pPREPLACEMENTService
        {
            get
            {
                return _pPREPLACEMENTService;
            }
        }

        public IIfaReadyService iFAREADYService
        {
            get
            {
                return _iFAREADYService;
            }
        }

        public IIfcReadyService iFCREADYService
        {
            get
            {
                return _iFCREADYService;
            }
        }

        public IMDEVICEService deviceServices
        {
            get
            {
                return _dEVICEService;
            }
        }

        public IPDService pDService
        {
            get
            {
                return _pDService;
            }
        }

        public IFiberCountService fIBERCOUNTService
        {
            get
            {
                return _fIBERCOUNTService;
            }
        }

        public IIfaFiberService ifaFiberService
        {
            get
            {
                return _ifaFiberService;
            }
        }

        public IIfcFiberService ifcFiberService
        {
            get
            {
                return _ifcFiberService;
            }
        }

        #endregion


        #region HutExecution 

        public IHutExecutionService hutExecutionService
        {
            get
            {
                return _hutExecutionService;
            }
        }

        public IHutExPhaseOneService hutExPhaseOneService
        {
            get
            {
                return _hutExPhaseOneService;
            }
        }

        public IHutExPowPhaseThreeService hutExPowPhaseThreeService
        {
            get
            {
                return _hutExPowPhaseThreeService;
            }
        }


        public IHutExAuxPowerPhaseTwoService hutExAuxPowerPhaseTwoService
        {
            get
            {
                return _hutExAuxPowerPhaseTwoService;
            }
        }

        public IHutExCivilPhaseThreeService hutExCivilPhaseThreeService
        {
            get
            {
                return _hutExCivilPhaseThreeService;
            }
        }

        public IHutExCVSubgradePhaseTwoService hutExCVSubgradePhaseTwoService
        {
            get
            {
                return _hutExCVSubgradePhaseTwoService;
            }
        }

        public IHutExRnPPhaseTwoService hutExRnPPhaseTwoService
        {
            get
            {
                return _hutExRnPPhaseTwoService;
            }
        }


        public IHutExTestingService hutExTestingService
        {
            get
            {
                return _hutExTestingService;
            }
        }


        public IHutExFiberPhaseThreeService hutExFiberPhaseThreeService
        {
            get
            {
                return _hutExFiberPhaseThreeService;
            }
        }

        public IHutExRnPPhaseThreeService hutExRnPPhaseThreeService
        {
            get
            {
                return _hutExRnPPhaseThreeService;
            }
        }


        public IHutExRouterUpgradePhaseThreeService hutExRouterUpgradePhaseThreeService
        {
            get
            {
                return _hutExRouterUpgradePhaseThreeService;
            }
        }
        #endregion

        #region HutPermit 
        public IHUTPERMITService hUTPERMITService
        {
            get
            {
                return _hUTPERMITService;
            }
        }
        #endregion

        #region Hut
        public IHUTService hUTService
        {
            get
            {
                return _hUTService;
            }
        }
        #endregion

        #region ExecutionLinks 
        public IPDDetailsService pDDetailsService
        {
            get
            {
                return pDDetails;
            }
        }

        public IOSPPermitEasementService oSPPermitEasementService
        {
            get { return oSPPermitService; }
        }

        public IPerformProgressService performProgressService 
        {
            get { return progressService; }
        }

        #endregion
    }
}
