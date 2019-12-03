using Microsoft.AspNetCore.Mvc;

namespace Inter2.Controllers
{
    public class DashboardController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        //------------------------------------------------
        /*[HttpGet]
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
            e.Id = id;
            if(!ModelState.IsValid)
                return View(e);

            using(var data = new FuncionarioData())
                data.Update(e);
            return RedirectToAction("Index");
        }*/
    }
}