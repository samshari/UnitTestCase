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
    public class HutExCivilPhaseThreeRepository : IHutExCivilPhaseThreeRepository
    {
        private readonly string _connectionString;
        private readonly string _storedProcedure = "dbo.spHutExCivilPhaseThreeActions";


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

        public HutExCivilPhaseThreeRepository(IAppSettings appSettings)
        {
            _connectionString = appSettings.GetConnectionString();
        }

        public Task<List<HutExCivilPhaseThreeModel>> GetHutCivilPhaseThree(int id = 0)
        {
            return Task.Run(() =>
            {
                var result = new List<HutExCivilPhaseThreeModel>();
                try
                {
                    using(SqlConnection connection = new SqlConnection(this._connectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.CommandText = _storedProcedure;
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@HutExCivilPhase3ID", id);
                            cmd.Parameters.AddWithValue("@HutExecutionID", 0);
                            cmd.Parameters.AddWithValue("@CivilAward",string.Empty);
                            cmd.Parameters.AddWithValue("@EnvRFP",string.Empty);
                            cmd.Parameters.AddWithValue("@Survey",string.Empty);
                            cmd.Parameters.AddWithValue("@IFC_T7", DBNull.Value);
                            cmd.Parameters.AddWithValue("@FoundationPoured_T5",DBNull.Value );
                            cmd.Parameters.AddWithValue("@GroundingConduitInstallPedBoxes_T4",DBNull.Value);
                            cmd.Parameters.AddWithValue("@ComEdContractingLNL",string.Empty );
                            cmd.Parameters.AddWithValue("@FoundationReadyforHutOffload_T1",DBNull.Value );
                            cmd.Parameters.AddWithValue("@HutOffload",DBNull.Value );
                            cmd.Parameters.AddWithValue("@CivilComplete_T0",DBNull.Value );
                            cmd.Parameters.AddWithValue("@Fenceinstall",DBNull.Value );
                            cmd.Parameters.AddWithValue("@Construction_Notes", string.Empty);
                            cmd.Parameters.AddWithValue("@GroundingTestingCompleted", string.Empty);
                            cmd.Parameters.AddWithValue("@OutageRequiredforDelivery", string.Empty);
                            cmd.Parameters.AddWithValue("@CreatedBy", string.Empty);
                            cmd.Parameters.AddWithValue("@UpdatedBy", string.Empty);
                            cmd.Connection = connection;

                            if (id == 0)
                                cmd.Parameters.AddWithValue("@procId", 4);
                            else
                                cmd.Parameters.AddWithValue("@procId", 5);

                            connection.Open();
                            using(SqlDataReader dataReader = cmd.ExecuteReader())
                            {
                                while (dataReader.Read())
                                {

                                    var onlyDate = "MM'/'dd'/'yyyy";
                                    var dateWithTime = "MM'/'dd'/'yyyy h:mm tt";
                                    var civilphasethree = new HutExCivilPhaseThreeModel();
                                    civilphasethree.HutExCivilPhase3ID = (long)dataReader["HutExCivilPhase3ID"];
                                    civilphasethree.HutExecutionID = (long)dataReader["HutExecutionID"];
                                    civilphasethree.CivilAward = dataReader["CivilAward"].ToString();
                                    civilphasethree.EnvRFP = dataReader["EnvRFP"].ToString();
                                    civilphasethree.Survey = dataReader["Survey"].ToString();
                                    civilphasethree.ComEdContractingLNL = dataReader["ComEdContractingLNL"].ToString();
                                    civilphasethree.Construction_Notes = dataReader["Construction_Notes"].ToString();
                                    civilphasethree.GroundingTestingCompleted = dataReader["GroundingTestingCompleted"].ToString();
                                    civilphasethree.OutageRequiredforDelivery = dataReader["OutageRequiredforDelivery"].ToString();
                                    if (dataReader["IFC_T7"] != DBNull.Value)
                                        civilphasethree.IFC_T7 = Convert.ToDateTime(dataReader["IFC_T7"]);
                                    if (dataReader["FoundationPoured_T5"] != DBNull.Value)
                                        civilphasethree.FoundationPoured_T5 = Convert.ToDateTime(dataReader["FoundationPoured_T5"]);
                                    if (dataReader["GroundingConduitInstallPedBoxes_T4"] != DBNull.Value)
                                        civilphasethree.GroundingConduitInstallPedBoxes_T4 = Convert.ToDateTime(dataReader["GroundingConduitInstallPedBoxes_T4"]);
                                    if (dataReader["FoundationReadyforHutOffload_T1"] != DBNull.Value)
                                        civilphasethree.FoundationReadyforHutOffload_T1 = Convert.ToDateTime(dataReader["FoundationReadyforHutOffload_T1"]);
                                    if (dataReader["HutOffload"] != DBNull.Value)
                                        civilphasethree.HutOffload = Convert.ToDateTime(dataReader["HutOffload"]);
                                    if (dataReader["CivilComplete_T0"] != DBNull.Value)
                                        civilphasethree.CivilComplete_T0 = Convert.ToDateTime(dataReader["CivilComplete_T0"]);
                                    if (dataReader["Fenceinstall"] != DBNull.Value)
                                        civilphasethree.Fenceinstall = Convert.ToDateTime(dataReader["Fenceinstall"]);

                                    if (dataReader["IFC_T7"] != DBNull.Value)
                                        civilphasethree.StrIFC_T7 = Convert.ToDateTime(dataReader["IFC_T7"]).ToString(onlyDate);
                                    if (dataReader["FoundationPoured_T5"] != DBNull.Value)
                                        civilphasethree.StrFoundationPoured_T5 = Convert.ToDateTime(dataReader["FoundationPoured_T5"]).ToString(onlyDate);
                                    if (dataReader["GroundingConduitInstallPedBoxes_T4"] != DBNull.Value)
                                        civilphasethree.StrGroundingConduitInstallPedBoxes_T4 = Convert.ToDateTime(dataReader["GroundingConduitInstallPedBoxes_T4"]).ToString(onlyDate);
                                    if (dataReader["FoundationReadyforHutOffload_T1"] != DBNull.Value)
                                        civilphasethree.StrFoundationReadyforHutOffload_T1 = Convert.ToDateTime(dataReader["FoundationReadyforHutOffload_T1"]).ToString(onlyDate);
                                    if (dataReader["HutOffload"] != DBNull.Value)
                                        civilphasethree.StrHutOffload = Convert.ToDateTime(dataReader["HutOffload"]).ToString(onlyDate);
                                    if (dataReader["CivilComplete_T0"] != DBNull.Value)
                                        civilphasethree.StrCivilComplete_T0 = Convert.ToDateTime(dataReader["CivilComplete_T0"]).ToString(onlyDate);
                                    if (dataReader["Fenceinstall"] != DBNull.Value)
                                        civilphasethree.StrFenceinstall = Convert.ToDateTime(dataReader["Fenceinstall"]).ToString(onlyDate);

                                    civilphasethree.IsActive = Convert.ToBoolean(dataReader["IsActive"]);
                                    civilphasethree.CreatedBy = dataReader["CreateBy"].ToString();
                                    civilphasethree.CreatedDate = Convert.ToDateTime(dataReader["CreatedDate"]).ToString(dateWithTime);
                                    civilphasethree.UpdatedBy = dataReader["UpdatedBy"].ToString();
                                    civilphasethree.UpdatedDate = Convert.ToDateTime(dataReader["UpdatedDate"]).ToString(dateWithTime);
                                    result.Add(civilphasethree);
                                }
                            }
                            connection.Close();
                            return result;
                        }
                    }
                }
                catch(Exception ex) { return new List<HutExCivilPhaseThreeModel>(); }
            });
        }

        public Task<HutExCivilPhaseThreeModel> CreateCivilPhaseThree(HutExCivilPhaseThreeModel hutExCivilPhaseThreeModel)
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
                            cmd.Parameters.AddWithValue("@HutExCivilPhase3ID", hutExCivilPhaseThreeModel.HutExCivilPhase3ID);
                            cmd.Parameters.AddWithValue("@HutExecutionID", hutExCivilPhaseThreeModel.HutExecutionID);
                            cmd.Parameters.AddWithValue("@CivilAward", string.IsNullOrEmpty(hutExCivilPhaseThreeModel.CivilAward) ? string.Empty:hutExCivilPhaseThreeModel.CivilAward) ;
                            cmd.Parameters.AddWithValue("@EnvRFP", string.IsNullOrEmpty(hutExCivilPhaseThreeModel.EnvRFP)?string.Empty:hutExCivilPhaseThreeModel.EnvRFP);
                            cmd.Parameters.AddWithValue("@Survey", string.IsNullOrEmpty(hutExCivilPhaseThreeModel.Survey)?string.Empty:hutExCivilPhaseThreeModel.Survey);
                            cmd.Parameters.AddWithValue("@IFC_T7", checkNull(hutExCivilPhaseThreeModel.IFC_T7));
                            cmd.Parameters.AddWithValue("@FoundationPoured_T5", checkNull(hutExCivilPhaseThreeModel.FoundationPoured_T5));
                            cmd.Parameters.AddWithValue("@GroundingConduitInstallPedBoxes_T4", checkNull(hutExCivilPhaseThreeModel.GroundingConduitInstallPedBoxes_T4));
                            cmd.Parameters.AddWithValue("@ComEdContractingLNL", string.IsNullOrEmpty(hutExCivilPhaseThreeModel.ComEdContractingLNL)?string.Empty:hutExCivilPhaseThreeModel.ComEdContractingLNL);
                            cmd.Parameters.AddWithValue("@FoundationReadyforHutOffload_T1", checkNull(hutExCivilPhaseThreeModel.FoundationReadyforHutOffload_T1));
                            cmd.Parameters.AddWithValue("@HutOffload", checkNull(hutExCivilPhaseThreeModel.HutOffload));
                            cmd.Parameters.AddWithValue("@CivilComplete_T0", checkNull(hutExCivilPhaseThreeModel.CivilComplete_T0));
                            cmd.Parameters.AddWithValue("@Fenceinstall", checkNull(hutExCivilPhaseThreeModel.Fenceinstall));
                            cmd.Parameters.AddWithValue("@Construction_Notes", string.IsNullOrEmpty(hutExCivilPhaseThreeModel.Construction_Notes)?string.Empty:hutExCivilPhaseThreeModel.Construction_Notes);
                            cmd.Parameters.AddWithValue("@GroundingTestingCompleted", string.IsNullOrEmpty(hutExCivilPhaseThreeModel.GroundingTestingCompleted) ? string.Empty : hutExCivilPhaseThreeModel.GroundingTestingCompleted);
                            cmd.Parameters.AddWithValue("@OutageRequiredforDelivery", string.IsNullOrEmpty(hutExCivilPhaseThreeModel.OutageRequiredforDelivery) ? string.Empty : hutExCivilPhaseThreeModel.OutageRequiredforDelivery);
                            cmd.Parameters.AddWithValue("@CreatedBy", hutExCivilPhaseThreeModel.CreatedBy);
                            cmd.Parameters.AddWithValue("@UpdatedBy", hutExCivilPhaseThreeModel.CreatedBy);
                            cmd.Connection = connection;
                            connection.Open();
                            hutExCivilPhaseThreeModel.HutExCivilPhase3ID=(long)cmd.ExecuteScalar();
                            connection.Close();
                            return hutExCivilPhaseThreeModel;
                        }
                    }
                }
                catch (Exception ex) { return new HutExCivilPhaseThreeModel(); }
            });

        }

        public Task<HutExCivilPhaseThreeModel> UpdateCivilPhaseThree(HutExCivilPhaseThreeModel hutExCivilPhaseThreeModel)
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
                            cmd.Parameters.AddWithValue("@procId", 5);
                            cmd.Parameters.AddWithValue("@HutExCivilPhase3ID", hutExCivilPhaseThreeModel.HutExCivilPhase3ID);
                            cmd.Parameters.AddWithValue("@HutExecutionID", hutExCivilPhaseThreeModel.HutExecutionID);
                            cmd.Parameters.AddWithValue("@CivilAward", string.IsNullOrEmpty(hutExCivilPhaseThreeModel.CivilAward) ? string.Empty : hutExCivilPhaseThreeModel.CivilAward);
                            cmd.Parameters.AddWithValue("@EnvRFP", string.IsNullOrEmpty(hutExCivilPhaseThreeModel.EnvRFP) ? string.Empty : hutExCivilPhaseThreeModel.EnvRFP);
                            cmd.Parameters.AddWithValue("@Survey", string.IsNullOrEmpty(hutExCivilPhaseThreeModel.Survey) ? string.Empty : hutExCivilPhaseThreeModel.Survey);
                            cmd.Parameters.AddWithValue("@IFC_T7", checkNull(hutExCivilPhaseThreeModel.IFC_T7));
                            cmd.Parameters.AddWithValue("@FoundationPoured_T5", checkNull(hutExCivilPhaseThreeModel.FoundationPoured_T5));
                            cmd.Parameters.AddWithValue("@GroundingConduitInstallPedBoxes_T4", checkNull(hutExCivilPhaseThreeModel.GroundingConduitInstallPedBoxes_T4));
                            cmd.Parameters.AddWithValue("@ComEdContractingLNL", string.IsNullOrEmpty(hutExCivilPhaseThreeModel.ComEdContractingLNL) ? string.Empty : hutExCivilPhaseThreeModel.ComEdContractingLNL);
                            cmd.Parameters.AddWithValue("@FoundationReadyforHutOffload_T1", checkNull(hutExCivilPhaseThreeModel.FoundationReadyforHutOffload_T1));
                            cmd.Parameters.AddWithValue("@HutOffload", checkNull(hutExCivilPhaseThreeModel.HutOffload));
                            cmd.Parameters.AddWithValue("@CivilComplete_T0", checkNull(hutExCivilPhaseThreeModel.CivilComplete_T0));
                            cmd.Parameters.AddWithValue("@Fenceinstall", checkNull(hutExCivilPhaseThreeModel.Fenceinstall));
                            cmd.Parameters.AddWithValue("@Construction_Notes", string.IsNullOrEmpty(hutExCivilPhaseThreeModel.Construction_Notes) ? string.Empty : hutExCivilPhaseThreeModel.Construction_Notes);
                            cmd.Parameters.AddWithValue("@GroundingTestingCompleted", string.IsNullOrEmpty(hutExCivilPhaseThreeModel.GroundingTestingCompleted) ? string.Empty : hutExCivilPhaseThreeModel.GroundingTestingCompleted);
                            cmd.Parameters.AddWithValue("@OutageRequiredforDelivery", string.IsNullOrEmpty(hutExCivilPhaseThreeModel.OutageRequiredforDelivery) ? string.Empty : hutExCivilPhaseThreeModel.OutageRequiredforDelivery);
                            cmd.Parameters.AddWithValue("@CreatedBy", string.Empty);
                            cmd.Parameters.AddWithValue("@UpdatedBy", hutExCivilPhaseThreeModel.UpdatedBy);
                            cmd.Connection = connection;
                            connection.Open();
                            var civilphasethree = new HutExCivilPhaseThreeModel();
                            using (SqlDataReader dataReader = cmd.ExecuteReader())
                            {
                                while (dataReader.Read())
                                {
                                    
                                    civilphasethree.HutExCivilPhase3ID = (long)dataReader["HutExCivilPhase3ID"];
                                    civilphasethree.HutExecutionID = (long)dataReader["HutExecutionID"];
                                    civilphasethree.CivilAward = dataReader["CivilAward"].ToString();
                                    civilphasethree.EnvRFP = dataReader["EnvRFP"].ToString();
                                    civilphasethree.Survey = dataReader["Survey"].ToString();
                                    civilphasethree.ComEdContractingLNL = dataReader["ComEdContractingLNL"].ToString();
                                    civilphasethree.Construction_Notes = dataReader["Construction_Notes"].ToString();
                                    civilphasethree.GroundingTestingCompleted = dataReader["GroundingTestingCompleted"].ToString();
                                    civilphasethree.OutageRequiredforDelivery = dataReader["OutageRequiredforDelivery"].ToString();
                                    if (dataReader["IFC_T7"] != DBNull.Value)
                                        civilphasethree.IFC_T7 = Convert.ToDateTime(dataReader["IFC_T7"]);
                                    if (dataReader["FoundationPoured_T5"] != DBNull.Value)
                                        civilphasethree.FoundationPoured_T5 = Convert.ToDateTime(dataReader["FoundationPoured_T5"]);
                                    if (dataReader["GroundingConduitInstallPedBoxes_T4"] != DBNull.Value)
                                        civilphasethree.GroundingConduitInstallPedBoxes_T4 = Convert.ToDateTime(dataReader["GroundingConduitInstallPedBoxes_T4"]);
                                    if (dataReader["FoundationReadyforHutOffload_T1"] != DBNull.Value)
                                        civilphasethree.FoundationReadyforHutOffload_T1 = Convert.ToDateTime(dataReader["FoundationReadyforHutOffload_T1"]);
                                    if (dataReader["HutOffload"] != DBNull.Value)
                                        civilphasethree.HutOffload = Convert.ToDateTime(dataReader["HutOffload"]);
                                    if (dataReader["CivilComplete_T0"] != DBNull.Value)
                                        civilphasethree.CivilComplete_T0 = Convert.ToDateTime(dataReader["CivilComplete_T0"]);
                                    if (dataReader["Fenceinstall"] != DBNull.Value)
                                        civilphasethree.Fenceinstall = Convert.ToDateTime(dataReader["Fenceinstall"]);
                                }
                            }

                            if (string.IsNullOrEmpty(hutExCivilPhaseThreeModel.CivilAward))
                                cmd.Parameters["@CivilAward"].Value = civilphasethree.CivilAward;
                            if (string.IsNullOrEmpty(hutExCivilPhaseThreeModel.EnvRFP))
                                cmd.Parameters["@EnvRFP"].Value = civilphasethree.EnvRFP;
                            if (string.IsNullOrEmpty(hutExCivilPhaseThreeModel.Survey))
                                cmd.Parameters["@Survey"].Value = civilphasethree.Survey;
                            if (string.IsNullOrEmpty(hutExCivilPhaseThreeModel.ComEdContractingLNL))
                                cmd.Parameters["@ComEdContractingLNL"].Value = civilphasethree.ComEdContractingLNL;
                            if (string.IsNullOrEmpty(hutExCivilPhaseThreeModel.Construction_Notes))
                                cmd.Parameters["@Construction_Notes"].Value = civilphasethree.Construction_Notes;
                            if (string.IsNullOrEmpty(hutExCivilPhaseThreeModel.GroundingTestingCompleted))
                                cmd.Parameters["@GroundingTestingCompleted"].Value = civilphasethree.GroundingTestingCompleted;
                            if (string.IsNullOrEmpty(hutExCivilPhaseThreeModel.OutageRequiredforDelivery))
                                cmd.Parameters["@OutageRequiredforDelivery"].Value = civilphasethree.OutageRequiredforDelivery;

                            cmd.Parameters["@IFC_T7"].Value = checkNullWithValue(hutExCivilPhaseThreeModel.IFC_T7, civilphasethree.IFC_T7);
                            cmd.Parameters["@FoundationPoured_T5"].Value = checkNullWithValue(hutExCivilPhaseThreeModel.FoundationPoured_T5, civilphasethree.FoundationPoured_T5);
                            cmd.Parameters["@GroundingConduitInstallPedBoxes_T4"].Value = checkNullWithValue(hutExCivilPhaseThreeModel.GroundingConduitInstallPedBoxes_T4, civilphasethree.GroundingConduitInstallPedBoxes_T4);
                            cmd.Parameters["@FoundationReadyforHutOffload_T1"].Value = checkNullWithValue(hutExCivilPhaseThreeModel.FoundationReadyforHutOffload_T1, civilphasethree.FoundationReadyforHutOffload_T1);
                            cmd.Parameters["@HutOffload"].Value = checkNullWithValue(hutExCivilPhaseThreeModel.HutOffload, civilphasethree.HutOffload);
                            cmd.Parameters["@CivilComplete_T0"].Value = checkNullWithValue(hutExCivilPhaseThreeModel.CivilComplete_T0, civilphasethree.CivilComplete_T0);
                            cmd.Parameters["@Fenceinstall"].Value = checkNullWithValue(hutExCivilPhaseThreeModel.Fenceinstall, civilphasethree.Fenceinstall);
                            cmd.Parameters["@procId"].Value = 2;
                            cmd.ExecuteNonQuery();
                            connection.Close();
                            return hutExCivilPhaseThreeModel;
                        }
                    }
                }
                catch (Exception ex) { return new HutExCivilPhaseThreeModel(); }
            });
        }

        public Task<int> DeleteCivilPhaseThree(int id)
        {
            return Task.Run(() =>
            {
                var result = new List<HutExCivilPhaseThreeModel>();
                try
                {
                    using (SqlConnection connection = new SqlConnection(this._connectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.CommandText = _storedProcedure;
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@procId", 3);
                            cmd.Parameters.AddWithValue("@HutExCivilPhase3ID", id);
                            cmd.Parameters.AddWithValue("@HutExecutionID", 0);
                            cmd.Parameters.AddWithValue("@CivilAward", string.Empty);
                            cmd.Parameters.AddWithValue("@EnvRFP", string.Empty);
                            cmd.Parameters.AddWithValue("@Survey", string.Empty);
                            cmd.Parameters.AddWithValue("@IFC_T7", DBNull.Value);
                            cmd.Parameters.AddWithValue("@FoundationPoured_T5", DBNull.Value);
                            cmd.Parameters.AddWithValue("@GroundingConduitInstallPedBoxes_T4", DBNull.Value);
                            cmd.Parameters.AddWithValue("@ComEdContractingLNL", string.Empty);
                            cmd.Parameters.AddWithValue("@FoundationReadyforHutOffload_T1", DBNull.Value);
                            cmd.Parameters.AddWithValue("@HutOffload", DBNull.Value);
                            cmd.Parameters.AddWithValue("@CivilComplete_T0", DBNull.Value);
                            cmd.Parameters.AddWithValue("@Fenceinstall", DBNull.Value);
                            cmd.Parameters.AddWithValue("@Construction_Notes", string.Empty);
                            cmd.Parameters.AddWithValue("@GroundingTestingCompleted", string.Empty);
                            cmd.Parameters.AddWithValue("@OutageRequiredforDelivery", string.Empty);
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
