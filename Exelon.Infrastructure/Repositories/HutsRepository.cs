using Exelon.Domain;
using Exelon.Domain.Abstractions;
using Exelon.Domain.Common;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Exelon.Infrastructure.Repositories
{
    public class HUTSRepository : IHutRepository
    {
        private readonly string _connectionString;
        private readonly string _storedProcedure = "dbo.spHUTSActions";

        public HUTSRepository(IAppSettings appSettings)
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
        public async Task<List<HUTSModel>> GetHUTS(int id = 0)
        {
            return await Task.Run(() =>
            {
                var result = new List<HUTSModel>();
                try
                {
                    using(SqlConnection connection = new SqlConnection(this._connectionString))
                    {
                        using(SqlCommand cmd = new SqlCommand())
                        {
                            cmd.CommandText = _storedProcedure;
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@HutsID", id);
                            cmd.Parameters.AddWithValue("@Substation", string.Empty);
                            cmd.Parameters.AddWithValue("@FK_PDID", 1);
                            cmd.Parameters.AddWithValue("@Address", 1);
                            cmd.Parameters.AddWithValue("@FK_RegionID", 1);
                            cmd.Parameters.AddWithValue("@FK_SizeID", 1);
                            cmd.Parameters.AddWithValue("@Vendor", string.Empty);
                            cmd.Parameters.AddWithValue("@WorkOrder", string.Empty);
                            cmd.Parameters.AddWithValue("@ProjectID", string.Empty);
                            cmd.Parameters.AddWithValue("@ProjectManager", string.Empty);
                            cmd.Parameters.AddWithValue("@FK_EOCID", 1);
                            cmd.Parameters.AddWithValue("@FK_PhaseID", 1);
                            cmd.Parameters.AddWithValue("@SR", string.Empty);
                            cmd.Parameters.AddWithValue("@Year", string.Empty);
                            cmd.Parameters.AddWithValue("@FK_LandAcquisition", 1);
                            cmd.Parameters.AddWithValue("@FK_EnvironmentalDueDiligence", 1);
                            cmd.Parameters.AddWithValue("@REEFResults", string.Empty);
                            cmd.Parameters.AddWithValue("@FK_ComEdOwnership", string.Empty);
                            cmd.Parameters.AddWithValue("@Survey", string.Empty);
                            cmd.Parameters.AddWithValue("@SitePlanSubmitted", string.Empty);
                            cmd.Parameters.AddWithValue("@LocationProperty", string.Empty);
                            cmd.Parameters.AddWithValue("@FK_TransmissionROWPermitStatus", 1);
                            cmd.Parameters.AddWithValue("@GEOTech", string.Empty);
                            cmd.Parameters.AddWithValue("@CivilIFA", DBNull.Value);
                            cmd.Parameters.AddWithValue("@LandscapingPlan", string.Empty);
                            cmd.Parameters.AddWithValue("@Stormwater", string.Empty);
                            cmd.Parameters.AddWithValue("@CivilIFC", DBNull.Value);
                            cmd.Parameters.AddWithValue("@ElectricalIFA", DBNull.Value);
                            cmd.Parameters.AddWithValue("@ElectricalIFC", DBNull.Value);
                            cmd.Parameters.AddWithValue("@FK_CompletionStatus", 1);
                            cmd.Parameters.AddWithValue("@SubstationElectrical", string.Empty);
                            cmd.Parameters.AddWithValue("@SubstationCivil", string.Empty );
                            cmd.Parameters.AddWithValue("@SubstationSupportDesigner", string.Empty);
                            cmd.Parameters.AddWithValue("@SCADA", string.Empty);
                            cmd.Parameters.AddWithValue("@Relay", string.Empty);
                            cmd.Parameters.AddWithValue("@COMM", string.Empty);
                            cmd.Parameters.AddWithValue("@UCommFiberEng", string.Empty);
                            cmd.Parameters.AddWithValue("@UCommNetworkEng", string.Empty);
                            cmd.Parameters.AddWithValue("@REACTsEng", string.Empty);
                            cmd.Parameters.AddWithValue("@HutPlannedDeliveryDate", string.Empty);
                            cmd.Parameters.AddWithValue("@EnclosureLeadtime", string.Empty);
                            cmd.Parameters.AddWithValue("@Remarks", string.Empty);
                            cmd.Parameters.AddWithValue("@CreatedBy", string.Empty);
                            cmd.Parameters.AddWithValue("@UpdatedBy", string.Empty);
                            cmd.Connection = connection;
                            connection.Open();
                            if (id == 0)
                                cmd.Parameters.AddWithValue("@procId", 5);
                            else
                                cmd.Parameters.AddWithValue("@procId", 4);


                            using (SqlDataReader dataReader = cmd.ExecuteReader())
                            {
                                while (dataReader.Read())
                                {
                                    var onlyDate = "MM'/'dd'/'yyyy";
                                    var dateWithTime = "MM'/'dd'/'yyyy h:mm tt";
                                    var hut = new HUTSModel();
                                    hut.HutsID = (long)dataReader["HutsID"];
                                    hut.Substation = dataReader["Substation"].ToString();
                                    hut.FK_PDID = (int)dataReader["FK_PDID"];
                                    hut.Address = dataReader["Address"].ToString();

                                    if (dataReader["FK_RegionID"] != DBNull.Value)
                                        hut.FK_RegionID = (int)dataReader["FK_RegionID"];

                                    if (dataReader["FK_SizeID"] != DBNull.Value)
                                        hut.FK_SizeID = (int)dataReader["FK_SizeID"];

                                    if (dataReader["FK_EOCID"] != DBNull.Value)
                                        hut.FK_EOCID = (int)dataReader["FK_EOCID"];

                                    if (dataReader["FK_PhaseID"] != DBNull.Value)
                                        hut.FK_PhaseID = (int)dataReader["FK_PhaseID"];

                                    if (dataReader["FK_LandAcquisition"] != DBNull.Value)
                                        hut.FK_LandAcquisition = (int)dataReader["FK_LandAcquisition"];

                                    if (dataReader["FK_EnvironmentalDueDiligence"] != DBNull.Value)
                                        hut.FK_EnvironmentalDueDiligence = (int)dataReader["FK_EnvironmentalDueDiligence"];

                                    if (dataReader["FK_ComEdOwnership"] != DBNull.Value)
                                        hut.FK_ComEdOwnership = (int)dataReader["FK_ComEdOwnership"];

                                    if (dataReader["FK_TransmissionROWPermitStatus"] != DBNull.Value)
                                        hut.FK_TransmissionROWPermitStatus = (int)dataReader["FK_TransmissionROWPermitStatus"];

                                    if (dataReader["FK_CompletionStatus"] != DBNull.Value)
                                        hut.FK_CompletionStatus = (int)dataReader["FK_CompletionStatus"];

                                    if (dataReader["CivilIFA"] != DBNull.Value)
                                        hut.CivilIFA =Convert.ToDateTime(dataReader["CivilIFA"]);
                                    if (dataReader["CivilIFC"] != DBNull.Value)
                                        hut.CivilIFC = Convert.ToDateTime(dataReader["CivilIFC"]);
                                    if (dataReader["HutPlannedDeliveryDate"] != DBNull.Value)
                                        hut.HutPlannedDeliveryDate = Convert.ToDateTime(dataReader["HutPlannedDeliveryDate"]);
                                    if (dataReader["ElectricalIFA"] != DBNull.Value)
                                        hut.ElectricalIFA = Convert.ToDateTime(dataReader["ElectricalIFA"]);
                                    if (dataReader["ElectricalIFC"] != DBNull.Value)
                                        hut.ElectricalIFC = Convert.ToDateTime(dataReader["ElectricalIFC"]);

                                    if (dataReader["CivilIFA"] != DBNull.Value)
                                        hut.StrCivilIFA = Convert.ToDateTime(dataReader["CivilIFA"]).ToString(onlyDate);
                                    if (dataReader["CivilIFC"] != DBNull.Value)
                                        hut.StrCivilIFC = Convert.ToDateTime(dataReader["CivilIFC"]).ToString(onlyDate);
                                    if (dataReader["HutPlannedDeliveryDate"] != DBNull.Value)
                                        hut.StrHutPlannedDeliveryDate = Convert.ToDateTime(dataReader["HutPlannedDeliveryDate"]).ToString(onlyDate);
                                    if (dataReader["ElectricalIFA"] != DBNull.Value)
                                        hut.StrElectricalIFA = Convert.ToDateTime(dataReader["ElectricalIFA"]).ToString(onlyDate);
                                    if (dataReader["ElectricalIFC"] != DBNull.Value)
                                        hut.StrElectricalIFC = Convert.ToDateTime(dataReader["ElectricalIFC"]).ToString(onlyDate);

                                    hut.Survey = dataReader["Survey"].ToString();
                                    hut.Vendor = dataReader["Vendor"].ToString();
                                    hut.WorkOrder = dataReader["WorkOrder"].ToString();
                                    hut.ProjectID = dataReader["ProjectID"].ToString();
                                    hut.ProjectManager = dataReader["ProjectManager"].ToString();
                                    hut.SR = dataReader["SR"].ToString();
                                    hut.Year = dataReader["Year"].ToString();
                                    hut.REEFResults = dataReader["REEFResults"].ToString();
                                    hut.SitePlanSubmitted = dataReader["SitePlanSubmitted"].ToString();
                                    hut.LocationProperty = dataReader["LocationProperty"].ToString();
                                    hut.GEOTech = dataReader["GEOTech"].ToString();
                                    hut.LandscapingPlan = dataReader["LandscapingPlan"].ToString();
                                    hut.Stormwater = dataReader["Stormwater"].ToString();
                                    hut.SubstationElectrical = dataReader["SubstationElectrical"].ToString();
                                    hut.SubstationCivil = dataReader["SubstationCivil"].ToString();
                                    hut.SubstationSupportDesigner = dataReader["SubstationSupportDesigner"].ToString();
                                    hut.SCADA = dataReader["SCADA"].ToString();
                                    hut.Relay = dataReader["Relay"].ToString();
                                    hut.COMM = dataReader["COMM"].ToString();
                                    hut.UCommFiberEng = dataReader["UCommFiberEng"].ToString();
                                    hut.UCommNetworkEng = dataReader["UCommNetworkEng"].ToString();
                                    hut.REACTsEng = dataReader["REACTsEng"].ToString();
                                    hut.EnclosureLeadtime = dataReader["EnclosureLeadtime"].ToString();
                                    hut.Remarks = dataReader["Remarks"].ToString();
                                    hut.IsActive = Convert.ToBoolean(dataReader["IsActive"]);
                                    hut.CreatedBy = dataReader["CreatedBy"].ToString();
                                    hut.CreatedDate = Convert.ToDateTime(dataReader["CreatedDate"]).ToString(dateWithTime);
                                    hut.UpdatedBy = dataReader["UpdatedBy"].ToString();
                                    hut.UpdatedDate = Convert.ToDateTime(dataReader["UpdatedDate"]).ToString(dateWithTime);
                                    result.Add(hut);

                                }
                            }
                            connection.Close();

                            return result;
                        }
                    }

                }
                catch (Exception ex) { return new List<HUTSModel>(); }

            });
        }


        public async Task<HUTSModel> CreateHUTS(HUTSModel hUTSModel)
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
                            cmd.Parameters.AddWithValue("@procId", 1);
                            cmd.Parameters.AddWithValue("@HutsID", hUTSModel.HutsID);
                            cmd.Parameters.AddWithValue("@Substation", string.IsNullOrEmpty(hUTSModel.Substation) ? string.Empty : hUTSModel.Substation);
                            cmd.Parameters.AddWithValue("@FK_PDID", hUTSModel.FK_PDID);
                            cmd.Parameters.AddWithValue("@Address", string.IsNullOrEmpty(hUTSModel.Address) ? string.Empty : hUTSModel.Address);
                            cmd.Parameters.AddWithValue("@FK_RegionID",checkNull(hUTSModel.FK_RegionID));
                            cmd.Parameters.AddWithValue("@FK_SizeID",checkNull(hUTSModel.FK_SizeID));
                            cmd.Parameters.AddWithValue("@Vendor", string.IsNullOrEmpty(hUTSModel.Vendor) ? string.Empty : hUTSModel.Vendor);
                            cmd.Parameters.AddWithValue("@WorkOrder", string.IsNullOrEmpty(hUTSModel.WorkOrder) ? string.Empty : hUTSModel.WorkOrder);
                            cmd.Parameters.AddWithValue("@ProjectID", string.IsNullOrEmpty(hUTSModel.ProjectID) ? string.Empty : hUTSModel.ProjectID);
                            cmd.Parameters.AddWithValue("@ProjectManager", string.IsNullOrEmpty(hUTSModel.ProjectManager) ? string.Empty : hUTSModel.ProjectManager);
                            cmd.Parameters.AddWithValue("@FK_EOCID",checkNull(hUTSModel.FK_EOCID));
                            cmd.Parameters.AddWithValue("@FK_PhaseID",checkNull(hUTSModel.FK_PhaseID));
                            cmd.Parameters.AddWithValue("@SR", string.IsNullOrEmpty(hUTSModel.SR) ? string.Empty : hUTSModel.SR);
                            cmd.Parameters.AddWithValue("@Year", string.IsNullOrEmpty(hUTSModel.Year) ? string.Empty : hUTSModel.Year);
                            cmd.Parameters.AddWithValue("@FK_LandAcquisition",checkNull(hUTSModel.FK_LandAcquisition));
                            cmd.Parameters.AddWithValue("@FK_EnvironmentalDueDiligence",checkNull(hUTSModel.FK_EnvironmentalDueDiligence));
                            cmd.Parameters.AddWithValue("@FK_ComEdOwnership",checkNull(hUTSModel.FK_ComEdOwnership));
                            cmd.Parameters.AddWithValue("@REEFResults", string.IsNullOrEmpty(hUTSModel.REEFResults) ? string.Empty : hUTSModel.REEFResults);
                            cmd.Parameters.AddWithValue("@Survey", string.IsNullOrEmpty(hUTSModel.Survey) ? string.Empty : hUTSModel.Survey);
                            cmd.Parameters.AddWithValue("@SitePlanSubmitted", string.IsNullOrEmpty(hUTSModel.SitePlanSubmitted) ? string.Empty : hUTSModel.SitePlanSubmitted);
                            cmd.Parameters.AddWithValue("@LocationProperty", string.IsNullOrEmpty(hUTSModel.LocationProperty) ? string.Empty : hUTSModel.LocationProperty);
                            cmd.Parameters.AddWithValue("@FK_TransmissionROWPermitStatus",checkNull(hUTSModel.FK_TransmissionROWPermitStatus));
                            cmd.Parameters.AddWithValue("@GEOTech", string.IsNullOrEmpty(hUTSModel.GEOTech) ? string.Empty : hUTSModel.GEOTech);
                            cmd.Parameters.AddWithValue("@CivilIFA",checkNull(hUTSModel.CivilIFA));
                            cmd.Parameters.AddWithValue("@CivilIFC",checkNull(hUTSModel.CivilIFC));
                            cmd.Parameters.AddWithValue("@ElectricalIFA",checkNull(hUTSModel.ElectricalIFA));
                            cmd.Parameters.AddWithValue("@ElectricalIFC",checkNull(hUTSModel.ElectricalIFC));
                            cmd.Parameters.AddWithValue("@FK_CompletionStatus",checkNull(hUTSModel.FK_CompletionStatus));
                            cmd.Parameters.AddWithValue("@LandscapingPlan", string.IsNullOrEmpty(hUTSModel.LandscapingPlan) ? string.Empty : hUTSModel.LandscapingPlan);
                            cmd.Parameters.AddWithValue("@Stormwater", string.IsNullOrEmpty(hUTSModel.Stormwater) ? string.Empty : hUTSModel.Stormwater);
                            cmd.Parameters.AddWithValue("@SubstationElectrical", string.IsNullOrEmpty(hUTSModel.SubstationElectrical) ? string.Empty : hUTSModel.SubstationElectrical);
                            cmd.Parameters.AddWithValue("@SubstationCivil", string.IsNullOrEmpty(hUTSModel.SubstationCivil) ? string.Empty : hUTSModel.SubstationCivil);
                            cmd.Parameters.AddWithValue("@SubstationSupportDesigner", string.IsNullOrEmpty(hUTSModel.SubstationSupportDesigner) ? string.Empty : hUTSModel.SubstationSupportDesigner);
                            cmd.Parameters.AddWithValue("@SCADA", string.IsNullOrEmpty(hUTSModel.SCADA) ? string.Empty : hUTSModel.SCADA);
                            cmd.Parameters.AddWithValue("@Relay", string.IsNullOrEmpty(hUTSModel.Relay) ? string.Empty : hUTSModel.Relay);
                            cmd.Parameters.AddWithValue("@COMM", string.IsNullOrEmpty(hUTSModel.COMM) ? string.Empty : hUTSModel.COMM);
                            cmd.Parameters.AddWithValue("@UCommFiberEng", string.IsNullOrEmpty(hUTSModel.UCommFiberEng) ? string.Empty : hUTSModel.UCommFiberEng);
                            cmd.Parameters.AddWithValue("@UCommNetworkEng", string.IsNullOrEmpty(hUTSModel.UCommNetworkEng) ? string.Empty : hUTSModel.UCommNetworkEng);
                            cmd.Parameters.AddWithValue("@REACTsEng", string.IsNullOrEmpty(hUTSModel.REACTsEng) ? string.Empty : hUTSModel.REACTsEng);
                            cmd.Parameters.AddWithValue("@HutPlannedDeliveryDate", checkNull(hUTSModel.HutPlannedDeliveryDate));
                            cmd.Parameters.AddWithValue("@EnclosureLeadtime", string.IsNullOrEmpty(hUTSModel.EnclosureLeadtime) ? string.Empty : hUTSModel.EnclosureLeadtime);
                            cmd.Parameters.AddWithValue("@Remarks", string.IsNullOrEmpty(hUTSModel.Remarks) ? string.Empty : hUTSModel.Remarks);
                            cmd.Parameters.AddWithValue("@CreatedBy", hUTSModel.CreatedBy);
                            cmd.Parameters.AddWithValue("@UpdatedBy", hUTSModel.CreatedBy);
                            cmd.Connection = connection;
                            connection.Open();

                            hUTSModel.HutsID = (long)cmd.ExecuteScalar();

                            connection.Close();

                            return hUTSModel;
                        }
                    }

                }
                catch (Exception ex) { return new HUTSModel(); }

            });

        }

        public async Task<HUTSModel> UpdateHUTS(HUTSModel hUTSModel)
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
                            cmd.Parameters.AddWithValue("@HutsID", hUTSModel.HutsID);
                            cmd.Parameters.AddWithValue("@Substation", string.IsNullOrEmpty(hUTSModel.Substation) ? string.Empty : hUTSModel.Substation);
                            cmd.Parameters.AddWithValue("@FK_PDID", hUTSModel.FK_PDID);
                            cmd.Parameters.AddWithValue("@Address", string.IsNullOrEmpty(hUTSModel.Address) ? string.Empty : hUTSModel.Address);
                            cmd.Parameters.AddWithValue("@FK_RegionID", checkNull(hUTSModel.FK_RegionID));
                            cmd.Parameters.AddWithValue("@FK_SizeID", checkNull(hUTSModel.FK_SizeID));
                            cmd.Parameters.AddWithValue("@Vendor", string.IsNullOrEmpty(hUTSModel.Vendor) ? string.Empty : hUTSModel.Vendor);
                            cmd.Parameters.AddWithValue("@WorkOrder", string.IsNullOrEmpty(hUTSModel.WorkOrder) ? string.Empty : hUTSModel.WorkOrder);
                            cmd.Parameters.AddWithValue("@ProjectID", string.IsNullOrEmpty(hUTSModel.ProjectID) ? string.Empty : hUTSModel.ProjectID);
                            cmd.Parameters.AddWithValue("@ProjectManager", string.IsNullOrEmpty(hUTSModel.ProjectManager) ? string.Empty : hUTSModel.ProjectManager);
                            cmd.Parameters.AddWithValue("@FK_EOCID", checkNull(hUTSModel.FK_EOCID));
                            cmd.Parameters.AddWithValue("@FK_PhaseID", checkNull(hUTSModel.FK_PhaseID));
                            cmd.Parameters.AddWithValue("@SR", string.IsNullOrEmpty(hUTSModel.SR) ? string.Empty : hUTSModel.SR);
                            cmd.Parameters.AddWithValue("@Year", string.IsNullOrEmpty(hUTSModel.Year) ? string.Empty : hUTSModel.Year);
                            cmd.Parameters.AddWithValue("@FK_LandAcquisition", checkNull(hUTSModel.FK_LandAcquisition));
                            cmd.Parameters.AddWithValue("@FK_EnvironmentalDueDiligence", checkNull(hUTSModel.FK_EnvironmentalDueDiligence));
                            cmd.Parameters.AddWithValue("@FK_ComEdOwnership", checkNull(hUTSModel.FK_ComEdOwnership));
                            cmd.Parameters.AddWithValue("@REEFResults", string.IsNullOrEmpty(hUTSModel.REEFResults) ? string.Empty : hUTSModel.REEFResults);
                            cmd.Parameters.AddWithValue("@Survey", string.IsNullOrEmpty(hUTSModel.Survey) ? string.Empty : hUTSModel.Survey);
                            cmd.Parameters.AddWithValue("@SitePlanSubmitted", string.IsNullOrEmpty(hUTSModel.SitePlanSubmitted) ? string.Empty : hUTSModel.SitePlanSubmitted);
                            cmd.Parameters.AddWithValue("@LocationProperty", string.IsNullOrEmpty(hUTSModel.LocationProperty) ? string.Empty : hUTSModel.LocationProperty);
                            cmd.Parameters.AddWithValue("@FK_TransmissionROWPermitStatus", checkNull(hUTSModel.FK_TransmissionROWPermitStatus));
                            cmd.Parameters.AddWithValue("@GEOTech", string.IsNullOrEmpty(hUTSModel.GEOTech) ? string.Empty : hUTSModel.GEOTech);
                            cmd.Parameters.AddWithValue("@CivilIFA", checkNull(hUTSModel.CivilIFA));
                            cmd.Parameters.AddWithValue("@CivilIFC", checkNull(hUTSModel.CivilIFC));
                            cmd.Parameters.AddWithValue("@ElectricalIFA", checkNull(hUTSModel.ElectricalIFA));
                            cmd.Parameters.AddWithValue("@ElectricalIFC", checkNull(hUTSModel.ElectricalIFC));
                            cmd.Parameters.AddWithValue("@FK_CompletionStatus", checkNull(hUTSModel.FK_CompletionStatus));
                            cmd.Parameters.AddWithValue("@LandscapingPlan", string.IsNullOrEmpty(hUTSModel.LandscapingPlan) ? string.Empty : hUTSModel.LandscapingPlan);
                            cmd.Parameters.AddWithValue("@Stormwater", string.IsNullOrEmpty(hUTSModel.Stormwater) ? string.Empty : hUTSModel.Stormwater);
                            cmd.Parameters.AddWithValue("@SubstationElectrical", string.IsNullOrEmpty(hUTSModel.SubstationElectrical) ? string.Empty : hUTSModel.SubstationElectrical);
                            cmd.Parameters.AddWithValue("@SubstationCivil", string.IsNullOrEmpty(hUTSModel.SubstationCivil) ? string.Empty : hUTSModel.SubstationCivil);
                            cmd.Parameters.AddWithValue("@SubstationSupportDesigner", string.IsNullOrEmpty(hUTSModel.SubstationSupportDesigner) ? string.Empty : hUTSModel.SubstationSupportDesigner);
                            cmd.Parameters.AddWithValue("@SCADA", string.IsNullOrEmpty(hUTSModel.SCADA) ? string.Empty : hUTSModel.SCADA);
                            cmd.Parameters.AddWithValue("@Relay", string.IsNullOrEmpty(hUTSModel.Relay) ? string.Empty : hUTSModel.Relay);
                            cmd.Parameters.AddWithValue("@COMM", string.IsNullOrEmpty(hUTSModel.COMM) ? string.Empty : hUTSModel.COMM);
                            cmd.Parameters.AddWithValue("@UCommFiberEng", string.IsNullOrEmpty(hUTSModel.UCommFiberEng) ? string.Empty : hUTSModel.UCommFiberEng);
                            cmd.Parameters.AddWithValue("@UCommNetworkEng", string.IsNullOrEmpty(hUTSModel.UCommNetworkEng) ? string.Empty : hUTSModel.UCommNetworkEng);
                            cmd.Parameters.AddWithValue("@REACTsEng", string.IsNullOrEmpty(hUTSModel.REACTsEng) ? string.Empty : hUTSModel.REACTsEng);
                            cmd.Parameters.AddWithValue("@HutPlannedDeliveryDate", checkNull(hUTSModel.HutPlannedDeliveryDate));
                            cmd.Parameters.AddWithValue("@EnclosureLeadtime", string.IsNullOrEmpty(hUTSModel.EnclosureLeadtime) ? string.Empty : hUTSModel.EnclosureLeadtime);
                            cmd.Parameters.AddWithValue("@Remarks", string.IsNullOrEmpty(hUTSModel.Remarks) ? string.Empty : hUTSModel.Remarks);
                            cmd.Parameters.AddWithValue("@CreatedBy", string.Empty);
                            cmd.Parameters.AddWithValue("@UpdatedBy", hUTSModel.UpdatedBy);
                            cmd.Connection = connection;
                            connection.Open();

                            var hut = new HUTSModel();
                            using (SqlDataReader dataReader = cmd.ExecuteReader())
                            {
                                while (dataReader.Read())
                                {
                                    
                                    hut.HutsID = (long)dataReader["HutsID"];
                                    hut.Substation = dataReader["Substation"].ToString();
                                    hut.FK_PDID = (int)dataReader["FK_PDID"];
                                    hut.Address = dataReader["Address"].ToString();

                                    if (dataReader["FK_RegionID"] != DBNull.Value)
                                        hut.FK_RegionID = (int)dataReader["FK_RegionID"];

                                    if (dataReader["FK_SizeID"] != DBNull.Value)
                                        hut.FK_SizeID = (int)dataReader["FK_SizeID"];

                                    if (dataReader["FK_EOCID"] != DBNull.Value)
                                        hut.FK_EOCID = (int)dataReader["FK_EOCID"];

                                    if (dataReader["FK_PhaseID"] != DBNull.Value)
                                        hut.FK_PhaseID = (int)dataReader["FK_PhaseID"];

                                    if (dataReader["FK_LandAcquisition"] != DBNull.Value)
                                        hut.FK_LandAcquisition = (int)dataReader["FK_LandAcquisition"];

                                    if (dataReader["FK_EnvironmentalDueDiligence"] != DBNull.Value)
                                        hut.FK_EnvironmentalDueDiligence = (int)dataReader["FK_EnvironmentalDueDiligence"];

                                    if (dataReader["FK_ComEdOwnership"] != DBNull.Value)
                                        hut.FK_ComEdOwnership = (int)dataReader["FK_ComEdOwnership"];

                                    if (dataReader["FK_TransmissionROWPermitStatus"] != DBNull.Value)
                                        hut.FK_TransmissionROWPermitStatus = (int)dataReader["FK_TransmissionROWPermitStatus"];

                                    if (dataReader["FK_CompletionStatus"] != DBNull.Value)
                                        hut.FK_CompletionStatus = (int)dataReader["FK_CompletionStatus"];

                                    hut.Survey = dataReader["Survey"].ToString();
                                    hut.Vendor = dataReader["Vendor"].ToString();
                                    hut.WorkOrder = dataReader["WorkOrder"].ToString();
                                    hut.ProjectID = dataReader["ProjectID"].ToString();
                                    hut.ProjectManager = dataReader["ProjectManager"].ToString();
                                    hut.SR = dataReader["SR"].ToString();
                                    hut.Year = dataReader["Year"].ToString();
                                    hut.REEFResults = dataReader["REEFResults"].ToString();
                                    hut.SitePlanSubmitted = dataReader["SitePlanSubmitted"].ToString();
                                    hut.LocationProperty = dataReader["LocationProperty"].ToString();
                                    hut.GEOTech = dataReader["GEOTech"].ToString();
                                    hut.LandscapingPlan = dataReader["LandscapingPlan"].ToString();
                                    hut.Stormwater = dataReader["Stormwater"].ToString();
                                    hut.SubstationElectrical = dataReader["SubstationElectrical"].ToString();
                                    hut.SubstationCivil = dataReader["SubstationCivil"].ToString();
                                    hut.SubstationSupportDesigner = dataReader["SubstationSupportDesigner"].ToString();
                                    hut.SCADA = dataReader["SCADA"].ToString();
                                    hut.Relay = dataReader["Relay"].ToString();
                                    hut.COMM = dataReader["COMM"].ToString();
                                    hut.UCommFiberEng = dataReader["UCommFiberEng"].ToString();
                                    hut.UCommNetworkEng = dataReader["UCommNetworkEng"].ToString();
                                    hut.REACTsEng = dataReader["REACTsEng"].ToString();
                                    hut.EnclosureLeadtime = dataReader["EnclosureLeadtime"].ToString();
                                    hut.Remarks = dataReader["Remarks"].ToString();
                                }
                            }


                            cmd.Parameters["@createdBy"].Value = hut.CreatedBy; 
                            if (string.IsNullOrEmpty(hUTSModel.Substation))
                                cmd.Parameters["@Substation"].Value = hut.Substation;

                            if (string.IsNullOrEmpty(hUTSModel.Address))
                                cmd.Parameters["@Address"].Value = hut.Address;

                            if (string.IsNullOrEmpty(hUTSModel.Vendor))
                                cmd.Parameters["@Vendor"].Value = hut.Vendor;

                            if (string.IsNullOrEmpty(hUTSModel.WorkOrder))
                                cmd.Parameters["@WorkOrder"].Value = hut.WorkOrder;

                            if (string.IsNullOrEmpty(hUTSModel.ProjectID))
                                cmd.Parameters["@ProjectID"].Value = hut.ProjectID;

                            if (string.IsNullOrEmpty(hUTSModel.ProjectManager))
                                cmd.Parameters["@ProjectManager"].Value = hut.ProjectManager;

                            if (string.IsNullOrEmpty(hUTSModel.SR))
                                cmd.Parameters["@SR"].Value = hut.SR;

                            if (string.IsNullOrEmpty(hUTSModel.Year))
                                cmd.Parameters["@Year"].Value = hut.Year;

                            if (string.IsNullOrEmpty(hUTSModel.REEFResults))
                                cmd.Parameters["@REEFResults"].Value = hut.REEFResults;

                            if (string.IsNullOrEmpty(hUTSModel.Survey))
                                cmd.Parameters["@Survey"].Value = hut.Survey;

                            if (string.IsNullOrEmpty(hUTSModel.SitePlanSubmitted))
                                cmd.Parameters["@SitePlanSubmitted"].Value = hut.SitePlanSubmitted;
                            
                            if (string.IsNullOrEmpty(hUTSModel.LocationProperty))
                                cmd.Parameters["@LocationProperty"].Value = hut.LocationProperty;

                            if (string.IsNullOrEmpty(hUTSModel.GEOTech))
                                cmd.Parameters["@GEOTech"].Value = hut.GEOTech;

                            if (string.IsNullOrEmpty(hUTSModel.LandscapingPlan))
                                cmd.Parameters["@LandscapingPlan"].Value = hut.LandscapingPlan;

                            if (string.IsNullOrEmpty(hUTSModel.Stormwater))
                                cmd.Parameters["@Stormwater"].Value = hut.Stormwater;

                            if (string.IsNullOrEmpty(hUTSModel.SubstationElectrical))
                                cmd.Parameters["@SubstationElectrical"].Value = hut.SubstationElectrical;

                            if (string.IsNullOrEmpty(hUTSModel.SubstationCivil))
                                cmd.Parameters["@SubstationCivil"].Value = hut.SubstationCivil;

                            if (string.IsNullOrEmpty(hUTSModel.SubstationSupportDesigner))
                                cmd.Parameters["@SubstationSupportDesigner"].Value = hut.SubstationSupportDesigner;

                            if (string.IsNullOrEmpty(hUTSModel.UCommFiberEng))
                                cmd.Parameters["@UCommFiberEng"].Value = hut.UCommFiberEng;

                            if (string.IsNullOrEmpty(hUTSModel.UCommNetworkEng))
                                cmd.Parameters["@UCommNetworkEng"].Value = hut.UCommNetworkEng;

                            if (string.IsNullOrEmpty(hUTSModel.REACTsEng))
                                cmd.Parameters["@REACTsEng"].Value = hut.REACTsEng;

                            if (string.IsNullOrEmpty(hUTSModel.EnclosureLeadtime))
                                cmd.Parameters["@EnclosureLeadtime"].Value = hut.EnclosureLeadtime;

                            if (string.IsNullOrEmpty(hUTSModel.Remarks))
                                cmd.Parameters["@Remarks"].Value = hut.Remarks;

                            if (string.IsNullOrEmpty(hUTSModel.FK_PDID.ToString()))
                                cmd.Parameters["@FK_PDID"].Value = hut.FK_PDID;
                            cmd.Parameters["@FK_EOCID"].Value =checkNullWithValue(hUTSModel.FK_EOCID,hut.FK_EOCID);
                            cmd.Parameters["@FK_RegionID"].Value = checkNullWithValue(hUTSModel.FK_RegionID,hut.FK_RegionID);
                            cmd.Parameters["@FK_SizeID"].Value =checkNullWithValue(hUTSModel.FK_SizeID,hut.FK_SizeID);
                            cmd.Parameters["@FK_PhaseID"].Value =checkNullWithValue(hUTSModel.FK_PhaseID,hut.FK_PhaseID);
                            cmd.Parameters["@FK_LandAcquisition"].Value =checkNullWithValue(hUTSModel.FK_LandAcquisition,hut.FK_LandAcquisition);
                            cmd.Parameters["@FK_EnvironmentalDueDiligence"].Value =checkNullWithValue(hUTSModel.FK_EnvironmentalDueDiligence,hut.FK_EnvironmentalDueDiligence);
                            cmd.Parameters["@FK_ComEdOwnership"].Value =checkNullWithValue(hUTSModel.FK_ComEdOwnership,hut.FK_ComEdOwnership);
                            cmd.Parameters["@FK_TransmissionROWPermitStatus"].Value =checkNullWithValue(hUTSModel.FK_TransmissionROWPermitStatus,hut.FK_TransmissionROWPermitStatus);
                            cmd.Parameters["@CivilIFA"].Value =checkNullWithValue(hUTSModel.CivilIFA, hut.CivilIFA);
                            cmd.Parameters["@CivilIFC"].Value =checkNullWithValue(hUTSModel.CivilIFC,hut.CivilIFC);
                            cmd.Parameters["@ElectricalIFA"].Value =checkNullWithValue(hUTSModel.ElectricalIFA,hut.ElectricalIFA);
                            cmd.Parameters["@ElectricalIFC"].Value =checkNullWithValue(hUTSModel.ElectricalIFC,hut.ElectricalIFC);
                            cmd.Parameters["@FK_CompletionStatus"].Value =checkNullWithValue(hUTSModel.FK_CompletionStatus,hut.FK_CompletionStatus);
                            cmd.Parameters["@HutPlannedDeliveryDate"].Value =checkNullWithValue(hUTSModel.HutPlannedDeliveryDate,hut.HutPlannedDeliveryDate);
                            cmd.Parameters["@procId"].Value = 2;
                            cmd.ExecuteNonQuery();
                            connection.Close();
                            return hUTSModel;
                        }
                    }
                }
                catch(Exception ex) { return new HUTSModel(); }
            });
        }

        public async Task<int> DeleteHUTS(int id)
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
                            cmd.Parameters.AddWithValue("@HutsID", id);
                            cmd.Parameters.AddWithValue("@Substation", string.Empty);
                            cmd.Parameters.AddWithValue("@FK_PDID", 1);
                            cmd.Parameters.AddWithValue("@Address", 1);
                            cmd.Parameters.AddWithValue("@FK_RegionID", 1);
                            cmd.Parameters.AddWithValue("@FK_SizeID", 1);
                            cmd.Parameters.AddWithValue("@Vendor", string.Empty);
                            cmd.Parameters.AddWithValue("@WorkOrder", string.Empty);
                            cmd.Parameters.AddWithValue("@ProjectID", string.Empty);
                            cmd.Parameters.AddWithValue("@ProjectManager", string.Empty);
                            cmd.Parameters.AddWithValue("@FK_EOCID", 1);
                            cmd.Parameters.AddWithValue("@FK_PhaseID", 1);
                            cmd.Parameters.AddWithValue("@SR", string.Empty);
                            cmd.Parameters.AddWithValue("@Year", string.Empty);
                            cmd.Parameters.AddWithValue("@FK_LandAcquisition", 1);
                            cmd.Parameters.AddWithValue("@FK_EnvironmentalDueDiligence", 1);
                            cmd.Parameters.AddWithValue("@REEFResults", string.Empty);
                            cmd.Parameters.AddWithValue("@FK_ComEdOwnership", string.Empty);
                            cmd.Parameters.AddWithValue("@Survey", string.Empty);
                            cmd.Parameters.AddWithValue("@SitePlanSubmitted", string.Empty);
                            cmd.Parameters.AddWithValue("@LocationProperty", string.Empty);
                            cmd.Parameters.AddWithValue("@FK_TransmissionROWPermitStatus", 1);
                            cmd.Parameters.AddWithValue("@GEOTech", string.Empty);
                            cmd.Parameters.AddWithValue("@CivilIFA", DBNull.Value);
                            cmd.Parameters.AddWithValue("@LandscapingPlan", string.Empty);
                            cmd.Parameters.AddWithValue("@Stormwater", string.Empty);
                            cmd.Parameters.AddWithValue("@CivilIFC", DBNull.Value);
                            cmd.Parameters.AddWithValue("@ElectricalIFA", DBNull.Value);
                            cmd.Parameters.AddWithValue("@ElectricalIFC", DBNull.Value);
                            cmd.Parameters.AddWithValue("@FK_CompletionStatus", 1);
                            cmd.Parameters.AddWithValue("@SubstationElectrical", string.Empty);
                            cmd.Parameters.AddWithValue("@SubstationCivil", string.Empty);
                            cmd.Parameters.AddWithValue("@SubstationSupportDesigner", string.Empty);
                            cmd.Parameters.AddWithValue("@SCADA", string.Empty);
                            cmd.Parameters.AddWithValue("@Relay", string.Empty);
                            cmd.Parameters.AddWithValue("@COMM", string.Empty);
                            cmd.Parameters.AddWithValue("@UCommFiberEng", string.Empty);
                            cmd.Parameters.AddWithValue("@UCommNetworkEng", string.Empty);
                            cmd.Parameters.AddWithValue("@REACTsEng", string.Empty);
                            cmd.Parameters.AddWithValue("@HutPlannedDeliveryDate", string.Empty);
                            cmd.Parameters.AddWithValue("@EnclosureLeadtime", string.Empty);
                            cmd.Parameters.AddWithValue("@Remarks", string.Empty);
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
