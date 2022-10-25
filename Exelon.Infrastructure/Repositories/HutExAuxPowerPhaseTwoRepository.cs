using Exelon.Domain.Abstractions;
using Exelon.Domain.Common;
using Exelon.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Exelon.Infrastructure.Repositories
{
    public class HutExAuxPowerPhaseTwoRepository : IHutExAuxPowerPhaseTwoRepository
    {
        private readonly string _connectionString;
        private readonly string _storedProcedure = "dbo.spHutExAuxPowPhase2Actions";


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

        public HutExAuxPowerPhaseTwoRepository(IAppSettings appSettings)
        {
            _connectionString = appSettings.GetConnectionString();
        }

        public Task<List<HutExAuxPowerPhaseTwoModel>> GetHutPhaseTwo(int id = 0)
        {
            return Task.Run(() =>
            {
                var result = new List<HutExAuxPowerPhaseTwoModel>();
                try
                {
                    using (SqlConnection connection = new SqlConnection(this._connectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.CommandText = _storedProcedure;
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@AuxPowerPhase2ID", id);
                            cmd.Parameters.AddWithValue("@HutExecutionID", 0);
                            cmd.Parameters.AddWithValue("@SecurityInfrastructure", string.Empty);
                            cmd.Parameters.AddWithValue("@SecurityNotesNextSteps", string.Empty);
                            cmd.Parameters.AddWithValue("@DistElectricalIFAs", DBNull.Value);
                            cmd.Parameters.AddWithValue("@DistElectricalIFCs", DBNull.Value);
                            cmd.Parameters.AddWithValue("@AboveGradeElectricalIFAs", DBNull.Value);
                            cmd.Parameters.AddWithValue("@PermitStatus", string.Empty);
                            cmd.Parameters.AddWithValue("@CreatedBy", string.Empty);
                            cmd.Parameters.AddWithValue("@UpdatedBy", string.Empty);
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
                                    var onlyDate = "MM'/'dd'/'yyyy";
                                    var dateWithTime = "MM'/'dd'/'yyyy h:mm tt";
                                    var hutphasetwo = new HutExAuxPowerPhaseTwoModel();
                                    hutphasetwo.AuxPowerPhase2ID = (long)dataReader["AuxPowerPhase2ID"];
                                    hutphasetwo.HutExecutionID = (long)dataReader["HutExecutionID"];
                                    hutphasetwo.SecurityInfrastructure = dataReader["SecurityInfrastructure"].ToString();
                                    hutphasetwo.SecurityNotesNextSteps = dataReader["SecurityNotesNextSteps"].ToString();
                                    if(dataReader["DistElectricalIFAs"] != DBNull.Value)
                                        hutphasetwo.DistElectricalIFAs = Convert.ToDateTime(dataReader["DistElectricalIFAs"]);
                                    if (dataReader["DistElectricalIFCs"] != DBNull.Value)
                                        hutphasetwo.DistElectricalIFCs = Convert.ToDateTime(dataReader["DistElectricalIFCs"]);
                                    if (dataReader["AboveGradeElectricalIFAs"] != DBNull.Value)
                                        hutphasetwo.AboveGradeElectricalIFAs = Convert.ToDateTime(dataReader["AboveGradeElectricalIFAs"]);
                                    if (dataReader["DistElectricalIFAs"] != DBNull.Value)
                                        hutphasetwo.StrDistElectricalIFAs = Convert.ToDateTime(dataReader["DistElectricalIFAs"]).ToString(onlyDate);
                                    if (dataReader["DistElectricalIFCs"] != DBNull.Value)
                                        hutphasetwo.StrDistElectricalIFCs = Convert.ToDateTime(dataReader["DistElectricalIFCs"]).ToString(onlyDate);
                                    if (dataReader["AboveGradeElectricalIFAs"] != DBNull.Value)
                                        hutphasetwo.StrAboveGradeElectricalIFAs = Convert.ToDateTime(dataReader["AboveGradeElectricalIFAs"]).ToString(onlyDate);
                                    hutphasetwo.PermitStatus = dataReader["PermitStatus"].ToString();
                                    hutphasetwo.IsActive = Convert.ToBoolean(dataReader["IsActive"]);
                                    hutphasetwo.CreatedBy = dataReader["CreatedBy"].ToString();
                                    hutphasetwo.CreatedDate = Convert.ToDateTime(dataReader["CreatedDate"]).ToString(dateWithTime);
                                    hutphasetwo.UpdatedBy = dataReader["UpdatedBy"].ToString();
                                    hutphasetwo.UpdatedDate = Convert.ToDateTime(dataReader["UpdatedDate"]).ToString(dateWithTime);
                                    result.Add(hutphasetwo);

                                }
                            }

                            connection.Close();
                            return result;


                        }
                    }

                }
                catch (Exception ex) { return new List<HutExAuxPowerPhaseTwoModel>(); }
            });
        }

        public Task<HutExAuxPowerPhaseTwoModel> CreateHutPhaseTwo(HutExAuxPowerPhaseTwoModel hutExAuxPowerPhaseTwoModel)
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
                            cmd.Parameters.AddWithValue("@AuxPowerPhase2ID", hutExAuxPowerPhaseTwoModel.AuxPowerPhase2ID);
                            cmd.Parameters.AddWithValue("@HutExecutionID", hutExAuxPowerPhaseTwoModel.HutExecutionID);
                            cmd.Parameters.AddWithValue("@SecurityInfrastructure", string.IsNullOrEmpty(hutExAuxPowerPhaseTwoModel.SecurityInfrastructure) ? string.Empty : hutExAuxPowerPhaseTwoModel.SecurityInfrastructure);
                            cmd.Parameters.AddWithValue("@SecurityNotesNextSteps", string.IsNullOrEmpty(hutExAuxPowerPhaseTwoModel.SecurityNotesNextSteps) ? string.Empty : hutExAuxPowerPhaseTwoModel.SecurityNotesNextSteps);
                            cmd.Parameters.AddWithValue("@DistElectricalIFAs", checkNull(hutExAuxPowerPhaseTwoModel.DistElectricalIFAs));
                            cmd.Parameters.AddWithValue("@DistElectricalIFCs", checkNull(hutExAuxPowerPhaseTwoModel.DistElectricalIFCs));
                            cmd.Parameters.AddWithValue("@AboveGradeElectricalIFAs", checkNull(hutExAuxPowerPhaseTwoModel.DistElectricalIFAs));
                            cmd.Parameters.AddWithValue("@PermitStatus", string.IsNullOrEmpty(hutExAuxPowerPhaseTwoModel.PermitStatus) ? string.Empty : hutExAuxPowerPhaseTwoModel.PermitStatus);
                            cmd.Parameters.AddWithValue("@CreatedBy", hutExAuxPowerPhaseTwoModel.CreatedBy);
                            cmd.Parameters.AddWithValue("@UpdatedBy", hutExAuxPowerPhaseTwoModel.CreatedBy);
                            cmd.Connection = connection;
                            connection.Open();
                            hutExAuxPowerPhaseTwoModel.AuxPowerPhase2ID = (long)cmd.ExecuteScalar();
                            connection.Close();
                            return hutExAuxPowerPhaseTwoModel;
                        }
                    }

                }
                catch (Exception ex) { return new HutExAuxPowerPhaseTwoModel(); }
            });
        }


        public Task<HutExAuxPowerPhaseTwoModel> UpdateHutPhaseTwo(HutExAuxPowerPhaseTwoModel hutExAuxPowerPhaseTwoModel)
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
                            cmd.Parameters.AddWithValue("@AuxPowerPhase2ID", hutExAuxPowerPhaseTwoModel.AuxPowerPhase2ID);
                            cmd.Parameters.AddWithValue("@HutExecutionID", hutExAuxPowerPhaseTwoModel.HutExecutionID);
                            cmd.Parameters.AddWithValue("@SecurityInfrastructure", string.IsNullOrEmpty(hutExAuxPowerPhaseTwoModel.SecurityInfrastructure) ? string.Empty : hutExAuxPowerPhaseTwoModel.SecurityInfrastructure);
                            cmd.Parameters.AddWithValue("@SecurityNotesNextSteps", string.IsNullOrEmpty(hutExAuxPowerPhaseTwoModel.SecurityNotesNextSteps) ? string.Empty : hutExAuxPowerPhaseTwoModel.SecurityNotesNextSteps);
                            cmd.Parameters.AddWithValue("@DistElectricalIFAs", checkNull(hutExAuxPowerPhaseTwoModel.DistElectricalIFAs));
                            cmd.Parameters.AddWithValue("@DistElectricalIFCs", checkNull(hutExAuxPowerPhaseTwoModel.DistElectricalIFCs));
                            cmd.Parameters.AddWithValue("@AboveGradeElectricalIFAs", checkNull(hutExAuxPowerPhaseTwoModel.DistElectricalIFAs));
                            cmd.Parameters.AddWithValue("@PermitStatus", string.IsNullOrEmpty(hutExAuxPowerPhaseTwoModel.PermitStatus) ? string.Empty : hutExAuxPowerPhaseTwoModel.PermitStatus);
                            cmd.Parameters.AddWithValue("@CreatedBy", string.Empty);
                            cmd.Parameters.AddWithValue("@UpdatedBy", hutExAuxPowerPhaseTwoModel.UpdatedBy);
                            cmd.Connection = connection;
                            connection.Open();

                            var hutphasetwo = new HutExAuxPowerPhaseTwoModel();
                            using (SqlDataReader dataReader = cmd.ExecuteReader())
                            {
                                while (dataReader.Read())
                                {
                                    
                                    hutphasetwo.AuxPowerPhase2ID = (long)dataReader["AuxPowerPhase2ID"];
                                    hutphasetwo.HutExecutionID = (long)dataReader["HutExecutionID"];
                                    hutphasetwo.SecurityInfrastructure = dataReader["SecurityInfrastructure"].ToString();
                                    hutphasetwo.SecurityNotesNextSteps = dataReader["SecurityNotesNextSteps"].ToString();
                                    if (dataReader["DistElectricalIFAs"] != DBNull.Value)
                                        hutphasetwo.DistElectricalIFAs = Convert.ToDateTime(dataReader["DistElectricalIFAs"]);
                                    if (dataReader["DistElectricalIFCs"] != DBNull.Value)
                                        hutphasetwo.DistElectricalIFCs = Convert.ToDateTime(dataReader["DistElectricalIFCs"]);
                                    if (dataReader["AboveGradeElectricalIFAs"] != DBNull.Value)
                                        hutphasetwo.AboveGradeElectricalIFAs = Convert.ToDateTime(dataReader["AboveGradeElectricalIFAs"]);
                                    hutphasetwo.PermitStatus = dataReader["PermitStatus"].ToString();
                                    

                                }
                            }
                            if (string.IsNullOrEmpty(hutExAuxPowerPhaseTwoModel.SecurityInfrastructure))
                                cmd.Parameters["@SecurityInfrastructure"].Value = hutphasetwo.SecurityInfrastructure;

                            if (string.IsNullOrEmpty(hutExAuxPowerPhaseTwoModel.SecurityNotesNextSteps))
                                cmd.Parameters["@SecurityNotesNextSteps"].Value = hutphasetwo.SecurityNotesNextSteps;

                            if (string.IsNullOrEmpty(hutExAuxPowerPhaseTwoModel.PermitStatus))
                                cmd.Parameters["@PermitStatus"].Value = hutphasetwo.PermitStatus;

                            cmd.Parameters["@DistElectricalIFAs"].Value = checkNullWithValue(hutExAuxPowerPhaseTwoModel.DistElectricalIFAs, hutphasetwo.DistElectricalIFAs);
                            cmd.Parameters["@DistElectricalIFCs"].Value = checkNullWithValue(hutExAuxPowerPhaseTwoModel.DistElectricalIFCs, hutphasetwo.DistElectricalIFCs);
                            cmd.Parameters["@AboveGradeElectricalIFAs"].Value = checkNullWithValue(hutExAuxPowerPhaseTwoModel.AboveGradeElectricalIFAs, hutphasetwo.AboveGradeElectricalIFAs);

                            cmd.Parameters["@procId"].Value = 2;
                            cmd.ExecuteNonQuery();
                            connection.Close();
                            return hutExAuxPowerPhaseTwoModel;
                        }
                    }

                }
                catch (Exception ex) { return new HutExAuxPowerPhaseTwoModel(); }
            });
        }

        public Task<int> DeleteHutPhaseTwo(int id)
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
                            cmd.Parameters.AddWithValue("@AuxPowerPhase2ID", id);
                            cmd.Parameters.AddWithValue("@HutExecutionID", 0);
                            cmd.Parameters.AddWithValue("@SecurityInfrastructure", string.Empty);
                            cmd.Parameters.AddWithValue("@SecurityNotesNextSteps", string.Empty);
                            cmd.Parameters.AddWithValue("@DistElectricalIFAs", DBNull.Value);
                            cmd.Parameters.AddWithValue("@DistElectricalIFCs", DBNull.Value);
                            cmd.Parameters.AddWithValue("@AboveGradeElectricalIFAs", DBNull.Value);
                            cmd.Parameters.AddWithValue("@PermitStatus", string.Empty);
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
