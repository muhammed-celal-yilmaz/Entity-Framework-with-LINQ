using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Framework
{
    public class ProductDal
    {
        public List<Product> GetAll()
        {
            using (ETicaretContext context = new ETicaretContext())
            {

                return context.Products.ToList();

            }

        }

        public List<Product> GetByName(string key)
        {
            using (ETicaretContext context = new ETicaretContext())
            {

                return context.Products.Where(p=>p.Name.Contains(key)).ToList();

            }

        }

        public List<Product> GetByUnitPrice(decimal price)
        {
            using (ETicaretContext context = new ETicaretContext())
            {

                return context.Products.Where(p => p.UnitPrice>=price).ToList();

            }

        }

        public List<Product> GetByUnitPrice(decimal min,decimal max)
        {
            using (ETicaretContext context = new ETicaretContext())
            {

                return context.Products.Where(p => p.UnitPrice>=min && p.UnitPrice<=max).ToList();

            }

        }

        public Product GetById(int id)
        {
            using (ETicaretContext context = new ETicaretContext())
            {
                var result = context.Products.FirstOrDefault(p => p.Id == id);
                return result;
                // Birden fazla id gelirse SingleOrDefault ile çalışırız.

            }

        }

        public void Add(Product product)
        {
            using (ETicaretContext context = new ETicaretContext())
            {
                var entity = context.Entry(product);
                entity.State = System.Data.Entity.EntityState.Added;
               // 2.yöntem context.Products.Add(product);
                context.SaveChanges();
            }
        }

        public void Update(Product product)
        {
            using (ETicaretContext context = new ETicaretContext())
            {
                var entity = context.Entry(product);
                entity.State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }

        }

        public void Delete(Product product)
        {
            using (ETicaretContext context = new ETicaretContext())
            {
                var entity = context.Entry(product);
                entity.State = System.Data.Entity.EntityState.Deleted;
                context.SaveChanges();
            }

        }

        

    }

}