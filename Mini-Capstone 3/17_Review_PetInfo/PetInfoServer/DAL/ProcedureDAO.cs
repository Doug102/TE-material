using PetInfoServer.DAL.Interfaces;
using PetInfoServer.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace PetInfoServer.DAL
{
    public class ProcedureDAO : IProcedureDAO
    {
        private string sqlGetProcedures = "SELECT * FROM procedures;";
        private string connectionString;
        public ProcedureDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<Procedures> GetProcedures()
        {
            List<Procedures> procedures = new List<Procedures>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sqlGetProcedures, conn);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Procedures procedure = ReaderToProcedure(reader);
                        procedures.Add(procedure);

                    }

                }
            }
            catch (Exception ex)
            {
                procedures = new List<Procedures>();
            }

            return procedures;


        }
        private Procedures ReaderToProcedure(SqlDataReader reader)
        {
            Procedures procedure = new Procedures();
            procedure.Id = Convert.ToInt32(reader["id"]);
            procedure.Name = Convert.ToString(reader["Name"]);

            return procedure;
        }
    }
}
