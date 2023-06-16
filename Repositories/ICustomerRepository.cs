using System.Data;
using WebAPI.Models;

namespace WebAPI.Repositories
{
    internal interface ICustomerRepository
    {
        DataTable GetAll();
        string Add(Customer customer);
        string Update(Customer customer);
        string Delete(int id);
        void DeleteDocuments(int id);
    }
}
