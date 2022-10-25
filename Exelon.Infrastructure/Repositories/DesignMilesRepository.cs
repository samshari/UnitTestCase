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
    public class DesignMilesRepository : IDesignMilesRepository
    {
        private readonly string _connectionString;
        private readonly string _storedProcedure = "dbo.spMDESIGNActions";

        public DesignMilesRepository(IAppSettings appSettings)
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

        public async Task<List<DesignMilesModel>> GetDESIGN(int id = 0)
        {
            return await Task.Run(() =>
            {
                var result = new List<DesignMilesModel>();
                try
                {
                    using (SqlConnection connection = new SqlConnection(this._connectionString))
                    {
                        connection.Open();
                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.CommandText = _storedProcedure;
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@DesignMilesID", id);
                            cmd.Parameters.AddWithValue("@FK_LinkingID", 0);
                            cmd.Parameters.AddWithValue("@FK_StepID", 0);
                            cmd.Parameters.AddWithValue("@UGMiles", 0.00);
                            cmd.Parameters.AddWithValue("@OHMiles", 0.00);
                            cmd.Parameters.AddWithValue("@TotalMiles", 0.00);
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
                                    var mdesign = new DesignMilesModel();
                                    var dateWithTime = "MM'/'dd'/'yyyy h:mm tt";
                                    mdesign.DesignMilesID = (long)dataReader["DesignMilesID"];
                                    mdesign.FK_LinkingID = (long)dataReader["FK_LinkingID"];
                                    mdesign.FK_StepID = (int)dataReader["FK_StepID"];
                                    if (dataReader["UGMiles"] != DBNull.Value)
                                        mdesign.UGMiles = dataReader.GetDecimal(dataReader.GetOrdinal("UGMiles"));
                                    if (dataReader["OHMiles"] != DBNull.Value)
                                        mdesign.OHMiles = dataReader.GetDecimal(dataReader.GetOrdinal("OHMiles"));
                                    if (dataReader["TotalMiles"] != DBNull.Value)
                                        mdesign.TotalMiles = dataReader.GetDecimal(dataReader.GetOrdinal("TotalMiles"));
                                    mdesign.IsActive = Convert.ToBoolean(dataReader["IsActive"]);
                                    mdesign.CreatedBy = dataReader["CreatedBy"].ToString();
                                    mdesign.CreatedDate = Convert.ToDateTime(dataReader["CreatedDate"]).ToString(dateWithTime);
                                    mdesign.UpdatedBy = dataReader["UpdatedBy"].ToString();
                                    mdesign.UpdatedDate = Convert.ToDateTime(dataReader["UpdatedDate"]).ToString(dateWithTime);
                                    result.Add(mdesign);
                                }
                            }

                        }
                        connection.Close();
                    }

                    return result;
                }
                catch (Exception ex) { return new List<DesignMilesModel>(); }
            });
        }



        public async Task<Dictionary<DesignMilesModel, string>> CreateDESIGN(DesignMilesModel dESIGNMILESModel)
        {
            return await Task.Run(() =>
            {
                var result = new Dictionary<DesignMilesModel, string>();
                try
                {
                    using (SqlConnection connection = new SqlConnection(this._connectionString))
                    {
                        
                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.CommandText = _storedProcedure;
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@procId", 6);
                            cmd.Parameters.AddWithValue("@DesignMilesID", dESIGNMILESModel.DesignMilesID);
                            cmd.Parameters.AddWithValue("@FK_LinkingID", dESIGNMILESModel.FK_LinkingID);
                            cmd.Parameters.AddWithValue("@FK_StepID", dESIGNMILESModel.FK_StepID);
                            cmd.Parameters.AddWithValue("@OHMiles",checkNull(dESIGNMILESModel.OHMiles));
                            cmd.Parameters.AddWithValue("@UGMiles",checkNull(dESIGNMILESModel.UGMiles));
                            cmd.Parameters.AddWithValue("@TotalMiles",checkNull(dESIGNMILESModel.TotalMiles));
                            cmd.Parameters.AddWithValue("@CreatedBy", dESIGNMILESModel.CreatedBy);
                            cmd.Parameters.AddWithValue("@updatedBy", dESIGNMILESModel.CreatedBy);
                            cmd.Connection = connection;
                            connection.Open();
                            int check = (int)cmd.ExecuteScalar();
                            if (check == 1)
                            {
                                cmd.Parameters["@procId"].Value = 1;
                                dESIGNMILESModel.DesignMilesID = (long)cmd.ExecuteScalar();
                            }
                            else
                            {
                                connection.Close();
                                result[dESIGNMILESModel] = "Linking Id Already Exists!";
                                return result;
                            }
                            connection.Close();
                            result[dESIGNMILESModel] = "ok";
                            return result;

                        }
                    }
                }
                catch (Exception ex) { return new Dictionary<DesignMilesModel, string>(); }
            });
        }

        public async Task<DesignMilesModel> UpdateDESIGN(DesignMilesModel dESIGNMILESModel)
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
                            cmd.Parameters.AddWithValue("@DesignMilesID", dESIGNMILESModel.DesignMilesID);
                            cmd.Parameters.AddWithValue("@FK_LinkingID", dESIGNMILESModel.FK_LinkingID);
                            cmd.Parameters.AddWithValue("@FK_StepID", dESIGNMILESModel.FK_StepID);
                            cmd.Parameters.AddWithValue("@OHMiles", checkNull(dESIGNMILESModel.OHMiles));
                            cmd.Parameters.AddWithValue("@UGMiles", checkNull(dESIGNMILESModel.UGMiles));
                            cmd.Parameters.AddWithValue("@TotalMiles", checkNull(dESIGNMILESModel.TotalMiles));
                            cmd.Parameters.AddWithValue("@CreatedBy", string.Empty);
                            cmd.Parameters.AddWithValue("@updatedBy", dESIGNMILESModel.UpdatedBy);
                            cmd.Connection = connection;

                            connection.Open();

                            var mdesign = new DesignMilesModel();
                            using (SqlDataReader dataReader = cmd.ExecuteReader())
                            {
                                while (dataReader.Read())
                                {
                                    
                                    mdesign.DesignMilesID = (long)dataReader["DesignMilesID"];
                                    mdesign.FK_LinkingID = (long)dataReader["FK_LinkingID"];
                                    mdesign.FK_StepID = (int)dataReader["FK_StepID"];
                                    if (dataReader["UGMiles"] != DBNull.Value)
                                        mdesign.UGMiles = dataReader.GetDecimal(dataReader.GetOrdinal("UGMiles"));
                                    if (dataReader["OHMiles"] != DBNull.Value)
                                        mdesign.OHMiles = dataReader.GetDecimal(dataReader.GetOrdinal("OHMiles"));
                                    if (dataReader["TotalMiles"] != DBNull.Value)
                                        mdesign.TotalMiles = dataReader.GetDecimal(dataReader.GetOrdinal("TotalMiles"));
                                    
                                }
                            }

                            cmd.Parameters["@OHMiles"].Value =checkNullWithValue(dESIGNMILESModel.OHMiles,mdesign.OHMiles);
                            cmd.Parameters["@UGMiles"].Value =checkNullWithValue(dESIGNMILESModel.UGMiles,mdesign.UGMiles);
                            cmd.Parameters["@TotalMiles"].Value =checkNullWithValue(dESIGNMILESModel.TotalMiles,mdesign.TotalMiles);
                            cmd.Parameters["@procId"].Value = 2;
                            cmd.ExecuteNonQuery();
                            connection.Close();
                            return dESIGNMILESModel;

                        }
                    }
                }
                catch (Exception ex) { return new DesignMilesModel(); }
            });
        }

        public async Task<int> DeleteDESIGN(int id)
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
                            cmd.Parameters.AddWithValue("@DesignMilesID", id);
                            cmd.Parameters.AddWithValue("@FK_LinkingID", 0);
                            cmd.Parameters.AddWithValue("@FK_StepID", 0);
                            cmd.Parameters.AddWithValue("@UGMiles", 0.00);
                            cmd.Parameters.AddWithValue("@OHMiles", 0.00);
                            cmd.Parameters.AddWithValue("@TotalMiles", 0.00);
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

