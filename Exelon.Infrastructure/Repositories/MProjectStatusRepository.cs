using Exelon.Domain;
using Exelon.Domain.Abstractions;
using Exelon.Domain.Common;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Exelon.Infrastructure.Repositories
{
    public class MPROJECTSTATUSRepository : IMPROJECTSTATUSRepository
    {
        private readonly string _connectionString;
        private readonly string _storedProcedure = "spMPROJECTSTATUSActions";

        public MPROJECTSTATUSRepository(IAppSettings appSettings)
        {
            _connectionString = appSettings.GetConnectionString();
        }

        public async Task<List<MPROJECTSTATUSModel>> GETMPROJECTSTATUS(int id = 0)
        {
            return await Task.Run(() =>
            {
                var lstMPROJECTSTATUS = new List<MPROJECTSTATUSModel>();
                try
                {
                    using(SqlConnection connection = new SqlConnection(this._connectionString))
                    {
                        connection.Open();
                        using (SqlCommand cmd = new SqlCommand())
                        {
                            if (id == 0)
                            {
                                cmd.CommandText = _storedProcedure;
                                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                                cmd.Parameters.AddWithValue("@procId", 1);
                                cmd.Parameters.AddWithValue("@StatusID", id);
                                cmd.Connection = connection;
                            }
                            else
                            {
                                cmd.CommandText = _storedProcedure;
                                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                                cmd.Parameters.AddWithValue("@procId", 2);
                                cmd.Parameters.AddWithValue("@StatusID", id);
                                cmd.Connection = connection;
                            }

                            using (SqlDataReader dataReader = cmd.ExecuteReader())
                            {
                                while (dataReader.Read())
                                {
                                    var mprojectstatus = new MPROJECTSTATUSModel();
                                    mprojectstatus.StatusID = (int)dataReader["StatusID"];
                                    mprojectstatus.Name = dataReader["Name"].ToString();
                                    lstMPROJECTSTATUS.Add(mprojectstatus);
                                }

                            }
                            

                        }
                       
                    }
                    return lstMPROJECTSTATUS;
                }
                catch(Exception ex) { return new List<MPROJECTSTATUSModel>(); }
            });
        }

    }
}
