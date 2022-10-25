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
    public class FiberCountRepository : IFiberCountRepository
    {
        private readonly string _connectionString;
        private readonly string _storedProcedure = "dbo.spMFIBERCOUNTActions";

        public FiberCountRepository(IAppSettings appSettings)
        {
            _connectionString = appSettings.GetConnectionString();
        }

        public async Task<List<FiberCountModel>> GetFIBER(int id = 0)
        {
            return await Task.Run(() =>
            {
                var result = new List<FiberCountModel>();
                try
                {
                    using (SqlConnection connection = new SqlConnection(this._connectionString))
                    {
                        connection.Open();
                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.CommandText = _storedProcedure;
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@FiberCountID", id);
                            cmd.Parameters.AddWithValue("@FiberCountValue", string.Empty);
                            cmd.Parameters.AddWithValue("@Description", string.Empty);
                            cmd.Parameters.AddWithValue("@createdBy", string.Empty);
                            cmd.Parameters.AddWithValue("@updatedBy", string.Empty);
                            cmd.Connection = connection;
                            if (id == 0)
                                cmd.Parameters.AddWithValue("@procId", 5);
                            else
                                cmd.Parameters.AddWithValue("@procId", 4);



                            using (SqlDataReader dataReader = cmd.ExecuteReader())
                            {
                                while (dataReader.Read())
                                {
                                    var dateWithTime = "MM'/'dd'/'yyyy h:mm tt";
                                    var mfiber = new FiberCountModel();
                                    mfiber.FiberCountID = (int)dataReader["FiberCountID"];
                                    mfiber.FiberCountValue = (int)dataReader["FiberCountValue"];
                                    mfiber.Description = dataReader["Description"].ToString();
                                    mfiber.IsActive = Convert.ToBoolean(dataReader["IsActive"]);
                                    mfiber.CreatedBy = dataReader["CreatedBy"].ToString();
                                    mfiber.CreatedDate = Convert.ToDateTime(dataReader["CreatedDate"]).ToString(dateWithTime);
                                    mfiber.UpdatedBy = dataReader["UpdatedBy"].ToString();
                                    mfiber.UpdatedDate = Convert.ToDateTime(dataReader["UpdatedDate"]).ToString(dateWithTime);
                                    result.Add(mfiber);
                                }
                            }
                            connection.Close();

                        }
                    }
                    return result;
                }
                catch (Exception ex) { return new List<FiberCountModel>(); }
            });
        }

        public async Task<Dictionary<FiberCountModel, string>> CreateFIBER(FiberCountModel fIBERCOUNTModel)
        {
            return await Task.Run(() =>
            {
                var result = new Dictionary<FiberCountModel, string>();
                try
                {
                    using (SqlConnection connection = new SqlConnection(this._connectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.CommandText = _storedProcedure;
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@procId", 6);
                            cmd.Parameters.AddWithValue("@FiberCountID", 0);
                            cmd.Parameters.AddWithValue("@FiberCountValue", fIBERCOUNTModel.FiberCountValue);
                            cmd.Parameters.AddWithValue("@Description", string.IsNullOrEmpty(fIBERCOUNTModel.Description)?string.Empty: fIBERCOUNTModel.Description);
                            cmd.Parameters.AddWithValue("@createdBy", fIBERCOUNTModel.CreatedBy);
                            cmd.Parameters.AddWithValue("@updatedBy", fIBERCOUNTModel.CreatedBy);
                            cmd.Connection = connection;
                            connection.Open();
                            int check = (int)cmd.ExecuteScalar();
                            if (check == 1)
                            {
                                cmd.Parameters["@procId"].Value = 1;
                                fIBERCOUNTModel.FiberCountID = (int)cmd.ExecuteScalar();
                            }
                            else
                            {
                                connection.Close();
                                result[fIBERCOUNTModel] = "Already Exists!";
                                return result;
                            }
                            connection.Close();
                            result[fIBERCOUNTModel] = "ok";
                            return result;
                        }
                    }
                }
                catch (Exception ex) { return new Dictionary<FiberCountModel, string>(); }

            });
        }

        public async Task<FiberCountModel> UpdateFIBER(FiberCountModel fIBERCOUNTModel)
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
                            cmd.Parameters.AddWithValue("@procId", 5);
                            cmd.Parameters.AddWithValue("@FiberCountID", fIBERCOUNTModel.FiberCountID);
                            cmd.Parameters.AddWithValue("@FiberCountValue", fIBERCOUNTModel.FiberCountValue);
                            cmd.Parameters.AddWithValue("@Description", fIBERCOUNTModel.Description);
                            cmd.Parameters.AddWithValue("@createdBy", string.Empty);
                            cmd.Parameters.AddWithValue("@updatedBy", fIBERCOUNTModel.UpdatedBy);
                            cmd.Connection = connection;
                            connection.Open();
                            var mfiber = new FiberCountModel();
                            using (SqlDataReader dataReader = cmd.ExecuteReader())
                            {
                                while (dataReader.Read())
                                {
                                    
                                    mfiber.FiberCountID = (int)dataReader["FiberCountID"];
                                    mfiber.FiberCountValue = (int)dataReader["FiberCountValue"];
                                    mfiber.Description = dataReader["Description"].ToString();
                                    
                                }
                            }
                            if (string.IsNullOrEmpty(fIBERCOUNTModel.Description))
                                cmd.Parameters["@Description"].Value = mfiber.Description;
                            cmd.Parameters["@procId"].Value = 2;
                            cmd.ExecuteNonQuery();
                            connection.Close();
                            return fIBERCOUNTModel;
                        }
                    }

                }
                catch (Exception ex) { return new FiberCountModel(); }
            });
        }

        public async Task<int> DeleteFIBER(int id)
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
                            cmd.Parameters.AddWithValue("@FiberCountID", id);
                            cmd.Parameters.AddWithValue("@FiberCountValue", 1);
                            cmd.Parameters.AddWithValue("@Description", string.Empty);
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
                catch (Exception ex) { return 0; }
            });
        }
    }
}
