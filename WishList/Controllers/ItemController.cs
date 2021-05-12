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

[HttpPost]
public IActionResult Delete(int Id){

    //get the Item

    var item = _context.Items.Where(x => x.Id == Id).ToList();
    Console.WriteLine(item.First().Description);
    if(item.Count > 0){
         _context.Items.Remove(item.First());
        _context.SaveChanges();
          

    }


       

      return RedirectToAction("Index");

}

    }
}