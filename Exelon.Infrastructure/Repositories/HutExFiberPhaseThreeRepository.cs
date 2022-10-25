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
    public class HutExFiberPhaseThreeRepository : IHutExFiberPhaseThreeRepository
    {
        private readonly string _connectionString;
        private readonly string _storedProcedure = "dbo.spHutExFiberPhaseThreeActions";


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

        public HutExFiberPhaseThreeRepository(IAppSettings appSettings)
        {
            _connectionString = appSettings.GetConnectionString();
        }

        public Task<List<HutExFiberPhaseThreeModel>> GetHutFiber(int id = 0)
        {
            return Task.Run(() =>
            {
                var result = new List<HutExFiberPhaseThreeModel>();
                try
                {
                    using (SqlConnection connection = new SqlConnection(this._connectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.CommandText = _storedProcedure;
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@FiberPhase3ID", id);
                            cmd.Parameters.AddWithValue("@HutExecutionID", 0);
                            cmd.Parameters.AddWithValue("@FiberInstallationDate", DBNull.Value);
                            cmd.Parameters.AddWithValue("@FiberRingCompleted", DBNull.Value);                           
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
                                    var hutfiber = new HutExFiberPhaseThreeModel();
                                    hutfiber.FiberPhase3ID = (long)dataReader["FiberPhase3ID"];
                                    hutfiber.HutExecutionID = (long)dataReader["HutExecutionID"];
                                    if(dataReader["FiberInstallationDate"]!=DBNull.Value)
                                        hutfiber.FiberInstallationDate = Convert.ToDateTime(dataReader["FiberInstallationDate"]);
                                    if (dataReader["FiberRingCompleted"] != DBNull.Value)
                                        hutfiber.FiberRingCompleted = Convert.ToDateTime(dataReader["FiberRingCompleted"]);

                                    if (dataReader["FiberInstallationDate"] != DBNull.Value)
                                        hutfiber.StrFiberInstallationDate = Convert.ToDateTime(dataReader["FiberInstallationDate"]).ToString(onlyDate);
                                    if (dataReader["FiberRingCompleted"] != DBNull.Value)
                                        hutfiber.StrFiberRingCompleted = Convert.ToDateTime(dataReader["FiberRingCompleted"]).ToString(onlyDate);

                                    hutfiber.IsActive = Convert.ToBoolean(dataReader["IsActive"]);
                                    hutfiber.CreatedBy = dataReader["CreatedBy"].ToString();
                                    hutfiber.CreatedDate = Convert.ToDateTime(dataReader["CreatedDate"]).ToString(dateWithTime);
                                    hutfiber.UpdatedBy = dataReader["UpdatedBy"].ToString();
                                    hutfiber.UpdatedDate = Convert.ToDateTime(dataReader["UpdatedDate"]).ToString(dateWithTime);
                                    result.Add(hutfiber);
                                }
                            }
                            connection.Close();
                            return result;

                        }

                    }

                }
                catch (Exception ex) { return new List<HutExFiberPhaseThreeModel>(); }
            });
        }

        public Task<HutExFiberPhaseThreeModel> CreateHutFiber(HutExFiberPhaseThreeModel hutExFiberPhaseThreeModel)
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
                            cmd.Parameters.AddWithValue("@FiberPhase3ID",hutExFiberPhaseThreeModel.FiberPhase3ID);
                            cmd.Parameters.AddWithValue("@HutExecutionID", hutExFiberPhaseThreeModel.HutExecutionID);
                            cmd.Parameters.AddWithValue("@FiberInstallationDate", checkNull(hutExFiberPhaseThreeModel.FiberInstallationDate));
                            cmd.Parameters.AddWithValue("@FiberRingCompleted", checkNull(hutExFiberPhaseThreeModel.FiberRingCompleted));
                            cmd.Parameters.AddWithValue("@CreatedBy", hutExFiberPhaseThreeModel.CreatedBy);
                            cmd.Parameters.AddWithValue("@UpdatedBy", hutExFiberPhaseThreeModel.CreatedBy);
                            cmd.Connection = connection;
                            connection.Open();
                            hutExFiberPhaseThreeModel.FiberPhase3ID = (long)cmd.ExecuteScalar();
                            connection.Close();
                            return hutExFiberPhaseThreeModel;

                        }

                    }

                }
                catch (Exception ex) { return new HutExFiberPhaseThreeModel(); }
            });
        }

        public Task<HutExFiberPhaseThreeModel> UpdateHutFiber(HutExFiberPhaseThreeModel hutExFiberPhaseThreeModel)
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
                            cmd.Parameters.AddWithValue("@FiberPhase3ID", hutExFiberPhaseThreeModel.FiberPhase3ID);
                            cmd.Parameters.AddWithValue("@HutExecutionID", hutExFiberPhaseThreeModel.HutExecutionID);
                            cmd.Parameters.AddWithValue("@FiberInstallationDate", checkNull(hutExFiberPhaseThreeModel.FiberInstallationDate));
                            cmd.Parameters.AddWithValue("@FiberRingCompleted", checkNull(hutExFiberPhaseThreeModel.FiberRingCompleted));
                            cmd.Parameters.AddWithValue("@CreatedBy", string.Empty);
                            cmd.Parameters.AddWithValue("@UpdatedBy", hutExFiberPhaseThreeModel.UpdatedBy);
                            cmd.Connection = connection;
                            connection.Open();
                            var hutfiber = new HutExFiberPhaseThreeModel();
                            using (SqlDataReader dataReader = cmd.ExecuteReader())
                            {
                                while (dataReader.Read())
                                {
                                    hutfiber.FiberPhase3ID = (long)dataReader["FiberPhase3ID"];
                                    hutfiber.HutExecutionID = (long)dataReader["HutExecutionID"];
                                    if (dataReader["FiberInstallationDate"] != DBNull.Value)
                                        hutfiber.FiberInstallationDate = Convert.ToDateTime(dataReader["FiberInstallationDate"]);
                                    if (dataReader["FiberRingCompleted"] != DBNull.Value)
                                        hutfiber.FiberRingCompleted = Convert.ToDateTime(dataReader["FiberRingCompleted"]);

                                }
                            }
                            cmd.Parameters["@FiberInstallationDate"].Value = checkNullWithValue(hutExFiberPhaseThreeModel.FiberInstallationDate, hutfiber.FiberInstallationDate);
                            cmd.Parameters["@FiberRingCompleted"].Value = checkNullWithValue(hutExFiberPhaseThreeModel.FiberRingCompleted, hutfiber.FiberRingCompleted);
                            
                            cmd.Parameters["@procId"].Value = 2;
                            cmd.ExecuteNonQuery();
                            connection.Close();
                            return hutExFiberPhaseThreeModel;

                        }

                    }

                }
                catch (Exception ex) { return new HutExFiberPhaseThreeModel(); }
            });
        }
        public Task<int> DeleteHutFiber(int id)
        {
            return Task.Run(() =>
            {
                var result = new List<HutExTestingModel>();
                try
                {
                    using (SqlConnection connection = new SqlConnection(this._connectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.CommandText = _storedProcedure;
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@procId", 3);
                            cmd.Parameters.AddWithValue("@FiberPhase3ID", id);
                            cmd.Parameters.AddWithValue("@HutExecutionID", 0);
                            cmd.Parameters.AddWithValue("@FiberInstallationDate", DBNull.Value);
                            cmd.Parameters.AddWithValue("@FiberRingCompleted", DBNull.Value);
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
