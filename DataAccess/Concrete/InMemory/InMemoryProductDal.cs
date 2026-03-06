 using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {   List<Product> _products;

        public InMemoryProductDal()
        {   // Hazır veri seti. Kendi db miz.
            _products = new List<Product>() { 
                new Product { ProductId=1, CategoryId=2, ProductName="Bardak", UnitPiece=5, UnitPrice=25},
                new Product { ProductId=2, CategoryId=2, ProductName="Tabak", UnitPiece=50, UnitPrice=5},
                new Product { ProductId=3, CategoryId=3, ProductName="Ütü", UnitPiece=10, UnitPrice=250},
                new Product { ProductId=4, CategoryId=3, ProductName="Bulaşık Makinesi", UnitPiece=25, UnitPrice=2500}};
        }
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {   //LINQ --> Language Integreted Query
            // => Lambda
            // SingleOrDefault(p=>   bu kısım foreach görevi görür.
            Product productToDelete = _products.SingleOrDefault(p=>p.ProductId==product.ProductId);

            _products.Remove(productToDelete);
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public List<Product> GetAllByCategory(int categoryId)
        {   // Category Id 'si girilen Id ile ile aynı olması durumunda o Idleri ayrı bir listede bana gösterir 
            return _products.Where(p=>p.CategoryId==categoryId).ToList();
        }

        

        public void Update(Product product)
        {   // Gönderdiğim id yi ürün listsinde o id'ye sahip ürünü bul.
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);

            productToUpdate.ProductName = product.ProductName; 
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitPiece = product.UnitPiece;
            productToUpdate.UnitPrice = product.UnitPrice;
            
           
        }
    }
}
