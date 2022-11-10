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
    public class PRECONSTRUCTIONRepository : IPRECONSTRUCTIONRepository
    {
        private readonly string _connectionString;
        private readonly string _storedProcedure = "dbo.spPRECONSTActions";

        public PRECONSTRUCTIONRepository(IAppSettings appSettings)
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

        public async  Task<List<PRECONSTRUCTIONModel>> GetPreConstruction(int id = 0)
        {
            return await Task.Run(() =>
            {
                var result = new List<PRECONSTRUCTIONModel>();
                try
                {
                    using(SqlConnection connection = new SqlConnection(this._connectionString))
                    {
                        using(SqlCommand cmd = new SqlCommand())
                        {
                            cmd.CommandText = _storedProcedure;
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@PreContructionID", id);
                            cmd.Parameters.AddWithValue("@FK_LinkingID", 0);
                            cmd.Parameters.AddWithValue("@FK_EnvironmentalCOCID", 0);
                            cmd.Parameters.AddWithValue("@FK_VegRequired", 0);
                            cmd.Parameters.AddWithValue("@FK_StackingRequired", 0);
                            cmd.Parameters.AddWithValue("@FK_MattingRequired", 0);
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
                                    var preconst = new PRECONSTRUCTIONModel();
                                    preconst.PreContructionID = (long)dataReader["PreContructionID"];
                                    preconst.FK_LinkingID = (long)dataReader["ExecutionLinkingID"];
                                    if (dataReader["FK_EnvironmentalCOCID"] != DBNull.Value)
                                        preconst.FK_EnvironmentalCOCID = (int)dataReader["FK_EnvironmentalCOCID"];
                                    if (dataReader["FK_VegRequired"] != DBNull.Value)
                                        preconst.FK_VegRequired = (int)dataReader["FK_VegRequired"];
                                    if (dataReader["FK_StackingRequired"] != DBNull.Value)
                                        preconst.FK_StackingRequired = (int)dataReader["FK_StackingRequired"];
                                    if (dataReader["FK_MattingRequired"] != DBNull.Value)
                                        preconst.FK_MattingRequired = (int)dataReader["FK_MattingRequired"];
                                    preconst.IsActive = Convert.ToBoolean(dataReader["IsActive"]);
                                    preconst.CreatedBy = dataReader["CreatedBy"].ToString();
                                    preconst.CreatedDate = Convert.ToDateTime(dataReader["CreatedDate"]).ToString(dateWithTime);
                                    preconst.UpdatedBy = dataReader["UpdatedBy"].ToString();
                                    preconst.UpdatedDate = Convert.ToDateTime(dataReader["UpdatedDate"]).ToString(dateWithTime);
                                    result.Add(preconst);

                                }
                            }
                            connection.Close();
                            return result;

                        }
                    }
                }
                catch(Exception ex) { return new List<PRECONSTRUCTIONModel>(); }
            });
        }

        public async Task<Dictionary<PRECONSTRUCTIONModel, string>> CreatePreConstruction(PRECONSTRUCTIONModel pRECONSTRUCTIONModel)
        {
            return await Task.Run(() =>
            {
                var result = new Dictionary<PRECONSTRUCTIONModel, string>();
                try
                {
                    using (SqlConnection connection = new SqlConnection(this._connectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.CommandText = _storedProcedure;
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@procId", 6);
                            cmd.Parameters.AddWithValue("@PreContructionID", pRECONSTRUCTIONModel.PreContructionID);
                            cmd.Parameters.AddWithValue("@FK_LinkingID", pRECONSTRUCTIONModel.FK_LinkingID);
                            cmd.Parameters.AddWithValue("@FK_EnvironmentalCOCID",checkNull(pRECONSTRUCTIONModel.FK_EnvironmentalCOCID));
                            cmd.Parameters.AddWithValue("@FK_VegRequired", checkNull(pRECONSTRUCTIONModel.FK_VegRequired));
                            cmd.Parameters.AddWithValue("@FK_StackingRequired",checkNull(pRECONSTRUCTIONModel.FK_StackingRequired));
                            cmd.Parameters.AddWithValue("@FK_MattingRequired",checkNull(pRECONSTRUCTIONModel.FK_MattingRequired));
                            cmd.Parameters.AddWithValue("@createdBy", pRECONSTRUCTIONModel.CreatedBy);
                            cmd.Parameters.AddWithValue("@updatedBy", pRECONSTRUCTIONModel.CreatedBy);
                            cmd.Connection = connection;
                            connection.Open();
                            int check = (int)cmd.ExecuteScalar();
                            if(check == 1)
                            {
                                cmd.Parameters["@procId"].Value = 1;
                            }
                            else
                            {
                                connection.Close();
                                result[pRECONSTRUCTIONModel] = "Linking Id Already Exists!";
                                return result;
                            }

                            pRECONSTRUCTIONModel.PreContructionID = (long)cmd.ExecuteScalar();
                            result[pRECONSTRUCTIONModel] = "ok";
                            connection.Close();
                            return result;

                        }
                    }
                }
                catch (Exception ex) { return new Dictionary<PRECONSTRUCTIONModel, string>(); }
            });
        }

        public async Task<PRECONSTRUCTIONModel> UpdatePreConstruction(PRECONSTRUCTIONModel pRECONSTRUCTIONModel)
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
                            cmd.Parameters.AddWithValue("@PreContructionID", pRECONSTRUCTIONModel.PreContructionID);
                            cmd.Parameters.AddWithValue("@FK_LinkingID", pRECONSTRUCTIONModel.FK_LinkingID);
                            cmd.Parameters.AddWithValue("@FK_EnvironmentalCOCID", checkNull(pRECONSTRUCTIONModel.FK_EnvironmentalCOCID));
                            cmd.Parameters.AddWithValue("@FK_VegRequired", checkNull(pRECONSTRUCTIONModel.FK_VegRequired));
                            cmd.Parameters.AddWithValue("@FK_StackingRequired", checkNull(pRECONSTRUCTIONModel.FK_StackingRequired));
                            cmd.Parameters.AddWithValue("@FK_MattingRequired", checkNull(pRECONSTRUCTIONModel.FK_MattingRequired)); 
                            cmd.Parameters.AddWithValue("@createdBy", string.Empty);
                            cmd.Parameters.AddWithValue("@updatedBy", pRECONSTRUCTIONModel.UpdatedBy);
                            cmd.Connection = connection;
                            connection.Open();
                            cmd.ExecuteNonQuery();
                            connection.Close();
                            return pRECONSTRUCTIONModel;

                        }
                    }
                }
                catch (Exception ex) { return new PRECONSTRUCTIONModel(); }
            });
        }

        public async Task<int> DeletePreConstruction(int id)
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
                            cmd.Parameters.AddWithValue("@PreContructionID", id);
                            cmd.Parameters.AddWithValue("@FK_LinkingID", 0);
                            cmd.Parameters.AddWithValue("@FK_EnvironmentalCOCID", 0);
                            cmd.Parameters.AddWithValue("@FK_VegRequired", 0);
                            cmd.Parameters.AddWithValue("@FK_StackingRequired", 0);
                            cmd.Parameters.AddWithValue("@FK_MattingRequired", 0);
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
    }
}
