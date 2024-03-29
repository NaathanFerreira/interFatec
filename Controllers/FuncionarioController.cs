using System;
using Microsoft.AspNetCore.Mvc;
using Inter2.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using System.Linq;
using Inter2.Data;
using Newtonsoft.Json;

namespace Inter2.Controllers
{
    public class FuncionarioController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            using(var data = new FuncionarioData())
            return View(data.Read());
        }
        /*Retorna todos os funcionários por json*/
        public String ViewFunc()
        {
            List<Funcionario> funcionarios = new List<Funcionario>();

            using (var data = new FuncionarioData())
            {
                funcionarios = data.Read();
            }
            string json = JsonConvert.SerializeObject(funcionarios);
        
            return json;
        }
        //------------------------------------------------
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]

        public ActionResult Create(Funcionario e)
        {
            if(!ModelState.IsValid)
            {
                return View(e);
            }
            using(var data = new FuncionarioData())
                data.Create(e);
            return RedirectToAction("Index");
        }
        //---------------------------------------------------

        public IActionResult Delete(int id)
        {
            using(var data = new FuncionarioData())
            {
                data.Delete(id);
            }
            return RedirectToAction("Index");
        }

        //-------------------------------------------------------
        public IActionResult Update(int id)
        {
            using(var data = new FuncionarioData())
                return View(data.Read(id));
        }
        [HttpPost]
        public IActionResult Update(int id, Funcionario e)
        {
            e.IdFuncionario = id;
            if(!ModelState.IsValid)
                return View(e);

            using(var data = new FuncionarioData())
                data.Update(e);
            return RedirectToAction("Index");
        }
    }
}