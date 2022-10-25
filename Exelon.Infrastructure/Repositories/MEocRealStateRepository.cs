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
    public class MEOCREALSTATERepository: IMEOCREALSTATERepository
    {
        private readonly string _connectionString;
        private readonly string _storedProcedure = "dbo.spMEOCREALSTATEActions";

        public MEOCREALSTATERepository(IAppSettings appSettings)
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

        public async Task<List<MEOCREALSTATEModel>> GetMEOCREALSTATE(int id = 0)
        {
            return await Task.Run(() =>
            {
                var lstMEOCREAl = new List<MEOCREALSTATEModel>();
                try
                {
                    using(SqlConnection connection = new SqlConnection(this._connectionString))
                    {
                        connection.Open();
                        using(SqlCommand cmd = new SqlCommand())
                        {
                            cmd.CommandText = _storedProcedure;
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            cmd.Connection = connection;
                            cmd.Parameters.AddWithValue("@EOCRealEstateID", id);
                            cmd.Parameters.AddWithValue("@REEFSubmittal", string.Empty);
                            cmd.Parameters.AddWithValue("@REEF", string.Empty);
                            cmd.Parameters.AddWithValue("@EOCReleaseDate", DBNull.Value );
                            cmd.Parameters.AddWithValue("@EOCPoleForemanComplete", DBNull.Value);
                            cmd.Parameters.AddWithValue("@UGCnCInvestigation", string.Empty);
                            cmd.Parameters.AddWithValue("@MHDefects", string.Empty);
                            cmd.Parameters.AddWithValue("@InvestigationComments", string.Empty);
                            cmd.Parameters.AddWithValue("@MRs", string.Empty);
                            cmd.Parameters.AddWithValue("@FK_LinkingID", 1);
                            cmd.Parameters.AddWithValue("@FK_EOCID", 1);
                            cmd.Parameters.AddWithValue("@FK_COCID", 1);
                            cmd.Parameters.AddWithValue("@FK_RealEstateSupportCOCID", 1);
                            cmd.Parameters.AddWithValue("@FK_StepID", 1);
                            cmd.Parameters.AddWithValue("@createdBy", string.Empty);
                            cmd.Parameters.AddWithValue("@updatedBy", string.Empty);
                            if (id == 0)
                            {
                               
                                cmd.Parameters.AddWithValue("@procId", 4);
                            }
                            else
                            {
                                cmd.Parameters.AddWithValue("@procId", 5);
                            }

                            using(SqlDataReader dataReader = cmd.ExecuteReader())
                            {
                                while (dataReader.Read())
                                {
                                    var onlyDate = "MM'/'dd'/'yyyy";
                                    var dateWithTime = "MM'/'dd'/'yyyy h:mm tt";
                                    var meocreal = new MEOCREALSTATEModel();
                                    meocreal.EOCRealEstateID = (long)dataReader["EOCRealEstateID"];
                                    meocreal.FK_LinkingID = (long)dataReader["FK_LinkingID"];
                                    if(dataReader["FK_EOCID"] != DBNull.Value) 
                                        meocreal.FK_EOCID = (int)dataReader["FK_EOCID"];
                                    if(dataReader["EOCReleaseDate"] != DBNull.Value)
                                        meocreal.EOCReleaseDate = Convert.ToDateTime(dataReader["EOCReleaseDate"]);
                                    if(dataReader["EOCPoleForemanComplete"] != DBNull.Value)
                                        meocreal.EOCPoleForemanComplete = Convert.ToDateTime(dataReader["EOCPoleForemanComplete"]);

                                    if (dataReader["EOCReleaseDate"] != DBNull.Value)
                                        meocreal.StrEOCReleaseDate = Convert.ToDateTime(dataReader["EOCReleaseDate"]).ToString(onlyDate);
                                    if (dataReader["EOCPoleForemanComplete"] != DBNull.Value)
                                        meocreal.StrEOCPoleForemanComplete = Convert.ToDateTime(dataReader["EOCPoleForemanComplete"]).ToString(onlyDate);

                                    if (dataReader["REEFSubmittal"]!=DBNull.Value)
                                        meocreal.REEFSubmittal = dataReader["REEFSubmittal"].ToString();
                                    if(dataReader["REEF"] != DBNull.Value)
                                        meocreal.REEF = dataReader["REEF"].ToString();
                                    if(dataReader["FK_COCID"] != DBNull.Value)
                                        meocreal.FK_COCID = (int)dataReader["FK_COCID"];
                                    if(dataReader["FK_RealEstateSupportCOCID"] != DBNull.Value)
                                        meocreal.FK_RealEstateSupportCOCID = (int)dataReader["FK_RealEstateSupportCOCID"];
                                    if(dataReader["UGCnCInvestigation"]!= DBNull.Value)
                                        meocreal.UGCnCInvestigation = dataReader["UGCnCInvestigation"].ToString();
                                    if(dataReader["MHDefects"] != DBNull.Value)
                                        meocreal.MHDefects = dataReader["MHDefects"].ToString();
                                    if(dataReader["InvestigationComments"]!=DBNull.Value)
                                        meocreal.InvestigationComments = dataReader["InvestigationComments"].ToString();
                                    if(dataReader["MRs"] != DBNull.Value)
                                        meocreal.MRs = dataReader["MRs"].ToString();
                                    meocreal.FK_StepID = (int)dataReader["FK_StepID"];
                                    meocreal.IsActive = Convert.ToBoolean(dataReader["IsActive"]);
                                    meocreal.CreatedBy = dataReader["CreatedBy"].ToString();
                                    meocreal.CreatedDate = Convert.ToDateTime(dataReader["CreatedDate"]).ToString(dateWithTime);
                                    meocreal.UpdatedBy = dataReader["UpdatedBy"].ToString();
                                    meocreal.UpdatedDate = Convert.ToDateTime(dataReader["UpdatedDate"]).ToString(dateWithTime);
                                    lstMEOCREAl.Add(meocreal);
                                }
                            }
                        }
                    }
                    return lstMEOCREAl;
                }
                catch(Exception ex) { return new List<MEOCREALSTATEModel>(); }
            });
        }

        public async Task<Dictionary<MEOCREALSTATEModel,string>> CreateMEOCREALSTATE(MEOCREALSTATEModel mEOCREALSTATEModel)
        {
            return await Task.Run(() =>
            {
                var result = new Dictionary<MEOCREALSTATEModel, string>();
                try
                {
                    using(SqlConnection connection = new SqlConnection(this._connectionString))
                    {
                        using(SqlCommand cmd = new SqlCommand())
                        {
                            cmd.CommandText = _storedProcedure;
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            cmd.Connection = connection;
                            cmd.Parameters.AddWithValue("@procId", 6);
                            cmd.Parameters.AddWithValue("@EOCRealEstateID", 0);
                            cmd.Parameters.AddWithValue("@REEFSubmittal",string.IsNullOrEmpty(mEOCREALSTATEModel.REEFSubmittal)?string.Empty:mEOCREALSTATEModel.REEFSubmittal);
                            cmd.Parameters.AddWithValue("@REEF", string.IsNullOrEmpty(mEOCREALSTATEModel.REEF) ? string.Empty : mEOCREALSTATEModel.REEF);
                            cmd.Parameters.AddWithValue("@EOCReleaseDate",checkNull(mEOCREALSTATEModel.EOCReleaseDate));
                            cmd.Parameters.AddWithValue("@EOCPoleForemanComplete",checkNull(mEOCREALSTATEModel.EOCPoleForemanComplete));
                            cmd.Parameters.AddWithValue("@UGCnCInvestigation", string.IsNullOrEmpty(mEOCREALSTATEModel.UGCnCInvestigation) ? string.Empty : mEOCREALSTATEModel.UGCnCInvestigation);
                            cmd.Parameters.AddWithValue("@MHDefects", string.IsNullOrEmpty(mEOCREALSTATEModel.MHDefects) ? string.Empty : mEOCREALSTATEModel.MHDefects);
                            cmd.Parameters.AddWithValue("@InvestigationComments", string.IsNullOrEmpty(mEOCREALSTATEModel.InvestigationComments) ? string.Empty : mEOCREALSTATEModel.InvestigationComments);
                            cmd.Parameters.AddWithValue("@MRs", string.IsNullOrEmpty(mEOCREALSTATEModel.MRs) ? string.Empty : mEOCREALSTATEModel.MRs);
                            cmd.Parameters.AddWithValue("@FK_LinkingID", mEOCREALSTATEModel.FK_LinkingID);cmd.Parameters.AddWithValue("@FK_EOCID",checkNull(mEOCREALSTATEModel.FK_EOCID));
                            cmd.Parameters.AddWithValue("@FK_COCID",checkNull(mEOCREALSTATEModel.FK_COCID));
                            cmd.Parameters.AddWithValue("@FK_RealEstateSupportCOCID",checkNull(mEOCREALSTATEModel.FK_RealEstateSupportCOCID));
                            cmd.Parameters.AddWithValue("@FK_StepID", mEOCREALSTATEModel.FK_StepID);
                            cmd.Parameters.AddWithValue("@createdBy", mEOCREALSTATEModel.CreatedBy);
                            cmd.Parameters.AddWithValue("@updatedBy", mEOCREALSTATEModel.CreatedBy);
                            connection.Open();
                            int check = (int)cmd.ExecuteScalar();
                            if (check == 1)
                            {
                                cmd.Parameters["@procId"].Value = 1;
                                mEOCREALSTATEModel.EOCRealEstateID = (long)cmd.ExecuteScalar();
                            }
                            else
                            {
                                connection.Close();
                                result[mEOCREALSTATEModel] = "Linking id Already Exists!";
                                return result;
                            }
                            connection.Close();
                            result[mEOCREALSTATEModel] = "ok";
                            return result;

                        }
                    }

                }
                catch(Exception ex) { return new Dictionary<MEOCREALSTATEModel, string>(); }
            });
        }

        public async Task<Dictionary<MEOCREALSTATEModel, string>> UpdateMEOCREALSTATE(MEOCREALSTATEModel mEOCREALSTATEModel)
        {
            return await  Task.Run(() =>
            {
                var result = new Dictionary<MEOCREALSTATEModel, string>();
                try
                {
                    using(SqlConnection connection = new SqlConnection(this._connectionString))
                    {
                        using(SqlCommand cmd = new SqlCommand())
                        {
                            cmd.CommandText = _storedProcedure;
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            cmd.Connection = connection;
                            cmd.Parameters.AddWithValue("@procId", 6);
                            cmd.Parameters.AddWithValue("@EOCRealEstateID", mEOCREALSTATEModel.EOCRealEstateID);
                            cmd.Parameters.AddWithValue("@REEFSubmittal", string.IsNullOrEmpty(mEOCREALSTATEModel.REEFSubmittal) ? string.Empty : mEOCREALSTATEModel.REEFSubmittal);
                            cmd.Parameters.AddWithValue("@REEF", string.IsNullOrEmpty(mEOCREALSTATEModel.REEF) ? string.Empty : mEOCREALSTATEModel.REEF);
                            cmd.Parameters.AddWithValue("@EOCReleaseDate", checkNull(mEOCREALSTATEModel.EOCReleaseDate));
                            cmd.Parameters.AddWithValue("@EOCPoleForemanComplete", checkNull(mEOCREALSTATEModel.EOCPoleForemanComplete));
                            cmd.Parameters.AddWithValue("@UGCnCInvestigation", string.IsNullOrEmpty(mEOCREALSTATEModel.UGCnCInvestigation) ? string.Empty : mEOCREALSTATEModel.UGCnCInvestigation);
                            cmd.Parameters.AddWithValue("@MHDefects", string.IsNullOrEmpty(mEOCREALSTATEModel.MHDefects) ? string.Empty : mEOCREALSTATEModel.MHDefects);
                            cmd.Parameters.AddWithValue("@InvestigationComments", string.IsNullOrEmpty(mEOCREALSTATEModel.InvestigationComments) ? string.Empty : mEOCREALSTATEModel.InvestigationComments);
                            cmd.Parameters.AddWithValue("@MRs", string.IsNullOrEmpty(mEOCREALSTATEModel.MRs) ? string.Empty : mEOCREALSTATEModel.MRs);
                            cmd.Parameters.AddWithValue("@FK_LinkingID", mEOCREALSTATEModel.FK_LinkingID); cmd.Parameters.AddWithValue("@FK_EOCID", checkNull(mEOCREALSTATEModel.FK_EOCID));
                            cmd.Parameters.AddWithValue("@FK_COCID", checkNull(mEOCREALSTATEModel.FK_COCID));
                            cmd.Parameters.AddWithValue("@FK_RealEstateSupportCOCID", checkNull(mEOCREALSTATEModel.FK_RealEstateSupportCOCID));
                            cmd.Parameters.AddWithValue("@FK_StepID", mEOCREALSTATEModel.FK_StepID);
                            cmd.Parameters.AddWithValue("@createdBy", string.Empty);
                            cmd.Parameters.AddWithValue("@updatedBy", mEOCREALSTATEModel.UpdatedBy);
                            connection.Open();
                            
                                var meocreal = new MEOCREALSTATEModel();

                                cmd.Parameters["@procId"].Value = 5;
                                using (SqlDataReader dataReader = cmd.ExecuteReader())
                                {
                                    while (dataReader.Read())
                                    {
                                        
                                        meocreal.EOCRealEstateID = (long)dataReader["EOCRealEstateID"];
                                        meocreal.FK_LinkingID = (long)dataReader["FK_LinkingID"];

                                        if (dataReader["FK_EOCID"] != DBNull.Value)
                                            meocreal.FK_EOCID = (int)dataReader["FK_EOCID"];

                                        if (dataReader["EOCReleaseDate"] != DBNull.Value)
                                            meocreal.EOCReleaseDate = Convert.ToDateTime(dataReader["EOCReleaseDate"]);

                                        if (dataReader["EOCPoleForemanComplete"] != DBNull.Value)
                                            meocreal.EOCPoleForemanComplete = Convert.ToDateTime(dataReader["EOCPoleForemanComplete"]);

                                        if (dataReader["REEFSubmittal"] != DBNull.Value)
                                            meocreal.REEFSubmittal = dataReader["REEFSubmittal"].ToString();

                                        if (dataReader["REEF"] != DBNull.Value)
                                            meocreal.REEF = dataReader["REEF"].ToString();

                                        if (dataReader["FK_COCID"] != DBNull.Value)
                                            meocreal.FK_COCID = (int)dataReader["FK_COCID"];

                                        if (dataReader["FK_RealEstateSupportCOCID"] != DBNull.Value)
                                            meocreal.FK_RealEstateSupportCOCID = (int)dataReader["FK_RealEstateSupportCOCID"];

                                        if (dataReader["UGCnCInvestigation"] != DBNull.Value)
                                            meocreal.UGCnCInvestigation = dataReader["UGCnCInvestigation"].ToString();

                                        if (dataReader["MHDefects"] != DBNull.Value)
                                            meocreal.MHDefects = dataReader["MHDefects"].ToString();

                                        if (dataReader["InvestigationComments"] != DBNull.Value)
                                            meocreal.InvestigationComments = dataReader["InvestigationComments"].ToString();

                                        if (dataReader["MRs"] != DBNull.Value)
                                            meocreal.MRs = dataReader["MRs"].ToString();
                                        meocreal.FK_StepID = (int)dataReader["FK_StepID"];
                                        
                                    }
                                }

                                if (string.IsNullOrEmpty(mEOCREALSTATEModel.FK_LinkingID.ToString()))
                                    cmd.Parameters["@FK_LinkingID"].Value = meocreal.FK_LinkingID;

                                if (string.IsNullOrEmpty(mEOCREALSTATEModel.FK_StepID.ToString()))
                                    cmd.Parameters["@FK_StepID"].Value = meocreal.FK_StepID;

                                if (string.IsNullOrEmpty(mEOCREALSTATEModel.REEFSubmittal))
                                    cmd.Parameters["@REEFSubmittal"].Value = meocreal.REEFSubmittal;

                                if(string.IsNullOrEmpty(mEOCREALSTATEModel.REEF))
                                    cmd.Parameters["@REEF"].Value = meocreal.REEF;
                                
                                cmd.Parameters["@EOCReleaseDate"].Value = checkNullWithValue(mEOCREALSTATEModel.EOCReleaseDate,meocreal.EOCReleaseDate);
                                cmd.Parameters["@EOCPoleForemanComplete"].Value = checkNullWithValue(mEOCREALSTATEModel.EOCPoleForemanComplete,meocreal.EOCPoleForemanComplete);
                                cmd.Parameters["@MHDefects"].Value =checkNullWithValue(mEOCREALSTATEModel.MHDefects,meocreal.MHDefects);

                                if (string.IsNullOrEmpty(mEOCREALSTATEModel.InvestigationComments))
                                    cmd.Parameters["@InvestigationComments"].Value = meocreal.InvestigationComments;

                                if (string.IsNullOrEmpty(mEOCREALSTATEModel.MRs))
                                    cmd.Parameters["@MRs"].Value = meocreal.MRs;
                                cmd.Parameters["@FK_EOCID"].Value = checkNullWithValue(mEOCREALSTATEModel.FK_EOCID,meocreal.FK_EOCID);                                
                                cmd.Parameters["@FK_COCID"].Value = checkNullWithValue(mEOCREALSTATEModel.FK_COCID,meocreal.FK_COCID);
                                cmd.Parameters["@FK_RealEstateSupportCOCID"].Value = checkNullWithValue(mEOCREALSTATEModel.FK_RealEstateSupportCOCID,meocreal.FK_RealEstateSupportCOCID);
                                cmd.Parameters["@procId"].Value = 2;
                                cmd.ExecuteNonQuery();
                            
                            connection.Close();
                            result[mEOCREALSTATEModel] = "ok";
                            return result;
                        }
                    }
                }
                catch(Exception ex) { return new Dictionary<MEOCREALSTATEModel, string>(); }
            });
        }


        public async Task<int> DeleteMEOCREALSTATE(int id)
        {
            return await Task.Run(() =>
            {
                try
                {
                    using(SqlConnection connection = new SqlConnection(this._connectionString))
                    {
                        using(SqlCommand cmd = new SqlCommand())
                        {
                            cmd.CommandText = _storedProcedure;
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            cmd.Connection = connection;
                            cmd.Parameters.AddWithValue("@procId", 3);
                            cmd.Parameters.AddWithValue("@EOCRealEstateID", id);
                            cmd.Parameters.AddWithValue("@REEFSubmittal", string.Empty);
                            cmd.Parameters.AddWithValue("@REEF", string.Empty);
                            cmd.Parameters.AddWithValue("@EOCReleaseDate", DBNull.Value);
                            cmd.Parameters.AddWithValue("@EOCPoleForemanComplete", DBNull.Value);
                            cmd.Parameters.AddWithValue("@UGCnCInvestigation", string.Empty);
                            cmd.Parameters.AddWithValue("@MHDefects", string.Empty);
                            cmd.Parameters.AddWithValue("@InvestigationComments", string.Empty);
                            cmd.Parameters.AddWithValue("@MRs", string.Empty);
                            cmd.Parameters.AddWithValue("@FK_LinkingID", 1);
                            cmd.Parameters.AddWithValue("@FK_EOCID", 1);
                            cmd.Parameters.AddWithValue("@FK_COCID", 1);
                            cmd.Parameters.AddWithValue("@FK_RealEstateSupportCOCID", 1);
                            cmd.Parameters.AddWithValue("@FK_StepID", 1);
                            cmd.Parameters.AddWithValue("@createdBy", string.Empty);
                            cmd.Parameters.AddWithValue("@updatedBy", string.Empty);
                            connection.Open();
                            cmd.ExecuteScalar();
                            connection.Close();
                            return 1;
                        }
                    }
                }
                catch(Exception ex) { return 0; }
            });
        }
    }
}
