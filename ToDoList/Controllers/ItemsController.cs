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
      Item newItem = new Item(Request.Form["itemDescription"], Request.Form["itemDueDate"], int.Parse(Request.Form["itemCategoryId"]));
      newItem.Save();
      List<Item> allItems = Item.GetAll();
      return RedirectToAction("Index");
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

    [HttpGet("/items/{id}/update")]
    public ActionResult UpdateForm(int id)
    {
        Item thisItem = Item.Find(id);
        return View(thisItem);
    }

    [HttpPost("/items/{id}/update")]
    public ActionResult Update(int id, string newDescription, string newCategoryId)
    {
        Item thisItem = Item.Find(id);
        int newIntCategoryId = int.Parse(newCategoryId);
        thisItem.Edit(newDescription, newIntCategoryId);
        return RedirectToAction("Index");
    }

    [HttpPost("/items/delete")]
    public ActionResult DeleteAll()
    {
        Item.DeleteAll();
        return View();
    }
  }
}
