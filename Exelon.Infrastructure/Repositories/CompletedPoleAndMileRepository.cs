using Exelon.Domain.Abstractions;
using Exelon.Domain.Common;
using Exelon.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Exelon.Infrastructure.Repositories
{
   public class CompletedPoleAndMileRepository:ICompletedPoleAndMile
    {
        private readonly string _connectionString;
        private readonly string _storedProcedure = "dbo.sp_ExeCompletedPoleAndMileActions";
        public CompletedPoleAndMileRepository(IAppSettings appSettings)
        {
            _connectionString = appSettings.GetConnectionString();
        }

        #region [Get Completed Pole Mile By Id]
        /// <summary>
        /// Get Completed Pole Mile By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<CompletedPoleAndMile> GetCompletedPoleMileById(int id)
        {
            return await Task.Run(() =>
            {
                var result = new CompletedPoleAndMile();
                try
                {
                    using (SqlConnection connection = new SqlConnection(this._connectionString))
                    {
                        connection.Open();
                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.CommandText = _storedProcedure;
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@procId", 3);
                            cmd.Parameters.AddWithValue("@completedPloeMilesId", id);
                            cmd.Parameters.AddWithValue("@executionLinkingId", 0);
                            cmd.Parameters.AddWithValue("@totalNumberOfPolesNeeded", 0);
                            cmd.Parameters.AddWithValue("@polesInstalled", 0);
                            cmd.Parameters.AddWithValue("@ohMilesTotal", 0);
                            cmd.Parameters.AddWithValue("@makeReadyOHMilesCompleted", 0);
                            cmd.Parameters.AddWithValue("@ugMilesTotal", 0);
                            cmd.Parameters.AddWithValue("@ugMilesCompleted", 0);
                            cmd.Parameters.AddWithValue("@createdBy", "1");
                            cmd.Parameters.AddWithValue("@updatedBy", "1");
                            cmd.Connection = connection;

                            using (SqlDataReader dataReader = cmd.ExecuteReader())
                            {
                                while (dataReader.Read())
                                {
                                    var model = new CompletedPoleAndMile();
                                    model.CompletedPoleMileId = (Int64)dataReader["CompletedPoleMileID"];
                                    model.ExecutionLinkingId = (Int64)dataReader["ExecutionLinkingID"];
                                    model.TotalNoOfPolesNeeded = (int)dataReader["TotalNoOfPolesNeeded"];
                                    model.PoleInstalled = (int)dataReader["PoleInstalled"];
                                    model.OHMilesTotal = (int)dataReader["OHMilesTotal"];
                                    model.MakeReadyOHMilesCompleted = (int)dataReader["MakeReadyOHMilesCompleted"];
                                    model.UGMilesTotal = (int)dataReader["UGMilesTotal"];
                                    model.UGMilesCompleted = (int)dataReader["UGMilesCompleted"];
                                    model.CreatedBy = dataReader["CreatedBy"].ToString();
                                    model.UpdatedBy = dataReader["UpdatedBy"].ToString();
                                    result = model;
                                }
                            }
                        }
                        connection.Close();
                    }
                    return result;
                }
                catch (Exception) { return new CompletedPoleAndMile(); }
            });
        }
        #endregion

        #region [Get Completed Pole Mile By Link Id]
        /// <summary>
        /// Get Completed Pole Mile By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<CompletedPoleAndMile> GetCompletedPoleMileByLinkId(int id)
        {
            return await Task.Run(() =>
            {
                var result = new CompletedPoleAndMile();
                try
                {
                    using (SqlConnection connection = new SqlConnection(this._connectionString))
                    {
                        connection.Open();
                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.CommandText = _storedProcedure;
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@procId", 4);
                            cmd.Parameters.AddWithValue("@completedPloeMilesId", 0);
                            cmd.Parameters.AddWithValue("@executionLinkingId", id);
                            cmd.Parameters.AddWithValue("@totalNumberOfPolesNeeded", 0);
                            cmd.Parameters.AddWithValue("@polesInstalled", 0);
                            cmd.Parameters.AddWithValue("@ohMilesTotal", 0);
                            cmd.Parameters.AddWithValue("@makeReadyOHMilesCompleted", 0);
                            cmd.Parameters.AddWithValue("@ugMilesTotal", 0);
                            cmd.Parameters.AddWithValue("@ugMilesCompleted", 0);
                            cmd.Parameters.AddWithValue("@createdBy", "1");
                            cmd.Parameters.AddWithValue("@updatedBy", "1"); 
                            cmd.Connection = connection;

                            using (SqlDataReader dataReader = cmd.ExecuteReader())
                            {
                                while (dataReader.Read())
                                {
                                    var model = new CompletedPoleAndMile();
                                    model.CompletedPoleMileId = (Int64)dataReader["CompletedPoleMileID"];
                                    model.ExecutionLinkingId = (Int64)dataReader["ExecutionLinkingID"];
                                    model.TotalNoOfPolesNeeded = (int)dataReader["TotalNoOfPolesNeeded"];
                                    model.PoleInstalled = (int)dataReader["PoleInstalled"];
                                    model.OHMilesTotal = (int)dataReader["OHMilesTotal"];
                                    model.MakeReadyOHMilesCompleted = (int)dataReader["MakeReadyOHMilesCompleted"];
                                    model.UGMilesTotal = (int)dataReader["UGMilesTotal"];
                                    model.UGMilesCompleted = (int)dataReader["UGMilesCompleted"];
                                    model.CreatedBy = dataReader["CreatedBy"].ToString();
                                    model.UpdatedBy = dataReader["UpdatedBy"].ToString();
                                    result = model;
                                }
                            }
                        }
                        connection.Close();
                    }
                    return result;
                }
                catch (Exception ex) { return new CompletedPoleAndMile(); }
            });
        }
        #endregion

        #region [Save Update Completed Pole Mile]
        /// <summary>
        /// Save Update Completed Pole Mile
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<Dictionary<CompletedPoleAndMile,string>> SaveUpdateCompletedPoleMile(CompletedPoleAndMile model)
        {
            return await Task.Run(() =>
            {
                var result = new Dictionary<CompletedPoleAndMile, string>();
                try
                {
                    using (SqlConnection connection = new SqlConnection(this._connectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.CommandText = _storedProcedure;
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@procId", 5);
                            cmd.Parameters.AddWithValue("@completedPloeMilesId", model.CompletedPoleMileId);
                            cmd.Parameters.AddWithValue("@executionLinkingId", model.ExecutionLinkingId);
                            cmd.Parameters.AddWithValue("@totalNumberOfPolesNeeded", model.TotalNoOfPolesNeeded);
                            cmd.Parameters.AddWithValue("@polesInstalled", model.PoleInstalled);
                            cmd.Parameters.AddWithValue("@ohMilesTotal", model.OHMilesTotal);
                            cmd.Parameters.AddWithValue("@makeReadyOHMilesCompleted", model.MakeReadyOHMilesCompleted);
                            cmd.Parameters.AddWithValue("@ugMilesTotal", model.UGMilesTotal);
                            cmd.Parameters.AddWithValue("@ugMilesCompleted", model.UGMilesCompleted);
                            cmd.Parameters.AddWithValue("@createdBy", model.CreatedBy);
                            cmd.Parameters.AddWithValue("@updatedBy", model.CreatedBy);
                            cmd.Connection = connection;
                            connection.Open();
                            int check = (int)cmd.ExecuteScalar();
                            if(check == 1)
                            {
                                cmd.Parameters["@procId"].Value = 1;
                            }
                            else
                            {
                                connection.Close();
                                result[model] = "Linking Id Already Exists!";
                                return result;
                            }
                            model.CompletedPoleMileId = (long)cmd.ExecuteScalar();
                            connection.Close();
                            result[model] = "ok";
                            return result;
                        }
                    }
                }
                catch (Exception) { return new Dictionary<CompletedPoleAndMile, string>(); }
            });
        }
        #endregion
        #region [Save Update Completed Pole Mile]
        /// <summary>
        /// Save Update Completed Pole Mile
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<CompletedPoleAndMile> UpdateCompletedPoleMile(CompletedPoleAndMile model)
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
                            cmd.Parameters.AddWithValue("@completedPloeMilesId", model.CompletedPoleMileId);
                            cmd.Parameters.AddWithValue("@executionLinkingId", model.ExecutionLinkingId);
                            cmd.Parameters.AddWithValue("@totalNumberOfPolesNeeded", model.TotalNoOfPolesNeeded);
                            cmd.Parameters.AddWithValue("@polesInstalled", model.PoleInstalled);
                            cmd.Parameters.AddWithValue("@ohMilesTotal", model.OHMilesTotal);
                            cmd.Parameters.AddWithValue("@makeReadyOHMilesCompleted", model.MakeReadyOHMilesCompleted);
                            cmd.Parameters.AddWithValue("@ugMilesTotal", model.UGMilesTotal);
                            cmd.Parameters.AddWithValue("@ugMilesCompleted", model.UGMilesCompleted);
                            cmd.Parameters.AddWithValue("@createdBy", model.UpdatedBy);
                            cmd.Parameters.AddWithValue("@updatedBy", model.UpdatedBy);
                            cmd.Connection = connection;
                            connection.Open();
                            cmd.ExecuteNonQuery();
                            connection.Close();
                            return model;
                        }
                    }
                }
                catch (Exception) { return new CompletedPoleAndMile(); }
            });
        }
        #endregion
    }
}
