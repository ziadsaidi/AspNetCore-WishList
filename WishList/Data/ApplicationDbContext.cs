
using Microsoft.EntityFrameworkCore;
using WishList.Models;

namespace  WishList.Data {

public class ApplicationDbContext: DbContext{

    public ApplicationDbContext(DbContextOptions options):base(options){

    }

    //add properties 

    public DbSet<Item> Items { get;set;}

}

}