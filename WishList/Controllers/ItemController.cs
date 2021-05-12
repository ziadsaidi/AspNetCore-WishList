using Microsoft.AspNetCore.Mvc;
using WishList.Data;
using WishList.Models;
using System.Linq;
using System;
namespace WishList.Controllers {


    public class ItemController : Controller {

private readonly ApplicationDbContext _context;

public ItemController(ApplicationDbContext context){
    _context = context;
}


public IActionResult Index(){
    return View("Index",_context.Items.ToList());
}

[HttpGet]
public IActionResult Create(){
    return View("Create");
}

[HttpPost]
public IActionResult Create(Item item){


_context.Items.Add(item);
_context.SaveChanges();

  return RedirectToAction("Index");
    
}

public IActionResult Delete(int id){
    var item = _context.Items.FirstOrDefault(x =>x.Id == id);
    _context.Items.Remove(item);
    _context.SaveChanges();
    return RedirectToAction("Index");

}

    }
}