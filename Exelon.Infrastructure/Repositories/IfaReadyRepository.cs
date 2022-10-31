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
    public class IfaReadyRepository : IIfaReadyRepository
    {
        private readonly string _connectionString;
        private readonly string _storedProcedure = "dbo.spMIFAREADYActions";

        public IfaReadyRepository(IAppSettings appSettings)
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

        public async  Task<List<IfaReadyModel>> GetIFA(int id = 0)
        {
            return await Task.Run(() =>
            {
                var lstMIFA = new List<IfaReadyModel>();
                try
                {
                    using(SqlConnection connection = new SqlConnection(this._connectionString))
                    {
                        connection.Open();
                        using(SqlCommand cmd = new SqlCommand())
                        {
                            cmd.CommandText = _storedProcedure;
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@IFAMakeReadyID", id);
                            cmd.Parameters.AddWithValue("@FK_LinkingID", 1);
                            cmd.Parameters.AddWithValue("@CurrentScheduledDate", DBNull.Value);
                            cmd.Parameters.AddWithValue("@OriginalScheduledDate", DBNull.Value);
                            cmd.Parameters.AddWithValue("@MissedDatesAndReasons", string.Empty);
                            cmd.Parameters.AddWithValue("@InitialIssueDate", DBNull.Value);
                            cmd.Parameters.AddWithValue("@FinalIssueDate", DBNull.Value);
                            cmd.Parameters.AddWithValue("@StepID", 1);
                            cmd.Parameters.AddWithValue("@CreatedBy", string.Empty);
                            cmd.Parameters.AddWithValue("@updatedBy", string.Empty);
                            cmd.Connection = connection;
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
                                    var mifa = new IfaReadyModel();
                                    mifa.IFAMakeReadyID = (long)dataReader["IFAMakeReadyID"];
                                    mifa.FK_LinkingID = (long)dataReader["FK_LinkingID"];
                                    if(dataReader["CurrentScheduledDate"] != DBNull.Value)
                                        mifa.CurrentScheduledDate = Convert.ToDateTime(dataReader["CurrentScheduledDate"]);
                                    if(dataReader["OriginalScheduledDate"] != DBNull.Value)
                                        mifa.OriginalScheduledDate = Convert.ToDateTime(dataReader["OriginalScheduledDate"]);
                                     mifa.MissedDatesAndReasons = dataReader["MissedDatesAndReasons"].ToString();
                                    if (dataReader["InitialIssueDate"] != DBNull.Value)
                                        mifa.InitialIssueDate = Convert.ToDateTime(dataReader["InitialIssueDate"]);
                                    if (dataReader["FinalIssueDate"] != DBNull.Value)
                                        mifa.FinalIssueDate = Convert.ToDateTime(dataReader["FinalIssueDate"]);

                                    if (dataReader["CurrentScheduledDate"] != DBNull.Value)
                                        mifa.StrCurrentScheduledDate = Convert.ToDateTime(dataReader["CurrentScheduledDate"]).ToString(onlyDate);
                                    if (dataReader["OriginalScheduledDate"] != DBNull.Value)
                                        mifa.StrOriginalScheduledDate = Convert.ToDateTime(dataReader["OriginalScheduledDate"]).ToString(onlyDate);
                                    if (dataReader["InitialIssueDate"] != DBNull.Value)
                                        mifa.StrInitialIssueDate = Convert.ToDateTime(dataReader["InitialIssueDate"]).ToString(onlyDate);
                                    if (dataReader["FinalIssueDate"] != DBNull.Value)
                                        mifa.StrFinalIssueDate = Convert.ToDateTime(dataReader["FinalIssueDate"]).ToString(onlyDate);

                                    if (dataReader["StepID"] != DBNull.Value)
                                        mifa.StepID = (int)dataReader["StepID"];
                                    mifa.IsActive = Convert.ToBoolean(dataReader["IsActive"]);
                                    mifa.CreatedBy = dataReader["CreatedBy"].ToString();
                                    mifa.CreatedDate = Convert.ToDateTime(dataReader["CreatedDate"]).ToString(dateWithTime);
                                    mifa.UpdatedBy = dataReader["UpdatedBy"].ToString();
                                    mifa.UpdatedDate = Convert.ToDateTime(dataReader["UpdatedDate"]).ToString(dateWithTime);

                                    lstMIFA.Add(mifa);

                                }
                            }
                            connection.Close();
                        }
                    }
                    return lstMIFA;

                }
                catch(Exception ex) { return new List<IfaReadyModel>(); }
            });
        }

        public async Task<Dictionary<IfaReadyModel,string>> CreateIFA(IfaReadyModel iFAREADYModel)
        {
            return await Task.Run(() =>
            {
                var result = new Dictionary<IfaReadyModel, string>();
                try
                {
                    using (SqlConnection connection = new SqlConnection(this._connectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.CommandText = _storedProcedure;
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            cmd.Connection = connection;
                            cmd.Parameters.AddWithValue("@procId", 6);
                            cmd.Parameters.AddWithValue("@IFAMakeReadyID", 1);
                            cmd.Parameters.AddWithValue("@FK_LinkingID", iFAREADYModel.FK_LinkingID);
                            cmd.Parameters.AddWithValue("@CurrentScheduledDate",checkNull(iFAREADYModel.CurrentScheduledDate));
                            cmd.Parameters.AddWithValue("@OriginalScheduledDate",checkNull(iFAREADYModel.OriginalScheduledDate));
                            cmd.Parameters.AddWithValue("@MissedDatesAndReasons", string.IsNullOrEmpty(iFAREADYModel.MissedDatesAndReasons)?string.Empty: iFAREADYModel.MissedDatesAndReasons);
                            cmd.Parameters.AddWithValue("@InitialIssueDate",checkNull(iFAREADYModel.InitialIssueDate));
                            cmd.Parameters.AddWithValue("@FinalIssueDate",checkNull(iFAREADYModel.FinalIssueDate));
                            cmd.Parameters.AddWithValue("@StepID",checkNull(iFAREADYModel.StepID));
                            cmd.Parameters.AddWithValue("@CreatedBy", iFAREADYModel.CreatedBy);
                            cmd.Parameters.AddWithValue("@updatedBy", iFAREADYModel.CreatedBy);

                            connection.Open();
                            int check = (int)cmd.ExecuteScalar();
                            if (check == 1){
                                cmd.Parameters["@procId"].Value = 1;
                            }
                            else
                            {
                                connection.Close();
                                result[iFAREADYModel] = "Linking Id already Exists!";
                                return result;
                            }
                            iFAREADYModel.IFAMakeReadyID = (long)cmd.ExecuteScalar();
                            result[iFAREADYModel] = "ok";
                            connection.Close();
                            return result;

                            
                        }
                    }
                    

                }
                catch (Exception ex) { return new Dictionary<IfaReadyModel, string>(); }
            });
        }

        public async Task<IfaReadyModel> UpdateIFA(IfaReadyModel iFAREADYModel)
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
                            cmd.Connection = connection;
                            cmd.Parameters.AddWithValue("@procId", 2);
                            cmd.Parameters.AddWithValue("@IFAMakeReadyID", iFAREADYModel.IFAMakeReadyID);
                            cmd.Parameters.AddWithValue("@FK_LinkingID", iFAREADYModel.FK_LinkingID);
                            cmd.Parameters.AddWithValue("@CurrentScheduledDate", checkNull(iFAREADYModel.CurrentScheduledDate));
                            cmd.Parameters.AddWithValue("@OriginalScheduledDate", checkNull(iFAREADYModel.OriginalScheduledDate));
                            cmd.Parameters.AddWithValue("@MissedDatesAndReasons", string.IsNullOrEmpty(iFAREADYModel.MissedDatesAndReasons) ? string.Empty : iFAREADYModel.MissedDatesAndReasons);
                            cmd.Parameters.AddWithValue("@InitialIssueDate", checkNull(iFAREADYModel.InitialIssueDate));
                            cmd.Parameters.AddWithValue("@FinalIssueDate", checkNull(iFAREADYModel.FinalIssueDate));
                            cmd.Parameters.AddWithValue("@StepID", checkNull(iFAREADYModel.StepID));
                            cmd.Parameters.AddWithValue("@CreatedBy", string.Empty);
                            cmd.Parameters.AddWithValue("@updatedBy", iFAREADYModel.UpdatedBy);

                            var mifa = new IfaReadyModel();

                            connection.Open();
                            cmd.ExecuteNonQuery();
                            connection.Close();
                            return iFAREADYModel;


                        }
                    }


                }
                catch (Exception ex) { return new IfaReadyModel(); }
            });
        }

        public async Task<int> DeleteIFA(int id = 0)
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
                            cmd.Connection = connection;
                            cmd.Parameters.AddWithValue("@procId", 3);
                            cmd.Parameters.AddWithValue("@IFAMakeReadyID", id);
                            cmd.Parameters.AddWithValue("@FK_LinkingID", 1);
                            cmd.Parameters.AddWithValue("@CurrentScheduledDate", DBNull.Value);
                            cmd.Parameters.AddWithValue("@OriginalScheduledDate", DBNull.Value);
                            cmd.Parameters.AddWithValue("@MissedDatesAndReasons", string.Empty);
                            cmd.Parameters.AddWithValue("@InitialIssueDate", DBNull.Value);
                            cmd.Parameters.AddWithValue("@FinalIssueDate", DBNull.Value);
                            cmd.Parameters.AddWithValue("@StepID", 1);
                            cmd.Parameters.AddWithValue("@CreatedBy", string.Empty);
                            cmd.Parameters.AddWithValue("@updatedBy", string.Empty);
                            cmd.Connection = connection;
                            connection.Open();
                            cmd.ExecuteNonQuery();
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
