using Exelon.Domain;
using Exelon.Domain.Abstractions;
using Exelon.Domain.Common;
using Exelon.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Exelon.Infrastructure.Repositories
{
    public class PDDetailsRepositories : IPDRepositories
    {
        private readonly string _connectionString;
        private readonly string _storedProcedureName = "dbo.sp_PDInformationActions";

        public PDDetailsRepositories(IAppSettings appSettings)
        {
            _connectionString = appSettings.GetConnectionString();
        }
        #region [Save PD Information]
        /// <summary>
        /// Save PD Information
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<PDDetailsModel> SavePDInformation(PDDetailsModel model)
        {
            return await Task.Run(() =>
            {
                var result = new PDDetailsModel();
                try
                {
                    using (SqlConnection con = new SqlConnection(this._connectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.CommandText = _storedProcedureName;
                            cmd.CommandType = CommandType.StoredProcedure;
                            if (model.PDInformationId == 0)
                                cmd.Parameters.AddWithValue("@procId", 1);
                            else if (model.PDInformationId > 0)
                                cmd.Parameters.AddWithValue("@procId", 2);
                            cmd.Parameters.AddWithValue("@pdInformationId", model.PDInformationId);
                            cmd.Parameters.AddWithValue("@yearId", model.FinancialYearId);
                            cmd.Parameters.AddWithValue("@projectName", model.ProjectName);
                            cmd.Parameters.AddWithValue("@itn", model.ITN);
                            cmd.Parameters.AddWithValue("@sr", model.SR);
                            cmd.Parameters.AddWithValue("@regionId", model.RegionId);
                            cmd.Parameters.AddWithValue("@barnId", model.BarnId);
                            cmd.Parameters.AddWithValue("@WorkOrder", model.WorkOrder);
                            cmd.Parameters.AddWithValue("@projectStatusId", model.ProjectStatusId);
                            cmd.Parameters.AddWithValue("@projectId", model.ProjectId);
                            cmd.Parameters.AddWithValue("@pdId", model.PDId);
                            cmd.Parameters.AddWithValue("@linkNickName", model.LinkNickName);
                            cmd.Parameters.AddWithValue("@jobStatus", model.JobStatus);
                            cmd.Parameters.AddWithValue("@ownerName", model.OwnerName);
                            cmd.Parameters.AddWithValue("@workOrderPriorityLevel", model.WorkOrderPriorityLevel);
                            if (model.WorkOrderDueDate == null)
                                cmd.Parameters.AddWithValue("@workOrderDueDate", DBNull.Value);
                            else
                                cmd.Parameters.AddWithValue("@workOrderDueDate", model.WorkOrderDueDate);
                            cmd.Parameters.AddWithValue("@priorityLevel", model.PriorityLevel);
                            cmd.Parameters.AddWithValue("@createdBy", model.CreatedBy);
                            cmd.Parameters.AddWithValue("@updatedBy", model.UpdatedBy);
                            cmd.Connection = con;
                            con.Open();
                            result.PDInformationId = (Int64)cmd.ExecuteScalar();
                            con.Close();
                            return result;
                        }
                    }
                }
                catch (Exception)
                {
                    return new PDDetailsModel();
                }
            });
        }
        #endregion

        #region [Get PD Information By Id]
        /// <summary>
        /// Get PD Information By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<PDDetailsModel> GetPDInformationById(int id = 0)
        {
            return await Task.Run(() =>
            {
                var result = new PDDetailsModel();
                try
                {
                    using (SqlConnection connection = new SqlConnection(this._connectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.CommandText = _storedProcedureName;
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@procId", 2);
                            cmd.Parameters.AddWithValue("@pdInformationId", id);
                            cmd.Parameters.AddWithValue("@yearId", 0);
                            cmd.Parameters.AddWithValue("@projectName", string.Empty);
                            cmd.Parameters.AddWithValue("@itn", 0);
                            cmd.Parameters.AddWithValue("@sr", string.Empty);
                            cmd.Parameters.AddWithValue("@regionId", 0);
                            cmd.Parameters.AddWithValue("@barnId", 0);
                            cmd.Parameters.AddWithValue("@WorkOrder", string.Empty);
                            cmd.Parameters.AddWithValue("@projectStatusId", 0);
                            cmd.Parameters.AddWithValue("@projectId", string.Empty);
                            cmd.Parameters.AddWithValue("@pdId", 0);
                            cmd.Parameters.AddWithValue("@linkNickName", string.Empty);
                            cmd.Parameters.AddWithValue("@jobStatus", string.Empty);
                            cmd.Parameters.AddWithValue("@ownerName", string.Empty);
                            cmd.Parameters.AddWithValue("@workOrderDueDate", DateTime.Now);
                            cmd.Parameters.AddWithValue("@priorityLevel", string.Empty);
                            cmd.Parameters.AddWithValue("@createdBy", string.Empty);
                            cmd.Parameters.AddWithValue("@updatedBy", string.Empty);
                            cmd.Connection = connection;
                            connection.Open();

                            using (SqlDataReader dataReader = cmd.ExecuteReader())
                            {
                                while (dataReader.Read())
                                {
                                    var model = new PDDetailsModel();
                                    model.BarnId = (int)dataReader["BarnID"];
                                    model.FinancialYearId = (int)dataReader["FinancialYearID"];
                                    model.ITN = (int)dataReader["ITN"];
                                    model.JobStatus = dataReader["JobStatus"].ToString();
                                    model.LinkNickName = (int)dataReader["LinkNickName"];
                                    model.OwnerName = dataReader["OwnerName"].ToString();
                                    model.PDId = (int)dataReader["PDId"];
                                    model.PDInformationId = (int)dataReader["PDInformationId"];
                                    model.PriorityLevel = dataReader["PriorityLevel"].ToString();
                                    model.ProjectId = dataReader["ProjectId"].ToString();
                                    model.ProjectName = dataReader["ProjectName"].ToString();
                                    model.ProjectStatusId = (int)dataReader["ProjectStatusId"];
                                    model.RegionId = (int)dataReader["RegionId"];
                                    model.SR = (int)dataReader["SR"];
                                    model.WorkOrder = dataReader["WorkOrder"].ToString();
                                    model.WorkOrderDueDate = (DateTime)dataReader["WorkOrderDueDate"];
                                    model.WorkOrderPriorityLevel = dataReader["WorkOrderPriorityLevel"].ToString();
                                }
                            }
                            connection.Close();
                        }
                    }
                    return result;
                }
                catch (Exception) { return new PDDetailsModel(); }
            });
        }
        #endregion

        #region [Get PD EOC By Id]
        /// <summary>
        /// Get PD EOC By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<PDEOCModel> GetPDEOCById(int id = 0)
        {
            return await Task.Run(() =>
            {
                var result = new PDEOCModel();
                try
                {
                    using (SqlConnection connection = new SqlConnection(this._connectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.CommandText = "sp_PdEOCActions";
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@procId", 3);
                            cmd.Parameters.AddWithValue("@pdEOCId", 0);
                            cmd.Parameters.AddWithValue("@pdInformationId", 0);
                            cmd.Parameters.AddWithValue("@eOCId", 0);
                            cmd.Parameters.AddWithValue("@eOCReleaseDate", DateTime.Now);
                            cmd.Parameters.AddWithValue("@createdBy", string.Empty);
                            cmd.Parameters.AddWithValue("@updatedBy", string.Empty);
                            cmd.Connection = connection;
                            connection.Open();

                            using (SqlDataReader dataReader = cmd.ExecuteReader())
                            {
                                while (dataReader.Read())
                                {
                                    var model = new PDEOCModel();
                                    model.PDEOCId = (Int64)dataReader["PDEOCID"];
                                    model.PDInformationId = (Int64)dataReader["PDInformationID"];
                                    model.EOCId = (int)dataReader["EOCID"];
                                    model.EOCReleaseDate = Convert.ToDateTime(dataReader["EOCReleaseDate"]);
                                    result = model;
                                }
                            }
                            connection.Close();
                        }
                    }
                    return result;
                }
                catch (Exception) { return new PDEOCModel(); }
            });
        }
        #endregion

        #region [Save PD EOC]
        /// <summary>
        /// Save PD EOC
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<PDEOCModel> SaveUpdatePDEOC(PDEOCModel model)
        {
            return await Task.Run(() =>
            {
                var result = new PDEOCModel();
                try
                {
                    using (SqlConnection con = new SqlConnection(this._connectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.CommandText = "dbo.sp_PdEOCActions";
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@procId", 1);
                            cmd.Parameters.AddWithValue("@pdEOCId", 0);
                            cmd.Parameters.AddWithValue("@pdInformationId", model.PDInformationId);
                            cmd.Parameters.AddWithValue("@eOCId", model.EOCId);
                            cmd.Parameters.AddWithValue("@eOCReleaseDate", model.EOCReleaseDate);
                            cmd.Parameters.AddWithValue("@createdBy", model.CreatedBy);
                            cmd.Parameters.AddWithValue("@updatedBy", model.UpdatedBy);
                            cmd.Connection = con;
                            con.Open();
                            con.Close();
                            result.PDEOCId = (int)cmd.ExecuteScalar();
                            return result;
                        }
                    }
                }
                catch (Exception) { return new PDEOCModel(); }
            });
        }
        #endregion

        #region [Get PD COC By Id]
        /// <summary>
        /// Get PD COC By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<PDCOCModel> GetPDCOCById(int id = 0)
        {
            return await Task.Run(() =>
            {
                var result = new PDCOCModel();
                try
                {
                    using (SqlConnection connection = new SqlConnection(this._connectionString))
                    {
                        connection.Open();
                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.CommandText = "sp_PdCOCActions";
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            cmd.Parameters.Add("@procID", SqlDbType.Int);
                            cmd.Parameters.AddWithValue("@pdCOCID", id);
                            cmd.Parameters.AddWithValue("@pdInformationID", 0);
                            cmd.Parameters.AddWithValue("@ohFiberCOC", string.Empty);
                            cmd.Parameters.AddWithValue("@ugFiberCOC", string.Empty);
                            cmd.Parameters.AddWithValue("@createdBy", string.Empty);
                            cmd.Parameters.AddWithValue("@updatedBy", string.Empty);
                            cmd.Connection = connection;

                            using (SqlDataReader dataReader = cmd.ExecuteReader())
                            {
                                while (dataReader.Read())
                                {
                                    var model = new PDCOCModel();
                                    model.PDCOCId = (int)dataReader["PDCOCID"];
                                    model.PDInformationId = (long)dataReader["PDInformationID"];
                                    model.OHFiberCOC = dataReader["Description"].ToString();
                                    model.UGFiberCOC = Convert.ToString(dataReader["UGFiberCOC"]);
                                    result = model;
                                }
                            }
                            connection.Close();
                        }
                    }
                    return result;
                }
                catch (Exception) { return new PDCOCModel(); }
            });
        }
        #endregion

        #region [Save PD COC]
        /// <summary>
        /// Save PD COC
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<PDCOCModel> SaveUpdatePDCOC(PDCOCModel model)
        {
            return await Task.Run(() =>
            {
                var result = new PDCOCModel();
                try
                {
                    using (SqlConnection con = new SqlConnection(this._connectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.CommandText = "dbo.sp_PdCOCActions";
                            cmd.CommandType = CommandType.StoredProcedure;
                            if (model.PDCOCId == 0)
                                cmd.Parameters.AddWithValue("@procId", 1);
                            else if (model.PDCOCId > 0)
                                cmd.Parameters.AddWithValue("@procId", 2);
                            cmd.Parameters.AddWithValue("@pdCOCID", model.PDCOCId);
                            cmd.Parameters.AddWithValue("@pdInformationID", model.PDInformationId);
                            cmd.Parameters.AddWithValue("@ohFiberCOC", model.OHFiberCOC);
                            cmd.Parameters.AddWithValue("@ugFiberCOC", model.UGFiberCOC);
                            cmd.Parameters.AddWithValue("@createdBy", model.CreatedBy);
                            cmd.Parameters.AddWithValue("@updatedBy", model.UpdatedBy);
                            cmd.Connection = con;
                            con.Open();
                            con.Close();
                            result.PDCOCId = (int)cmd.ExecuteScalar();
                            return result;
                        }
                    }
                }
                catch (Exception) { return new PDCOCModel(); }
            });
        }
        #endregion

        #region [Get PD Fiber By Id]
        /// <summary>
        /// Get PD Fiber By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<PDFiberModel> GetPDFiberById(int id = 0)
        {
            return await Task.Run(() =>
            {
                var result = new PDFiberModel();
                try
                {
                    using (SqlConnection connection = new SqlConnection(this._connectionString))
                    {
                        connection.Open();
                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.CommandText = "sp_PdFiberActions";
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@procId", 3);
                            cmd.Parameters.AddWithValue("@pdFiberId", id);
                            cmd.Parameters.AddWithValue("@pdInformationId", 0);
                            cmd.Parameters.AddWithValue("@fiberCount", 0);
                            cmd.Parameters.AddWithValue("@pdIFA", DateTime.Now);
                            cmd.Parameters.AddWithValue("@pdIFC", DateTime.Now);
                            cmd.Parameters.AddWithValue("@milesOH", 0M);
                            cmd.Parameters.AddWithValue("@milesUG", 0M);
                            cmd.Parameters.AddWithValue("@fiberOpticHutSize", string.Empty);
                            cmd.Parameters.AddWithValue("@createdBy", string.Empty);
                            cmd.Parameters.AddWithValue("@updatedBy", string.Empty);
                            cmd.Connection = connection;

                            using (SqlDataReader dataReader = cmd.ExecuteReader())
                            {
                                while (dataReader.Read())
                                {
                                    var model = new PDFiberModel();
                                    model.PDFiberId = (long)dataReader["PDFiberID"];
                                    model.PDInformationId = (long)dataReader["PDInformationID"];
                                    model.FiberCount = (int)dataReader["FiberCount"];
                                    model.PDIFA = Convert.ToDateTime(dataReader["PDIFA"]);
                                    model.PDIFC = Convert.ToDateTime(dataReader["PDIFC"]);
                                    model.MilesOH = (decimal)dataReader["MilesOH"];
                                    model.MilesUG = (decimal)dataReader["MilesUG"];
                                    model.FiberOpticHutSize = dataReader["FiberOpticHutSize"].ToString();
                                    result = model;
                                }
                            }

                        }
                        connection.Close();
                    }
                    return result;
                }
                catch (Exception) { return new PDFiberModel(); }
            });
        }
        #endregion

        #region [Save Update PD Fiber]
        /// <summary>
        /// Save Update PD Fiber
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<PDFiberModel> SaveUpdatePDFiber(PDFiberModel model)
        {
            return await Task.Run(() =>
            {
                var result = new PDFiberModel();
                try
                {
                    using (SqlConnection con = new SqlConnection(this._connectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.CommandText = "dbo.sp_PdFiberActions";
                            cmd.CommandType = CommandType.StoredProcedure;
                            if (model.PDFiberId == 0)
                                cmd.Parameters.AddWithValue("@procId", 1);
                            else if (model.PDFiberId > 0)
                                cmd.Parameters.AddWithValue("@procId", 2);
                            cmd.Parameters.AddWithValue("@pdFiberId", model.PDFiberId);
                            cmd.Parameters.AddWithValue("@pdInformationId", model.PDInformationId);
                            cmd.Parameters.AddWithValue("@fiberCount", model.FiberCount);
                            cmd.Parameters.AddWithValue("@pdIFA", model.PDIFA);
                            cmd.Parameters.AddWithValue("@pdIFC", model.PDIFC);
                            cmd.Parameters.AddWithValue("@milesOH", model.MilesOH);
                            cmd.Parameters.AddWithValue("@milesUG", model.MilesUG);
                            cmd.Parameters.AddWithValue("@fiberOpticHutSize", model.FiberOpticHutSize);
                            cmd.Parameters.AddWithValue("@createdBy", model.CreatedBy);
                            cmd.Parameters.AddWithValue("@updatedBy", model.UpdatedBy);
                            cmd.Connection = con;
                            con.Open();
                            con.Close();
                            result.PDFiberId = (int)cmd.ExecuteScalar();
                            return result;
                        }
                    }
                }
                catch (Exception) { return new PDFiberModel(); }
            });
        }
        #endregion
    }
}
