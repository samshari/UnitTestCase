using Exelon.Domain;
using Exelon.Domain.Abstractions;
using Exelon.Domain.Common;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Exelon.Infrastructure.Repositories
{
    public class VegPreConstructionRequiredRepository : IVegPreConstructionRequiredRepository
    {
        private readonly string _connectionString;
        private readonly string _storedProcedure = "dbo.spCOMMONREQActions";

        public VegPreConstructionRequiredRepository(IAppSettings appSettings)
        {
            _connectionString = appSettings.GetConnectionString();
        }
        public async Task<COMMONREQModel> GetPreConstructionRequired(int id)
        {
            return await Task.Run(() =>
            {
                var result = new COMMONREQModel();
                try
                {
                    using (SqlConnection connection = new SqlConnection(this._connectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.CommandText = _storedProcedure;
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@procId", 1);
                            cmd.Parameters.AddWithValue("@ID", id);
                            cmd.Connection = connection;
                            connection.Open();
                            var lstreq = new List<MREQUIREDModel>();
                            using (SqlDataReader dataReader = cmd.ExecuteReader())
                            {
                                while (dataReader.Read())
                                {
                                    var req = new MREQUIREDModel();
                                    req.ID = (int)dataReader["ID"];
                                    req.Name = dataReader["Name"].ToString();
                                    lstreq.Add(req);
                                }
                            }

                            result.Result = lstreq;
                            connection.Close();
                            return result;
                        }
                    }
                }
                catch (Exception ex) { return new COMMONREQModel(); }
            });
        }
    }
}
