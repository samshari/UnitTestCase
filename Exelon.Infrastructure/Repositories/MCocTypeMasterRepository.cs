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
    public class MCOCTYPEMASTERRepository : IMCOCTYPEMASTERRepository
    {

        private readonly string _connectionString;
        private readonly string _storedProcedure = "dbo.spMCOCTYPEMASTERActions";

        public MCOCTYPEMASTERRepository(IAppSettings appSettings)
        {
            _connectionString = appSettings.GetConnectionString();
        }

        public async Task<List<MCOCTYPEMASTERModel>> GetMCOCTYPE(int id = 0)
        {
            return await Task.Run(() =>
            {

                var result = new List<MCOCTYPEMASTERModel>();
                try
                {
                    using (SqlConnection connection = new SqlConnection(this._connectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.CommandText = _storedProcedure;
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@COCTypeID", id);
                            cmd.Connection = connection;

                            connection.Open();
                            if (id == 0)
                                cmd.Parameters.AddWithValue("@procId", 1);
                            else
                                cmd.Parameters.AddWithValue("@procId", 2);


                            using(SqlDataReader dataReader = cmd.ExecuteReader())
                            {
                                while (dataReader.Read())
                                {
                                    var coctype = new MCOCTYPEMASTERModel();
                                    coctype.COCTypeID = (int)dataReader["COCTypeID"];
                                    coctype.COCTypeName = dataReader["COCTypeName"].ToString();
                                    coctype.IsActive = Convert.ToBoolean(dataReader["IsActive"]);
                                    result.Add(coctype);
                                }
                            }


                            connection.Close();
                            return result;
                        }
                    }
                }
                catch (Exception ex) { return new List<MCOCTYPEMASTERModel>(); }
            });
        }


    }
}
