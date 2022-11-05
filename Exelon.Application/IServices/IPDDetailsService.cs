using Exelon.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exelon.Application.IServices
{
   public interface IPDDetailsService
    {
        Task<PDDetailsModel> SavePDInformation(PDDetailsModel model);
        Task<PDDetailsModel> GetPDInformationById(int id = 0);
        Task<PDEOCModel> SaveUpdatePDEOC(PDEOCModel model);
        Task<PDEOCModel> GetPDEOCById(int id = 0);
        Task<PDCOCModel> SaveUpdatePDCOC(PDCOCModel model);
        Task<PDCOCModel> GetPDCOCById(int id = 0);
        Task<PDFiberModel> SaveUpdatePDFiber(PDFiberModel model);
        Task<PDFiberModel> GetPDFiberById(int id = 0);
    }
}
