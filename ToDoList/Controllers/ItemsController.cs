using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;
using System;
using System.Collections.Generic;

namespace ToDoList.Controllers
{
    public class ItemsController : Controller
    {
      [HttpGet("/items")]
        public ActionResult Index()
        {
            List<Item> allItems = Item.GetAll();
            return View(allItems);
        }

        [HttpGet("/items/new")]
        public ActionResult CreateForm()
        {
            return View();
        }
        [HttpPost("/items")]
        public ActionResult Create()
        {
          // description = Request.Form("itemDescription");
          Item newItem = new Item(Request.Form["itemDescription"], Request.Form["itemDueDate"]);
          newItem.Save();
          List<Item> allItems = Item.GetAll();
          return View("Index", allItems);
        }
        [HttpPost("/items/sorted")]
        public ActionResult Filter()
        {
          List<Item> allItems = Item.Filter(Request.Form["order"]);
          return View("Index", allItems);
        }
        [HttpGet("/items/{id}")]
        public ActionResult Detail(int id)
        {
          Item newItem = Item.Find(id);

            return View(newItem);
        }

    }
}
