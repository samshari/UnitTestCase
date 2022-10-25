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
    public class HutExTestingRepository : IHutExTestingRepository
    {
        private readonly string _connectionString;
        private readonly string _storedProcedure = "dbo.spHutExTestingActions";


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

        public HutExTestingRepository(IAppSettings appSettings)
        {
            _connectionString = appSettings.GetConnectionString();
        }

        public Task<List<HutExTestingModel>> GetHutTest(int id = 0)
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
                            cmd.Parameters.AddWithValue("@HutTestingLNLID",id);
                            cmd.Parameters.AddWithValue("@HutExecutionID",0);
                            cmd.Parameters.AddWithValue("@FiberRingCompleted",DBNull.Value);
                            cmd.Parameters.AddWithValue("@HutInService",DBNull.Value);
                            cmd.Parameters.AddWithValue("@SecurityEquipmentInstalleCard", string.Empty);
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
                                    var huttest = new HutExTestingModel();
                                    huttest.HutTestingLNLID = (long)dataReader["HutTestingLNLID"];
                                    huttest.HutExecutionID = (long)dataReader["HutExecutionID"];
                                    if(dataReader["FiberRingCompleted"]!=DBNull.Value)
                                        huttest.FiberRingCompleted = Convert.ToDateTime(dataReader["FiberRingCompleted"]);
                                    if(dataReader["HutInService"]!=DBNull.Value)
                                        huttest.HutInService = Convert.ToDateTime(dataReader["HutInService"]);
                                    if (dataReader["FiberRingCompleted"] != DBNull.Value)
                                        huttest.StrFiberRingCompleted = Convert.ToDateTime(dataReader["FiberRingCompleted"]).ToString(onlyDate);
                                    if (dataReader["HutInService"] != DBNull.Value)
                                        huttest.StrHutInService = Convert.ToDateTime(dataReader["HutInService"]).ToString(onlyDate);
                                    huttest.SecurityEquipmentInstalleCard = dataReader["SecurityEquipmentInstalleCard"].ToString();
                                    huttest.IsActive = Convert.ToBoolean(dataReader["IsActive"]);
                                    huttest.CreatedBy = dataReader["CreatedBy"].ToString();
                                    huttest.CreatedDate = Convert.ToDateTime(dataReader["CreatedDate"]).ToString(dateWithTime);
                                    huttest.UpdatedBy = dataReader["UpdatedBy"].ToString();
                                    huttest.UpdatedDate = Convert.ToDateTime(dataReader["UpdatedDate"]).ToString(dateWithTime);
                                    result.Add(huttest);
                                }
                            }
                            connection.Close();
                            return result;

                        }

                    }

                }
                catch (Exception ex) { return new List<HutExTestingModel>(); }
            });
        }

        public Task<HutExTestingModel> CreateHutTest(HutExTestingModel hutExTestingModel)
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
                            cmd.Parameters.AddWithValue("@HutTestingLNLID", hutExTestingModel.HutTestingLNLID);
                            cmd.Parameters.AddWithValue("@HutExecutionID", hutExTestingModel.HutExecutionID);
                            cmd.Parameters.AddWithValue("@FiberRingCompleted", checkNull(hutExTestingModel.FiberRingCompleted));
                            cmd.Parameters.AddWithValue("@HutInService", checkNull(hutExTestingModel.HutInService));
                            cmd.Parameters.AddWithValue("@SecurityEquipmentInstalleCard", string.IsNullOrEmpty(hutExTestingModel.SecurityEquipmentInstalleCard) ? string.Empty : hutExTestingModel.SecurityEquipmentInstalleCard);
                            cmd.Parameters.AddWithValue("@CreatedBy", hutExTestingModel.CreatedBy);
                            cmd.Parameters.AddWithValue("@UpdatedBy", hutExTestingModel.CreatedBy);
                            cmd.Connection = connection;
                            connection.Open();
                            hutExTestingModel.HutTestingLNLID = (long)cmd.ExecuteScalar();
                            connection.Close();
                            return hutExTestingModel;

                        }

                    }

                }
                catch (Exception ex) { return new HutExTestingModel(); }
            });
        }

        public Task<HutExTestingModel> UpdateHutTest(HutExTestingModel hutExTestingModel)
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
                            cmd.Parameters.AddWithValue("@HutTestingLNLID", hutExTestingModel.HutTestingLNLID);
                            cmd.Parameters.AddWithValue("@HutExecutionID", hutExTestingModel.HutExecutionID);
                            cmd.Parameters.AddWithValue("@FiberRingCompleted", checkNull(hutExTestingModel.FiberRingCompleted));
                            cmd.Parameters.AddWithValue("@HutInService", checkNull(hutExTestingModel.HutInService));
                            cmd.Parameters.AddWithValue("@SecurityEquipmentInstalleCard", string.IsNullOrEmpty(hutExTestingModel.SecurityEquipmentInstalleCard)?string.Empty:hutExTestingModel.SecurityEquipmentInstalleCard);
                            cmd.Parameters.AddWithValue("@CreatedBy", string.Empty);
                            cmd.Parameters.AddWithValue("@UpdatedBy", hutExTestingModel.UpdatedBy);
                            cmd.Connection = connection;
                            connection.Open();
                            var huttest = new HutExTestingModel();
                            using (SqlDataReader dataReader = cmd.ExecuteReader())
                            {
                                while (dataReader.Read())
                                {
                                    
                                    huttest.HutTestingLNLID = (long)dataReader["HutTestingLNLID"];
                                    huttest.HutExecutionID = (long)dataReader["HutExecutionID"];
                                    if (dataReader["FiberRingCompleted"] != DBNull.Value)
                                        huttest.FiberRingCompleted = Convert.ToDateTime(dataReader["FiberRingCompleted"]);
                                    if (dataReader["HutInService"] != DBNull.Value)
                                        huttest.HutInService = Convert.ToDateTime(dataReader["HutInService"]);
                                    huttest.SecurityEquipmentInstalleCard = dataReader["SecurityEquipmentInstalleCard"].ToString();

                                }
                            }
                            cmd.Parameters["@FiberRingCompleted"].Value = checkNullWithValue(hutExTestingModel.FiberRingCompleted, huttest.FiberRingCompleted);
                            cmd.Parameters["@HutInService"].Value = checkNullWithValue(hutExTestingModel.HutInService, huttest.HutInService);
                            if (string.IsNullOrEmpty(hutExTestingModel.SecurityEquipmentInstalleCard))
                                cmd.Parameters["@SecurityEquipmentInstalleCard"].Value = huttest.SecurityEquipmentInstalleCard;
                            cmd.Parameters["@procId"].Value = 2;
                            cmd.ExecuteNonQuery();
                            connection.Close();
                            return hutExTestingModel;

                        }

                    }

                }
                catch (Exception ex) { return new HutExTestingModel(); }
            });
        }
        public Task<int> DeleteHutTest(int id)
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
                            cmd.Parameters.AddWithValue("@HutTestingLNLID", id);
                            cmd.Parameters.AddWithValue("@HutExecutionID", 0);
                            cmd.Parameters.AddWithValue("@FiberRingCompleted", DBNull.Value);
                            cmd.Parameters.AddWithValue("@HutInService", DBNull.Value);
                            cmd.Parameters.AddWithValue("@SecurityEquipmentInstalleCard", string.Empty);
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
