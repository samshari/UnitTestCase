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
    public class MENVCOCRepository : IMENVCOCRepository
    {
        private readonly string _connectionString;
        private readonly string _storedProcedure = "dbo.spMENVCOCActions";

        public MENVCOCRepository(IAppSettings appSettings)
        {
            _connectionString = appSettings.GetConnectionString();
        }


        public async Task<List<MENVCOCModel>> GetMENVCOC(int id = 0)
        {
            return await Task.Run(() =>
            {
                var result = new List<MENVCOCModel>();
                try
                {
                    using (SqlConnection connection = new SqlConnection(this._connectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.CommandText = _storedProcedure;
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@ID", id);
                            cmd.Connection = connection;
                            connection.Open();
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
                                    var envcoc = new MENVCOCModel();
                                    envcoc.ID = (int)dataReader["ID"];
                                    envcoc.Name = dataReader["Name"].ToString();
                                    result.Add(envcoc);
                                }
                            }

                            connection.Close();
                            return result;
                        }
                    }
                }
                catch (Exception ex) { return new List<MENVCOCModel>(); }
            });
        }

    }
}
