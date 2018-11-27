using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace SonMogendorff
{
    [EnableCors("*", "*", "*")]
    [RoutePrefix("api")]
    public class ContactApiController : ApiController
    {
        private ContactLogic logic = new ContactLogic();

        [HttpGet]
        [Route("messages/{id}")]
        public HttpResponseMessage GetOneMessage(int id) // Gets one message from the DB
        {
            try
            {
                MessageModel message = logic.GetOneMessage(id);
                return Request.CreateResponse(HttpStatusCode.OK, message);
            }
            catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpGet]
        [Route("messages")]
        public HttpResponseMessage GetAllMessages() // Gets all messages from the DB
        {
            try
            {
                List<MessageModel> messages = logic.GetAllMessages();
                return Request.CreateResponse(HttpStatusCode.OK, messages);
            }
            catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpPost]
        [Route("messages")]
        public HttpResponseMessage AddMessage(MessageModel model) // Adds a single message to the DB.
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    List<PropErrors> errorList = ErrorExtractor.ExtractErrors(ModelState);
                    return Request.CreateResponse(HttpStatusCode.BadRequest, errorList);
                }

                MessageModel message = logic.AddMessage(model);
                return Request.CreateResponse(HttpStatusCode.Created, message);
            }
            catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

    }
}
