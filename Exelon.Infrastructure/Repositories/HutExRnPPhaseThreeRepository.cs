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
    public class HutExRnPPhaseThreeRepository : IHutExRnPPhaseThreeRepository
    {
        private readonly string _connectionString;
        private readonly string _storedProcedure = "dbo.spHutExRnPPhaseThreeActions";


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

        public HutExRnPPhaseThreeRepository(IAppSettings appSettings)
        {
            _connectionString = appSettings.GetConnectionString();
        }

        public Task<List<HutExRnPPhaseThreeModel>> GetHutRnPPhaseThree(int id = 0)
        {
            return Task.Run(() =>
            {
                var result = new List<HutExRnPPhaseThreeModel>();
                try
                {
                    using (SqlConnection connection = new SqlConnection(this._connectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.CommandText = _storedProcedure;
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@RnPPhase3ID",id);
                            cmd.Parameters.AddWithValue("@HutExecutionID",0);
                            cmd.Parameters.AddWithValue("@RelayExecutionStartDate",DBNull.Value);
                            cmd.Parameters.AddWithValue("@Outage",string.Empty);
                            cmd.Parameters.AddWithValue("@CompletionDate", DBNull.Value);
                            cmd.Parameters.AddWithValue("@CreatedBy", string.Empty);
                            cmd.Parameters.AddWithValue("@UpdatedBy", string.Empty);
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
                                    var hutrnp = new HutExRnPPhaseThreeModel();
                                    hutrnp.RnPPhase3ID = (long)dataReader["RnPPhase3ID"];
                                    hutrnp.HutExecutionID = (long)dataReader["HutExecutionID"];
                                    if(dataReader["RelayExecutionStartDate"]!=DBNull.Value)
                                        hutrnp.RelayExecutionStartDate = Convert.ToDateTime(dataReader["RelayExecutionStartDate"]);
                                    if (dataReader["RelayExecutionStartDate"] != DBNull.Value)
                                        hutrnp.StrRelayExecutionStartDate = Convert.ToDateTime(dataReader["RelayExecutionStartDate"]).ToString(onlyDate);
                                    hutrnp.Outage = dataReader["Outage"].ToString();
                                    if (dataReader["CompletionDate"] != DBNull.Value)
                                        hutrnp.CompletionDate = Convert.ToDateTime(dataReader["CompletionDate"]);
                                    if (dataReader["CompletionDate"] != DBNull.Value)
                                        hutrnp.StrCompletionDate = Convert.ToDateTime(dataReader["CompletionDate"]).ToString(onlyDate);
                                    hutrnp.IsActive = Convert.ToBoolean(dataReader["IsActive"]);
                                    hutrnp.CreatedBy = dataReader["CreatedBy"].ToString();
                                    hutrnp.CreatedDate = Convert.ToDateTime(dataReader["CreatedDate"]).ToString(dateWithTime);
                                    hutrnp.UpdatedBy = dataReader["UpdatedBy"].ToString();
                                    hutrnp.UpdatedDate = Convert.ToDateTime(dataReader["UpdatedDate"]).ToString(dateWithTime);
                                    result.Add(hutrnp);
                                }
                            }
                            connection.Close();
                            return result;

                        }

                    }

                }
                catch (Exception ex) { return new List<HutExRnPPhaseThreeModel>(); }
            });
        }

        public Task<HutExRnPPhaseThreeModel> CreateHutRnPPhaseThree(HutExRnPPhaseThreeModel hutExRnPPhaseThreeModel)
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
                            cmd.Parameters.AddWithValue("@RnPPhase3ID", hutExRnPPhaseThreeModel.RnPPhase3ID);
                            cmd.Parameters.AddWithValue("@HutExecutionID", hutExRnPPhaseThreeModel.HutExecutionID);
                            cmd.Parameters.AddWithValue("@RelayExecutionStartDate", checkNull(hutExRnPPhaseThreeModel.RelayExecutionStartDate));
                            cmd.Parameters.AddWithValue("@Outage", string.IsNullOrEmpty(hutExRnPPhaseThreeModel.Outage)?string.Empty:hutExRnPPhaseThreeModel.Outage);
                            cmd.Parameters.AddWithValue("@CompletionDate", checkNull(hutExRnPPhaseThreeModel.CompletionDate));
                            cmd.Parameters.AddWithValue("@CreatedBy", hutExRnPPhaseThreeModel.CreatedBy);
                            cmd.Parameters.AddWithValue("@UpdatedBy", hutExRnPPhaseThreeModel.CreatedBy);
                            cmd.Connection = connection;
                            connection.Open();
                            hutExRnPPhaseThreeModel.RnPPhase3ID = (long)cmd.ExecuteScalar();
                            connection.Close();
                            return hutExRnPPhaseThreeModel;

                        }

                    }

                }
                catch (Exception ex) { return new HutExRnPPhaseThreeModel(); }
            });
        }

        public Task<HutExRnPPhaseThreeModel> UpdateHutRnPPhaseThree(HutExRnPPhaseThreeModel hutExRnPPhaseThreeModel)
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
                            cmd.Parameters.AddWithValue("@RnPPhase3ID", hutExRnPPhaseThreeModel.RnPPhase3ID);
                            cmd.Parameters.AddWithValue("@HutExecutionID", hutExRnPPhaseThreeModel.HutExecutionID);
                            cmd.Parameters.AddWithValue("@RelayExecutionStartDate", checkNull(hutExRnPPhaseThreeModel.RelayExecutionStartDate));
                            cmd.Parameters.AddWithValue("@Outage", string.IsNullOrEmpty(hutExRnPPhaseThreeModel.Outage) ? string.Empty : hutExRnPPhaseThreeModel.Outage);
                            cmd.Parameters.AddWithValue("@CompletionDate", checkNull(hutExRnPPhaseThreeModel.CompletionDate));
                            cmd.Parameters.AddWithValue("@CreatedBy", string.Empty);
                            cmd.Parameters.AddWithValue("@UpdatedBy", hutExRnPPhaseThreeModel.UpdatedBy);
                            cmd.Connection = connection;
                            connection.Open();
                            var hutrnp = new HutExRnPPhaseThreeModel();
                            using (SqlDataReader dataReader = cmd.ExecuteReader())
                            {
                                while (dataReader.Read())
                                {
                                    
                                    hutrnp.RnPPhase3ID = (long)dataReader["RnPPhase3ID"];
                                    hutrnp.HutExecutionID = (long)dataReader["HutExecutionID"];
                                    if (dataReader["RelayExecutionStartDate"] != DBNull.Value)
                                        hutrnp.RelayExecutionStartDate = Convert.ToDateTime(dataReader["RelayExecutionStartDate"]);
                                    hutrnp.Outage = dataReader["Outage"].ToString();
                                    if (dataReader["CompletionDate"] != DBNull.Value)
                                        hutrnp.CompletionDate = Convert.ToDateTime(dataReader["CompletionDate"]);

                                }
                            }
                            cmd.Parameters["@RelayExecutionStartDate"].Value = checkNullWithValue(hutExRnPPhaseThreeModel.RelayExecutionStartDate, hutrnp.RelayExecutionStartDate);
                            cmd.Parameters["@CompletionDate"].Value = checkNullWithValue(hutExRnPPhaseThreeModel.CompletionDate, hutrnp.CompletionDate);
                            if (string.IsNullOrEmpty(hutExRnPPhaseThreeModel.Outage))
                                cmd.Parameters["@Outage"].Value = hutrnp.Outage;
                            cmd.Parameters["@procId"].Value = 2;
                            cmd.ExecuteNonQuery();
                            connection.Close();
                            return hutExRnPPhaseThreeModel;

                        }

                    }

                }
                catch (Exception ex) { return new HutExRnPPhaseThreeModel(); }
            });
        }
        public Task<int> DeleteHutRnPPhaseThree(int id)
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
                            cmd.Parameters.AddWithValue("@RnPPhase3ID", id);
                            cmd.Parameters.AddWithValue("@HutExecutionID", 0);
                            cmd.Parameters.AddWithValue("@RelayExecutionStartDate", DBNull.Value);
                            cmd.Parameters.AddWithValue("@Outage", string.Empty);
                            cmd.Parameters.AddWithValue("@CompletionDate", DBNull.Value);
                            cmd.Parameters.AddWithValue("@CreatedBy", string.Empty);
                            cmd.Parameters.AddWithValue("@UpdatedBy", string.Empty);
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
