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
    public class PerformProgressRepository : IPerformProgressRepository
    {
        private readonly string _connectionString;
        private readonly string _storedProcedure = "dbo.spPerformProgressData";
        public PerformProgressRepository(IAppSettings appSettings)
        {
            _connectionString = appSettings.GetConnectionString();
        }

        public async Task<List<PerformProgressModel>> GetPerformProgress(Int64 pdId, Int64 linkingId)
        {
            return await Task.Run(() =>
            {
                var result = new List<PerformProgressModel>();
                try
                {
                    using (SqlConnection connection = new SqlConnection(this._connectionString))
                    {
                        connection.Open();
                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.CommandText = _storedProcedure;
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@PROCID", 1);
                            cmd.Parameters.AddWithValue("@PDID", 0);
                            cmd.Parameters.AddWithValue("@LINKID", linkingId);
                            cmd.Parameters.AddWithValue("@WEEKLYDDATE", DateTime.Now);
                            cmd.Parameters.AddWithValue("@MILES", 0M);

                            using (SqlDataReader dataReader = cmd.ExecuteReader())
                            {
                                while (dataReader.Read())
                                {
                                    var model = new PerformProgressModel();
                                    model.PerformProgressId = (Int64)dataReader["ID"];
                                    model.PDId = (int)dataReader["PDID"];
                                    model.WeeklyDate = Convert.ToDateTime(dataReader["WeeklyDate"]);
                                    model.Miles = (decimal)dataReader["Link"];
                                    model.PDName = dataReader["PDName"].ToString();
                                    model.WorkOrder = dataReader["WorkOrder"].ToString();
                                    model.ProjectID = dataReader["ProjectID"].ToString();
                                    model.ProjectManager =dataReader["ProjectManager"].ToString();
                                    model.OHMiles = (decimal)dataReader["OHMiles"];
                                    model.UGMiles = (decimal)dataReader["UGMiles"];
                                    result.Add(model);
                                }
                            }
                        }
                        connection.Close();
                    }
                    return result;
                }
                catch (Exception) { return new List<PerformProgressModel>(); }
            });
        }

        public async Task<PerformProgressModel> SaveUpdatePerformProgress(PerformProgressModel model)
        {
            return await Task.Run(() =>
            {
                var result = new PerformProgressModel();
                try
                {
                    using (SqlConnection connection = new SqlConnection(this._connectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.CommandText = _storedProcedure;
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            if (model.PerformProgressId == 0)
                                cmd.Parameters.AddWithValue("@PROCID", 1);
                            cmd.Parameters.AddWithValue("@PDID", model.PDId);
                            cmd.Parameters.AddWithValue("@LINKID", model.LinkingId);
                            cmd.Parameters.AddWithValue("@WEEKLYDDATE", model.WeeklyDate);
                            cmd.Parameters.AddWithValue("@MILES", model.Miles);
                            cmd.Connection = connection;
                            connection.Open();
                            result.PerformProgressId = (Int64)cmd.ExecuteScalar();
                            connection.Close();
                            return result;
                        }
                    }
                }
                catch (Exception) { return new PerformProgressModel(); }
            });
        }
    }
}
