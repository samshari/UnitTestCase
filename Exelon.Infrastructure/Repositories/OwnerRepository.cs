using Exelon.Domain;
using Exelon.Domain.Abstractions;
using Exelon.Domain.Common;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Exelon.Infrastructure.Repositories
{
    public class OWNERRepository : IOWNERRepository
    {
        private readonly string _connectionString;
        private readonly string _storedProcedure= "dbo.spOWNERActions";

        public OWNERRepository(IAppSettings appSettings)
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

        public async Task<List<OWNERSModel>> GetOWNER(int id = 0)
        {
            return await Task.Run(() =>
            {
                var result = new List<OWNERSModel>();
                try
                {
                    using (SqlConnection connection = new SqlConnection(this._connectionString))
                    {
                        connection.Open();
                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.CommandText = _storedProcedure;
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@OwnerID",id);
                            cmd.Parameters.AddWithValue("@FK_LinkingID", 1);
                            cmd.Parameters.AddWithValue("@FK_ReactsLRE_ID", 1);
                            cmd.Parameters.AddWithValue("@FK_UCOMMSPOC_ID", 1);
                            cmd.Parameters.AddWithValue("@FK_ProjectManagerID", 1);
                            cmd.Parameters.AddWithValue("@StepID", 0);
                            cmd.Parameters.AddWithValue("@CreatedBy", string.Empty);
                            cmd.Parameters.AddWithValue("@updatedBy", string.Empty);
                            cmd.Connection = connection;

                            if (id == 0)
                                cmd.Parameters.AddWithValue("@procId", 4);
                            else
                                cmd.Parameters.AddWithValue("@procId", 5);

                            using(SqlDataReader dataReader = cmd.ExecuteReader())
                            {
                                while (dataReader.Read())
                                {
                                    var dateWithTime = "MM'/'dd'/'yyyy h:mm tt";
                                    var owner = new OWNERSModel();
                                    owner.OwnerID = (long)dataReader["OwnerID"];
                                    owner.FK_LinkingID = (long)dataReader["FK_LinkingID"];
                                    if(dataReader["FK_ReactsLRE_ID"] != DBNull.Value)
                                        owner.FK_ReactsLRE_ID = (int)dataReader["FK_ReactsLRE_ID"];

                                    if(dataReader["FK_UCOMMSPOC_ID"] != DBNull.Value)
                                        owner.FK_UCOMMSPOC_ID = (int)dataReader["FK_UCOMMSPOC_ID"];

                                    owner.FK_ProjectManagerID = (int)dataReader["FK_ProjectManagerID"];
                                    owner.StepID = (int)dataReader["StepID"];
                                    owner.IsActive = Convert.ToBoolean(dataReader["IsActive"]);
                                    owner.CreatedBy = dataReader["CreatedBy"].ToString();
                                    owner.CreatedDate = Convert.ToDateTime(dataReader["CreatedDate"]).ToString(dateWithTime);
                                    owner.UpdatedBy = dataReader["UpdatedBy"].ToString();
                                    owner.UpdatedDate = Convert.ToDateTime(dataReader["UpdatedDate"]).ToString(dateWithTime);
                                    result.Add(owner);

                                }
                            }
                            connection.Close();
                        }
                        
                    }
                    return result;
                }
                catch(Exception ex) { return new List<OWNERSModel>(); }
            });
        }


        public async Task<Dictionary<OWNERSModel, string>> CreateOWNER(OWNERSModel oWNERSModel)
        {
            return await Task.Run(() =>
            {
                var result = new Dictionary<OWNERSModel, string>();
                try
                {
                    using (SqlConnection connection = new SqlConnection(this._connectionString))
                    {

                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.CommandText = _storedProcedure;
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@procId", 6);
                            cmd.Parameters.AddWithValue("@OwnerID", 0);
                            cmd.Parameters.AddWithValue("@FK_LinkingID", oWNERSModel.FK_LinkingID);
                            cmd.Parameters.AddWithValue("@FK_ReactsLRE_ID", checkNull(oWNERSModel.FK_ReactsLRE_ID));
                            cmd.Parameters.AddWithValue("@FK_UCOMMSPOC_ID",checkNull(oWNERSModel.FK_UCOMMSPOC_ID));
                            cmd.Parameters.AddWithValue("@FK_ProjectManagerID", oWNERSModel.FK_ProjectManagerID);
                            cmd.Parameters.AddWithValue("@StepID", oWNERSModel.StepID);
                            cmd.Parameters.AddWithValue("@CreatedBy", oWNERSModel.CreatedBy);
                            cmd.Parameters.AddWithValue("@updatedBy", oWNERSModel.CreatedBy);
                            cmd.Connection = connection;
                            connection.Open();
                            int check = (int)cmd.ExecuteScalar();
                            if(check == 1)
                            {
                                cmd.Parameters["@procId"].Value = 1;
                                oWNERSModel.OwnerID = (long)cmd.ExecuteScalar();
                            }
                            else
                            {
                                connection.Close();
                                result[oWNERSModel] = "Linking Id Already Exists!";
                                return result;
                            }
                            result[oWNERSModel] = "ok";
                            return result;

                        }
                    }
                }
                catch (Exception ex) { return new Dictionary<OWNERSModel, string>(); }
            });
        }

        public async Task<Dictionary<OWNERSModel, string>> UpdateOWNER(OWNERSModel oWNERSModel)
        {
            return await Task.Run(() =>
            {
                var result = new Dictionary<OWNERSModel, string>();
                try
                {
                    using (SqlConnection connection = new SqlConnection(this._connectionString))
                    {

                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.CommandText = _storedProcedure;
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@procId", 5);
                            cmd.Parameters.AddWithValue("@OwnerID", oWNERSModel.OwnerID);
                            cmd.Parameters.AddWithValue("@FK_LinkingID", oWNERSModel.FK_LinkingID);
                            cmd.Parameters.AddWithValue("@FK_ReactsLRE_ID", checkNull(oWNERSModel.FK_ReactsLRE_ID));
                            cmd.Parameters.AddWithValue("@FK_UCOMMSPOC_ID", checkNull(oWNERSModel.FK_UCOMMSPOC_ID));
                            cmd.Parameters.AddWithValue("@FK_ProjectManagerID", oWNERSModel.FK_ProjectManagerID);
                            cmd.Parameters.AddWithValue("@StepID", oWNERSModel.StepID);
                            cmd.Parameters.AddWithValue("@CreatedBy", string.Empty);
                            cmd.Parameters.AddWithValue("@updatedBy", oWNERSModel.UpdatedBy);
                            cmd.Connection = connection;
                            connection.Open();
                            var owner = new OWNERSModel();
                            using (SqlDataReader dataReader = cmd.ExecuteReader())
                            {
                                while (dataReader.Read())
                                {
                                    
                                    owner.OwnerID = (long)dataReader["OwnerID"];
                                    owner.FK_LinkingID = (long)dataReader["FK_LinkingID"];
                                    if (dataReader["FK_ReactsLRE_ID"] != DBNull.Value)
                                        owner.FK_ReactsLRE_ID = (int)dataReader["FK_ReactsLRE_ID"];

                                    if (dataReader["FK_UCOMMSPOC_ID"] != DBNull.Value)
                                        owner.FK_UCOMMSPOC_ID = (int)dataReader["FK_UCOMMSPOC_ID"];

                                    owner.FK_ProjectManagerID = (int)dataReader["FK_ProjectManagerID"];
                                    owner.StepID = (int)dataReader["StepID"];
                                    

                                }
                            }

                            cmd.Parameters["@FK_ReactsLRE_ID"].Value = checkNullWithValue(oWNERSModel.FK_ReactsLRE_ID,owner.FK_ReactsLRE_ID);
                            cmd.Parameters["@FK_UCOMMSPOC_ID"].Value =checkNullWithValue(oWNERSModel.FK_UCOMMSPOC_ID,owner.FK_UCOMMSPOC_ID);

                            if (string.IsNullOrEmpty(oWNERSModel.FK_ProjectManagerID.ToString()))
                                cmd.Parameters["@FK_ProjectManagerID"].Value = owner.FK_ProjectManagerID;
                                

                            cmd.Parameters["@procId"].Value = 2;
                            cmd.ExecuteNonQuery();
                            connection.Close();

                            result[oWNERSModel] = "ok";
                            return result;

                        }
                    }
                }
                catch (Exception ex) { return new Dictionary<OWNERSModel, string>(); }
            });
        }

        public async Task<int> DeleteOWNER(int id)
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
                            cmd.Parameters.AddWithValue("@OwnerID", id);
                            cmd.Parameters.AddWithValue("@FK_LinkingID", 1);
                            cmd.Parameters.AddWithValue("@FK_ReactsLRE_ID", 1);
                            cmd.Parameters.AddWithValue("@FK_UCOMMSPOC_ID", 1);
                            cmd.Parameters.AddWithValue("@FK_ProjectManagerID", 1);
                            cmd.Parameters.AddWithValue("@StepID", 0);
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

    }
}
