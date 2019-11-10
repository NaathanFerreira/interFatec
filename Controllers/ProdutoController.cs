using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Inter2.Models;
using Inter2.Data;
using Microsoft.AspNetCore.Http;

namespace Inter2.Controllers
{
    public class ProdutoController : Controller
    {
        public IActionResult Index()
        {
            using(var data = new ProdutoData())
                return View(data.Read());            
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Produto e)
        {
            if(!ModelState.IsValid)
            {
                return View(e);
            }

            using(var data = new ProdutoData())
                data.Create(e);

            return RedirectToAction("Index");
        }

         public IActionResult Delete(int id)
        {
            using(var data = new ProdutoData())
                data.Delete(id);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            using(var data = new ProdutoData())
                return View(data.Read(id));
        }

        [HttpPost]
        public IActionResult Update(int id, Produto e)
        {
            e.Id = id;

            if(!ModelState.IsValid)
                return View(e);
        
            using(var data = new ProdutoData())
                data.Update(e);

            return RedirectToAction("Index");
        }
    }
}