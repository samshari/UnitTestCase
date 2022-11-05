using Exelon.Domain;
using Exelon.Domain.Abstractions;
using Exelon.Domain.Common;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Exelon.Infrastructure.Repositories
{
    public class COMEDEXRepository : ICOMEDEXRepository
    {
        private readonly string _connectionString;
        private readonly string _storedProcedure = "dbo.spCOMDEXActions";

        public COMEDEXRepository(IAppSettings appSettings)
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
        public async Task<List<COMEDEXModel>> GetCOMED(int id = 0)
        {
            return await Task.Run(() =>
            {
                var result = new List<COMEDEXModel>();
                try
                {
                    using (SqlConnection connection = new SqlConnection(this._connectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.CommandText = _storedProcedure;
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@ComEdID", id);
                            cmd.Parameters.AddWithValue("@FK_LinkingID", 0);
                            cmd.Parameters.AddWithValue("@FK_LNLID", 0);
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
                                    var dateWithTime = "MM'/'dd'/'yyyy h:mm tt";
                                    var com = new COMEDEXModel();
                                    com.ComEdID = (long)dataReader["ComEdID"];
                                    com.FK_LinkingID = (long)dataReader["ExecutionLinkingID"];
                                    if (dataReader["FK_LNLID"] != DBNull.Value)
                                        com.FK_LNLID = (int)dataReader["FK_LNLID"];
                                    com.IsActive = Convert.ToBoolean(dataReader["IsActive"]);
                                    com.CreatedBy = dataReader["CreatedBy"].ToString();
                                    com.CreatedDate = Convert.ToDateTime(dataReader["CreatedDate"]).ToString(dateWithTime);
                                    com.UpdatedBy = dataReader["UpdatedBy"].ToString();
                                    com.UpdatedDate = Convert.ToDateTime(dataReader["UpdatedDate"]).ToString(dateWithTime);
                                    result.Add(com);
                                }
                            }
                            connection.Close();


                        }
                    }
                    return result;
                }
                catch (Exception ex) { return new List<COMEDEXModel>(); }
            });
        }

        public async Task<Dictionary<COMEDEXModel, string>> CreateCOMED(COMEDEXModel cOMEDEXModel)
        {
            return await Task.Run(() =>
            {
                var result = new Dictionary<COMEDEXModel, string>();
                try
                {
                    using (SqlConnection connection = new SqlConnection(this._connectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.CommandText = _storedProcedure;
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@procId", 6);
                            cmd.Parameters.AddWithValue("@ComEdID", cOMEDEXModel.ComEdID);
                            cmd.Parameters.AddWithValue("@FK_LinkingID", cOMEDEXModel.FK_LinkingID);
                            cmd.Parameters.AddWithValue("@FK_LNLID",checkNull(cOMEDEXModel.FK_LNLID));
                            cmd.Parameters.AddWithValue("@createdBy", cOMEDEXModel.CreatedBy);
                            cmd.Parameters.AddWithValue("@updatedBy", cOMEDEXModel.CreatedBy);
                            cmd.Connection = connection;
                            connection.Open();
                            int check = (int)cmd.ExecuteScalar();
                            if (check == 1)
                            {
                                cmd.Parameters["@procId"].Value = 1;
                            }
                            else
                            {
                                connection.Close();
                                result[cOMEDEXModel] = "Linking Id Already Exists";
                                return result;
                            }
                            cOMEDEXModel.ComEdID = (long)cmd.ExecuteScalar();
                            result[cOMEDEXModel] = "ok";
                            connection.Close();
                            return result;


                        }
                    }
                }
                catch (Exception ex) { return new Dictionary<COMEDEXModel, string>(); }
            });
        }

        public async Task<COMEDEXModel> UpdateCOMED(COMEDEXModel cOMEDEXModel)
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
                            cmd.Parameters.AddWithValue("@ComEdID", cOMEDEXModel.ComEdID);
                            cmd.Parameters.AddWithValue("@FK_LinkingID", cOMEDEXModel.FK_LinkingID);
                            cmd.Parameters.AddWithValue("@FK_LNLID", checkNull(cOMEDEXModel.FK_LNLID));
                            cmd.Parameters.AddWithValue("@createdBy", string.Empty);
                            cmd.Parameters.AddWithValue("@updatedBy", cOMEDEXModel.UpdatedBy);
                            cmd.Connection = connection;
                            connection.Open();
                            cmd.ExecuteNonQuery();
                            connection.Close();
                            return cOMEDEXModel;

                        }
                    }
                }
                catch (Exception ex) { return new COMEDEXModel(); }
            });
        }


        public async Task<int> DeleteCOMED(int id)
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
                            cmd.Parameters.AddWithValue("@ComEdID", id);
                            cmd.Parameters.AddWithValue("@FK_LinkingID", 0);
                            cmd.Parameters.AddWithValue("@FK_LNLID", 0);
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
