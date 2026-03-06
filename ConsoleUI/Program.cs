

/*int[] array = { 2, 3, 4, 5, 1, 7};

for (int i = 0; i < array.Length; i++)
{
    if()
}*/


using Business.Concrete;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

namespace ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager(new InMemoryProductDal());
            
            Product product1 = new Product { ProductId = 5, ProductName = "Araba", CategoryId = 4, UnitPiece = 1, UnitPrice = 1000000 };
            
            productManager.Add(product1);
            
            productManager.Add(new Product { ProductId = 6, ProductName = "Ev", CategoryId = 4, UnitPiece = 1, UnitPrice = 7000000 });
            
            foreach (var item in productManager.GetAll())
            {
                Console.WriteLine(item.ProductName + "---->" + item.UnitPrice );
            }



            productManager.Delete(product1);

            Console.WriteLine("*******************");

            foreach (var item in productManager.GetAll())
            {
                Console.WriteLine(item.ProductName + "---->" + item.UnitPrice);
            }




            productManager.Update(new Product { ProductId=6 ,CategoryId=4, ProductName="Motorsiklet", UnitPiece= 1, UnitPrice=7000000 });
            
            Console.WriteLine("*******************");
            
            foreach(var item in productManager.GetAll())
            {
                Console.WriteLine(item.ProductName + "---->" + item.UnitPrice);
            }


            
        }



    }
}

