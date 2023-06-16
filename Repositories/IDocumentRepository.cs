using System.Data;
using WebAPI.Models;

namespace WebAPI.Repositories
{
    internal interface IDocumentRepository
    {
        DataTable GetAll(int customerId);
        string Add(int customerId, Document document);
        string Delete(int id);
    }
}
