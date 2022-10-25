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
    public class IfaFiberRepository : IIfaFiberRepository
    {
        private readonly string _connectionString;
        private readonly string _storedProcedure = "dbo.spMIFAFIBERActions";

        public IfaFiberRepository(IAppSettings appSettings)
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


        public async Task<List<IfaFiberModel>> GetIFAFIBER(int id = 0)
        {
            return await Task.Run(() =>
            {
                var lstMIFAFIBER = new List<IfaFiberModel>();
                ; try
                {
                    using (SqlConnection connection = new SqlConnection(this._connectionString))
                    {
                        
                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.CommandText = _storedProcedure;
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@IFAFiberID", id);
                            cmd.Parameters.AddWithValue("@FK_LinkingID", 1);
                            cmd.Parameters.AddWithValue("@CurrentScheduledDate", DBNull.Value);
                            cmd.Parameters.AddWithValue("@OriginalScheduledDate", DBNull.Value);
                            cmd.Parameters.AddWithValue("@MissedDatesAndReasons", string.Empty);
                            cmd.Parameters.AddWithValue("@InitialIssueDate", DBNull.Value);
                            cmd.Parameters.AddWithValue("@FinalIssueDate", DBNull.Value);
                            cmd.Parameters.AddWithValue("@StepID", 1);
                            cmd.Parameters.AddWithValue("@CreatedBy", string.Empty);
                            cmd.Parameters.AddWithValue("@UpdatedBy", string.Empty);
                            cmd.Connection = connection;
                            connection.Open();

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
                                    var onlyDate = "MM'/'dd'/'yyyy";
                                    var dateWithTime = "MM'/'dd'/'yyyy h:mm tt";
                                    var mfiber = new IfaFiberModel();
                                    mfiber.IFAFiberID = (long)dataReader["IFAFiberID"];
                                    mfiber.FK_LinkingID = (long)dataReader["FK_LinkingID"];
                                    if(dataReader["CurrentScheduledDate"] != DBNull.Value)
                                        mfiber.CurrentScheduledDate = Convert.ToDateTime(dataReader["CurrentScheduledDate"]);
                                    mfiber.MissedDatesAndReasons = dataReader["MissedDatesAndReasons"].ToString();
                                    if (dataReader["InitialIssueDate"] != DBNull.Value)
                                        mfiber.InitialIssueDate = Convert.ToDateTime(dataReader["InitialIssueDate"]);
                                    if (dataReader["FinalIssueDate"] != DBNull.Value)
                                        mfiber.FinalIssueDate = Convert.ToDateTime(dataReader["FinalIssueDate"]);
                                    if (dataReader["OriginalScheduledDate"] != DBNull.Value)
                                        mfiber.OriginalScheduledDate = Convert.ToDateTime(dataReader["OriginalScheduledDate"]);

                                    if (dataReader["CurrentScheduledDate"] != DBNull.Value)
                                        mfiber.StrCurrentScheduledDate = Convert.ToDateTime(dataReader["CurrentScheduledDate"]).ToString(onlyDate);
                                    if (dataReader["InitialIssueDate"] != DBNull.Value)
                                        mfiber.StrInitialIssueDate = Convert.ToDateTime(dataReader["InitialIssueDate"]).ToString(onlyDate);
                                    if (dataReader["FinalIssueDate"] != DBNull.Value)
                                        mfiber.StrFinalIssueDate = Convert.ToDateTime(dataReader["FinalIssueDate"]).ToString(onlyDate);
                                    if (dataReader["OriginalScheduledDate"] != DBNull.Value)
                                        mfiber.StrOriginalScheduledDate = Convert.ToDateTime(dataReader["OriginalScheduledDate"]).ToString(onlyDate);

                                    mfiber.StepID = (int)dataReader["StepID"];
                                    mfiber.IsActive = Convert.ToBoolean(dataReader["IsActive"]);
                                    mfiber.CreatedBy = dataReader["CreatedBy"].ToString();
                                    mfiber.CreatedDate = Convert.ToDateTime(dataReader["CreatedDate"]).ToString(dateWithTime);
                                    mfiber.UpdatedBy = dataReader["UpdatedBy"].ToString();
                                    mfiber.UpdatedDate = Convert.ToDateTime(dataReader["UpdatedDate"]).ToString(dateWithTime);
                                    lstMIFAFIBER.Add(mfiber);
                                }
                            }
                        }
                    }
                    return lstMIFAFIBER;
                }
                catch (Exception ex) { return new List<IfaFiberModel>(); }
            });
        }

        public async Task<Dictionary<IfaFiberModel,string>> CreateIFAFIBER(IfaFiberModel ifaFiberModel)
        {
            return await Task.Run(() =>
            {
                var result = new Dictionary<IfaFiberModel, string>();

                try
                {
                    using (SqlConnection connection = new SqlConnection(this._connectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.CommandText = _storedProcedure;
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@procId", 6);
                            cmd.Parameters.AddWithValue("@IFAFiberID", ifaFiberModel.IFAFiberID);
                            cmd.Parameters.AddWithValue("@FK_LinkingID", ifaFiberModel.FK_LinkingID);
                            cmd.Parameters.AddWithValue("@CurrentScheduledDate",checkNull(ifaFiberModel.CurrentScheduledDate));
                            cmd.Parameters.AddWithValue("@OriginalScheduledDate", checkNull(ifaFiberModel.OriginalScheduledDate));
                            cmd.Parameters.AddWithValue("@MissedDatesAndReasons", string.IsNullOrEmpty(ifaFiberModel.MissedDatesAndReasons) ? string.Empty : ifaFiberModel.MissedDatesAndReasons);
                            cmd.Parameters.AddWithValue("@InitialIssueDate",checkNull(ifaFiberModel.InitialIssueDate));
                            cmd.Parameters.AddWithValue("@FinalIssueDate",checkNull(ifaFiberModel.FinalIssueDate));
                            cmd.Parameters.AddWithValue("@StepID", ifaFiberModel.StepID);
                            cmd.Parameters.AddWithValue("@CreatedBy", ifaFiberModel.CreatedBy);
                            cmd.Parameters.AddWithValue("@UpdatedBy", ifaFiberModel.CreatedBy);
                            cmd.Connection = connection;
                            connection.Open();
                            int check = (int)cmd.ExecuteScalar();
                            if(check == 1){
                                cmd.Parameters["@procId"].Value = 1;
                            }
                            else
                            {
                                connection.Close();
                                result[ifaFiberModel] = "LinkingId Already Exists!";
                                return result;
                            }

                            ifaFiberModel.IFAFiberID = (long)cmd.ExecuteScalar();
                            connection.Close();
                            result[ifaFiberModel] = "ok";
                            return result;
                        }
                    }

                }
                catch (Exception ex) { return new Dictionary<IfaFiberModel, string>(); }
            });
        }

        public async Task<IfaFiberModel> UpdateIFAFIBER(IfaFiberModel ifaFiberModel)
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
                            cmd.Parameters.AddWithValue("@IFAFiberID", ifaFiberModel.IFAFiberID);
                            cmd.Parameters.AddWithValue("@FK_LinkingID", ifaFiberModel.FK_LinkingID);
                            cmd.Parameters.AddWithValue("@CurrentScheduledDate", checkNull(ifaFiberModel.CurrentScheduledDate));
                            cmd.Parameters.AddWithValue("@OriginalScheduledDate", checkNull(ifaFiberModel.OriginalScheduledDate));
                            cmd.Parameters.AddWithValue("@MissedDatesAndReasons", string.IsNullOrEmpty(ifaFiberModel.MissedDatesAndReasons) ? string.Empty : ifaFiberModel.MissedDatesAndReasons);
                            cmd.Parameters.AddWithValue("@InitialIssueDate", checkNull(ifaFiberModel.InitialIssueDate));
                            cmd.Parameters.AddWithValue("@FinalIssueDate", checkNull(ifaFiberModel.FinalIssueDate)); cmd.Parameters.AddWithValue("@StepID", ifaFiberModel.StepID);
                            cmd.Parameters.AddWithValue("@CreatedBy", string.Empty);
                            cmd.Parameters.AddWithValue("@UpdatedBy", ifaFiberModel.UpdatedBy);

                            cmd.Connection = connection;
                            connection.Open();

                            var mfiber = new IfaFiberModel();

                            using (SqlDataReader dataReader = cmd.ExecuteReader())
                            {
                                while (dataReader.Read())
                                {
                                    mfiber.IFAFiberID = (long)dataReader["IFAFiberID"];
                                    mfiber.FK_LinkingID = (long)dataReader["FK_LinkingID"];
                                    if (dataReader["CurrentScheduledDate"] != DBNull.Value)
                                        mfiber.CurrentScheduledDate = Convert.ToDateTime(dataReader["CurrentScheduledDate"]);
                                    mfiber.MissedDatesAndReasons = dataReader["MissedDatesAndReasons"].ToString();
                                    if (dataReader["InitialIssueDate"] != DBNull.Value)
                                        mfiber.InitialIssueDate = Convert.ToDateTime(dataReader["InitialIssueDate"]);
                                    if (dataReader["FinalIssueDate"] != DBNull.Value)
                                        mfiber.FinalIssueDate = Convert.ToDateTime(dataReader["FinalIssueDate"]);
                                    if (dataReader["OriginalScheduledDate"] != DBNull.Value)
                                        mfiber.OriginalScheduledDate = Convert.ToDateTime(dataReader["OriginalScheduledDate"]);
                                    mfiber.StepID = (int)dataReader["StepID"];

                                }
                            }
                            cmd.Parameters["@CurrentScheduledDate"].Value = checkNullWithValue(ifaFiberModel.CurrentScheduledDate,mfiber.CurrentScheduledDate);
                            cmd.Parameters["@InitialIssueDate"].Value =checkNullWithValue(ifaFiberModel.InitialIssueDate,mfiber.InitialIssueDate);
                            cmd.Parameters["@FinalIssueDate"].Value =checkNullWithValue(ifaFiberModel.FinalIssueDate,mfiber.FinalIssueDate);
                            cmd.Parameters["@OriginalScheduledDate"].Value =checkNullWithValue(ifaFiberModel.OriginalScheduledDate, mfiber.OriginalScheduledDate);
                            if (string.IsNullOrEmpty(ifaFiberModel.MissedDatesAndReasons))
                                cmd.Parameters["@MissedDatesAndReasons"].Value = mfiber.MissedDatesAndReasons;
                            cmd.Parameters["@procId"].Value = 2;
                            cmd.ExecuteNonQuery();
                            connection.Close();
                            return ifaFiberModel;
                        }
                    }

                }
                catch (Exception ex) { return new IfaFiberModel(); }
            });
        }

        public async Task<int> DeleteIFAFIBER(int id)
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
                            cmd.Parameters.AddWithValue("@IFAFiberID", id);
                            cmd.Parameters.AddWithValue("@FK_LinkingID", 1);
                            cmd.Parameters.AddWithValue("@CurrentScheduledDate", DBNull.Value);
                            cmd.Parameters.AddWithValue("@OriginalScheduledDate", DBNull.Value);
                            cmd.Parameters.AddWithValue("@MissedDatesAndReasons", string.Empty);
                            cmd.Parameters.AddWithValue("@InitialIssueDate", DBNull.Value);
                            cmd.Parameters.AddWithValue("@FinalIssueDate", DBNull.Value);
                            cmd.Parameters.AddWithValue("@StepID", 1);
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
