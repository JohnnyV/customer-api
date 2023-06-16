using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using WebAPI.Config;
using WebAPI.Models;

namespace WebAPI.Repositories
{
    public class ContactRepository : IContactRepository
    {

        private readonly DataTable _dataTable = new DataTable();
        private readonly string _connectionString = ConfigurationManager.ConnectionStrings[AppConstants.DatabaseName].ConnectionString;

        public string Add(int customerId, Contact contact)
        {
            string query = @"
                    insert into dbo.Contact
                    values ('" + contact.contactType + @"', '" + contact.contactData + @"', '" + customerId + @"')
                    "; executeOnDb(query);

            return executeOnDb(query);
        }

        public string Delete(int id)
        {
            string query = @"
                    delete from dbo.Contact 
                    where id=" + id + @"
                    ";

            return executeOnDb(query);
        }

        public string DeleteAll(int customerId)
        {
            string query = @"
                    delete from dbo.Contact 
                    where customerId=" + customerId + @"
                    ";

            return executeOnDb(query);
        }

        public DataTable GetAll(int customerId)
        {
            // TODO Use stored procedures instead of raw queries to avoid SQL injections?
            string query = @"select * from dbo.Contact where customerId=" + customerId;
            executeOnDb(query);

            return _dataTable;
        }

        public string Update(int id, Contact contact)
        {
            string query = @"
                    update dbo.Contact 
                    set TIN='" + contact.contactType + @"', FirstName='" + contact.contactData + @"'
                    where id=" + contact.id + @"
                    ";
            return executeOnDb(query);
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
