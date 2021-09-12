using AAPM.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AAPM.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        string Baseurl = "https://localhost:44342/";
        public async Task<ActionResult> Index()
        {
            List<UserModel> EmpInfo = new List<UserModel>();
            using (var client = new HttpClient())
            {
                //Passing service base url
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                //Define request data format
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //Sending request to find web api REST service resource GetAllEmployees using HttpClient
                HttpResponseMessage Res = await client.GetAsync("api/Admin/GetUsers");
                //Checking the response is successful or not which is sent using HttpClient
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                    //Deserializing the response recieved from web api and storing into the Employee list
                    EmpInfo = JsonConvert.DeserializeObject<List<UserModel>>(EmpResponse);
                }
                //returning the employee list to view
                return View(EmpInfo);
            }
        }

        public async Task<ActionResult> AddUser(UserModel userModel)
        {
            if (ModelState.IsValid)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Baseurl);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage Res = await client.PostAsJsonAsync<UserModel>("api/Admin/AddUser", userModel);

                    if (Res.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }

                    ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");

                    return View(userModel);
                }

            }
            else
            {
                return View();
            }
        }

        public async Task<ActionResult> EditUser(int userId)
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync("api/Admin/GetUserDetail/" + userId);
                //Checking the response is successful or not which is sent using HttpClient
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api
                    var userDetail = Res.Content.ReadAsStringAsync().Result;
                    //Deserializing the response recieved from web api and storing into the Employee list
                    var EmpInfo = JsonConvert.DeserializeObject<UserModel>(userDetail);
                    return View(EmpInfo);

                }

            }

            return View();


        }

        [HttpPost]
        public async Task<ActionResult> EditUser(UserModel model)
        {
            
                if (ModelState.IsValid)
                {
                    if (model != null)
                    using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri(Baseurl);
                        client.DefaultRequestHeaders.Clear();
                        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                        HttpResponseMessage Res = await client.PostAsJsonAsync<UserModel>("api/Admin/AddUser", model);

                        if (Res.IsSuccessStatusCode)
                        {
                            ViewBag.Message = "Updated";
                            return View();
                        }

                    }
                return View();
            }
                else
                {
                ViewBag.Message = ModelState.Select(x=>x.Value);
                    return View();
                }


        }

        public async Task<ActionResult> DeleteUser(int userId)
        {
            if (userId != 0)
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Baseurl);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage Res = await client.DeleteAsync("api/Admin/DeleteUser/" + userId);

                    if (Res.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }

                    //ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");

                    //return RedirectToAction("Index");
                    List<UserModel> model = new List<UserModel>();
                    Res = await client.GetAsync("api/Admin/GetUsers");
                    if (Res.IsSuccessStatusCode)
                    {
                        var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                        //Deserializing the response recieved from web api and storing into the Employee list
                        model = JsonConvert.DeserializeObject<List<UserModel>>(EmpResponse);
                    }
                    ViewBag.Message = "Not Deleted";
                    return View("Index", model);
                }
            else
            {
                ViewBag.Message = "Not Deleted";
                return View("Index");

            }


        }

    }

}

