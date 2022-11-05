using Exelon.Domain;
using Exelon.Domain.Abstractions;
using Exelon.Domain.Common;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Exelon.Infrastructure.Repositories
{
    public class FIBERRepository : IFIBERRepository
    {
        private readonly string _connectionString;
        private readonly string _storedProcedure = "dbo.spFIBERActions";

        public FIBERRepository(IAppSettings appSettings)
        {
            _connectionString = appSettings.GetConnectionString();
        }

        private object checkNull(object value)
        {
            if (value == null)
                return DBNull.Value;

            return value;
        }

        private object checkNullWithValue(object Value, object changeValue)
        {
            if (Value == null && changeValue == null)
                return DBNull.Value;
            else if (Value == null)
                return changeValue;
            return Value;
        }

        public async Task<List<FIBERModel>> GetFIBER(int id = 0)
        {
            return await Task.Run(() =>
            {
                var result = new List<FIBERModel>();
                try
                {
                    using (SqlConnection connection = new SqlConnection(this._connectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.CommandText = _storedProcedure;
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@FiberID", id);
                            cmd.Parameters.AddWithValue("@FK_LinkingID", 0);
                            cmd.Parameters.AddWithValue("@FK_stepID", 0);
                            cmd.Parameters.AddWithValue("@FK_FiberCOCID", 0);
                            cmd.Parameters.AddWithValue("@IssuesOrComments", string.Empty);
                            cmd.Parameters.AddWithValue("@StartDate", DBNull.Value);
                            cmd.Parameters.AddWithValue("@EndDate", DBNull.Value);
                            cmd.Parameters.AddWithValue("@WeeklyFTECount", string.Empty);
                            cmd.Parameters.AddWithValue("@OTDRCompletionDate", DBNull.Value);
                            cmd.Parameters.AddWithValue("@CreatedBy", string.Empty);
                            cmd.Parameters.AddWithValue("@updatedBy", string.Empty);
                            cmd.Connection = connection;
                            connection.Open();

                            if (id == 0)
                                cmd.Parameters.AddWithValue("@procId", 4);
                            else
                                cmd.Parameters.AddWithValue("@procId", 5);

                            using (SqlDataReader dataReader = cmd.ExecuteReader())
                            {
                                while (dataReader.Read())
                                {
                                    var onlyDate = "MM'/'dd'/'yyyy";
                                    var dateWithTime = "MM'/'dd'/'yyyy h:mm tt";
                                    var fiber = new FIBERModel();
                                    fiber.FiberID = (long)dataReader["FiberID"];
                                    fiber.FK_LinkingID = (long)dataReader["FK_LinkingID"];
                                    fiber.FK_stepID = (int)dataReader["FK_stepID"];
                                    if (dataReader["FK_FiberCOCID"] != DBNull.Value)
                                        fiber.FK_FiberCOCID = (int)dataReader["FK_FiberCOCID"];
                                    fiber.IssuesOrComments = dataReader["IssuesOrComments"].ToString();
                                    if (dataReader["StartDate"] != DBNull.Value)
                                        fiber.StartDate = Convert.ToDateTime(dataReader["StartDate"]);
                                    if (dataReader["EndDate"] != DBNull.Value)
                                        fiber.EndDate = Convert.ToDateTime(dataReader["EndDate"]);
                                    if (dataReader["OTDRCompletionDate"] != DBNull.Value)
                                        fiber.OTDRCompletionDate = Convert.ToDateTime(dataReader["OTDRCompletionDate"]);
                                    if (dataReader["StartDate"] != DBNull.Value)
                                        fiber.StrStartDate = Convert.ToDateTime(dataReader["StartDate"]).ToString(onlyDate);
                                    if (dataReader["EndDate"] != DBNull.Value)
                                        fiber.StrEndDate = Convert.ToDateTime(dataReader["EndDate"]).ToString(onlyDate);
                                    if (dataReader["OTDRCompletionDate"] != DBNull.Value)
                                        fiber.StrOTDRCompletionDate = Convert.ToDateTime(dataReader["OTDRCompletionDate"]).ToString(onlyDate);
                                    fiber.WeeklyFTECount = dataReader["WeeklyFTECount"].ToString();
                                    fiber.IsActive = Convert.ToBoolean(dataReader["IsActive"]);
                                    fiber.CreatedBy = dataReader["CreatedBy"].ToString();
                                    fiber.CreatedDate = Convert.ToDateTime(dataReader["CreatedDate"]).ToString(dateWithTime);
                                    fiber.UpdatedBy = dataReader["UpdatedBy"].ToString();
                                    fiber.UpdatedDate = Convert.ToDateTime(dataReader["UpdatedDate"]).ToString(dateWithTime);
                                    result.Add(fiber);
                                }
                            }


                            connection.Close();
                            return result;


                        }
                    }
                }
                catch (Exception ex) { return new List<FIBERModel>(); }
            });
        }


        public async Task<Dictionary<FIBERModel, string>> CreateFIBER(FIBERModel fIBERModel)
        {
            return await Task.Run(() =>
            {
                var result = new Dictionary<FIBERModel, string>();
                try
                {
                    using (SqlConnection connection = new SqlConnection(this._connectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.CommandText = _storedProcedure;
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@procId", 6);
                            cmd.Parameters.AddWithValue("@FiberID", fIBERModel.FiberID);
                            cmd.Parameters.AddWithValue("@FK_LinkingID", fIBERModel.FK_LinkingID);
                            cmd.Parameters.AddWithValue("@FK_stepID", fIBERModel.FK_stepID);
                            cmd.Parameters.AddWithValue("@FK_FiberCOCID",checkNull(fIBERModel.FK_FiberCOCID));
                            cmd.Parameters.AddWithValue("@IssuesOrComments", string.IsNullOrEmpty(fIBERModel.IssuesOrComments) ? string.Empty : fIBERModel.IssuesOrComments);
                            cmd.Parameters.AddWithValue("@StartDate",checkNull(fIBERModel.StartDate));
                            cmd.Parameters.AddWithValue("@EndDate",checkNull(fIBERModel.EndDate));
                            cmd.Parameters.AddWithValue("@OTDRCompletionDate",checkNull(fIBERModel.OTDRCompletionDate));
                            cmd.Parameters.AddWithValue("@WeeklyFTECount", string.IsNullOrEmpty(fIBERModel.WeeklyFTECount) ? string.Empty : fIBERModel.WeeklyFTECount);
                            cmd.Parameters.AddWithValue("@CreatedBy", fIBERModel.CreatedBy);
                            cmd.Parameters.AddWithValue("@UpdatedBy", fIBERModel.CreatedBy);
                            cmd.Connection = connection;
                            connection.Open();
                            int check = (int)cmd.ExecuteScalar();
                            if (check == 1)
                            {
                                cmd.Parameters["@procId"].Value = 1;
                            }
                            else
                            {
                                connection.Close();
                                result[fIBERModel] = "Linking Id Already Exists!";
                                return result;
                            }
                            fIBERModel.FiberID = (long)cmd.ExecuteScalar();
                            result[fIBERModel] = "ok";
                            connection.Close();
                            return result;

                        }
                    }
                }
                catch (Exception ex) { return new Dictionary<FIBERModel, string>(); }
            });
        }

        public async Task<FIBERModel> UpdateFIBER(FIBERModel fIBERModel)
        {
            return await Task.Run(() =>
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(this._connectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.CommandText = _storedProcedure;
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@procId", 2);
                            cmd.Parameters.AddWithValue("@FiberID", fIBERModel.FiberID);
                            cmd.Parameters.AddWithValue("@FK_LinkingID", fIBERModel.FK_LinkingID);
                            cmd.Parameters.AddWithValue("@FK_stepID", fIBERModel.FK_stepID);
                            cmd.Parameters.AddWithValue("@FK_FiberCOCID", checkNull(fIBERModel.FK_FiberCOCID));
                            cmd.Parameters.AddWithValue("@IssuesOrComments", string.IsNullOrEmpty(fIBERModel.IssuesOrComments) ? string.Empty : fIBERModel.IssuesOrComments);
                            cmd.Parameters.AddWithValue("@StartDate", checkNull(fIBERModel.StartDate));
                            cmd.Parameters.AddWithValue("@EndDate", checkNull(fIBERModel.EndDate));
                            cmd.Parameters.AddWithValue("@OTDRCompletionDate", checkNull(fIBERModel.OTDRCompletionDate));
                            cmd.Parameters.AddWithValue("@WeeklyFTECount", string.IsNullOrEmpty(fIBERModel.WeeklyFTECount) ? string.Empty : fIBERModel.WeeklyFTECount);
                            cmd.Parameters.AddWithValue("@CreatedBy", string.Empty);
                            cmd.Parameters.AddWithValue("@UpdatedBy", fIBERModel.UpdatedBy);
                            cmd.Connection = connection;
                            connection.Open();
                            cmd.ExecuteNonQuery();
                            connection.Close();
                            return fIBERModel;
                        }
                    }
                }
                catch (Exception ex) { return new FIBERModel(); }
            });
        }


        public async Task<int> DeleteFIBER(int id)
        {
            return await Task.Run(() =>
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(this._connectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.CommandText = _storedProcedure;
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@procId", 3);
                            cmd.Parameters.AddWithValue("@FiberID", id);
                            cmd.Parameters.AddWithValue("@FK_LinkingID", 0);
                            cmd.Parameters.AddWithValue("@FK_stepID", 0);
                            cmd.Parameters.AddWithValue("@FK_FiberCOCID", 0);
                            cmd.Parameters.AddWithValue("@IssuesOrComments", string.Empty);
                            cmd.Parameters.AddWithValue("@StartDate", DBNull.Value);
                            cmd.Parameters.AddWithValue("@EndDate", DBNull.Value);
                            cmd.Parameters.AddWithValue("@WeeklyFTECount", string.Empty);
                            cmd.Parameters.AddWithValue("@OTDRCompletionDate", DBNull.Value);
                            cmd.Parameters.AddWithValue("@CreatedBy", string.Empty);
                            cmd.Parameters.AddWithValue("@updatedBy", string.Empty);
                            cmd.Connection = connection;
                            connection.Open();
                            cmd.ExecuteScalar();
                            connection.Close();
                            return 1;
                        }
                    }
                }
                catch (Exception ex) { return 0; }
            });
        }

        #region [Execution Completed Fiber Miles]
        #region [Get Completed Fiber Miles]
        /// <summary>
        /// Get Execution Device
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ExecutionCompletedFiberMile> GetCompletedFiberMileById(int id)
        {
            return await Task.Run(() =>
            {
                var model = new ExecutionCompletedFiberMile();
                try
                {
                    using (SqlConnection connection = new SqlConnection(this._connectionString))
                    {
                        connection.Open();
                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.CommandText = "sp_ExeCompletedFiberMileActions";
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@procId", 3);
                            cmd.Parameters.AddWithValue("@completedFiberMilesId", id);
                            cmd.Parameters.AddWithValue("@executionLinkingId", 0);
                            cmd.Parameters.AddWithValue("@fiberMilesInstalled", 0);
                            cmd.Parameters.AddWithValue("@fiberMilesCompleted", 0);
                            cmd.Parameters.AddWithValue("@createdBy", string.Empty);
                            cmd.Parameters.AddWithValue("@updatedBy", string.Empty);
                            cmd.Connection = connection;

                            using (SqlDataReader dataReader = cmd.ExecuteReader())
                            {
                                while (dataReader.Read())
                                {
                                    model.CompletedFiberMileId = (Int64)dataReader["CompletedFiberMileID"];
                                    model.ExecutionLinkingId = (Int64)dataReader["ExecutionLinkingID"];
                                    model.FiberMilesInstalled = (int)dataReader["FiberMilesInstalled"];
                                    model.FiberMilesCompleted = (int)dataReader["FiberMilesCompleted"];
                                    model.CreatedBy = dataReader["CreatedBy"].ToString();
                                    model.UpdatedBy = dataReader["UpdatedBy"].ToString();
                                }
                            }
                        }
                        connection.Close();
                    }
                    return model;
                }
                catch (Exception){
                    return new ExecutionCompletedFiberMile(); 
                }
            });
        }
        #endregion

        #region [Save Update Completed Fiber Mile]
        /// <summary>
        /// Save Update Completed Fiber Mile
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<ExecutionCompletedFiberMile> SaveUpdateCompletedFiberMile(ExecutionCompletedFiberMile model)
        {
            return await Task.Run(() =>
            {
                var result = new ExecutionCompletedFiberMile();
                try
                {
                    using (SqlConnection connection = new SqlConnection(this._connectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.CommandText = "sp_ExeCompletedFiberMileActions";
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            if (model.CompletedFiberMileId == 0)
                                cmd.Parameters.AddWithValue("@procId", 1);
                            else if (model.CompletedFiberMileId > 0)
                                cmd.Parameters.AddWithValue("@procId", 2);
                            cmd.Parameters.AddWithValue("@completedFiberMilesId", model.CompletedFiberMileId);
                            cmd.Parameters.AddWithValue("@executionLinkingId", model.ExecutionLinkingId);
                            cmd.Parameters.AddWithValue("@fiberMilesInstalled", model.FiberMilesInstalled);
                            cmd.Parameters.AddWithValue("@fiberMilesCompleted", model.FiberMilesCompleted);
                            cmd.Parameters.AddWithValue("@createdBy", model.CreatedBy);
                            cmd.Parameters.AddWithValue("@updatedBy", model.CreatedBy);
                            cmd.Connection = connection;
                            connection.Open();
                            result.CompletedFiberMileId = (Int64)cmd.ExecuteScalar();
                            connection.Close();
                            return result;
                        }
                    }
                }
                catch (Exception ex)
                {
                    return new ExecutionCompletedFiberMile();}
            });
        }
        #endregion
        #endregion
    }
}
