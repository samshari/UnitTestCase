using Exelon.Domain;
using Exelon.Domain.Abstractions;
using Exelon.Domain.Common;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Exelon.Infrastructure.Repositories
{
    public class MCOCBIDCOMRepository : IMCOCBIDCOMRepository
    {
        private readonly string _connectionString;
        private readonly string _storedProcedure= "dbo.spMCOCBIDCOMActions";

        public MCOCBIDCOMRepository(IAppSettings appSettings)
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
        public async Task<List<MCocBidComModel>> GetMCOCBID(int id = 0)
        {
            return await Task.Run(() =>
            {
                var result = new List<MCocBidComModel>();
                try
                {
                    using (SqlConnection connection = new SqlConnection(this._connectionString))
                    {
                        connection.Open();
                        using(SqlCommand cmd = new SqlCommand())
                        {
                            cmd.CommandText = _storedProcedure;
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@COCBidCompleteID",id);
                            cmd.Parameters.AddWithValue("@FK_LinkingID", 1);
                            cmd.Parameters.AddWithValue("@FK_StepID", 1);
                            cmd.Parameters.AddWithValue("@FK_COCBidCompMkReadyID", 1);
                            cmd.Parameters.AddWithValue("@FK_COCBidCompFiberID", 1);
                            cmd.Parameters.AddWithValue("@UpdatedBy", string.Empty);
                            cmd.Parameters.AddWithValue("@CreatedBy", string.Empty);
                            cmd.Connection = connection;

                            if(id == 0)
                                cmd.Parameters.AddWithValue("@procId", 4);
                            else
                                cmd.Parameters.AddWithValue("@procId", 5);

                            using (SqlDataReader dataReader = cmd.ExecuteReader())
                            {
                                while (dataReader.Read())
                                {
                                    var dateWithTime = "MM'/'dd'/'yyyy h:mm tt";
                                    var mcocbid = new MCocBidComModel();
                                    mcocbid.COCBidCompleteID = (long)dataReader["COCBidCompleteID"];
                                    mcocbid.FK_LinkingID = (long)dataReader["FK_LinkingID"];
                                    mcocbid.FK_StepID = (int)dataReader["FK_StepID"];
                                    if (dataReader["FK_COCBidCompMkReadyID"] != DBNull.Value)
                                        mcocbid.FK_COCBidCompMkReadyID = (int)dataReader["FK_COCBidCompMkReadyID"];
                                    if (dataReader["FK_COCBidCompFiberID"] != DBNull.Value)
                                        mcocbid.FK_COCBidCompFiberID = (int)dataReader["FK_COCBidCompFiberID"];
                                    mcocbid.IsActive = Convert.ToBoolean(dataReader["IsActive"]);
                                    mcocbid.CreatedBy = dataReader["CreatedBy"].ToString();
                                    mcocbid.CreatedDate = Convert.ToDateTime(dataReader["CreatedDate"]).ToString(dateWithTime);
                                    mcocbid.UpdatedBy = dataReader["UpdatedBy"].ToString();
                                    mcocbid.UpdatedDate = Convert.ToDateTime(dataReader["UpdatedDate"]).ToString(dateWithTime);
                                    result.Add(mcocbid);
                                }
                            }
                            
                        }
                        connection.Close();
                    }
                    
                    return result;
                }
                catch(Exception ex) { return new List<MCocBidComModel>(); }
            });
        }



        public async  Task<Dictionary<MCocBidComModel,string>> CreateMCOCBID(MCocBidComModel mCOCBIDCCOMModel)
        {
            return await Task.Run(() =>
            {
                var result = new Dictionary<MCocBidComModel, string>();
                try
                {
                    using (SqlConnection connection = new SqlConnection(this._connectionString))
                    {
                        
                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.CommandText = _storedProcedure;
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@procId", 6);
                            cmd.Parameters.AddWithValue("@COCBidCompleteID", mCOCBIDCCOMModel.COCBidCompleteID);
                            cmd.Parameters.AddWithValue("@FK_LinkingID", mCOCBIDCCOMModel.FK_LinkingID);
                            cmd.Parameters.AddWithValue("@FK_StepID", mCOCBIDCCOMModel.FK_StepID);
                            if (mCOCBIDCCOMModel.FK_COCBidCompMkReadyID == null)
                                cmd.Parameters.AddWithValue("@FK_COCBidCompMkReadyID", DBNull.Value);
                            else
                                cmd.Parameters.AddWithValue("@FK_COCBidCompMkReadyID", mCOCBIDCCOMModel.FK_COCBidCompMkReadyID);
                            if (mCOCBIDCCOMModel.FK_COCBidCompFiberID == null)
                                cmd.Parameters.AddWithValue("@FK_COCBidCompFiberID", DBNull.Value);
                            else
                                cmd.Parameters.AddWithValue("@FK_COCBidCompFiberID", mCOCBIDCCOMModel.FK_COCBidCompFiberID);
                            cmd.Parameters.AddWithValue("@CreatedBy", mCOCBIDCCOMModel.CreatedBy);
                            cmd.Parameters.AddWithValue("@UpdatedBy", mCOCBIDCCOMModel.CreatedBy);
                            cmd.Connection = connection;
                            connection.Open();
                            int check = (int)cmd.ExecuteScalar();
                            if (check == 1)
                            {
                                cmd.Parameters["@procId"].Value = 1;
                                mCOCBIDCCOMModel.COCBidCompleteID = (long)cmd.ExecuteScalar();
                                connection.Close();
                            }
                            else
                            {
                                connection.Close();
                                result[mCOCBIDCCOMModel] = "Linking Id can't be same";
                                return result;
                            }
                            
                            result[mCOCBIDCCOMModel] = "ok";
                            return result;

                        }
                    }
                }
                catch (Exception ex) { return new Dictionary<MCocBidComModel, string>(); }
                
            });
        }

        public async Task<MCocBidComModel> UpdateMCOCBID(MCocBidComModel mCOCBIDCCOMModel)
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
                            cmd.Parameters.AddWithValue("@COCBidCompleteID", mCOCBIDCCOMModel.COCBidCompleteID);
                            cmd.Parameters.AddWithValue("@FK_LinkingID", mCOCBIDCCOMModel.FK_LinkingID);
                            cmd.Parameters.AddWithValue("@FK_StepID", mCOCBIDCCOMModel.FK_StepID);
                            cmd.Parameters.AddWithValue("@FK_COCBidCompMkReadyID",checkNull(mCOCBIDCCOMModel.FK_COCBidCompMkReadyID));
                            cmd.Parameters.AddWithValue("@FK_COCBidCompFiberID",checkNull(mCOCBIDCCOMModel.FK_COCBidCompFiberID));
                            cmd.Parameters.AddWithValue("@CreatedBy", string.Empty);
                            cmd.Parameters.AddWithValue("@UpdatedBy", mCOCBIDCCOMModel.UpdatedBy);
                            cmd.Connection = connection;
                            connection.Open();
                            cmd.ExecuteNonQuery();
                            connection.Close();
                            return mCOCBIDCCOMModel;

                        }
                    }
                }
                catch (Exception ex) { return new MCocBidComModel(); }
            });
        }

        public async Task<int> DeleteMCOCBID(int id)
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
                            cmd.Parameters.AddWithValue("@COCBidCompleteID", id);
                            cmd.Parameters.AddWithValue("@FK_LinkingID", 1);
                            cmd.Parameters.AddWithValue("@FK_StepID", 1);
                            cmd.Parameters.AddWithValue("@FK_COCBidCompMkReadyID", 1);
                            cmd.Parameters.AddWithValue("@FK_COCBidCompFiberID", 1);
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
