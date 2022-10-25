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
    public class OVHDMKRepository : IOVHDMKRepository
    {
        private readonly string _connectionString;
        private readonly string _storedProcedure = "dbo.spOVHDNKActions";

        public OVHDMKRepository(IAppSettings appSettings)
        {
            _connectionString = appSettings.GetConnectionString();
        }

        public async Task<List<OVHDMKModel>> GetOVHD(int id = 0)
        {
            return await Task.Run(() =>
            {
                var result = new List<OVHDMKModel>();
                try
                {
                    using (SqlConnection connection = new SqlConnection(this._connectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.CommandText = _storedProcedure;
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@OVHDMakeReadyID", id);
                            cmd.Parameters.AddWithValue("@FK_LinkingID", 0);
                            cmd.Parameters.AddWithValue("@FK_stepID", 0);
                            cmd.Parameters.AddWithValue("@FK_OVHDCOCID", 0);
                            cmd.Parameters.AddWithValue("@IssuesOrComments", string.Empty);
                            cmd.Parameters.AddWithValue("@StartDate", DBNull.Value);
                            cmd.Parameters.AddWithValue("@EndDate", DBNull.Value);
                            cmd.Parameters.AddWithValue("@WeeklyFTECount", string.Empty);
                            cmd.Parameters.AddWithValue("@CreatedBy", string.Empty);
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
                                    var onlyDate = "MM'/'dd'/'yyyy";
                                    var dateWithTime = "MM'/'dd'/'yyyy h:mm tt";
                                    var ovhd = new OVHDMKModel();
                                    ovhd.OVHDMakeReadyID = (long)dataReader["OVHDMakeReadyID"];
                                    ovhd.FK_LinkingID = (long)dataReader["FK_LinkingID"];
                                    ovhd.FK_stepID = (int)dataReader["FK_stepID"];
                                    if(dataReader["FK_OVHDCOCID"]!=DBNull.Value)
                                        ovhd.FK_OVHDCOCID = (int)dataReader["FK_OVHDCOCID"];
                                    ovhd.IssuesOrComments = dataReader["IssuesOrComments"].ToString();
                                    if (dataReader["StartDate"] != DBNull.Value)
                                        ovhd.StartDate = Convert.ToDateTime(dataReader["StartDate"]);
                                    if (dataReader["EndDate"] != DBNull.Value)
                                        ovhd.EndDate = Convert.ToDateTime(dataReader["EndDate"]);

                                    if (dataReader["StartDate"] != DBNull.Value)
                                        ovhd.StrStartDate = Convert.ToDateTime(dataReader["StartDate"]).ToString(onlyDate);
                                    if (dataReader["EndDate"] != DBNull.Value)
                                        ovhd.StrEndDate = Convert.ToDateTime(dataReader["EndDate"]).ToString(onlyDate);

                                    ovhd.WeeklyFTECount = dataReader["WeeklyFTECount"].ToString();
                                    ovhd.IsActive = Convert.ToBoolean(dataReader["IsActive"]);
                                    ovhd.CreatedBy = dataReader["CreatedBy"].ToString();
                                    ovhd.CreatedDate = Convert.ToDateTime(dataReader["CreatedDate"]).ToString(dateWithTime);
                                    ovhd.UpdatedBy = dataReader["UpdatedBy"].ToString();
                                    ovhd.UpdatedDate = Convert.ToDateTime(dataReader["UpdatedDate"]).ToString(dateWithTime);
                                    result.Add(ovhd);
                                }
                            }


                            connection.Close();
                            return result;


                        }
                    }
                }
                catch (Exception ex) { return new List<OVHDMKModel>(); }
            });
        }


        public async Task<Dictionary<OVHDMKModel, string>> CreateOVHD(OVHDMKModel oVHDMKModel)
        {
            return await Task.Run(() =>
            {
                var result = new Dictionary<OVHDMKModel, string>();
                try
                {
                    using (SqlConnection connection = new SqlConnection(this._connectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.CommandText = _storedProcedure;
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@procId", 6);
                            cmd.Parameters.AddWithValue("@OVHDMakeReadyID", oVHDMKModel.OVHDMakeReadyID);
                            cmd.Parameters.AddWithValue("@FK_LinkingID", oVHDMKModel.FK_LinkingID);
                            cmd.Parameters.AddWithValue("@FK_stepID", oVHDMKModel.FK_stepID);
                            if (oVHDMKModel.FK_OVHDCOCID == null)
                                cmd.Parameters.AddWithValue("@FK_OVHDCOCID", DBNull.Value);
                            else
                                cmd.Parameters.AddWithValue("@FK_OVHDCOCID", oVHDMKModel.FK_OVHDCOCID);

                            cmd.Parameters.AddWithValue("@IssuesOrComments", string.IsNullOrEmpty(oVHDMKModel.IssuesOrComments) ? string.Empty : oVHDMKModel.IssuesOrComments);

                            if (oVHDMKModel.StartDate == null)
                                cmd.Parameters.AddWithValue("@StartDate", DBNull.Value);
                            else
                                cmd.Parameters.AddWithValue("@StartDate", oVHDMKModel.StartDate);

                            if (oVHDMKModel.EndDate == null)
                                cmd.Parameters.AddWithValue("@EndDate", DBNull.Value);
                            else
                                cmd.Parameters.AddWithValue("@EndDate", oVHDMKModel.EndDate);

                            cmd.Parameters.AddWithValue("@WeeklyFTECount", string.IsNullOrEmpty(oVHDMKModel.WeeklyFTECount) ? string.Empty : oVHDMKModel.WeeklyFTECount);
                            cmd.Parameters.AddWithValue("@CreatedBy", oVHDMKModel.CreatedBy);
                            cmd.Parameters.AddWithValue("@UpdatedBy", oVHDMKModel.CreatedBy);
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
                                result[oVHDMKModel] = "Linking Id Already Exists!";
                                return result;
                            }
                            oVHDMKModel.OVHDMakeReadyID = (long)cmd.ExecuteScalar();
                            result[oVHDMKModel] = "ok";
                            connection.Close();
                            return result;

                        }
                    }
                }
                catch (Exception ex) { return new Dictionary<OVHDMKModel, string>(); }
            });
        }

        public async Task<OVHDMKModel> UpdateOVHD(OVHDMKModel oVHDMKModel)
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
                            cmd.Parameters.AddWithValue("@OVHDMakeReadyID", oVHDMKModel.OVHDMakeReadyID);
                            cmd.Parameters.AddWithValue("@FK_LinkingID", oVHDMKModel.FK_LinkingID);
                            cmd.Parameters.AddWithValue("@FK_stepID", oVHDMKModel.FK_stepID);
                            if (oVHDMKModel.FK_OVHDCOCID == null)
                                cmd.Parameters.AddWithValue("@FK_OVHDCOCID", DBNull.Value);
                            else
                                cmd.Parameters.AddWithValue("@FK_OVHDCOCID", oVHDMKModel.FK_OVHDCOCID);

                            cmd.Parameters.AddWithValue("@IssuesOrComments", string.IsNullOrEmpty(oVHDMKModel.IssuesOrComments) ? string.Empty : oVHDMKModel.IssuesOrComments);

                            if (oVHDMKModel.StartDate == null)
                                cmd.Parameters.AddWithValue("@StartDate", DBNull.Value);
                            else
                                cmd.Parameters.AddWithValue("@StartDate", oVHDMKModel.StartDate);

                            if (oVHDMKModel.EndDate == null)
                                cmd.Parameters.AddWithValue("@EndDate", DBNull.Value);
                            else
                                cmd.Parameters.AddWithValue("@EndDate", oVHDMKModel.EndDate);

                            cmd.Parameters.AddWithValue("@WeeklyFTECount", string.IsNullOrEmpty(oVHDMKModel.WeeklyFTECount) ? string.Empty : oVHDMKModel.WeeklyFTECount);

                            cmd.Parameters.AddWithValue("@CreatedBy", string.Empty);
                            cmd.Parameters.AddWithValue("@UpdatedBy", oVHDMKModel.UpdatedBy);
                            cmd.Connection = connection;
                            connection.Open();


                            var ovhd = new OVHDMKModel();
                            using (SqlDataReader dataReader = cmd.ExecuteReader())
                            {
                                while (dataReader.Read())
                                {

                                    ovhd.OVHDMakeReadyID = (long)dataReader["OVHDMakeReadyID"];
                                    ovhd.FK_LinkingID = (long)dataReader["FK_LinkingID"];
                                    ovhd.FK_stepID = (int)dataReader["FK_stepID"];
                                    if (dataReader["FK_OVHDCOCID"] != DBNull.Value)
                                        ovhd.FK_OVHDCOCID = (int)dataReader["FK_OVHDCOCID"];
                                    ovhd.IssuesOrComments = dataReader["IssuesOrComments"].ToString();
                                    if (dataReader["StartDate"] != DBNull.Value)
                                        ovhd.StartDate = Convert.ToDateTime(dataReader["StartDate"]);
                                    if (dataReader["EndDate"] != DBNull.Value)
                                        ovhd.EndDate = Convert.ToDateTime(dataReader["EndDate"]);
                                    ovhd.WeeklyFTECount = dataReader["WeeklyFTECount"].ToString();

                                }
                            }

                            if (string.IsNullOrEmpty(oVHDMKModel.WeeklyFTECount))
                                cmd.Parameters["@WeeklyFTECount"].Value = ovhd.WeeklyFTECount;

                            if (string.IsNullOrEmpty(oVHDMKModel.IssuesOrComments))
                                cmd.Parameters["@IssuesOrComments"].Value = ovhd.IssuesOrComments;

                            if (oVHDMKModel.FK_OVHDCOCID == null && ovhd.FK_OVHDCOCID == null)
                                cmd.Parameters["@FK_OVHDCOCID"].Value = DBNull.Value;
                            else if (oVHDMKModel.FK_OVHDCOCID == null)
                                cmd.Parameters["@FK_OVHDCOCID"].Value = ovhd.FK_OVHDCOCID;

                            if (oVHDMKModel.StartDate == null && ovhd.StartDate == null)
                                cmd.Parameters["@StartDate"].Value = DBNull.Value;
                            else if (oVHDMKModel.StartDate == null)
                                cmd.Parameters["@StartDate"].Value = ovhd.StartDate;

                            if (oVHDMKModel.EndDate == null && ovhd.EndDate == null)
                                cmd.Parameters["@EndDate"].Value = DBNull.Value;
                            else if (oVHDMKModel.EndDate == null)
                                cmd.Parameters["@EndDate"].Value = ovhd.EndDate;

                            cmd.Parameters["@procId"].Value = 2;
                            cmd.ExecuteNonQuery();
                            connection.Close();
                            return oVHDMKModel;
                        }
                    }
                }
                catch (Exception ex) { return new OVHDMKModel(); }
            });
        }


        public async Task<int> DeleteOVHD(int id)
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
                            cmd.Parameters.AddWithValue("@OVHDMakeReadyID", id);
                            cmd.Parameters.AddWithValue("@FK_LinkingID", 0);
                            cmd.Parameters.AddWithValue("@FK_stepID", 0);
                            cmd.Parameters.AddWithValue("@FK_OVHDCOCID", 0);
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
