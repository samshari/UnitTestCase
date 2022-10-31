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
    public class MCOCMASTERRepository : IMCOCMASTERRepository
    {

        private readonly string _connectionString;
        private readonly string _storedProcedure = "dbo.spMCOCMASTERctions";

        public MCOCMASTERRepository(IAppSettings appSettings)
        {
            _connectionString = appSettings.GetConnectionString();
        }


        public async Task<List<MCOCMASTERModel>> GetCOC(int id = 0)
        {
            return await Task.Run(() =>
            {
                var result = new List<MCOCMASTERModel>();
                try
                {
                    using (SqlConnection connection = new SqlConnection(this._connectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.CommandText = _storedProcedure;
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@COCID", id);
                            cmd.Parameters.AddWithValue("@FK_COCTypeID", 0);
                            cmd.Parameters.AddWithValue("@Name", string.Empty);
                            cmd.Parameters.AddWithValue("@CreatedBy", 1);
                            cmd.Parameters.AddWithValue("@updatedBy", 1);
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
                                    var coc = new MCOCMASTERModel();
                                    coc.COCID = (int)dataReader["COCID"];
                                    coc.FK_COCTypeID = (int)dataReader["FK_COCTypeID"];
                                    coc.Name = dataReader["COCName"].ToString();
                                    coc.IsActive = Convert.ToBoolean(dataReader["IsActive"]);
                                    coc.CreatedBy = dataReader["CreatedBy"].ToString();
                                    coc.CreatedDate = Convert.ToDateTime(dataReader["CreatedDate"]).ToString(dateWithTime);
                                    coc.UpdatedBy = dataReader["UpdatedBy"].ToString();
                                    coc.UpdatedDate = Convert.ToDateTime(dataReader["UpdatedDate"]).ToString(dateWithTime);
                                    result.Add(coc);
                                }
                            }


                            connection.Close();
                            return result;
                        }
                    }
                }
                catch (Exception ex) { return new List<MCOCMASTERModel>(); }
            });
        }

        public async Task<Dictionary<MCOCMASTERModel, string>> CreateCOC(MCOCMASTERModel mCOCMASTERModel)
        {
            return await Task.Run(() =>
            {
                var result = new Dictionary<MCOCMASTERModel, string>();
                try
                {
                    using (SqlConnection connection = new SqlConnection(this._connectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.CommandText = _storedProcedure;
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@procId", 6);
                            cmd.Parameters.AddWithValue("@COCID", mCOCMASTERModel.COCID);
                            cmd.Parameters.AddWithValue("@FK_COCTypeID", mCOCMASTERModel.FK_COCTypeID);
                            cmd.Parameters.AddWithValue("@Name", mCOCMASTERModel.Name);
                            cmd.Parameters.AddWithValue("@CreatedBy", mCOCMASTERModel.CreatedBy);
                            cmd.Parameters.AddWithValue("@UpdatedBy", mCOCMASTERModel.CreatedBy);
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
                                result[mCOCMASTERModel] = "Already Exists";
                                return result;
                            }
                            mCOCMASTERModel.COCID = (int)cmd.ExecuteScalar();
                            connection.Close();
                            result[mCOCMASTERModel] = "ok";
                            return result;

                        }
                    }
                }
                catch (Exception ex) { return new Dictionary<MCOCMASTERModel, string>(); }
            });
        }

        public async Task<MCOCMASTERModel> UpdateCOC(MCOCMASTERModel mCOCMASTERModel)
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
                            cmd.Parameters.AddWithValue("@COCID", mCOCMASTERModel.COCID);
                            cmd.Parameters.AddWithValue("@FK_COCTypeID", mCOCMASTERModel.FK_COCTypeID);
                            cmd.Parameters.AddWithValue("@Name", mCOCMASTERModel.Name);
                            cmd.Parameters.AddWithValue("@CreatedBy", string.Empty);
                            cmd.Parameters.AddWithValue("@UpdatedBy", mCOCMASTERModel.UpdatedBy);
                            cmd.Connection = connection;
                            connection.Open();
                            cmd.ExecuteNonQuery();
                            connection.Close();
                            return mCOCMASTERModel;

                        }
                    }
                }
                catch (Exception ex) { return new MCOCMASTERModel(); }
            });
        }


        public async Task<int> DeleteCOC(int id)
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
                            cmd.Parameters.AddWithValue("@COCID", id);
                            cmd.Parameters.AddWithValue("@FK_COCTypeID", 0);
                            cmd.Parameters.AddWithValue("@COCName", string.Empty);
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
