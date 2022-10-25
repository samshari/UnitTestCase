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
    public class MSTEPMASTERRepository : IMSTEPMASTERRepository
    {
        private readonly string _connectionString;
        private readonly string _storedProcedure= "dbo.spMSTEPBYIDActions";

        public MSTEPMASTERRepository(IAppSettings appSettings)
        {
            _connectionString = appSettings.GetConnectionString();
        }

        public async Task<MSTEPMASTERModel> GetSTEPBYID(int id)
        {
            return await Task.Run(() =>
            {
                var result = new MSTEPMASTERModel();
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
                            var step = new List<MSTEPTYPEModel>();
                            using (SqlDataReader dataReader = cmd.ExecuteReader())
                            {
                                while (dataReader.Read())
                                {

                                    var temp = new MSTEPTYPEModel();
                                    temp.StepID = (int)dataReader["StepID"];
                                    temp.StepName = dataReader["StepName"].ToString();
                                    step.Add(temp);


                                }
                            }

                            result.result = step;
                            connection.Close();
                        }
                    }

                    return result;
                }
                catch (Exception ex) { return new MSTEPMASTERModel(); }
            });
        }
    }
}
