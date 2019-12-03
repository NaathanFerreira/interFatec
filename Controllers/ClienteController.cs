using System;
using Microsoft.AspNetCore.Mvc;
using Inter2.Data;
using Inter2.Models;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Inter2.Controllers
{
    public class ClienteController : Controller
    {
        public IActionResult Index()
        {
            using(var data = new ClienteData())
                return View(data.Read());            
        }
        //-------------------------------------------------
        /*Retorna todos os clientes por json*/
        /*public String ViewCli()
        {
            List<Cliente> clientes = new List<Cliente>();

            using (var data = new ClienteData())
            {
                clientes = data.Read();
            }
            string json = JsonConvert.SerializeObject(clientes);
        
            return json;
        }*/
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Cliente e)
        {
            if(!ModelState.IsValid)
            {
                return View(e);
            }
            using(var data = new ClienteData())
                data.Create(e);
            return RedirectToAction("Index");
        }
        //------------------------------------------------------------

        public IActionResult Delete(int id)
        {
            using(var data = new ClienteData())
                data.Delete(id);
            return RedirectToAction("Index");
        }
        //---------------------------------------------------------
        public IActionResult Update(int id)
        {
            using(var data = new ClienteData())
                return View(data.Read(id));
        }
        [HttpPost]
        public IActionResult Update(int id, Cliente e)
        {
            e.IdCliente = id;
            if(!ModelState.IsValid)
                return View(e);

            using(var data = new ClienteData())
                data.Update(e);
            return RedirectToAction("Index");
        }

    }

}