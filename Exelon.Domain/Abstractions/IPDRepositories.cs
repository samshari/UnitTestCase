using Exelon.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exelon.Domain.Abstractions
{
    public interface IPDRepositories
    {
        Task<PDDetailsModel> GetPDInformationById(int id = 0);
        Task<PDDetailsModel> SavePDInformation(PDDetailsModel model);
        Task<PDEOCModel> SaveUpdatePDEOC(PDEOCModel model);
        Task<PDEOCModel> GetPDEOCById(int id = 0);
        Task<PDCOCModel> SaveUpdatePDCOC(PDCOCModel model);
        Task<PDCOCModel> GetPDCOCById(int id = 0);
        Task<PDFiberModel> SaveUpdatePDFiber(PDFiberModel model);
        Task<PDFiberModel> GetPDFiberById(int id = 0);
    }
}
