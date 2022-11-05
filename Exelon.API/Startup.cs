using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Exelon.Domain.Common;
using Exelon.Application.IServices;
using Exelon.Application.Service;
using Exelon.Domain.Abstractions;
using Exelon.Infrastructure.Repositories;

namespace Exelon.API
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddNewtonsoftJson();

            services.AddCors();
            services.AddMvc();

            services.AddSingleton<IAppSettings, AppSettings>();
            services.AddTransient<IUnitOfWorkService, UnitOfWorkService>();

            services.AddTransient<IMCocService, MCocService>();
            services.AddTransient<IMCocRepository, MCocRepository>();

            services.AddTransient<IMEOCService, MEOCService>();
            services.AddTransient<IMEOCRepository, MEOCRepository>();

            services.AddTransient<IMREGIONService, MREGIONService>();
            services.AddTransient<IMREGIONRepository, MREGIONRepository>();

            services.AddTransient<IMBarnService, MBARNService>();
            services.AddTransient<IMBARNRepository, MBARNRepository>();

            services.AddTransient<IMProjectStatusService, MPROJECTSTATUSService>();
            services.AddTransient<IMPROJECTSTATUSRepository, MPROJECTSTATUSRepository>();

            services.AddTransient<ILinkingInfoService, LinkingInfoService>();
            services.AddTransient<ILinkingInfoRepository, LinkingInfoRepository>();

            services.AddTransient<IMEOCREALSTATEService, MEOCREALSTATEService>();
            services.AddTransient<IMEOCREALSTATERepository, MEOCREALSTATERepository>();

            services.AddTransient<IMTECHService, MTECHService>();
            services.AddTransient<IMTECHRepository, MTECHRepository>();

            services.AddTransient<IMREALSUPEOCService, MREALSUPEOCService>();
            services.AddTransient<IMREALSUPEOCRepository, MREALSUPEOCRepository>();

            services.AddTransient<IMPMService, MPMService>();
            services.AddTransient<IMPMRepository, MPMRepository>();

            services.AddTransient<IPDService, PDService>();
            services.AddTransient<IPDRepository, PDRepository>();

            services.AddTransient<IIfaReadyService, IfaReadyService>();
            services.AddTransient<IIfaReadyRepository, IfaReadyRepository>();

            services.AddTransient<IIfcReadyService, IfcReadyService>();
            services.AddTransient<IIfcReadyRepository, IfcReadyRepository>();

            services.AddTransient<IMCOCBIDCOMService, MCOCBIDCOMService>();
            services.AddTransient<IMCOCBIDCOMRepository, MCOCBIDCOMRepository>();

            services.AddTransient<IMCOCMKREADYService, MCOCMKREADYService>();
            services.AddTransient<IMCOCMKREADYRepository, MCOCMKREADYRepository>();

            services.AddTransient<IDesignMilesService, DesignMilesService>();
            services.AddTransient<IDesignMilesRepository, DesignMilesRepository>();

            services.AddTransient<IMDEVICEService, DeviceService>();
            services.AddTransient<IDeviceRepository, DeviceRepository>();

            services.AddTransient<IMCOCBIDFIBERService, MCOCBIDFIBERService>();
            services.AddTransient<IMCOCBIDFIBERRepository, MCOCBIDFIBERRepository>();

            services.AddTransient<IOWNERService, OWNERService>();
            services.AddTransient<IOWNERRepository, OWNERRepository>();

            services.AddTransient<IMREACTLREService, MREACTLREService>();
            services.AddTransient<IMREACTLRERepository, MREACTLRERepository>();

            services.AddTransient<IMREQUIREDService, MREQUIREDService>();
            services.AddTransient<IMREQUIREDRepository, MREQUIREDRepository>();

            services.AddTransient<IMSIZEService, MSIZEService>();
            services.AddTransient<IMSIZERepository, MSIZERepository>();

            services.AddTransient<IPPREPLACEMENTService, PPREPLACEMENTService>();
            services.AddTransient<IPPReplacementRepository, PPReplacementRepository>();

            services.AddTransient<IHUTPERMITService, HUTPERMITService>();
            services.AddTransient<IHUTPERMITRepository, HUTPERMITRepository>();

            services.AddTransient<IMUCOSPOCService, MUCOSPOCService>();
            services.AddTransient<IMUCOSPOCRepository, MUCOSPOCRepository>();

            services.AddTransient<IGENERALService, GENERALService>();
            services.AddTransient<IGENERALRepository, GENERALRepository>();

            services.AddTransient<IHUTREEFService, HUTSREEFService>();
            services.AddTransient<IHUTSREEFRepository, HUTSREEFRepository>();

            services.AddTransient<IHUTSOWNERService, HUTSOWNERService>();
            services.AddTransient<IHUTSOWNERRepository, HUTSOWNERRepository>();

            services.AddTransient<IHUTSENVDUEService, HUTSENVDUEService>();
            services.AddTransient<IHUTSENVDUERepository, HUTSENVDUERepository>();

            services.AddTransient<IHUTSCOMPSTATUSService, HUTSCOMPSTATUSService>();
            services.AddTransient<IHUTSCOMPSTATUSRepository, HUTSCOMPSTATUSRepository>();

            services.AddTransient<IHUTSTRANSPERMITService, HUTTRANSPERMITService>();
            services.AddTransient<IHUTSTRANSPERMITRepository, HUTSTRANSPERMITRepository>();

            services.AddTransient<IFiberCountService, FiberCountService>();
            services.AddTransient<IFiberCountRepository, FiberCountRepository>();

            services.AddTransient<IHUTService, HUTService>();
            services.AddTransient<IHutRepository, HUTSRepository>();

            services.AddTransient<IENGINVESTService, ENGINVESTService>();
            services.AddTransient<IENGINVESTRepository, ENGINVESTRepository>();

            services.AddTransient<IINNERRODROPEService, INNERRODROPEService>();
            services.AddTransient<IINNERRODROPERepository, INNERRODROPERepository>();

            services.AddTransient<IMSTEPMASTERService, MSTEPMASTERService>();
            services.AddTransient<IMSTEPMASTERRepository, MSTEPMASTERRepository>();

            services.AddTransient<IMINNERDUCTCOCService, MINNERDUCTCOCService>();
            services.AddTransient<IMINNERDUCTCOCRepository, MINNERDUCTCOCRepository>();

            services.AddTransient<IVEGPreConstructionRequiredService, VegPreConstructionRequiredService>();
            services.AddTransient<IVegPreConstructionRequiredRepository, VegPreConstructionRequiredRepository>();

            services.AddTransient<ILNLService, LNLService>();
            services.AddTransient<ILNLRepository, LNLRepository>();

            services.AddTransient<ISTACKINGPreConstructionRequiredService, STACKINGPreConstructionRequiredService>();
            services.AddTransient<ISTACKINGPreConstructionRequiredRepository, STACKINGPreConstructionRequiredRepository>();

            services.AddTransient<IMattingPreConstructionRequiredService, MattingPreConstructionRequiredService>();
            services.AddTransient<IMattingPreConstructionRequiredRepository, MattingPreConstructionRequiredRepository>();

            services.AddTransient<IMENVCOCService, MENVCOCService>();
            services.AddTransient<IMENVCOCRepository, MENVCOCRepository>();

            services.AddTransient<IPRECONSTRUCTIONService, PRECONSTRUCIONService>();
            services.AddTransient<IPRECONSTRUCTIONRepository, PRECONSTRUCTIONRepository>();

            services.AddTransient<ICOMEDEXService, COMEDEXService>();
            services.AddTransient<ICOMEDEXRepository, COMEDEXRepository>();

            services.AddTransient<IIFCDATESService, IFCDATESService>();
            services.AddTransient<IIFCDATESRepository, IFCDATESRepository>();


            services.AddTransient<IMCOCMASTERService, MCOCMASTERService>();
            services.AddTransient<IMCOCMASTERRepository, MCOCMASTERRepository>();

            services.AddTransient<IMCOCTYPEMASTERService, MCOCTYPEMASTERService>();
            services.AddTransient<IMCOCTYPEMASTERRepository, MCOCTYPEMASTERRepository>();

            services.AddTransient<IBORINGService, BORINGService>();
            services.AddTransient<IBORINGRepository, BORINGRepository>();

            services.AddTransient<ICIVILService, CIVILService>();
            services.AddTransient<ICIVILRepository, CIVILRepository>();

            services.AddTransient<IFIBERService, FIBERService>();
            services.AddTransient<IFIBERRepository, FIBERRepository>();

            services.AddTransient<IOVHDMKService, OVHDMKService>();
            services.AddTransient<IOVHDMKRepository, OVHDMKRepository>();

            services.AddTransient<IPostCompletionService, PostCompletionService>();
            services.AddTransient<IPostCompletionRepository, PostCompletionRepository>();

            services.AddTransient<IIfaFiberService, IfaFiberService>();
            services.AddTransient<IIfaFiberRepository, IfaFiberRepository>();

            services.AddTransient<IIfcFiberService, IfcFiberService>();
            services.AddTransient<IIFCFIBERRepository, IfcFiberRepository>();

            services.AddTransient<IHutExecutionService, HutExecutionService>();
            services.AddTransient<IHutExecutionRepository, HutExecutionRepository>();

            services.AddTransient<IHutExPhaseOneService, HutExPhaseOneService>();
            services.AddTransient<IHutExPhaseOneRepository, HutExPhaseOneRepository>();

            services.AddTransient<IHutExPowPhaseThreeService, HutExPowPhaseThreeService>();
            services.AddTransient<IHutExPowPhaseThreeRepository, HutExPowPhaseThreeRepository>();

            services.AddTransient<IHutExAuxPowerPhaseTwoService, HutExAuxPowerPhaseTwoService>();
            services.AddTransient<IHutExAuxPowerPhaseTwoRepository, HutExAuxPowerPhaseTwoRepository>();

            services.AddTransient<IHutExCivilPhaseThreeService, HutExCivilPhaseThreeService>();
            services.AddTransient<IHutExCivilPhaseThreeRepository, HutExCivilPhaseThreeRepository>();

            services.AddTransient<IHutExCVSubgradePhaseTwoService, HutExCVSubgradePhaseTwoService>();
            services.AddTransient<IHutExCVSubgradePhaseTwoRepository, HutExCVSubgradePhaseTwoRepository>();

            services.AddTransient<IHutExFiberPhaseThreeService, HutExFiberPhaseThreeService>();
            services.AddTransient<IHutExFiberPhaseThreeRepository, HutExFiberPhaseThreeRepository>();

            services.AddTransient<IHutExRnPPhaseThreeService, HutExRnPPhaseThreeService>();
            services.AddTransient<IHutExRnPPhaseThreeRepository, HutExRnPPhaseThreeRepository>();

            services.AddTransient<IHutExRnPPhaseTwoService, HutExRnPPhaseTwoService>();
            services.AddTransient<IHutExRnPPhaseThreeRepository, HutExRnPPhaseThreeRepository>();

            services.AddTransient<IHutExRnPPhaseTwoService, HutExRnPPhaseTwoService>();
            services.AddTransient<IHutExRnPPhaseTwoRepository, HutExRnPPhaseTwoRepository>();

            services.AddTransient<IHutExTestingService, HutExTestingService>();
            services.AddTransient<IHutExTestingRepository, HutExTestingRepository>();

            services.AddTransient<IHutExRouterUpgradePhaseThreeService, HutExRouterUpgradePhaseThreeService>();
            services.AddTransient<IHutExRouterUpgradePhaseThreeRepository, HutExRouterUpgradePhaseThreeRepository>();

            services.AddTransient<IMPhaseService,MPhaseService>();
            services.AddTransient<IMPhaseRepository, MPhaseRepository>();

            services.AddTransient<IPDDetailsService, PDDetailsService>();
            services.AddTransient<IPDRepositories, PDDetailsRepositories>();

            services.AddTransient<ICompletedPoleMileService,CompletedPoleMileService>();
            services.AddTransient<ICompletedPoleAndMile, CompletedPoleAndMileRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();


            app.UseCors(builder => builder
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
            
            
            
            app.UseAuthorization();

            

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
