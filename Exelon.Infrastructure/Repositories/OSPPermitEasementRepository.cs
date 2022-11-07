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
    public class OSPPermitEasementRepository : IOSPPermitEasementRepository
    {
        private readonly string _connectionString;
        private readonly string _storedProcedure = "dbo.sp_OSPPermitEasementActions";
        public OSPPermitEasementRepository(IAppSettings appSettings)
        {
            _connectionString = appSettings.GetConnectionString();
        }

        public async Task<List<OSPPermitEasementModel>> GetOSPPermitEasement(int id = 0)
        {
            return await Task.Run(() =>
            {
                var result = new List<OSPPermitEasementModel>();
                try
                {
                    using (SqlConnection connection = new SqlConnection(this._connectionString))
                    {
                        connection.Open();
                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.CommandText = _storedProcedure;
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@id", id);
                            cmd.Parameters.AddWithValue("@pdId", 0);
                            cmd.Parameters.AddWithValue("@pId", "");
                            cmd.Parameters.AddWithValue("@link", string.Empty);
                            cmd.Parameters.AddWithValue("@miles", 0);
                            cmd.Parameters.AddWithValue("@currentIFADate", string.Empty);
                            cmd.Parameters.AddWithValue("@executionQuarterStart", string.Empty);
                            cmd.Parameters.AddWithValue("@executionQuarterFinish", 0);
                            cmd.Parameters.AddWithValue("@executionYear", string.Empty);
                            cmd.Parameters.AddWithValue("@easementsRes", 0);
                            cmd.Parameters.AddWithValue("@easementsReq", 0);
                            cmd.Parameters.AddWithValue("@permitStatusIDOTPermitsRes", 0);
                            cmd.Parameters.AddWithValue("@permitStatusIDOTPermitsReq", 0);
                            cmd.Parameters.AddWithValue("@permitStatusEnvironmentalPermitReq", 0);
                            cmd.Parameters.AddWithValue("@permitStatusEnvironmentalPermitRes", 0);
                            cmd.Parameters.AddWithValue("@permitStatusRRMetraPermitReq", 0);
                            cmd.Parameters.AddWithValue("@permitStatusRRMetraPermitRes", 0);
                            cmd.Parameters.AddWithValue("@permitStatusCityCountryPermitReq", 0);
                            cmd.Parameters.AddWithValue("@permitStatusCityCountryPermitRes", 0);
                            cmd.Parameters.AddWithValue("@permitStatusTROWPermitReq", 0);
                            cmd.Parameters.AddWithValue("@permitStatusTROWPermitRes", 0);
                            cmd.Parameters.AddWithValue("@potentialIssuesConcerns", string.Empty);
                            cmd.Parameters.AddWithValue("@createdBy", string.Empty);
                            cmd.Parameters.AddWithValue("@updatedBy", string.Empty);
                            cmd.Connection = connection;

                            if (id == 0)
                                cmd.Parameters.AddWithValue("@procId", 3);
                            else
                                cmd.Parameters.AddWithValue("@procId", 4);

                            using (SqlDataReader dataReader = cmd.ExecuteReader())
                            {
                                while (dataReader.Read())
                                {
                                    var ospModel = new OSPPermitEasementModel();
                                    ospModel.PermitId = (Int64)dataReader["ID"];
                                    ospModel.PDId = (int)dataReader["PDID"];
                                    ospModel.PId = dataReader["PID"].ToString();
                                    ospModel.Link = dataReader["Link"].ToString();
                                    ospModel.Miles = (decimal)dataReader["Miles"];
                                    ospModel.CurrentIFADate = dataReader["CurrentIFADate"].ToString();
                                    ospModel.ExecutionQuarterStart = dataReader["ExecutionQuarterStart"].ToString();
                                    ospModel.ExecutionQuarterFinish = (int)dataReader["ExecutionQuarterFinish"];
                                    ospModel.ExecutionYear = dataReader["ExecutionYear"].ToString();
                                    ospModel.EasementsRes = (int)dataReader["EasementsRes"];
                                    ospModel.EasementsReq = (int)dataReader["EasementsReq"];
                                    ospModel.PermitStatusIDOTPermitsRes = (int)dataReader["PermitStatusIDOTPermitsRes"];
                                    ospModel.PermitStatusIDOTPermitsReq = (int)dataReader["PermitStatusIDOTPermitsReq"];
                                    ospModel.PermitStatusEnvironmentalPermitReq = (int)dataReader["PermitStatusEnvironmentalPermitReq"];
                                    ospModel.PermitStatusEnvironmentalPermitRes = (int)dataReader["PermitStatusEnvironmentalPermitRes"];
                                    ospModel.PermitStatusRRMetraPermitReq = (int)dataReader["PermitStatusRRMetraPermitReq"];
                                    ospModel.PermitStatusRRMetraPermitRes = (int)dataReader["PermitStatusRRMetraPermitRes"];
                                    ospModel.PermitStatusCityCountryPermitReq = (int)dataReader["PermitStatusCityCountryPermitReq"];
                                    ospModel.PermitStatusCityCountryPermitRes = (int)dataReader["PermitStatusCityCountryPermitRes"];
                                    ospModel.PermitStatusTROWPermitReq = (int)dataReader["PermitStatusTROWPermitReq"];
                                    ospModel.PermitStatusTROWPermitRes = (int)dataReader["PermitStatusTROWPermitRes"];
                                    ospModel.PotentialIssuesConcerns = (int)dataReader["PotentialIssuesConcerns"];
                                    result.Add(ospModel);
                                }
                            }
                        }
                        connection.Close();
                    }
                    return result;
                }
                catch (Exception) { return new List<OSPPermitEasementModel>(); }
            });
        }

        public async Task<OSPPermitEasementModel> SaveUpdatedOSPPermitEasement(OSPPermitEasementModel model)
        {
            return await Task.Run(() =>
            {
                var result = new OSPPermitEasementModel();
                try
                {
                    using (SqlConnection connection = new SqlConnection(this._connectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.CommandText = _storedProcedure;
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            if (model.PermitId == 0)
                                cmd.Parameters.AddWithValue("@procId", 1);
                            else if (model.PermitId > 0)
                                cmd.Parameters.AddWithValue("@procId", 2);

                            cmd.Parameters.AddWithValue("@id", model.PermitId);
                            cmd.Parameters.AddWithValue("@pdId", model.PDId);
                            cmd.Parameters.AddWithValue("@pId", model.PId);
                            cmd.Parameters.AddWithValue("@link", model.Link);
                            cmd.Parameters.AddWithValue("@miles", model.Miles);
                            cmd.Parameters.AddWithValue("@currentIFADate", model.CurrentIFADate);
                            cmd.Parameters.AddWithValue("@executionQuarterStart", model.ExecutionQuarterStart);
                            cmd.Parameters.AddWithValue("@executionQuarterFinish", model.ExecutionQuarterFinish);
                            cmd.Parameters.AddWithValue("@executionYear", model.ExecutionYear);
                            cmd.Parameters.AddWithValue("@easementsRes", model.EasementsRes);
                            cmd.Parameters.AddWithValue("@easementsReq", model.EasementsReq);
                            cmd.Parameters.AddWithValue("@permitStatusIDOTPermitsRes", model.PermitStatusIDOTPermitsRes);
                            cmd.Parameters.AddWithValue("@permitStatusIDOTPermitsReq", model.PermitStatusIDOTPermitsReq);
                            cmd.Parameters.AddWithValue("@permitStatusEnvironmentalPermitReq", model.PermitStatusEnvironmentalPermitReq);
                            cmd.Parameters.AddWithValue("@permitStatusEnvironmentalPermitRes", model.PermitStatusEnvironmentalPermitRes);
                            cmd.Parameters.AddWithValue("@permitStatusRRMetraPermitReq", model.PermitStatusRRMetraPermitReq);
                            cmd.Parameters.AddWithValue("@permitStatusRRMetraPermitRes", model.PermitStatusRRMetraPermitRes);
                            cmd.Parameters.AddWithValue("@permitStatusCityCountryPermitReq", model.PermitStatusCityCountryPermitReq);
                            cmd.Parameters.AddWithValue("@permitStatusCityCountryPermitRes", model.PermitStatusCityCountryPermitRes);
                            cmd.Parameters.AddWithValue("@permitStatusTROWPermitReq", model.PermitStatusTROWPermitReq);
                            cmd.Parameters.AddWithValue("@permitStatusTROWPermitRes", model.PermitStatusTROWPermitRes);
                            cmd.Parameters.AddWithValue("@potentialIssuesConcerns", model.PotentialIssuesConcerns);
                            cmd.Parameters.AddWithValue("@createdBy", model.CreatedBy);
                            cmd.Parameters.AddWithValue("@updatedBy", model.CreatedBy);

                            cmd.Connection = connection;
                            connection.Open();
                            result.PermitId = (Int64)cmd.ExecuteScalar();
                            connection.Close();
                            return result;
                        }
                    }
                }
                catch (Exception) { return new OSPPermitEasementModel(); }
            });
        }
    }
}
