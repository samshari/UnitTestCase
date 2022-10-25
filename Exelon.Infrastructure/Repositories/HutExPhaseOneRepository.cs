using Exelon.Domain.Abstractions;
using Exelon.Domain.Common;
using Exelon.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Exelon.Infrastructure.Repositories
{
    public class HutExPhaseOneRepository : IHutExPhaseOneRepository
    {

        private readonly string _connectionString;
        private readonly string _storedProcedure = "dbo.spHutExecutionPhaseOneActions";

        public HutExPhaseOneRepository(IAppSettings appSettings)
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

        public async  Task<List<HutExPhaseOneModel>> GetHutExPOne(int id = 0)
        {
            return await Task.Run(() =>
            {
                var result = new List<HutExPhaseOneModel>();
                try
                {
                    using (SqlConnection connection = new SqlConnection(this._connectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.CommandText = _storedProcedure;
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@HutExPhaseOneID", id);
                            cmd.Parameters.AddWithValue("@FK_HutExecutionID",0);
                            cmd.Parameters.AddWithValue("@FK_LandAcquisitionRequired",0);
                            cmd.Parameters.AddWithValue("@LandAcquisitionOther",string.Empty);
                            cmd.Parameters.AddWithValue("@LocationTwo",string.Empty);
                            cmd.Parameters.AddWithValue("@PhaseOneFeasibility_T35",string.Empty);
                            cmd.Parameters.AddWithValue("@FK_IsLandAcquisitionRequired",0);
                            cmd.Parameters.AddWithValue("@LandAcquisitionRequiredOth",string.Empty);
                            cmd.Parameters.AddWithValue("@FK_SiteLayoutApprovalStatus",0);
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

                                    var dateWithTime = "MM'/'dd'/'yyyy h:mm tt";
                                    var hutexphase = new HutExPhaseOneModel();
                                    hutexphase.HutExPhaseOneID = (long)dataReader["HutExPhaseOneID"];
                                    hutexphase.FK_HutExecutionID = (long)dataReader["FK_HutExecutionID"];
                                    if(dataReader["FK_LandAcquisitionRequired"]!=DBNull.Value)
                                        hutexphase.FK_LandAcquisitionRequired = (int)dataReader["FK_LandAcquisitionRequired"];
                                    hutexphase.LandAcquisitionOther = dataReader["LandAcquisitionOther"].ToString();
                                    hutexphase.LocationTwo = dataReader["LocationTwo"].ToString();
                                    hutexphase.PhaseOneFeasibility_T35 = dataReader["PhaseOneFeasibility_T35"].ToString();
                                    if(dataReader["FK_IsLandAcquisitionRequired"]!=DBNull.Value)
                                        hutexphase.FK_IsLandAcquisitionRequired = (int)dataReader["FK_IsLandAcquisitionRequired"];
                                    hutexphase.LandAcquisitionRequiredOth = dataReader["LandAcquisitionRequiredOth"].ToString();
                                    if(dataReader["FK_SiteLayoutApprovalStatus"]!=DBNull.Value)
                                        hutexphase.FK_SiteLayoutApprovalStatus = (int)dataReader["FK_SiteLayoutApprovalStatus"];
                                    hutexphase.IsActive = Convert.ToBoolean(dataReader["IsActive"]);
                                    hutexphase.CreatedBy = dataReader["CreatedBy"].ToString();
                                    hutexphase.CreatedDate = Convert.ToDateTime(dataReader["CreatedDate"]).ToString(dateWithTime);
                                    hutexphase.UpdatedBy = dataReader["UpdatedBy"].ToString();
                                    hutexphase.UpdatedDate = Convert.ToDateTime(dataReader["UpdatedDate"]).ToString(dateWithTime);
                                    result.Add(hutexphase);

                                }
                            }
                            connection.Close();
                            return result;
                        }
                    }

                }
                catch (Exception ex) { return new List<HutExPhaseOneModel>(); }
            });
        }


        public async Task<HutExPhaseOneModel> CreateHutExPOne(HutExPhaseOneModel exPhaseOneModel)
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
                            cmd.Parameters.AddWithValue("@procId", 1);
                            cmd.Parameters.AddWithValue("@HutExPhaseOneID", exPhaseOneModel.HutExPhaseOneID);
                            cmd.Parameters.AddWithValue("@FK_HutExecutionID", exPhaseOneModel.FK_HutExecutionID);
                            cmd.Parameters.AddWithValue("@FK_LandAcquisitionRequired",checkNull(exPhaseOneModel.FK_LandAcquisitionRequired));
                            cmd.Parameters.AddWithValue("@LandAcquisitionOther", string.IsNullOrEmpty(exPhaseOneModel.LandAcquisitionOther)?string.Empty:exPhaseOneModel.LandAcquisitionOther);
                            cmd.Parameters.AddWithValue("@LocationTwo", string.IsNullOrEmpty(exPhaseOneModel.LocationTwo)?string.Empty:exPhaseOneModel.LocationTwo);
                            cmd.Parameters.AddWithValue("@PhaseOneFeasibility_T35", string.IsNullOrEmpty(exPhaseOneModel.PhaseOneFeasibility_T35)?string.Empty:exPhaseOneModel.PhaseOneFeasibility_T35);
                            cmd.Parameters.AddWithValue("@FK_IsLandAcquisitionRequired",checkNull(exPhaseOneModel.FK_IsLandAcquisitionRequired));
                            cmd.Parameters.AddWithValue("@LandAcquisitionRequiredOth", string.IsNullOrEmpty(exPhaseOneModel.LandAcquisitionRequiredOth)?string.Empty:exPhaseOneModel.LandAcquisitionRequiredOth);
                            cmd.Parameters.AddWithValue("@FK_SiteLayoutApprovalStatus",checkNull(exPhaseOneModel.FK_SiteLayoutApprovalStatus));
                            cmd.Parameters.AddWithValue("@CreatedBy", exPhaseOneModel.CreatedBy);
                            cmd.Parameters.AddWithValue("@updatedBy", exPhaseOneModel.CreatedBy);
                            cmd.Connection = connection;
                            connection.Open();
                            exPhaseOneModel.HutExPhaseOneID = (long)cmd.ExecuteScalar();
                            connection.Close();
                            return exPhaseOneModel;

                        }
                    }

                }
                catch (Exception ex) { return new HutExPhaseOneModel(); }
            });
        }

        public async Task<HutExPhaseOneModel> UpdateHutExPOne(HutExPhaseOneModel exPhaseOneModel)
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
                            cmd.Parameters.AddWithValue("@HutExPhaseOneID", exPhaseOneModel.HutExPhaseOneID);
                            cmd.Parameters.AddWithValue("@FK_HutExecutionID", exPhaseOneModel.FK_HutExecutionID);
                            cmd.Parameters.AddWithValue("@FK_LandAcquisitionRequired", checkNull(exPhaseOneModel.FK_LandAcquisitionRequired));
                            cmd.Parameters.AddWithValue("@LandAcquisitionOther", string.IsNullOrEmpty(exPhaseOneModel.LandAcquisitionOther) ? string.Empty : exPhaseOneModel.LandAcquisitionOther);
                            cmd.Parameters.AddWithValue("@LocationTwo", string.IsNullOrEmpty(exPhaseOneModel.LocationTwo) ? string.Empty : exPhaseOneModel.LocationTwo);
                            cmd.Parameters.AddWithValue("@PhaseOneFeasibility_T35", string.IsNullOrEmpty(exPhaseOneModel.PhaseOneFeasibility_T35) ? string.Empty : exPhaseOneModel.PhaseOneFeasibility_T35);
                            cmd.Parameters.AddWithValue("@FK_IsLandAcquisitionRequired", checkNull(exPhaseOneModel.FK_IsLandAcquisitionRequired));
                            cmd.Parameters.AddWithValue("@LandAcquisitionRequiredOth", string.IsNullOrEmpty(exPhaseOneModel.LandAcquisitionRequiredOth) ? string.Empty : exPhaseOneModel.LandAcquisitionRequiredOth);
                            cmd.Parameters.AddWithValue("@FK_SiteLayoutApprovalStatus", checkNull(exPhaseOneModel.FK_SiteLayoutApprovalStatus));
                            cmd.Parameters.AddWithValue("@CreatedBy", string.Empty);
                            cmd.Parameters.AddWithValue("@updatedBy", exPhaseOneModel.UpdatedBy);
                            cmd.Connection = connection;
                            connection.Open();

                            var hutexphase = new HutExPhaseOneModel();
                            using (SqlDataReader dataReader = cmd.ExecuteReader())
                            {
                                while (dataReader.Read())
                                {
                                    
                                    hutexphase.HutExPhaseOneID = (long)dataReader["HutExPhaseOneID"];
                                    hutexphase.FK_HutExecutionID = (long)dataReader["FK_HutExecutionID"];
                                    if (dataReader["FK_LandAcquisitionRequired"] != DBNull.Value)
                                        hutexphase.FK_LandAcquisitionRequired = (int)dataReader["FK_LandAcquisitionRequired"];
                                    hutexphase.LandAcquisitionOther = dataReader["LandAcquisitionOther"].ToString();
                                    hutexphase.LocationTwo = dataReader["LocationTwo"].ToString();
                                    hutexphase.PhaseOneFeasibility_T35 = dataReader["PhaseOneFeasibility_T35"].ToString();
                                    if (dataReader["FK_IsLandAcquisitionRequired"] != DBNull.Value)
                                        hutexphase.FK_IsLandAcquisitionRequired = (int)dataReader["FK_IsLandAcquisitionRequired"];
                                    hutexphase.LandAcquisitionRequiredOth = dataReader["LandAcquisitionRequiredOth"].ToString();
                                    if (dataReader["FK_SiteLayoutApprovalStatus"] != DBNull.Value)
                                        hutexphase.FK_SiteLayoutApprovalStatus = (int)dataReader["FK_SiteLayoutApprovalStatus"];

                                }
                            }

                            if (string.IsNullOrEmpty(exPhaseOneModel.LandAcquisitionOther))
                                cmd.Parameters["@LandAcquisitionOther"].Value = hutexphase.LandAcquisitionOther;

                            if (string.IsNullOrEmpty(exPhaseOneModel.LocationTwo))
                                cmd.Parameters["@LocationTwo"].Value = hutexphase.LocationTwo;

                            if (string.IsNullOrEmpty(exPhaseOneModel.PhaseOneFeasibility_T35))
                                cmd.Parameters["@PhaseOneFeasibility_T35"].Value = hutexphase.PhaseOneFeasibility_T35;

                            if (string.IsNullOrEmpty(exPhaseOneModel.LandAcquisitionRequiredOth))
                                cmd.Parameters["@LandAcquisitionRequiredOth"].Value = hutexphase.LandAcquisitionRequiredOth;
   
                            cmd.Parameters["@FK_IsLandAcquisitionRequired"].Value =checkNullWithValue(exPhaseOneModel.FK_IsLandAcquisitionRequired, hutexphase.FK_IsLandAcquisitionRequired);
                            cmd.Parameters["@FK_LandAcquisitionRequired"].Value =checkNullWithValue(exPhaseOneModel.FK_LandAcquisitionRequired,hutexphase.FK_LandAcquisitionRequired);
                            cmd.Parameters["@FK_SiteLayoutApprovalStatus"].Value =checkNullWithValue(exPhaseOneModel.FK_SiteLayoutApprovalStatus,hutexphase.FK_SiteLayoutApprovalStatus);
                            cmd.Parameters["@procId"].Value = 2;
                            cmd.ExecuteNonQuery();
                            connection.Close();
                            return exPhaseOneModel;

                        }
                    }

                }
                catch (Exception ex) { return new HutExPhaseOneModel(); }
            });

        }

        public async Task<int> DeleteHutExPOne(int id)
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
                            cmd.Parameters.AddWithValue("@HutExPhaseOneID", id);
                            cmd.Parameters.AddWithValue("@FK_HutExecutionID", 0);
                            cmd.Parameters.AddWithValue("@FK_LandAcquisitionRequired", 0);
                            cmd.Parameters.AddWithValue("@LandAcquisitionOther", string.Empty);
                            cmd.Parameters.AddWithValue("@LocationTwo", string.Empty);
                            cmd.Parameters.AddWithValue("@PhaseOneFeasibility_T35", string.Empty);
                            cmd.Parameters.AddWithValue("@FK_IsLandAcquisitionRequired", 0);
                            cmd.Parameters.AddWithValue("@LandAcquisitionRequiredOth", string.Empty);
                            cmd.Parameters.AddWithValue("@FK_SiteLayoutApprovalStatus", 0);
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
