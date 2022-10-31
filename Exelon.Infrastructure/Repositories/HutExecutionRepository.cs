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
    public class HutExecutionRepository : IHutExecutionRepository
    {
        private readonly string _connectionString;
        private readonly string _storedProcedure = "dbo.spHutExecutionActions";

        public HutExecutionRepository(IAppSettings appSettings)
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

        public async Task<List<HutExecutionModel>> GetHutExecute(int id = 0)
        {
            return await  Task.Run(() =>
            {
                var result = new List<HutExecutionModel>();
                try
                {
                    using(SqlConnection connection = new SqlConnection(this._connectionString))
                    {
                        using(SqlCommand cmd = new SqlCommand())
                        {
                            cmd.CommandText = _storedProcedure;
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@HutExecutionID", id);
                            cmd.Parameters.AddWithValue("@HutDeliveryYear", string.Empty);
                            cmd.Parameters.AddWithValue("@Location", string.Empty);
                            cmd.Parameters.AddWithValue("@FK_PDID", 0);
                            cmd.Parameters.AddWithValue("@WorkOrder", string.Empty);
                            cmd.Parameters.AddWithValue("@PID", string.Empty);
                            cmd.Parameters.AddWithValue("@FK_RegionID", 0);
                            cmd.Parameters.AddWithValue("@FK_BarnID", 0);
                            cmd.Parameters.AddWithValue("@EOC", string.Empty);
                            cmd.Parameters.AddWithValue("@FK_HutSize", 0);
                            cmd.Parameters.AddWithValue("@ProductOrder", string.Empty);
                            cmd.Parameters.AddWithValue("@Cat_ID", string.Empty);
                            cmd.Parameters.AddWithValue("@Delivery_Address_On_PO", string.Empty);
                            cmd.Parameters.AddWithValue("@CreatedBy", string.Empty);
                            cmd.Parameters.AddWithValue("@UpdatedBy", string.Empty);
                            cmd.Connection = connection;

                            if (id == 0)
                                cmd.Parameters.AddWithValue("@procId", 4);
                            else
                                cmd.Parameters.AddWithValue("@procId", 5);

                            connection.Open();

                            using(SqlDataReader dataReader = cmd.ExecuteReader())
                            {
                                while (dataReader.Read())
                                {
                                    var dateWithTime = "MM'/'dd'/'yyyy h:mm tt";
                                    var hutexecute = new HutExecutionModel();
                                    hutexecute.HutExecutionID = (long)dataReader["HutExecutionID"];
                                    hutexecute.HutDeliveryYear = dataReader["HutDeliveryYear"].ToString();
                                    hutexecute.Location = dataReader["Location"].ToString();
                                    hutexecute.FK_PDID = (int)dataReader["FK_PDID"];
                                    hutexecute.WorkOrder = dataReader["WorkOrder"].ToString();
                                    hutexecute.PID = dataReader["PID"].ToString();
                                    if(dataReader["FK_RegionID"] != DBNull.Value)
                                        hutexecute.FK_RegionID = (int)dataReader["FK_RegionID"];
                                    if(dataReader["FK_BarnID"]!= DBNull.Value)
                                        hutexecute.FK_BarnID = (int)dataReader["FK_BarnID"];
                                    hutexecute.EOC = dataReader["EOC"].ToString();
                                    if(dataReader["FK_HutSize"]!=DBNull.Value)
                                        hutexecute.FK_HutSize = (int)dataReader["FK_HutSize"];
                                    hutexecute.ProductOrder = dataReader["ProductOrder"].ToString();
                                    hutexecute.Cat_ID = dataReader["Cat_ID"].ToString();
                                    hutexecute.Delivery_Address_On_PO = dataReader["Delivery_Address_On_PO"].ToString();
                                    hutexecute.IsActive = Convert.ToBoolean(dataReader["IsActive"]);
                                    hutexecute.CreatedBy = dataReader["CreatedBy"].ToString();
                                    hutexecute.CreatedDate = Convert.ToDateTime(dataReader["CreatedDate"]).ToString(dateWithTime);
                                    hutexecute.UpdatedBy = dataReader["UpdatedBy"].ToString();
                                    hutexecute.UpdatedDate = Convert.ToDateTime(dataReader["UpdatedDate"]).ToString(dateWithTime);
                                    result.Add(hutexecute);

                                }
                            }

                           
                            connection.Close();
                            return result;
                        }
                    }

                }
                catch (Exception ex) { return new List<HutExecutionModel>(); }
            });
        }


        public async Task<HutExecutionModel> CreateHutExecute(HutExecutionModel hutExecutionModel)
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
                            cmd.Parameters.AddWithValue("@procId", 1);
                            cmd.Parameters.AddWithValue("@HutExecutionID", hutExecutionModel.HutExecutionID);
                            cmd.Parameters.AddWithValue("@HutDeliveryYear", string.IsNullOrEmpty(hutExecutionModel.HutDeliveryYear)?string.Empty:hutExecutionModel.HutDeliveryYear);
                            cmd.Parameters.AddWithValue("@Location", string.IsNullOrEmpty(hutExecutionModel.Location)?string.Empty:hutExecutionModel.Location);
                            cmd.Parameters.AddWithValue("@FK_PDID", hutExecutionModel.FK_PDID);
                            cmd.Parameters.AddWithValue("@WorkOrder", string.IsNullOrEmpty(hutExecutionModel.WorkOrder)?string.Empty:hutExecutionModel.WorkOrder);
                            cmd.Parameters.AddWithValue("@PID", string.IsNullOrEmpty(hutExecutionModel.PID)?string.Empty:hutExecutionModel.PID);
                            cmd.Parameters.AddWithValue("@FK_RegionID",checkNull(hutExecutionModel.FK_RegionID));
                            cmd.Parameters.AddWithValue("@FK_BarnID",checkNull(hutExecutionModel.FK_BarnID));
                            cmd.Parameters.AddWithValue("@FK_HutSize",checkNull(hutExecutionModel.FK_RegionID));
                            cmd.Parameters.AddWithValue("@EOC", string.IsNullOrEmpty(hutExecutionModel.EOC)?string.Empty:hutExecutionModel.EOC);
                            cmd.Parameters.AddWithValue("@ProductOrder",string.IsNullOrEmpty(hutExecutionModel.ProductOrder)?string.Empty:hutExecutionModel.ProductOrder);
                            cmd.Parameters.AddWithValue("@Cat_ID", string.IsNullOrEmpty(hutExecutionModel.Cat_ID)?string.Empty:hutExecutionModel.Cat_ID);
                            cmd.Parameters.AddWithValue("@Delivery_Address_On_PO", string.IsNullOrEmpty(hutExecutionModel.Delivery_Address_On_PO)?string.Empty:hutExecutionModel.Delivery_Address_On_PO);
                            cmd.Parameters.AddWithValue("@CreatedBy", hutExecutionModel.CreatedBy);
                            cmd.Parameters.AddWithValue("@UpdatedBy", hutExecutionModel.CreatedBy);
                            cmd.Parameters.AddWithValue("@DeletedBy", 0);
                            cmd.Connection = connection;
                            connection.Open();
                            hutExecutionModel.HutExecutionID = (long)cmd.ExecuteScalar();
                            connection.Close();
                            return hutExecutionModel;

                        }
                    }

                }
                catch (Exception ex) { return new HutExecutionModel(); }
            });
        }


        public async Task<HutExecutionModel> UpdateHutExecute(HutExecutionModel hutExecutionModel)
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
                            cmd.Parameters.AddWithValue("@HutExecutionID", hutExecutionModel.HutExecutionID);
                            cmd.Parameters.AddWithValue("@HutDeliveryYear", string.IsNullOrEmpty(hutExecutionModel.HutDeliveryYear) ? string.Empty : hutExecutionModel.HutDeliveryYear);
                            cmd.Parameters.AddWithValue("@Location", string.IsNullOrEmpty(hutExecutionModel.Location) ? string.Empty : hutExecutionModel.Location);
                            cmd.Parameters.AddWithValue("@FK_PDID", hutExecutionModel.FK_PDID);
                            cmd.Parameters.AddWithValue("@WorkOrder", string.IsNullOrEmpty(hutExecutionModel.WorkOrder) ? string.Empty : hutExecutionModel.WorkOrder);
                            cmd.Parameters.AddWithValue("@PID", string.IsNullOrEmpty(hutExecutionModel.PID) ? string.Empty : hutExecutionModel.PID);
                            cmd.Parameters.AddWithValue("@FK_RegionID", checkNull(hutExecutionModel.FK_RegionID));
                            cmd.Parameters.AddWithValue("@FK_BarnID", checkNull(hutExecutionModel.FK_BarnID));
                            cmd.Parameters.AddWithValue("@FK_HutSize", checkNull(hutExecutionModel.FK_RegionID));
                            cmd.Parameters.AddWithValue("@EOC", string.IsNullOrEmpty(hutExecutionModel.EOC) ? string.Empty : hutExecutionModel.EOC);
                            cmd.Parameters.AddWithValue("@ProductOrder", string.IsNullOrEmpty(hutExecutionModel.ProductOrder) ? string.Empty : hutExecutionModel.ProductOrder);
                            cmd.Parameters.AddWithValue("@Cat_ID", string.IsNullOrEmpty(hutExecutionModel.Cat_ID) ? string.Empty : hutExecutionModel.Cat_ID);
                            cmd.Parameters.AddWithValue("@Delivery_Address_On_PO", string.IsNullOrEmpty(hutExecutionModel.Delivery_Address_On_PO) ? string.Empty : hutExecutionModel.Delivery_Address_On_PO);
                            cmd.Parameters.AddWithValue("@CreatedBy", string.Empty);
                            cmd.Parameters.AddWithValue("@UpdatedBy", hutExecutionModel.UpdatedBy);
                            cmd.Connection = connection;
                            connection.Open();
                            cmd.ExecuteNonQuery();
                            connection.Close();
                            return hutExecutionModel;

                        }
                    }

                }
                catch (Exception ex) { return new HutExecutionModel(); }
            });
        }


        public async Task<int> DeleteHutExecute(int id)
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
                            cmd.Parameters.AddWithValue("@HutExecutionID", id);
                            cmd.Parameters.AddWithValue("@HutDeliveryYear", string.Empty);
                            cmd.Parameters.AddWithValue("@Location", string.Empty);
                            cmd.Parameters.AddWithValue("@FK_PDID", 0);
                            cmd.Parameters.AddWithValue("@WorkOrder", string.Empty);
                            cmd.Parameters.AddWithValue("@PID", string.Empty);
                            cmd.Parameters.AddWithValue("@FK_RegionID", 0);
                            cmd.Parameters.AddWithValue("@FK_BarnID", 0);
                            cmd.Parameters.AddWithValue("@EOC", string.Empty);
                            cmd.Parameters.AddWithValue("@FK_HutSize", 0);
                            cmd.Parameters.AddWithValue("@ProductOrder", string.Empty);
                            cmd.Parameters.AddWithValue("@Cat_ID", string.Empty);
                            cmd.Parameters.AddWithValue("@Delivery_Address_On_PO", string.Empty);
                            cmd.Parameters.AddWithValue("@CreatedBy", string.Empty);
                            cmd.Parameters.AddWithValue("@UpdatedBy", string.Empty);
                            cmd.Connection = connection;
                            connection.Open();
                            int check = (int)cmd.ExecuteScalar();
                            connection.Close();
                            return check;

                        }
                    }

                }
                catch (Exception ex) { return 0; }
            });
        }
    }
}
