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
    public class PostCompletionRepository : IPostCompletionRepository
    {
        private readonly string _connectionString;
        private readonly string _storedProcedure = "dbo.spPostCompletionActions";

        public PostCompletionRepository(IAppSettings appSettings)
        {
            _connectionString = appSettings.GetConnectionString();
        }

        public async Task<List<PostCompletionModel>> GetPostCompletion(int id = 0)
        {
            return await Task.Run(() =>
           {
               var result = new List<PostCompletionModel>();
               try
               {
                   using (SqlConnection connection = new SqlConnection(this._connectionString))
                   {
                       using (SqlCommand cmd = new SqlCommand())
                       {

                           cmd.CommandText = _storedProcedure;
                           cmd.CommandType = System.Data.CommandType.StoredProcedure;
                           cmd.Parameters.AddWithValue("@PostCompletionID", id);
                           cmd.Parameters.AddWithValue("@FK_LinkingID", 0);
                           cmd.Parameters.AddWithValue("@AsBuiltsReceived", string.Empty);
                           cmd.Parameters.AddWithValue("@LocationsReadyToInspect", string.Empty);
                           cmd.Parameters.AddWithValue("@LocationsInspected", string.Empty);
                           cmd.Parameters.AddWithValue("@TEDUpdated", string.Empty);
                           cmd.Parameters.AddWithValue("@PNIUpdatedIS", string.Empty);
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
                                   var dateWithTime = "MM'/'dd'/'yyyy h:mm tt";
                                   var post = new PostCompletionModel();
                                   post.PostCompletionID = (long)dataReader["PostCompletionID"];
                                   post.FK_LinkingID = (long)dataReader["ExecutionLinkingID"];
                                   post.AsBuiltsReceived = dataReader["AsBuiltsReceived"].ToString();
                                   post.LocationsInspected = dataReader["LocationsInspected"].ToString();
                                   post.LocationsReadyToInspect = dataReader["LocationsReadyToInspect"].ToString();
                                   post.TEDUpdated = dataReader["TEDUpdated"].ToString();
                                   post.PNIUpdatedIS = dataReader["PNIUpdatedIS"].ToString();
                                   post.IsActive = Convert.ToBoolean(dataReader["IsActive"]);
                                   post.CreatedBy = dataReader["CreatedBy"].ToString();
                                   post.CreatedDate = Convert.ToDateTime(dataReader["CreatedDate"]).ToString(dateWithTime);
                                   post.UpdatedBy = dataReader["UpdateBy"].ToString();
                                   post.UpdatedDate = Convert.ToDateTime(dataReader["UpdatedDate"]).ToString(dateWithTime);
                                   result.Add(post);

                               }
                           }

                           connection.Close();

                           return result;
                       }
                   }
               }
               catch (Exception ex) { return new List<PostCompletionModel>(); }
           });

        }


            public async Task<Dictionary<PostCompletionModel, string>> CreatePostCompletion(PostCompletionModel postCompletionModel)
            {

                return await Task.Run(() =>
                {
                    var result = new Dictionary<PostCompletionModel, string>();
                    try
                    {
                        using (SqlConnection connection = new SqlConnection(this._connectionString))
                        {
                            using (SqlCommand cmd = new SqlCommand())
                            {
                                cmd.CommandText = _storedProcedure;
                                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                                cmd.Parameters.AddWithValue("@procId", 6);
                                cmd.Parameters.AddWithValue("@PostCompletionID", postCompletionModel.PostCompletionID);
                                cmd.Parameters.AddWithValue("@FK_LinkingID", postCompletionModel.FK_LinkingID);
                                cmd.Parameters.AddWithValue("@AsBuiltsReceived",string.IsNullOrEmpty(postCompletionModel.AsBuiltsReceived)?string.Empty:postCompletionModel.AsBuiltsReceived);
                                cmd.Parameters.AddWithValue("@LocationsReadyToInspect", string.IsNullOrEmpty(postCompletionModel.LocationsReadyToInspect)?string.Empty:postCompletionModel.LocationsReadyToInspect);
                                cmd.Parameters.AddWithValue("@LocationsInspected", string.IsNullOrEmpty(postCompletionModel.LocationsInspected)?string.Empty:postCompletionModel.LocationsInspected);
                                cmd.Parameters.AddWithValue("@TEDUpdated", string.IsNullOrEmpty(postCompletionModel.TEDUpdated)?string.Empty:postCompletionModel.TEDUpdated);
                                cmd.Parameters.AddWithValue("@PNIUpdatedIS", string.IsNullOrEmpty(postCompletionModel.PNIUpdatedIS)?string.Empty:postCompletionModel.PNIUpdatedIS);
                                cmd.Parameters.AddWithValue("@CreatedBy", postCompletionModel.CreatedBy);
                                cmd.Parameters.AddWithValue("@UpdatedBy", postCompletionModel.CreatedBy);
                                cmd.Connection = connection;
                                connection.Open();
                                int check = (int)cmd.ExecuteScalar();
                                if(check == 1)
                                {
                                    cmd.Parameters["@procId"].Value = 1;
                                }
                                else
                                {
                                    connection.Close();
                                    result[postCompletionModel] = "LinkingId Already Exists!";
                                    return result;
                                }

                                postCompletionModel.PostCompletionID = (long)cmd.ExecuteScalar();
                                connection.Close();
                                result[postCompletionModel] = "ok"; 
                                return result;

                            }
                        }
                    }
                    catch (Exception ex) { return new Dictionary<PostCompletionModel, string>(); }
                });
            

        }

        public async Task<PostCompletionModel> UpdatePostCompletion(PostCompletionModel postCompletionModel)
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
                            cmd.Parameters.AddWithValue("@procId", 2);
                            cmd.Parameters.AddWithValue("@PostCompletionID", postCompletionModel.PostCompletionID);
                            cmd.Parameters.AddWithValue("@FK_LinkingID", postCompletionModel.FK_LinkingID);
                            cmd.Parameters.AddWithValue("@AsBuiltsReceived", string.IsNullOrEmpty(postCompletionModel.AsBuiltsReceived) ? string.Empty : postCompletionModel.AsBuiltsReceived);
                            cmd.Parameters.AddWithValue("@LocationsReadyToInspect", string.IsNullOrEmpty(postCompletionModel.LocationsReadyToInspect) ? string.Empty : postCompletionModel.LocationsReadyToInspect);
                            cmd.Parameters.AddWithValue("@LocationsInspected", string.IsNullOrEmpty(postCompletionModel.LocationsInspected) ? string.Empty : postCompletionModel.LocationsInspected);
                            cmd.Parameters.AddWithValue("@TEDUpdated", string.IsNullOrEmpty(postCompletionModel.TEDUpdated) ? string.Empty : postCompletionModel.TEDUpdated);
                            cmd.Parameters.AddWithValue("@PNIUpdatedIS", string.IsNullOrEmpty(postCompletionModel.PNIUpdatedIS) ? string.Empty : postCompletionModel.PNIUpdatedIS);
                            cmd.Parameters.AddWithValue("@CreatedBy", string.Empty);
                            cmd.Parameters.AddWithValue("@UpdatedBy", postCompletionModel.UpdatedBy);
                            cmd.Connection = connection;
                            connection.Open();
                            cmd.ExecuteNonQuery();
                            connection.Close();
                            return postCompletionModel;

                        }
                    }
                }
                catch (Exception ex) { return new PostCompletionModel(); }
            });
        }


        public async Task<int> DeletePostCompletion(int id)
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
                            cmd.Parameters.AddWithValue("@PostCompletionID", id);
                            cmd.Parameters.AddWithValue("@FK_LinkingID", 0);
                            cmd.Parameters.AddWithValue("@AsBuiltsReceived", string.Empty);
                            cmd.Parameters.AddWithValue("@LocationsReadyToInspect", string.Empty);
                            cmd.Parameters.AddWithValue("@LocationsInspected", string.Empty);
                            cmd.Parameters.AddWithValue("@TEDUpdated", string.Empty);
                            cmd.Parameters.AddWithValue("@PNIUpdatedIS", string.Empty);
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
