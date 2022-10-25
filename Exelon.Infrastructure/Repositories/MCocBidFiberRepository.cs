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
    public class MCOCBIDFIBERRepository : IMCOCBIDFIBERRepository
    {
        private readonly string _connectionString;

        private readonly string _storedProcedure = "dbo.spMCOCBIDFIBERActions";

        public MCOCBIDFIBERRepository(IAppSettings appSettings)
        {
            _connectionString = appSettings.GetConnectionString();
        }



        public async Task<List<MCOCBIDFIBERModel>> GetMCOCBID(int id = 0)
        {
            return await Task.Run(() =>
            {
                var result = new List<MCOCBIDFIBERModel>();
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
                                    var mcocfiber = new MCOCBIDFIBERModel();
                                    mcocfiber.ID = (int)dataReader["ID"];
                                    mcocfiber.Name = dataReader["Name"].ToString();
                                    result.Add(mcocfiber);
                                }
                            }
                        }
                    }
                    return result;

                }
                catch (Exception ex) { return new List<MCOCBIDFIBERModel>(); }
            });
        }
    }
}
