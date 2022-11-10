using Exelon.Domain;
using Exelon.Domain.Abstractions;
using Exelon.Domain.Common;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Exelon.Infrastructure.Repositories
{
    public class INNERRODROPERepository : IINNERRODROPERepository
    {
        private readonly string _connectionString;
        private readonly string _storedProcedure = "dbo.spINNERRODROPEActions";

        public INNERRODROPERepository(IAppSettings appSettings)
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

        public async Task<List<InnerRodRopeModel>> GetRODROPE(int id = 0)
        {
            return await Task.Run(() =>
            {
                var result = new List<InnerRodRopeModel>();
                try
                {
                    using (SqlConnection connection = new SqlConnection(this._connectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.CommandText = _storedProcedure;
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@RodAndRopeID", id);
                            cmd.Parameters.AddWithValue("@FK_LinkingID", 1);
                            cmd.Parameters.AddWithValue("@InnerductStartDate", DBNull.Value);
                            cmd.Parameters.AddWithValue("@InnerductEndDate", DBNull.Value);
                            cmd.Parameters.AddWithValue("@Comments", string.Empty);
                            cmd.Parameters.AddWithValue("@CreatedBy", string.Empty);
                            cmd.Parameters.AddWithValue("@UpdatedBy", string.Empty);
                            cmd.Connection = connection;
                            if (id == 0)
                                cmd.Parameters.AddWithValue("@procId", 4);
                            else
                                cmd.Parameters.AddWithValue("@procId", 5);

                            connection.Open();
                            using (SqlDataReader dataReader = cmd.ExecuteReader())
                            {
                                while (dataReader.Read())
                                {
                                    var onlyDate = "MM'/'dd'/'yyyy";
                                    var dateWithTime = "MM'/'dd'/'yyyy h:mm tt";
                                    var inner = new InnerRodRopeModel();
                                    inner.RodAndRopeID = (long)dataReader["RodAndRopeID"];
                                    inner.FK_LinkingID = (long)dataReader["ExecutionLinkingID"];
                                    if (dataReader["InnerductStartDate"] != DBNull.Value)
                                        inner.InnerductStartDate = Convert.ToDateTime(dataReader["InnerductStartDate"]);
                                    if (dataReader["InnerductEndDate"] != DBNull.Value)
                                        inner.InnerductEndDate = Convert.ToDateTime(dataReader["InnerductEndDate"]);
                                    if (dataReader["InnerductStartDate"] != DBNull.Value)
                                        inner.StrInnerductStartDate = Convert.ToDateTime(dataReader["InnerductStartDate"]).ToString(onlyDate);
                                    if (dataReader["InnerductEndDate"] != DBNull.Value)
                                        inner.StrInnerductEndDate = Convert.ToDateTime(dataReader["InnerductEndDate"]).ToString(onlyDate);
                                    inner.Comments = dataReader["Comments"].ToString();
                                    inner.IsActive = Convert.ToBoolean(dataReader["IsActive"]);
                                    inner.CreatedBy = dataReader["CreatedBy"].ToString();
                                    inner.CreatedDate = Convert.ToDateTime(dataReader["CreatedDate"]).ToString(dateWithTime);
                                    inner.UpdatedBy = dataReader["UpdatedBy"].ToString();
                                    inner.UpdatedDate = Convert.ToDateTime(dataReader["UpdatedDate"]).ToString(dateWithTime);
                                    result.Add(inner);
                                }
                            }

                            connection.Close();
                            return result;
                        }
                    }
                }
                catch (Exception ex) { return new List<InnerRodRopeModel>(); }
            });
        }


        public async Task<Dictionary<InnerRodRopeModel, string>> CreateRODROPE(InnerRodRopeModel iNNERODROPEModel)
        {
            return await Task.Run(() =>
            {
                var result = new Dictionary<InnerRodRopeModel, string>();
                try
                {
                    using (SqlConnection connection = new SqlConnection(this._connectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.CommandText = _storedProcedure;
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@procId", 6);
                            cmd.Parameters.AddWithValue("@RodAndRopeID", 0);
                            cmd.Parameters.AddWithValue("@FK_LinkingID", iNNERODROPEModel.FK_LinkingID);
                            cmd.Parameters.AddWithValue("@InnerductStartDate", checkNull(iNNERODROPEModel.InnerductStartDate));
                            cmd.Parameters.AddWithValue("@InnerductEndDate", checkNull(iNNERODROPEModel.InnerductEndDate));
                            cmd.Parameters.AddWithValue("@Comments", string.IsNullOrEmpty(iNNERODROPEModel.Comments) ? string.Empty : iNNERODROPEModel.Comments);
                            cmd.Parameters.AddWithValue("@CreatedBy", iNNERODROPEModel.CreatedBy);
                            cmd.Parameters.AddWithValue("@UpdatedBy", iNNERODROPEModel.CreatedBy);
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
                                result[iNNERODROPEModel] = "Linking ID Already Exists!";
                                return result;
                            }
                            iNNERODROPEModel.RodAndRopeID = (long)cmd.ExecuteScalar();
                            connection.Close();
                            result[iNNERODROPEModel] = "ok";
                            return result;

                        }
                    }
                }
                catch (Exception ex) { return new Dictionary<InnerRodRopeModel, string>(); }
            });
        }

        public async Task<InnerRodRopeModel> UpdateRODROPE(InnerRodRopeModel iNNERODROPEModel)
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
                            cmd.Parameters.AddWithValue("@RodAndRopeID", iNNERODROPEModel.RodAndRopeID);
                            cmd.Parameters.AddWithValue("@FK_LinkingID", DBNull.Value);
                            cmd.Parameters.AddWithValue("@InnerductStartDate", checkNull(iNNERODROPEModel.InnerductStartDate));
                            cmd.Parameters.AddWithValue("@InnerductEndDate", checkNull(iNNERODROPEModel.InnerductEndDate));
                            cmd.Parameters.AddWithValue("@Comments", string.IsNullOrEmpty(iNNERODROPEModel.Comments) ? string.Empty : iNNERODROPEModel.Comments);
                            cmd.Parameters.AddWithValue("@CreatedBy", string.Empty);
                            cmd.Parameters.AddWithValue("@UpdatedBy", iNNERODROPEModel.UpdatedBy);
                            cmd.Connection = connection;
                            connection.Open();
                            cmd.ExecuteNonQuery();
                            connection.Close();
                            return iNNERODROPEModel;

                        }
                    }

                }
                catch (Exception ex) { return new InnerRodRopeModel(); }
            });
        }

        public async Task<int> DeleteRODROPE(int id)
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
                            cmd.Parameters.AddWithValue("@RodAndRopeID", id);
                            cmd.Parameters.AddWithValue("@FK_LinkingID", 1);
                            cmd.Parameters.AddWithValue("@InnerductStartDate", DBNull.Value);
                            cmd.Parameters.AddWithValue("@InnerductEndDate", DBNull.Value);
                            cmd.Parameters.AddWithValue("@Comments", string.Empty);
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
