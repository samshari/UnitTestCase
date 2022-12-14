import headerReducer from "./views/Header/HeaderReducer";
import selectNavbarReducer from "./views/Navbar/NavbarReducer";
import engineeringFormReducer from "./components/Engineering/EngineeringReducer"
import hutPermittingFormReducer from "./components/HutPermitting/HutPermittingReducer";
import hideExecutionLinksFormReducer from "./components/ExecutionLinks/ExecutionLinksReducer";
import hutsFormReducer from "./components/Huts/HutsReducer";
import hutsExecutionFormReducer from "./components/HutsExecution/HutsExecutionReducer";
import linkInformationReducer from "./components/Engineering/LinkInformation/LinkInformationReducer";
import DeviceReducer from "./components/Engineering/Device/DeviceReducer";
import DesignReducer from "./components/Engineering/DesignMiles/DesignMileReducer";
import COCBIDReducer from "./components/Engineering/COCBidComplete/COCBidCompleteReducer";
import COCBIDMkReducer from "./components/Engineering/COCBidComplete/COCBIDMkReducer";
import COCBIDFiberReducer from "./components/Engineering/COCBidComplete/COCBIDFiberReducer";
import PlannedPoleReducer from "./components/Engineering/PlannedPoleReplacement/PlannedPoleReplacementReducer";
import IFCMakeReadyReducer from "./components/Engineering/IFCMakeReady/IFCMakeReadyReducer";
import IFCFiberReducer from "./components/Engineering/IFCFiber/IFCFiberReducer";
import OwnerReducer  from "./components/Engineering/Owners/OwnerReducer";
import ReactLREReducer from "./components/Engineering/Owners/ReactLREReducer";
import UcomSPOCReducer from "./components/Engineering/Owners/UcomSPOCReducer";
import PMReducer from "./components/Engineering/Owners/PMReducer";
import IFAFiberReducer from "./components/Engineering/IFAFiber/IFAFiberReducer";
import IFAMakeReadyReducer from "./components/Engineering/IFAFiberMkReady/IFAFiberMkReadyReducer";
import EOCReducer from "./components/Engineering/RealEstate/EOCActionReducer";
import SupportCOCReducer from "./components/Engineering/RealEstate/SupportCOCReducer";
import RealEstateReducer from "./components/Engineering/RealEstate/RealEstateReducer";
import BarnReducer from "./components/Engineering/LinkInformation/BarnReducer";
import RegionReducer from "./components/Engineering/LinkInformation/RegionReducer";
import ProjectStatusReducer from "./components/Engineering/LinkInformation/ProjectStatusReducer";
import TechReducer from "./components/Engineering/LinkInformation/TechReducer";
import FiberReducer from "./components/Engineering/LinkInformation/FiberReducer";
import PDReducer from "./components/Engineering/PD/PDReducer";
import PostCompletionReducer from "./components/ExecutionLinks/PostCreation/PostCreationReducer";
import InnerDuctCOCReducer from "./components/ExecutionLinks/Engginvestigation/InnerDuctCOCReducer";
import EnggInvestReducer from "./components/ExecutionLinks/Engginvestigation/EngginvestionReducer";
import InnerDuctReducer from "./components/ExecutionLinks/InnerDuct/InnerDuctReducer";
import OVHDReducer from "./components/ExecutionLinks/Ovhd/OvhdReducer";
import OvhdCOCReducer from "./components/ExecutionLinks/Ovhd/OvhdCocReduer";
import IfcDatesReducer from './components/ExecutionLinks/IfcDates/IfcDatesReducer'
import exlinkInformationReducer from "./components/ExecutionLinks/Linkinformation/LinkInformationReducer";
import ComEdReducer from "./components/ExecutionLinks/ComEdExternal/ComEdReducer";
import CivilCOCReducer from "./components/ExecutionLinks/Civil/CivilCocReducer";
import CIVILReducer from "./components/ExecutionLinks/Civil/CivilReducer";
import ExFiberReducer from "./components/ExecutionLinks/Fiber/FiberReducer";
import PreConstructionReducer from "./components/ExecutionLinks/PreConstruction/PreConstructionReducer";
import PreConstructionCOCReducer from "./components/ExecutionLinks/PreConstruction/PreConstructionCocReducer";
import BoringCOCReducer from "./components/ExecutionLinks/Boring/BoringCocReducer";
import BoringReducer from "./components/ExecutionLinks/Boring/BoringReducer";
import LnlReducer from "./components/ExecutionLinks/ComEdExternal/LnlReducer";
import SizeReducer from "./components/HutPermitting/Size/SizeReducer";


import TabsReducer from "./utils/Tabs/TabsReducer";

import { combineReducers } from "redux";

const rootReducer= combineReducers({
    headerReducer: headerReducer,
    selectNavbarReducer: selectNavbarReducer,
    engineeringFormReducer: engineeringFormReducer,
    hutPermittingFormReducer: hutPermittingFormReducer,
    hutsFormReducer:hutsFormReducer,
    hutsExecutionFormReducer: hutsExecutionFormReducer,
    hideExecutionLinksFormReducer:hideExecutionLinksFormReducer,
    linkInformationReducer:linkInformationReducer,
    DeviceReducer:DeviceReducer,
    DesignReducer : DesignReducer,
    COCBIDReducer: COCBIDReducer,
    COCBIDMkReducer: COCBIDMkReducer,
    COCBIDFiberReducer:COCBIDFiberReducer,
    PlannedPoleReducer:PlannedPoleReducer,
    IFCMakeReadyReducer: IFCMakeReadyReducer,
    IFCFiberReducer: IFCFiberReducer,
    OwnerReducer : OwnerReducer,
    ReactLREReducer: ReactLREReducer,
    UcomSPOCReducer:UcomSPOCReducer,
    PMReducer:PMReducer,
    IFAFiberReducer: IFAFiberReducer,
    IFAMakeReadyReducer: IFAMakeReadyReducer,
    RealEstateReducer: RealEstateReducer,
    EOCReducer:EOCReducer,
    SupportCOCReducer:SupportCOCReducer,
    BarnReducer: BarnReducer,
    RegionReducer: RegionReducer,
    TechReducer: TechReducer,
    ProjectStatusReducer: ProjectStatusReducer,
    FiberReducer:FiberReducer,
    TabsReducer:TabsReducer,
    PDReducer: PDReducer,
    PostCompletionReducer:PostCompletionReducer,
    FiberReducer: FiberReducer,
    InnerDuctCOCReducer:InnerDuctCOCReducer,
    EnggInvestReducer:EnggInvestReducer,
    InnerDuctReducer:InnerDuctReducer,
    OVHDReducer:OVHDReducer,
    OvhdCOCReducer:OvhdCOCReducer,
    IfcDatesReducer:IfcDatesReducer,
    ComEdReducer:ComEdReducer,
    exlinkInformationReducer:exlinkInformationReducer,
    CivilCOCReducer:CivilCOCReducer,
    CIVILReducer:CIVILReducer,
    ExFiberReducer:ExFiberReducer,
    PreConstructionReducer:PreConstructionReducer,
    BoringCOCReducer:BoringCOCReducer,
    BoringReducer:BoringReducer,
    LnlReducer:LnlReducer,
    PreConstructionCOCReducer:PreConstructionCOCReducer,
    SizeReducer:SizeReducer

})

export default rootReducer;