using ContactsWebUI.BusinessLogicLayer;
using ContactsWebUI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ContactsWebUI.Controllers
{
    public class UsersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult AllUsers()
        {
            string link = string.Format(
                              Sabitler.ApiLink + "api/users");

            List<UsersDto> sonucList = new List<UsersDto>();

            try
            {
                var httpClient = new HttpClient();

                string json = "";
                //json = Newtonsoft.Json.JsonConvert.SerializeObject(Request);
                var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
                var postTask = httpClient.GetAsync(link);
                postTask.Wait();
                var postResult = postTask.Result;
                var responJsonText = postResult.Content.ReadAsStringAsync().Result;

                sonucList = (JsonConvert.DeserializeObject<List<UsersDto>>(responJsonText));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            var sonuc = Json(sonucList);
            return sonuc;
        }

    }
}
