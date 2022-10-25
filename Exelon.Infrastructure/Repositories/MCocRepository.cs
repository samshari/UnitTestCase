
#region [ Namespaces ]

using Exelon.Domain;
using Exelon.Domain.Abstractions;
using Exelon.Domain.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

#endregion

namespace Exelon.Infrastructure.Repositories
{
    public class MCocRepository : IMCocRepository
    {


        private readonly string _connectionString;

        private readonly string _storedProcedureName = "[dbo].[spMCOCActions]";

        public MCocRepository(IAppSettings appSettings)
        {
            _connectionString = appSettings.GetConnectionString();
        }


        

        #region [Get MCOC]
        public async Task<List<MCOCModel>> GetMCOC(int id=0)
        {
            return await Task.Run(() =>
            {
                var lstMCOC = new List<MCOCModel>();
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
                                    var mcoc = new MCOCModel();
                                    mcoc.ID = (int)dataReader["ID"];
                                    mcoc.Name = dataReader["Name"].ToString();
                                    mcoc.IsActive = Convert.ToBoolean(dataReader["IsActive"]);
                                    mcoc.CreatedBy = dataReader["CreatedBy"].ToString();
                                    mcoc.CreatedDate = Convert.ToDateTime(dataReader["CreatedDate"]).ToString(dateWithTime);
                                    mcoc.UpdatedBy = dataReader["UpdatedBy"].ToString();
                                    mcoc.UpdatedDate = Convert.ToDateTime(dataReader["UpdatedDate"]).ToString(dateWithTime);
                                    lstMCOC.Add(mcoc);
                                     

                                }

                            }
                            connection.Close();
                        }
                    }
                    return lstMCOC;
                }
                catch (Exception ex) { return new List<MCOCModel>(); }
            });
        }
        #endregion


        #region [Create MCOC]
        /// <summary>
        /// Create MCOC
        /// </summary>
        /// <param name="mCOCModel"></param>
        /// <returns></returns>
        public async Task<Dictionary<MCOCModel,string>> CreateMCOC(MCOCModel mCOCModel)
        {
            return await Task.Run(() =>
            {
                var result = new Dictionary<MCOCModel, string>();
                try
                {

                    using (SqlConnection con = new SqlConnection(this._connectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.CommandText = _storedProcedureName;
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@procId", 6);
                            cmd.Parameters.AddWithValue("@Id", 0);
                            cmd.Parameters.AddWithValue("@name", mCOCModel.Name);
                            cmd.Parameters.AddWithValue("@createdBy", mCOCModel.CreatedBy);
                            cmd.Parameters.AddWithValue("@updatedBy", mCOCModel.CreatedBy);
                            cmd.Connection = con;
                            con.Open();
                            int check = (int)cmd.ExecuteScalar();
                            if (check == 1)
                            {
                                cmd.Parameters["@procID"].Value = 1;
                                mCOCModel.ID = (int)cmd.ExecuteScalar();

                            }
                            else
                            {
                                con.Close();
                                result[mCOCModel] = "Already Exists";
                                return result;
                            }
                            con.Close();
                            result[mCOCModel] = "ok";
                            return result;
                        }
                    }
                }
                catch (Exception ex) { return new Dictionary<MCOCModel, string>(); }
            });
        }
        #endregion


        public async Task<int> DeleteMCOC(int id)
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
                            cmd.Parameters.AddWithValue("@name", string.Empty);
                            cmd.Parameters.AddWithValue("@createdBy", string.Empty);
                            cmd.Parameters.AddWithValue("@updatedBy", string.Empty);
                            cmd.Connection = con;
                            con.Open();
                            int check = (int)cmd.ExecuteScalar();
                            con.Close();
                            return check;
                        }
                    }
                }
                catch (Exception ex) { return 0; }
            });
        }



        #region [Update MCOC]
        /// <summary>
        /// Update MCOC
        /// </summary>
        /// <param name="mCOCModel"></param>
        /// <returns></returns>
        public async Task<Dictionary<MCOCModel, string>> UpdateMCOC(MCOCModel mCOCModel)
        {
            return await Task.Run(() =>
            {
                var result = new Dictionary<MCOCModel, string>();
                try
                {

                    using (SqlConnection con = new SqlConnection(this._connectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.CommandText = _storedProcedureName;
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@procId", 6);
                            cmd.Parameters.AddWithValue("@Id", mCOCModel.ID);
                            cmd.Parameters.AddWithValue("@name", mCOCModel.Name);
                            cmd.Parameters.AddWithValue("@createdBy", string.Empty);
                            cmd.Parameters.AddWithValue("@updatedBy", mCOCModel.UpdatedBy);
                            cmd.Connection = con;
                            con.Open();
                            int check = (int)cmd.ExecuteScalar();
                            if (check == 1)
                            {
                                cmd.Parameters["@procId"].Value = 2;
                                cmd.ExecuteNonQuery();
                            }
                            else
                            {
                                con.Close();
                                result[mCOCModel] = "Already Exists!";
                                return result;
                            }
                            con.Close();
                            result[mCOCModel] = "ok";
                            return result;
                        }
                    }
                }
                catch (Exception ex) { return new Dictionary<MCOCModel, string>(); }
            });
        }
        #endregion
    }
}
