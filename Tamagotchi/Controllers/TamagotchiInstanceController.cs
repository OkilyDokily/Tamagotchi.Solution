using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Tamagotchi.Models;
namespace Tamagotchi.Controllers
{
    public class TamagotchiInstanceController : Controller
    {
        [HttpGet("/tamagotchis/")]
        public ActionResult Index()
        {
            List<TamagotchiInstance> all = TamagotchiInstance.GetAll();
            return View(all);
        }

        [HttpGet("/tamagotchis/new")]
        public ActionResult New()
        {
            return View();
        }

        [HttpPost("/tamagotchis")]
        public ActionResult Create(string name)
        {
            new TamagotchiInstance(name);

           return RedirectToAction("Index");
        }

        [HttpGet("/tamagotchis/{id}")]
        public ActionResult Item(int id)
        {
            TamagotchiInstance item = TamagotchiInstance.Find(id);
            return View(item);
        }

        [HttpPost("/tamagotchis/feed/{id}")]
        public ActionResult Feed(int id)
        {
            TamagotchiInstance item = TamagotchiInstance.Find(id);
            item.IncreaseFood();
            return RedirectToAction("Item", new {id = id});
        }

        [HttpPost("/tamagotchis/play/{id}")]
        public ActionResult Play(int id)
        {
            TamagotchiInstance item = TamagotchiInstance.Find(id);
            item.IncreaseAttention();
            return RedirectToAction("Item", new {id = id});
        }

        [HttpPost("/tamagotchis/sleep/{id}")]
        public ActionResult Sleep(int id)
        {
            TamagotchiInstance item = TamagotchiInstance.Find(id);
            item.IncreaseRest();
            return RedirectToAction("Item", new {id = id});
        }
        [HttpPost("/tamagotchis/delete")]
        public ActionResult Delete()
        {
            TamagotchiInstance.ClearAll();
            return RedirectToAction("Index");
        }

        [HttpPost("/tamagotchis/time")]
        public ActionResult Time()
        {
            TamagotchiInstance.MakeTimePass();
            return RedirectToAction("Index");
        }
    }
}