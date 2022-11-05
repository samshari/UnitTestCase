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
                            cmd.Parameters.AddWithValue("@executionDeviceId", id);
                            cmd.Parameters.AddWithValue("@executionLinkingId", 0);
                            cmd.Parameters.AddWithValue("@installedDevices", 0);
                            cmd.Parameters.AddWithValue("@CreatedBy", string.Empty);
                            cmd.Parameters.AddWithValue("@UpdatedBy", string.Empty);
                            cmd.Connection = connection;

                            using (SqlDataReader dataReader = cmd.ExecuteReader())
                            {
                                while (dataReader.Read())
                                {
                                    var model = new CompletedPoleAndMile();
                                    model.CompletedPoleMileId = (Int64)dataReader["CompletedPoleMileID"];
                                    model.ExecutionLinkingId = (Int64)dataReader["ExecutionLinkidID"];
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

        #region [Save Update Completed Pole Mile]
        /// <summary>
        /// Save Update Completed Pole Mile
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<CompletedPoleAndMile> SaveUpdateCompletedPoleMile(CompletedPoleAndMile model)
        {
            return await Task.Run(() =>
            {
                var result = new CompletedPoleAndMile();
                try
                {
                    using (SqlConnection connection = new SqlConnection(this._connectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.CommandText = _storedProcedure;
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            if (model.CompletedPoleMileId == 0)
                                cmd.Parameters.AddWithValue("@procId", 1);
                            else if (model.CompletedPoleMileId > 0)
                                cmd.Parameters.AddWithValue("@procId", 2);

                            cmd.Parameters.AddWithValue("@completedPloeMilesId", model.CompletedPoleMileId);
                            cmd.Parameters.AddWithValue("@executionLinkingId", model.ExecutionLinkingId);
                            cmd.Parameters.AddWithValue("@totalNumberOfPolesNeeded", model.TotalNoOfPolesNeeded);
                            cmd.Parameters.AddWithValue("@polesInstalled", model.PoleInstalled);
                            cmd.Parameters.AddWithValue("@ohMilesTotal", model.OHMilesTotal);
                            cmd.Parameters.AddWithValue("@makeReadyOHMilesCompleted", model.MakeReadyOHMilesCompleted);
                            cmd.Parameters.AddWithValue("@ugMilesTotal", model.UGMilesTotal);
                            cmd.Parameters.AddWithValue("@ugMilesCompleted", model.UGMilesTotal);
                            cmd.Parameters.AddWithValue("@createdBy", model.CreatedBy);
                            cmd.Parameters.AddWithValue("@updatedBy", model.CreatedBy);
                            cmd.Connection = connection;
                            connection.Open();
                            result.CompletedPoleMileId = (Int64)cmd.ExecuteScalar();
                            connection.Close();
                            return result;
                        }
                    }
                }
                catch (Exception) { return new CompletedPoleAndMile(); }
            });
        } 
        #endregion
    }
}
