using Exelon.Domain.Abstractions;
using Exelon.Domain.Common;
using Exelon.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Exelon.Infrastructure.Repositories
{
    public class MPhaseRepository : IMPhaseRepository
    {
        private readonly string _connectionString;
        private readonly string _storedProcedure = "dbo.spMPhaseActions";


        public MPhaseRepository(IAppSettings appSettings)
        {
            _connectionString = appSettings.GetConnectionString();
        }


        public Task<List<MPhaseModel>> GetMPhase(int id = 0)
        {
            return Task.Run(() =>
            {
                var result = new List<MPhaseModel>();
                try
                {
                    using (SqlConnection connection = new SqlConnection(this._connectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.CommandText = _storedProcedure;
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            cmd.Connection = connection;
                            connection.Open();
                            cmd.Parameters.AddWithValue("@ID", id);
                            if (id == 0)
                                cmd.Parameters.AddWithValue("@procId", 1);
                            else
                                cmd.Parameters.AddWithValue("@procId", 2);

                            using(SqlDataReader dataReader = cmd.ExecuteReader())
                            {
                                while (dataReader.Read())
                                {
                                    var mphase = new MPhaseModel();
                                    mphase.ID = (int)dataReader["ID"];
                                    mphase.Name = dataReader["Name"].ToString();
                                    result.Add(mphase);
                                }
                            }
                            connection.Close();
                            
                        }
                        return result;
                    }
                }
                catch(Exception ex) { return new List<MPhaseModel>(); }
            });
        }
    }
}
