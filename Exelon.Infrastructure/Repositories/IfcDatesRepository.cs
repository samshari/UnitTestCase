using Exelon.Domain;
using Exelon.Domain.Abstractions;
using Exelon.Domain.Common;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Exelon.Infrastructure.Repositories
{
    public class IFCDATESRepository : IIFCDATESRepository
    {
        private readonly string _connectionString;
        private readonly string _storedProcedure = "dbo.spIFCDATESActions";

        public IFCDATESRepository(IAppSettings appSettings)
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

        public async Task<List<IFCDATESModel>> GetIFCDATES(int id = 0)
        {
            return await Task.Run(() =>
            {
                var result = new List<IFCDATESModel>();
                try
                {
                    using (SqlConnection connection = new SqlConnection(this._connectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.CommandText = _storedProcedure;
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@IFCDateID", id);
                            cmd.Parameters.AddWithValue("@FK_LinkingID", 0);
                            cmd.Parameters.AddWithValue("@IFCMkReadyScheduledIssueDate", DBNull.Value);
                            cmd.Parameters.AddWithValue("@IFCFiberCurrentScheduledIssueDt", DBNull.Value);
                            cmd.Parameters.AddWithValue("@createdBy", string.Empty);
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
                                    var ifc = new IFCDATESModel();
                                    ifc.IFCDateID = (int)dataReader["IFCDateID"];
                                    ifc.FK_LinkingID = (long)dataReader["ExecutionLinkingID"];
                                    if(dataReader["IFCMkReadyScheduledIssueDate"] != DBNull.Value)
                                        ifc.IFCMkReadyScheduledIssueDate = Convert.ToDateTime(dataReader["IFCMkReadyScheduledIssueDate"]);
                                    if(dataReader["IFCFiberCurrentScheduledIssueDt"] != DBNull.Value)
                                        ifc.IFCFiberCurrentScheduledIssueDt = Convert.ToDateTime(dataReader["IFCFiberCurrentScheduledIssueDt"]);

                                    if (dataReader["IFCMkReadyScheduledIssueDate"] != DBNull.Value)
                                        ifc.StrIFCMkReadyScheduledIssueDate = Convert.ToDateTime(dataReader["IFCMkReadyScheduledIssueDate"]).ToString(onlyDate);
                                    if (dataReader["IFCFiberCurrentScheduledIssueDt"] != DBNull.Value)
                                        ifc.StrIFCFiberCurrentScheduledIssueDt = Convert.ToDateTime(dataReader["IFCFiberCurrentScheduledIssueDt"]).ToString(onlyDate);

                                    ifc.IsActive = Convert.ToBoolean(dataReader["IsActive"]);
                                    ifc.CreatedBy = dataReader["CreatedBy"].ToString();
                                    ifc.CreatedDate = Convert.ToDateTime(dataReader["CreatedDate"]).ToString(dateWithTime);
                                    ifc.UpdatedBy = dataReader["UpdatedBy"].ToString();
                                    ifc.UpdatedDate = Convert.ToDateTime(dataReader["UpdatedDate"]).ToString(dateWithTime);
                                    result.Add(ifc);
                                }
                            }
                            connection.Close();
                            return result;
                        }
                    }
                }
                catch (Exception ex) { return new  List<IFCDATESModel>(); }
            });
        }

        public async Task<Dictionary<IFCDATESModel, string>> CreateIFCDATES(IFCDATESModel iFCDATESModel)
        {
            return await Task.Run(() =>
            {
                var result = new Dictionary<IFCDATESModel, string>();
                try
                {
                    using (SqlConnection connection = new SqlConnection(this._connectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.CommandText = _storedProcedure;
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@procId", 6);
                            cmd.Parameters.AddWithValue("@IFCDateID", iFCDATESModel.IFCDateID);
                            cmd.Parameters.AddWithValue("@FK_LinkingID", iFCDATESModel.FK_LinkingID);
                            cmd.Parameters.AddWithValue("@IFCMkReadyScheduledIssueDate",checkNull(iFCDATESModel.IFCMkReadyScheduledIssueDate));
                            cmd.Parameters.AddWithValue("@IFCFiberCurrentScheduledIssueDt",checkNull(iFCDATESModel.IFCFiberCurrentScheduledIssueDt));
                            cmd.Parameters.AddWithValue("@createdBy", iFCDATESModel.CreatedBy);
                            cmd.Parameters.AddWithValue("@updatedBy", iFCDATESModel.CreatedBy);
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
                                result[iFCDATESModel] = "Linking Id Already Exists";
                                return result;
                            }
                            iFCDATESModel.IFCDateID = (int)cmd.ExecuteScalar();
                            result[iFCDATESModel] = "ok";
                            connection.Close();
                            return result;

                        }
                    }
                }
                catch (Exception ex) { return new Dictionary<IFCDATESModel, string>(); }
            });
        }

        public async Task<IFCDATESModel> UpdateIFCDATES(IFCDATESModel iFCDATESModel)
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
                            cmd.Parameters.AddWithValue("@IFCDateID", iFCDATESModel.IFCDateID);
                            cmd.Parameters.AddWithValue("@FK_LinkingID", iFCDATESModel.FK_LinkingID);
                            cmd.Parameters.AddWithValue("@IFCMkReadyScheduledIssueDate", checkNull(iFCDATESModel.IFCMkReadyScheduledIssueDate));
                            cmd.Parameters.AddWithValue("@IFCFiberCurrentScheduledIssueDt", checkNull(iFCDATESModel.IFCFiberCurrentScheduledIssueDt));
                            cmd.Parameters.AddWithValue("@createdBy", string.Empty);
                            cmd.Parameters.AddWithValue("@updatedBy", iFCDATESModel.UpdatedBy);
                            cmd.Connection = connection;
                            connection.Open();
                            cmd.ExecuteNonQuery();
                            connection.Close();
                            return iFCDATESModel;
                        }
                    }
                }
                catch (Exception ex) { return new IFCDATESModel(); }
            });
        }

        public async Task<int> DeleteIFCDATES(int id)
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
                            cmd.Parameters.AddWithValue("@IFCDateID", id);
                            cmd.Parameters.AddWithValue("@FK_LinkingID", 0);
                            cmd.Parameters.AddWithValue("@IFCMkReadyScheduledIssueDate", DBNull.Value);
                            cmd.Parameters.AddWithValue("@IFCFiberCurrentScheduledIssueDt", DBNull.Value);
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
