#region [Namespaces]
using Exelon.Domain;
using Exelon.Domain.Abstractions;
using Exelon.Domain.Common;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
#endregion

namespace Exelon.Infrastructure.Repositories
{
    public class DeviceRepository : IDeviceRepository
    {
        private readonly string _connectionString;
        private readonly string _storedProcedure = "dbo.spMDEVICEActions";

        public DeviceRepository(IAppSettings appSettings)
        {
            _connectionString = appSettings.GetConnectionString();
        }
        public async Task<List<DeviceModel>> GetDevice(int id = 0)
        {
            return await Task.Run(() =>
            {
                var result = new List<DeviceModel>();
                try
                {
                    using (SqlConnection connection = new SqlConnection(this._connectionString))
                    {
                        connection.Open();
                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.CommandText = _storedProcedure;
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@DeviceID", id);
                            cmd.Parameters.AddWithValue("@FK_LinkingID", 1);
                            cmd.Parameters.AddWithValue("@FK_StepID", 1);
                            cmd.Parameters.AddWithValue("@TotalDevices", 1);
                            cmd.Parameters.AddWithValue("@DeviceType", string.Empty);
                            cmd.Parameters.AddWithValue("@CreatedBy", string.Empty);
                            cmd.Parameters.AddWithValue("@UpdatedBy", string.Empty);
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
                                    var mdevice = new DeviceModel();
                                    mdevice.DeviceId = (long)dataReader["DeviceID"];
                                    mdevice.LinkingId = (long)dataReader["FK_LinkingID"];
                                    mdevice.StepId = (int)dataReader["FK_StepID"];
                                    mdevice.TotalDevices = (int)dataReader["TotalDevices"];
                                    mdevice.DeviceType = dataReader["DeviceType"].ToString();
                                    mdevice.IsActive = Convert.ToBoolean(dataReader["IsActive"]);
                                    mdevice.CreatedBy = dataReader["CreatedBy"].ToString();
                                    mdevice.CreatedDate = Convert.ToDateTime(dataReader["CreatedDate"]).ToString(dateWithTime);
                                    mdevice.UpdatedBy = dataReader["UpdatedBy"].ToString();
                                    mdevice.UpdatedDate = Convert.ToDateTime(dataReader["UpdatedDate"]).ToString(dateWithTime);
                                    result.Add(mdevice);
                                }
                            }
                        }
                        connection.Close();
                    }
                    return result;
                }
                catch (Exception) { return new List<DeviceModel>(); }
            });
        }
        public async Task<Dictionary<DeviceModel, string>> CreateDevice(DeviceModel model)
        {
            return await Task.Run(() =>
            {
                var result = new Dictionary<DeviceModel, string>();
                try
                {
                    using (SqlConnection connection = new SqlConnection(this._connectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.CommandText = _storedProcedure;
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@procId", 6);
                            cmd.Parameters.AddWithValue("@DeviceID", model.DeviceId);
                            cmd.Parameters.AddWithValue("@FK_LinkingID", model.LinkingId);
                            cmd.Parameters.AddWithValue("@FK_StepID", model.StepId);
                            cmd.Parameters.AddWithValue("@TotalDevices", model.TotalDevices);
                            cmd.Parameters.AddWithValue("@DeviceType", string.IsNullOrEmpty(model.DeviceType) ? string.Empty : model.DeviceType);
                            cmd.Parameters.AddWithValue("@CreatedBy", model.CreatedBy);
                            cmd.Parameters.AddWithValue("@UpdatedBy", model.CreatedBy);
                            cmd.Connection = connection;
                            connection.Open();
                            int check = (int)cmd.ExecuteScalar();
                            if (check == 1)
                            {
                                cmd.Parameters["@procId"].Value = 1;
                                model.DeviceId = (long)cmd.ExecuteScalar();
                            }
                            else
                            {
                                connection.Close();
                                result[model] = "Linking Id Already Exists!";
                                return result;
                            }
                            connection.Close();
                            result[model] = "ok";
                            return result;
                        }
                    }
                }
                catch (Exception) { return new Dictionary<DeviceModel, string>(); }
            });
        }
        public async Task<DeviceModel> UpdateDevice(DeviceModel model)
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
                            cmd.Parameters.AddWithValue("@DeviceID", model.DeviceId);
                            cmd.Parameters.AddWithValue("@FK_LinkingID", model.LinkingId);
                            cmd.Parameters.AddWithValue("@FK_StepID", model.StepId);
                            cmd.Parameters.AddWithValue("@TotalDevices", model.TotalDevices);
                            cmd.Parameters.AddWithValue("@DeviceType", string.IsNullOrEmpty(model.DeviceType) ? string.Empty : model.DeviceType);
                            cmd.Parameters.AddWithValue("@CreatedBy", string.Empty);
                            cmd.Parameters.AddWithValue("@UpdatedBy", model.UpdatedBy);
                            cmd.Connection = connection;

                            connection.Open();
                            var mdevice = new DeviceModel();
                            using (SqlDataReader dataReader = cmd.ExecuteReader())
                            {
                                while (dataReader.Read())
                                {
                                    mdevice.DeviceId = (long)dataReader["DeviceID"];
                                    mdevice.LinkingId = (long)dataReader["FK_LinkingID"];
                                    mdevice.StepId = (int)dataReader["FK_StepID"];
                                    mdevice.TotalDevices = (int)dataReader["TotalDevices"];
                                    mdevice.DeviceType = dataReader["DeviceType"].ToString();
                                }
                            }
                            if (string.IsNullOrEmpty(model.TotalDevices.ToString()))
                                model.TotalDevices = mdevice.TotalDevices;
                            if (string.IsNullOrEmpty(model.DeviceType))
                                model.DeviceType = mdevice.DeviceType;
                            cmd.Parameters["@procId"].Value = 2;
                            cmd.ExecuteNonQuery();
                            connection.Close();
                            return model;
                        }
                    }
                }
                catch (Exception) { return new DeviceModel(); }
            });
        }
        public async Task<int> DeleteDevice(int id)
        {
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
                            cmd.Parameters.AddWithValue("@procId", 3);
                            cmd.Parameters.AddWithValue("@DeviceID", id);
                            cmd.Parameters.AddWithValue("@FK_LinkingID", id);
                            cmd.Parameters.AddWithValue("@FK_StepID", 1);
                            cmd.Parameters.AddWithValue("@TotalDevices", 1);
                            cmd.Parameters.AddWithValue("@DeviceType", string.Empty);
                            cmd.Parameters.AddWithValue("@CreatedBy", string.Empty);
                            cmd.Parameters.AddWithValue("@UpdatedBy", string.Empty);
                            cmd.Connection = connection;
                            cmd.ExecuteScalar();
                            return 1;
                        }
                    }
                }
                catch (Exception) { return 0; }
            });
        }

        #region [Execution Device]
        #region [Get Execution Device]
        /// <summary>
        /// Get Execution Device
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ExecutionDeviceModel> GetExecutionDevice(int id)
        {
            return await Task.Run(() =>
            {
                var result = new ExecutionDeviceModel();
                try
                {
                    using (SqlConnection connection = new SqlConnection(this._connectionString))
                    {
                        connection.Open();
                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.CommandText = "sp_ExecutionDeviceActions";
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@procId", 3);
                            cmd.Parameters.AddWithValue("@executionDeviceId", id);
                            cmd.Parameters.AddWithValue("@executionLinkingId", 0);
                            cmd.Parameters.AddWithValue("@installedDevices", 0);
                            cmd.Parameters.AddWithValue("@CreatedBy", string.Empty);
                            cmd.Parameters.AddWithValue("@UpdatedBy", string.Empty);
                            cmd.Connection = connection;

                            using (SqlDataReader dataReader = cmd.ExecuteReader())
                            {
                                while (dataReader.Read())
                                {
                                    var model = new ExecutionDeviceModel();
                                    model.ExecutionDeviceId = (long)dataReader["ExecutionDeviceID"];
                                    model.ExecutionLinkidId = (long)dataReader["ExecutionLinkidID"];
                                    model.InstalledDevice = (int)dataReader["InstalledDevice"];
                                    model.CreatedBy = dataReader["CreatedBy"].ToString();
                                    model.UpdatedBy = dataReader["UpdatedBy"].ToString();
                                    result = model;
                                }
                            }
                        }
                        connection.Close();
                    }
                    return result;
                }
                catch (Exception) {return new ExecutionDeviceModel();}
            });
        }
        #endregion

        #region [Execution Device]
        #region [Get Execution Device By Link id]
        /// <summary>
        /// Get Execution Device
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ExecutionDeviceModel> GetExecutionDeviceBYLinkId(int id)
        {
            return await Task.Run(() =>
            {
                var result = new ExecutionDeviceModel();
                try
                {
                    using (SqlConnection connection = new SqlConnection(this._connectionString))
                    {
                        connection.Open();
                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.CommandText = "sp_ExecutionDeviceActions";
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@procId", 4);
                            cmd.Parameters.AddWithValue("@executionDeviceId", 0);
                            cmd.Parameters.AddWithValue("@executionLinkingId", id);
                            cmd.Parameters.AddWithValue("@installedDevices", 0);
                            cmd.Parameters.AddWithValue("@CreatedBy", string.Empty);
                            cmd.Parameters.AddWithValue("@UpdatedBy", string.Empty);
                            cmd.Connection = connection;

                            using (SqlDataReader dataReader = cmd.ExecuteReader())
                            {
                                while (dataReader.Read())
                                {
                                    var model = new ExecutionDeviceModel();
                                    model.ExecutionDeviceId = (long)dataReader["ExecutionDeviceID"];
                                    model.ExecutionLinkidId = (long)dataReader["ExecutionLinkidID"];
                                    model.InstalledDevice = (int)dataReader["InstalledDevice"];
                                    model.CreatedBy = dataReader["CreatedBy"].ToString();
                                    model.UpdatedBy = dataReader["UpdatedBy"].ToString();
                                    result = model;
                                }
                            }
                        }
                        connection.Close();
                    }
                    return result;
                }
                catch (Exception) { return new ExecutionDeviceModel(); }
            });
        }
        #endregion
        #endregion

        #region [Save Update Execution Device]
        /// <summary>
        /// Save Update Execution Device
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<Dictionary<ExecutionDeviceModel,string>> SaveUpdateExecutionDevice(ExecutionDeviceModel model)
        {
            return await Task.Run(() =>
            {
                var result = new Dictionary<ExecutionDeviceModel, string>();
                try
                {
                    using (SqlConnection connection = new SqlConnection(this._connectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.CommandText = "sp_ExecutionDeviceActions";
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@procId", 5);
                            cmd.Parameters.AddWithValue("@executionDeviceId", model.ExecutionDeviceId);
                            cmd.Parameters.AddWithValue("@executionLinkingId", model.ExecutionLinkidId);
                            cmd.Parameters.AddWithValue("@installedDevices", model.InstalledDevice);
                            cmd.Parameters.AddWithValue("@CreatedBy", model.CreatedBy);
                            cmd.Parameters.AddWithValue("@UpdatedBy", model.CreatedBy);
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
                                result[model] = "Linking Id Already Exists!";
                                return result;
                            }
                            model.ExecutionDeviceId = (long)cmd.ExecuteScalar();
                            connection.Close();
                            result[model] = "ok";
                            return result;
                        }
                    }
                }
                catch (Exception ex) {
                    return new Dictionary<ExecutionDeviceModel, string>();
                }
            });
        }
        #endregion
        #endregion

        #region [Update Execution Device]
        /// <summary>
        /// Save Update Execution Device
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<ExecutionDeviceModel> UpdateExecutionDevice(ExecutionDeviceModel model)
        {
            return await Task.Run(() =>
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(this._connectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.CommandText = "sp_ExecutionDeviceActions";
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@procId", 2);
                            cmd.Parameters.AddWithValue("@executionDeviceId", model.ExecutionDeviceId);
                            cmd.Parameters.AddWithValue("@executionLinkingId", model.ExecutionLinkidId);
                            cmd.Parameters.AddWithValue("@installedDevices", model.InstalledDevice);
                            cmd.Parameters.AddWithValue("@CreatedBy", model.UpdatedBy);
                            cmd.Parameters.AddWithValue("@UpdatedBy", model.UpdatedBy);
                            cmd.Connection = connection;
                            connection.Open();
                            cmd.ExecuteNonQuery();
                            connection.Close();
                            return model;
                        }
                    }
                }
                catch (Exception ex)
                {
                    return new ExecutionDeviceModel();
                }
            });
        }
        #endregion
        
    }
}
