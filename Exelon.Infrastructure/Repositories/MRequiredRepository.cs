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
    public class MREQUIREDRepository : IMREQUIREDRepository
    {
        private readonly string _connectionString;

        private readonly string _storedProcedure = "dbo.spMREQUIREDActions";
        public MREQUIREDRepository(IAppSettings appSettings)
        {
            _connectionString = appSettings.GetConnectionString();
        }
        public async Task<List<MREQUIREDModel>> GetMREQ(int id = 0)
        {
            return await Task.Run(() =>
            {

                var result = new List<MREQUIREDModel>();
                try
                {
                    using (SqlConnection connection = new SqlConnection(this._connectionString))
                    {
                        connection.Open();
                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.CommandText = _storedProcedure;
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@ID", id);
                            cmd.Connection = connection;
                            if (id == 0)
                            {
                                cmd.Parameters.AddWithValue("@procId", 1);

                            }
                            else
                            {

                                cmd.Parameters.AddWithValue("@procId", 2);

                            }

                            using (SqlDataReader dataReader = cmd.ExecuteReader())
                            {
                                while (dataReader.Read())
                                {
                                    var mreq = new MREQUIREDModel();
                                    mreq.ID = (int)dataReader["ID"];
                                    mreq.Name = dataReader["Name"].ToString();
                                    result.Add(mreq);
                                }
                            }
                        }
                    }
                    return result;

                }
                catch (Exception ex) { return new List<MREQUIREDModel>(); }

            });
        }
    }
}
