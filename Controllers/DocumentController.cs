using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using WebAPI.Config;
using WebAPI.Models;
using WebAPI.Repositories;

namespace WebAPI.Controllers
{
    [Route("api/Customer/Document")]
    public class DocumentController : ApiController
    {
        private IDocumentRepository documentRepository = new DocumentRepository();

        public HttpResponseMessage Get(int customerId)
        {
            return Request.CreateResponse(HttpStatusCode.OK, documentRepository.GetAll(customerId));
        }

        public string Post(int customerId)
        {
            try
            {
                Directory.CreateDirectory(AppConstants.AbsoluteDocumentsDirectory);

                var httpRequest = HttpContext.Current.Request;
                var count = httpRequest.Files.Count;
                for (int i = 0; i < httpRequest.Files.Count; i++)
                {
                    var postedFile = httpRequest.Files[i];
                    var fullPath = HttpContext.Current.Server.MapPath("~/" + AppConstants.DocumentsDirectory + "/" + customerId + "/" + postedFile.FileName);
                    postedFile.SaveAs(fullPath);

                    var document = new Document() { 
                        fileName = postedFile.FileName,
                        customerId = customerId,
                    };
                    
                    documentRepository.Add(customerId, document);
                }

                return "Success";
            }
            catch (Exception)
            {
                return "Failure";
            }
        }

        public string Delete(int id)
        {
            return documentRepository.Delete(id);
        }
    }
}
