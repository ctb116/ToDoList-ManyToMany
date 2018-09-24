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
    public ActionResult Create(string itemDescription, string itemDueDate) //userinput
    {
      Item newItem = new Item(itemDescription, itemDueDate);
      newItem.Save();
      return RedirectToAction("Index");
    }
    //     [HttpPost("/items/sorted")]
    //     public ActionResult Filter()
    //     {
    //       List<Item> allItems = Item.Filter(Request.Form["order"]);
    //       return View("Index", allItems);
    // }
    [HttpGet("/items/{id}")]
    public ActionResult Details(int id)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Item selectedItem = Item.Find(id);
      List<Category> itemCategories = selectedItem.GetCategories();
      List<Category> allCategories = Category.GetAll();
      model.Add("selectedItem", selectedItem);
      model.Add("itemCategories", itemCategories);
      model.Add("allCategories", allCategories);
      return View(model);
    }
    [HttpPost("/items/{itemId}/categories/new")]
    public ActionResult AddCategory(int itemId, int categoryId)
    {
      Item item = Item.Find(itemId);
      Category category = Category.Find(categoryId);
      item.AddCategory(category);
      return RedirectToAction("Details",  new { id = itemId });
    }
    //
    //     [HttpGet("/items/{id}/update")]
    //     public ActionResult UpdateForm(int id)
    //     {
    //         // Dictionary<List<Category>, Item> newDictionary = new Dictionary<List<Category>, Item>() {};
    //         // Item thisItem = Item.Find(id);
    //         // List<Category> allCategories = Category.GetAll();
    //         // newDictionary.Add(allCategories, thisItem);
    //         Dictionary<string, object> newDictionary = new Dictionary<string, object>();
    //         List<Category> allCategories = Category.GetAll();
    //         Item foundItem = Item.Find(id);
    //         newDictionary.Add("categories",allCategories);
    //         newDictionary.Add("item",foundItem);
    //         return View(newDictionary);
    //     }
    //
    //     [HttpPost("/items/{id}/update")]
    //     public ActionResult Update(int id, string newDescription)
    //     {
    //         Item thisItem = Item.Find(id);
    //
    //         thisItem.Edit(Request.Form["newDescription"];
    //         return RedirectToAction("Index");
    //     }
    //
    //     [HttpPost("/items/delete")]
    //     public ActionResult DeleteAll()
    //     {
    //         Item.DeleteAll();
    //         return View();
    //     }
    //
    //     [HttpGet("/items/{id}/delete")]
    //     public ActionResult Delete(int id)
    //     {
    //         Item thisItem = Item.Find(id);
    //         thisItem.Delete(id);
    //         return RedirectToAction("Index");
    //     }
    //
    //
  }
}
