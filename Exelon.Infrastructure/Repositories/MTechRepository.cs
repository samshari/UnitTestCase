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
    public class MTECHRepository : IMTECHRepository
    {
        private readonly string _connectionString;

        private readonly string _storedProcedure = "dbo.spMTECHActions";
        public MTECHRepository(IAppSettings appSettings)
        {
            _connectionString = appSettings.GetConnectionString();
        }

        public async Task<List<MTECHModel>> GetMTECH(int id = 0)
        {
            return await Task.Run(() =>
            {
                var lstMTECH = new List<MTECHModel>();
                try
                {
                    using(SqlConnection connection = new SqlConnection(this._connectionString))
                    {
                        connection.Open();
                        using(SqlCommand cmd = new SqlCommand())
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

                            using(SqlDataReader dataReader = cmd.ExecuteReader())
                            {
                                while (dataReader.Read())
                                {
                                    var mtech = new MTECHModel();
                                    mtech.ID = (int)dataReader["ID"];
                                    mtech.Name = dataReader["Name"].ToString();
                                    lstMTECH.Add(mtech);
                                }
                            }
                        }
                        connection.Close();
                    }
                   
                    return lstMTECH;

                }
                catch(Exception ex) { return new List<MTECHModel>(); }
            });
        }
    }
}
