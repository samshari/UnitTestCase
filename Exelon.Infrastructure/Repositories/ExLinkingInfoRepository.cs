using Exelon.Domain;
using Exelon.Domain.Abstractions;
using Exelon.Domain.Common;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Exelon.Infrastructure.Repositories
{
    public class ExLinkingInfoRepository: IExLinkingInfoRepository
    {
        private readonly string _connectionString;
        private readonly string _storedProcedure = "[dbo].[spExLINKINGInfoActions]";

        public ExLinkingInfoRepository(IAppSettings appSettings)
        {
            _connectionString = appSettings.GetConnectionString();
        }

        private object checkNull(object value)
        {
            if (value == null)
                return DBNull.Value;

            return value;
        }

        
        public async Task<List<ExLinkingInfoModel>> GetExLinkInfo(int id = 0)
        {
            return await Task.Run(() =>
            {
                var lstLinkInfo = new List<ExLinkingInfoModel>();
                try
                {
                    using (SqlConnection connection = new SqlConnection(this._connectionString))
                    {
                        connection.Open();
                        using (SqlCommand cmd = new SqlCommand())
                        {

                            cmd.CommandText = _storedProcedure;
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@ExecutionLinkingID", id);
                            cmd.Parameters.AddWithValue("@PrimaryKey", string.Empty);
                            cmd.Parameters.AddWithValue("@Description", string.Empty);
                            cmd.Parameters.AddWithValue("@Nickname", string.Empty);
                            cmd.Parameters.AddWithValue("@PDID", 1);
                            cmd.Parameters.AddWithValue("@EngineeringYear", string.Empty);
                            cmd.Parameters.AddWithValue("@ExecutionYear", string.Empty);
                            cmd.Parameters.AddWithValue("@FK_TechnologyID", 1);
                            cmd.Parameters.AddWithValue("@FK_RegionID", 0);
                            cmd.Parameters.AddWithValue("@FK_BarnID", 0);
                            cmd.Parameters.AddWithValue("@WorkOrder", string.Empty);
                            cmd.Parameters.AddWithValue("@ProjectID", string.Empty);
                            cmd.Parameters.AddWithValue("@Comments", string.Empty);
                            cmd.Parameters.AddWithValue("@ScopeComments", string.Empty);
                            cmd.Parameters.AddWithValue("@ITN", string.Empty);
                            cmd.Parameters.AddWithValue("@FK_ProjectStatusID", 0);
                            cmd.Parameters.AddWithValue("@FiberCount", string.Empty);
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
                                    var dateWithTime = "MM'/'dd'/'yyyy h:mm tt";
                                    var linkInfo = new ExLinkingInfoModel();
                                    linkInfo.ExecutionLinkingID = (long)dataReader["ExecutionLinkingID"];
                                    linkInfo.PrimaryKey = dataReader["PrimaryKey"].ToString();
                                    linkInfo.Description = dataReader["Description"].ToString();
                                    linkInfo.Nickname = dataReader["Nickname"].ToString();
                                    linkInfo.PDId = (int)dataReader["PDID"];
                                    linkInfo.EngineeringYear = dataReader["EngineeringYear"].ToString();
                                    linkInfo.ExecutionYear = dataReader["ExecutionYear"].ToString();
                                    if (dataReader["FK_TechnologyID"] != DBNull.Value)
                                        linkInfo.TechnologyId = (int)dataReader["FK_TechnologyID"];
                                    if (dataReader["FK_RegionID"] != DBNull.Value)
                                        linkInfo.RegionId = (int)dataReader["FK_RegionID"];
                                    if (dataReader["FK_BarnID"] != DBNull.Value)
                                        linkInfo.BarnId = (int)dataReader["FK_BarnID"];
                                    linkInfo.WorkOrder = dataReader["WorkOrder"].ToString();
                                    linkInfo.ProjectId = dataReader["ProjectID"].ToString();
                                    linkInfo.FiberCount = dataReader["FiberCount"].ToString();
                                    linkInfo.Comments = dataReader["Comments"].ToString();
                                    linkInfo.ScopeComments = dataReader["ScopeComments"].ToString();
                                    linkInfo.StatusName = dataReader["StatusName"].ToString();
                                    linkInfo.ITN = dataReader["ITN"].ToString();
                                    if (dataReader["FK_ProjectStatusID"] != DBNull.Value)
                                        linkInfo.ProjectStatusId = (int)dataReader["FK_ProjectStatusID"];
                                    lstLinkInfo.Add(linkInfo);

                                }
                            }
                        }
                    }
                    return lstLinkInfo;
                }
                catch (Exception ex) { throw ex; }
            });

        }

        public async Task<Dictionary<ExLinkingInfoModel, string>> CreateExLinkInfo(ExLinkingInfoModel linkingInfoModel)
        {
            return await Task.Run(() =>
            {
                var result = new Dictionary<ExLinkingInfoModel, string>();
                if (string.IsNullOrEmpty(linkingInfoModel.ProjectId))
                {
                    result[linkingInfoModel] = "ProjectId is Empty!";
                    return result;
                }

                try
                {
                    using (SqlConnection connection = new SqlConnection(this._connectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.CommandText = _storedProcedure;
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@procID", 8);
                            cmd.Parameters.AddWithValue("@ExecutionLinkingID", 0);
                            cmd.Parameters.AddWithValue("@PrimaryKey", string.IsNullOrEmpty(linkingInfoModel.PrimaryKey) ? string.Empty : linkingInfoModel.PrimaryKey);
                            cmd.Parameters.AddWithValue("@Description", string.IsNullOrEmpty(linkingInfoModel.Description) ? string.Empty : linkingInfoModel.Description);
                            cmd.Parameters.AddWithValue("@Nickname", string.IsNullOrEmpty(linkingInfoModel.Nickname) ? string.Empty : linkingInfoModel.Nickname);
                            cmd.Parameters.AddWithValue("@PDID", linkingInfoModel.PDId);
                            cmd.Parameters.AddWithValue("@EngineeringYear", string.IsNullOrEmpty(linkingInfoModel.EngineeringYear) ? string.Empty : linkingInfoModel.EngineeringYear);
                            cmd.Parameters.AddWithValue("@ExecutionYear", string.IsNullOrEmpty(linkingInfoModel.ExecutionYear) ? string.Empty : linkingInfoModel.ExecutionYear);
                            cmd.Parameters.AddWithValue("@FK_RegionID", checkNull(linkingInfoModel.RegionId));
                            cmd.Parameters.AddWithValue("@FK_TechnologyID", checkNull(linkingInfoModel.TechnologyId));
                            cmd.Parameters.AddWithValue("@FK_BarnID", checkNull(linkingInfoModel.BarnId));
                            cmd.Parameters.AddWithValue("@WorkOrder", string.IsNullOrEmpty(linkingInfoModel.WorkOrder) ? string.Empty : linkingInfoModel.WorkOrder);
                            cmd.Parameters.AddWithValue("@ProjectID", string.IsNullOrEmpty(linkingInfoModel.ProjectId) ? string.Empty : linkingInfoModel.ProjectId);
                            cmd.Parameters.AddWithValue("@Comments", string.IsNullOrEmpty(linkingInfoModel.Comments) ? string.Empty : linkingInfoModel.Comments);
                            cmd.Parameters.AddWithValue("@ScopeComments", string.IsNullOrEmpty(linkingInfoModel.ScopeComments) ? string.Empty : linkingInfoModel.ScopeComments);
                            cmd.Parameters.AddWithValue("@ITN", string.IsNullOrEmpty(linkingInfoModel.ITN) ? string.Empty : linkingInfoModel.ITN);
                            cmd.Parameters.AddWithValue("@FK_ProjectStatusID", checkNull(linkingInfoModel.ProjectStatusId));
                            cmd.Parameters.AddWithValue("@FiberCount", checkNull(linkingInfoModel.FiberCount));
                            cmd.Parameters.AddWithValue("@createdBy", linkingInfoModel.CreatedBy);
                            cmd.Parameters.AddWithValue("@updatedBy", linkingInfoModel.CreatedBy);
                            cmd.Connection = connection;
                            connection.Open();
                            int check = (int)cmd.ExecuteScalar();
                            if (check == 1)
                            {
                                cmd.Parameters["@procId"].Value = 1;
                            }
                            else
                            {
                                connection.Close();
                                result[linkingInfoModel] = "Project Id Already Exists!";
                                return result;
                            }
                            linkingInfoModel.ExecutionLinkingID = (long)cmd.ExecuteScalar();
                            connection.Close();
                            result[linkingInfoModel] = "ok";
                            return result;

                        }
                    }
                }
                catch (Exception ex) { return new Dictionary<ExLinkingInfoModel, string>(); }
            });

        }
          public async Task<Dictionary<ExLinkingInfoModel, string>> UpdateExLinkInfo(ExLinkingInfoModel infoModel)
            {
                return await Task.Run(() =>
                {
                    var result = new Dictionary<ExLinkingInfoModel, string>();
                    if (string.IsNullOrEmpty(infoModel.ProjectId))
                    {
                        result[infoModel] = "ProjectId is Empty!";
                        return result;
                    }
                    try
                    {
                        using (SqlConnection connection = new SqlConnection(this._connectionString))
                        {
                            using (SqlCommand cmd = new SqlCommand())
                            {

                                cmd.CommandText = _storedProcedure;
                                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                                cmd.Parameters.AddWithValue("@procID", 9);
                                cmd.Parameters.AddWithValue("@ExecutionLinkingID", infoModel.ExecutionLinkingID);
                                cmd.Parameters.AddWithValue("@PrimaryKey", string.IsNullOrEmpty(infoModel.PrimaryKey) ? string.Empty : infoModel.PrimaryKey);
                                cmd.Parameters.AddWithValue("@Description", string.IsNullOrEmpty(infoModel.Description) ? string.Empty : infoModel.Description);
                                cmd.Parameters.AddWithValue("@Nickname", string.IsNullOrEmpty(infoModel.Nickname) ? string.Empty : infoModel.Nickname);
                                cmd.Parameters.AddWithValue("@PDID", infoModel.PDId);
                                cmd.Parameters.AddWithValue("@EngineeringYear", string.IsNullOrEmpty(infoModel.EngineeringYear) ? string.Empty : infoModel.EngineeringYear);
                                cmd.Parameters.AddWithValue("@ExecutionYear", string.IsNullOrEmpty(infoModel.ExecutionYear) ? string.Empty : infoModel.ExecutionYear);
                                cmd.Parameters.AddWithValue("@FK_RegionID", checkNull(infoModel.RegionId));
                                cmd.Parameters.AddWithValue("@FK_TechnologyID", checkNull(infoModel.TechnologyId));
                                cmd.Parameters.AddWithValue("@FK_BarnID", checkNull(infoModel.BarnId));
                                cmd.Parameters.AddWithValue("@WorkOrder", string.IsNullOrEmpty(infoModel.WorkOrder) ? string.Empty : infoModel.WorkOrder);
                                cmd.Parameters.AddWithValue("@ProjectID", string.IsNullOrEmpty(infoModel.ProjectId) ? string.Empty : infoModel.ProjectId);
                                cmd.Parameters.AddWithValue("@Comments", string.IsNullOrEmpty(infoModel.Comments) ? string.Empty : infoModel.Comments);
                                cmd.Parameters.AddWithValue("@ScopeComments", string.IsNullOrEmpty(infoModel.ScopeComments) ? string.Empty : infoModel.ScopeComments);
                                cmd.Parameters.AddWithValue("@ITN", string.IsNullOrEmpty(infoModel.ITN) ? string.Empty : infoModel.ITN);
                                cmd.Parameters.AddWithValue("@FK_ProjectStatusID", checkNull(infoModel.ProjectStatusId));
                                cmd.Parameters.AddWithValue("@FiberCount", string.IsNullOrEmpty(infoModel.FiberCount) ? string.Empty : infoModel.FiberCount);
                                cmd.Parameters.AddWithValue("@createdBy", string.Empty);
                                cmd.Parameters.AddWithValue("@updatedBy", infoModel.UpdatedBy);
                                cmd.Connection = connection;
                                connection.Open();
                                int check = (int)cmd.ExecuteScalar();
                                if (check == 1)
                                {
                                    cmd.Parameters["@procId"].Value = 2;
                                }
                                else
                                {
                                    connection.Close();
                                    result[infoModel] = "Project ID Already Exists!";
                                    return result;
                                }
                                cmd.ExecuteNonQuery();
                                connection.Close();
                                result[infoModel] = "ok";
                                return result;
                            }
                        }
                    }
                    catch (Exception ex) { throw ex; }
                });
            }

        public async Task<int> DeleteExLinkInfo(int id)
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
                            cmd.Parameters.AddWithValue("@ExecutionLinkingID", id);
                            cmd.Parameters.AddWithValue("@PrimaryKey", string.Empty);
                            cmd.Parameters.AddWithValue("@Description", string.Empty);
                            cmd.Parameters.AddWithValue("@Nickname", string.Empty);
                            cmd.Parameters.AddWithValue("@PDID", 1);
                            cmd.Parameters.AddWithValue("@EngineeringYear", string.Empty);
                            cmd.Parameters.AddWithValue("@ExecutionYear", string.Empty);
                            cmd.Parameters.AddWithValue("@FK_TechnologyID", 1);
                            cmd.Parameters.AddWithValue("@FK_RegionID", 0);
                            cmd.Parameters.AddWithValue("@FK_BarnID", 0);
                            cmd.Parameters.AddWithValue("@WorkOrder", string.Empty);
                            cmd.Parameters.AddWithValue("@ProjectID", string.Empty);
                            cmd.Parameters.AddWithValue("@Comments", string.Empty);
                            cmd.Parameters.AddWithValue("@ScopeComments", string.Empty);
                            cmd.Parameters.AddWithValue("@ITN", string.Empty);
                            cmd.Parameters.AddWithValue("@FK_ProjectStatusID", 0);
                            cmd.Parameters.AddWithValue("@FiberCount", string.Empty);
                            cmd.Parameters.AddWithValue("@createdBy", string.Empty);
                            cmd.Parameters.AddWithValue("@updatedBy", string.Empty);
                            cmd.Connection = connection;
                            connection.Open();
                            int check = (int)cmd.ExecuteScalar();
                            connection.Close();
                            return check;
                        }
                    }
                }
                catch (Exception) { return 0; }
            });
        }

        public async Task<List<ExLinkingInfoModel>> GetProjectIDsByPDId(int id = 0)
        {
            return await Task.Run(() =>
            {
                var lstLinkInfo = new List<ExLinkingInfoModel>();
                try
                {
                    using (SqlConnection connection = new SqlConnection(this._connectionString))
                    {
                        connection.Open();
                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.CommandText = _storedProcedure;
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@ExecutionLinkingID", 0);
                            cmd.Parameters.AddWithValue("@ProcId", 6);
                            cmd.Parameters.AddWithValue("@PrimaryKey", string.Empty);
                            cmd.Parameters.AddWithValue("@Description", string.Empty);
                            cmd.Parameters.AddWithValue("@Nickname", string.Empty);
                            cmd.Parameters.AddWithValue("@PDID", id);
                            cmd.Parameters.AddWithValue("@EngineeringYear", string.Empty);
                            cmd.Parameters.AddWithValue("@ExecutionYear", string.Empty);
                            cmd.Parameters.AddWithValue("@FK_TechnologyID", 0);
                            cmd.Parameters.AddWithValue("@FK_RegionID", 0);
                            cmd.Parameters.AddWithValue("@FK_BarnID", 0);
                            cmd.Parameters.AddWithValue("@WorkOrder", string.Empty);
                            cmd.Parameters.AddWithValue("@ProjectID", string.Empty);
                            cmd.Parameters.AddWithValue("@Comments", string.Empty);
                            cmd.Parameters.AddWithValue("@ScopeComments", string.Empty);
                            cmd.Parameters.AddWithValue("@ITN", string.Empty);
                            cmd.Parameters.AddWithValue("@FK_ProjectStatusID", 0);
                            cmd.Parameters.AddWithValue("@FiberCount", 0);
                            cmd.Parameters.AddWithValue("@createdBy", string.Empty);
                            cmd.Parameters.AddWithValue("@updatedBy", string.Empty);
                            cmd.Connection = connection;
                            using (SqlDataReader dataReader = cmd.ExecuteReader())
                            {
                                while (dataReader.Read())
                                {
                                    var linkInfo = new ExLinkingInfoModel();
                                    linkInfo.ProjectId = dataReader["ProjectID"].ToString();
                                    lstLinkInfo.Add(linkInfo);
                                }
                            }
                        }
                    }
                    return lstLinkInfo;
                }
                catch (Exception ex) { throw ex; }
            });

        }
        public async Task<Int64> GetLinkInfoIdByProjectId(string id)
        {
            var linkInfo = new ExLinkingInfoModel();
            return await Task.Run(() =>
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(this._connectionString))
                    {
                        connection.Open();
                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.CommandText = _storedProcedure;
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@ExecutionLinkingID", 0);
                            cmd.Parameters.AddWithValue("@ProcId", 7);
                            cmd.Parameters.AddWithValue("@PrimaryKey", string.Empty);
                            cmd.Parameters.AddWithValue("@Description", string.Empty);
                            cmd.Parameters.AddWithValue("@Nickname", string.Empty);
                            cmd.Parameters.AddWithValue("@PDID", 0);
                            cmd.Parameters.AddWithValue("@EngineeringYear", string.Empty);
                            cmd.Parameters.AddWithValue("@ExecutionYear", string.Empty);
                            cmd.Parameters.AddWithValue("@FK_TechnologyID", 0);
                            cmd.Parameters.AddWithValue("@FK_RegionID", 0);
                            cmd.Parameters.AddWithValue("@FK_BarnID", 0);
                            cmd.Parameters.AddWithValue("@WorkOrder", string.Empty);
                            cmd.Parameters.AddWithValue("@ProjectID", id);
                            cmd.Parameters.AddWithValue("@Comments", string.Empty);
                            cmd.Parameters.AddWithValue("@ScopeComments", string.Empty);
                            cmd.Parameters.AddWithValue("@ITN", string.Empty);
                            cmd.Parameters.AddWithValue("@FK_ProjectStatusID", 0);
                            cmd.Parameters.AddWithValue("@FiberCount", 0);
                            cmd.Parameters.AddWithValue("@createdBy", string.Empty);
                            cmd.Parameters.AddWithValue("@updatedBy", string.Empty);
                            cmd.Connection = connection;
                            using (SqlDataReader dataReader = cmd.ExecuteReader())
                            {
                                while (dataReader.Read())
                                {
                                    linkInfo.ExecutionLinkingID = (long)dataReader["ExecutionLinkingID"];
                                }
                            }
                        }
                    }
                    return linkInfo.ExecutionLinkingID;
                }
                catch (Exception ex) { throw ex; }
            });

        }
    }
}
