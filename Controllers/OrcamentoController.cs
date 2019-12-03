using System;
using Microsoft.AspNetCore.Mvc;
using Inter2.Models;
using System.Collections.Generic;
using Inter2.Data;
using Newtonsoft.Json;

namespace Inter2.Controllers
{
    public class OrcamentoController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public String Create(Orcamento o)
        {
            using (var data = new OrcamentoData())
                data.Create(o);

            string json = JsonConvert.SerializeObject(o);

            return json;
        }
    }
}