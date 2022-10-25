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
    public class PDRepository : IPDRepository
    {
        private readonly string _connectionString;
        private readonly string _storedProcedure= "dbo.spMPDActions";

        public PDRepository(IAppSettings appSettings)
        {
            _connectionString = appSettings.GetConnectionString();
        }

        public async Task<List<PdModel>> GetPD(int id = 0)
        {
            return await Task.Run(() =>
            {
                var lstMPD = new List<PdModel>();
                try
                {
                    using(SqlConnection connection = new SqlConnection(this._connectionString))
                    {
                        connection.Open();
                        using(SqlCommand cmd = new SqlCommand())
                        {
                            cmd.CommandText = _storedProcedure;
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            cmd.Parameters.Add("@procId", SqlDbType.Int);
                            cmd.Parameters.AddWithValue("@PDID", id);
                            cmd.Parameters.AddWithValue("@Name", string.Empty);
                            cmd.Parameters.AddWithValue("@Description", string.Empty);
                            cmd.Parameters.AddWithValue("@createdBy", string.Empty);
                            cmd.Parameters.AddWithValue("@updatedBy", string.Empty);
                            cmd.Connection = connection;
                            if (id == 0)
                                cmd.Parameters["@procId"].Value = 5;
                            else
                                cmd.Parameters["@procId"].Value = 4;
                            


                            using (SqlDataReader dataReader = cmd.ExecuteReader())
                            {
                                while (dataReader.Read())
                                {
                                    var dateWithTime = "MM'/'dd'/'yyyy h:mm tt";
                                    var mpd = new PdModel();
                                    mpd.PDID = (int)dataReader["PDID"];
                                    mpd.Name = dataReader["Name"].ToString();
                                    mpd.Description = dataReader["Description"].ToString();
                                    mpd.IsActive = Convert.ToBoolean(dataReader["IsActive"]);
                                    mpd.CreatedBy = dataReader["CreatedBy"].ToString();
                                    mpd.CreatedDate = Convert.ToDateTime(dataReader["CreatedDate"]).ToString(dateWithTime);
                                    mpd.UpdatedBy = dataReader["UpdatedBy"].ToString();
                                    mpd.UpdatedDate = Convert.ToDateTime(dataReader["UpdatedDate"]).ToString(dateWithTime);
                                    lstMPD.Add(mpd);
                                }
                            }
                            connection.Close();

                        }
                    }
                    return lstMPD;
                }
                catch(Exception ex) { return new List<PdModel>(); }
            });
        }

        public async Task<PdModel> CreatePD(PdModel pDModel)
        {
            return await Task.Run(() =>
            {
                try
                {
                    using(SqlConnection connection = new SqlConnection(this._connectionString))
                    {
                        using(SqlCommand cmd = new SqlCommand())
                        {
                            cmd.CommandText = _storedProcedure;
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@procId", 1);
                            cmd.Parameters.AddWithValue("@PDID", 0);
                            cmd.Parameters.AddWithValue("@Name", pDModel.Name);
                            cmd.Parameters.AddWithValue("@Description", string.IsNullOrEmpty(pDModel.Description) ? string.Empty : pDModel.Description);
                            cmd.Parameters.AddWithValue("@createdBy", pDModel.CreatedBy);
                            cmd.Parameters.AddWithValue("@updatedBy", pDModel.CreatedBy);
                            cmd.Connection = connection;
                            connection.Open();
                            pDModel.PDID = (int)cmd.ExecuteScalar();
                            connection.Close();
                            return pDModel;
                        }
                    }
                }
                catch(Exception ex) { return new PdModel(); }

            });
        }

        public async Task<PdModel> UpdatePD(PdModel pDModel)
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
                            cmd.Parameters.AddWithValue("@PDID", pDModel.PDID);
                            cmd.Parameters.AddWithValue("@Name", pDModel.Name);
                            cmd.Parameters.AddWithValue("@Description", string.IsNullOrEmpty(pDModel.Description) ? string.Empty : pDModel.Description);
                            cmd.Parameters.AddWithValue("@createdBy", string.Empty);
                            cmd.Parameters.AddWithValue("@updatedBy", pDModel.UpdatedBy);
                            cmd.Connection = connection;
                            connection.Open();
                            
                            var mpd = new PdModel();


                            using (SqlDataReader dataReader = cmd.ExecuteReader())
                            {
                                while (dataReader.Read())
                                {

                                    mpd.PDID = (int)dataReader["PDID"];
                                    mpd.Name = dataReader["Name"].ToString();
                                    mpd.Description = dataReader["Description"].ToString();

                                }
                            }


                            if (string.IsNullOrEmpty(pDModel.Name))
                                cmd.Parameters["@Name"].Value = mpd.Name;


                            if (string.IsNullOrEmpty(pDModel.Description))
                                cmd.Parameters["@Description"].Value = mpd.Description;


                            if (string.IsNullOrEmpty(pDModel.IsActive.ToString()))
                                cmd.Parameters["@IsActive"].Value = mpd.IsActive;


                            cmd.Parameters["@procId"].Value = 2;

                            cmd.ExecuteNonQuery();
                            connection.Close();
                            return pDModel;
                            
                        }
                    }

                }
                catch(Exception ex) { return new PdModel(); }
            });
        }

        public async Task<int> DeletePD(int id)
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
                            cmd.Parameters.AddWithValue("@PDID", id);
                            cmd.Parameters.AddWithValue("@Name", string.Empty);
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
                catch(Exception ex) { return 0; }
            });
        }

    }
}
