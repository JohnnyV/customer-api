using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using WebAPI.Config;
using WebAPI.Models;

namespace WebAPI.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {

        private readonly DataTable _dataTable = new DataTable();
        private readonly string _connectionString = ConfigurationManager.ConnectionStrings[AppConstants.DatabaseName].ConnectionString;

        public DataTable GetAll()
        {
            string query = @"select * from dbo.Customer";
            executeOnDb(query);

            return _dataTable;
        }

        public string Add(Customer customer)
        {
            string query = @"
                    insert into dbo.Customer 
                    values ('" + customer.TIN + @"', '" + customer.FirstName + @"', '" + customer.LastName + @"')
                    ";
            return executeOnDb(query);
        }

        public string Delete(int id)
        {
            string query = @"
                delete from dbo.Document
                where customerId =" + id + @"
                delete from dbo.Contact 
                where customerId =" + id + @"
                delete from dbo.Customer 
                where id=" + id + @"
                ";
            return executeOnDb(query);
        }

        public string Update(Customer customer)
        {
            string query = @"
                    update dbo.Customer 
                    set TIN='" + customer.TIN + @"', FirstName='" + customer.FirstName + @"', LastName='" + customer.LastName + @"'
                    where id=" + customer.id + @"
                    ";
            return executeOnDb(query);
        }

        private string executeOnDb(string query) {
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

        public void DeleteDocuments(int id)
        {
            try
            {
                // Delete the directory and its contents recursively
                Directory.Delete(AppConstants.AbsoluteDocumentsDirectory + "\\" + id, true);
            }
            catch (Exception) {}
        }
    }
}
