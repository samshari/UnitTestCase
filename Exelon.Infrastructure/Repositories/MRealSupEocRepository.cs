using Exelon.Domain;
using Exelon.Domain.Abstractions;
using Exelon.Domain.Common;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Exelon.Infrastructure.Repositories
{
    public class MREALSUPEOCRepository : IMREALSUPEOCRepository
    {
        private readonly string _connectionString;

        private readonly string _storedProcedure = "dbo.spMREALSUPPORTEOCActions";
        public MREALSUPEOCRepository(IAppSettings appSettings)
        {
            _connectionString = appSettings.GetConnectionString();
        }

        public async Task<List<MREALSUPEOCModel>> GetMREALEOC(int id = 0)
        {
            return await Task.Run(() =>
            {
                var lstMREAL = new List<MREALSUPEOCModel>();
                try
                {
                    using (SqlConnection connection = new SqlConnection(this._connectionString))
                    {
                        connection.Open();
                        using (SqlCommand cmd = new SqlCommand())
                        {
                            if (id == 0)
                            {
                                cmd.CommandText = _storedProcedure;
                                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                                cmd.Parameters.AddWithValue("@procId", 1);
                                cmd.Parameters.AddWithValue("@ID", id);
                                cmd.Connection = connection;

                            }
                            else
                            {
                                cmd.CommandText = _storedProcedure;
                                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                                cmd.Parameters.AddWithValue("@procId", 2);
                                cmd.Parameters.AddWithValue("@ID", id);
                                cmd.Connection = connection;

                            }

                            using (SqlDataReader dataReader = cmd.ExecuteReader())
                            {
                                while (dataReader.Read())
                                {
                                    var mtech = new MREALSUPEOCModel();
                                    mtech.ID = (int)dataReader["ID"];
                                    mtech.Name = dataReader["Name"].ToString();
                                    lstMREAL.Add(mtech);
                                }
                            }
                        }
                    }
                    return lstMREAL;

                }
                catch (Exception ex) { return new List<MREALSUPEOCModel>(); }
            });
        }
    }
}
