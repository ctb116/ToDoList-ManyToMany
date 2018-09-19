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
        List<Category> allCategories = Category.GetAll();
        return View(allCategories);
    }
    [HttpPost("/items")]
    public ActionResult Create()
    {
      Item newItem = new Item(Request.Form["itemDescription"], Request.Form["itemDueDate"], int.Parse(Request.Form["category"]));
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
        // Dictionary<List<Category>, Item> newDictionary = new Dictionary<List<Category>, Item>() {};
        // Item thisItem = Item.Find(id);
        // List<Category> allCategories = Category.GetAll();
        // newDictionary.Add(allCategories, thisItem);
        Dictionary<string, object> newDictionary = new Dictionary<string, object>();
        List<Category> allCategories = Category.GetAll();
        Item foundItem = Item.Find(id);
        newDictionary.Add("categories",allCategories);
        newDictionary.Add("item",foundItem);
        return View(newDictionary);
    }

    [HttpPost("/items/{id}/update")]
    public ActionResult Update(int id, string newDescription, string newCategoryId)
    {
        Item thisItem = Item.Find(id);

        thisItem.Edit(Request.Form["newDescription"], int.Parse(Request.Form["category"]));
        return RedirectToAction("Index");
    }

    [HttpPost("/items/delete")]
    public ActionResult DeleteAll()
    {
        Item.DeleteAll();
        return View();
    }

    [HttpGet("/items/{id}/delete")]
    public ActionResult Delete(int id)
    {
        Item thisItem = Item.Find(id);
        thisItem.Delete(id);
        return RedirectToAction("Index");
    }


  }
}
