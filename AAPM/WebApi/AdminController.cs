using AAPModel;
using AAPModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;


namespace AAPM.WebApi
{
    [EnableCorsAttribute("*", "*", "*")]
    public class AdminController : ApiController
    {

        //private IRepository _IRepo;

        //public AdminController(IRepository IRepo)
        //{
        //    _IRepo = IRepo;
        //}
        [Route("api/Admin/GetUsers")]
        [HttpGet]
        public HttpResponseMessage GetUsers()
        {
            //string username = Thread.CurrentPrincipal.Identity.Name;

            using (AAPMEntities entities = new AAPMEntities())
            {
                Repository repository = new Repository();

                var entity = repository.GetUsers(1);
                if (entity != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, entity);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound,
                        "No Data Available");
                }
            }
        }


        [Route("api/Admin/AddUser")]
        [HttpPost]
        public HttpResponseMessage AddUser([FromBody] AppUserModel appUser)
        {
            //comment
            try
            {
                Repository repository = new Repository();
                var result = repository.AddUser(appUser);
                HttpResponseMessage message= new HttpResponseMessage();
                if (result!=0)
                {
                    message = Request.CreateResponse(HttpStatusCode.Created, appUser);
                    message.Headers.Location = new Uri(Request.RequestUri +
                        appUser.UserId.ToString());

                    
                }
                return message;

            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [Route("api/Admin/AddUser")]
        [HttpPut]
        public HttpResponseMessage EditUser([FromBody] AppUserModel appUser)
        {
            //comment
            try
            {
                Repository repository = new Repository();
                var result = repository.AddUser(appUser);
                HttpResponseMessage message = new HttpResponseMessage();
                if (result != 0)
                {
                    message = Request.CreateResponse(HttpStatusCode.Created, appUser);
                    message.Headers.Location = new Uri(Request.RequestUri +
                        appUser.UserId.ToString());


                }
                return message;

            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [Route("api/Admin/DeleteUser/{userId}")]
        [HttpDelete]
        public HttpResponseMessage DeleteUser(int userId)
        {
            //comment
            try
            {
                Repository repository = new Repository();
                var result = repository.DeleteUser(userId);
                HttpResponseMessage message = new HttpResponseMessage();
                if (result== "Success")
                {
                    message = Request.CreateResponse(HttpStatusCode.Created, "Success");
                    message.Headers.Location = new Uri(Request.RequestUri.ToString());

                }
                return message;

            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [Route("api/Admin/GetUserDetail/{userId}")]
        [HttpGet]
        public HttpResponseMessage GetUserDetail(int userId)
        {
            //comment
            try
            {
                Repository repository = new Repository();
                var result = repository.GetUserDetail(userId);
                HttpResponseMessage response = new HttpResponseMessage();
                if (result !=null)
                {
                    response = Request.CreateResponse(HttpStatusCode.OK, result);
                    response.Headers.Location = new Uri(Request.RequestUri.ToString());

                }
                return response;

            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

    }
}
