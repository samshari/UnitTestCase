using Exelon.Domain;
using Exelon.Domain.Abstractions;
using Exelon.Domain.Common;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Exelon.Infrastructure.Repositories
{
    public class ENGINVESTRepository : IENGINVESTRepository
    {
        private readonly string _connectionString;
        private readonly string _storedProcedure = "dbo.spENGINVESTActions";

        public ENGINVESTRepository(IAppSettings appSettings)
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

        public async Task<List<ENGINVESTModel>> GetENGINVEST(int id = 0)
        {
            return await Task.Run(() =>
            {
                var result = new List<ENGINVESTModel>();
                try
                {
                    using(SqlConnection connection = new SqlConnection(this._connectionString))
                    {
                        using(SqlCommand cmd = new SqlCommand())
                        {
                            cmd.CommandText = _storedProcedure;
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@EnggInvestigationID", id);
                            cmd.Parameters.AddWithValue("@FK_LinkingID",1);
                            cmd.Parameters.AddWithValue("@FK_StepID", 1);
                            cmd.Parameters.AddWithValue("@FK_InnerductCOC", 1);
                            cmd.Parameters.AddWithValue("@Comments", string.Empty);
                            cmd.Parameters.AddWithValue("@CreatedBy", string.Empty);
                            cmd.Parameters.AddWithValue("@UpdatedBy", string.Empty);
                            cmd.Connection = connection;
                            if (id == 0)
                                cmd.Parameters.AddWithValue("@procId", 4);
                            else
                                cmd.Parameters.AddWithValue("@procId", 5);

                            connection.Open();
                            using(SqlDataReader dataReader = cmd.ExecuteReader())
                            {
                                while (dataReader.Read())
                                {
                                    var dateWithTime = "MM'/'dd'/'yyyy h:mm tt";
                                    var eng = new ENGINVESTModel();
                                    eng.EnggInvestigationID = (long)dataReader["EnggInvestigationID"];
                                    eng.FK_LinkingID = (long)dataReader["FK_LinkingID"];
                                    eng.FK_StepID = (int)dataReader["FK_StepID"];
                                    if (dataReader["FK_InnerductCOC"] != DBNull.Value)
                                        eng.FK_InnerductCOC = (int)dataReader["FK_InnerductCOC"];
                                    eng.Comments = dataReader["Comments"].ToString();
                                    eng.IsActive = Convert.ToBoolean(dataReader["IsActive"]);
                                    eng.CreatedBy = dataReader["CreatedBy"].ToString();
                                    eng.CreatedDate = Convert.ToDateTime(dataReader["CreatedDate"]).ToString(dateWithTime);
                                    eng.UpdatedBy = dataReader["UpdatedBy"].ToString();
                                    eng.UpdatedDate = Convert.ToDateTime(dataReader["UpdatedDate"]).ToString(dateWithTime);
                                    result.Add(eng);
                                }
                            }

                            connection.Close();
                            return result;
                        }
                    }
                }
                catch(Exception ex) { return new List<ENGINVESTModel>(); }
            });
        }


        public async Task<Dictionary<ENGINVESTModel,string>> CreateENGINVEST(ENGINVESTModel eNGINVESTModel)
        {
            return await Task.Run(() =>
            {
                var result = new Dictionary<ENGINVESTModel, string>();
                try
                {
                    using (SqlConnection connection = new SqlConnection(this._connectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.CommandText = _storedProcedure;
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@procId", 6);
                            cmd.Parameters.AddWithValue("@EnggInvestigationID", 0);
                            cmd.Parameters.AddWithValue("@FK_LinkingID", eNGINVESTModel.FK_LinkingID);
                            cmd.Parameters.AddWithValue("@FK_StepID", eNGINVESTModel.FK_StepID);
                            cmd.Parameters.AddWithValue("@FK_InnerductCOC",checkNull(eNGINVESTModel.FK_InnerductCOC));
                            cmd.Parameters.AddWithValue("@Comments", string.IsNullOrEmpty(eNGINVESTModel.Comments)?string.Empty:eNGINVESTModel.Comments);
                            cmd.Parameters.AddWithValue("@CreatedBy", eNGINVESTModel.CreatedBy);
                            cmd.Parameters.AddWithValue("@UpdatedBy", eNGINVESTModel.CreatedBy);
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
                                result[eNGINVESTModel] = "Linking ID Already Exists!";
                                return result;
                            }
                            eNGINVESTModel.EnggInvestigationID = (long)cmd.ExecuteScalar();
                            connection.Close();
                            result[eNGINVESTModel] = "ok";
                            return result;

                        }
                    }
                }
                catch (Exception ex) { return new Dictionary<ENGINVESTModel, string>(); }
            });
        }

        public async Task<ENGINVESTModel> UpdateENGINVEST(ENGINVESTModel eNGINVESTModel)
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
                            cmd.Parameters.AddWithValue("@EnggInvestigationID", eNGINVESTModel.EnggInvestigationID);
                            cmd.Parameters.AddWithValue("@FK_LinkingID", DBNull.Value);
                            cmd.Parameters.AddWithValue("@FK_StepID", DBNull.Value);
                            cmd.Parameters.AddWithValue("@FK_InnerductCOC",checkNull(eNGINVESTModel.FK_InnerductCOC));
                            cmd.Parameters.AddWithValue("@Comments", string.IsNullOrEmpty(eNGINVESTModel.Comments) ? string.Empty : eNGINVESTModel.Comments);
                            cmd.Parameters.AddWithValue("@CreatedBy", string.Empty);
                            cmd.Parameters.AddWithValue("@UpdatedBy", eNGINVESTModel.UpdatedBy);
                            cmd.Connection = connection;
                            connection.Open();
                            var eng = new ENGINVESTModel();
                            using (SqlDataReader dataReader = cmd.ExecuteReader())
                            {
                                while (dataReader.Read())
                                {
                                    
                                    eng.EnggInvestigationID = (long)dataReader["EnggInvestigationID"];
                                    eng.FK_LinkingID = (long)dataReader["FK_LinkingID"];
                                    eng.FK_StepID = (int)dataReader["FK_StepID"];
                                    if (dataReader["FK_InnerductCOC"] != DBNull.Value)
                                        eng.FK_InnerductCOC = (int)dataReader["FK_InnerductCOC"];
                                    eng.Comments = dataReader["Comments"].ToString();
                                    
                                }
                            }

                            if (string.IsNullOrEmpty(eNGINVESTModel.Comments))
                                cmd.Parameters["@Comments"].Value = eng.Comments;
                            cmd.Parameters["@FK_InnerductCOC"].Value =checkNullWithValue(eNGINVESTModel.FK_InnerductCOC,eng.FK_InnerductCOC);
                            cmd.Parameters["@procId"].Value = 2;
                            cmd.ExecuteNonQuery();
                            connection.Close();
                            return eNGINVESTModel;

                        }
                    }
                
                }
                catch (Exception ex) { return new ENGINVESTModel(); }
            });
        }

        public async Task<int> DeleteENGINVEST(int id)
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
                            cmd.Parameters.AddWithValue("@EnggInvestigationID", id);
                            cmd.Parameters.AddWithValue("@FK_LinkingID", 1);
                            cmd.Parameters.AddWithValue("@FK_StepID", 1);
                            cmd.Parameters.AddWithValue("@FK_InnerductCOC", 1);
                            cmd.Parameters.AddWithValue("@Comments", string.Empty);
                            cmd.Parameters.AddWithValue("@CreatedBy", string.Empty);
                            cmd.Parameters.AddWithValue("@UpdatedBy", string.Empty);
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
