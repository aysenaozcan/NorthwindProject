using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    //Context: Db tabloları ile proje classlarını bağlamak
    //Entitytframework kurarken base bır sınıf gelır yanı context, ve db contextin ta kendısıdır.
    public class NorthwindContext:DbContext
    {   
        //projemızın hangı verı tabanıyla ılıskılı olduğunu gosterecek.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\ProjectModels;Database=Northwind;Trusted_Connection=true");
        }

        //Aşağıdakiler koddakı hangı class verıtabanındakı hangı tabloya bağlanacak bunu yapmanı sağlar.
        public DbSet<Product> Products { get; set; } 
        public DbSet<Category> Categories{ get; set; }
        public DbSet<Customer> Customers{ get; set; }
        public DbSet<Order> Orders { get; set; }
 
    }
    
}
