// using Microsoft.AspNetCore.Mvc;
// using ToDoList.Models;
// using System;
// using System.Collections.Generic;
//
// namespace ToDoList.Controllers
// {
//   public class CategoriesController : Controller
//   {
//     [HttpGet("/categories")]
//     public ActionResult Index()
//     {
//         List<Category> allCategories = Category.GetAll();
//         return View(allCategories);
//     }
//
//     [HttpGet("/categories/new")]
//     public ActionResult CreateForm()
//     {
//         return View();
//     }
//
//     [HttpPost("/categories")]
//     public ActionResult Create()
//     {
//         Category newCategory = new Category(Request.Form["categoryName"]);
//         newCategory.Save();
//         return RedirectToAction("Index");
//     }
//
//     [HttpGet("/categories/{id}")]
//     public ActionResult Details(int id)
//     {
//       Dictionary<string, object> model = new Dictionary<string, object>();
//       Category selectedCategory = Category.Find(id);
//       List<Item> categoryItems = selectedCategory.GetItems();
//       model.Add("category",selectedCategory);
//       model.Add("items",categoryItems);
//       return View(selectedCategory);
//     }
//   }
// }
