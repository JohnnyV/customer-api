using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using WebAPI.Config;
using WebAPI.Models;

namespace WebAPI.Repositories
{
    public class DocumentRepository : IDocumentRepository
    {
        private readonly DataTable _dataTable = new DataTable();
        private readonly string _connectionString = ConfigurationManager.ConnectionStrings[AppConstants.DatabaseName].ConnectionString;

        public string Add(int customerId, Document document)
        {
            string query = @"
                    insert into dbo.Document
                    values ('" + document.fileName + @"', '" + customerId + @"')
                    ";

            return executeOnDb(query);
        }

        public string Delete(int id)
        {
            string query = @"
                    delete from dbo.Document 
                    where id=" + id + @"
                    ";

            return executeOnDb(query);
        }

        public DataTable GetAll(int customerId)
        {
            // TODO Use stored procedures instead of raw queries to avoid SQL injections?
            string query = @"select * from dbo.Document where customerId=" + customerId + "@";
            executeOnDb(query);

            return _dataTable;
        }
        
        private string executeOnDb(string query)
        {
            try
            {
                using (var sqlConnection = new SqlConnection(_connectionString))
                using (var sqlCommand = new SqlCommand(query, sqlConnection))
                using (var dataAdapter = new SqlDataAdapter(sqlCommand))
                {
                    sqlCommand.CommandType = CommandType.Text;
                    dataAdapter.Fill(_dataTable);
                }

                return "Success";
            }
            catch (Exception)
            {
                return "Failure";
            }
        }
    }
}