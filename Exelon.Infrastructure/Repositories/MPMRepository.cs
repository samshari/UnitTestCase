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
    public class MPMRepository : IMPMRepository
    {
        private readonly string _connectionString;

        private readonly string _storedProcedureName = "dbo.spMPMActions";

        public MPMRepository(IAppSettings appSettings)
        {
            _connectionString = appSettings.GetConnectionString();
        }

        public async Task<List<MPMModel>> GetMPM(int id = 0)
        {
            return await Task.Run(() =>
            {
                var lstMPM = new List<MPMModel>();
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
                            cmd.Parameters.AddWithValue("@Name", string.Empty);
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
                                    var mpm = new MPMModel();
                                    mpm.PMID = (int)dataReader["PMId"];
                                    mpm.Name = dataReader["Name"].ToString();
                                    mpm.IsActive = Convert.ToBoolean(dataReader["IsActive"]);
                                    mpm.CreatedBy = dataReader["CreatedBy"].ToString();
                                    mpm.CreatedDate = Convert.ToDateTime(dataReader["CreatedDate"]).ToString(dateWithTime);
                                    mpm.UpdatedBy = dataReader["UpdatedBy"].ToString();
                                    mpm.UpdatedDate = Convert.ToDateTime(dataReader["UpdatedDate"]).ToString(dateWithTime);
                                    lstMPM.Add(mpm);


                                }

                            }
                        }
                    }
                    return lstMPM;
                }
                catch (Exception ex) { return new List<MPMModel>(); }
            });
        }


        public async Task<Dictionary<MPMModel,string>> CreateMPM(MPMModel mPMModel)
        {
            return await Task.Run(() =>
            {
                try
                {
                    var result = new Dictionary<MPMModel, string>();
                    using (SqlConnection con = new SqlConnection(this._connectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.CommandText = _storedProcedureName;
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@procId", 6);
                            cmd.Parameters.AddWithValue("@Id", 0);
                            cmd.Parameters.AddWithValue("@name", mPMModel.Name);
                            cmd.Parameters.AddWithValue("@createdBy", mPMModel.CreatedBy);
                            cmd.Parameters.AddWithValue("@updatedBy", mPMModel.CreatedBy);
                            cmd.Connection = con;
                            con.Open();
                            int check = (int)cmd.ExecuteScalar();
                            if(check == 1)
                            {
                                cmd.Parameters["@procId"].Value = 1;
                                mPMModel.PMID = (int)cmd.ExecuteScalar();
                            }
                            else
                            {
                                result[mPMModel] = "Already Exists!";
                                return result;
                            }
                            
                            con.Close();
                            result[mPMModel] = "ok";
                            return result;
                        }
                    }
                }
                catch (Exception ex) { return new Dictionary<MPMModel, string>(); }
            });
        }


        public async Task<int> DeleteMPM(int id)
        {
            return await Task.Run(() =>
            {
                try
                {

                    using (SqlConnection con = new SqlConnection(this._connectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.CommandText = _storedProcedureName;
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@procId", 3);
                            cmd.Parameters.AddWithValue("@Id", id);
                            cmd.Parameters.AddWithValue("@Name", string.Empty);
                            cmd.Parameters.AddWithValue("@createdBy", string.Empty);
                            cmd.Parameters.AddWithValue("@updatedBy", string.Empty);
                            cmd.Connection = con;
                            con.Open();
                            cmd.ExecuteScalar();
                            con.Close();
                            return 1;
                        }
                    }
                }
                catch (Exception ex) { return 0; }
            });
        }



        public async Task<Dictionary<MPMModel, string>> UpdateMPM(MPMModel mPMModel)
        {
            return await Task.Run(() =>
            {
                var result = new Dictionary<MPMModel, string>();
                try
                {

                    using (SqlConnection con = new SqlConnection(this._connectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.CommandText = _storedProcedureName;
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@procId", 6);
                            cmd.Parameters.AddWithValue("@Id", mPMModel.PMID);
                            cmd.Parameters.AddWithValue("@name", mPMModel.Name);
                            cmd.Parameters.AddWithValue("@createdBy", string.Empty);
                            cmd.Parameters.AddWithValue("@updatedBy", mPMModel.UpdatedBy);
                            cmd.Connection = con;
                            con.Open();
                            int check = (int)cmd.ExecuteScalar();
                            if (check == 1)
                            {
                                cmd.Parameters["@procId"].Value=2;
                                cmd.ExecuteNonQuery();

                            }
                            else
                            {
                                con.Close();
                                result[mPMModel] = "Already Exists!";
                                return result;
                            }
                            con.Close();
                            result[mPMModel] = "ok";
                            return result;
                        }
                    }
                }
                catch (Exception ex) { return new Dictionary<MPMModel, string>(); }
            });
        }

    }
}
