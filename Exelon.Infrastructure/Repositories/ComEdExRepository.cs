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
        public async Task<List<COMEDEXModel>> GetComEd(int id = 0)
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
                                    com.ComEdId = (long)dataReader["ComEdID"];
                                    com.LinkingId = (long)dataReader["ExecutionLinkingID"];
                                    if (dataReader["FK_LNLID"] != DBNull.Value)
                                        com.LNLId = (int)dataReader["FK_LNLID"];
                                    com.Name = dataReader["Name"].ToString();
                                    com.IsActive = Convert.ToBoolean(dataReader["IsActive"]);
                                    result.Add(com);
                                }
                            }
                            connection.Close();
                        }
                    }
                    return result;
                }
                catch (Exception ex) { throw ex; }
            });
        }
        public async Task<Dictionary<COMEDEXModel, string>> CreateComEd(COMEDEXModel model)
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
                            cmd.Parameters.AddWithValue("@ComEdID", model.ComEdId);
                            cmd.Parameters.AddWithValue("@FK_LinkingID", model.LinkingId);
                            cmd.Parameters.AddWithValue("@FK_LNLID", checkNull(model.LNLId));
                            cmd.Parameters.AddWithValue("@createdBy", model.CreatedBy);
                            cmd.Parameters.AddWithValue("@updatedBy", model.CreatedBy);
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
                                result[model] = "Linking Id Already Exists";
                                return result;
                            }
                            model.ComEdId = (long)cmd.ExecuteScalar();
                            result[model] = "ok";
                            connection.Close();
                            return result;
                        }
                    }
                }
                catch (Exception ex)
                {
                    return new Dictionary<COMEDEXModel, string>();
                }
            });
        }
        public async Task<COMEDEXModel> UpdateComEd(COMEDEXModel model)
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
                            cmd.Parameters.AddWithValue("@ComEdID", model.ComEdId);
                            cmd.Parameters.AddWithValue("@FK_LinkingID", model.LinkingId);
                            cmd.Parameters.AddWithValue("@FK_LNLID", checkNull(model.LNLId));
                            cmd.Parameters.AddWithValue("@createdBy", string.Empty);
                            cmd.Parameters.AddWithValue("@updatedBy", model.UpdatedBy);
                            cmd.Connection = connection;
                            connection.Open();
                            cmd.ExecuteNonQuery();
                            connection.Close();
                            return model;

                        }
                    }
                }
                catch (Exception ex) { return new COMEDEXModel(); }
            });
        }
        public async Task<int> DeleteComEd(int id)
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
        public async Task<List<COMEDEXModel>> GetLnL()
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
                            cmd.CommandText = _storedProcedure;
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@procId", 7);
                            cmd.Parameters.AddWithValue("@ComEdID", 0);
                            cmd.Parameters.AddWithValue("@FK_LinkingID", 0);
                            cmd.Parameters.AddWithValue("@FK_LNLID", 0);
                            cmd.Parameters.AddWithValue("@createdBy", string.Empty);
                            cmd.Parameters.AddWithValue("@updatedBy", string.Empty);
                            cmd.Connection = connection;
                            connection.Open();
                            using (SqlDataReader dataReader = cmd.ExecuteReader())
                            {
                                while (dataReader.Read())
                                {
                                    var com = new COMEDEXModel();
                                    if (dataReader["ID"] != DBNull.Value)
                                        com.Id = (int)dataReader["ID"];
                                    com.Name = dataReader["Name"].ToString();
                                    result.Add(com);
                                }
                            }
                            connection.Close();
                        }
                    }
                    return result;
                }
                catch (Exception ex)
                {
                    throw ex;
                    //  return new List<COMEDEXModel>();
                }
            });
        }
        public async Task<int> GetComEdIdByLinkingId(long linkingId)
        {
            return await Task.Run(() =>
            {
                int result = 0;
                try
                {
                    using (SqlConnection connection = new SqlConnection(this._connectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.CommandText = _storedProcedure;
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            cmd.CommandText = _storedProcedure;
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@procId", 8);
                            cmd.Parameters.AddWithValue("@ComEdID", 0);
                            cmd.Parameters.AddWithValue("@FK_LinkingID", linkingId);
                            cmd.Parameters.AddWithValue("@FK_LNLID", 0);
                            cmd.Parameters.AddWithValue("@createdBy", string.Empty);
                            cmd.Parameters.AddWithValue("@updatedBy", string.Empty);
                            cmd.Connection = connection;
                            connection.Open();
                            using (SqlDataReader dataReader = cmd.ExecuteReader())
                            {
                                while (dataReader.Read())
                                {
                                    var com = new COMEDEXModel();
                                    com.ComEdId = (long)dataReader["ComEdID"] != 0 ? (long)dataReader["ComEdID"] : 0;
                                    result = (int)com.ComEdId;
                                }
                            }
                            connection.Close();
                        }
                    }
                    return result;
                }
                catch (Exception ex)
                {
                    throw ex;
                    //  return new List<COMEDEXModel>();
                }
            });
        }
    }
}
