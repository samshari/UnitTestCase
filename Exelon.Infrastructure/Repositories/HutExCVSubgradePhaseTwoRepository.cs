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
    public class HutExCVSubgradePhaseTwoRepository : IHutExCVSubgradePhaseTwoRepository
    {
        private readonly string _connectionString;
        private readonly string _storedProcedure = "dbo.spHutExCVSubgradePhaseTwoActions";


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

        public HutExCVSubgradePhaseTwoRepository(IAppSettings appSettings)
        {
            _connectionString = appSettings.GetConnectionString();
        }

        public Task<List<HutExCVSubgradePhaseTwoModel>> GetHutExCV(int id = 0)
        {
            return Task.Run(() =>
            {
                var result = new List<HutExCVSubgradePhaseTwoModel>();
                try
                {
                    using (SqlConnection connection = new SqlConnection(this._connectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.CommandText = _storedProcedure;
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@HutExCVSubgradePhase2_ID", id);
                            cmd.Parameters.AddWithValue("@HutsExecutionID", 0);
                            cmd.Parameters.AddWithValue("@CiviIFAs_T15",DBNull.Value);
                            cmd.Parameters.AddWithValue("@CivilIFCs_T12",DBNull.Value);
                            cmd.Parameters.AddWithValue("@PermitReadyDate",DBNull.Value);
                            cmd.Parameters.AddWithValue("@RFPSubmittedOn",DBNull.Value);
                            cmd.Parameters.AddWithValue("@PreConstructionWalkdown",DBNull.Value);
                            cmd.Parameters.AddWithValue("@FK_HASPRequired",0);
                            cmd.Parameters.AddWithValue("@CreateMR",string.Empty);
                            cmd.Parameters.AddWithValue("@HRESubmitte",string.Empty);
                            cmd.Parameters.AddWithValue("@PermitsOutstanding_T8",string.Empty);
                            cmd.Parameters.AddWithValue("@HASPReqdOther",string.Empty);
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
                                    var hutphasetwo = new HutExCVSubgradePhaseTwoModel();
                                    hutphasetwo.HutExCVSubgradePhase2_ID = (long)dataReader["HutExCVSubgradePhase2_ID"];
                                    hutphasetwo.HutsExecutionID = (long)dataReader["HutsExecutionID"];
                                    if(dataReader["CiviIFAs_T15"] != DBNull.Value)
                                        hutphasetwo.CiviIFAs_T15 = Convert.ToDateTime(dataReader["CiviIFAs_T15"]);
                                    if (dataReader["CivilIFCs_T12"] != DBNull.Value)
                                        hutphasetwo.CivilIFCs_T12 = Convert.ToDateTime(dataReader["CivilIFCs_T12"]);
                                    if (dataReader["PermitReadyDate"] != DBNull.Value)
                                        hutphasetwo.PermitReadyDate = Convert.ToDateTime(dataReader["PermitReadyDate"]);
                                    if (dataReader["RFPSubmittedOn"] != DBNull.Value)
                                        hutphasetwo.RFPSubmittedOn = Convert.ToDateTime(dataReader["RFPSubmittedOn"]);
                                    if (dataReader["PreConstructionWalkdown"] != DBNull.Value)
                                        hutphasetwo.PreConstructionWalkdown = Convert.ToDateTime(dataReader["PreConstructionWalkdown"]);

                                    if (dataReader["CiviIFAs_T15"] != DBNull.Value)
                                        hutphasetwo.StrCiviIFAs_T15 = Convert.ToDateTime(dataReader["CiviIFAs_T15"]).ToString(onlyDate);
                                    if (dataReader["CivilIFCs_T12"] != DBNull.Value)
                                        hutphasetwo.StrCivilIFCs_T12 = Convert.ToDateTime(dataReader["CivilIFCs_T12"]).ToString(onlyDate);
                                    if (dataReader["PermitReadyDate"] != DBNull.Value)
                                        hutphasetwo.StrPermitReadyDate = Convert.ToDateTime(dataReader["PermitReadyDate"]).ToString(onlyDate);
                                    if (dataReader["RFPSubmittedOn"] != DBNull.Value)
                                        hutphasetwo.StrRFPSubmittedOn = Convert.ToDateTime(dataReader["RFPSubmittedOn"]).ToString(onlyDate);
                                    if (dataReader["PreConstructionWalkdown"] != DBNull.Value)
                                        hutphasetwo.StrPreConstructionWalkdown = Convert.ToDateTime(dataReader["PreConstructionWalkdown"]).ToString(onlyDate);

                                    if (dataReader["FK_HASPRequired"] != DBNull.Value)
                                        hutphasetwo.FK_HASPRequired = (int)dataReader["FK_HASPRequired"];
                                    hutphasetwo.CreateMR = dataReader["CreateMR"].ToString();
                                    hutphasetwo.HRESubmitte = dataReader["HRESubmitte"].ToString();
                                    hutphasetwo.PermitsOutstanding_T8 = dataReader["PermitsOutstanding_T8"].ToString();
                                    hutphasetwo.HASPReqdOther = dataReader["HASPReqdOther"].ToString();
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
                catch (Exception ex) { return new List<HutExCVSubgradePhaseTwoModel>(); }
            });
        }

        public Task<HutExCVSubgradePhaseTwoModel> CreateHutExCV(HutExCVSubgradePhaseTwoModel hutExCVSubgradePhaseTwoModel)
        {
            return Task.Run(() =>
            {
                var result = new List<HutExCVSubgradePhaseTwoModel>();
                try
                {
                    using (SqlConnection connection = new SqlConnection(this._connectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.CommandText = _storedProcedure;
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@procId", 1);
                            cmd.Parameters.AddWithValue("@HutExCVSubgradePhase2_ID", hutExCVSubgradePhaseTwoModel.HutExCVSubgradePhase2_ID);
                            cmd.Parameters.AddWithValue("@HutsExecutionID", hutExCVSubgradePhaseTwoModel.HutsExecutionID);
                            cmd.Parameters.AddWithValue("@CiviIFAs_T15", checkNull(hutExCVSubgradePhaseTwoModel.CiviIFAs_T15));
                            cmd.Parameters.AddWithValue("@CivilIFCs_T12", checkNull(hutExCVSubgradePhaseTwoModel.CivilIFCs_T12));
                            cmd.Parameters.AddWithValue("@PermitReadyDate", checkNull(hutExCVSubgradePhaseTwoModel.PermitReadyDate));
                            cmd.Parameters.AddWithValue("@RFPSubmittedOn", checkNull(hutExCVSubgradePhaseTwoModel.RFPSubmittedOn));
                            cmd.Parameters.AddWithValue("@PreConstructionWalkdown", checkNull(hutExCVSubgradePhaseTwoModel.PreConstructionWalkdown));
                            cmd.Parameters.AddWithValue("@FK_HASPRequired", checkNull(hutExCVSubgradePhaseTwoModel.FK_HASPRequired));
                            cmd.Parameters.AddWithValue("@CreateMR", string.IsNullOrEmpty(hutExCVSubgradePhaseTwoModel.CreateMR)?string.Empty:hutExCVSubgradePhaseTwoModel.CreateMR);
                            cmd.Parameters.AddWithValue("@HRESubmitte", string.IsNullOrEmpty(hutExCVSubgradePhaseTwoModel.HRESubmitte)?string.Empty:hutExCVSubgradePhaseTwoModel.HRESubmitte);
                            cmd.Parameters.AddWithValue("@PermitsOutstanding_T8", string.IsNullOrEmpty(hutExCVSubgradePhaseTwoModel.PermitsOutstanding_T8)?string.Empty:hutExCVSubgradePhaseTwoModel.PermitsOutstanding_T8);
                            cmd.Parameters.AddWithValue("@HASPReqdOther", string.IsNullOrEmpty(hutExCVSubgradePhaseTwoModel.HASPReqdOther)?string.Empty:hutExCVSubgradePhaseTwoModel.HASPReqdOther);
                            cmd.Parameters.AddWithValue("@CreatedBy", hutExCVSubgradePhaseTwoModel.CreatedBy);
                            cmd.Parameters.AddWithValue("@UpdatedBy", hutExCVSubgradePhaseTwoModel.CreatedBy);
                            cmd.Connection = connection;
                            connection.Open();
                            hutExCVSubgradePhaseTwoModel.HutExCVSubgradePhase2_ID = (long)cmd.ExecuteScalar();
                            connection.Close();
                            return hutExCVSubgradePhaseTwoModel;

                        }
                    }

                }
                catch (Exception ex) { return new HutExCVSubgradePhaseTwoModel(); }
            });
        }

        public Task<HutExCVSubgradePhaseTwoModel> UpdateHutExCV(HutExCVSubgradePhaseTwoModel hutExCVSubgradePhaseTwoModel)
        {
            return Task.Run(() =>
            {
                var result = new List<HutExCVSubgradePhaseTwoModel>();
                try
                {
                    using (SqlConnection connection = new SqlConnection(this._connectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.CommandText = _storedProcedure;
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@procId", 2);
                            cmd.Parameters.AddWithValue("@HutExCVSubgradePhase2_ID", hutExCVSubgradePhaseTwoModel.HutExCVSubgradePhase2_ID);
                            cmd.Parameters.AddWithValue("@HutsExecutionID", hutExCVSubgradePhaseTwoModel.HutsExecutionID);
                            cmd.Parameters.AddWithValue("@CiviIFAs_T15", checkNull(hutExCVSubgradePhaseTwoModel.CiviIFAs_T15));
                            cmd.Parameters.AddWithValue("@CivilIFCs_T12", checkNull(hutExCVSubgradePhaseTwoModel.CivilIFCs_T12));
                            cmd.Parameters.AddWithValue("@PermitReadyDate", checkNull(hutExCVSubgradePhaseTwoModel.PermitReadyDate));
                            cmd.Parameters.AddWithValue("@RFPSubmittedOn", checkNull(hutExCVSubgradePhaseTwoModel.RFPSubmittedOn));
                            cmd.Parameters.AddWithValue("@PreConstructionWalkdown", checkNull(hutExCVSubgradePhaseTwoModel.PreConstructionWalkdown));
                            cmd.Parameters.AddWithValue("@FK_HASPRequired", checkNull(hutExCVSubgradePhaseTwoModel.FK_HASPRequired));
                            cmd.Parameters.AddWithValue("@CreateMR", string.IsNullOrEmpty(hutExCVSubgradePhaseTwoModel.CreateMR) ? string.Empty : hutExCVSubgradePhaseTwoModel.CreateMR);
                            cmd.Parameters.AddWithValue("@HRESubmitte", string.IsNullOrEmpty(hutExCVSubgradePhaseTwoModel.HRESubmitte) ? string.Empty : hutExCVSubgradePhaseTwoModel.HRESubmitte);
                            cmd.Parameters.AddWithValue("@PermitsOutstanding_T8", string.IsNullOrEmpty(hutExCVSubgradePhaseTwoModel.PermitsOutstanding_T8) ? string.Empty : hutExCVSubgradePhaseTwoModel.PermitsOutstanding_T8);
                            cmd.Parameters.AddWithValue("@HASPReqdOther", string.IsNullOrEmpty(hutExCVSubgradePhaseTwoModel.HASPReqdOther) ? string.Empty : hutExCVSubgradePhaseTwoModel.HASPReqdOther);
                            cmd.Parameters.AddWithValue("@CreatedBy", string.Empty);
                            cmd.Parameters.AddWithValue("@UpdatedBy", hutExCVSubgradePhaseTwoModel.UpdatedBy);
                            cmd.Connection = connection;
                            connection.Open();
                            cmd.ExecuteNonQuery();
                            connection.Close();
                            return hutExCVSubgradePhaseTwoModel;

                        }
                    }

                }
                catch (Exception ex) { return new HutExCVSubgradePhaseTwoModel(); }
            });
        }

        public Task<int> DeleteHutExCV(int id)
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
                            cmd.Parameters.AddWithValue("@procId", 3);
                            cmd.Parameters.AddWithValue("@HutExCVSubgradePhase2_ID", id);
                            cmd.Parameters.AddWithValue("@HutsExecutionID", 0);
                            cmd.Parameters.AddWithValue("@CiviIFAs_T15", DBNull.Value);
                            cmd.Parameters.AddWithValue("@CivilIFCs_T12", DBNull.Value);
                            cmd.Parameters.AddWithValue("@PermitReadyDate", DBNull.Value);
                            cmd.Parameters.AddWithValue("@RFPSubmittedOn", DBNull.Value);
                            cmd.Parameters.AddWithValue("@PreConstructionWalkdown", DBNull.Value);
                            cmd.Parameters.AddWithValue("@FK_HASPRequired", 0);
                            cmd.Parameters.AddWithValue("@CreateMR", string.Empty);
                            cmd.Parameters.AddWithValue("@HRESubmitte", string.Empty);
                            cmd.Parameters.AddWithValue("@PermitsOutstanding_T8", string.Empty);
                            cmd.Parameters.AddWithValue("@HASPReqdOther", string.Empty);
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
