using Exelon.Domain;
using Exelon.Domain.Abstractions;
using Exelon.Domain.Common;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Exelon.Infrastructure.Repositories
{
    public class HUTPERMITRepository : IHUTPERMITRepository
    {
        private readonly string _connectionString;
        private readonly string _storedProcedure = "dbo.spHUTPERMITActions";

        public HUTPERMITRepository(IAppSettings appSettings)
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
        public async Task<List<HUTPERMITTINGModel>> GetHUT(int id = 0)
        {
            return await Task.Run(() =>
            {
                var result = new List<HUTPERMITTINGModel>();
                try
                {
                    using (SqlConnection connection = new SqlConnection(this._connectionString))
                    {
                        connection.Open();
                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.CommandText = _storedProcedure;
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@HutPermittingID", id);
                            cmd.Parameters.AddWithValue("@InstallYear", string.Empty);
                            cmd.Parameters.AddWithValue("@Substation", string.Empty);
                            cmd.Parameters.AddWithValue("@FK_EOCID", 1);
                            cmd.Parameters.AddWithValue("@FK_SizeID", 1);
                            cmd.Parameters.AddWithValue("@Location_Municipality", string.Empty);
                            cmd.Parameters.AddWithValue("@Location_County", string.Empty);
                            cmd.Parameters.AddWithValue("@FK_RequiredCountyStormwater", 1);
                            cmd.Parameters.AddWithValue("@FK_ArmyCorpsPermitRequired", 1);
                            cmd.Parameters.AddWithValue("@FK_TROWPermitRequired", 1);
                            cmd.Parameters.AddWithValue("@FK_HwyOrIDOTPermit", 1);
                            cmd.Parameters.AddWithValue("@FK_SiteDevelopmentPermitRequired", 1);
                            cmd.Parameters.AddWithValue("@FK_BuildingOrOtherPermitRequired", 1);
                            cmd.Parameters.AddWithValue("@OH_RequiredCountyStormwater", string.Empty);
                            cmd.Parameters.AddWithValue("@OH_ArmyCorpsPermitRequired", string.Empty);
                            cmd.Parameters.AddWithValue("@OH_TROWPermitRequired", string.Empty);
                            cmd.Parameters.AddWithValue("@OH_SiteDevelopmentPermitRequired", string.Empty);
                            cmd.Parameters.AddWithValue("@OH_HwyOrIDOTPermit", string.Empty);
                            cmd.Parameters.AddWithValue("@OH_BuildingOrOtherPermitRequired", string.Empty);
                            cmd.Parameters.AddWithValue("@Status", string.Empty);
                            cmd.Parameters.AddWithValue("@Comments", string.Empty);
                            cmd.Parameters.AddWithValue("@PermitExpiration", string.Empty);
                            cmd.Parameters.AddWithValue("@Notes", string.Empty);
                            cmd.Parameters.AddWithValue("@CivilIFADate", DBNull.Value);
                            cmd.Parameters.AddWithValue("@CivilIFCDate", DBNull.Value);
                            cmd.Parameters.AddWithValue("@PermitSubmissionDate", DBNull.Value);
                            cmd.Parameters.AddWithValue("@PermitReadyDate", DBNull.Value);
                            cmd.Parameters.AddWithValue("@CreatedBy", string.Empty);
                            cmd.Parameters.AddWithValue("@UpdatedBy", string.Empty);
                            cmd.Connection = connection;

                            if (id == 0)
                                cmd.Parameters.AddWithValue("@procId", 3);
                            else
                                cmd.Parameters.AddWithValue("@procId", 4);

                            using (SqlDataReader dataReader = cmd.ExecuteReader())
                            {
                                while (dataReader.Read())
                                {
                                    var onlyDate = "MM'/'dd'/'yyyy";
                                    var dateWithTime = "MM'/'dd'/'yyyy h:mm tt";
                                    var hut = new HUTPERMITTINGModel();
                                    hut.HutPermittingID = (long)dataReader["HutPermittingID"];
                                    hut.InstallYear = dataReader["InstallYear"].ToString();
                                    hut.Substation = dataReader["Substation"].ToString();
                                    hut.Location_Municipality = dataReader["Location_Municipality"].ToString();
                                    hut.Location_County = dataReader["Location_County"].ToString();
                                    hut.OH_RequiredCountyStormwater = dataReader["OH_RequiredCountyStormwater"].ToString();
                                    hut.OH_ArmyCorpsPermitRequired = dataReader["OH_ArmyCorpsPermitRequired"].ToString();
                                    hut.OH_TROWPermitRequired = dataReader["OH_TROWPermitRequired"].ToString();
                                    hut.OH_SiteDevelopmentPermitRequired = dataReader["OH_SiteDevelopmentPermitRequired"].ToString();
                                    hut.OH_HwyOrIDOTPermit = dataReader["OH_HwyOrIDOTPermit"].ToString();
                                    hut.OH_BuildingOrOtherPermitRequired = dataReader["OH_BuildingOrOtherPermitRequired"].ToString();
                                    hut.Comments = dataReader["Comments"].ToString();
                                    hut.Status = dataReader["Status"].ToString();
                                    hut.PermitExpiration = dataReader["PermitExpiration"].ToString();
                                    hut.Notes = dataReader["Notes"].ToString();
                                    if (dataReader["FK_ArmyCorpsPermitRequired"] != DBNull.Value)
                                        hut.FK_ArmyCorpsPermitRequired = (int)dataReader["FK_ArmyCorpsPermitRequired"];
                                    if (dataReader["FK_BuildingOrOtherPermitRequired"] != DBNull.Value)
                                        hut.FK_BuildingOrOtherPermitRequired = (int)dataReader["FK_BuildingOrOtherPermitRequired"];
                                    if (dataReader["FK_HwyOrIDOTPermit"] != DBNull.Value)
                                        hut.FK_HwyOrIDOTPermit = (int)dataReader["FK_HwyOrIDOTPermit"];
                                    if (dataReader["FK_RequiredCountyStormwater"] != DBNull.Value)
                                        hut.FK_RequiredCountyStormwater = (int)dataReader["FK_RequiredCountyStormwater"];
                                    if (dataReader["FK_SiteDevelopmentPermitRequired"] != DBNull.Value)
                                        hut.FK_SiteDevelopmentPermitRequired = (int)dataReader["FK_SiteDevelopmentPermitRequired"];
                                    if (dataReader["FK_SizeID"] != DBNull.Value)
                                        hut.FK_SizeID = (int)dataReader["FK_SizeID"];
                                    if(dataReader["FK_TROWPermitRequired"] != DBNull.Value)
                                    hut.FK_TROWPermitRequired = (int)dataReader["FK_TROWPermitRequired"];
                                    hut.FK_EOCID = (int)dataReader["FK_EOCID"];
                                    if(dataReader["CivilIFADate"] != DBNull.Value)
                                        hut.CivilIFADate = Convert.ToDateTime(dataReader["CivilIFADate"]);
                                    if (dataReader["CivilIFCDate"] != DBNull.Value)
                                        hut.CivilIFCDate = Convert.ToDateTime(dataReader["CivilIFCDate"]);
                                    if(dataReader["PermitReadyDate"] != DBNull.Value)
                                        hut.PermitReadyDate = Convert.ToDateTime(dataReader["PermitReadyDate"]);
                                    if(dataReader["PermitSubmissionDate"] != DBNull.Value)
                                        hut.PermitSubmissionDate = Convert.ToDateTime(dataReader["PermitSubmissionDate"]);

                                    if (dataReader["CivilIFADate"] != DBNull.Value)
                                        hut.StrCivilIFADate = Convert.ToDateTime(dataReader["CivilIFADate"]).ToString(onlyDate);
                                    if (dataReader["CivilIFCDate"] != DBNull.Value)
                                        hut.StrCivilIFCDate = Convert.ToDateTime(dataReader["CivilIFCDate"]).ToString(onlyDate);
                                    if (dataReader["PermitReadyDate"] != DBNull.Value)
                                        hut.StrPermitReadyDate = Convert.ToDateTime(dataReader["PermitReadyDate"]).ToString(onlyDate);
                                    if (dataReader["PermitSubmissionDate"] != DBNull.Value)
                                        hut.StrPermitSubmissionDate = Convert.ToDateTime(dataReader["PermitSubmissionDate"]).ToString(onlyDate);
                                    hut.IsActive = Convert.ToBoolean(dataReader["IsActive"]);
                                    hut.CreatedBy = dataReader["CreatedBy"].ToString();
                                    hut.CreatedDate = Convert.ToDateTime(dataReader["CreatedDate"]).ToString(dateWithTime);
                                    hut.UpdatedBy = dataReader["UpdatedBy"].ToString();
                                    hut.UpdatedDate = Convert.ToDateTime(dataReader["UpdatedDate"]).ToString(dateWithTime);
                                    result.Add(hut);
                                }
                            }

                        }
                        connection.Close();
                    }

                    return result;
                }
                catch (Exception ex) { return new List<HUTPERMITTINGModel>(); }
            });
        }



        public async Task<HUTPERMITTINGModel> CreateHUT(HUTPERMITTINGModel hUTPERMITTINGModel)
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
                            cmd.Parameters.AddWithValue("@HutPermittingID", 0);
                            cmd.Parameters.AddWithValue("@InstallYear", string.IsNullOrEmpty(hUTPERMITTINGModel.InstallYear) ? string.Empty : hUTPERMITTINGModel.InstallYear);
                            cmd.Parameters.AddWithValue("@Substation", string.IsNullOrEmpty(hUTPERMITTINGModel.Substation) ? string.Empty : hUTPERMITTINGModel.Substation);
                            cmd.Parameters.AddWithValue("@FK_EOCID", hUTPERMITTINGModel.FK_EOCID);
                            cmd.Parameters.AddWithValue("@FK_SizeID",checkNull(hUTPERMITTINGModel.FK_SizeID));
                            cmd.Parameters.AddWithValue("@Location_Municipality", string.IsNullOrEmpty(hUTPERMITTINGModel.Location_Municipality) ? string.Empty : hUTPERMITTINGModel.Location_Municipality);
                            cmd.Parameters.AddWithValue("@Location_County", string.IsNullOrEmpty(hUTPERMITTINGModel.Location_County) ? string.Empty : hUTPERMITTINGModel.Location_County);
                            cmd.Parameters.AddWithValue("@FK_RequiredCountyStormwater",checkNull(hUTPERMITTINGModel.FK_RequiredCountyStormwater));
                            cmd.Parameters.AddWithValue("@FK_ArmyCorpsPermitRequired",checkNull(hUTPERMITTINGModel.FK_ArmyCorpsPermitRequired));
                            cmd.Parameters.AddWithValue("@FK_TROWPermitRequired",checkNull(hUTPERMITTINGModel.FK_TROWPermitRequired));
                            cmd.Parameters.AddWithValue("@FK_SiteDevelopmentPermitRequired",checkNull(hUTPERMITTINGModel.FK_SiteDevelopmentPermitRequired));
                            cmd.Parameters.AddWithValue("@FK_BuildingOrOtherPermitRequired",checkNull(hUTPERMITTINGModel.FK_BuildingOrOtherPermitRequired));
                            cmd.Parameters.AddWithValue("@FK_HwyOrIDOTPermit",checkNull(hUTPERMITTINGModel.FK_HwyOrIDOTPermit));
                            cmd.Parameters.AddWithValue("@OH_RequiredCountyStormwater", string.IsNullOrEmpty(hUTPERMITTINGModel.OH_RequiredCountyStormwater) ? string.Empty : hUTPERMITTINGModel.OH_RequiredCountyStormwater);
                            cmd.Parameters.AddWithValue("@OH_ArmyCorpsPermitRequired", string.IsNullOrEmpty(hUTPERMITTINGModel.OH_ArmyCorpsPermitRequired) ? string.Empty : hUTPERMITTINGModel.OH_ArmyCorpsPermitRequired);
                            cmd.Parameters.AddWithValue("@OH_TROWPermitRequired", string.IsNullOrEmpty(hUTPERMITTINGModel.OH_TROWPermitRequired) ? string.Empty : hUTPERMITTINGModel.OH_TROWPermitRequired);
                            cmd.Parameters.AddWithValue("@OH_SiteDevelopmentPermitRequired", string.IsNullOrEmpty(hUTPERMITTINGModel.OH_SiteDevelopmentPermitRequired) ? string.Empty : hUTPERMITTINGModel.OH_SiteDevelopmentPermitRequired);
                            cmd.Parameters.AddWithValue("@OH_HwyOrIDOTPermit", string.IsNullOrEmpty(hUTPERMITTINGModel.OH_HwyOrIDOTPermit) ? string.Empty : hUTPERMITTINGModel.OH_HwyOrIDOTPermit);
                            cmd.Parameters.AddWithValue("@OH_BuildingOrOtherPermitRequired", string.IsNullOrEmpty(hUTPERMITTINGModel.OH_BuildingOrOtherPermitRequired) ? string.Empty : hUTPERMITTINGModel.OH_BuildingOrOtherPermitRequired);
                            cmd.Parameters.AddWithValue("@Status", string.IsNullOrEmpty(hUTPERMITTINGModel.Status) ? string.Empty : hUTPERMITTINGModel.Status);
                            cmd.Parameters.AddWithValue("@Comments", string.IsNullOrEmpty(hUTPERMITTINGModel.Comments) ? string.Empty : hUTPERMITTINGModel.Comments);
                            cmd.Parameters.AddWithValue("@PermitExpiration", string.IsNullOrEmpty(hUTPERMITTINGModel.PermitExpiration) ? string.Empty : hUTPERMITTINGModel.PermitExpiration);
                            cmd.Parameters.AddWithValue("@Notes", string.IsNullOrEmpty(hUTPERMITTINGModel.Notes) ? string.Empty : hUTPERMITTINGModel.Notes);
                            cmd.Parameters.AddWithValue("@CivilIFADate",checkNull(hUTPERMITTINGModel.CivilIFADate));
                            cmd.Parameters.AddWithValue("@CivilIFCDate",checkNull(hUTPERMITTINGModel.CivilIFCDate));
                            cmd.Parameters.AddWithValue("@PermitSubmissionDate",checkNull(hUTPERMITTINGModel.PermitSubmissionDate));
                            cmd.Parameters.AddWithValue("@PermitReadyDate",checkNull(hUTPERMITTINGModel.PermitReadyDate));
                            cmd.Parameters.AddWithValue("@CreatedBy", hUTPERMITTINGModel.CreatedBy);
                            cmd.Parameters.AddWithValue("@UpdatedBy", hUTPERMITTINGModel.CreatedBy);
                            cmd.Connection = connection; 
                            connection.Open();
                            hUTPERMITTINGModel.HutPermittingID =(long)cmd.ExecuteScalar();
                            connection.Close();
                            return hUTPERMITTINGModel;
                        }
                    }
                }
                catch (Exception ex) { return new HUTPERMITTINGModel(); }

            });
        }

        public async Task<HUTPERMITTINGModel> UpdateHUT(HUTPERMITTINGModel hUTPERMITTINGModel)
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
                            cmd.Parameters.AddWithValue("@procId", 4);
                            cmd.Parameters.AddWithValue("@HutPermittingID", hUTPERMITTINGModel.HutPermittingID);
                            cmd.Parameters.AddWithValue("@InstallYear", string.IsNullOrEmpty(hUTPERMITTINGModel.InstallYear) ? string.Empty : hUTPERMITTINGModel.InstallYear);
                            cmd.Parameters.AddWithValue("@Substation", string.IsNullOrEmpty(hUTPERMITTINGModel.Substation) ? string.Empty : hUTPERMITTINGModel.Substation);
                            cmd.Parameters.AddWithValue("@FK_EOCID", checkNull(hUTPERMITTINGModel.FK_EOCID));
                            cmd.Parameters.AddWithValue("@FK_SizeID", checkNull(hUTPERMITTINGModel.FK_SizeID));
                            cmd.Parameters.AddWithValue("@Location_Municipality", string.IsNullOrEmpty(hUTPERMITTINGModel.Location_Municipality) ? string.Empty : hUTPERMITTINGModel.Location_Municipality);
                            cmd.Parameters.AddWithValue("@Location_County", string.IsNullOrEmpty(hUTPERMITTINGModel.Location_County) ? string.Empty : hUTPERMITTINGModel.Location_County);
                            cmd.Parameters.AddWithValue("@FK_RequiredCountyStormwater", checkNull(hUTPERMITTINGModel.FK_RequiredCountyStormwater));
                            cmd.Parameters.AddWithValue("@FK_ArmyCorpsPermitRequired", checkNull(hUTPERMITTINGModel.FK_ArmyCorpsPermitRequired));
                            cmd.Parameters.AddWithValue("@FK_TROWPermitRequired", checkNull(hUTPERMITTINGModel.FK_TROWPermitRequired));
                            cmd.Parameters.AddWithValue("@FK_SiteDevelopmentPermitRequired", checkNull(hUTPERMITTINGModel.FK_SiteDevelopmentPermitRequired));
                            cmd.Parameters.AddWithValue("@FK_BuildingOrOtherPermitRequired", checkNull(hUTPERMITTINGModel.FK_BuildingOrOtherPermitRequired));
                            cmd.Parameters.AddWithValue("@FK_HwyOrIDOTPermit", checkNull(hUTPERMITTINGModel.FK_HwyOrIDOTPermit));
                            cmd.Parameters.AddWithValue("@OH_RequiredCountyStormwater", string.IsNullOrEmpty(hUTPERMITTINGModel.OH_RequiredCountyStormwater) ? string.Empty : hUTPERMITTINGModel.OH_RequiredCountyStormwater);
                            cmd.Parameters.AddWithValue("@OH_ArmyCorpsPermitRequired", string.IsNullOrEmpty(hUTPERMITTINGModel.OH_ArmyCorpsPermitRequired) ? string.Empty : hUTPERMITTINGModel.OH_ArmyCorpsPermitRequired);
                            cmd.Parameters.AddWithValue("@OH_TROWPermitRequired", string.IsNullOrEmpty(hUTPERMITTINGModel.OH_TROWPermitRequired) ? string.Empty : hUTPERMITTINGModel.OH_TROWPermitRequired);
                            cmd.Parameters.AddWithValue("@OH_SiteDevelopmentPermitRequired", string.IsNullOrEmpty(hUTPERMITTINGModel.OH_SiteDevelopmentPermitRequired) ? string.Empty : hUTPERMITTINGModel.OH_SiteDevelopmentPermitRequired);
                            cmd.Parameters.AddWithValue("@OH_HwyOrIDOTPermit", string.IsNullOrEmpty(hUTPERMITTINGModel.OH_HwyOrIDOTPermit) ? string.Empty : hUTPERMITTINGModel.OH_HwyOrIDOTPermit);
                            cmd.Parameters.AddWithValue("@OH_BuildingOrOtherPermitRequired", string.IsNullOrEmpty(hUTPERMITTINGModel.OH_BuildingOrOtherPermitRequired) ? string.Empty : hUTPERMITTINGModel.OH_BuildingOrOtherPermitRequired);
                            cmd.Parameters.AddWithValue("@Status", string.IsNullOrEmpty(hUTPERMITTINGModel.Status) ? string.Empty : hUTPERMITTINGModel.Status);
                            cmd.Parameters.AddWithValue("@Comments", string.IsNullOrEmpty(hUTPERMITTINGModel.Comments) ? string.Empty : hUTPERMITTINGModel.Comments);
                            cmd.Parameters.AddWithValue("@PermitExpiration", string.IsNullOrEmpty(hUTPERMITTINGModel.PermitExpiration) ? string.Empty : hUTPERMITTINGModel.PermitExpiration);
                            cmd.Parameters.AddWithValue("@Notes", string.IsNullOrEmpty(hUTPERMITTINGModel.Notes) ? string.Empty : hUTPERMITTINGModel.Notes);
                            cmd.Parameters.AddWithValue("@CivilIFADate", checkNull(hUTPERMITTINGModel.CivilIFADate));
                            cmd.Parameters.AddWithValue("@CivilIFCDate", checkNull(hUTPERMITTINGModel.CivilIFCDate));
                            cmd.Parameters.AddWithValue("@PermitSubmissionDate", checkNull(hUTPERMITTINGModel.PermitSubmissionDate));
                            cmd.Parameters.AddWithValue("@PermitReadyDate", checkNull(hUTPERMITTINGModel.PermitReadyDate));
                            cmd.Parameters.AddWithValue("@CreatedBy", string.Empty);
                            cmd.Parameters.AddWithValue("@UpdatedBy", hUTPERMITTINGModel.UpdatedBy);
                            cmd.Connection = connection;
                            connection.Open();
                            var hut = new HUTPERMITTINGModel();
                            using (SqlDataReader dataReader = cmd.ExecuteReader())
                            {
                                while (dataReader.Read())
                                {

                                    hut.HutPermittingID = (long)dataReader["HutPermittingID"];
                                    hut.InstallYear = dataReader["InstallYear"].ToString();
                                    hut.Substation = dataReader["Substation"].ToString();
                                    hut.Location_Municipality = dataReader["Location_Municipality"].ToString();
                                    hut.Location_County = dataReader["Location_County"].ToString();
                                    hut.OH_RequiredCountyStormwater = dataReader["OH_RequiredCountyStormwater"].ToString();
                                    hut.OH_ArmyCorpsPermitRequired = dataReader["OH_ArmyCorpsPermitRequired"].ToString();
                                    hut.OH_TROWPermitRequired = dataReader["OH_TROWPermitRequired"].ToString();
                                    hut.OH_SiteDevelopmentPermitRequired = dataReader["OH_SiteDevelopmentPermitRequired"].ToString();
                                    hut.OH_HwyOrIDOTPermit = dataReader["OH_HwyOrIDOTPermit"].ToString();
                                    hut.OH_BuildingOrOtherPermitRequired = dataReader["OH_BuildingOrOtherPermitRequired"].ToString();
                                    hut.Comments = dataReader["Comments"].ToString();
                                    hut.PermitExpiration = dataReader["PermitExpiration"].ToString();
                                    hut.Notes = dataReader["Notes"].ToString();
                                    hut.Status = dataReader["Status"].ToString();
                                    if (dataReader["FK_ArmyCorpsPermitRequired"] != DBNull.Value)
                                        hut.FK_ArmyCorpsPermitRequired = (int)dataReader["FK_ArmyCorpsPermitRequired"];
                                    if (dataReader["FK_BuildingOrOtherPermitRequired"] != DBNull.Value)
                                        hut.FK_BuildingOrOtherPermitRequired = (int)dataReader["FK_BuildingOrOtherPermitRequired"];
                                    if (dataReader["FK_HwyOrIDOTPermit"] != DBNull.Value)
                                        hut.FK_HwyOrIDOTPermit = (int)dataReader["FK_HwyOrIDOTPermit"];
                                    if (dataReader["FK_RequiredCountyStormwater"] != DBNull.Value)
                                        hut.FK_RequiredCountyStormwater = (int)dataReader["FK_RequiredCountyStormwater"];
                                    if (dataReader["FK_SiteDevelopmentPermitRequired"] != DBNull.Value)
                                        hut.FK_SiteDevelopmentPermitRequired = (int)dataReader["FK_SiteDevelopmentPermitRequired"];
                                    if (dataReader["FK_SizeID"] != DBNull.Value)
                                        hut.FK_SizeID = (int)dataReader["FK_SizeID"];
                                    if (dataReader["FK_TROWPermitRequired"] != DBNull.Value)
                                        hut.FK_TROWPermitRequired = (int)dataReader["FK_TROWPermitRequired"];
                                    hut.FK_EOCID = (int)dataReader["FK_EOCID"];
                                    if (dataReader["CivilIFADate"] != DBNull.Value)
                                        hut.CivilIFADate = Convert.ToDateTime(dataReader["CivilIFADate"]);
                                    if (dataReader["CivilIFCDate"] != DBNull.Value)
                                        hut.CivilIFCDate = Convert.ToDateTime(dataReader["CivilIFCDate"]);
                                    if (dataReader["PermitReadyDate"] != DBNull.Value)
                                        hut.PermitReadyDate = Convert.ToDateTime(dataReader["PermitReadyDate"]);
                                    if (dataReader["PermitSubmissionDate"] != DBNull.Value)
                                        hut.PermitSubmissionDate = Convert.ToDateTime(dataReader["PermitSubmissionDate"]);
                                }
                            }
                            cmd.Parameters["@procId"].Value = 2;
                            if (string.IsNullOrEmpty(hUTPERMITTINGModel.InstallYear))
                                cmd.Parameters["@InstallYear"].Value = hut.InstallYear;

                            if (string.IsNullOrEmpty(hUTPERMITTINGModel.Substation))
                                cmd.Parameters["@Substation"].Value = hut.Substation;

                            if (string.IsNullOrEmpty(hUTPERMITTINGModel.Location_Municipality))
                                cmd.Parameters["@Location_Municipality"].Value = hut.Location_Municipality;

                            if (string.IsNullOrEmpty(hUTPERMITTINGModel.Location_County))
                                cmd.Parameters["@Location_County"].Value = hut.Location_County;

                            if (string.IsNullOrEmpty(hUTPERMITTINGModel.OH_RequiredCountyStormwater))
                                cmd.Parameters["@OH_RequiredCountyStormwater"].Value = hut.OH_RequiredCountyStormwater;

                            if (string.IsNullOrEmpty(hUTPERMITTINGModel.OH_BuildingOrOtherPermitRequired))
                                cmd.Parameters["@OH_BuildingOrOtherPermitRequired"].Value = hut.OH_BuildingOrOtherPermitRequired;

                            if (string.IsNullOrEmpty(hUTPERMITTINGModel.OH_ArmyCorpsPermitRequired))
                                cmd.Parameters["@OH_ArmyCorpsPermitRequired"].Value = hut.OH_ArmyCorpsPermitRequired;

                            if (string.IsNullOrEmpty(hUTPERMITTINGModel.OH_HwyOrIDOTPermit))
                                cmd.Parameters["@OH_HwyOrIDOTPermit"].Value = hut.OH_HwyOrIDOTPermit;

                            if (string.IsNullOrEmpty(hUTPERMITTINGModel.OH_SiteDevelopmentPermitRequired))
                                cmd.Parameters["@OH_SiteDevelopmentPermitRequired"].Value = hut.OH_SiteDevelopmentPermitRequired;

                            if (string.IsNullOrEmpty(hUTPERMITTINGModel.OH_TROWPermitRequired))
                                cmd.Parameters["@OH_TROWPermitRequired"].Value = hut.OH_TROWPermitRequired;

                            if (string.IsNullOrEmpty(hUTPERMITTINGModel.Comments))
                                cmd.Parameters["@Comments"].Value = hut.Comments;

                            if (string.IsNullOrEmpty(hUTPERMITTINGModel.PermitExpiration))
                                cmd.Parameters["@PermitExpiration"].Value = hut.PermitExpiration;

                            if (string.IsNullOrEmpty(hUTPERMITTINGModel.Status))
                                cmd.Parameters["@Status"].Value = hut.Status;

                            if (string.IsNullOrEmpty(hUTPERMITTINGModel.Notes))
                                cmd.Parameters["@Notes"].Value = hut.Notes;

                            cmd.Parameters["@FK_SizeID"].Value = checkNullWithValue(hUTPERMITTINGModel.FK_SizeID, hut.FK_SizeID);
                            cmd.Parameters["@FK_EOCID"].Value = checkNullWithValue(hUTPERMITTINGModel.FK_EOCID, hut.FK_EOCID);
                            cmd.Parameters["@FK_ArmyCorpsPermitRequired"].Value =checkNullWithValue(hUTPERMITTINGModel.FK_ArmyCorpsPermitRequired,hut.FK_ArmyCorpsPermitRequired);
                            cmd.Parameters["@FK_BuildingOrOtherPermitRequired"].Value =checkNullWithValue(hUTPERMITTINGModel.FK_BuildingOrOtherPermitRequired,hut.FK_BuildingOrOtherPermitRequired);
                            cmd.Parameters["@FK_HwyOrIDOTPermit"].Value = checkNullWithValue(hUTPERMITTINGModel.FK_HwyOrIDOTPermit,hut.FK_HwyOrIDOTPermit);
                            cmd.Parameters["@FK_RequiredCountyStormwater"].Value =checkNullWithValue(hUTPERMITTINGModel.FK_RequiredCountyStormwater,hut.FK_RequiredCountyStormwater);
                            cmd.Parameters["@FK_SiteDevelopmentPermitRequired"].Value =checkNullWithValue(hUTPERMITTINGModel.FK_SiteDevelopmentPermitRequired,hut.FK_SiteDevelopmentPermitRequired);
                            cmd.Parameters["@FK_TROWPermitRequired"].Value =checkNullWithValue(hUTPERMITTINGModel.FK_TROWPermitRequired,hut.FK_TROWPermitRequired);cmd.Parameters["@FK_SizeID"].Value =checkNullWithValue(hUTPERMITTINGModel.FK_SizeID,hut.FK_SizeID);
                            cmd.Parameters["@CivilIFADate"].Value =checkNullWithValue(hUTPERMITTINGModel.CivilIFADate,hut.CivilIFADate);
                            cmd.Parameters["@CivilIFCDate"].Value =checkNullWithValue(hUTPERMITTINGModel.CivilIFCDate, hut.CivilIFCDate);
                            cmd.Parameters["@PermitReadyDate"].Value = checkNullWithValue(hUTPERMITTINGModel.PermitReadyDate,hut.PermitReadyDate);
                            cmd.Parameters["@PermitSubmissionDate"].Value =checkNullWithValue(hUTPERMITTINGModel.PermitSubmissionDate,hut.PermitSubmissionDate);
                            cmd.ExecuteNonQuery();
                            connection.Close();
                            return hUTPERMITTINGModel;
                        }
                    }
                }
                catch (Exception ex) { return new HUTPERMITTINGModel(); }

            });
        }

        public async Task<int> DeleteHUT(int id)
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
                            cmd.Parameters.AddWithValue("@HutPermittingID", id);
                            cmd.Parameters.AddWithValue("@InstallYear", string.Empty);
                            cmd.Parameters.AddWithValue("@Substation", string.Empty);
                            cmd.Parameters.AddWithValue("@FK_EOCID", 1);
                            cmd.Parameters.AddWithValue("@FK_SizeID", 1);
                            cmd.Parameters.AddWithValue("@Location_Municipality", string.Empty);
                            cmd.Parameters.AddWithValue("@Location_County", string.Empty);
                            cmd.Parameters.AddWithValue("@FK_HwyOrIDOTPermit", DBNull.Value);
                            cmd.Parameters.AddWithValue("@FK_RequiredCountyStormwater", 1);
                            cmd.Parameters.AddWithValue("@FK_ArmyCorpsPermitRequired", 1);
                            cmd.Parameters.AddWithValue("@FK_TROWPermitRequired", 1);
                            cmd.Parameters.AddWithValue("@FK_SiteDevelopmentPermitRequired", 1);
                            cmd.Parameters.AddWithValue("@FK_BuildingOrOtherPermitRequired", 1);
                            cmd.Parameters.AddWithValue("@OH_RequiredCountyStormwater", string.Empty);
                            cmd.Parameters.AddWithValue("@OH_ArmyCorpsPermitRequired", string.Empty);
                            cmd.Parameters.AddWithValue("@OH_TROWPermitRequired", string.Empty);
                            cmd.Parameters.AddWithValue("@OH_SiteDevelopmentPermitRequired", string.Empty);
                            cmd.Parameters.AddWithValue("@OH_HwyOrIDOTPermit", string.Empty);
                            cmd.Parameters.AddWithValue("@OH_BuildingOrOtherPermitRequired", string.Empty);
                            cmd.Parameters.AddWithValue("@Status", string.Empty);
                            cmd.Parameters.AddWithValue("@Comments", string.Empty);
                            cmd.Parameters.AddWithValue("@PermitExpiration", string.Empty);
                            cmd.Parameters.AddWithValue("@Notes", string.Empty);
                            cmd.Parameters.AddWithValue("@CivilIFADate", DBNull.Value);
                            cmd.Parameters.AddWithValue("@CivilIFCDate", DBNull.Value);
                            cmd.Parameters.AddWithValue("@PermitSubmissionDate", DBNull.Value);
                            cmd.Parameters.AddWithValue("@PermitReadyDate", DBNull.Value);
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
