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



        public IActionResult Yeni()
        {

            UsersDto user = new UsersDto();

            return View(user);
        }


        [Route("[controller]/[action]/{id}")]
        public IActionResult Guncelle(string id)
        {
            UsersDto user = new UsersDto();

            string link = Sabitler.ApiLink + "api/users/" + id;


            try
            {
                var httpClient = new HttpClient();
                
                string json = "";
                var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
                var postTask = httpClient.GetAsync(link);
                postTask.Wait();
                var postResult = postTask.Result;
                var responJsonText = postResult.Content.ReadAsStringAsync().Result;

                var sonuc = (JsonConvert.DeserializeObject<DataResult<UsersDto>>(responJsonText));

                user = sonuc.Data;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return View(user);
        }
        
        [Route("[controller]/[action]/{id}")]
        public IActionResult Izle(string id)
        {
            UsersDto user = new UsersDto();

            string link = Sabitler.ApiLink + "api/users/" + id;


            try
            {
                var httpClient = new HttpClient();
                
                string json = "";
                var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
                var postTask = httpClient.GetAsync(link);
                postTask.Wait();
                var postResult = postTask.Result;
                var responJsonText = postResult.Content.ReadAsStringAsync().Result;

                var sonuc = (JsonConvert.DeserializeObject<DataResult<UsersDto>>(responJsonText));

                user = sonuc.Data;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return View(user);
        }

        [HttpPost]
        public IActionResult KaydetYeni(UsersDto user)
        {

            string link = Sabitler.ApiLink + "api/users";


            try
            {
                var httpClient = new HttpClient();
                //httpClient.DefaultRequestHeaders.Authorization =
                //    new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("Token"));

                string json = "";
                json = Newtonsoft.Json.JsonConvert.SerializeObject(user);
                var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
                var postTask = httpClient.PostAsync(link, httpContent);
                postTask.Wait();
                var postResult = postTask.Result;
                var responJsonText = postResult.Content.ReadAsStringAsync().Result;

                var sonuc = (JsonConvert.DeserializeObject<DataResult<UsersDto>>(responJsonText));

                if (!sonuc.Success)
                {
                    return Json(new { success = false, responseText = sonuc.Message });
                }


                return Json(new { success = true, responseText = "Kayıt Başarılı" });

            }
            catch (Exception ex)
            {
                return Json(new { success = false, responseText ="Hata" });
            }

        }


        [HttpPut]
        public IActionResult KaydetGuncelle(UsersDto user)
        {

            string link = Sabitler.ApiLink + "api/users/";

            try
            {
                var httpClient = new HttpClient();
               
                string json = "";
                json = Newtonsoft.Json.JsonConvert.SerializeObject(user);
                var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
                var postTask = httpClient.PutAsync(link, httpContent);
                postTask.Wait();
                var postResult = postTask.Result;
                var responJsonText = postResult.Content.ReadAsStringAsync().Result;

                var sonuc = (JsonConvert.DeserializeObject<DataResult<UsersDto>>(responJsonText));

                if (!sonuc.Success)
                {
                    return Json(new { success = false, responseText = sonuc.Message });
                }


                return Json(new { success = true, responseText = "Guncelle Basarili" });

            }
            catch (Exception ex)
            {
                return Json(new { success = false, responseText = "Guncelle Hata" });
            }


        }
        
        [HttpDelete]
        public IActionResult KayitSil(string id)
        {

            string link = Sabitler.ApiLink + "api/users/"+ id ;

            try
            {
                var httpClient = new HttpClient();
               
                string json = "";


                var postTask = httpClient.DeleteAsync(link);
                postTask.Wait();
                var postResult = postTask.Result;
                var responJsonText = postResult.Content.ReadAsStringAsync().Result;

                var sonuc = (JsonConvert.DeserializeObject<DataResult<object>>(responJsonText));

                if (!sonuc.Success)
                {
                    return Json(new { success = false, responseText = sonuc.Message });
                }


                return Json(new { success = true, responseText = "Sil Basarili" });

            }
            catch (Exception ex)
            {
                return Json(new { success = false, responseText = "Sil Hata" });
            }


        }


    }
}
