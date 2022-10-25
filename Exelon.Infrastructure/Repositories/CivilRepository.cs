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
    public class CIVILRepository : ICIVILRepository
    {
        private readonly string _connectionString;
        private readonly string _storedProcedure = "dbo.spCIVILActions";

        public CIVILRepository(IAppSettings appSettings)
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

        public async Task<List<CIVILModel>> GetCIVIL(int id = 0)
        {
            return await Task.Run(() =>
            {
                var result = new List<CIVILModel>();
                try
                {
                    using (SqlConnection connection = new SqlConnection(this._connectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.CommandText = _storedProcedure;
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@CivilID", id);
                            cmd.Parameters.AddWithValue("@FK_LinkingID", 0);
                            cmd.Parameters.AddWithValue("@FK_stepID", 0);
                            cmd.Parameters.AddWithValue("@FK_CivilCOCID", 0);
                            cmd.Parameters.AddWithValue("@IssuesOrComments", string.Empty);
                            cmd.Parameters.AddWithValue("@StartDate", DBNull.Value);
                            cmd.Parameters.AddWithValue("@EndDate", DBNull.Value);
                            cmd.Parameters.AddWithValue("@WeeklyFTECount", string.Empty);
                            cmd.Parameters.AddWithValue("@CreatedBy", string.Empty);
                            cmd.Parameters.AddWithValue("@UpdatedBy", string.Empty);
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
                                    var onlyDate = "MM'/'dd'/'yyyy";
                                    var dateWithTime = "MM'/'dd'/'yyyy h:mm tt";
                                    var civil = new CIVILModel();
                                    civil.CivilID = (long)dataReader["CivilID"];
                                    civil.FK_LinkingID = (long)dataReader["FK_LinkingID"];
                                    civil.FK_stepID = (int)dataReader["FK_stepID"];
                                    if(dataReader["FK_CivilCOCID"] != DBNull.Value)
                                        civil.FK_CivilCOCID = (int)dataReader["FK_CivilCOCID"];
                                    civil.IssuesOrComments = dataReader["IssuesOrComments"].ToString();
                                    if (dataReader["StartDate"] != DBNull.Value)
                                        civil.StartDate = Convert.ToDateTime(dataReader["StartDate"]);
                                    if (dataReader["EndDate"] != DBNull.Value)
                                        civil.EndDate = Convert.ToDateTime(dataReader["EndDate"]);
                                    if (dataReader["StartDate"] != DBNull.Value)
                                        civil.StrStartDate = Convert.ToDateTime(dataReader["StartDate"]).ToString(onlyDate);
                                    if (dataReader["EndDate"] != DBNull.Value)
                                        civil.StrEndDate = Convert.ToDateTime(dataReader["EndDate"]).ToString(onlyDate);
                                    civil.WeeklyFTECount = dataReader["WeeklyFTECount"].ToString();
                                    civil.WeeklyFTECount = dataReader["WeeklyFTECount"].ToString();
                                    civil.IsActive = Convert.ToBoolean(dataReader["IsActive"]);
                                    civil.CreatedBy = dataReader["CreatedBy"].ToString();
                                    civil.CreatedDate = Convert.ToDateTime(dataReader["CreatedDate"]).ToString(dateWithTime);
                                    civil.UpdatedBy = dataReader["UpdatedBy"].ToString();
                                    civil.UpdatedDate = Convert.ToDateTime(dataReader["UpdatedDate"]).ToString(dateWithTime);
                                    result.Add(civil);
                                }
                            }


                            connection.Close();
                            return result;


                        }
                    }
                }
                catch (Exception ex) { return new List<CIVILModel>(); }
            });
        }


        public async Task<Dictionary<CIVILModel, string>> CreateCIVIL(CIVILModel cIVILModel)
        {
            return await Task.Run(() =>
            {
                var result = new Dictionary<CIVILModel, string>();
                try
                {
                    using (SqlConnection connection = new SqlConnection(this._connectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.CommandText = _storedProcedure;
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@procId", 6);
                            cmd.Parameters.AddWithValue("@CivilID", cIVILModel.CivilID);
                            cmd.Parameters.AddWithValue("@FK_LinkingID", cIVILModel.FK_LinkingID);
                            cmd.Parameters.AddWithValue("@FK_stepID", cIVILModel.FK_stepID);
                            cmd.Parameters.AddWithValue("@FK_CivilCOCID",checkNull(cIVILModel.FK_CivilCOCID));
                            cmd.Parameters.AddWithValue("@IssuesOrComments", string.IsNullOrEmpty(cIVILModel.IssuesOrComments) ? string.Empty : cIVILModel.IssuesOrComments);
                            cmd.Parameters.AddWithValue("@StartDate",checkNull(cIVILModel.StartDate));
                            cmd.Parameters.AddWithValue("@EndDate",checkNull(cIVILModel.EndDate));
                            cmd.Parameters.AddWithValue("@WeeklyFTECount", string.IsNullOrEmpty(cIVILModel.WeeklyFTECount) ? string.Empty : cIVILModel.WeeklyFTECount);
                            cmd.Parameters.AddWithValue("@CreatedBy", cIVILModel.CreatedBy);
                            cmd.Parameters.AddWithValue("@UpdatedBy", cIVILModel.CreatedBy);
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
                                result[cIVILModel] = "Linking Id Already Exists!";
                                return result;
                            }
                            cIVILModel.CivilID = (long)cmd.ExecuteScalar();
                            result[cIVILModel] = "ok";
                            connection.Close();
                            return result;

                        }
                    }
                }
                catch (Exception ex) { return new Dictionary<CIVILModel, string>(); }
            });
        }

        public async Task<CIVILModel> UpdateCIVIL(CIVILModel cIVILModel)
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
                            cmd.Parameters.AddWithValue("@CivilID", cIVILModel.CivilID);
                            cmd.Parameters.AddWithValue("@FK_LinkingID", cIVILModel.FK_LinkingID);
                            cmd.Parameters.AddWithValue("@FK_stepID", cIVILModel.FK_stepID);
                            cmd.Parameters.AddWithValue("@FK_CivilCOCID", checkNull(cIVILModel.FK_CivilCOCID));
                            cmd.Parameters.AddWithValue("@IssuesOrComments", string.IsNullOrEmpty(cIVILModel.IssuesOrComments) ? string.Empty : cIVILModel.IssuesOrComments);
                            cmd.Parameters.AddWithValue("@StartDate", checkNull(cIVILModel.StartDate));
                            cmd.Parameters.AddWithValue("@EndDate", checkNull(cIVILModel.EndDate));
                            cmd.Parameters.AddWithValue("@WeeklyFTECount", string.IsNullOrEmpty(cIVILModel.WeeklyFTECount) ? string.Empty : cIVILModel.WeeklyFTECount);
                            cmd.Parameters.AddWithValue("@CreatedBy", string.Empty);
                            cmd.Parameters.AddWithValue("@UpdatedBy", cIVILModel.UpdatedBy);
                            cmd.Connection = connection;
                            connection.Open();
                            var civil = new CIVILModel();
                            using (SqlDataReader dataReader = cmd.ExecuteReader())
                            {
                                while (dataReader.Read())
                                {

                                    civil.CivilID = (long)dataReader["CivilID"];
                                    civil.FK_LinkingID = (long)dataReader["FK_LinkingID"];
                                    civil.FK_stepID = (int)dataReader["FK_stepID"];
                                    if (dataReader["FK_CivilCOCID"] != DBNull.Value)
                                        civil.FK_CivilCOCID = (int)dataReader["FK_CivilCOCID"];
                                    civil.IssuesOrComments = dataReader["IssuesOrComments"].ToString();
                                    if (dataReader["StartDate"] != DBNull.Value)
                                        civil.StartDate = Convert.ToDateTime(dataReader["StartDate"]);
                                    if (dataReader["EndDate"] != DBNull.Value)
                                        civil.EndDate = Convert.ToDateTime(dataReader["EndDate"]);
                                    civil.WeeklyFTECount = dataReader["WeeklyFTECount"].ToString();

                                }
                            }

                            if (string.IsNullOrEmpty(cIVILModel.WeeklyFTECount))
                                cmd.Parameters["@WeeklyFTECount"].Value = civil.WeeklyFTECount;

                            if (string.IsNullOrEmpty(cIVILModel.IssuesOrComments))
                                cmd.Parameters["@IssuesOrComments"].Value = civil.IssuesOrComments;
                            cmd.Parameters["@FK_CivilCOCID"].Value =checkNullWithValue(cIVILModel.FK_CivilCOCID,civil.FK_CivilCOCID);
                            cmd.Parameters["@StartDate"].Value =checkNullWithValue(cIVILModel.StartDate,civil.StartDate);
                            cmd.Parameters["@EndDate"].Value =checkNullWithValue(cIVILModel.EndDate,civil.EndDate);
                            cmd.Parameters["@procId"].Value = 2;
                            cmd.ExecuteNonQuery();
                            connection.Close();
                            return cIVILModel;
                        }
                    }
                }
                catch (Exception ex) { return new CIVILModel(); }
            });
        }


        public async Task<int> DeleteCIVIL(int id)
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
                            cmd.Parameters.AddWithValue("@CivilID", id);
                            cmd.Parameters.AddWithValue("@FK_LinkingID", 0);
                            cmd.Parameters.AddWithValue("@FK_stepID", 0);
                            cmd.Parameters.AddWithValue("@FK_CivilCOCID", 0);
                            cmd.Parameters.AddWithValue("@IssuesOrComments", string.Empty);
                            cmd.Parameters.AddWithValue("@StartDate", DBNull.Value);
                            cmd.Parameters.AddWithValue("@EndDate", DBNull.Value);
                            cmd.Parameters.AddWithValue("@WeeklyFTECount", string.Empty);
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
