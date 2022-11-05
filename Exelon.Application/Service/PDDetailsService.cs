using Exelon.Application.IServices;
using Exelon.Domain.Abstractions;
using Exelon.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exelon.Application.Service
{
   public class PDDetailsService: IPDDetailsService
    {
        private readonly IPDRepositories pDRepositories;

        public PDDetailsService(IPDRepositories repositories)
        {
            pDRepositories = repositories;
        }

        public async Task<PDDetailsModel> SavePDInformation(PDDetailsModel model)
        {
            return await pDRepositories.SavePDInformation(model);
        }
        public async Task<PDDetailsModel> GetPDInformationById(int id = 0)
        {
            return await pDRepositories.GetPDInformationById(id);
        }
        public async Task<PDCOCModel> GetPDCOCById(int id = 0)
        {
            return await pDRepositories.GetPDCOCById(id);
        }
        public async Task<PDCOCModel> SaveUpdatePDCOC(PDCOCModel model)
        {
            return await pDRepositories.SaveUpdatePDCOC(model);
        }
        public async Task<PDEOCModel> GetPDEOCById(int id = 0)
        {
            return await pDRepositories.GetPDEOCById(id);
        }
        public async Task<PDEOCModel> SaveUpdatePDEOC(PDEOCModel model)
        {
            return await pDRepositories.SaveUpdatePDEOC(model);
        }
        public async Task<PDFiberModel> GetPDFiberById(int id = 0)
        {
            return await pDRepositories.GetPDFiberById(id);
        }
        public async Task<PDFiberModel> SaveUpdatePDFiber(PDFiberModel model)
        {
            return await pDRepositories.SaveUpdatePDFiber(model);
        }
    }
}
