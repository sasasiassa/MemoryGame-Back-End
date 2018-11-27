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
    public class GameResultsApiController : ApiController
    {
        private GameResultsLogic logic = new GameResultsLogic(); 

        [HttpGet]
        [Route("gameresults")]
        public HttpResponseMessage GetAllGameResults() // Gets all game results from the DB
        {
            try
            {
                List<GameResultModel> gameResults = logic.GetAllGameResults();
                return Request.CreateResponse(HttpStatusCode.OK, gameResults);
            }
            catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpGet]
        [Route("gameresults/{id}")]
        public HttpResponseMessage GetOneGameResult(int id) // Gets one game result from the DB
        {
            try
            {
                GameResultModel gameResult = logic.GetOneGameResult(id);
                return Request.CreateResponse(HttpStatusCode.OK, gameResult);

            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpPost]
        [Route("gameresults")]
        public HttpResponseMessage AddGameResult(GameResultModel model) // Adds a single game result to the DB
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    List<PropErrors> errorList = ErrorExtractor.ExtractErrors(ModelState);
                    return Request.CreateResponse(HttpStatusCode.BadRequest, errorList);
                }

                GameResultModel gameResult = logic.AddGameResult(model);
                return Request.CreateResponse(HttpStatusCode.Created, gameResult);
            }
            catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

    }
}
