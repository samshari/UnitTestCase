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
    public class MREGIONRepository : IMREGIONRepository
    {
        private readonly string _connectionString;

        private readonly string _storedProcedureName = "[dbo].[spMREGIONActions]";

        public MREGIONRepository(IAppSettings appSettings)
        {
            _connectionString = appSettings.GetConnectionString();
        }

        public async Task<List<MREGIONModel>> GetMREGION(int id = 0)
        {
            return await Task.Run(() =>
            {
                var lstMREGION = new List<MREGIONModel>();
                try
                {
                    using (SqlConnection connection = new SqlConnection(this._connectionString))
                    {
                        connection.Open();
                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.CommandText = _storedProcedureName;
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@RegionID", id);
                            cmd.Parameters.AddWithValue("@RegionName", string.Empty);
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
                                        var mregion = new MREGIONModel();
                                        mregion.RegionID = (int)dataReader["RegionID"];
                                        mregion.RegionName = dataReader["RegionName"].ToString();
                                        mregion.CreatedBy = dataReader["CreatedBy"].ToString();
                                        mregion.IsActive = Convert.ToBoolean(dataReader["IsActive"]);
                                        mregion.CreatedDate = Convert.ToDateTime(dataReader["CreatedDate"]).ToString(dateWithTime);
                                        mregion.UpdatedBy = dataReader["UpdatedBy"].ToString();
                                        mregion.UpdatedDate = Convert.ToDateTime(dataReader["UpdatedDate"]).ToString(dateWithTime);
                                        lstMREGION.Add(mregion);

                                }

                            }
                            connection.Close();
                        }
                    }
                    return lstMREGION;
                }
                catch (Exception ex) { return new List<MREGIONModel>(); }
            });
        }

        public async Task<Dictionary<MREGIONModel,string>> CreateMREGION(MREGIONModel mREGIONModel)
        {

            return await Task.Run(() =>
            {
                var result = new Dictionary<MREGIONModel,string>();
                try
                {
                    using (SqlConnection connection = new SqlConnection(this._connectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.CommandText = _storedProcedureName;
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@procId", 6);
                            cmd.Parameters.AddWithValue("@RegionID", 0);
                            cmd.Parameters.AddWithValue("@RegionName", mREGIONModel.RegionName);
                            cmd.Parameters.AddWithValue("@createdBy", mREGIONModel.CreatedBy);
                            cmd.Parameters.AddWithValue("@updatedBy", mREGIONModel.CreatedBy);
                            cmd.Connection = connection;
                            connection.Open();
                            int check = (int)cmd.ExecuteScalar();
                            if (check == 1)
                            {
                                cmd.Parameters["@procId"].Value = 1;
                                mREGIONModel.RegionID = (int)cmd.ExecuteScalar();
                            }
                            else
                            {
                                connection.Close();
                                result[mREGIONModel] = "Already Exists!";
                                return result;
                            }
                            connection.Close();
                            result[mREGIONModel] = "ok";
                            return result;
                        }
                    }
                }
                catch (Exception ex) { return new Dictionary<MREGIONModel, string>(); }
            });
        }


        public async Task<Dictionary<MREGIONModel, string>> UpdateMREGION(MREGIONModel mREGIONModel)
        {
            return await Task.Run(() =>
            {
                var result = new Dictionary<MREGIONModel, string>();
                try
                {
                    using (SqlConnection connection = new SqlConnection(this._connectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.CommandText = _storedProcedureName;
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@procId", 6);
                            cmd.Parameters.AddWithValue("@RegionId", mREGIONModel.RegionID);
                            cmd.Parameters.AddWithValue("@RegionName", mREGIONModel.RegionName);
                            cmd.Parameters.AddWithValue("@createdBy", string.Empty);
                            cmd.Parameters.AddWithValue("@updatedBy", mREGIONModel.UpdatedBy);
                            cmd.Connection = connection;
                            connection.Open();
                            int check = (int)cmd.ExecuteScalar();
                            if(check == 1)
                            {
                                cmd.Parameters["@procId"].Value = 2;
                                cmd.ExecuteNonQuery();
                            }
                            else
                            {
                                connection.Close();
                                result[mREGIONModel] = "Already Exists!";
                                return result;
                            }
                            connection.Close();
                            result[mREGIONModel] = "ok";
                            return result;
                        }
                    }
                }
                catch (Exception ex) { return new Dictionary<MREGIONModel, string>(); }
            });
        }

        public async Task<int> DeleteMREGION(int id)
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
                            cmd.Parameters.AddWithValue("@RegionID", id);
                            cmd.Parameters.AddWithValue("@RegionName", string.Empty);
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
