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
    public class HutExRouterUpgradePhaseThreeRepository : IHutExRouterUpgradePhaseThreeRepository
    {
        private readonly string _connectionString;
        private readonly string _storedProcedure = "dbo.spHutExRouterUpgradePhaseThreeActions";


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

        public HutExRouterUpgradePhaseThreeRepository(IAppSettings appSettings)
        {
            _connectionString = appSettings.GetConnectionString();
        }


        public Task<List<HutExRouterUpgradePhaseThreeModel>> GetHutRouterP3(int id = 0)
        {
            return Task.Run(() =>
            {
                var result = new List<HutExRouterUpgradePhaseThreeModel>();
                try
                {
                    using (SqlConnection connection = new SqlConnection(this._connectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.CommandText = _storedProcedure;
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@RouterUpgradesPhase3ID", id);
                            cmd.Parameters.AddWithValue("@HutExecutionID", 0);
                            cmd.Parameters.AddWithValue("@RouterUpgradeStartDate", DBNull.Value);
                            cmd.Parameters.AddWithValue("@RouterUpgradeEndDate", DBNull.Value);
                            cmd.Parameters.AddWithValue("@createdBy", string.Empty);
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
                                    var hutrouter = new HutExRouterUpgradePhaseThreeModel();
                                    hutrouter.RouterUpgradesPhase3ID = (long)dataReader["RouterUpgradesPhase3ID"];
                                    hutrouter.HutExecutionID = (long)dataReader["HutExecutionID"];
                                    if (dataReader["RouterUpgradeStartDate"] != DBNull.Value)
                                        hutrouter.RouterUpgradeStartDate = Convert.ToDateTime(dataReader["RouterUpgradeStartDate"]);
                                    if (dataReader["RouterUpgradeEndDate"] != DBNull.Value)
                                        hutrouter.RouterUpgradeEndDate = Convert.ToDateTime(dataReader["RouterUpgradeEndDate"]);

                                    if (dataReader["RouterUpgradeStartDate"] != DBNull.Value)
                                        hutrouter.StrRouterUpgradeStartDate = Convert.ToDateTime(dataReader["RouterUpgradeStartDate"]).ToString(onlyDate);
                                    if (dataReader["RouterUpgradeEndDate"] != DBNull.Value)
                                        hutrouter.StrRouterUpgradeEndDate = Convert.ToDateTime(dataReader["RouterUpgradeEndDate"]).ToString(onlyDate);
                                    hutrouter.IsActive = Convert.ToBoolean(dataReader["IsActive"]);
                                    hutrouter.CreatedBy = dataReader["CreatedBy"].ToString();
                                    hutrouter.CreatedDate = Convert.ToDateTime(dataReader["CreatedDate"]).ToString(dateWithTime);
                                    hutrouter.UpdatedBy =   dataReader["UpdatedBy"].ToString();
                                    hutrouter.UpdatedDate = Convert.ToDateTime(dataReader["UpdatedDate"]).ToString(dateWithTime);
                                    result.Add(hutrouter);

                                }
                            }
                            connection.Close();
                            return result;
                        }
                    }
                }
                catch(Exception ex) { return new List<HutExRouterUpgradePhaseThreeModel>(); }
            });
        }

        public Task<HutExRouterUpgradePhaseThreeModel> CreateHutRouterP3(HutExRouterUpgradePhaseThreeModel hutExRouterUpgradePhaseThreeModel)
        {
            return Task.Run(() =>
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(this._connectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.CommandText = _storedProcedure;
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@procId", 1);
                            cmd.Parameters.AddWithValue("@RouterUpgradesPhase3ID", hutExRouterUpgradePhaseThreeModel.RouterUpgradesPhase3ID);
                            cmd.Parameters.AddWithValue("@HutExecutionID", hutExRouterUpgradePhaseThreeModel.HutExecutionID);
                            cmd.Parameters.AddWithValue("@RouterUpgradeStartDate", checkNull(hutExRouterUpgradePhaseThreeModel.RouterUpgradeStartDate));
                            cmd.Parameters.AddWithValue("@RouterUpgradeEndDate", checkNull(hutExRouterUpgradePhaseThreeModel.RouterUpgradeEndDate));
                            cmd.Parameters.AddWithValue("@CreatedBy", hutExRouterUpgradePhaseThreeModel.CreatedBy);
                            cmd.Parameters.AddWithValue("@updatedBy", hutExRouterUpgradePhaseThreeModel.CreatedBy);
                            cmd.Connection = connection;
                            connection.Open();
                            hutExRouterUpgradePhaseThreeModel.RouterUpgradesPhase3ID = (long)cmd.ExecuteScalar();
                            connection.Close();
                            return hutExRouterUpgradePhaseThreeModel;
                        }
                    }
                }
                catch (Exception ex) { return new HutExRouterUpgradePhaseThreeModel(); }
            });
        }

        public Task<HutExRouterUpgradePhaseThreeModel> UpdateHutRouterP3(HutExRouterUpgradePhaseThreeModel hutExRouterUpgradePhaseThreeModel)
        {
            return Task.Run(() =>
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(this._connectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.CommandText = _storedProcedure;
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@procId", 5);
                            cmd.Parameters.AddWithValue("@RouterUpgradesPhase3ID", hutExRouterUpgradePhaseThreeModel.RouterUpgradesPhase3ID);
                            cmd.Parameters.AddWithValue("@HutExecutionID", hutExRouterUpgradePhaseThreeModel.HutExecutionID);
                            cmd.Parameters.AddWithValue("@RouterUpgradeStartDate", checkNull(hutExRouterUpgradePhaseThreeModel.RouterUpgradeStartDate));
                            cmd.Parameters.AddWithValue("@RouterUpgradeEndDate", checkNull(hutExRouterUpgradePhaseThreeModel.RouterUpgradeEndDate));
                            cmd.Parameters.AddWithValue("@createdBy", string.Empty);
                            cmd.Parameters.AddWithValue("@updatedBy", hutExRouterUpgradePhaseThreeModel.UpdatedBy);
                            cmd.Connection = connection;
                            connection.Open();
                            var hutrouter = new HutExRouterUpgradePhaseThreeModel();
                            using (SqlDataReader dataReader = cmd.ExecuteReader())
                            {
                                while (dataReader.Read())
                                {
                                    hutrouter.RouterUpgradesPhase3ID = (long)dataReader["RouterUpgradesPhase3ID"];
                                    hutrouter.HutExecutionID = (long)dataReader["HutExecutionID"];
                                    if (dataReader["RouterUpgradeStartDate"] != DBNull.Value)
                                        hutrouter.RouterUpgradeStartDate = Convert.ToDateTime(dataReader["RouterUpgradeStartDate"]);
                                    if (dataReader["RouterUpgradeEndDate"] != DBNull.Value)
                                        hutrouter.RouterUpgradeEndDate = Convert.ToDateTime(dataReader["RouterUpgradeEndDate"]);   
                                }
                            }

                            cmd.Parameters["@RouterUpgradeStartDate"].Value = checkNullWithValue(hutExRouterUpgradePhaseThreeModel.RouterUpgradeStartDate, hutrouter.RouterUpgradeStartDate);
                            cmd.Parameters["@RouterUpgradeEndDate"].Value = checkNullWithValue(hutExRouterUpgradePhaseThreeModel.RouterUpgradeEndDate, hutrouter.RouterUpgradeEndDate);
                            cmd.Parameters["@procId"].Value = 2;
                            cmd.ExecuteNonQuery();
                            connection.Close();
                            return hutExRouterUpgradePhaseThreeModel;
                        }
                    }
                }
                catch (Exception ex) { return new HutExRouterUpgradePhaseThreeModel(); }
            });
        }

        public Task<int> DeleteHutRouterP3(int id)
        {
            return Task.Run(() =>
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
                            cmd.Parameters.AddWithValue("@RouterUpgradesPhase3ID", id);
                            cmd.Parameters.AddWithValue("@HutExecutionID", 0);
                            cmd.Parameters.AddWithValue("@RouterUpgradeStartDate", DBNull.Value);
                            cmd.Parameters.AddWithValue("@RouterUpgradeEndDate", DBNull.Value);
                            cmd.Parameters.AddWithValue("@createdBy", string.Empty);
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
    }
}
