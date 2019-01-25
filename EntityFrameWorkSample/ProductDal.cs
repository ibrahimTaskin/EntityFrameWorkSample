using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameWorkSample
{
    class ProductDal
    {
        public List<Product> GetAll()
        {
            using (ETicaretContext context = new ETicaretContext())
            {
                return context.Products.ToList(); //context imizdeki bütün verileri liste halinde çektik
            }
        }

        public List<Product> GetByName(string key)
        {
            using (ETicaretContext context=new ETicaretContext())
            {
                return context.Products.Where(p => p.Name.Contains(key)).ToList();
                //anahtar cümleyi içeren kelimeyi getir.
            }
        }

        public List<Product> GetByUnitPrice(decimal price)
        {
            using (ETicaretContext context=new ETicaretContext())
            {
                return context.Products.Where(p => p.UnitPrice >= price).ToList();
                //verilen değere eşit ve ya büyük fiyatlı ürünü getir.
            }
        }

        public List<Product> GetByUnitPrice(decimal min,decimal max)
        {
            using (ETicaretContext context = new ETicaretContext())
            {
                return context.Products.Where(p => p.UnitPrice >= min && p.UnitPrice<=max).ToList();
                //verilen değerler arasında varsa ürün getir.
            }
        }

        public Product GetById(int id)
        {
            using (ETicaretContext context = new ETicaretContext())
            {
                var result= context.Products.FirstOrDefault(p => p.Id == id);
                return result;
                //verilen id nosuna göre arama yap.
            }
        }

        public void Add(Product product)
        {
            using (ETicaretContext context=new ETicaretContext())
            {
                var deger = context.Entry(product);
                deger.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Uodate(Product product)
        {
            using (ETicaretContext context=new ETicaretContext())
            {
                var deger = context.Entry(product);
                deger.State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void Delete(Product product)
        {
            using (ETicaretContext context=new ETicaretContext())
            {
                var deger = context.Entry(product);
                deger.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }




    }
}
