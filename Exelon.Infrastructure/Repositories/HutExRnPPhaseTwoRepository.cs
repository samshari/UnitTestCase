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
    public class HutExRnPPhaseTwoRepository : IHutExRnPPhaseTwoRepository
    {
        private readonly string _connectionString;
        private readonly string _storedProcedure = "dbo.spHutExRnPPhaseTwoActions";


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

        public HutExRnPPhaseTwoRepository(IAppSettings appSettings)
        {
            _connectionString = appSettings.GetConnectionString();
        }

        public Task<List<HutExRnPPhaseTwoModel>> GetHutExRnPhaseTwo(int id = 0)
        {
            return Task.Run(() =>
            {
                var result = new List<HutExRnPPhaseTwoModel>();
                try
                {
                    using(SqlConnection connection = new SqlConnection(this._connectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.CommandText = _storedProcedure;
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@HutExRnPPhase2ID", id);
                            cmd.Parameters.AddWithValue("@HutExecutionID", 0);
                            cmd.Parameters.AddWithValue("@RnPIFA", DBNull.Value);
                            cmd.Parameters.AddWithValue("@RnPIFC", DBNull.Value);
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
                                    var rnphasetwo = new HutExRnPPhaseTwoModel();
                                    rnphasetwo.HutExRnPPhase2ID = (long)dataReader["HutExRnPPhase2ID"];
                                    rnphasetwo.HutExecutionID = (long)dataReader["HutExecutionID"];
                                    if(dataReader["RnPIFA"]!=DBNull.Value)
                                        rnphasetwo.RnPIFA = Convert.ToDateTime(dataReader["RnPIFA"]);
                                    if(dataReader["RnPIFC"]!=DBNull.Value)
                                        rnphasetwo.RnPIFC = Convert.ToDateTime(dataReader["RnPIFC"]);
                                    if (dataReader["RnPIFA"] != DBNull.Value)
                                        rnphasetwo.StrRnPIFA = Convert.ToDateTime(dataReader["RnPIFA"]).ToString(onlyDate);
                                    if (dataReader["RnPIFC"] != DBNull.Value)
                                        rnphasetwo.StrRnPIFC = Convert.ToDateTime(dataReader["RnPIFC"]).ToString(onlyDate);

                                    rnphasetwo.IsActive = Convert.ToBoolean(dataReader["IsActive"]);
                                    rnphasetwo.CreatedBy = dataReader["CreatedBy"].ToString();
                                    rnphasetwo.CreatedDate = Convert.ToDateTime(dataReader["CreatedDate"]).ToString(dateWithTime);
                                    rnphasetwo.UpdatedBy = dataReader["UpdatedBy"].ToString();
                                    rnphasetwo.UpdatedDate = Convert.ToDateTime(dataReader["UpdatedDate"]).ToString(dateWithTime);
                                    result.Add(rnphasetwo);
                                }
                            }
                            connection.Close();
                            return result;

                        }

                    }

                }
                catch(Exception ex) { return new List<HutExRnPPhaseTwoModel>(); }
            });
        }

        public Task<HutExRnPPhaseTwoModel> CreateHutExRnPhaseTwo(HutExRnPPhaseTwoModel hutExRnPPhaseTwoModel)
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
                            cmd.Parameters.AddWithValue("@HutExRnPPhase2ID", hutExRnPPhaseTwoModel.HutExRnPPhase2ID);
                            cmd.Parameters.AddWithValue("@HutExecutionID", hutExRnPPhaseTwoModel.HutExecutionID);
                            cmd.Parameters.AddWithValue("@RnPIFA", checkNull(hutExRnPPhaseTwoModel.RnPIFA));
                            cmd.Parameters.AddWithValue("@RnPIFC", checkNull(hutExRnPPhaseTwoModel.RnPIFC));
                            cmd.Parameters.AddWithValue("@CreatedBy", hutExRnPPhaseTwoModel.CreatedBy);
                            cmd.Parameters.AddWithValue("@UpdatedBy", hutExRnPPhaseTwoModel.CreatedBy);
                            cmd.Connection = connection;
                            connection.Open();
                            hutExRnPPhaseTwoModel.HutExRnPPhase2ID = (long)cmd.ExecuteScalar();
                            connection.Close();
                            return hutExRnPPhaseTwoModel;

                        }

                    }

                }
                catch (Exception ex) { return new HutExRnPPhaseTwoModel(); }
            });
        }

        public Task<HutExRnPPhaseTwoModel> UpdateHutExRnPhaseTwo(HutExRnPPhaseTwoModel hutExRnPPhaseTwoModel)
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
                            cmd.Parameters.AddWithValue("@HutExRnPPhase2ID", hutExRnPPhaseTwoModel.HutExRnPPhase2ID);
                            cmd.Parameters.AddWithValue("@HutExecutionID", hutExRnPPhaseTwoModel.HutExecutionID);
                            cmd.Parameters.AddWithValue("@RnPIFA", checkNull(hutExRnPPhaseTwoModel.RnPIFA));
                            cmd.Parameters.AddWithValue("@RnPIFC", checkNull(hutExRnPPhaseTwoModel.RnPIFC));
                            cmd.Parameters.AddWithValue("@CreatedBy", string.Empty);
                            cmd.Parameters.AddWithValue("@UpdatedBy", hutExRnPPhaseTwoModel.UpdatedBy);
                            cmd.Connection = connection;
                            connection.Open();
                            var rnphasetwo = new HutExRnPPhaseTwoModel();
                            using (SqlDataReader dataReader = cmd.ExecuteReader())
                            {
                                while (dataReader.Read())
                                {
                                    
                                    rnphasetwo.HutExRnPPhase2ID = (long)dataReader["HutExRnPPhase2ID"];
                                    rnphasetwo.HutExecutionID = (long)dataReader["HutExecutionID"];
                                    if (dataReader["RnPIFA"] != DBNull.Value)
                                        rnphasetwo.RnPIFA = Convert.ToDateTime(dataReader["RnPIFA"]);
                                    if (dataReader["RnPIFC"] != DBNull.Value)
                                        rnphasetwo.RnPIFC = Convert.ToDateTime(dataReader["RnPIFC"]);

                                }
                            }
                            cmd.Parameters["@RnPIFA"].Value = checkNullWithValue(hutExRnPPhaseTwoModel.RnPIFA, rnphasetwo.RnPIFA);
                            cmd.Parameters["@RnPIFC"].Value = checkNullWithValue(hutExRnPPhaseTwoModel.RnPIFC, rnphasetwo.RnPIFC);
                            cmd.Parameters["@procId"].Value = 2;
                            cmd.ExecuteNonQuery();
                            connection.Close();
                            return hutExRnPPhaseTwoModel;

                        }

                    }

                }
                catch (Exception ex) { return new HutExRnPPhaseTwoModel(); }
            });
        }

        public Task<int> DeleteHutExRnPhaseTwo(int id)
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
                            cmd.Parameters.AddWithValue("@HutExRnPPhase2ID", id);
                            cmd.Parameters.AddWithValue("@HutExecutionID", 0);
                            cmd.Parameters.AddWithValue("@RnPIFA", DBNull.Value);
                            cmd.Parameters.AddWithValue("@RnPIFC", DBNull.Value);
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
