using Exelon.Domain;
using Exelon.Domain.Abstractions;
using Exelon.Domain.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Exelon.Infrastructure.Repositories
{
    public class MBARNRepository : IMBARNRepository
    {
        private readonly string _connectionString;

        private readonly string _storedProcedureName = "[dbo].[spMBARNActions]";
        
        public MBARNRepository(IAppSettings appSettings )
        {
            _connectionString = appSettings.GetConnectionString();
        }
        public async Task<List<MBARNModel>> GetBarn(int id = 0)
        {
            return await Task.Run(() =>
            {
                var lstBARN = new List<MBARNModel>();
                try
                {
                    using (SqlConnection connection = new SqlConnection(this._connectionString))
                    {
                        connection.Open();
                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.CommandText = _storedProcedureName;
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add("@procId", SqlDbType.Int);
                            cmd.Parameters.AddWithValue("@BarnID", id);
                            cmd.Parameters.AddWithValue("@BarnName", string.Empty);
                            cmd.Parameters.AddWithValue("@createdBy", string.Empty);
                            cmd.Parameters.AddWithValue("@updatedBy", string.Empty);
                            cmd.Connection = connection;
                            if (id == 0)   
                                cmd.Parameters["@procId"].Value = 4;
                            else
                                cmd.Parameters["@procId"].Value = 5;

                            using (SqlDataReader dataReader = cmd.ExecuteReader())
                            {
                                while (dataReader.Read())
                                {
                                        var dateWithTime = "MM'/'dd'/'yyyy h:mm tt";
                                        var mbarn = new MBARNModel();
                                        mbarn.BarnID = (int)dataReader["BarnID"];
                                        mbarn.BarnName = dataReader["BarnName"].ToString();
                                        mbarn.IsActive = Convert.ToBoolean(dataReader["IsActive"]);
                                        mbarn.CreatedBy = dataReader["CreatedBy"].ToString();
                                        mbarn.CreatedDate = Convert.ToDateTime(dataReader["CreatedDate"]).ToString(dateWithTime);
                                        mbarn.UpdatedBy = dataReader["UpdatedBy"].ToString();
                                        mbarn.UpdatedDate = Convert.ToDateTime(dataReader["UpdatedDate"]).ToString(dateWithTime);
                                        lstBARN.Add(mbarn);
                                }

                            }
                            
                        }
                        connection.Close();
                    }
                    
                    return lstBARN;
                }
                catch (Exception ex) { return new List<MBARNModel>(); }
            });
        }
        public async Task<Dictionary<MBARNModel,string>> CreateBarn(MBARNModel mBARNModel)
        {

            return await Task.Run(() =>
            {
                var result = new Dictionary<MBARNModel, string>();
                try
                {
                    using (SqlConnection connection = new SqlConnection(this._connectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.CommandText = _storedProcedureName;
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@procId", 6);
                            cmd.Parameters.AddWithValue("@BarnID", 0);
                            cmd.Parameters.AddWithValue("@BarnName", mBARNModel.BarnName);
                            cmd.Parameters.AddWithValue("@createdBy", mBARNModel.CreatedBy);
                            cmd.Parameters.AddWithValue("@updatedBy", mBARNModel.CreatedBy);
                            cmd.Connection = connection;
                            connection.Open();
                            int check = (int)cmd.ExecuteScalar();
                            if (check == 1)
                            {
                                cmd.Parameters["@procId"].Value = 1;
                                mBARNModel.BarnID = (int)cmd.ExecuteScalar();
                            }
                            else
                            {
                                connection.Close();
                                result[mBARNModel] = "Already Exists!";
                                return result;

                            }
                            connection.Close();
                            result[mBARNModel] = "ok";
                            return result;
                        }
                    }
                }
                catch (Exception ex) {
                    return new Dictionary<MBARNModel, string>();
                }
            });
        }
        public async Task<Dictionary<MBARNModel,string>> UpdateBarn(MBARNModel mBARNModel)
        {
            return await Task.Run(() =>
            {
                var result = new Dictionary<MBARNModel, string>();
                try
                {
                    using (SqlConnection connection = new SqlConnection(this._connectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.CommandText = _storedProcedureName;
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@procId", 6);
                            cmd.Parameters.AddWithValue("@BarnID", mBARNModel.BarnID);
                            cmd.Parameters.AddWithValue("@BarnName", mBARNModel.BarnName);
                            cmd.Parameters.AddWithValue("@createdBy", string.Empty);
                            cmd.Parameters.AddWithValue("@updatedBy", mBARNModel.UpdatedBy);
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
                                result[mBARNModel] = "Already Exists!";
                                return result;
                            }
                            connection.Close();
                            connection.Close();
                            result[mBARNModel] = "ok";
                            return result;
                        }
                    }
                }
                catch (Exception ex) { return new Dictionary<MBARNModel, string>(); }
            });
        }
        public async Task<int> DeleteBarn(int id)
        {
            return await Task.Run(() =>
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(this._connectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.CommandText = _storedProcedureName;
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@procId", 3);
                            cmd.Parameters.AddWithValue("@BarnID", id);
                            cmd.Parameters.AddWithValue("@BarnName", string.Empty);
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
