using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;
using WebAPI.Repositories;

namespace WebAPI.Controllers
{
    [Route("api/Customer/Contact")]
    public class ContactController : ApiController
    {

        private IContactRepository contactRepository = new ContactRepository();

        public HttpResponseMessage Get(int customerId) {
            return Request.CreateResponse(HttpStatusCode.OK, contactRepository.GetAll(customerId));
        }

        public string Post(int customerId, Contact contact) 
        {
            return contactRepository.Add(customerId, contact);
        }

        public string Put(int id, Contact contact)
        {
            return contactRepository.Update(id, contact);
        }

        public string Delete(int id)
        {
            return contactRepository.Delete(id);
        }
    }
}
