using Exelon.Domain;
using Exelon.Domain.Abstractions;
using Exelon.Domain.Common;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Exelon.Infrastructure.Repositories
{
    public class MSIZERepository : IMSIZERepository
    {
        private readonly string _connectionString;
        private readonly string _storedProcedure = "dbo.spMSIZEActions";

        public MSIZERepository(IAppSettings appSettings)
        {
            _connectionString = appSettings.GetConnectionString();
        }

        public async Task<List<MSIZEModel>> GetMSIZE(int id = 0)
        {
            return await Task.Run(() =>
            {
                var result = new List<MSIZEModel>();
                try
                {
                    using (SqlConnection connection = new SqlConnection(this._connectionString))
                    {
                        connection.Open();
                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.CommandText = _storedProcedure;
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@ID", id);
                            cmd.Parameters.AddWithValue("@Name", string.Empty);
                            cmd.Parameters.AddWithValue("@Description", string.Empty);
                            cmd.Parameters.AddWithValue("@createdBy", string.Empty);
                            cmd.Parameters.AddWithValue("@updatedBy", string.Empty);
                            cmd.Connection = connection;
                            if (id == 0)
                                cmd.Parameters.AddWithValue("@procId",5);
                            else
                                cmd.Parameters.AddWithValue("@procId", 4);



                            using (SqlDataReader dataReader = cmd.ExecuteReader())
                            {
                                while (dataReader.Read())
                                {
                                    var dateWithTime = "MM'/'dd'/'yyyy h:mm tt";
                                    var msize = new MSIZEModel();
                                    msize.ID = (int)dataReader["ID"];
                                    msize.Name = dataReader["Name"].ToString();
                                    msize.Description = dataReader["Description"].ToString();
                                    msize.IsActive = Convert.ToBoolean(dataReader["IsActive"]);
                                    msize.CreatedBy = dataReader["CreatedBy"].ToString();
                                    msize.CreatedDate = Convert.ToDateTime(dataReader["CreatedDate"]).ToString(dateWithTime);
                                    msize.UpdatedBy = dataReader["UpdatedBy"].ToString();
                                    msize.UpdatedDate = Convert.ToDateTime(dataReader["UpdatedDate"]).ToString(dateWithTime);
                                    result.Add(msize);
                                }
                            }
                            connection.Close();

                        }
                    }
                    return result;
                }
                catch (Exception ex) { return new List<MSIZEModel>(); }
            });
        }

        public async Task<Dictionary<MSIZEModel, string>> CreateMSIZE(MSIZEModel mSIZEModel)
        {
            return await Task.Run(() =>
            {
                var result = new Dictionary<MSIZEModel, string>();
                try
                {
                    using (SqlConnection connection = new SqlConnection(this._connectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand())
                        {
                            
                            cmd.CommandText = _storedProcedure;
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@procId", 6);
                            cmd.Parameters.AddWithValue("@ID", 0);
                            cmd.Parameters.AddWithValue("@Name", mSIZEModel.Name);
                            cmd.Parameters.AddWithValue("@Description",string.IsNullOrEmpty(mSIZEModel.Description)?string.Empty:mSIZEModel.Description);
                            cmd.Parameters.AddWithValue("@CreatedBy", mSIZEModel.CreatedBy);
                            cmd.Parameters.AddWithValue("@UpdatedBy", mSIZEModel.CreatedBy);
                            cmd.Connection = connection;
                            connection.Open();
                            int check = (int)cmd.ExecuteScalar();
                            if (check == 1)
                            {
                                cmd.Parameters["@procId"].Value = 1;
                                mSIZEModel.ID = (int)cmd.ExecuteScalar();
                            }
                            else
                            {
                                connection.Close();
                                result[mSIZEModel] = "Already Exists!";
                                return result;
                            }
                            connection.Close();
                            result[mSIZEModel] = "ok";
                            return result;
                        }
                    }
                }
                catch (Exception ex) { return new Dictionary<MSIZEModel, string>(); }

            });
        }

        public async Task<Dictionary<MSIZEModel,string>> UpdateMSIZE(MSIZEModel mSIZEModel)
        {
            return await Task.Run(() =>
            {
                var result = new Dictionary<MSIZEModel, string>();
                try
                {
                    using (SqlConnection connection = new SqlConnection(this._connectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.CommandText = _storedProcedure;
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@procId", 6);
                            cmd.Parameters.AddWithValue("@ID", mSIZEModel.ID);
                            cmd.Parameters.AddWithValue("@Name", mSIZEModel.Name);
                            cmd.Parameters.AddWithValue("@Description", mSIZEModel.Description);
                            cmd.Parameters.AddWithValue("@CreatedBy", string.Empty);
                            cmd.Parameters.AddWithValue("@UpdatedBy", mSIZEModel.UpdatedBy);
                            cmd.Connection = connection;
                            connection.Open();
                            int check = (int)cmd.ExecuteScalar();
                            if(check == 0)
                            {
                                connection.Close();
                                result[mSIZEModel] = "Already Exists!";
                                return result;
                            }
                            cmd.Parameters["@procId"].Value = 4;
                            var msize = new MSIZEModel();
                            using (SqlDataReader dataReader = cmd.ExecuteReader())
                            {
                                while (dataReader.Read())
                                {
                                    
                                    msize.ID = (int)dataReader["ID"];
                                    msize.Name = dataReader["Name"].ToString();
                                    msize.Description = dataReader["Description"].ToString();
                                    
                                }
                            }
                            if (string.IsNullOrEmpty(mSIZEModel.Description))
                                cmd.Parameters["@Description"].Value = msize.Description;
                            if (string.IsNullOrEmpty(mSIZEModel.IsActive.ToString()))
                                cmd.Parameters["@IsActive"].Value = msize.IsActive;
                            cmd.Parameters["@procId"].Value = 2;
                            cmd.ExecuteNonQuery();
                            result[mSIZEModel] = "ok";
                            connection.Close();
                            return result;
                        }
                    }

                }
                catch (Exception ex) { return new Dictionary<MSIZEModel, string>(); }
            });
        }

        public async Task<int> DeleteMSIZE(int id)
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
                            cmd.Parameters.AddWithValue("@ID", id);
                            cmd.Parameters.AddWithValue("@Name", string.Empty);
                            cmd.Parameters.AddWithValue("@Description", string.Empty);
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
