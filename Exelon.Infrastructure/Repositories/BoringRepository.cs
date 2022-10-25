using Exelon.Domain;
using Exelon.Domain.Abstractions;
using Exelon.Domain.Common;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Exelon.Infrastructure.Repositories
{
    public class BORINGRepository : IBORINGRepository
    {
        private readonly string _connectionString;
        private readonly string _storedProcedure = "dbo.spBORINGActions";

        public BORINGRepository(IAppSettings appSettings)
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
        public async Task<List<BORINGModel>> GetBORE(int id = 0)
        {
            return await Task.Run(() =>
            {
                var result = new List<BORINGModel>();
                try
                {
                    using (SqlConnection connection = new SqlConnection(this._connectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.CommandText = _storedProcedure;
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@BoringID", id);
                            cmd.Parameters.AddWithValue("@FK_LinkingID", 0);
                            cmd.Parameters.AddWithValue("@FK_stepID", 0);
                            cmd.Parameters.AddWithValue("@FK_BoringCOCID", 0);
                            cmd.Parameters.AddWithValue("@IssuesOrComments", string.Empty);
                            cmd.Parameters.AddWithValue("@StartDate", DBNull.Value);
                            cmd.Parameters.AddWithValue("@EndDate",DBNull.Value );
                            cmd.Parameters.AddWithValue("@WeeklyFTECount", string.Empty);
                            cmd.Parameters.AddWithValue("@CreatedBy", string.Empty);
                            cmd.Parameters.AddWithValue("@updatedBy", string.Empty);
                            cmd.Connection = connection;
                            connection.Open();

                            if (id == 0)
                                cmd.Parameters.AddWithValue("@procId", 4);
                            else
                                cmd.Parameters.AddWithValue("@procId", 5);

                            using(SqlDataReader dataReader = cmd.ExecuteReader())
                            {
                                while (dataReader.Read())
                                {
                                    var onlyDate = "MM'/'dd'/'yyyy";
                                    var dateWithTime = "MM'/'dd'/'yyyy h:mm tt";
                                    var bore = new BORINGModel();
                                    bore.BoringID = (long)dataReader["BoringID"];
                                    bore.FK_LinkingID = (long)dataReader["FK_LinkingID"];
                                    bore.FK_stepID = (int)dataReader["FK_stepID"];
                                    if(dataReader["FK_BoringCOCID"] != DBNull.Value)
                                        bore.FK_BoringCOCID = (int)dataReader["FK_BoringCOCID"];
                                    bore.IssuesOrComments = dataReader["IssuesOrComments"].ToString();
                                    if(dataReader["StartDate"] != DBNull.Value)
                                        bore.StartDate = Convert.ToDateTime(dataReader["StartDate"]);
                                    if(dataReader["EndDate"] != DBNull.Value)
                                        bore.EndDate = Convert.ToDateTime(dataReader["EndDate"]);
                                    if (dataReader["StartDate"] != DBNull.Value)
                                        bore.StrStartDate = Convert.ToDateTime(dataReader["StartDate"]).ToString(onlyDate);
                                    if (dataReader["EndDate"] != DBNull.Value)
                                        bore.StrEndDate = Convert.ToDateTime(dataReader["EndDate"]).ToString(onlyDate);
                                    bore.WeeklyFTECount = dataReader["WeeklyFTECount"].ToString();
                                    bore.IsActive = Convert.ToBoolean(dataReader["IsActive"]);
                                    bore.CreatedBy = dataReader["CreatedBy"].ToString();
                                    bore.CreatedDate = Convert.ToDateTime(dataReader["CreatedDate"]).ToString(dateWithTime);
                                    bore.UpdatedBy = dataReader["UpdatedBy"].ToString();
                                    bore.UpdatedDate = Convert.ToDateTime(dataReader["UpdatedDate"]).ToString(dateWithTime);
                                    result.Add(bore);
                                }
                            }


                            connection.Close();
                            return result;


                        }
                    }
                }
                catch (Exception ex) { return new List<BORINGModel>(); }
            });
        }


        public async Task<Dictionary<BORINGModel, string>> CreateBORE(BORINGModel bORINGModel)
        {
            return await Task.Run(() =>
            {
                var result = new Dictionary<BORINGModel, string>();
                try
                {
                    using (SqlConnection connection = new SqlConnection(this._connectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.CommandText = _storedProcedure;
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@procId", 6);
                            cmd.Parameters.AddWithValue("@BoringID", bORINGModel.BoringID);
                            cmd.Parameters.AddWithValue("@FK_LinkingID", bORINGModel.FK_LinkingID);
                            cmd.Parameters.AddWithValue("@FK_stepID", bORINGModel.FK_stepID);
                            cmd.Parameters.AddWithValue("@FK_BoringCOCID", checkNull(bORINGModel.FK_BoringCOCID));
                            cmd.Parameters.AddWithValue("@IssuesOrComments",string.IsNullOrEmpty(bORINGModel.IssuesOrComments)?string.Empty:bORINGModel.IssuesOrComments);
                            cmd.Parameters.AddWithValue("@StartDate",checkNull(bORINGModel.StartDate));
                            cmd.Parameters.AddWithValue("@EndDate", checkNull(bORINGModel.EndDate));
                            cmd.Parameters.AddWithValue("@WeeklyFTECount", string.IsNullOrEmpty(bORINGModel.WeeklyFTECount)?string.Empty:bORINGModel.WeeklyFTECount);
                            cmd.Parameters.AddWithValue("@CreatedBy", bORINGModel.CreatedBy);
                            cmd.Parameters.AddWithValue("@UpdatedBy", bORINGModel.CreatedBy);
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
                                result[bORINGModel] = "Linking Id Already Exists!";
                                return result;
                            }
                            bORINGModel.BoringID = (long)cmd.ExecuteScalar();
                            result[bORINGModel] = "ok";
                            connection.Close();
                            return result;

                        }
                    }
                }
                catch (Exception ex) { return new Dictionary<BORINGModel, string>(); }
            });
        }

        public async Task<BORINGModel> UpdateBORE(BORINGModel bORINGModel)
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
                            cmd.Parameters.AddWithValue("@BoringID", bORINGModel.BoringID);
                            cmd.Parameters.AddWithValue("@FK_LinkingID", bORINGModel.FK_LinkingID);
                            cmd.Parameters.AddWithValue("@FK_stepID", bORINGModel.FK_stepID);
                            cmd.Parameters.AddWithValue("@FK_BoringCOCID", checkNull(bORINGModel.FK_BoringCOCID));
                            cmd.Parameters.AddWithValue("@IssuesOrComments", string.IsNullOrEmpty(bORINGModel.IssuesOrComments) ? string.Empty : bORINGModel.IssuesOrComments);
                            cmd.Parameters.AddWithValue("@StartDate", checkNull(bORINGModel.StartDate));
                            cmd.Parameters.AddWithValue("@EndDate", checkNull(bORINGModel.EndDate));
                            cmd.Parameters.AddWithValue("@WeeklyFTECount", string.IsNullOrEmpty(bORINGModel.WeeklyFTECount) ? string.Empty : bORINGModel.WeeklyFTECount);
                            cmd.Parameters.AddWithValue("@CreatedBy", string.Empty);
                            cmd.Parameters.AddWithValue("@UpdatedBy", bORINGModel.UpdatedBy);
                            cmd.Connection = connection;
                            connection.Open();


                            var bore = new BORINGModel();
                            using (SqlDataReader dataReader = cmd.ExecuteReader())
                            {
                                while (dataReader.Read())
                                {
                                    
                                    bore.BoringID = (long)dataReader["BoringID"];
                                    bore.FK_LinkingID = (long)dataReader["FK_LinkingID"];
                                    bore.FK_stepID = (int)dataReader["FK_stepID"];
                                    if (dataReader["FK_BoringCOCID"] != DBNull.Value)
                                        bore.FK_BoringCOCID = (int)dataReader["FK_BoringCOCID"];
                                    bore.IssuesOrComments = dataReader["IssuesOrComments"].ToString();
                                    if (dataReader["StartDate"] != DBNull.Value)
                                        bore.StartDate = Convert.ToDateTime(dataReader["StartDate"]);
                                    if (dataReader["EndDate"] != DBNull.Value)
                                        bore.EndDate = Convert.ToDateTime(dataReader["EndDate"]);
                                    bore.WeeklyFTECount = dataReader["WeeklyFTECount"].ToString();
                                    bore.WeeklyFTECount = dataReader["WeeklyFTECount"].ToString();

                                }
                            }

                            if (string.IsNullOrEmpty(bORINGModel.WeeklyFTECount))
                                cmd.Parameters["@WeeklyFTECount"].Value = bore.WeeklyFTECount;

                            if (string.IsNullOrEmpty(bORINGModel.IssuesOrComments))
                                cmd.Parameters["@IssuesOrComments"].Value = bore.IssuesOrComments;
                            cmd.Parameters["@FK_BoringCOCID"].Value =checkNullWithValue(bORINGModel.FK_BoringCOCID, bore.FK_BoringCOCID);
                            cmd.Parameters["@StartDate"].Value =checkNullWithValue(bORINGModel.StartDate,bore.StartDate);
                            cmd.Parameters["@EndDate"].Value =checkNullWithValue(bORINGModel.EndDate,bore.EndDate);
                            cmd.Parameters["@procId"].Value = 2;
                            cmd.ExecuteNonQuery();
                            connection.Close();
                            return bORINGModel;
                        }
                    }
                }
                catch (Exception ex) { return new BORINGModel();  }
            });
        }
        

        public async Task<int> DeleteBORE(int id)
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
                            cmd.Parameters.AddWithValue("@BoringID", id);
                            cmd.Parameters.AddWithValue("@FK_LinkingID", 0);
                            cmd.Parameters.AddWithValue("@FK_stepID", 0);
                            cmd.Parameters.AddWithValue("@FK_BoringCOCID", 0);
                            cmd.Parameters.AddWithValue("@IssuesOrComments", string.Empty);
                            cmd.Parameters.AddWithValue("@StartDate", DBNull.Value);
                            cmd.Parameters.AddWithValue("@EndDate", DBNull.Value);
                            cmd.Parameters.AddWithValue("@WeeklyFTECount", string.Empty);
                            cmd.Parameters.AddWithValue("@CreatedBy", string.Empty);
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
