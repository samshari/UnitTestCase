using Exelon.Domain.Abstractions;
using Exelon.Domain.Common;
using Exelon.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Exelon.Infrastructure.Repositories
{
    public class HutExPowPhaseThreeRepository : IHutExPowPhaseThreeRepository
    {
        private readonly string _connectionString;
        private readonly string _storedProcedure= "dbo.spHutExAuxPowPhase3Actions";


        private object checkNull(object value)
        {
            if (value == null)
                return DBNull.Value;

            return value;
        }

        private object checkNullWithValue(object Value,object changeValue)
        {
            if (Value == null && changeValue == null)
                return DBNull.Value;
            else if (Value == null)
                return changeValue;
            return Value;

        }

        public HutExPowPhaseThreeRepository(IAppSettings appSettings)
        {
            _connectionString = appSettings.GetConnectionString();
        }

        public Task<List<HutExPowPhaseThreeModel>> GetHutExPowPhaseThree(int id = 0)
        {
            return Task.Run(() =>
            {

                var result = new List<HutExPowPhaseThreeModel>();

                try
                {
                    using (SqlConnection connection = new SqlConnection(this._connectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.CommandText = _storedProcedure;
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@HutExAuxPowerPhase3ID", id);
                            cmd.Parameters.AddWithValue("@HutExecutionID", 0);
                            cmd.Parameters.AddWithValue("@AuxPowerCivilStart", DBNull.Value);
                            cmd.Parameters.AddWithValue("@AuxPowerCivilComplete", DBNull.Value);
                            cmd.Parameters.AddWithValue("@AuxPowerElectricalStart", DBNull.Value);
                            cmd.Parameters.AddWithValue("@AuxPowerElectricalComplete", DBNull.Value);
                            cmd.Parameters.AddWithValue("@AuxPowerTestedByTG",string.Empty);
                            cmd.Parameters.AddWithValue("@OutageCutoverDate", DBNull.Value);
                            cmd.Parameters.AddWithValue("@DistOpsNotifiedOfWork", string.Empty);
                            cmd.Parameters.AddWithValue("@LNLSubmitted", string.Empty);
                            cmd.Parameters.AddWithValue("@ComEdContracting", string.Empty);
                            cmd.Parameters.AddWithValue("@FiberHutToControlBuildingStart", DBNull.Value);
                            cmd.Parameters.AddWithValue("@FiberHutToControlBuildingFinish", DBNull.Value);
                            cmd.Parameters.AddWithValue("@CreatedBy", string.Empty);
                            cmd.Parameters.AddWithValue("@UpdatedBy", string.Empty);
                            cmd.Connection = connection;
                            connection.Open();

                            if(id == 0)
                                cmd.Parameters.AddWithValue("@procId", 4);
                            else
                                cmd.Parameters.AddWithValue("@procId", 5);

                            using (SqlDataReader dataReader = cmd.ExecuteReader())
                            {
                                while (dataReader.Read())
                                {

                                    var onlyDate = "MM'/'dd'/'yyyy";
                                    var dateWithTime = "MM'/'dd'/'yyyy h:mm tt";
                                    var hutphase = new HutExPowPhaseThreeModel();
                                    hutphase.HutExAuxPowerPhase3ID = (long)dataReader["HutExAuxPowerPhase3ID"];
                                    hutphase.HutExecutionID = (long)dataReader["HutExecutionID"];
                                    if(dataReader["AuxPowerCivilStart"] != DBNull.Value)
                                        hutphase.AuxPowerCivilStart = Convert.ToDateTime(dataReader["AuxPowerCivilStart"]);
                                    if(dataReader["AuxPowerCivilComplete"] !=DBNull.Value)
                                        hutphase.AuxPowerCivilComplete = Convert.ToDateTime(dataReader["AuxPowerCivilComplete"]);
                                    if (dataReader["AuxPowerElectricalStart"] != DBNull.Value)
                                        hutphase.AuxPowerElectricalStart = Convert.ToDateTime(dataReader["AuxPowerElectricalStart"]);
                                    if (dataReader["AuxPowerElectricalComplete"] != DBNull.Value)
                                        hutphase.AuxPowerElectricalComplete = Convert.ToDateTime(dataReader["AuxPowerElectricalComplete"]);

                                    if (dataReader["AuxPowerCivilStart"] != DBNull.Value)
                                        hutphase.StrAuxPowerCivilStart = Convert.ToDateTime(dataReader["AuxPowerCivilStart"]).ToString(onlyDate);
                                    if (dataReader["AuxPowerCivilComplete"] != DBNull.Value)
                                        hutphase.StrAuxPowerCivilComplete = Convert.ToDateTime(dataReader["AuxPowerCivilComplete"]).ToString(onlyDate);
                                    if (dataReader["AuxPowerElectricalStart"] != DBNull.Value)
                                        hutphase.StrAuxPowerElectricalStart = Convert.ToDateTime(dataReader["AuxPowerElectricalStart"]).ToString(onlyDate);
                                    if (dataReader["AuxPowerElectricalComplete"] != DBNull.Value)
                                        hutphase.StrAuxPowerElectricalComplete = Convert.ToDateTime(dataReader["AuxPowerElectricalComplete"]).ToString(onlyDate);
                                    hutphase.AuxPowerTestedByTG = dataReader["AuxPowerTestedByTG"].ToString();
                                    if(dataReader["OutageCutoverDate"] !=DBNull.Value)
                                        hutphase.OutageCutoverDate = Convert.ToDateTime(dataReader["OutageCutoverDate"]);
                                    if (dataReader["OutageCutoverDate"] != DBNull.Value)
                                        hutphase.StrOutageCutoverDate = Convert.ToDateTime(dataReader["OutageCutoverDate"]).ToString(onlyDate);
                                    hutphase.DistOpsNotifiedOfWork = dataReader["DistOpsNotifiedOfWork"].ToString();
                                    hutphase.LNLSubmitted = dataReader["LNLSubmitted"].ToString();
                                    hutphase.ComEdContracting = dataReader["ComEdContracting"].ToString();
                                    if (dataReader["FiberHutToControlBuildingStart"] != DBNull.Value)
                                        hutphase.FiberHutToControlBuildingStart = Convert.ToDateTime(dataReader["FiberHutToControlBuildingStart"]);
                                    if (dataReader["FiberHutToControlBuildingFinish"] != DBNull.Value)
                                        hutphase.FiberHutToControlBuildingFinish = Convert.ToDateTime(dataReader["FiberHutToControlBuildingFinish"]);

                                    if (dataReader["FiberHutToControlBuildingStart"] != DBNull.Value)
                                        hutphase.StrFiberHutToControlBuildingStart = Convert.ToDateTime(dataReader["FiberHutToControlBuildingStart"]).ToString(onlyDate);
                                    if (dataReader["FiberHutToControlBuildingFinish"] != DBNull.Value)
                                        hutphase.StrFiberHutToControlBuildingFinish = Convert.ToDateTime(dataReader["FiberHutToControlBuildingFinish"]).ToString(onlyDate);
                                    hutphase.IsActive = Convert.ToBoolean(dataReader["IsActive"]);
                                    hutphase.CreatedBy = dataReader["CreatedBy"].ToString();
                                    hutphase.CreatedDate = Convert.ToDateTime(dataReader["CreatedDate"]).ToString(dateWithTime);
                                    hutphase.UpdatedBy = dataReader["UpdatedBy"].ToString();
                                    hutphase.UpdatedDate = Convert.ToDateTime(dataReader["UpdatedDate"]).ToString(dateWithTime);
                                    result.Add(hutphase);
                                }
                            }

                            connection.Close();


                        }
                    }
                    return result;
                }
                catch(Exception ex) { return new List<HutExPowPhaseThreeModel>(); }
            });
        }

        

        public Task<HutExPowPhaseThreeModel> CreateHutExPowPhaseThree(HutExPowPhaseThreeModel hutExPowPhaseThreeModel)
        {

            return Task.Run(() =>
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
                            cmd.Parameters.AddWithValue("@HutExAuxPowerPhase3ID", hutExPowPhaseThreeModel.HutExAuxPowerPhase3ID);
                            cmd.Parameters.AddWithValue("@HutExecutionID", hutExPowPhaseThreeModel.HutExecutionID);
                            cmd.Parameters.AddWithValue("@AuxPowerCivilStart", checkNull(hutExPowPhaseThreeModel.AuxPowerCivilStart));
                            cmd.Parameters.AddWithValue("@AuxPowerCivilComplete", checkNull(hutExPowPhaseThreeModel.AuxPowerCivilComplete));
                            cmd.Parameters.AddWithValue("@AuxPowerElectricalStart", checkNull(hutExPowPhaseThreeModel.AuxPowerElectricalStart));
                            cmd.Parameters.AddWithValue("@AuxPowerElectricalComplete", checkNull(hutExPowPhaseThreeModel.AuxPowerElectricalComplete));
                            cmd.Parameters.AddWithValue("@OutageCutoverDate", checkNull(hutExPowPhaseThreeModel.OutageCutoverDate));
                            cmd.Parameters.AddWithValue("@FiberHutToControlBuildingStart", checkNull(hutExPowPhaseThreeModel.FiberHutToControlBuildingStart));
                            cmd.Parameters.AddWithValue("@FiberHutToControlBuildingFinish", checkNull(hutExPowPhaseThreeModel.FiberHutToControlBuildingFinish));
                            cmd.Parameters.AddWithValue("@AuxPowerTestedByTG", string.IsNullOrEmpty(hutExPowPhaseThreeModel.AuxPowerTestedByTG)?string.Empty:hutExPowPhaseThreeModel.AuxPowerTestedByTG);
                            cmd.Parameters.AddWithValue("@DistOpsNotifiedOfWork", string.IsNullOrEmpty(hutExPowPhaseThreeModel.DistOpsNotifiedOfWork)?string.Empty:hutExPowPhaseThreeModel.DistOpsNotifiedOfWork);
                            cmd.Parameters.AddWithValue("@LNLSubmitted", string.IsNullOrEmpty(hutExPowPhaseThreeModel.LNLSubmitted)?string.Empty:hutExPowPhaseThreeModel.LNLSubmitted);
                            cmd.Parameters.AddWithValue("@ComEdContracting", string.IsNullOrEmpty(hutExPowPhaseThreeModel.ComEdContracting)?string.Empty:hutExPowPhaseThreeModel.ComEdContracting);
                            cmd.Parameters.AddWithValue("@CreatedBy", string.Empty);
                            cmd.Parameters.AddWithValue("@UpdatedBy", string.Empty);
                            cmd.Connection = connection;
                            connection.Open();
                            hutExPowPhaseThreeModel.HutExAuxPowerPhase3ID = (long)cmd.ExecuteScalar();
                            connection.Close();
                        }
                    }
                    return hutExPowPhaseThreeModel;
                }
                catch (Exception ex) { throw ex; }
            });

        }

        public Task<HutExPowPhaseThreeModel> UpdateHutExPowPhaseThree(HutExPowPhaseThreeModel hutExPowPhaseThreeModel)
        {
            return Task.Run(() =>
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
                            cmd.Parameters.AddWithValue("@HutExAuxPowerPhase3ID", hutExPowPhaseThreeModel.HutExAuxPowerPhase3ID);
                            cmd.Parameters.AddWithValue("@HutExecutionID", hutExPowPhaseThreeModel.HutExecutionID);
                            cmd.Parameters.AddWithValue("@AuxPowerCivilStart", checkNull(hutExPowPhaseThreeModel.AuxPowerCivilStart));
                            cmd.Parameters.AddWithValue("@AuxPowerCivilComplete", checkNull(hutExPowPhaseThreeModel.AuxPowerCivilComplete));
                            cmd.Parameters.AddWithValue("@AuxPowerElectricalStart", checkNull(hutExPowPhaseThreeModel.AuxPowerElectricalStart));
                            cmd.Parameters.AddWithValue("@AuxPowerElectricalComplete", checkNull(hutExPowPhaseThreeModel.AuxPowerElectricalComplete));
                            cmd.Parameters.AddWithValue("@OutageCutoverDate", checkNull(hutExPowPhaseThreeModel.OutageCutoverDate));
                            cmd.Parameters.AddWithValue("@FiberHutToControlBuildingStart", checkNull(hutExPowPhaseThreeModel.FiberHutToControlBuildingStart));
                            cmd.Parameters.AddWithValue("@FiberHutToControlBuildingFinish", checkNull(hutExPowPhaseThreeModel.FiberHutToControlBuildingFinish));
                            cmd.Parameters.AddWithValue("@AuxPowerTestedByTG", string.IsNullOrEmpty(hutExPowPhaseThreeModel.AuxPowerTestedByTG) ? string.Empty : hutExPowPhaseThreeModel.AuxPowerTestedByTG);
                            cmd.Parameters.AddWithValue("@DistOpsNotifiedOfWork", string.IsNullOrEmpty(hutExPowPhaseThreeModel.DistOpsNotifiedOfWork) ? string.Empty : hutExPowPhaseThreeModel.DistOpsNotifiedOfWork);
                            cmd.Parameters.AddWithValue("@LNLSubmitted", string.IsNullOrEmpty(hutExPowPhaseThreeModel.LNLSubmitted) ? string.Empty : hutExPowPhaseThreeModel.LNLSubmitted);
                            cmd.Parameters.AddWithValue("@ComEdContracting", string.IsNullOrEmpty(hutExPowPhaseThreeModel.ComEdContracting) ? string.Empty : hutExPowPhaseThreeModel.ComEdContracting);
                            cmd.Parameters.AddWithValue("@CreatedBy", string.Empty);
                            cmd.Parameters.AddWithValue("@UpdatedBy", string.Empty);
                            cmd.Connection = connection;
                            connection.Open();
                            cmd.ExecuteNonQuery();
                            connection.Close();
                            return hutExPowPhaseThreeModel;


                        }
                    }
                }
                catch (Exception ex) { throw ex; }
            });
        }

        public Task<int> DeleteHutExPowPhaseThree(int id)
        {
            return Task.Run(() =>
            {

                var result = new List<HutExPowPhaseThreeModel>();

                try
                {
                    using (SqlConnection connection = new SqlConnection(this._connectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.CommandText = _storedProcedure;
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@procId", 3);
                            cmd.Parameters.AddWithValue("@HutExAuxPowerPhase3ID", id);
                            cmd.Parameters.AddWithValue("@HutExecutionID", 0);
                            cmd.Parameters.AddWithValue("@AuxPowerCivilStart", DBNull.Value);
                            cmd.Parameters.AddWithValue("@AuxPowerCivilComplete", DBNull.Value);
                            cmd.Parameters.AddWithValue("@AuxPowerElectricalStart", DBNull.Value);
                            cmd.Parameters.AddWithValue("@AuxPowerElectricalComplete", DBNull.Value);
                            cmd.Parameters.AddWithValue("@AuxPowerTestedByTG", string.Empty);
                            cmd.Parameters.AddWithValue("@OutageCutoverDate", DBNull.Value);
                            cmd.Parameters.AddWithValue("@DistOpsNotifiedOfWork", string.Empty);
                            cmd.Parameters.AddWithValue("@LNLSubmitted", string.Empty);
                            cmd.Parameters.AddWithValue("@ComEdContracting", string.Empty);
                            cmd.Parameters.AddWithValue("@FiberHutToControlBuildingStart", DBNull.Value);
                            cmd.Parameters.AddWithValue("@FiberHutToControlBuildingFinish", DBNull.Value);
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
