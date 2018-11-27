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
    public class UsersApiController : ApiController
    {
        private UsersLogic usersLogic = new UsersLogic();

        [HttpGet]
        [Route("users")]
        public HttpResponseMessage GetAllUsers() // Gets all users from the DB
        {
            try
            {
                List<UserModel> users = usersLogic.GetAllUsers();
                return Request.CreateResponse(HttpStatusCode.OK, users);
            }
            catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpGet]
        [Route("users/{id}")]
        public HttpResponseMessage GetOneUser(int id) // Gets one user from the DB
        {
            try
            {
                UserModel user = usersLogic.GetOneUser(id);
                return Request.CreateResponse(HttpStatusCode.OK, user);
            }
            catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpPost]
        [Route("users")]
        public HttpResponseMessage AddUser(UserModel userModel) // Adds a single user to the DB
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    List<PropErrors> errorList = ErrorExtractor.ExtractErrors(ModelState);
                    return Request.CreateResponse(HttpStatusCode.BadRequest, errorList);
                }
                UserModel user = usersLogic.AddUser(userModel);
                return Request.CreateResponse(HttpStatusCode.Created, user);

            }
            catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpGet]
        [Route("users/login")]
        public HttpResponseMessage Login([FromUri] string username, [FromUri] string password)
        {
            //Takes the query string as parameters for the login authorization.
            try
            {
                UserModel user = usersLogic.GetUserByDetails(username, password);
                return Request.CreateResponse(HttpStatusCode.OK, user);
            }
            catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }

        }

        //[HttpGet]
        //[Route("users/{username}/{password}")]
        //public HttpResponseMessage GetUserByDetails(string username, string password)
        //{
        //    try
        //    {
        //        UserModel user = usersLogic.GetUserByDetails(username, password);
        //        return Request.CreateResponse(HttpStatusCode.OK, user);
        //    }
        //    catch(Exception ex)
        //    {
        //        return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
        //    }
        //}

        protected override void Dispose(bool disposing)
        {
            
            base.Dispose(disposing);
            usersLogic.Dispose();
        }

    }
}
