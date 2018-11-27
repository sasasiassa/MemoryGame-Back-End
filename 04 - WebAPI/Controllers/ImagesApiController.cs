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
    public class ImagesApiController : ApiController
    {
        private ImgsLogic logic = new ImgsLogic();

        [HttpGet]
        [Route("imgs")]
        public HttpResponseMessage GetAllImages() // Gets all images from the DB
        {
            try
            {
                List<ImgModel> imgs = logic.GetAllImages();
                return Request.CreateResponse(HttpStatusCode.OK, imgs);
            }
            catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }

        }

        [HttpGet]
        [Route("imgs/{id}")]
        public HttpResponseMessage GetOneImage(int id) // Gets one image.
        {
            try
            {
                ImgModel img = logic.GetOneImg(id);
                return Request.CreateResponse(HttpStatusCode.OK, img);
            }
            catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpPost]
        [Route("imgs")]
        public HttpResponseMessage AddImage(ImgModel model) // Adds an image.
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    List<PropErrors> errorList = ErrorExtractor.ExtractErrors(ModelState);
                    return Request.CreateResponse(HttpStatusCode.BadRequest, errorList);
                }
                ImgModel img = logic.AddImg(model);
                return Request.CreateResponse(HttpStatusCode.Created, img);
            }
            catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }
    }
}
