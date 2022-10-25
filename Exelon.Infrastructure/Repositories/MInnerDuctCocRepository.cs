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
    public class MINNERDUCTCOCRepository : IMINNERDUCTCOCRepository
    {

        private readonly string _connectionString;
        private readonly string _storedProcedure= "dbo.spMINNERDUCTActions";

        public MINNERDUCTCOCRepository(IAppSettings appSettings)
        {
            _connectionString = appSettings.GetConnectionString();
        }

        public async  Task<List<MINNERDUCTCOCModel>> GetINNERDUCT(int id = 0)
        {
            return await Task.Run(() =>
            {
                var result = new List<MINNERDUCTCOCModel>();
                try
                {
                    using (SqlConnection connection = new SqlConnection(this._connectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.CommandText = _storedProcedure;
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@InnerductCOCID", id);
                            cmd.Parameters.AddWithValue("@Name", string.Empty);
                            cmd.Connection = connection;
                            if(id == 0)
                                cmd.Parameters.AddWithValue("@procId", 1);
                            else
                                cmd.Parameters.AddWithValue("@procId", 2);

                            connection.Open();
                            using(SqlDataReader dataReader = cmd.ExecuteReader())
                            {
                                while (dataReader.Read())
                                {
                                    var innerduct = new MINNERDUCTCOCModel();
                                    innerduct.InnerductCOCID = (int)dataReader["InnerductCOCID"];
                                    innerduct.Name = dataReader["Name"].ToString();
                                    result.Add(innerduct);
                                }
                            }
                            connection.Close();
                        }
                    }

                   return result;
                }
                catch(Exception ex) { return new List<MINNERDUCTCOCModel>(); }
            });
        }
    }
}
