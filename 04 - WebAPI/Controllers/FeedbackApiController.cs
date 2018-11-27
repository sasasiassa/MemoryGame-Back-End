using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace SonMogendorff.Controllers
{
    [EnableCors("*", "*", "*")]
    [RoutePrefix("api")]
    public class FeedbackApiController : ApiController
    {
        private FeedbackLogic logic = new FeedbackLogic();

        [HttpGet]
        [Route("feedbacks")]
        public HttpResponseMessage GetAllFeedbacks() // Gets all feedbacks from the DB
        {
            try
            {
                List<FeedbackModel> feedbacks = logic.GetAllFeedbacks();
                return Request.CreateResponse(HttpStatusCode.OK, feedbacks);
            }
            catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }

        }

        [HttpGet]
        [Route("feedbacks/{id}")]
        public HttpResponseMessage GetOneFeedback(int id) // Gets one feedback from the DB
        {
            try
            {
                FeedbackModel feedback = logic.GetOneFeedback(id);
                return Request.CreateResponse(HttpStatusCode.OK, feedback);
            }
            catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpPost]
        [Route("feedbacks")]
        public HttpResponseMessage AddFeedback(FeedbackModel model) // Adds a single feedback to the DB
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    List<PropErrors> errorList = ErrorExtractor.ExtractErrors(ModelState);
                    return Request.CreateResponse(HttpStatusCode.BadRequest, errorList);
                }
                FeedbackModel feedback = logic.AddFeedback(model);
                return Request.CreateResponse(HttpStatusCode.Created, feedback);
            }
            catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

    }
}
