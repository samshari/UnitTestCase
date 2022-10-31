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
    public class IfcReadyRepository : IIfcReadyRepository
    {
        private readonly string _connectionString;
        private readonly string _storedProcedure = "dbo.spMIFCREADYActions";

        public IfcReadyRepository(IAppSettings appSettings)
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

        public async Task<List<IfcReadyModel>> GetIFC(int id = 0)
        {
            return await Task.Run(() =>
            {
                var lstMIFC = new List<IfcReadyModel>();
                try
                {
                    using (SqlConnection connection = new SqlConnection(this._connectionString))
                    {
                        connection.Open();
                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.CommandText = _storedProcedure;
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@IFCMakeReadyID", id);
                            cmd.Parameters.AddWithValue("@FK_LinkingID", 1);
                            cmd.Parameters.AddWithValue("@CurrentScheduledDate", DBNull.Value);
                            cmd.Parameters.AddWithValue("@OriginalScheduledDate", DBNull.Value);
                            cmd.Parameters.AddWithValue("@MissedDatesAndReasons", string.Empty);
                            cmd.Parameters.AddWithValue("@InitialIssueDate", DBNull.Value);
                            cmd.Parameters.AddWithValue("@FinalIssueDate", DBNull.Value);
                            cmd.Parameters.AddWithValue("@StepID", 0);
                            cmd.Parameters.AddWithValue("@CreatedBy", string.Empty);
                            cmd.Parameters.AddWithValue("@updatedBy", string.Empty);

                            cmd.Connection = connection;
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
                                    var mifc = new IfcReadyModel();
                                    mifc.IFCMakeReadyID = (long)dataReader["IFCMakeReadyID"];
                                    mifc.FK_LinkingID = (long)dataReader["FK_LinkingID"];
                                    if (dataReader["CurrentScheduledDate"] != DBNull.Value)
                                        mifc.CurrentScheduledDate = Convert.ToDateTime(dataReader["CurrentScheduledDate"]);
                                    if (dataReader["OriginalScheduledDate"] != DBNull.Value)
                                        mifc.OriginalScheduledDate = Convert.ToDateTime(dataReader["OriginalScheduledDate"]);

                                    if (dataReader["CurrentScheduledDate"] != DBNull.Value)
                                        mifc.StrCurrentScheduledDate = Convert.ToDateTime(dataReader["CurrentScheduledDate"]).ToString(onlyDate);
                                    if (dataReader["OriginalScheduledDate"] != DBNull.Value)
                                        mifc.StrOriginalScheduledDate = Convert.ToDateTime(dataReader["OriginalScheduledDate"]).ToString(onlyDate);

                                    mifc.MissedDatesAndReasons = dataReader["MissedDatesAndReasons"].ToString();
                                    if (dataReader["InitialIssueDate"] != DBNull.Value)
                                        mifc.InitialIssueDate = Convert.ToDateTime(dataReader["InitialIssueDate"]);
                                    if (dataReader["FinalIssueDate"] != DBNull.Value)
                                        mifc.FinalIssueDate = Convert.ToDateTime(dataReader["FinalIssueDate"]);

                                    if (dataReader["InitialIssueDate"] != DBNull.Value)
                                        mifc.StrInitialIssueDate = Convert.ToDateTime(dataReader["InitialIssueDate"]).ToString(onlyDate);
                                    if (dataReader["FinalIssueDate"] != DBNull.Value)
                                        mifc.StrFinalIssueDate = Convert.ToDateTime(dataReader["FinalIssueDate"]).ToString(onlyDate);

                                    if (dataReader["StepID"] != DBNull.Value)
                                        mifc.StepID = (int)dataReader["StepID"];
                                    mifc.IsActive = Convert.ToBoolean(dataReader["IsActive"]);
                                    mifc.CreatedBy = dataReader["CreatedBy"].ToString();
                                    mifc.CreatedDate = Convert.ToDateTime(dataReader["CreatedDate"]).ToString(dateWithTime);
                                    mifc.UpdatedBy = dataReader["UpdatedBy"].ToString();
                                    mifc.UpdatedDate = Convert.ToDateTime(dataReader["UpdatedDate"]).ToString(dateWithTime);

                                    lstMIFC.Add(mifc);

                                }
                            }
                            connection.Close();
                        }
                    }
                    return lstMIFC;

                }
                catch (Exception ex) { return new List<IfcReadyModel>(); }
            });
        }

        public async Task<Dictionary<IfcReadyModel, string>> CreateIFC(IfcReadyModel iFCREADYModel)
        {
            return await Task.Run(() =>
                {

                var result = new Dictionary<IfcReadyModel, string>();
                try
                {
                    using (SqlConnection connection = new SqlConnection(this._connectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.CommandText = _storedProcedure;
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            cmd.Connection = connection;
                            cmd.Parameters.AddWithValue("@procId",6);
                            cmd.Parameters.AddWithValue("@IFCMakeReadyID", iFCREADYModel.IFCMakeReadyID);
                            cmd.Parameters.AddWithValue("@FK_LinkingID", iFCREADYModel.FK_LinkingID);
                            cmd.Parameters.AddWithValue("@CurrentScheduledDate",checkNull(iFCREADYModel.CurrentScheduledDate));
                            cmd.Parameters.AddWithValue("@OriginalScheduledDate",checkNull(iFCREADYModel.OriginalScheduledDate));
                            cmd.Parameters.AddWithValue("@MissedDatesAndReasons", string.IsNullOrEmpty(iFCREADYModel.MissedDatesAndReasons) ? string.Empty : iFCREADYModel.MissedDatesAndReasons);
                            cmd.Parameters.AddWithValue("@InitialIssueDate",checkNull(iFCREADYModel.InitialIssueDate));
                            cmd.Parameters.AddWithValue("@FinalIssueDate",checkNull(iFCREADYModel.FinalIssueDate));
                            cmd.Parameters.AddWithValue("@StepID",checkNull(iFCREADYModel.StepID));
                            cmd.Parameters.AddWithValue("@CreatedBy", iFCREADYModel.CreatedBy);
                            cmd.Parameters.AddWithValue("@updatedBy", iFCREADYModel.CreatedBy);

                            connection.Open();
                            int check = (int)cmd.ExecuteScalar();
                            if(check == 1)
                            {
                                cmd.Parameters["@procId"].Value = 1;
                            }
                            else
                            {
                                connection.Close();
                                result[iFCREADYModel] = "Linking Id already Exists!";
                                return result;
                                
                            }
                            iFCREADYModel.IFCMakeReadyID = (long)cmd.ExecuteScalar();
                            result[iFCREADYModel] = "ok";
                            connection.Close();
                            return result;


                        }
                    }


                }
                catch (Exception ex) { throw ex; }
            });
        }

        public async Task<IfcReadyModel> UpdateIFC(IfcReadyModel iFCREADYModel)
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
                            cmd.Parameters.AddWithValue("@IFCMakeReadyID", iFCREADYModel.IFCMakeReadyID);
                            cmd.Parameters.AddWithValue("@FK_LinkingID", iFCREADYModel.FK_LinkingID);
                            cmd.Parameters.AddWithValue("@CurrentScheduledDate", checkNull(iFCREADYModel.CurrentScheduledDate));
                            cmd.Parameters.AddWithValue("@OriginalScheduledDate", checkNull(iFCREADYModel.OriginalScheduledDate));
                            cmd.Parameters.AddWithValue("@MissedDatesAndReasons", string.IsNullOrEmpty(iFCREADYModel.MissedDatesAndReasons) ? string.Empty : iFCREADYModel.MissedDatesAndReasons);
                            cmd.Parameters.AddWithValue("@InitialIssueDate", checkNull(iFCREADYModel.InitialIssueDate));
                            cmd.Parameters.AddWithValue("@FinalIssueDate", checkNull(iFCREADYModel.FinalIssueDate));
                            cmd.Parameters.AddWithValue("@StepID", checkNull(iFCREADYModel.StepID)); 
                            cmd.Parameters.AddWithValue("@CreatedBy", string.Empty);
                            cmd.Parameters.AddWithValue("@updatedBy", iFCREADYModel.UpdatedBy);

                            var mifc = new IfcReadyModel();

                            connection.Open();
                            cmd.ExecuteNonQuery();
                            connection.Close();
                            return iFCREADYModel;


                        }
                    }


                }
                catch (Exception ex) { return new IfcReadyModel(); }
            });
        }

        public async Task<int> DeleteIFC(int id = 0)
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
                            cmd.Parameters.AddWithValue("@IFCMakeReadyID", id);
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
