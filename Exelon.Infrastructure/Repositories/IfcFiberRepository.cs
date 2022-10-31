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
    public class IfcFiberRepository : IIFCFIBERRepository
    {
        private readonly string _connectionString;
        private readonly string _storedProcedure = "dbo.spMIFCFIBERActions";

        public IfcFiberRepository(IAppSettings appSettings)
        {
            _connectionString = appSettings.GetConnectionString();
        }


        public async Task<List<IfcFiberModel>> GetIFCFIBER(int id = 0)
        {
            return await Task.Run(() =>
            {
                var lstIFC = new List<IfcFiberModel>();
                try
                {
                    using (SqlConnection connection = new SqlConnection(this._connectionString))
                    {
                        connection.Open();
                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.CommandText = _storedProcedure;
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@FK_LinkingID", 1);
                            cmd.Parameters.AddWithValue("@IFCFiberID", id);
                            cmd.Parameters.AddWithValue("@CurrentScheduledDate", DBNull.Value);
                            cmd.Parameters.AddWithValue("OriginalScheduledDate", DBNull.Value);
                            cmd.Parameters.AddWithValue("@MissedDates", DBNull.Value);
                            cmd.Parameters.AddWithValue("@MissedReason", string.Empty);
                            cmd.Parameters.AddWithValue("@InitialIssueDate", DBNull.Value);
                            cmd.Parameters.AddWithValue("@FinalIssueDate", DBNull.Value);
                            cmd.Parameters.AddWithValue("@StepID", 1);
                            cmd.Parameters.AddWithValue("@CreatedBy", string.Empty);
                            cmd.Parameters.AddWithValue("@UpdatedBy", string.Empty);
                            cmd.Connection = connection;
                            if(id == 0)
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
                                    var ifc = new IfcFiberModel();
                                    ifc.IFCFiberID = (long)dataReader["IFCFiberID"];
                                    ifc.FK_LinkingID = (long)dataReader["FK_LinkingID"];

                                    if(dataReader["CurrentScheduledDate"]!=DBNull.Value)
                                        ifc.CurrentScheduledDate = Convert.ToDateTime(dataReader["CurrentScheduledDate"]);

                                    if (dataReader["OriginalScheduledDate"]!=DBNull.Value)
                                        ifc.OriginalScheduledDate = Convert.ToDateTime(dataReader["OriginalScheduledDate"]);

                                    if(dataReader["MissedDates"]!=DBNull.Value)
                                        ifc.MissedDates = Convert.ToDateTime(dataReader["MissedDates"]);

                                    if (dataReader["CurrentScheduledDate"] != DBNull.Value)
                                        ifc.StrCurrentScheduledDate = Convert.ToDateTime(dataReader["CurrentScheduledDate"]).ToString(onlyDate);

                                    if (dataReader["OriginalScheduledDate"] != DBNull.Value)
                                        ifc.StrOriginalScheduledDate = Convert.ToDateTime(dataReader["OriginalScheduledDate"]).ToString(onlyDate);

                                    if (dataReader["MissedDates"] != DBNull.Value)
                                        ifc.StrMissedDates = Convert.ToDateTime(dataReader["MissedDates"]).ToString(onlyDate);

                                    ifc.MissedReason = dataReader["MissedReason"].ToString();

                                    if(dataReader["InitialIssueDate"]!=DBNull.Value)
                                        ifc.InitialIssueDate = Convert.ToDateTime(dataReader["InitialIssueDate"]);

                                    if(dataReader["FinalIssueDate"]!=DBNull.Value)
                                        ifc.FinalIssueDate = Convert.ToDateTime(dataReader["FinalIssueDate"]);

                                    if (dataReader["InitialIssueDate"] != DBNull.Value)
                                        ifc.StrInitialIssueDate = Convert.ToDateTime(dataReader["InitialIssueDate"]).ToString(onlyDate);

                                    if (dataReader["FinalIssueDate"] != DBNull.Value)
                                        ifc.StrFinalIssueDate = Convert.ToDateTime(dataReader["FinalIssueDate"]).ToString(dateWithTime);

                                    ifc.StepID = (int)dataReader["StepID"];
                                    ifc.IsActive = Convert.ToBoolean(dataReader["IsActive"]);
                                    ifc.CreatedBy = dataReader["CreatedBy"].ToString();
                                    ifc.CreatedDate = Convert.ToDateTime(dataReader["CreatedDate"]).ToString(dateWithTime);
                                    ifc.UpdatedBy = dataReader["UpdatedBy"].ToString();
                                    ifc.UpdatedDate = Convert.ToDateTime(dataReader["UpdatedDate"]).ToString(dateWithTime);
                                    lstIFC.Add(ifc);
                                }
                            }


                        }
                    }
                    return lstIFC;
                }
                catch (Exception ex) { return new List<IfcFiberModel>(); }
            });
        }

        public async Task<Dictionary<IfcFiberModel,string>> CreateIFCFIBER(IfcFiberModel ifcFiberModel)
        {
            return await Task.Run(() =>
            {
                var result = new Dictionary<IfcFiberModel, string>();
                try
                {
                    using (SqlConnection connection = new SqlConnection(this._connectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.CommandText = _storedProcedure;
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@procId", 6);
                            cmd.Parameters.AddWithValue("@IFCFiberID", ifcFiberModel.IFCFiberID);
                            cmd.Parameters.AddWithValue("@FK_LinkingID", ifcFiberModel.FK_LinkingID);
                            

                            if(ifcFiberModel.CurrentScheduledDate == null)
                                cmd.Parameters.AddWithValue("@CurrentScheduledDate", DBNull.Value);
                            else
                                cmd.Parameters.AddWithValue("@CurrentScheduledDate", ifcFiberModel.CurrentScheduledDate);

                            if(ifcFiberModel.OriginalScheduledDate == null)
                                cmd.Parameters.AddWithValue("OriginalScheduledDate", DBNull.Value);
                            else
                                cmd.Parameters.AddWithValue("OriginalScheduledDate", ifcFiberModel.OriginalScheduledDate);

                            if(ifcFiberModel.MissedDates == null)
                                cmd.Parameters.AddWithValue("@MissedDates", DBNull.Value);
                            else
                                cmd.Parameters.AddWithValue("@MissedDates", ifcFiberModel.MissedDates);

                            cmd.Parameters.AddWithValue("@MissedReason", string.IsNullOrEmpty(ifcFiberModel.MissedReason)?string.Empty: ifcFiberModel.MissedReason);

                            if(ifcFiberModel.InitialIssueDate == null)
                                cmd.Parameters.AddWithValue("@InitialIssueDate", DBNull.Value);
                            else
                                cmd.Parameters.AddWithValue("@InitialIssueDate", ifcFiberModel.InitialIssueDate);

                            if(ifcFiberModel.FinalIssueDate == null)
                                cmd.Parameters.AddWithValue("@FinalIssueDate", DBNull.Value);
                            else
                                cmd.Parameters.AddWithValue("@FinalIssueDate", ifcFiberModel.FinalIssueDate);

                            cmd.Parameters.AddWithValue("@StepID", ifcFiberModel.StepID);
                            cmd.Parameters.AddWithValue("@CreatedBy", ifcFiberModel.CreatedBy);
                            cmd.Parameters.AddWithValue("@UpdatedBy", ifcFiberModel.CreatedBy);
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
                                result[ifcFiberModel] = "Linking Id Already Exists";
                                return result;
                            }

                            ifcFiberModel.IFCFiberID = (long)cmd.ExecuteScalar();
                            connection.Close();
                            result[ifcFiberModel] = "ok";
                            return result;

                        }
                    }

                }
                catch (Exception ex) { return new Dictionary<IfcFiberModel, string>(); }
            });
        }

        public async Task<IfcFiberModel> UpdateIFCFIBER(IfcFiberModel ifcFiberModel)
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
                            cmd.Parameters.AddWithValue("@FK_LinkingID", ifcFiberModel.FK_LinkingID);
                            cmd.Parameters.AddWithValue("@IFCFiberID", ifcFiberModel.IFCFiberID);

                            if (ifcFiberModel.CurrentScheduledDate == null)
                                cmd.Parameters.AddWithValue("@CurrentScheduledDate", DBNull.Value);
                            else
                                cmd.Parameters.AddWithValue("@CurrentScheduledDate", ifcFiberModel.CurrentScheduledDate);

                            if (ifcFiberModel.OriginalScheduledDate == null)
                                cmd.Parameters.AddWithValue("OriginalScheduledDate", DBNull.Value);
                            else
                                cmd.Parameters.AddWithValue("OriginalScheduledDate", ifcFiberModel.OriginalScheduledDate);

                            if (ifcFiberModel.MissedDates == null)
                                cmd.Parameters.AddWithValue("@MissedDates", DBNull.Value);
                            else
                                cmd.Parameters.AddWithValue("@MissedDates", ifcFiberModel.MissedDates);

                            cmd.Parameters.AddWithValue("@MissedReason", string.IsNullOrEmpty(ifcFiberModel.MissedReason) ? string.Empty : ifcFiberModel.MissedReason);

                            if (ifcFiberModel.InitialIssueDate == null)
                                cmd.Parameters.AddWithValue("@InitialIssueDate", DBNull.Value);
                            else
                                cmd.Parameters.AddWithValue("@InitialIssueDate", ifcFiberModel.InitialIssueDate);

                            if (ifcFiberModel.FinalIssueDate == null)
                                cmd.Parameters.AddWithValue("@FinalIssueDate", DBNull.Value);
                            else
                                cmd.Parameters.AddWithValue("@FinalIssueDate", ifcFiberModel.FinalIssueDate);

                            cmd.Parameters.AddWithValue("@StepID", ifcFiberModel.StepID);
                            cmd.Parameters.AddWithValue("@CreatedBy", string.Empty);
                            cmd.Parameters.AddWithValue("@UpdatedBy", ifcFiberModel.UpdatedBy);
                            cmd.Connection = connection;
                            connection.Open();
                            cmd.ExecuteNonQuery();
                            connection.Close();
                            return ifcFiberModel;

                        }
                    }

                }
                catch (Exception ex) { return new IfcFiberModel(); }
            });
        }

        public async Task<int> DeleteIFCFIBER(int id)
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
                            cmd.Parameters.AddWithValue("@FK_LinkingID", 1);
                            cmd.Parameters.AddWithValue("@IFCFiberID", id);
                            cmd.Parameters.AddWithValue("@CurrentScheduledDate", DBNull.Value);
                            cmd.Parameters.AddWithValue("OriginalScheduledDate", DBNull.Value);
                            cmd.Parameters.AddWithValue("@MissedDates", DBNull.Value);
                            cmd.Parameters.AddWithValue("@MissedReason", string.Empty);
                            cmd.Parameters.AddWithValue("@InitialIssueDate", DBNull.Value);
                            cmd.Parameters.AddWithValue("@FinalIssueDate", DBNull.Value);
                            cmd.Parameters.AddWithValue("@StepID", 0);
                            cmd.Parameters.AddWithValue("@CreatedBy",string.Empty);
                            cmd.Parameters.AddWithValue("@UpdatedBy",string.Empty);
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
