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
    public class MREACTLRERepository : IMREACTLRERepository
    {
        private readonly string _connectionString;

        private readonly string _storedProcedure = "dbo.spMREACTLREActions";
        public MREACTLRERepository(IAppSettings appSettings)
        {
            _connectionString = appSettings.GetConnectionString();
        }
        public async Task<List<MREACTLREModel>> GetMREACT(int id = 0)
        {
            return await Task.Run(() =>
            {

                var result = new List<MREACTLREModel>();
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
                                    var mreact = new MREACTLREModel();
                                    mreact.ID = (int)dataReader["ID"];
                                    mreact.Name = dataReader["Name"].ToString();
                                    result.Add(mreact);
                                }
                            }
                        }
                    }
                    return result;

                }
                catch (Exception ex) { return new List<MREACTLREModel>(); }

            });
        }
    }
}
