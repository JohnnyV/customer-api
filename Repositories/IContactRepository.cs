using System;
using System.Data;
using WebAPI.Models;

namespace WebAPI.Repositories
{
    internal interface IContactRepository
    {
        DataTable GetAll(int customerId);
        string Add(int contactId, Contact contact);
        string Update(int id, Contact contact);
        string Delete(int id);
        string DeleteAll(int customerId);

    }
}
