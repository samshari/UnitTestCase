using Exelon.Domain;
using Exelon.Domain.Abstractions;
using Exelon.Domain.Common;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Exelon.Infrastructure.Repositories
{
    public class PPReplacementRepository : IPPReplacementRepository
    {
        private readonly string _connectionString;
        private readonly string _storedProcedure = "dbo.spPPREPLACEMENTActions";

        public PPReplacementRepository(IAppSettings appSettings)
        {
            _connectionString = appSettings.GetConnectionString();
        }

        public async  Task<List<PPREPLACEMENTModel>> GetPPREPLACE(int id = 0)
        {
            return await Task.Run(() =>
            {
                var result = new List<PPREPLACEMENTModel>();
                try
                {
                    using(SqlConnection connection = new SqlConnection(this._connectionString))
                    {
                        connection.Open();
                        using(SqlCommand cmd = new SqlCommand())
                        {
                            cmd.CommandText = _storedProcedure;
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@PolesRepacementID", id);
                            cmd.Parameters.AddWithValue("@FK_LinkingID", 1);
                            cmd.Parameters.AddWithValue("@TotalNoOfPolesInRoute", 1);
                            cmd.Parameters.AddWithValue("@ReplacedNoOfOsmos", 1);
                            cmd.Parameters.AddWithValue("@ReplacedLoading", 1);
                            cmd.Parameters.AddWithValue("@ReplacedClearance", 1);
                            cmd.Parameters.AddWithValue("@ReplacedReliability", 1);
                            cmd.Parameters.AddWithValue("@NewOrMidspanPoles", 1);
                            cmd.Parameters.AddWithValue("@TotalRelocatedPoles", 1);
                            cmd.Parameters.AddWithValue("@TotalPolesNeedingReplaced", 1);
                            cmd.Parameters.AddWithValue("@NewAnchor", 1);
                            cmd.Parameters.AddWithValue("@OtherWorkOnPole", 1);
                            cmd.Parameters.AddWithValue("@PoleReplacementPercentage", 1.11);
                            cmd.Parameters.AddWithValue("@StepID", 0);
                            cmd.Parameters.AddWithValue("@CreatedBy", string.Empty);
                            cmd.Parameters.AddWithValue("@updatedBy", string.Empty);
                            cmd.Connection = connection;

                            if (id == 0)
                                cmd.Parameters.AddWithValue("@procId", 4);
                            else
                                cmd.Parameters.AddWithValue("@procId", 5);

                            using (SqlDataReader dataReader = cmd.ExecuteReader())
                            {
                                while (dataReader.Read())
                                {
                                    var dateWithTime = "MM'/'dd'/'yyyy h:mm tt";
                                    var pprep = new PPREPLACEMENTModel();
                                    pprep.PolesRepacementID = (long)dataReader["PolesRepacementID"];
                                    pprep.FK_LinkingID = (long)dataReader["FK_LinkingID"];
                                    pprep.TotalNoOfPolesInRoute = (int)dataReader["TotalNoOfPolesInRoute"];
                                    pprep.ReplacedNoOfOsmos = (int)dataReader["ReplacedNoOfOsmos"];
                                    pprep.ReplacedReliability = (int)dataReader["ReplacedReliability"];
                                    pprep.TotalPolesNeedingReplaced = (int)dataReader["TotalPolesNeedingReplaced"];
                                    pprep.ReplacedClearance = (int)dataReader["ReplacedClearance"];
                                    pprep.ReplacedLoading = (int)dataReader["ReplacedLoading"];
                                    pprep.NewOrMidspanPoles = (int)dataReader["NewOrMidspanPoles"];
                                    pprep.TotalRelocatedPoles = (int)dataReader["TotalRelocatedPoles"];
                                    pprep.NewAnchor = (int)dataReader["NewAnchor"];
                                    pprep.OtherWorkOnPole = (int)dataReader["OtherWorkOnPole"];
                                    pprep.PoleReplacementPercentage = dataReader.GetDecimal(dataReader.GetOrdinal("PoleReplacementPercentage"));
                                    pprep.StepID = (int)dataReader["StepID"];
                                    pprep.IsActive = Convert.ToBoolean(dataReader["IsActive"]);
                                    pprep.CreatedBy = dataReader["CreatedBy"].ToString();
                                    pprep.CreatedDate = Convert.ToDateTime(dataReader["CreatedDate"]).ToString(dateWithTime);
                                    pprep.UpdatedBy = dataReader["UpdatedBy"].ToString();
                                    pprep.UpdatedDate = Convert.ToDateTime(dataReader["UpdatedDate"]).ToString(dateWithTime);
                                    result.Add(pprep);
                                }
                            }
                        }

                        
                    }


                    return result;
                }
                catch(Exception ex) { return new List<PPREPLACEMENTModel>(); }
            });
        }

        public async Task<Dictionary<PPREPLACEMENTModel, string>> CreatePPREPLACE(PPREPLACEMENTModel pPREPLACEMENTModel)
        {
            return await Task.Run(() =>
            {
               var result = new  Dictionary<PPREPLACEMENTModel,string>();
               try
               {
                   using (SqlConnection connection = new SqlConnection(this._connectionString))
                   {
                       
                       using (SqlCommand cmd = new SqlCommand())
                       {
                           cmd.CommandText = _storedProcedure;
                           cmd.CommandType = System.Data.CommandType.StoredProcedure;
                           cmd.Parameters.AddWithValue("@procId", 6);
                           cmd.Parameters.AddWithValue("@PolesRepacementID",1);
                           cmd.Parameters.AddWithValue("@FK_LinkingID", pPREPLACEMENTModel.FK_LinkingID);
                           cmd.Parameters.AddWithValue("@TotalNoOfPolesInRoute", pPREPLACEMENTModel.TotalNoOfPolesInRoute);
                           cmd.Parameters.AddWithValue("@ReplacedNoOfOsmos", pPREPLACEMENTModel.ReplacedNoOfOsmos);
                           cmd.Parameters.AddWithValue("@ReplacedLoading", pPREPLACEMENTModel.ReplacedLoading);
                           cmd.Parameters.AddWithValue("@ReplacedClearance", pPREPLACEMENTModel.ReplacedClearance);
                           cmd.Parameters.AddWithValue("@ReplacedReliability", pPREPLACEMENTModel.ReplacedReliability);
                           cmd.Parameters.AddWithValue("@NewOrMidspanPoles", pPREPLACEMENTModel.NewOrMidspanPoles);
                           cmd.Parameters.AddWithValue("@TotalRelocatedPoles", pPREPLACEMENTModel.TotalRelocatedPoles);
                           cmd.Parameters.AddWithValue("@TotalPolesNeedingReplaced", pPREPLACEMENTModel.TotalPolesNeedingReplaced);
                           cmd.Parameters.AddWithValue("@NewAnchor", pPREPLACEMENTModel.NewAnchor);
                           cmd.Parameters.AddWithValue("@OtherWorkOnPole", pPREPLACEMENTModel.OtherWorkOnPole);
                           cmd.Parameters.AddWithValue("@PoleReplacementPercentage", pPREPLACEMENTModel.PoleReplacementPercentage);
                           cmd.Parameters.AddWithValue("@StepID", pPREPLACEMENTModel.StepID);
                           cmd.Parameters.AddWithValue("@CreatedBy", pPREPLACEMENTModel.CreatedBy);
                            cmd.Parameters.AddWithValue("@updatedBy", pPREPLACEMENTModel.CreatedBy);
                            cmd.Connection = connection;
                           connection.Open();
                           int check = (int)cmd.ExecuteScalar();
                           if(check == 1)
                           {
                               cmd.Parameters["@procId"].Value = 1;
                               pPREPLACEMENTModel.PolesRepacementID = (long)cmd.ExecuteScalar();
                           }
                           else
                           {
                               connection.Close();
                               result[pPREPLACEMENTModel] = "Linking Id Already Exists!";
                               return result;
                           }
                           connection.Close();
                           result[pPREPLACEMENTModel] = "ok";
                           return result;


                       }
                   }

               }
               catch (Exception ex) { return new Dictionary<PPREPLACEMENTModel,string>(); }
           });
        }

        public async Task<PPREPLACEMENTModel> UpdatePPREPLACE(PPREPLACEMENTModel pPREPLACEMENTModel)
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
                            cmd.Parameters.AddWithValue("@PolesRepacementID", pPREPLACEMENTModel.PolesRepacementID);
                            cmd.Parameters.AddWithValue("@FK_LinkingID", pPREPLACEMENTModel.FK_LinkingID);
                            cmd.Parameters.AddWithValue("@TotalNoOfPolesInRoute", pPREPLACEMENTModel.TotalNoOfPolesInRoute);
                            cmd.Parameters.AddWithValue("@ReplacedNoOfOsmos", pPREPLACEMENTModel.ReplacedNoOfOsmos);
                            cmd.Parameters.AddWithValue("@ReplacedLoading", pPREPLACEMENTModel.ReplacedLoading);
                            cmd.Parameters.AddWithValue("@ReplacedClearance", pPREPLACEMENTModel.ReplacedClearance);
                            cmd.Parameters.AddWithValue("@ReplacedReliability", pPREPLACEMENTModel.ReplacedReliability);
                            cmd.Parameters.AddWithValue("@NewOrMidspanPoles", pPREPLACEMENTModel.NewOrMidspanPoles);
                            cmd.Parameters.AddWithValue("@TotalRelocatedPoles", pPREPLACEMENTModel.TotalRelocatedPoles);
                            cmd.Parameters.AddWithValue("@TotalPolesNeedingReplaced", pPREPLACEMENTModel.TotalPolesNeedingReplaced);
                            cmd.Parameters.AddWithValue("@NewAnchor", pPREPLACEMENTModel.NewAnchor);
                            cmd.Parameters.AddWithValue("@OtherWorkOnPole", pPREPLACEMENTModel.OtherWorkOnPole);
                            cmd.Parameters.AddWithValue("@PoleReplacementPercentage", pPREPLACEMENTModel.PoleReplacementPercentage);
                            cmd.Parameters.AddWithValue("@StepID", pPREPLACEMENTModel.StepID);
                            cmd.Parameters.AddWithValue("@CreatedBy", string.Empty);
                            cmd.Parameters.AddWithValue("@updatedBy", pPREPLACEMENTModel.UpdatedBy);
                            cmd.Connection = connection;
                            connection.Open();
                            cmd.ExecuteNonQuery();
                            connection.Close();

                            return pPREPLACEMENTModel;

                        }
                    }

                }
                catch (Exception ex) { return new PPREPLACEMENTModel(); }
            });

        }

        public async Task<int> DeletePPREPLACE(int id)
        {
            return await Task.Run(() =>
            {
                var result = new List<PPREPLACEMENTModel>();
                try
                {
                    using (SqlConnection connection = new SqlConnection(this._connectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.CommandText = _storedProcedure;
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@procId", 3);
                            cmd.Parameters.AddWithValue("@PolesRepacementID", id);
                            cmd.Parameters.AddWithValue("@FK_LinkingID", 1);
                            cmd.Parameters.AddWithValue("@TotalNoOfPolesInRoute", 1);
                            cmd.Parameters.AddWithValue("@ReplacedNoOfOsmos", 1);
                            cmd.Parameters.AddWithValue("@ReplacedLoading", 1);
                            cmd.Parameters.AddWithValue("@ReplacedClearance", 1);
                            cmd.Parameters.AddWithValue("@ReplacedReliability", 1);
                            cmd.Parameters.AddWithValue("@NewOrMidspanPoles", 1);
                            cmd.Parameters.AddWithValue("@TotalRelocatedPoles", 1);
                            cmd.Parameters.AddWithValue("@TotalPolesNeedingReplaced", 1);
                            cmd.Parameters.AddWithValue("@NewAnchor", 1);
                            cmd.Parameters.AddWithValue("@OtherWorkOnPole", 1);
                            cmd.Parameters.AddWithValue("@PoleReplacementPercentage", 1.11);
                            cmd.Parameters.AddWithValue("@StepID", 1);
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
