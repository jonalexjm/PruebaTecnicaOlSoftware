using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OLSoftware.Core.Entities;

namespace OLSoftware.FrontEnd.Controllers
{
    public class UsersController : Controller
    {
        string urlCliente = "https://localhost:44390/api/users";
        string urlExport = "https://localhost:44390/api/ExportFile";
        public async  Task<IActionResult> Index()
        {
            

            var httpCliente = new HttpClient();

            var json = await httpCliente.GetStringAsync(urlCliente);

            List<User> userList = JsonConvert.DeserializeObject<List<User>>(json);

            return View(userList);
        }



        public IActionResult GuardarUsuario()
        {


            return View();
        }

        // POST: Users/Create
        [HttpPost]
        public async  Task<IActionResult> GuardarUsuario(User user)
        {
            if (ModelState.IsValid)
            {
                var objUser = new
                {
                    name = user.Name,
                    phone = user.Phone,
                    address = user.Address
                };

                var myContent = JsonConvert.SerializeObject(objUser);
                var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
                var byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                using (HttpClient client = new HttpClient())
                {
                    using (HttpResponseMessage res = await client.PostAsync(urlCliente, byteContent))
                    {
                        using (HttpContent content = res.Content)
                        {
                            string data = await content.ReadAsStringAsync();
                        }
                    }
                }

                 return RedirectToAction(nameof(Index));
            }
            return View(user);
          
        }


        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var httpCliente = new HttpClient();
            var json = await httpCliente.GetStringAsync(urlCliente+"/"+id);
            User user = JsonConvert.DeserializeObject<User>(json);
         
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, User user)
        {
            if (id != user.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var objUser = new
                    {
                        name = user.Name,
                        phone = user.Phone,
                        address = user.Address
                    };

                    var myContent = JsonConvert.SerializeObject(objUser);
                    var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
                    var byteContent = new ByteArrayContent(buffer);
                    byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                    using (HttpClient client = new HttpClient())
                    {
                        using (HttpResponseMessage res = await client.PutAsync(urlCliente + "/" + id, byteContent))
                        {
                            using (HttpContent content = res.Content)
                            {
                                string data = await content.ReadAsStringAsync();
                            }
                        }
                    }


                }
                catch (Exception ex)
                {
                    return NotFound();
                }
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var httpCliente = new HttpClient();
            var json = await httpCliente.GetStringAsync(urlCliente + "/" + id);
            User user = JsonConvert.DeserializeObject<User>(json);

            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        //POST: Users/Delete/5
        [HttpPost, ActionName("DeleteConfirmed")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            // await _userRepository.DeleteById(id);
           // var myContent = JsonConvert.SerializeObject(objUser);
          //  var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
          //  var byteContent = new ByteArrayContent(buffer);
          //  byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.DeleteAsync(urlCliente+"/"+id))
                {
                    using (HttpContent content = res.Content)
                    {
                        string data = await content.ReadAsStringAsync();
                    }
                }
            }


            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> ExportarFile()
        {
            var httpCliente = new HttpClient();

            var json = await httpCliente.GetStringAsync(urlExport);

            return RedirectToAction(nameof(Index));
        }

    }
}
