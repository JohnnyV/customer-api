using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;
using WebAPI.Repositories;

namespace WebAPI.Controllers
{
    public class CustomerController : ApiController
    {

        private ICustomerRepository customerRepository;

        public CustomerController()
        {
            customerRepository = new CustomerRepository();
        }

        public HttpResponseMessage Get() {
            return Request.CreateResponse(HttpStatusCode.OK, customerRepository.GetAll());
        }

        public string Post(Customer customer) 
        {
            return customerRepository.Add(customer);
        }

        public string Put(Customer customer)
        {
            return customerRepository.Update(customer);
        }

        public string Delete(int id)
        {
            customerRepository.DeleteDocuments(id);
            return customerRepository.Delete(id);
        }
    }
}
