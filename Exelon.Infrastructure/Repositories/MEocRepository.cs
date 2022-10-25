using Exelon.Domain;
using Exelon.Domain.Abstractions;
using Exelon.Domain.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Exelon.Infrastructure.Repositories
{
    public class MEOCRepository : IMEOCRepository
    {
        private readonly string _connectionString;

        private readonly string _storedProcedureName = "[dbo].[spMEOCActions]";

        public MEOCRepository(IAppSettings appSettings)
        {
            _connectionString = appSettings.GetConnectionString();
        }

        public async Task<List<MEOCModel>> GetMEOC(int id=0)
        {
            return await Task.Run(() =>
            {
                var lstMEOC = new List<MEOCModel>();
                try
                {
                    using (SqlConnection connection = new SqlConnection(this._connectionString))
                    {
                        connection.Open();
                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.CommandText = _storedProcedureName;
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@Id", id);
                            cmd.Parameters.AddWithValue("@name", string.Empty);
                            cmd.Parameters.AddWithValue("@createdBy", string.Empty);
                            cmd.Parameters.AddWithValue("@updatedBy", string.Empty);
                            cmd.Connection = connection;
                            if (id == 0)
                            {
                                cmd.Parameters.AddWithValue("@procId", 4);
                            }
                            else
                            {
                                cmd.Parameters.AddWithValue("@procId", 5);
                            }
                            using (SqlDataReader dataReader = cmd.ExecuteReader())
                            {
                                while (dataReader.Read())
                                {
                                        var dateWithTime = "MM'/'dd'/'yyyy h:mm tt";
                                        var meoc = new MEOCModel();
                                        meoc.ID = (int)dataReader["ID"];
                                        meoc.Name = dataReader["Name"].ToString();
                                        meoc.IsActive = Convert.ToBoolean(dataReader["IsActive"]);
                                        meoc.CreatedBy = dataReader["CreatedBy"].ToString();
                                        meoc.CreatedDate = Convert.ToDateTime(dataReader["CreatedDate"]).ToString(dateWithTime);
                                        meoc.UpdatedBy = dataReader["UpdatedBy"].ToString();
                                        meoc.UpdatedDate = Convert.ToDateTime(dataReader["UpdatedDate"]).ToString(dateWithTime);
                                        lstMEOC.Add(meoc);

                                }

                            }
                        }
                        connection.Close();
                    }
                    return lstMEOC;
                }
                catch(Exception ex) { throw ex; }
            }); 
        }

        public async Task<Dictionary<MEOCModel,string>> CreateMEOC(MEOCModel mEOCModel)
        {
            
            return await Task.Run(() =>
            {
                try
                {
                    var result = new Dictionary<MEOCModel, string>();
                    using (SqlConnection connection = new SqlConnection(this._connectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.CommandText = _storedProcedureName;
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@procId", 6);
                            cmd.Parameters.AddWithValue("@Id", 0);
                            cmd.Parameters.AddWithValue("@name", mEOCModel.Name);
                            cmd.Parameters.AddWithValue("@createdBy", mEOCModel.CreatedBy);
                            cmd.Parameters.AddWithValue("@updatedBy", mEOCModel.CreatedBy);
                            cmd.Connection = connection;
                            connection.Open();
                            int check = (int)cmd.ExecuteScalar();
                            if (check == 1)
                            {
                                cmd.Parameters["@procId"].Value = 1;
                                mEOCModel.ID = (int)cmd.ExecuteScalar();
                            }
                            else
                            {
                                connection.Close();
                                result[mEOCModel] = "Already Exists!";
                                return result;
                            }
                            connection.Close();
                            result[mEOCModel] = "ok";
                            return result;
                        }
                    }
                }
                catch (Exception ex) { return new Dictionary<MEOCModel,string>(); }
            });
        }
        

        public async Task<Dictionary<MEOCModel, string>> UpdateMEOC(MEOCModel mEOCModel)
        {
            return await Task.Run(() =>
            {
                var result = new Dictionary<MEOCModel, string>();                
                try
                {
                    using (SqlConnection connection = new SqlConnection(this._connectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.CommandText = _storedProcedureName;
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@procId", 6);
                            cmd.Parameters.AddWithValue("@Id", mEOCModel.ID);
                            cmd.Parameters.AddWithValue("@name", mEOCModel.Name);
                            cmd.Parameters.AddWithValue("@createdBy", string.Empty);
                            cmd.Parameters.AddWithValue("@updatedBy", mEOCModel.UpdatedBy);
                            cmd.Connection = connection;
                            connection.Open();
                            int check = (int)cmd.ExecuteScalar();
                            if (check == 1)
                            {
                                cmd.Parameters["@procId"].Value = 2;
                                cmd.ExecuteNonQuery();
                            }
                            else
                            {
                                connection.Close();
                                result[mEOCModel] = "Already Exists!";
                                return result;
                            }
                            connection.Close();
                            result[mEOCModel] = "ok";
                            return result;
                        }
                    }
                }
                catch (Exception ex) { return new Dictionary<MEOCModel, string>(); }
            });
        }

        public async Task<int> DeleteMEOC(int id)
        {
            return await Task.Run(() =>
            {
                try
                {
                    using(SqlConnection connection = new SqlConnection(this._connectionString))
                    {
                        using(SqlCommand cmd = new SqlCommand())
                        {
                            cmd.CommandText = _storedProcedureName;
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@procId", 3);
                            cmd.Parameters.AddWithValue("@Id", id);
                            cmd.Parameters.AddWithValue("@name", string.Empty);
                            cmd.Parameters.AddWithValue("@createdBy", string.Empty);
                            cmd.Parameters.AddWithValue("@updatedBy", string.Empty);
                            cmd.Connection = connection;
                            connection.Open();
                            int check = (int)cmd.ExecuteScalar();
                            connection.Close();
                            return check;

                        }
                    }
                }
                catch(Exception ex) { return 0; }
            });
        }


    }

    
}
